using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iHRM.Win.Frm.Common
{
    public partial class dlgCauHinhDB : dlgCustomBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        iHRM.Core.Business.Logic.Common.login logic = new iHRM.Core.Business.Logic.Common.login();

        private DataTable dtInstance = null;

        private DataTable dtDatabase = null;

        private bool installAsServer = false;

        private bool installAsServerMCC = false;

        private bool installAsServerFile = false;

        private bool installAsServerPush = false;

        private w5sysConnectionString _conn = null;

        public String _code = "";
        public dlgCauHinhDB()
        {
            InitializeComponent();
        }

        private void InitData() //Load data to control
        {
            if (_conn != null)
            {
                try
                {
                    String[] _index = _conn.strcnn.Split(';');

                    String[] _indexMCC = _conn.strMCC.Split(';');

                    String[] _indexFile = _conn.strFile.Split(';');

                    String[] _indexPush = _conn.strPushServer.Split(';');

                    //Strcnn
                    cboSV.Text = _index[0].Replace("Data Source=", "");

                    cboDB.Text = _index[1].Replace("Initial Catalog=", "");

                    txtID.Text = _index.Count() >= 4 ? _index[2].Replace("User ID=", "") : "";

                    txtPW.Text = _index.Count() >= 4 ? _index[3].Replace("Password=", "") : "";

                    cboAU.SelectedIndex = _index.Count() >= 4 ? 1 : 0;

                    //StrcnnMCC
                    cboSVMCC.Text = _indexMCC[0].Replace("Data Source=", "");

                    cboDBMCC.Text = _indexMCC[1].Replace("Initial Catalog=", "");

                    txtIDMCC.Text = _indexMCC.Count() >= 4 ? _indexMCC[2].Replace("User ID=", "") : "";

                    txtPWMCC.Text = _indexMCC.Count() >= 4 ? _indexMCC[3].Replace("Password=", "") : "";

                    cboAUMCC.SelectedIndex = _indexMCC.Count() >= 4 ? 1 : 0;

                    //StrcnnFile
                    cboSVFile.Text = _indexFile[0].Replace("Data Source=", "");

                    cboDBFile.Text = _indexFile[1].Replace("Initial Catalog=", "");

                    txtIDFile.Text = _indexFile.Count() >= 4 ? _indexFile[2].Replace("User ID=", "") : "";

                    txtPWFile.Text = _indexFile.Count() >= 4 ? _indexFile[3].Replace("Password=", "") : "";

                    cboAUFile.SelectedIndex = _indexFile.Count() >= 4 ? 1 : 0;

                    //StrcnnFile
                    cboSVPush.Text = _indexPush[0].Replace("Data Source=", "");

                    cboDBPush.Text = _indexPush[1].Replace("Initial Catalog=", "");

                    txtIDPush.Text = _indexPush.Count() >= 4 ? _indexPush[2].Replace("User ID=", "") : "";

                    txtPWPush.Text = _indexPush.Count() >= 4 ? _indexPush[3].Replace("Password=", "") : "";

                    cboAUPush.SelectedIndex = _indexPush.Count() >= 4 ? 1 : 0;
                }
                catch { }
            }
        }

        private void dlgCauHinhDB_Load(object sender, EventArgs e)
        {
            _conn = db.w5sysConnectionStrings.Where(p => p.code == _code).SingleOrDefault();

            InitData();
        }

        #region: Concat connect string
        public string BuildConnection(bool hasDb = true)
        {
            //Data Source=192.168.1.108;Initial Catalog=IVT_PMBH;User ID=sa;Password=123456@ivt

            if (String.IsNullOrWhiteSpace(cboSV.Text))
                return "";

            string strcnn = string.Format("Data Source={0};", cboSV.Text);

            if (!string.IsNullOrWhiteSpace(cboDB.Text))
            {
                if (hasDb)
                    strcnn += string.Format("Initial Catalog={0};", cboDB.Text);
            }

            if (cboAU.SelectedIndex == 1)
                strcnn += string.Format("User ID={0};Password={1}", txtID.Text, txtPW.Text);

            strcnn += (cboAU.SelectedIndex == 0 ? "Integrated Security=SSPI" : "");
            return strcnn;
        }

        public string BuildConnectionMCC(bool hasDb = true)
        {
            //Data Source=192.168.1.108;Initial Catalog=IVT_PMBH;User ID=sa;Password=123456@ivt

            if (String.IsNullOrWhiteSpace(cboSVMCC.Text))
                return "";

            string strcnn = string.Format("Data Source={0};", cboSVMCC.Text);

            if (!string.IsNullOrWhiteSpace(cboDBMCC.Text))
            {
                if (hasDb)
                    strcnn += string.Format("Initial Catalog={0};", cboDBMCC.Text);
            }

            if (cboAUMCC.SelectedIndex == 1)
                strcnn += string.Format("User ID={0};Password={1}", txtIDMCC.Text, txtPWMCC.Text);

            strcnn += (cboAUMCC.SelectedIndex == 0 ? "Integrated Security=SSPI" : "");
            return strcnn;
        }

        public string BuildConnectionFile(bool hasDb = true)
        {
            //Data Source=192.168.1.108;Initial Catalog=IVT_PMBH;User ID=sa;Password=123456@ivt

            if (String.IsNullOrWhiteSpace(cboSVFile.Text))
                return "";

            string strcnn = string.Format("Data Source={0};", cboSVFile.Text);

            if (!string.IsNullOrWhiteSpace(cboDBFile.Text))
            {
                if (hasDb)
                    strcnn += string.Format("Initial Catalog={0};", cboDBFile.Text);
            }

            if (cboAUFile.SelectedIndex == 1)
                strcnn += string.Format("User ID={0};Password={1}", txtIDFile.Text, txtPWFile.Text);

            strcnn += (cboAUFile.SelectedIndex == 0 ? "Integrated Security=SSPI" : "");
            return strcnn;
        }

        public string BuildConnectionPush(bool hasDb = true)
        {
            //Data Source=192.168.1.108;Initial Catalog=IVT_PMBH;User ID=sa;Password=123456@ivt

            if (String.IsNullOrWhiteSpace(cboSVPush.Text))
                return "";

            string strcnn = string.Format("Data Source={0};", cboSVPush.Text);

            if (!string.IsNullOrWhiteSpace(cboDBPush.Text))
            {
                if (hasDb)
                    strcnn += string.Format("Initial Catalog={0};", cboDBPush.Text);
            }

            if (cboAUPush.SelectedIndex == 1)
                strcnn += string.Format("User ID={0};Password={1}", txtIDPush.Text, txtPWPush.Text);

            strcnn += (cboAUPush.SelectedIndex == 0 ? "Integrated Security=SSPI" : "");
            return strcnn;
        }
        #endregion

        #region: Button click
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            linkLabel1.Image = Properties.Resources.loading;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();
            linkLabel2.Image = Properties.Resources.loading;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            linkLabel3.Image = Properties.Resources.loading;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();
            linkLabel4.Image = Properties.Resources.loading;
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            linkLabel6.Image = Properties.Resources.loading;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();
            linkLabel5.Image = Properties.Resources.loading;
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            linkLabel8.Image = Properties.Resources.loading;
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();
            linkLabel7.Image = Properties.Resources.loading;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Install();
        }

        private void btnTestConnect_Click_1(object sender, EventArgs e)
        {
            if (checkConnection())
                GUIHelper.MessageBox("Kết nối thành công");
            else
                GUIHelper.MessageError("Kết nối không thành công");
        }

        private void btnTestConnectMCC_Click(object sender, EventArgs e)
        {
            if (checkConnectionMCC())
                GUIHelper.MessageBox("Kết nối thành công");
            else
                GUIHelper.MessageError("Kết nối không thành công");
        }

        private void btnLuuMCC_Click(object sender, EventArgs e)
        {
            InstallMCC();
        }

        private void btnTestConnectFile_Click(object sender, EventArgs e)
        {
            if (checkConnectionFile())
                GUIHelper.MessageBox("Kết nối thành công");
            else
                GUIHelper.MessageError("Kết nối không thành công");
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            InstallFile();
        }

        private void btnTestConnectPush_Click(object sender, EventArgs e)
        {
            if (checkConnectionPush())
                GUIHelper.MessageBox("Kết nối thành công");
            else
                GUIHelper.MessageError("Kết nối không thành công");
        }

        private void btnLuuPush_Click(object sender, EventArgs e)
        {
            InstallPush();
        }
        #endregion

        #region: BackgroundWorker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Data.Sql.SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
            dtInstance = instance.GetDataSources();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cboSV.Tag = 1;
            cboSV.Items.Clear();
            cboSVMCC.Tag = 1;
            cboSVMCC.Items.Clear();
            cboSVFile.Tag = 1;
            cboSVFile.Items.Clear();
            cboSVPush.Tag = 1;
            cboSVPush.Items.Clear();

            foreach (DataRow dr in dtInstance.Rows)
            {
                cboSV.Items.Add("" + dr[0] + (string.IsNullOrWhiteSpace(dr[1].ToString()) ? "" : "\\" + dr[1]));
                cboSVMCC.Items.Add("" + dr[0] + (string.IsNullOrWhiteSpace(dr[1].ToString()) ? "" : "\\" + dr[1]));
                cboSVFile.Items.Add("" + dr[0] + (string.IsNullOrWhiteSpace(dr[1].ToString()) ? "" : "\\" + dr[1]));
                cboSVPush.Items.Add("" + dr[0] + (string.IsNullOrWhiteSpace(dr[1].ToString()) ? "" : "\\" + dr[1]));
            }

            cboSV.DroppedDown = true;
            linkLabel1.Image = null;
            linkLabel3.Image = null;
            linkLabel6.Image = null;
            linkLabel8.Image = null;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            SqlConnection cnn = new SqlConnection(BuildConnection(false));
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dtDatabase = new DataTable();
            try
            {
                cmd.CommandText = "sp_databases";
                da.Fill(dtDatabase);
            }
            catch
            {
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cboDB.DataSource = dtDatabase;
            cboDB.DroppedDown = true;

            cboDBFile.DataSource = dtDatabase;
            cboDBMCC.DataSource = dtDatabase;
            cboDBPush.DataSource = dtDatabase;
            linkLabel2.Image = null;
            linkLabel4.Image = null;
            linkLabel5.Image = null;
            linkLabel7.Image = null;
        }
        #endregion

        #region: Hàm xử lý
        bool Install()
        {
            //if (!checkConnection())
            //{
            //    GUIHelper.MessageError("Kết nối không thành công");
            //    return false;
            //}

            try
            {
                string strcnn = BuildConnection();

                _conn.strcnn = strcnn;

                db.SubmitChanges();

                //saveConnection();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
                return false;
            }

            return true;
        }


        bool checkConnection()
        {
            string strcnn = installAsServer ? BuildConnection(false) : BuildConnection(true);

            SqlConnection cnn = new SqlConnection(strcnn);
            try
            {
                cnn.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }

        bool InstallMCC()
        {
            //if (!checkConnectionMCC())
            //{
            //    GUIHelper.MessageError("Kết nối không thành công");
            //    return false;
            //}

            try
            {
                string strcnn = BuildConnectionMCC();

                _conn.strMCC = strcnn;

                db.SubmitChanges();

                //saveConnection();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
                return false;
            }

            return true;
        }


        bool checkConnectionMCC()
        {
            string strcnn = installAsServerMCC ? BuildConnectionMCC(false) : BuildConnectionMCC(true);

            SqlConnection cnn = new SqlConnection(strcnn);
            try
            {
                cnn.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }

        bool InstallFile()
        {
            //if (!checkConnectionFile())
            //{
            //    GUIHelper.MessageError("Kết nối không thành công");
            //    return false;
            //}

            try
            {
                string strcnn = BuildConnectionFile();

                _conn.strFile = strcnn;

                db.SubmitChanges();

                //saveConnection();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
                return false;
            }

            return true;
        }


        bool checkConnectionFile()
        {
            string strcnn = installAsServerFile ? BuildConnectionFile(false) : BuildConnectionFile(true);

            SqlConnection cnn = new SqlConnection(strcnn);
            try
            {
                cnn.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }

        bool InstallPush()
        {
            //if (!checkConnectionFile())
            //{
            //    GUIHelper.MessageError("Kết nối không thành công");
            //    return false;
            //}

            try
            {
                string strcnn = BuildConnectionPush();

                _conn.strPushServer = strcnn;

                db.SubmitChanges();

                //saveConnection();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
                return false;
            }

            return true;
        }


        bool checkConnectionPush()
        {
            string strcnn = installAsServerPush ? BuildConnectionPush(false) : BuildConnectionPush(true);

            SqlConnection cnn = new SqlConnection(strcnn);
            try
            {
                cnn.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }
        #endregion

        #region: Control
        private void cboAU_TextChanged(object sender, EventArgs e)
        {
            if (cboAU.SelectedIndex == 0)
            {
                installAsServer = true;

                txtID.Enabled = false;

                txtPW.Enabled = false;
            }
            else
            {
                installAsServer = false;

                txtID.Enabled = true;

                txtPW.Enabled = true;
            }
        }

        private void cboAUMCC_TextChanged(object sender, EventArgs e)
        {
            if (cboAUMCC.SelectedIndex == 0)
            {
                installAsServerMCC = true;

                txtIDMCC.Enabled = false;

                txtPWMCC.Enabled = false;
            }
            else
            {
                installAsServerMCC = false;

                txtIDMCC.Enabled = true;

                txtPWMCC.Enabled = true;
            }
        }

        private void cboAUFile_TextChanged(object sender, EventArgs e)
        {
            if (cboAUFile.SelectedIndex == 0)
            {
                installAsServerFile = true;

                txtIDFile.Enabled = false;

                txtPWFile.Enabled = false;
            }
            else
            {
                installAsServerFile = false;

                txtIDFile.Enabled = true;

                txtPWFile.Enabled = true;
            }
        }

        private void cboAUPush_TextChanged(object sender, EventArgs e)
        {
            if (cboAUPush.SelectedIndex == 0)
            {
                installAsServerPush = true;

                txtIDPush.Enabled = false;

                txtPWPush.Enabled = false;
            }
            else
            {
                installAsServerPush = false;

                txtIDPush.Enabled = true;

                txtPWPush.Enabled = true;
            }
        }
        #endregion
    }
}