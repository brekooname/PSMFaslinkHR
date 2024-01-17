using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Core.Business.Logic.Luong;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Frm.Employee;
using iHRM.Win.ExtClass.Contract;
using DevExpress.XtraEditors.Controls;
using System.IO;
using System.Data.SqlClient;
using iHRM.Win.Cls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace iHRM.Win.Frm.Employee
{
    public partial class frmInPhuLuc_Fake : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        DataTable Data = new DataTable();
        public frmInPhuLuc_Fake()
        {
            InitializeComponent();
        }
        private void frmInPhuLuc_Load(object sender, EventArgs e)
        {
            TranslateForm();
            loadRadioHD();
            rdGroupInHD.SelectedIndex = 0;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //LoadGrvLayout(grvEmployee);
            List<Employee> _lObject = new List<Employee>();

            var Data = Provider.ExecuteDataTableReader("p_getEmployeeHopDongLaoDong",
                     Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue()),
                     new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                     new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                     new SqlParameter("ContractTypeID", rdGroupInHD.EditValue)
                     );
            foreach (DataRow row in Data.Rows)
            {
                Employee newEmp = new Employee();
                newEmp.chkEmp = false;
                newEmp.EmployeeID = row["EmployeeID"].ToString();
                newEmp.EmployeeName = row["EmployeeName"].ToString();
                newEmp.IDCard = row["IDCard"].ToString();
                newEmp.DepName = row["DepName_Final"].ToString();
                newEmp.AppliedDate = row["AppliedDate"] as DateTime?;
                newEmp.Birthday = row["Birthday"] as DateTime?;
                _lObject.Add(newEmp);
            }
            grcEmployee.DataSource = _lObject;
        }
        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            // In thẻ : "the". In hồ sơ "hoso"
            List<string> _lEmpID = new List<string>();

            int _CountDep = 0;

            int _CountDefault = 0;
            String _FileDefult = "";

            rep_PhuLuc _rpDefault;

            rep_PhuLuc _rpNV;

            _lEmpID = getEmpID();
            if (_lEmpID.Count == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            if (rdGroupInHD.EditValue == null)
            {
                GUIHelper.Notifications("Bạn chưa chọn loại hợp đồng để in.", "In phụ lục", GUIHelper.NotifiType.info);
                return;
            }

            var dt = Provider.ExecuteDataTableReader("p_getHopDongLaoDong_PhuLuc",
                     Provider.CreateParameter_StringList("dtEmpID", _lEmpID),
                     new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                     new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                     new SqlParameter("ContractTypeID", rdGroupInHD.EditValue)
                     );
            if (dt.Rows.Count == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }

            _FileDefult = Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee_Fake\DH_PHULUCHDLD.docx");
            _rpDefault = new rep_PhuLuc(_FileDefult);
            _rpDefault.bindData(dt);
            ReportViewer rv = new ReportViewer();
            rv.ViewReport(_rpDefault);

        }
        private List<string> getEmpID()
        {
            List<string> _lEmpID = new List<string>();
            for (int i = 0; i < grvEmployee.RowCount; i++)
            {
                if (grvEmployee.GetRowCellValue(i, colCheck).ToString() == "True")
                {
                    _lEmpID.Add(grvEmployee.GetRowCellValue(i, colEmpID).ToString());
                }
            }
            return _lEmpID;
        }
        public void loadRadioHD()
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            rdGroupInHD.Properties.Items.AddRange(db.tblRef_ContractTypes
                                                    .Select(p => new RadioGroupItem
                                                    {
                                                        Value = p.ContractTypeID,
                                                        Description = p.ContractTypeName
                                                    }).ToArray());

        }
        private class Employee
        {
            public bool chkEmp { get; set; }
            public string EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public string IDCard { get; set; }
            public string DepName { get; set; }
            public DateTime? AppliedDate { get; set; }
            public DateTime? Birthday { get; set; }
        }

        private void grvEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcEmployee.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void frmInPhuLuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmInPhuLuc_Load(null, null);
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

        private IEnumerable<Label> EnumerateLabelControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(Label).IsAssignableFrom(field.FieldType)
                   let component = (Label)field.GetValue(this)
                   where component != null
                   select component;
        }

        private IEnumerable<DevExpress.XtraEditors.GroupControl> EnumerateGroupControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.GroupControl).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.GroupControl)field.GetValue(this)
                   where component != null
                   select component;
        }

        private IEnumerable<DevExpress.XtraTab.XtraTabPage> EnumerateXtraTabPage()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraTab.XtraTabPage).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraTab.XtraTabPage)field.GetValue(this)
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
            var _GroupControl = EnumerateGroupControl();
            var _XtraTabPage = EnumerateXtraTabPage();
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
            foreach (Label s in _LableControl)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.GroupControl s in _GroupControl)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraTab.XtraTabPage s in _XtraTabPage)
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
            // dịch radiogrop duyệt 
            //rdAccept.Properties.Items[0].Description = SelectTranslate("rdAcceptTatca", langTrans);
            //rdAccept.Properties.Items[1].Description = SelectTranslate("rdAcceptDaDuyet", langTrans);
            //rdAccept.Properties.Items[2].Description = SelectTranslate("rdAcceptKhongDuyet", langTrans);

            #endregion
        }

        #endregion
    }
}