using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.AccessRight
{
    public partial class frmChangePassword : dlgBase
    {

        public frmChangePassword()
        {
            InitializeComponent();


            txtTen.Text = LoginHelper.user.loginID; //-> lấy từ đối tượng đang login

            txtTen.ReadOnly = true; //readonly

            buttonPanel1.OnSave += buttonPanel1_OnSave;

        }
        
        void buttonPanel1_OnSave(object sender, EventArgs e)
        {
            if(!myValidate())
            {
                LoginHelper.user.loginPW = txtMatKhauNew.Text; //xử lý từ đối tượng đang login
                LoginHelper.db.SubmitChanges();
                LogAction.LogAction.PushLog("Sửa dữ liệu", "", "", "Thay đổi mật khẩu", "w5sysUser");
                Cls.GUIHelper.Notifications_msg(Cls.GUIHelper.Notifications_msgType.EditSuccess);
                this.Close();
            }
        }
        public bool myValidate()
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) 
            {
                GUIHelper.MessageBox("Chưa nhập mật khẩu cũ?");
                txtPassword.Focus();
                return true;
            }
            if (txtPassword.Text != LoginHelper.user.loginPW) 
            {
                GUIHelper.MessageBox("Mật khẩu cũ không đúng!");
                txtPassword.Focus();
                return true;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhauNew.Text)) 
            {
                GUIHelper.MessageBox("Chưa nhập mật khẩu mới?");
                txtMatKhauNew.Focus();
                return true;
            }
            if(txtEnterPassword.Text != txtMatKhauNew.Text)
            {
                GUIHelper.MessageBox("Mật khẩu mới nhập lại không trùng?");
                txtEnterPassword.Focus();
                return true;
            }
            
            return false;
        }
    }
}
