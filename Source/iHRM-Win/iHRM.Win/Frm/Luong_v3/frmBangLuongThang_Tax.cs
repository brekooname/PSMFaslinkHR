using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class frmBangLuongThang_Tax : frmBase
    {
        dcLuongv3DataContext db1 = new dcLuongv3DataContext(Provider.ConnectionString);
        DataTable LstData;
        List<DevExpress.XtraGrid.Columns.GridColumn> LstCol;

        dlgDinhNghiaThamSo_Tax dlgEditor = new dlgDinhNghiaThamSo_Tax();

        public frmBangLuongThang_Tax()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            txtSearchThang.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            LoadGrvLayout(bandedGridView1);
            TranslateForm();
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (chonPhongBan1.SelectedValue == null)
            {
                GUIHelper.MessageBox("Cần chọn phòng ban");
                return;
            }

            btnFind.Enabled = false;
            var db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) => 
            {
                var lst1 = db.tbLuong_DinhNghiaThamSo_Taxes.Where(i => i.hienTrenBangLuong == true).OrderBy(p=>p.ten).ToList();
                dw_it.bw.ReportProgress(1, lst1);
                
                LstData = Provider.ExecuteDataTableReader("p_BangLuong_GetAll_Tax", 
                    new SqlParameter("thang", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue),
                    new SqlParameter("tukhoa", txtTuKhoaSearch.Text.Trim())
                );
                dw_it.bw.ReportProgress(2, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    var lst1 = data.UserState as List<tbLuong_DinhNghiaThamSo_Tax>;
                    var lst2 = lst1.Select(i => i.nhom).Distinct().OrderBy(i => i).ToList();
                    if (LstCol == null)
                    {
                        LstCol = new List<DevExpress.XtraGrid.Columns.GridColumn>();
                    }
                    else
                    {
                        LstCol.ForEach(i => bandedGridView1.Columns.Remove(i));
                        LstCol.Clear();
                        for (int i = bandedGridView1.Bands.Count - 1; i >= 0; i--)
                        {
                            if (bandedGridView1.Bands[i] != gridBand1 && bandedGridView1.Bands[i] != gridBand2)
                                bandedGridView1.Bands.RemoveAt(i);
                        }
                    }

                    foreach (var g in lst2)
                    {
                        var b1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                        b1.Caption = g;

                        foreach (var it in lst1.Where(j => j.nhom == g).OrderBy(i => i.stt))
                        {
                            var gc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                            gc.Caption = it.ten;
                            switch (it.kieuDuLieu)
                            {
                                case 1: //số
                                    gc.ColumnEdit = this.repositoryItemCalcEdit1;
                                    gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                    gc.DisplayFormat.FormatString = "#,#.##";

                                    gc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                                    gc.SummaryItem.DisplayFormat = "{0:#,#.##}";
                                    break;
                                case 2: //chữ
                                    break;
                                case 3: //ngày
                                    gc.ColumnEdit = this.repositoryItemDateEdit1;
                                    gc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                                    gc.DisplayFormat.FormatString = "dd/MM/yyyy";
                                    break;
                                case 4: //true/flase
                                    gc.ColumnEdit = this.repositoryItemCheckEdit1;
                                    break;
                            }
                            gc.FieldName = it.tsIdx;
                            gc.Name = "_gridColumn" + it.id;
                            gc.Visible = true;
                            gc.OptionsColumn.AllowEdit = false;
                            gc.OptionsColumn.ReadOnly = true;

                            LstCol.Add(gc);
                            bandedGridView1.Columns.Add(gc);
                            b1.Columns.Add(gc);
                        }

                        bandedGridView1.Bands.Add(b1);
                    }
                }
                else if (data.ProgressPercentage == 2)
                {
                    grd.DataSource = LstData;
                    btnFind.Enabled = true;
                }
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(bandedGridView1);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsLock.IsLock.Check_IsLock("tbLuong_BangLuongThang_Tax", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)))
                {
                    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                    return;
                }

                if (LstData.GetChanges(DataRowState.Modified) == null || LstData.GetChanges(DataRowState.Modified).Rows.Count <= 0)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                    return;
                }

                foreach(DataRow r in LstData.GetChanges(DataRowState.Modified).Rows)
                {
                    var log = Log2.CreateLog(Log2.Log2Action.sua, "Sửa bảng thuế " + DbHelper.DrGet(r, "id"), "tbLuong_BangLuongThang_Tax");
                    Log2.AddLogDetail(log, new string[] {"id",
                        "idNV",
                        "thang",
                        "tongLuong",
                        "ts199",
                        "ts198",
                        "ts197",
                        "ts196",
                        "ts195",
                        "ts194",
                        "ts193",
                        "ts192",
                        "ts191",
                        "ts190",
                        "ts189",
                        "ts188",
                        "ts187",
                        "ts186",
                        "ts185",
                        "ts184",
                        "ts183",
                        "ts182",
                        "ts181",
                        "ts180",
                        "ts179",
                        "ts178",
                        "ts177",
                        "ts176",
                        "ts175",
                        "ts174",
                        "ts173",
                        "ts172",
                        "ts171",
                        "ts170",
                        "ts169",
                        "ts168",
                        "ts167",
                        "ts166",
                        "ts165",
                        "ts164",
                        "ts163",
                        "ts162",
                        "ts161",
                        "ts160",
                        "ts159",
                        "ts158",
                        "ts157",
                        "ts156",
                        "ts155",
                        "ts154",
                        "ts153",
                        "ts152",
                        "ts151",
                        "ts150",
                        "ts149",
                        "ts148",
                        "ts147",
                        "ts146",
                        "ts145",
                        "ts144",
                        "ts143",
                        "ts142",
                        "ts141",
                        "ts140",
                        "ts139",
                        "ts138",
                        "ts137",
                        "ts136",
                        "ts135",
                        "ts134",
                        "ts133",
                        "ts132",
                        "ts131",
                        "ts130",
                        "ts129",
                        "ts128",
                        "ts127",
                        "ts126",
                        "ts125",
                        "ts124",
                        "ts123",
                        "ts122",
                        "ts121",
                        "ts120",
                        "ts119",
                        "ts118",
                        "ts117",
                        "ts116",
                        "ts115",
                        "ts114",
                        "ts113",
                        "ts112",
                        "ts111",
                        "ts110",
                        "ts109",
                        "ts108",
                        "ts107",
                        "ts106",
                        "ts105",
                        "ts104",
                        "ts103",
                        "ts102",
                        "ts101",
                        "ts100",
                        "ts99",
                        "ts98",
                        "ts97",
                        "ts96",
                        "ts95",
                        "ts94",
                        "ts93",
                        "ts92",
                        "ts91",
                        "ts90",
                        "ts89",
                        "ts88",
                        "ts87",
                        "ts86",
                        "ts85",
                        "ts84",
                        "ts83",
                        "ts82",
                        "ts81",
                        "ts80",
                        "ts79",
                        "ts78",
                        "ts77",
                        "ts76",
                        "ts75",
                        "ts74",
                        "ts73",
                        "ts72",
                        "ts71",
                        "ts70",
                        "ts69",
                        "ts68",
                        "ts67",
                        "ts66",
                        "ts65",
                        "ts64",
                        "ts63",
                        "ts62",
                        "ts61",
                        "ts60",
                        "ts59",
                        "ts58",
                        "ts57",
                        "ts56",
                        "ts55",
                        "ts54",
                        "ts53",
                        "ts52",
                        "ts51",
                        "ts50",
                        "ts49",
                        "ts48",
                        "ts47",
                        "ts46",
                        "ts45",
                        "ts44",
                        "ts43",
                        "ts42",
                        "ts41",
                        "ts40",
                        "ts39",
                        "ts38",
                        "ts37",
                        "ts36",
                        "ts35",
                        "ts34",
                        "ts33",
                        "ts32",
                        "ts31",
                        "ts30",
                        "ts29",
                        "ts28",
                        "ts27",
                        "ts26",
                        "ts25",
                        "ts24",
                        "ts23",
                        "ts22",
                        "ts21",
                        "ts20",
                        "ts19",
                        "ts18",
                        "ts17",
                        "ts16",
                        "ts15",
                        "ts14",
                        "ts13",
                        "ts12",
                        "ts11",
                        "ts10",
                        "ts9",
                        "ts8",
                        "ts7",
                        "ts6",
                        "ts5",
                        "ts4",
                        "ts3",
                        "ts2",
                        "ts1",
                        "ghichu",
                        "tss49",
                        "tss48",
                        "tss47",
                        "tss46",
                        "tss45",
                        "tss44",
                        "tss43",
                        "tss42",
                        "tss41",
                        "tss40",
                        "tss39",
                        "tss38",
                        "tss37",
                        "tss36",
                        "tss35",
                        "tss34",
                        "tss33",
                        "tss32",
                        "tss31",
                        "tss30",
                        "tss29",
                        "tss28",
                        "tss27",
                        "tss26",
                        "tss25",
                        "tss24",
                        "tss23",
                        "tss22",
                        "tss21",
                        "tss20",
                        "tss19",
                        "tss18",
                        "tss17",
                        "tss16",
                        "tss15",
                        "tss14",
                        "tss13",
                        "tss12",
                        "tss11",
                        "tss10",
                        "tss1",
                        "tss9",
                        "tss8",
                        "tss7",
                        "tss6",
                        "tss5",
                        "tss4",
                        "tss3",
                        "tss2"
                    }, r);
                    Log2.PushLog(log);
                }

                Provider.UpdateData(LstData, "tbLuong_BangLuongThang_Tax");
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bandedGridView1.OptionsPrint.UsePrintStyles = false;
            ShowPreview(grd);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            txtSearchThang.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            chonPhongBan1.SelectedValue = null;
            txtTuKhoaSearch.EditValue = null;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dlgChuyenBangThue_Luong dlg = new dlgChuyenBangThue_Luong();
            dlg.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dlgChuyenBangThue_LuongBaoCao dlg = new dlgChuyenBangThue_LuongBaoCao();
            dlg.ShowDialog();
        }

        private void bandedGridView1_KeyDown(object sender, KeyEventArgs e)
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

        private void frmBangLuongThang_Tax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frm_Load(null, null);
            }
        }
    }
}
