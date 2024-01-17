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
using iHRM.Core.Business.DbObject;
using System.Data.SqlClient;
using DevExpress.Data;
using iHRM.Core.Business;
using System.Reflection;

namespace iHRM.Win.Frm.i_Report
{
    public partial class frmChartEmployee_001 : frmBase
    {
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        iHRM.Core.Controller.Report.GetData _controller = new Core.Controller.Report.GetData();

        DataTable _dataGrv;

        DataTable _data1;

        DataTable _data2;

        DataTable _data3;

        public frmChartEmployee_001()
        {
            InitializeComponent();
        }

        private void frmChartEmployee_001_Load(object sender, EventArgs e)
        {            
            TranslateForm();

            cbbNam.Properties.DataSource = Provider.ExecuteDataTable("p_chart_GetYear");

            cbbNam.EditValue = DateTime.Now.Year;

            _dataGrv = new DataTable();

            _data1 = new DataTable();

            _data2 = new DataTable();

            _data3 = new DataTable();

            try
            {
                _dataGrv = Provider.ExecuteDataTable("p_chart_GetEmployeeDepYear", new SqlParameter("year", cbbNam.EditValue.ToString()));

                _data1 = Provider.ExecuteDataTable("p_chart_GetEmployeeAppliedYear", new SqlParameter("year", cbbNam.EditValue.ToString()));

                _data2 = Provider.ExecuteDataTable("p_chart_GetEmployeeLeftDateYear", new SqlParameter("year", cbbNam.EditValue.ToString()));

                _data3 = Provider.ExecuteDataTable("p_chart_GetEmployeePresentYear", new SqlParameter("year", cbbNam.EditValue.ToString()));

                chartEmployee.Series[0].ArgumentDataMember = "chartName";

                chartEmployee.Series[0].ValueDataMembers[0] = "chartTotal";

                chartEmployee.Series[1].ArgumentDataMember = "chartName";

                chartEmployee.Series[1].ValueDataMembers[0] = "chartTotal";

                chartEmployee.Series[2].ArgumentDataMember = "chartName";

                chartEmployee.Series[2].ValueDataMembers[0] = "chartTotal";

                treeGrd.DataSource = _dataGrv;

                chartEmployee.Series[0].DataSource = _data1;

                chartEmployee.Series[1].DataSource = _data2;

                chartEmployee.Series[2].DataSource = _data3;
            }
            catch(Exception)
            {

            }
            
        }

        private void cbbNam_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                _dataGrv = Provider.ExecuteDataTable("p_chart_GetEmployeeDepYear", new SqlParameter("year", cbbNam.EditValue.ToString()));

                _data1 = Provider.ExecuteDataTable("p_chart_GetEmployeeAppliedYear", new SqlParameter("year", cbbNam.EditValue.ToString()));

                _data2 = Provider.ExecuteDataTable("p_chart_GetEmployeeLeftDateYear", new SqlParameter("year", cbbNam.EditValue.ToString()));

                _data3 = Provider.ExecuteDataTable("p_chart_GetEmployeePresentYear", new SqlParameter("year", cbbNam.EditValue.ToString()));

                treeGrd.DataSource = _dataGrv;

                chartEmployee.Series[0].DataSource = _data1;

                chartEmployee.Series[1].DataSource = _data2;

                chartEmployee.Series[2].DataSource = _data3;
            }
            catch(Exception)
            {

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

        private void frmChartEmployee_001_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmChartEmployee_001_Load(null, null);
            }
        }
    }
}