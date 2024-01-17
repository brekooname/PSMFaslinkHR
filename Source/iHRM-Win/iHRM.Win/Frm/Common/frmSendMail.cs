using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Common
{
    public partial class frmSendMail : DevExpress.XtraEditors.XtraForm
    {
        public DataTable lstCustomer { get; set; }

        public class lstTempItem
        {
            public string ten { get; set; }
            public string mota { get; set; }
        }
        public List<lstTempItem> lstTemp = new List<lstTempItem>();

        private string _emailField = "";
        private string _thangTL = "";
        /// <summary>
        /// trường email để gửi
        /// </summary>
        public string myEmailField
        {
            get { return _emailField; }
            set { _emailField = value; }
        }

        public string thangTL
        {
            get { return _thangTL; }
            set { _thangTL = value; }
        }

        bool webBrowser1_LoadCompleted = false;

        public frmSendMail()
        {
            InitializeComponent();
        }

        public string myTieuDe
        {
            get { return txtTieuDe.Text; }
            set { txtTieuDe.Text = value; }
        }

        private string _myNoiDung = "";
        public string myNoiDung
        {
            get { return webBrowser1_LoadCompleted ? webBrowser1.Document.InvokeScript("eval", new object[] { "myGetText()" }).ToString() : _myNoiDung; }
            set { if (webBrowser1_LoadCompleted) webBrowser1.Document.InvokeScript("mySetText", new object[] { value }); else _myNoiDung = value; }
        }

        private void frmTTTK_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("file:///" + System.IO.Path.Combine(win_globall.apppath, "ExcelTemplate\\ckeditor\\index.html"));
            grd.DataSource = lstTemp;

            if (lstCustomer != null && lstCustomer.Rows.Count > 0)
            {
                if (!lstCustomer.Columns.Contains(_emailField))
                {
                    GUIHelper.MessageBox("Cần đinh nghĩa trường email");
                }
                else
                {
                    txtSendTo.Text = string.Join(";", lstCustomer.Select().Select(i => i[_emailField]));
                }

                txtSendTo.Enabled = false;
                materialLabel1.Text = "Gửi tới";
            }
            else
            {
                grd.Visible = false;
            }

            textEdit1.Text = System.IO.Path.Combine(win_globall.apppath, "ExcelTemplate\\Luong\\PhieuLuong_GuiEmail.html");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                    btnSend.Text = "Đang dừng lại";
                    btnSend.Enabled = false;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtSendTo.Text))
                    {
                        GUIHelper.MessageBox("Cần điền địa chỉ gửi");
                        return;
                    }
                    if (lstCustomer != null && lstCustomer.Rows.Count > 0)
                    {
                        if (!lstCustomer.Columns.Contains(_emailField))
                        {
                            GUIHelper.MessageBox("Cần đinh nghĩa trường email");
                            return;
                        }
                    }

                    if (checkEdit1.Checked)
                        backgroundWorker1.RunWorkerAsync(System.IO.File.ReadAllText(textEdit1.Text));
                    else
                        backgroundWorker1.RunWorkerAsync(myNoiDung);
                    btnSend.Text = "Dừng lại";
                }
            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1_LoadCompleted = true;
            if (!string.IsNullOrWhiteSpace(_myNoiDung))
                myNoiDung = _myNoiDung;
        }

        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (webBrowser1_LoadCompleted)
            {
                var it = grv.GetFocusedRow() as lstTempItem;
                if (it != null)
                {
                    webBrowser1.Document.InvokeScript("myInsertText", new object[] { "{{" + it.ten + "}}" });
                }
            }
        }

        private void txtSendTo_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSendTo.Text))
                materialLabel1.Text = "Gửi tới";
            else
                materialLabel1.Text = "Gửi tới (" + txtSendTo.Text.Trim(' ', '\r', '\r', '\t', ';').Split(';').Length + ")";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //iHRM.Common.Code.SendMailHelper sm = new iHRM.Common.Code.SendMailHelper(iHRM.Core.Business.Logic.AllLogic.SysPa_Get("mail_u"), iHRM.Core.Business.Logic.AllLogic.SysPa_Get("mail_p"));
            var Parser = new iTemplate.iTemplateParser();
            Random rnd = new Random((int)DateTime.Now.Ticks);
            
            if (lstCustomer != null && lstCustomer.Rows.Count > 0)
            {
                foreach (DataRow cus in lstCustomer.Rows)
                {
                    if (backgroundWorker1.CancellationPending)
                        return;

                    string sendTo = cus[_emailField] as string;
                    if (!string.IsNullOrWhiteSpace(sendTo) && iHRM.Common.Code.SendMailHelper.IsValidEmail(sendTo))
                    {
                        backgroundWorker1.ReportProgress(1, "Gửi tới " + sendTo);

                        Parser.SetTemplate(e.Argument.ToString());

                        foreach (DataColumn dc in lstCustomer.Columns)
                        {
                            if (dc.DataType == typeof(double)
                                || dc.DataType == typeof(int)
                                || dc.DataType == typeof(long)
                                || dc.DataType == typeof(decimal)
                                || dc.DataType == typeof(float)
                            )
                                Parser.Parse(dc.ColumnName, string.Format("{0:#,0}", cus[dc]));
                            else
                                Parser.Parse(dc.ColumnName, "" + cus[dc]);
                        }

                        Parser.Parse("thangTL", "" + thangTL);

                        iHRM.Win.DungChung.Ham.SendMail_Luong(sendTo, txtTieuDe.Text + " - " + cus["nv_ten"].ToString(), Parser.GetTemplate());
                        if (chkDelaySend.Checked)
                            System.Threading.Thread.Sleep(rnd.Next(3500, 7700));
                    }
                }
            }
            else
            {
                string[] emails = txtSendTo.Text.Trim(' ', '\r', '\r', '\t', ';').Split(';');

                foreach (string em in emails)
                {
                    if (backgroundWorker1.CancellationPending)
                        return;

                    backgroundWorker1.ReportProgress(1, "Gửi tới " + em);
                    iHRM.Win.DungChung.Ham.SendMail_Luong(em, txtTieuDe.Text, e.Argument.ToString());
                    if (chkDelaySend.Checked)
                        System.Threading.Thread.Sleep(rnd.Next(3500, 7700));
                }
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                toolStripStatusLabel1.Text = e.UserState.ToString();
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSend.Text = "Bắt đầu gửi";
            btnSend.Enabled = true;

            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "HTML|*.html";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sd.FileName, myNoiDung);
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog sd = new OpenFileDialog();
            sd.Filter = "HTML|*.html";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                myNoiDung = System.IO.File.ReadAllText(sd.FileName);
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
            }
        }

        private void textEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "HTML|*.html";
            if (od.ShowDialog() == DialogResult.OK)
                textEdit1.Text = od.FileName;
        }

        private void frmSendMail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                GUIHelper.MessageBox("Đang gửi email!");
                e.Cancel = true;
            }
        }
    }
}
