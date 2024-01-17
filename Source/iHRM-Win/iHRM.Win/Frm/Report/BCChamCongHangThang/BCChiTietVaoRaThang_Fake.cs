using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.i_Report;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Report
{
    public partial class BCChiTietVaoRaThang_Fake : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        DataTable dt = new DataTable();
        public BCChiTietVaoRaThang_Fake()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ..."; //text hiện ở status
            dw_it.OnDoing = (s, ev) => //hàm lấy dữ liệu chạy ngầm
            {
                DateTime day;
                DateTime todates;
                day = chonKyLuong1.TuNgay;
                todates = chonKyLuong1.DenNgay;

                dt = logic.GetReportquetTheMonth_Fake(day, todates, ucChonDoiTuong_DS1.GetValue());
                dt.Columns.Add("TT");
                dt.Columns.Add("tgTangCa", typeof(double));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ngay"] != null && dr["ngay"].ToString() != "")
                        {
                            dr["ngay"] = Convert.ToDateTime(dr["ngay"].ToString()).ToShortDateString();
                        }
                        dr["TT"] = GetTrangThai(dr, 2);
                        if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                            dr["tgDiMuon"] = 0;
                        if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                        {
                            dr["tgTangCa"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                            dr["tgVeSom"] = 0;
                        }
                    }
                    dw_it.bw.ReportProgress(1, dt);
                }
                else
                    GUIHelper.Notifications("Không có dữ liệu");
            };
            dw_it.OnProcessing = (ps, data) => //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing
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
                bw.ReportProgress(-1, "Xuất excel dữ liệu vào ra tháng"); // Set caption

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

                ExcelExportHelper ex = new ExcelExportHelper("Report/ReportChiTietVaoRaThang.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("A4", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);
                ex.SetNamedRangeValue("Ngay", "Ngày tạo: " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.FillDataTable(dt); // Fill BC_FillData
                ex.RendAndFlush("BaoCaoChiTietVaoRaThang_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
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
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            TranslateForm();
        }
        private string GetTrangThai(DataRow dr, int type = 1)
        {
            return Core.Controller.QuetThe.Helper.GetTrangThai(dr);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Excel 2007|*.xls";
            if (sd.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                if (System.IO.File.Exists(sd.FileName))
                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception exc)
            {
                GUIHelper.MessageError(exc.Message, this.Text);
                return;
            }
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ..."; //text hiện ở status
            dw_it.OnDoing = (s, ev) => //hàm lấy dữ liệu chạy ngầm
            {
                #region lấy dữ liệu
                DateTime day;
                DateTime todates;
                var dtData = new DataTable();
                day = chonKyLuong1.TuNgay;
                todates = chonKyLuong1.DenNgay;

                dtData = logic.GetReportquetTheMonth_Fake(day, todates, ucChonDoiTuong_DS1.GetValue());
                dtData.Columns.Add("TT");
                dtData.Columns.Add("tgTangCa", typeof(double));
                dtData.Columns.Add("tgQuetDen1", typeof(string));
                dtData.Columns.Add("tgQuetVe1", typeof(string));
                if (dtData.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtData.Rows)
                    {
                        if (dr["ngay"] != null && dr["ngay"].ToString() != "")
                        {
                            dr["ngay"] = Convert.ToDateTime(dr["ngay"].ToString()).ToShortDateString();
                        }
                        dr["TT"] = GetTrangThai(dr, 2);
                        if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                            dr["tgDiMuon"] = 0;
                        if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                        {
                            dr["tgTangCa"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                            dr["tgVeSom"] = 0;
                        }
                        if (dr["tgQuetDen"] != DBNull.Value && dr["tgQuetDen"].ToString() != "")
                            dr["tgQuetDen1"] = dr["tgQuetDen"].ToString().Substring(0, 5);
                        if (dr["tgQuetVe"] != DBNull.Value && dr["tgQuetVe"].ToString() != "")
                            dr["tgQuetVe1"] = dr["tgQuetVe"].ToString().Substring(0, 5);
                    }
                    dw_it.bw.ReportProgress(1, dtData);
                }
                else
                    GUIHelper.Notifications("Không có dữ liệu");
                #endregion
                
            };
            dw_it.OnProcessing = (ps, data) => //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel();
                        ExcelExportHelper ex = new ExcelExportHelper("Report/ReportChiTietVaoRaThang.xls");
                        ex.WriteToCell("A2", "TÌNH HÌNH QUẸT THẺ NGÀY " + chonKyLuong1.TuNgay.Date.ToString("dd/MM"));
                        ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                        ex.WriteToCell("C1", LoginHelper.Company.CompanyName);

                        ex.WriteToCell("T6", string.Format("In ngày {0:dd/MM/yyyy}", DateTime.Now));
                        ex.FillDataTable(data.UserState as DataTable);
                        ex.RendAndFlush("ReportChiTietVaoRaThang_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
                        GUIHelper.Notifications("Xuất dữ liệu thành công", "Xuất excel", GUIHelper.NotifiType.download);
                        break;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);


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
        private void BCChiTietVaoRaThang_KeyDown(object sender, KeyEventArgs e)
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
