using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using iHRM.Win.DungChung;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmSendMail_new : DevExpress.XtraEditors.XtraForm
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        public DataTable lstCustomer { get; set; }
        public class lstTempItem
        {
            public string ten { get; set; }
            public string mota { get; set; }
        }
        public List<lstTempItem> lstTemp = new List<lstTempItem>();

        private string _emailField = "";
        /// <summary>
        /// trường email để gửi
        /// </summary>
        public string myEmailField
        {
            get { return _emailField; }
            set { _emailField = value; }
        }
        private DataRow r;
        public DataRow R
        {
            get { return r; }
            set { r = value; }
        }
        private int _LoaiMail;

        public int LoaiMail
        {
            get { return _LoaiMail; }
            set { _LoaiMail = value; }
        }
        private ListBox _fileMail;

        public ListBox FileMail
        {
            get { return _fileMail; }
            set { _fileMail = value; }
        }
        private DataTable _dt;

        public DataTable Dt
        {
            get { return _dt; }
            set { _dt = value; }
        }

        bool webBrowser1_LoadCompleted = false;
        public frmSendMail_new(DataRow r, int LoaiMail, DataTable dt, ListBox l)
        {
            this.r = r;
            this._LoaiMail = LoaiMail;
            this._fileMail = l;
            this._dt = dt;
            InitializeComponent();
        }
        public frmSendMail_new(DataRow r, int LoaiMail)
        {
            this.r = r;
            this._LoaiMail = LoaiMail;
            InitializeComponent();
        }
        public frmSendMail_new()
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
            switch(this.LoaiMail)
            {
                case 1:
                    {
                        try
                        {
                            this.myNoiDung = getContentThuMoiPV();
                        }
                        catch
                        {
                            GUIHelper.MessageBox("Thiếu thông tin. làm ơn kiểm tra lại thông tin");
                            return;
                        }
                        this.txtSendTo.Text = this.r["Email"] as string;
                        txtSendTo.Enabled = false;
                        this.txtTieuDe.Text = "Thư mời phỏng vấn";
                    } break;
                case 2:
                    {
                        this.myNoiDung = getContentThuMoiNV();
                        this.txtSendTo.Text = this.r["Email"] as string;
                        txtSendTo.Enabled = false;
                        this.txtTieuDe.Text = "Thư mời nhận việc";
                    } break;
                case 3:
                    {
                        this.myNoiDung = Ham.getHTML(this._dt);
                        for (int i = 0; i < this._fileMail.Items.Count; i++)
                        {
                            this.lstFile.Items.Add(_fileMail.Items[i].ToString());
                        } 
                    } break;
            }

            txt_Cc.Text = "";

            try
            {
                w5sysUser u = db.w5sysUsers.Where(p => p.id == LoginHelper.user.id).FirstOrDefault();

                var user = db.w5sysUsers.First(p => p.loginID == u.loginID);

                if (user.Email.ToString() != string.Empty)
                {
                    string temp = user.Email;
                    string[] strS = temp.Split(';');

                    txt_Cc.Text = strS[0];
                }
            }
            catch { }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSendTo.Text==string.Empty)
                {
                    GUIHelper.MessageBox("Chưa nhập Mail cần gởi");
                    return;
                }
                iHRM.Win.DungChung.Ham.SendMailTD(txtTieuDe.Text, this.myNoiDung, txtSendTo.Text, txt_Cc.Text, lstFile);
                GUIHelper.MessageBox("Mail đã gởi thành công");
                switch (this.LoaiMail)
                {
                    case 1:
                        {
                            var uvsb = db.tblUngVienSoBos.Where(p => p.MaUVSB == this.r["MaUVSB"].ToString()).FirstOrDefault();
                            if(uvsb!=null)
                            {
                                uvsb.ngaySendMail = DateTime.Now;
                                db.SubmitChanges();
                            }
                        } break;
                    case 2:
                        {
                            this.myNoiDung = getContentThuMoiNV();
                            this.txtSendTo.Text = this.r["Email"] as string;
                            txtSendTo.Enabled = false;
                            this.txtTieuDe.Text = "Thư mời nhận việc";
                        } break;
                    case 3:
                        {
                            foreach(DataRow r in this._dt.Rows)
                            {
                                //update lại cột gởi hồ sơ cho quản lý
                                var uvsb = db.tblUngVienSoBos.Where(p => p.MaUVSB == r["MaUVSB"].ToString()).FirstOrDefault();
                                if (uvsb != null)
                                {
                                    uvsb.ngaySendMailQL = DateTime.Now;
                                    db.SubmitChanges();
                                }
                            }
                        } break;
                }
                this.Close();
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

        private void txtSendTo_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSendTo.Text))
                materialLabel1.Text = "Gửi tới";
            else
                materialLabel1.Text = "Gửi tới (" + txtSendTo.Text.Trim(' ', '\r', '\r', '\t', ';').Split(';').Length + ")";
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            iHRM.Common.Code.SendMailHelper sm = new iHRM.Common.Code.SendMailHelper(iHRM.Core.Business.Logic.AllLogic.SysPa_Get("mail_u"), iHRM.Core.Business.Logic.AllLogic.SysPa_Get("mail_p"));
            var Parser = new iTemplate.iTemplateParser();
            Random rnd = new Random((int)DateTime.Now.Ticks);

            if (lstCustomer != null && lstCustomer.Rows.Count > 0)
            {
                foreach (DataRow cus in lstCustomer.Rows)
                {
                    if (backgroundWorker1.CancellationPending)
                        return;

                    backgroundWorker1.ReportProgress(1, "Gửi tới " + cus[_emailField]);

                    Parser.SetTemplate(e.Argument.ToString());

                    foreach (var it in lstTemp)
                    {
                        if (lstCustomer.Columns.Contains(it.ten))
                            Parser.Parse(it.ten, cus[it.ten].ToString());
                    }

                    sm.sendMailTo(cus[_emailField].ToString(), txtTieuDe.Text, Parser.GetTemplate());
                    if (chkDelaySend.Checked)
                        System.Threading.Thread.Sleep(rnd.Next(3500, 7700));
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
                    sm.sendMailTo(em, txtTieuDe.Text, e.Argument.ToString());
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
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var filename in openFileDialog1.FileNames)
                {
                    //Thêm các file đã chọn vào listBox1
                    lstFile.Items.Add(filename.ToString());
                }
            }
        }
        public string getContentThuMoiPV()
        {
            string body = string.Empty;
            body+="<p style='margin-left:0in; margin-right:0in; text-align:center'><img id='Picture_x0020_1' src='http://thuanhai.com.vn/datafiles/banners/14334898994427_logo.png' style='height:63.9pt; left:0px; margin-left:-3.75pt; margin-top:-1.5pt; position:absolute; text-align:left; width:99pt; z-index:-251657216' /></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:center'><strong><span style='font-size:20pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>THƯ MỜI PHỎNG VẤN</span></span></span></strong></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:center'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></p>                                                                                                                 ";
            body+="<p style='margin-left:3in; margin-right:0in; text-align:right'><span style='color:#000000'><em><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='font-size:medium'>Tp.HCM,ng&agrave;y "+DateTime.Now.Day+" th&aacute;ng </span></span></em><span style='font-size:9pt'><span style='font-family:&quot;Times New Roman&quot;,serif'>"+DateTime.Now.Month+"</span></span> <em><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='font-size:medium'>năm </span                                                                                                                  ";
            body+="></span></em><span style='font-size:9pt'><span style='font-family:&quot;Times New Roman&quot;,serif'> "+ DateTime.Now.Year +" </span></span></span></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                      ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'>&nbsp;</p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='color:#000000'><em><u><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'>K&iacute;nh gửi Anh/Chị:</span></span></u></em> &nbsp;<span style='font-family:&quot;Times New Roman&quot;,serif'><span style='font-size:medium'>"+this.r["HoVaTen"]+"</span></span></span></p>                                                                                                                                                                                           ";
            body+="<p style='margin-left:0in; margin-right:0in'>&nbsp;</p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ";
            var vitriungtuyen = db.tblRef_EmployeeTypes.Where(p => p.EmpTypeID == r["ViTriUngTuyen"].ToString()).FirstOrDefault();
            string vtut = string.Empty;
            if (vitriungtuyen != null)
                vtut = vitriungtuyen.EmpTypeName;
            else
                return string.Empty;
            body += "<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><span style='color:#000000'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'>Bộ phận Tuyển dụng C&ocirc;ng ty CP Thuận Hải c&aacute;m ơn Anh/Chị đ&atilde; gửi hồ sơ ứng tuyển cho vị tr&iacute; </span></span><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='font-size:medium'>" + vtut + "</span></span></span></span></p>                                                                                              ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>Để Anh/Chị hiểu r&otilde; hơn về C&ocirc;ng ty v&agrave; y&ecirc;u cầu của vị tr&iacute; tuyển dụng b&ecirc;n cạnh đ&oacute; C&ocirc;ng ty cũng c&oacute; đ&aacute;nh    gi&aacute; </br></br> ch&iacute;nh x&aacute;c hơn về hồ sơ v&agrave; năng lực kinh nghiệm/chuy&ecirc;n m&ocirc;n của Anh/Chị, Bộ phận Tuyển dụng C&ocirc;ng ty CP Thuận</span></span></span></span></p>                                                                                                                                                                                                                        ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>Hải mời Anh/Chị đến tham dự buổi phỏng vấn với th&ocirc;ng tin chi tiết như sau:</span></span></span></span></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ";
            body += "<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><span style='color:#000000'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'>Vị tr&iacute;: &nbsp;</span></span><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='font-size:medium'> " + vtut + " </span></span></span></span></p>                                                                                                                                                                                             ";
            TimeSpan gio = (TimeSpan)r["Gio"];
            body += "<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><span style='color:#000000'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'>Thời gian: </span></span><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='font-size:medium'> " + string.Format("{0: dd/MM/yyyy}", (DateTime)r["NgayPV"]) + " </span> </span><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'>v&agrave;o l&uacute;c </span></span><span style='font-fa                                                                              ";
            body += "mily:&quot;Times New Roman&quot;,serif'><span style='font-size:medium'> " + string.Format("{0: 00}", gio.Hours) + " </span></span><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'> giờ </span></span><span style='font-size:medium'><span style='font-family:&quot;Times New Roman&quot;,serif'>" + string.Format("{0: 00}", gio.Minutes) + "</span></span></span></span></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>Địa điểm:&nbsp;<strong>Văn Ph&ograve;ng C&ocirc;ng Ty Cổ Phần Thuận Hải, Tầng 10 T&ograve;a Nh&agrave; Vinamilk, Số 10 T&acirc;n Tr&agrave;o, T&acirc;n Ph&uacute;, Quận 7, TP.HCM</strong></span></span></span></span></p>                                                                                                                                                                                                                                                                                                                                                               ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><span style='color:#000000'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'>Điện thoại: 028. 54176777</span></span></span></span></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>Người li&ecirc;n hệ: <strong>Ms. Thủy Ti&ecirc;n &ndash; Bộ phận Tuyển dụng</strong></span></span></span></span></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><em><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>Anh/Chị c&oacute; thể t&igrave;m hiểu th&ocirc;ng tin C&ocirc;ng ty tại website sau:</span></span></span></em><a href='http://www.thuanhai.com.vn/' target='_blank'><em><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'>http://www.thuanhai.com.vn</span></span></em></a></span></p>                                                                                                                                                                                                                                                         ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>Hẹn gặp Anh/Chị tại buổi phỏng vấn.</span></span></span></span></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'>&nbsp;</p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><em><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>P/s: Để thuận lợi hơn, Anh/Chị vui l&ograve;ng điền v&agrave;o phiếu th&ocirc;ng tin dưới đ&acirc;y v&agrave; mang theo c&ugrave;ng với hồ sơ c&aacute; nh&acirc;n khi đến phỏng vấn . </span></span></span></em></span></p>                                                                                                                                                                                                                                                                                                                                                          ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='background-color:white'><em><u><span style='font-size:14pt'><span style='background-color:white'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#0070c0'>https://docs.google.com/forms/d/e/1FAIpQLScSd6sv77tAUyo3txZWv2wOP3u6SdcjWykfXTETfAEJEstEkA/viewform</span></span></span></span></u></em></span></p>                                                                                                                                                                                                                                                                                                                                                                                           ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:right'><br />                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                ";
            body+="<span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tr&acirc;n trọng k&iacute;nh ch&agrave;o</span></span></span></p>     ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:right'><span style='background-color:white'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>C&Ocirc;NG TY CP THUẬN HẢI</span></span></span></span></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:right'><br />                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                ";
            body+="<span style='background-color:white'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BỘ PHẬN TUYỂN DỤNG</span></span></span></span></p>                          ";
            return body;
        }
        public string getContentThuMoiNV()
        {
            string body = string.Empty;
            body += "<p style='margin-left:0in; margin-right:0in; text-align:center'><img id='Picture_x0020_1' src='http://thuanhai.com.vn/datafiles/banners/14334898994427_logo.png' style='height:63.9pt; left:0px; margin-left:-3.75pt; margin-top:-1.5pt; position:absolute; text-align:left; width:99pt; z-index:-251657216' /></p>                                                                                                                                                                                                                                                                                                                                                                            ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:center'><strong><span style='font-size:20pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>THƯ MỜI NHẬN VIỆC</span></span></span></strong></p>                                                                                                                                                                                                                                                                                                                                                                                                                                                         ";
            body+="<p style='margin-left:0in; margin-right:0in'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span></span></p>                        ";
            body+="<p style='margin-left:3in; margin-right:0in; text-align:right'><span style='color:#000000'><em><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='font-size:medium'>Tp.HCM,ng&agrave;y "+DateTime.Now.Day+" th&aacute;ng </span></span></em><span style='font-size:9pt'><span style='font-family:&quot;Times New Roman&quot;,serif'> "+DateTime.Now.Month+" </span></span> <em><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='font-size:me                      ";
            body+="dium'>năm </span></span></em><span style='font-size:9pt'><span style='font-family:&quot;Times New Roman&quot;,serif'> "+DateTime.Now.Year+" </span></span></span></p>                                                                                                                                                                                                                                                                                                                              ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:justify'>&nbsp;</p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ";
            body += "<p style='margin-left:0in; margin-right:0in; text-align:justify'><span style='color:#000000'><em><u><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'>K&iacute;nh gửi Anh/Chị:</span></span></u></em> &nbsp;<span style='font-family:&quot;Times New Roman&quot;,serif'><span style='font-size:medium'>" + this.r["EmployeeName"] + "</span></span></span></p>                                                                               ";
            body+="<p style='margin-left:0in; margin-right:0in'>&nbsp;</p>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ";
            body += "<p style='margin-left:0in; margin-right:0in'>&nbsp;</p>";
            body+="<p style='margin-left:0in; margin-right:0in'><span style='font-size:13pt'><span style='background-color:white'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:black'>Thay mặt C&ocirc;ng ty Cổ Phần Thuận Hải, Bộ phận Tuyển dụng cảm ơn Anh/Chị đ&atilde; tham gia c&aacute;c buổi phỏng vấn trong thời gian qua.</span></span></span></span></p>                           ";
            body += "<p style='margin-left:0in; margin-right:0in'><span style='font-size:13pt'><span style='background-color:white'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:black'>C&ocirc;ng ty CP Thuận Hải ch&uacute;c mừng Anh/Chị đ&atilde; tr&uacute;ng tuyển trong đợt phỏng vấn cho vị tr&iacute; " + this.r["EmpTypeName"] + " vừa qua.</span></span></span></span></p>              ";
            body+="<p style='margin-left:0in; margin-right:0in'><span style='font-size:13pt'><span style='background-color:white'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:black'>Nay, Bộ phận Tuyển dụng k&iacute;nh gửi Anh/Chị Thư Mời Nhận Việc n&agrave;y.</span></span></span></span></p>                                                                                           ";
            body += "<p style='margin-left:0in; margin-right:0in'><span style='font-size:13pt'><span style='background-color:white'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:black'>Anh/Chị vui l&ograve;ng xem file đ&iacute;nh k&egrave;m v&agrave; gửi phản hồi lại Bộ phận Tuyển dụng trước ng&agrave;y " + this.r["ngayNhanViec"] + ".</span></span></span></span></p>                    ";
            body+="<p style='margin-left:0in; margin-right:26pt'><span style='font-size:13pt'><span style='background-color:white'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:black'>Hẹn gặp lại Anh/Chị, ch&uacute;c Anh/Chị lu&ocirc;n th&agrave;nh c&ocirc;ng trong c&ocirc;ng việc v&agrave; cuộc sống</span></span></span></span><span style='font-size:13pt'><span style=             ";
            body+="'font-family:&quot;Times New Roman&quot;,serif'><span style='color:black'>.</span></span></span><br />                                                                                                                                                                                                                                                                                                       ";
            body+="<span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp           ";
            body+="<p style='margin-left:0in; margin-right:26pt; text-align:right'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>Tr&acirc;n trọng k&iacute;nh ch&agrave;o</span></span></span></p>                                                                                                                                                       ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:right'><span style='background-color:white'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>C&Ocirc;NG TY CP THUẬN HẢI</span></span></span></span></p>                                                                                                                          ";
            body+="<p style='margin-left:0in; margin-right:0in; text-align:right'><br />                                                                                                                                                                                                                                                                                                                                        ";
            body+="<span style='background-color:white'><span style='font-size:13pt'><span style='font-family:&quot;Times New Roman&quot;,serif'><span style='color:#000000'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp    ";
            body+="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BỘ PHẬN TUYỂN DỤNG</span></span></span></span></p>                           ";
            return body;
        }
    }
}
