using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iHRM.Win.DungChung;
using DevExpress.XtraReports.UI;
using iHRM.Win.Frm.XtraReportTemplate;
using iHRM.Win.Cls;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmSendMail : dlgCustomBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        public frmSendMail()
        {
            InitializeComponent();
        }
        DataRow r;

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
        private string _html;

        public string Html
        {
            get { return _html; }
            set { _html = value; }
        }

        public frmSendMail(DataRow r,int LoaiMail)
        {
            this.r = r;
            this._LoaiMail = LoaiMail;
            InitializeComponent();
        }
      
        public frmSendMail(DataRow r, int LoaiMail,string s,ListBox l)
        {
            this.r = r;
            this._LoaiMail = LoaiMail;
            this._fileMail = l;
            this._html = s;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu..."; //text hiện ở status
            dw_it.OnDoing = (s, ev) => //hàm lấy dữ liệu chạy ngầm
            {
               try
               {
                   if(_LoaiMail == 1) // thư mời phỏng vấn
                   {
                       #region Thư mời phỏng vấn
                       string body = string.Empty;
                       body += "<center><h2>THƯ MỜI PHỎNG VẤN</h2></center>";
                       body += "TP.HCM,ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + "" + "<br>";
                       body += "Kính gửi Anh/Chị:  " + r["HoVaTen"] as string + " <br>";
                       body += "<br>";
                       //get EmployeeTypeName
                       var vitriungtuyen = db.tblRef_EmployeeTypes.Where(p => p.EmpTypeID == r["ViTriUngTuyen"].ToString()).FirstOrDefault();
                       string vtut = string.Empty;
                       if (vitriungtuyen != null)
                           vtut = vitriungtuyen.EmpTypeName;
                       else
                           return;
                       body += "Bộ phận Tuyển dụng Công ty CP Thuận Hải cám ơn Anh/Chị đã gửi hồ sơ ứng tuyển cho vị trí " + vtut + "<br>";
                       body += "Để Anh/Chị hiểu rõ hơn về Công ty và yêu cầu của vị trí tuyển dụng bên cạnh đó Công ty cũng có đánh giá chính xác hơn về hồ sơ và năng lực kinh nghiệm/chuyên môn của Anh/Chị, Bộ phận Tuyển dụng Công ty CP Thuận Hải mời Anh/Chị đến tham dự buổi phỏng vấn với thông tin chi tiết như sau:" + "<br>";
                       body += "Vị trí:  " + vtut + "<br>";
                       TimeSpan gio = (TimeSpan)r["Gio"];
                       body += "Thời gian: " + string.Format("{0: dd/MM/yyyy}", (DateTime)r["NgayPV"]) + " vào lúc " + string.Format("{0: 00}", gio.Hours) + " giờ " + string.Format("{0: 00}", gio.Minutes) + "<br>";
                       body += "Địa điểm: <b>Văn Phòng Công Ty Cổ Phần Thuận Hải, Tầng 10 Tòa Nhà Vinamilk, Số 10 Tân Trào, Tân Phú, Quận 7, TP.HCM</b>" + "<br>";
                       body += "Điện thoại: 028. 54176777" + "<br>";
                       body += "Người liên hệ: <b>Ms. Thủy Tiên – Bộ phận Tuyển dụng</b>" + "<br>";
                       body += "<i>Anh/Chị có thể tìm hiểu thông tin Công ty tại website sau:</i>http://www.thuanhai.com.vn " + "<br>";
                       body += "Hẹn gặp Anh/Chị tại buổi phỏng vấn." + "<br>";
                       body += "<br>";
                       body += "<i>P/s: Để thuận lợi hơn, Anh/Chị vui lòng Điền vào phiếu thông tin trong link dưới đây.</i> " + "<br>";
                       body += @"<p>https://docs.google.com/forms/d/e/1FAIpQLScSd6sv77tAUyo3txZWv2wOP3u6SdcjWykfXTETfAEJEstEkA/viewform</p><br>";
                       body += "<br>";
                       body += "<p align='right'>Trân trọng kính chào" + "<br>";
                       body += "CÔNG TY CP THUẬN HẢI" + "<br>";
                       body += "BỘ PHẬN TUYỂN DỤNG" + "<br></p>";
                       
                       iHRM.Win.DungChung.Ham.SendMailTD(txtSubject.Text, body, txtTo.Text, "", lstFile);

                       //update lại cột 
                       tblUngVienSoBo uvsb = db.tblUngVienSoBos.Where(p => p.MaUVSB == r["MaUVSB"] as string).FirstOrDefault();
                       if (uvsb != null)
                       {
                           uvsb.ThuMoiPV = true;
                           db.SubmitChanges();
                       }
                        #endregion
                       LogAction.LogAction.PushLog("SendEmail", uvsb.MaUVSB, "", string.Format("Gửi thư mời phỏng vấn"), "tblUngVienSoBo");
                    }
                   if(_LoaiMail == 2) // thư mời thử việc
                   {
                       #region Thư mời thử việc
                       string body = string.Empty;
                       body += "<center><h2>THƯ MỜI NHẬN VIỆC</h2></center>";
                       body += "TP.HCM,ngày " + r["Ngay"] + " tháng " + r["Thang"] + " năm " + r["Nam"] + "" + "<br>";
                       body += "Kính gửi Anh/Chị:  " + r["EmployeeName"] as string + " <br>";
                       body += "<br>";
                       body += "Thay mặt Công ty Cổ Phần Thuận Hải, Bộ phận Tuyển dụng cảm ơn Anh/Chị đã tham gia các buổi phỏng vấn trong thời gian qua. <br>";
                       body += "Công ty CP Thuận Hải chúc mừng Anh/Chị đã trúng tuyển trong đợt phỏng vấn cho vị trí " + r["EmpTypeName"] + " vừa qua.<br>";
                       body += "Nay, Bộ phận Tuyển dụng kính gửi Anh/Chị Thư Mời Nhận Việc này.<br>";
                       body += "Anh/Chị vui lòng xem file đính kèm và gửi phản hồi lại Bộ phận Tuyển dụng trước ngày " + r["ngayNhanViec"] + "<br>";
                       body += "Hẹn gặp lại Anh/Chị, chúc Anh/Chị luôn thành công trong công việc và cuộc sống!<br>";
                       body += "<br>";
                       body += "<p align='right'>Trân trọng kính chào" + "<br>";
                       body += "CÔNG TY CP THUẬN HẢI" + "<br>";
                       body += "BỘ PHẬN TUYỂN DỤNG" + "<br></p>";
                       

                       iHRM.Win.DungChung.Ham.SendMailTD(txtSubject.Text, body, txtTo.Text , "", lstFile);

                        ////update lại cột 
                        //tblUngVienSoBo uvsb = db.tblUngVienSoBos.Where(p => p.MaUVSB == r["MaUVSB"] as string).FirstOrDefault();
                        //if (uvsb != null)
                        //{
                        //    uvsb.ThuMoiPV = true;
                        //    db.SubmitChanges();
                        //}

                        #endregion

                        LogAction.LogAction.PushLog("SendEmail", "", "", string.Format("Gửi thư mời thử việc"), "tblUngVienSoBo");
                    }
                   if(_LoaiMail==3 && this._html != string.Empty)
                   {
                       iHRM.Win.DungChung.Ham.SendMailTD(txtSubject.Text, this._html, txtTo.Text , "", lstFile);
                   }
                   dw_it.bw.ReportProgress(1, this);
               }
               catch 
               {
                   GUIHelper.MessageBox("Mail chưa gởi được do thiếu một trong các thông tin sau \n Vị trí tuyển dụng \n Ngày phỏng vấn và giờ phỏng vấn");
               }
            };
            dw_it.OnProcessing = (ps, data) => //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing
            {
                MessageBox.Show("Mail đã được gửi đi", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void btnChoose_Click(object sender, EventArgs e)
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

        private void frmSendMail_Load(object sender, EventArgs e)
        {
            this.txtTo.Text = r["Email"].ToString().Trim();
            if(_LoaiMail == 2)
            {
                txtSubject.Text = "Thư mời thử việc";
            }
            if (_LoaiMail == 3)
            {
                lstFile = this._fileMail;
                txtSubject.Text = string.Empty;
                txtTo.Text = string.Empty;
                txtTo.Enabled = true;
            }
        }

        
    }
}
