﻿using iHRM.Core.i_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Win.Cls;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Reflection;

namespace iHRM.Win.Frm.Report
{
    public partial class BCNVQuetTheKhongDKCaLam : frmBase
    {
        iHRM.Core.Business.DbObject.dcDatabaseMCCDataContext db_mcc = new iHRM.Core.Business.DbObject.dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);
        DataTable dt = null;
        public BCNVQuetTheKhongDKCaLam()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            repositoryItemLookUpEditMay.DataSource = db_mcc.tbMayChamCongs;
            //chonKyLuong1.TuNgay = DateTime.Now;
            //chonKyLuong1.DenNgay = DateTime.Now;
            TranslateForm();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ..."; //text hiện ở status
            dw_it.OnDoing = (s, ev) => //hàm lấy dữ liệu chạy ngầm
            {
                dt = Provider.ExecuteDataTableReader("p_BaoCao_GetNVQuetTheKhongDangKy",
                new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue()));

                dw_it.bw.ReportProgress(1, dt);

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
            };
            main.Instance.DoworkItem_Reg(dw_it);

        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
          
            if (grv.DataSource == null )
            {
                GUIHelper.MessageBox("Chưa có dữ liệu");
                return;
            }
            grv.OptionsPrint.UsePrintStyles = false;
            ShowPreview(grd);
            
        }

        private void btnXuatExel_Click(object sender, EventArgs e)
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
                bw.ReportProgress(-1, "Xuất excel nhân viên quẹt thẻ không đăng ký ca làm"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (dt == null || dt.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu
                    return;
                }


                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

                ExcelExportHelper ex = new ExcelExportHelper("Report/BCNhanVienQuetVanTayKhongDKCaLam.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("A4", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);
                ex.SetNamedRangeValue("Ngay", "Ngày tạo: " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.FillDataTable(dt); // Fill BC_FillData
                ex.RendAndFlush("BCNhanVienQuetVanTayKhongDKCaLam" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
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
        #region Translate language
        public static List<string> listCtr = new List<string>();
        public static Dictionary<string, string> myData = new Dictionary<string, string>();

        private IEnumerable<DevExpress.XtraGrid.Columns.GridColumn> EnumerateGridColumn()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraGrid.Columns.GridColumn).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraGrid.Columns.GridColumn)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<DevExpress.XtraEditors.SimpleButton> EnumerateSimpleButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.SimpleButton).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.SimpleButton)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<ToolStripButton> EnumerateToolStripButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(ToolStripButton).IsAssignableFrom(field.FieldType)
                   let component = (ToolStripButton)field.GetValue(this)
                   where component != null
                   select component;
        }

        private IEnumerable<DevExpress.XtraEditors.LabelControl> EnumerateLabelControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.LabelControl).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.LabelControl)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<DevExpress.XtraEditors.CheckEdit> EnumerateCheckEdit()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.CheckEdit).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.CheckEdit)field.GetValue(this)
                   where component != null
                   select component;
        }
        //DevExpress.XtraGrid.Views.BandedGrid.GridBand
        private IEnumerable<DevExpress.XtraGrid.Views.BandedGrid.GridBand> EnumerateGridBand()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraGrid.Views.BandedGrid.GridBand).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraGrid.Views.BandedGrid.GridBand)field.GetValue(this)
                   where component != null
                   select component;
        }
        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new System.Data.SqlClient.SqlParameter("CtrName", nameCrt),

                           new System.Data.SqlClient.SqlParameter("FormName", this.Name.ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                //có dữ liệu cho dùng chung
                if (ds.Tables[1].Rows.Count == 0)
                {
                    //không dùng riêng
                    return ds.Tables[0].Rows[0][lang].ToString().Trim();

                }
                else
                {
                    // có dùng riêng 
                    return ds.Tables[1].Rows[0][lang].ToString().Trim();
                }
            }
            else
            {
                return "";
            }

        }
        public void TranslateForm()
        {
            myData.Clear();
            listCtr.Clear();
            string langTrans = LoginHelper.langTrans;
            string formText = SelectTranslate(this.Name, langTrans);
            if (formText != "")
            {
                this.Text = formText;
            }
            #region Khai báo list loai control trong form
            var _GridColumn = EnumerateGridColumn();
            var _ToolStripButton = EnumerateToolStripButton();
            var _LableControl = EnumerateLabelControl();
            var _SimpleButton = EnumerateSimpleButton();
            var _CheckEdit = EnumerateCheckEdit();
            var _GridBand = EnumerateGridBand();
            #endregion

            #region Dịch form
            foreach (DevExpress.XtraGrid.Columns.GridColumn s in _GridColumn)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Caption);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Caption = trans;
                }
            }
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand s in _GridBand)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Caption);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Caption = trans;
                }
            }
            foreach (ToolStripButton s in _ToolStripButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.SimpleButton s in _SimpleButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.LabelControl s in _LableControl)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.CheckEdit s in _CheckEdit)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            myData.Add(this.Name, this.Text);
            listCtr.Add(this.Name);


            #endregion
        }

        #endregion
        private void BCNVQuetTheKhongDKCaLam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                Viewer_Load(null, null);
            }
        }
    }
}
