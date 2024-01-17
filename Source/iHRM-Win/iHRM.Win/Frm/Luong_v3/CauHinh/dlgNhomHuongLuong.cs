using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class dlgNhomHuongLuong : dlgCustomBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);

        private tbDM_nhomNV myValue;
        public tbDM_nhomNV MyValue
        {
            get { return myValue; }
            set
            {
                myValue = value;
                txtMa.Text = myValue.ma;
                txtTen.Text = myValue.ten;
            }
        }

        public string AttackMode { get; set; }

        public dlgNhomHuongLuong()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool ok = true;
                if (string.IsNullOrWhiteSpace(txtMa.Text))
                {
                    errorProvider1.SetError(txtMa, "Bạn chưa nhập mã...");
                    ok = false;
                }
                if (string.IsNullOrWhiteSpace(txtTen.Text))
                { 
                    errorProvider1.SetError(txtTen, "Bạn chưa nhập ten...");
                    ok = false;
                }

                if (!ok)
                    return;
                
                try
                {
                    myValue.ma = txtMa.Text;
                    myValue.ten = txtTen.Text;

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                    return;
                }
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
            
        }

        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void dlgNhomHuongLuong_Load(object sender, EventArgs e)
        {
            this.Form_Title = SelectTranslate("dlgNhomHuongLuong_Title", LoginHelper.langTrans);
            this.Form_Description = SelectTranslate("dlgNhomHuongLuong_Des", LoginHelper.langTrans);
            lblMa.Text = SelectTranslate("lblMa", LoginHelper.langTrans);
            lblNhomHuongLuong.Text = SelectTranslate("lblNhomHuongLuong", LoginHelper.langTrans);
            btnSave.Text = SelectTranslate("btnSave", LoginHelper.langTrans); 
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
    }
}
