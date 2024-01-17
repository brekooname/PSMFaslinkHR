using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass;
using iHRM.Win.Frm.mainForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Common
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        iHRM.Core.Business.Logic.Common.login logic = new iHRM.Core.Business.Logic.Common.login();
        string _appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public bool isNeedUpdate = false;
        public bool checkupdate_isFinal = false;
        Cls.MoreFormByControl mf;

        public frmLogin()
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
            else
            {
                bgCheckUpdate.RunWorkerAsync();
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
                cboNgonNgu.SelectedIndex = Config.appConfig.language.Trim().ToUpper() == "ENGLISH" ? 1 : 0;
                if (cboNgonNgu.SelectedIndex != -1)
                {

                    if (cboNgonNgu.SelectedIndex == 1)
                        lang = "EN";
                    else
                        if (cboNgonNgu.SelectedIndex == 3)
                            lang = "KR";
                        else
                            lang = "VN";
                }
                if (chkAutoLogin.Checked)
                {
                    if (checkupdate_isFinal)
                    {
                        timer1.Start();
                        return;
                    }
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
            chkAutoLogin.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginautolate")).Tables[0].Rows[0][lang].ToString() + _countDown2AutoLogin + "s";
            if (_countDown2AutoLogin <= 0)
            {
                timer1.Stop();
                btnLogin_Click(null, null);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            langTrans = Config.appConfig.language.Trim().ToUpper();
            if (timer1.Enabled)
                timer1.Stop();

            if (Equals(btnLogin.Tag, "1"))
            {
                Process.Start(Path.Combine(win_globall.apppath, "Updater_Admin.exe"));
                Application.Exit();
                return;
            }

            if (string.IsNullOrWhiteSpace(Provider.ConnectionString))
            {
                GUIHelper.MessageError(Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginselectsetting")).Tables[0].Rows[0][lang].ToString());
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
        public static string langTrans = "";
        private void Logged()
        {
            try
            {
                txtPW.Text = "";
                this.Hide();
                main.Load(Config.appConfig.language);
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
            Provider.ConnectionString_PushServer = dr["strPushServer"].ToString();
            Provider.ConnectionString_Files = dr["strFile"].ToString();

            LoginHelper.Database = dr["code"].ToString();

            try
            {
                pw.vnn.lic.versionsv vs = new pw.vnn.lic.versionsv();
                var v = vs.GetAppLastVersion(win_globall.updater_appcode);
                win_globall.updater_ver = v.vName;
            }
            catch { }

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
                Config.appConfig.language = cboNgonNgu.Text;
                Config.Save();
                Logged();
            }
            else
            {
                GUIHelper.MessageError(Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginfailed")).Tables[0].Rows[0][lang].ToString());
            }

            btnLogin.Enabled = true;
            progressPanel1.Visible = false;
        }

        private void bgCheckUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(Path.Combine(win_globall.apppath, "Updater.exe"), "checkupdate");
                p.Start();
                p.WaitForExit();

                e.Result = p.ExitCode;
            }
            catch
            {
                e.Result = -1;
            }
        }
        private void bgCheckUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void bgCheckUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int updateCode = (int)e.Result;

            if (updateCode == 1)
            {
                labelControl10.Appearance.Image = Properties.Resources.ico20_new;
                labelControl10.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginupdateinfo")).Tables[0].Rows[0][lang].ToString();
                labelControl10.ForeColor = Color.Red;
                btnLogin.Image = Properties.Resources.ico20_arrow_down;
                btnLogin.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginupdate")).Tables[0].Rows[0][lang].ToString();
                btnLogin.Tag = "1";

                checkupdate_isFinal = true;

                if (chkAutoLogin.Checked)
                {
                    if (checkupdate_isFinal)
                    {
                        timer1.Start();
                        return;
                    }

                }
            }
            else
            {
                labelControl10.Visible = false;

                checkupdate_isFinal = true;

                if (chkAutoLogin.Checked)
                {
                    if (checkupdate_isFinal)
                    {
                        timer1.Start();
                        return;
                    }

                }
            }
        }
        public static string lang = "VN";
        private void cboNgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dịch form login

            if (cboNgonNgu.SelectedIndex != -1)
            {

                if (cboNgonNgu.SelectedIndex == 1)
                    lang = "EN";
                else
                    if (cboNgonNgu.SelectedIndex == 3)
                        lang = "KR";
                    else
                        lang = "VN";
                lblTitle.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginCompany")).Tables[0].Rows[0][lang].ToString();
                labelControl2.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginSystem")).Tables[0].Rows[0][lang].ToString();
                labelControl10.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "logincheckupdate")).Tables[0].Rows[0][lang].ToString();
                lbl_User.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginuser")).Tables[0].Rows[0][lang].ToString();
                lbl_Pass.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginpass")).Tables[0].Rows[0][lang].ToString();
                label1.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginlang")).Tables[0].Rows[0][lang].ToString();
                chkRemember.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginremember")).Tables[0].Rows[0][lang].ToString();
                chkAutoLogin.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginauto")).Tables[0].Rows[0][lang].ToString();
                btnCauHinh.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginsetting")).Tables[0].Rows[0][lang].ToString();
                btnThoat.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginexit")).Tables[0].Rows[0][lang].ToString();

                if (btnLogin.Tag == "1")
                {
                    btnLogin.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "loginupdate")).Tables[0].Rows[0][lang].ToString();
                }
                else
                {
                    btnLogin.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "logindangnhap")).Tables[0].Rows[0][lang].ToString();
                }

                progressPanel1.Description = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "logindangnhapketnoi")).Tables[0].Rows[0][lang].ToString();
                lbl_Database.Text = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "logindatabase")).Tables[0].Rows[0][lang].ToString();
            }




        }

    }
}
