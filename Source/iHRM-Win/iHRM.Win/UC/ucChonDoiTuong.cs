using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business;
using iHRM.Common.Code;

namespace iHRM.Win.UC
{
    public partial class ucChonDoiTuong : UserControl
    {
        public int SelectedIndex
        {
            get
            {
                if (checkEdit1.Checked)
                    return 1;
                if (checkEdit2.Checked)
                    return 2;
                if (checkEdit3.Checked)
                    return 3;
                return 0;
            }
            set
            {
                checkEdit1.Checked = (value == 1);
                checkEdit2.Checked = (value == 2);
                checkEdit3.Checked = (value == 3);
            }
        }

        public string SelectedText
        {
            get
            {
                if (checkEdit1.Checked)
                    return string.Format("Nhân viên [{0}] {1}", txtMaNV.Text, txtTenNV.Text);
                if (checkEdit2.Checked)
                    return string.Format("Phòng [{0}] {1}", chonPhongBan1.SelectedValue, chonPhongBan1.SelectedRow.DepName);
                if (checkEdit3.Checked)
                    return string.Format("Nhóm NV 1 [{0}]", textEdit2.SelectedText);
                return "";
            }
        }

        public string SelectedValue
        {
            get
            {
                if (checkEdit1.Checked)
                    return txtMaNV.Text;
                if (checkEdit2.Checked)
                    return chonPhongBan1.SelectedValue;
                if (checkEdit3.Checked)
                    return textEdit2.EditValue.ToString();
                return "";
            }
            set
            {
                if (checkEdit1.Checked)
                    txtMaNV.Text = value;
                else if (checkEdit2.Checked)
                    chonPhongBan1.SelectedValue = value;
                else if (checkEdit3.Checked)
                    textEdit2.EditValue = value;
            }
        }

        public ucChonDoiTuong()
        {
            InitializeComponent();
        }

        private void ucChonDoiTuong_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                checkEdit1.Checked = true;
                textEdit2.Properties.DataSource = Cls.CacheDataTable.GetCacheDataTable(TableConst.tblEmp_Group1.TableName);

                var dt = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));
                // Trong add phan quyen 18/08/2017
                txtTenNV.Properties.DataSource = dt;// Cls.CacheDataTable.GetCacheDataTable("tblEmployee");
                txtTenNV.Properties.DisplayMember = "EmployeeName";
                txtTenNV.Properties.ValueMember = "EmployeeCode";
            }
        }

        private void lookUpEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            txtTenNV.ShowPopup();
        }

        public void txtMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
                DataRow dr;
                if (LoginHelper.user.idKhoiPB == null || LoginHelper.user.isAdmin)
                {
                    dr = logic.checkNV(txtMaNV.Text);
                }
                else
                {
                    dr = logic.checkNV(txtMaNV.Text, LoginHelper.user.idKhoiPB.ToString());
                }
                if (dr == null)
                {
                    txtMaNV.Text = "";
                }
                else
                {
                    //txtMaNV.Text = DbHelper.DrGetString(dr, "EmployeeID");
                    //txtTenNV.Text = string.Format("{0} [{1}]", DbHelper.DrGet(dr, "EmployeeName"), DbHelper.DrGet(dr, "IDCard"));
                    txtMaNV.Text = DbHelper.DrGetString(dr, "EmployeeID");
                    string s = string.Format("{0}", DbHelper.DrGet(dr, "EmployeeID"));
                    txtTenNV.EditValue = s;

                    checkEdit1.Checked = true;
                }
            }
        }

        private void chonPhongBan1_OnSelected(object sender, EventArgs e)
        {
            checkEdit2.Checked = true;
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            checkEdit3.Checked = true;
        }

        private void txtTenNV_EditValueChanged(object sender, EventArgs e)
        {
            txtMaNV.Text = (string)txtTenNV.EditValue;
            checkEdit1.Checked = true;
        }
    }
}
