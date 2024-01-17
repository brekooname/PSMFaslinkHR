using iHRM.Core.i_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace iHRM.Win.Frm.Report
{
    public partial class BCLog2 : frmBase
    {
        dcDatabaseDataContext db;
        DataTable data = new DataTable();

        BCLog2_detail frmDetail = new BCLog2_detail();

        public BCLog2()
        {
            InitializeComponent();
            db = new dcDatabaseDataContext(iHRM.Core.Business.Provider.ConnectionString);
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            searchLookUpNguoiSD.Properties.DataSource = db.w5sysUsers.ToList();
            searchLookUpNguoiSD.EditValue = null;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing += (s, ev) =>
            {
                data = Log2.GetLog(
                    chonKyLuong1.TuNgay,
                    chonKyLuong1.DenNgay,
                    searchLookUpNguoiSD.EditValue as long?
                );
                dw_it.bw.ReportProgress(1, data);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        grcNVLamCa.DataSource = data.UserState;
                        btnFind.Enabled = true;
                        break;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save
            sd.Filter = "Excel 2007|*.xls";
            if (sd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))
                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);
                return;
            }
            //---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới
            ge.OnDoing += (bw) =>
            {
                bw.ReportProgress(-1, "Xuất excel thông tin nhân viên làm ca"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (data == null || data.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu
                    return;
                }


                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

                ExcelExportHelper ex = new ExcelExportHelper("Report/ReportUserAction.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("N6", "Ngày tạo:  " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);
                ex.WriteToCell("A4", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));
                ex.FillDataTable(data); // Fill BC_FillData
                ex.RendAndFlush("ReportUserAction" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
                bw.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
                }
                else if (ps == 2)
                {// Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.
                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);
                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName,
                            UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void grv_DoubleClick(object sender, EventArgs e)
        {
            var r = grv.GetFocusedDataRow();
            if (r == null)
                return;

            frmDetail.myID = r["id"] as Guid?;
            frmDetail.ViewData();
            frmDetail.Show(this);
        }

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcNVLamCa.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }
    }
}
