using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
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
using iHRM.Win.Frm.LogAction;

namespace iHRM.Win.Frm.DataAPI
{
    public partial class frmDataAPI_VuiApp_NV : frmBase
    {
        dcDatabaseDataContext db;
        List<ActionClass> _lActionClass = new List<ActionClass>();

        public frmDataAPI_VuiApp_NV()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            TranslateForm();
            if (LoginHelper.user.idKhoiPB != null)
            {
                chonPhongBan1.SelectedValue = LoginHelper.user.idKhoiPB.ToString();
            }
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (chonPhongBan1.SelectedValue == null)
            {
                GUIHelper.MessageBox("Cần chọn phòng ban");

                return;
            }

            btnFind.Enabled = false;
             _lActionClass.Clear();

            db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            dw_it.Caption = "Đang tải dữ liệu...";

            dw_it.OnDoing = (s, ev) =>
            {
                var data = Provider.ExecuteDataTableReader("p_GetDataAPI_VuiApp_NV",
                                new SqlParameter("phongban_id", chonPhongBan1.SelectedValue));

                dw_it.bw.ReportProgress(1, data);

            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState;
                    btnFind.Enabled = true;
                }
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var newLst = new List<tblEmployee>();

            foreach (var it in getEmpID())
            {
                    newLst.Add(db.tblEmployees.Where(i => i.EmployeeID == it.ToString()).SingleOrDefault());
                    _lActionClass.Add(new ActionClass("Xóa dữ liệu", it.ToString(), "", "Xóa dữ liệu liên kết Vui App, nhân viên " + it.ToString(), "tblEmployee"));
            }

            if (getEmpID().Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            try
            {
                Provider.ExecNoneQuery("p_GetDataAPI_VuiApp_NV_Delete"

                                        , new System.Data.SqlClient.SqlParameter("phongban_id", chonPhongBan1.SelectedValue)

                                        , Provider.CreateParameter_StringList("ListNV", getEmpID()));

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                grv.DeleteSelectedRows();
                LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();
               
                
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dlgDataAPI_VuiApp_NV dlgEditor = new dlgDataAPI_VuiApp_NV();
            dlgEditor.ShowDialog();

            btnFind_Click(null, null);
        }


        private List<String> getEmpID()
        {
            List<String> _lEmpID = new List<String>();

            List<DataRow> _list_dr = grv.GetSelectedRows().Select(x => grv.GetDataRow(x) as DataRow).ToList();

            foreach (DataRow _dr in _list_dr)
            {
                _lEmpID.Add(_dr["EmployeeID"].ToString());
            }

            return _lEmpID;
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
        private void frmNhomHuongLuong_NV_KeyDown(object sender, KeyEventArgs e)
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
