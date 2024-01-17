using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
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

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class frmNhomHuongLuong_NV : frmBase
    {
        dcLuongv3DataContext db;
        List<tblEmployee> LstData;

        dlgNhomHuongLuong_NV dlgEditor = new dlgNhomHuongLuong_NV();

        dlgChuyenNhomHL_NV dlg;

        private String _txtModule = "";

        public frmNhomHuongLuong_NV()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);

            //txtModule.Properties.DataSource = CacheDataTable.GetCacheDataTable("tbDM_nhomNV");

            DataTable dt = Provider.ExecuteDataTable("p_tbDM_nhomNV_idDM_nhomNV_idUser", new System.Data.SqlClient.SqlParameter("idUser", LoginHelper.user.id));
            txtModule.Properties.DataSource = dt;

            TranslateForm();
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtModule.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn nhóm");
                return;
            }

            btnFind.Enabled = false;

            db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            dw_it.Caption = "Đang tải dữ liệu...";

            dw_it.OnDoing = (s, ev) =>
            {
                var data = Provider.ExecuteDataTableReader("p_tbDM_nhomNV_idDM_nhomNV",
                                new SqlParameter("id", txtModule.EditValue as int?));

                LstData = db.tbNhanVien_NhomNVs.Where(i => i.nhomnv_id == txtModule.EditValue as int?).Select(i => i.tblEmployee).ToList();

                _txtModule = txtModule.EditValue.ToString();

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
            if (txtModule.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn nhóm");
                return;
            }
            var newLst = new List<tblEmployee>();

            foreach (var it in getEmpID())
            {
                if (LstData.Where(i => i.EmployeeID == it.ToString()).Count() >= 0)

                    newLst.Add(LstData.Where(i => i.EmployeeID == it.ToString()).SingleOrDefault());
            }

            if (getEmpID().Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            try
            {
                Provider.ExecNoneQuery("p_tbDM_nhomNV_idDM_nhomNV_Delete"

                                        , new System.Data.SqlClient.SqlParameter("id", (int?)txtModule.EditValue)

                                        , Provider.CreateParameter_StringList("ListNV", getEmpID()));

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                grv.DeleteSelectedRows();

                var log = Log2.CreateLog(Log2.Log2Action.xoa, "Xóa " + newLst.Count() + " bản ghi", "tbNhanVien_NhomNV");
                log.tbLog2_details.AddRange(newLst.Select(i => new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "id",
                    target2 = "ten",
                    value1 = i.EmployeeID.ToString(),
                    value2 = i.EmployeeName
                }).ToArray());
                Log2.PushLog(log);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtModule.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn nhóm");
                return;
            }
            
            if (dlgEditor.ShowDialog() == DialogResult.OK)
            {
                if (dlgEditor.MyValue.Count() == 0)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                    return;
                }

                try
                {
                    var newLst = new List<tblEmployee>();
                    foreach(var it in dlgEditor.MyValue)
                    {
                        if (LstData.Count(i => i.EmployeeID == it.EmployeeID) == 0)
                            newLst.Add(it);
                    }

                    Provider.ExecuteNonQuery_SQL("INSERT tbNhanVien_NhomNV (id,employee_id,nhomnv_id) VALUES " + 
                        string.Join(",", newLst.Select(i => string.Format("(newid(),'{0}',{1})", i.EmployeeID, txtModule.EditValue as int?)))
                    );
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                    btnFind_Click(null, null);

                    var log = Log2.CreateLog(Log2.Log2Action.them, "Thêm " + newLst.Count() + " bản ghi", "tbNhanVien_NhomNV");
                    log.tbLog2_details.AddRange(newLst.Select(i => new Core.Business.DbObject.tbLog2_detail()
                    {
                        id = Guid.NewGuid(),
                        log_id = log.id,
                        target1 = "id",
                        target2 = "ten",
                        value1 = i.EmployeeID.ToString(),
                        value2 = i.EmployeeName
                    }).ToArray());
                    Log2.PushLog(log);
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (getEmpID().Count() == 0 || _txtModule == "")
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            dlg = new dlgChuyenNhomHL_NV();

            dlg._listEmp = getEmpID();

            dlg._idNhom = _txtModule;

            dlg.ShowDialog();

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
