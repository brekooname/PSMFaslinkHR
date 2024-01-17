using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Core.Business;
using iHRM.Core.i_Report;
using iHRM.Win.Cls;
using iHRM.Core.i_Report;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business.DbObject;
using System.Data.SqlClient;
using DevExpress.Data;

namespace iHRM.Win.Frm.i_Report
{
    public partial class iReports : frmBase
    {
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        iHRM.Core.Controller.Report.GetData _controller = new Core.Controller.Report.GetData();

        private iReport _iReports = new iReport();

        private String _StoredName = "";

        private int _checkLoad = 0;

        public String StoredName 
        { 
            get { return _StoredName.ToString(); } 
            set { _StoredName = value.ToString(); } 
        }

        private void SetReport()
        {
            _iReports.StoredName = _StoredName;

            _iReports.ToDate = chonKyLuong1.TuNgay;

            _iReports.FromDate = chonKyLuong1.DenNgay;

            _iReports.ListEmp = ucChonDoiTuong_DS1.GetValue();
        }

        public iReports()
        {
            InitializeComponent();
        }

        private void iReports_Load(object sender, EventArgs e)
        {
            TranslateForm();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (_checkLoad == 0)
            {
                SetReport();

                try
                {
                    _iReports.Data = Provider.ExecuteDataTable(_iReports.StoredName,
                                                                    new SqlParameter("tuNgay", _iReports.ToDate),
                                                                    new SqlParameter("denNgay", _iReports.FromDate),
                                                                    Provider.CreateParameter_StringList("dtEmployeeID", _iReports.ListEmp)
                                                                );
                    if (_iReports.Data.Columns.Count != 0)
                    {
                        foreach (var _col in _iReports.Data.Columns)
                        {
                            var _gc = new GridColumn();

                            _gc.Name = "col" + _col.ToString();

                            _gc.FieldName = _col.ToString();

                            _gc.Visible = true;

                            _gc.OptionsColumn.AllowEdit = false;

                            _gc.OptionsColumn.ReadOnly = true;

                            _gc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;

                            _gc.Caption = _col.ToString();

                            grv.Columns.Add(_gc);
                        }

                        grv.Columns[0].SummaryItem.DisplayFormat = "Tổng = {0:#,#}";
                        grv.Columns[0].SummaryItem.FieldName = grv.Columns[0].FieldName.ToString();
                        grv.Columns[0].SummaryItem.SummaryType = SummaryItemType.Count;
                    }

                    grd.DataSource = _iReports.Data;
                }
                catch (Exception)
                {

                }
                finally
                {
                    TranslateForm();

                    _checkLoad = 1;

                    grv.BestFitColumns();
                }
            }
            else
            {
                SetReport();

                try
                {
                    _iReports.Data = Provider.ExecuteDataTable(_iReports.StoredName,
                                                                    new SqlParameter("tuNgay", _iReports.ToDate),
                                                                    new SqlParameter("denNgay", _iReports.FromDate),
                                                                    Provider.CreateParameter_StringList("dtEmployeeID", _iReports.ListEmp)
                                                                );
                    grd.DataSource = _iReports.Data;
                }
                catch (Exception)
                {

                }
                finally
                {
                    _checkLoad = 1;
                }
            }
        }
        private void btnInTheoLuoi_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
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
            //var _GridColumn = EnumerateGridColumn();
            var _ToolStripButton = EnumerateToolStripButton();
            var _LableControl = EnumerateLabelControl();
            var _SimpleButton = EnumerateSimpleButton();
            var _CheckEdit = EnumerateCheckEdit();
            var _GridBand = EnumerateGridBand();
            #endregion

            #region Dịch form
            foreach (DevExpress.XtraGrid.Columns.GridColumn s in grv.Columns)
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

        private void iReports_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch     
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                iReports_Load(null, null);
            }
        }

        #endregion
    }
}