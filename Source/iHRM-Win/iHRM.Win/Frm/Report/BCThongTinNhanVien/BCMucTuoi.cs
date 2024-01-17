using iHRM.Core.Business;
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
using iHRM.Win.Cls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace iHRM.Win.Frm.Report
{
    public partial class BCMucTuoi : frmBase
    {
        DataTable dtData = new DataTable();
        public BCMucTuoi()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            dateMocThoiGian.DateTime = DateTime.Now;
        }

        int fromAge, toAge;
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            fromAge = Convert.ToInt16(txtMucTuoi.Text.Split('-')[0]);
            toAge = Convert.ToInt16(txtMucTuoi.Text.Split('-')[1]);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) =>
            {
                dtData = Core.Business.Provider.ExecuteDataTableReader("p_GetReportMucTuoi",     
                    Provider.CreateParameter_StringList("EmployeeID", ucChonDoiTuong_DS1.GetValue()),
                    new SqlParameter("fromAge", fromAge),
                    new SqlParameter("toAge", toAge),
                    new SqlParameter("mocThoiGian", dateMocThoiGian.DateTime),
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay)
                );

                dw_it.bw.ReportProgress(1, dtData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        grd.DataSource = data.UserState;
                        btnFind.Enabled = true;
                        break;
                }
            }; //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing

            main.Instance.DoworkItem_Reg(dw_it);
        }

        //void OnDoing1(BackgroundWorker bw)
        //{
        //    var vp_RecordCount = new SqlParameter("vp_RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
        //    var dt = Core.Business.Provider.ExecuteDataTableReader("p_GetReportMucTuoi",
        //        new SqlParameter("vp_PageSize", pageNavigator1.PageSize),
        //        new SqlParameter("vp_CurrentPage", pageNavigator1.CurrentPage),
        //        vp_RecordCount,
        //        new SqlParameter("fromAge", fromAge),
        //        new SqlParameter("toAge", toAge),
        //        new SqlParameter("mocThoiGian", dateMocThoiGian.DateTime),
        //        new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
        //        new SqlParameter("denNgay", chonKyLuong1.DenNgay),
        //        new SqlParameter("depID", chonPhongBan1.SelectedValue)
        //    );

        //    dw_it.bw.ReportProgress(1, dt);
        //    dw_it.bw.ReportProgress(2, vp_RecordCount.Value);
        //    dw_it.bw.ReportProgress(3, (int)vp_RecordCount.Value);
        //    dw_it.bw.ReportProgress(4, vp_RecordCount.SqlValue);
        //}

        //private void OnReport1(int ps, object data)
        //{
        //    switch (data.ProgressPercentage)
        //    {
        //        case 1:
        //            grd.DataSource = data;
        //            btnFind.Enabled = true;
        //            break;
        //        case 3:
        //            pageNavigator1.RecordCount = (int)data;
        //            break;
        //    }
        //}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //ExportGrid(grd);
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
                bw.ReportProgress(-1, "Xuất excel thông tin mức tuổi"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (dtData == null || dtData.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu
                    return;
                }


                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

                ExcelExportHelper ex = new ExcelExportHelper("Report/BaoCaoMucTuoi.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("G6", "Ngày tạo:  " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);
                ex.WriteToCell("A4", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));
                ex.FillDataTable(dtData); // Fill BC_FillData
                ex.RendAndFlush("BaoCaoMucTuoi" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
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

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grd.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }
    }
}
