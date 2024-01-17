﻿using iHRM.Core.Business;
using iHRM.Win.Cls;
using iHRM.Win.Frm.mainForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Common
{
    public partial class frmLogin_0 : DevExpress.XtraEditors.XtraForm
    {
        iHRM.Core.Business.Logic.Common.login logic = new iHRM.Core.Business.Logic.Common.login();
        Cls.MoreFormByControl mf;

        public frmLogin_0()
        {
            InitializeComponent();
            mf = new MoreFormByControl(this, panel1, labelControl1);
        }

        private void login_Load(object sender, EventArgs e)
        {
            if (win_globall.agrs == "/admin" || string.IsNullOrWhiteSpace(Config.appConfig.strcnn))
            {
                btnCauHinh.Visible = true;
            }

            var dt = logic.GetAllConnection();
            cmbDB.Properties.Items.AddRange(dt.Select().Select(i => i["code"]).ToArray());

            if (!string.IsNullOrWhiteSpace(Config.appConfig.frmLogin_saveId))
            {
                chkRemember.Checked = true;
                txtID.Text = Config.appConfig.frmLogin_saveId;
                txtPW.Text = Cls.Tools.Decrypt(Config.appConfig.frmLogin_savePw, "frmLogin_savePw1");
                cmbDB.EditValue = Config.appConfig.frmLogin_saveDb;
                chkAutoLogin.Checked = Config.appConfig.frmLogin_autoLog;

                if (chkAutoLogin.Checked)
                {
                    timer1.Start();
                    return;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int _countDown2AutoLogin = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            _countDown2AutoLogin -= 1;
            chkAutoLogin.Text = "Tự động đăng nhập sau " + _countDown2AutoLogin + "s";
            if (_countDown2AutoLogin <= 0)
            {
                timer1.Stop();
                btnLogin_Click(null, null);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Stop();

            if (string.IsNullOrWhiteSpace(Provider.ConnectionString))
            {
                GUIHelper.MessageError("Chưa chọn cấu hình...");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbDB.Text))
            {
                GUIHelper.MessageBox("Please Choose DB");
                return;
            }

            progressPanel1.Visible = true;
            btnLogin.Enabled = false;
            if (!bgwLogin.IsBusy)
                bgwLogin.RunWorkerAsync();
        }

        private void Logged()
        {
            try
            {
                txtPW.Text = "";
                this.Hide();
                main.Load();
                if (main.Instance.ShowDialog() == DialogResult.OK)
                {
                    Provider.ConnectionString = frmConnect.buildcauhinh(Config.appConfig.strcnn);
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
                this.Close();
            }
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm.Common.frmConnect cauhinh = new Frm.Common.frmConnect();
            try
            {
                cauhinh.ShowDialog();
            }
            finally
            {
                this.Show();
            }
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
            chkAutoLogin.Enabled = chkRemember.Checked;
        }

        private void chkAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Stop();
        }

        private void bgwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            var dr = logic.GetAllConnection().Select("code='" + cmbDB.Text + "'").FirstOrDefault();
            if (dr == null)
            {
                bgwLogin.ReportProgress(1);
                return;
            }
            LoginHelper.Dept = dr;
            Provider.ConnectionString = dr["strcnn"].ToString();
            Provider.ConnectionString_MCC = dr["strMCC"].ToString();

            LoginHelper.loginin(txtID.Text, txtPW.Text);
        }

        private void bgwLogin_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                GUIHelper.MessageBox("Please Choose DB");
            }
        }

        private void bgwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (LoginHelper.isLogin)
            {
                CacheDataTable.ds = new DataSet();
                Config.appConfig.frmLogin_autoLog = chkAutoLogin.Checked;
                Config.appConfig.frmLogin_saveId = chkRemember.Checked ? txtID.Text : "";
                Config.appConfig.frmLogin_savePw = chkRemember.Checked ? Cls.Tools.Encrypt(txtPW.Text, "frmLogin_savePw1") : "";
                Config.appConfig.frmLogin_saveDb = chkRemember.Checked ? cmbDB.Text : "";
                Config.Save();
                Logged();
            }
            else
            {
                GUIHelper.MessageError("Đăng nhập không thành công!");
            }
            btnLogin.Enabled = true;
        }
    }
}