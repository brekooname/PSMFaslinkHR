using iHRM.Core.i_Report;
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
using iHRM.Common.Code;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.AccessRight;

namespace iHRM.Win.Frm.AccessRight
{
    public partial class frmUsers : frmBase
    {
        Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
        
        Core.Business.Logic.AccessRight.User logic = new User();

        DataTable DataRoles;

        DataRow CRowRoles;

        public frmUsers()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            buttonPanel1.setFunctionEnable((int)iRule.rules);

            buttonPanel1.setFunctionVisible((int)iRule.rules);

            LoadGrvLayout(grv);

            repDep.DataSource = db.tblRef_Departments;

            buttonPanel1_OnFind(null, null);
        }

        private void buttonPanel1_OnFind(object sender, EventArgs e)
        {
            DataRoles = logic.GetAll(null, LoginHelper.user.isAdmin);

            grd.DataSource = DataRoles;
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CRowRoles = grv.GetFocusedDataRow();

            if (CRowRoles == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }
        }

        dlgUsers _dlgEditor = null;
        dlgUsers dlgEditor
        {
            get
            {
                if (_dlgEditor == null)
                {
                    _dlgEditor = new dlgUsers();

                    dlgEditor.Owner = this;

                    dlgEditor.OnSave += dlgEditor_OnSave;
                }
                return _dlgEditor;
            }
            set
            {
                _dlgEditor = value;
            }
        }

        private void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                var db = new dcDatabaseDataContext(Provider.ConnectionString);

                if (dlgEditor.CustomFormAction == 0)
                {
                    w5sysUser r = new w5sysUser();

                    SetDataContextFromDataRow(r, dlgEditor.MyValue);

                    r.status = 1;

                    db.w5sysUsers.InsertOnSubmit(r);

                    db.SubmitChanges();

                    LogAction.LogAction.PushLog("Thêm dữ liệu", "", "", string.Format("Thêm mới người dùng id={0}, caption={1}", r.id, r.caption), "w5sysUser");
                    
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    
                    DataRoles.Rows.Add(dlgEditor.MyValue);
                }
                else
                {
                    var r = db.w5sysUsers.SingleOrDefault(i => i.id == (long)dlgEditor.myID);
                    
                    if (r == null)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        
                        return;
                    }

                    SetDataContextFromDataRow(r, dlgEditor.MyValue);
                    
                    db.SubmitChanges();
                    
                    LogAction.LogAction.PushLog("Sửa dữ liệu", "", "", string.Format("Cập nhật người dùng id={0}, caption={1}", r.id, r.caption), "w5sysUser");
                    
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void buttonPanel1_OnNew(object sender, EventArgs e)
        {
            dlgEditor.MyValue = DataRoles.NewRow();

            dlgEditor.CustomFormAction = 0;

            dlgEditor.Show();
        }

        private void buttonPanel1_OnEdit(object sender, EventArgs e)
        {
            dlgEditor.MyValue = CRowRoles;

            dlgEditor.CustomFormAction = 1;

            dlgEditor.Show();
        }

        private void buttonPanel1_OnDelete(object sender, EventArgs e)
        {
            if (!LoginHelper.user.isAdmin)
            {
                return;
            }
            if (CRowRoles == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }
            try
            {
                using (var ts = new System.Transactions.TransactionScope())
                {
                    w5sysUser r1 = db.w5sysUsers.SingleOrDefault(i => i.id == (long)CRowRoles["id"]);

                    if (r1 == null)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                        return;
                    }

                    //db.w5sysRules.DeleteAllOnSubmit(r1.w5sysRules);
                    //db.SubmitChanges();

                    db.w5sysUsers.DeleteOnSubmit(r1);

                    db.SubmitChanges();

                    ts.Complete();

                    DataRoles.Rows.Remove(CRowRoles);

                    grv_FocusedRowChanged(null, null);

                    LogAction.LogAction.PushLog("Xóa dữ liệu", "", "", string.Format("Xóa người dùng id={0}, caption={1}", r1.id, r1.caption), "w5sysUser");
                }

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);

                return;
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, "Xóa người dùng không thành công");

                return;
            }
        }

        private void grv_DoubleClick(object sender, EventArgs e)
        {
            CRowRoles = grv.GetFocusedDataRow();

            dlgEditor.MyValue = CRowRoles;

            dlgEditor.CustomFormAction = 1;

            dlgEditor.Show();
        }
    }
}
