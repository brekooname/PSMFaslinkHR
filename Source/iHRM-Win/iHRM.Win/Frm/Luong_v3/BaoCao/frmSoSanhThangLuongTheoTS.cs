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

namespace iHRM.Win.Frm.Luong_v3.BaoCao
{
    public partial class frmSoSanhThangLuongTheoTS : frmBase
    {
        dcLuongv3DataContext db1 = new dcLuongv3DataContext(Provider.ConnectionString);
        DataTable LstData;
        List<DevExpress.XtraGrid.Columns.GridColumn> LstCol;

        dlgDinhNghiaThamSo dlgEditor = new dlgDinhNghiaThamSo();

        public frmSoSanhThangLuongTheoTS()
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
            btnFind.Enabled = false;
            var db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) => 
            {
                dw_it.bw.ReportProgress(1);

                DateTime _thang = new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1);
                LstData = Provider.ExecuteDataTableReader("p_BangLuong_GetAll", 
                    new SqlParameter("thang", _thang),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue),
                    new SqlParameter("tukhoa", txtTuKhoaSearch.Text.Trim())
                );
                LstData.Columns.Add("_thang", typeof(DateTime));
                foreach (DataRow r in LstData.Rows)
                    r["_thang"] = _thang;

                _thang = new DateTime(txtThang2.DateTime.Year, txtThang2.DateTime.Month, 1);
                var dt = Provider.ExecuteDataTableReader("p_BangLuong_GetAll",
                    new SqlParameter("thang", _thang),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue),
                    new SqlParameter("tukhoa", txtTuKhoaSearch.Text.Trim())
                );
                dt.Columns.Add("_thang", typeof(DateTime));
                foreach (DataRow r in dt.Rows)
                {
                    r["_thang"] = _thang;
                    LstData.ImportRow(r);
                }

                dw_it.bw.ReportProgress(2, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    var lst1 = dlgChonTS.LstData.Where(i => i.hienTrenBangLuong ?? false);
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
                            if (bandedGridView1.Bands[i] != colThongTin)
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
        
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            txtSearchThang.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            chonPhongBan1.SelectedValue = null;
            txtTuKhoaSearch.EditValue = null;
        }
        
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            bandedGridView1.OptionsPrint.UsePrintStyles = false;
            ShowPreview(grd);
        }

        dlgChonThamSo dlgChonTS = new dlgChonThamSo();
        private void textEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            dlgChonTS.ShowDialog();
            textEdit1.Text = dlgChonTS.LstData.Count(i => i.hienTrenBangLuong ?? false) + " TS được chọn";
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

        private void frmSoSanhThangLuongTheoTS_KeyDown(object sender, KeyEventArgs e)
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
