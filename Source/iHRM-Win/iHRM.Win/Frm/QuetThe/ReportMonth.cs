using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Win.Frm.XtraReportTemplate;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using iHRM.Win.ExtClass;
using iHRM.Common.Code;
using iHRM.Win.DungChung;
using DevExpress.XtraGrid;
using System.Reflection;


namespace iHRM.Win.Frm.QuetThe
{
    public partial class ReportMonth : frmBase
    {
        Core.Controller.QuetThe.ReportMonth controller = new Core.Controller.QuetThe.ReportMonth();

        dlgReportMonth dlgEditor = new dlgReportMonth();

        dsXuLyQuetThe ds;

        DataTable dt = new DataTable();

        public bool Chitietbangcong = false;

        public ReportMonth()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            toolStripPhanTichCong.Visible = BitHelper.Has(iRule.customRules ?? 0, 1);//bảng tính công
            toolStripPhanTichCong_TamUng.Visible = BitHelper.Has(iRule.customRules ?? 0, 1);//bảng tính công tạm ứng

            toolStripChiTiet.Enabled = Chitietbangcong = BitHelper.Has(iRule.customRules ?? 0, 2);//chi tiết bảng công

            toolStripButton2.Enabled = BitHelper.Has(iRule.customRules ?? 0, 4);//Xuất Excel

            toolStripPrint.Enabled = BitHelper.Has(iRule.customRules ?? 0, 8);//In bảng công tất cả trên lưới

            //toolStripPrint.Enabled = BitHelper.Has(iRule.customRules ?? 0, 16);//In bảng công tất cả trên lưới

            dlgEditor.Owner = this;

            LoadGrvLayout(grv);
            TranslateForm();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            dw_it.Caption = "Đang tải dữ liệu...";

            dw_it.OnDoing = (s, ev) =>
            {

                    dt = controller.GetData(ucChonDoiTuong_DS1.GetValue(),

                    chonKyLuong1.TuNgay,

                    chonKyLuong1.DenNgay,

                    true,

                    ucChonDoiTuong_DS1.getKhoiPBvalue()
                );

                dw_it.bw.ReportProgress(1, dt);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = data.UserState; btnFind.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            ExportGrid(grd);
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
                bw.ReportProgress(-1, "Xuất excel bảng công chi tiết"); // Set caption

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

                ExcelExportHelper ex = new ExcelExportHelper("Report/ReportBangCongChiTiet.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("A2", "BẢNG CHẤM CÔNG THÁNG " + chonKyLuong1.TuNgay.Date.ToString("MM") + " NĂM " + chonKyLuong1.DenNgay.Date.ToString("yyyy"));
                ex.WriteToCell("H5", chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy"));
                ex.WriteToCell("AI10", "Đông Hưng, ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.ToString("MM") + " năm " + DateTime.Now.ToString("yyyy"));
                ex.WriteToCell("AJ15", LoginHelper.user.caption);
                ex.FillDataTable(dt); // Fill BC_FillData
                ex.RendAndFlush("ReportBangCongChiTiet" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!Chitietbangcong)

                return;

            var r = grv.GetFocusedDataRow();

            if (r != null)
            {
                dlgEditor.empID = DbHelper.DrGetString(r, "EmployeeID");

                dlgEditor.empName = DbHelper.DrGetString(r, "tenNV");

                dlgEditor.tuNgay = chonKyLuong1.TuNgay;

                dlgEditor.denNgay = chonKyLuong1.DenNgay;

                dlgEditor.Show();

                dlgEditor.LoadData();
            }
        }

        private void grv_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;
            if (e.Column != colTotal && e.Column != colDepName_Final && e.Column != colLineName && e.Column != colTeamName
                && e.Column != colNgayVaoLam && e.Column != colEmployeeName && e.Column != colEmployeeID
                && e.Column != colNghiCoLuong && e.Column != colNghiKhongLuong && e.Column != colNghiCheDo 
                && e.Column != colNghiKhongPhep && e.Column != colPosName && e.Column !=  colTotal_LamThem
                && e.Column != colNormalOT && e.Column != colNightOT && e.Column != colTotalOT
                && e.Column != colNghiPhepNam && e.Column != colTCDemLT && e.Column != colTCNgayLT && e.Column != colTotal_TCLamThem
                && e.Column != colSoLanDTVS5 && e.Column != colSoLanDTVS510 && e.Column != colSoLanDTVS10 && e.Column != colLeftdate
                )
            {
                int ngay = Convert.ToInt32(e.Column.GetCaption());

                if (ngay >= chonKyLuong1.TuNgay.Day)
                {
                    if (DateTime.DaysInMonth(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month) < ngay)
                    {
                        return;
                    }

                    DateTime a = new DateTime(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month, ngay);

                    if (a.DayOfWeek == DayOfWeek.Sunday)
                    {
                        e.Appearance.BackColor = Color.Lavender;
                    }
                }
                else
                {
                    if (DateTime.DaysInMonth(chonKyLuong1.DenNgay.Year, chonKyLuong1.DenNgay.Month) < ngay)
                    {
                        return;
                    }

                    DateTime a = new DateTime(chonKyLuong1.DenNgay.Year, chonKyLuong1.DenNgay.Month, ngay);

                    if (a.DayOfWeek == DayOfWeek.Sunday)
                    {
                        e.Appearance.BackColor = Color.Lavender;
                    }
                }
            }
        }

        private void toolStripPrint_Click(object sender, EventArgs e)
        {
            List<String> _lstr = new List<String>();

            foreach(DataRow _row in (grd.DataSource as DataTable).Rows)
            {
                _lstr.Add(_row["EmployeeID"].ToString());
            }

            Ham.report_ChamCongThang_ChiTiet(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay, _lstr);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            PhanTichBangCong frm = new PhanTichBangCong();

            frm.Show();
        }

        private void toolStripPhanTichCong_TamUng_Click(object sender, EventArgs e)
        {
            PhanTichBangCong_TamUng frm = new PhanTichBangCong_TamUng();

            frm.Show();
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

        private void ReportMonth_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmDangKyCaLam_Load(null, null);
            }
        } 
    }
}
