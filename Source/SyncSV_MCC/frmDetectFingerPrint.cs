using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Mail;

namespace SyncSV
{
    public partial class frmDetectFingerPrint : Form
    {

        public zkemkeeper.CZKEMClass axCZKEM1;
        public frmDetectFingerPrint()
        {
            InitializeComponent();
        }
        private void frmDetectFingerPrint_Load(object sender, EventArgs e)
        {
            axCZKEM1 = new zkemkeeper.CZKEMClass();
            axCZKEM1.OnConnected += axCZKEM1_OnConnected;
            axCZKEM1.OnDisConnected += axCZKEM1_OnDisConnected;

            try
            {
                var a = Properties.Settings.Default.FPstrcnn.Trim().Split(';');
                var isCOnnected = false;
                switch (a[0])
                {
                    case "LAN":
                        isCOnnected = axCZKEM1.Connect_Net(a[1], Convert.ToInt32(a[2]));
                        break;
                    case "COM":
                        isCOnnected = axCZKEM1.Connect_Com(int.Parse(a[1]), Convert.ToInt32(a[2]), Convert.ToInt32(a[3]));
                        break;
                    case "USB":
                        isCOnnected = axCZKEM1.Connect_USB(Convert.ToInt32(a[1]));
                        break;
                }
                if (isCOnnected)
                {
                    axCZKEM1.EnableDevice(1, true);
                    if (axCZKEM1.RegEvent(1, 32767))
                    {
                        axCZKEM1.OnVerify += axCZKEM1_OnVerify;
                        axCZKEM1.OnAttTransaction += new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction);
                        axCZKEM1.OnAttTransactionEx += axCZKEM1_OnAttTransactionEx;
                        // axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kết nối máy chấm công không thành công");
            }

            timer1.Start();
        }

        private void axCZKEM1_OnConnected()
        {
            pictureEdit1.Image = Properties.Resources.fingerPrint;
            label2.Text = "-";
            label4.Text = "-";
        }

        private void axCZKEM1_OnFinger()
        {
            MessageBox.Show("Test");
        }
        void axCZKEM1_OnVerify(int UserID)
        {
            if (UserID == -1)
            {
                label2.Text = "Không có dữ liệu về nhân viên này!";
                label2.ForeColor = Color.Red;
                label4.Text = "-";
            }
        }
        void axCZKEM1_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            try
            {
                var time = new DateTime(Year, Month, Day, Hour, Minute, Second);
                var r = Business.ADOController.ExeProcedure("p_push_fingerPrint",
                    new System.Data.SqlClient.SqlParameter("ma_cc", EnrollNumber),
                    new System.Data.SqlClient.SqlParameter("somay", Properties.Settings.Default.FP_soMay),
                    new System.Data.SqlClient.SqlParameter("time", time),
                    new System.Data.SqlClient.SqlParameter("timeClient", DateTime.Now)

                );
                label2.Text = r.Rows.Count == 0 ? "Nhân viên chưa được khai báo trên phần mềm!" : r.Rows[0]["tenChamCong"] as string;
                label2.ForeColor = Color.Black;
                label4.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", time);
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
                label2.ForeColor = Color.Red;
            }
        }
        void axCZKEM1_OnAttTransaction(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
        }

        private void axCZKEM1_OnDisConnected()
        {
            pictureEdit1.Image = Properties.Resources.btnRefresh_Image;
            label2.Text = "Mất kết nối tới máy chấm công!";
        }

        private void frmDetectFingerPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Không cho phép tắt chương trình!");
            e.Cancel = true;
        }

        static bool LAN_ping(string add)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply rep = p.Send(add);
            return (rep.Status == System.Net.NetworkInformation.IPStatus.Success);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var a = Properties.Settings.Default.FPstrcnn.Trim().Split(';');
                switch (a[0])
                {
                    case "LAN":
                        if (!LAN_ping(a[1]))
                        {
                            SendMail("[THUANHAI - iHRM] - Ping kiểm tra kết nối - " + Properties.Settings.Default.FP_soMay, "Tự động gửi mail để kiểm tra kết nối - Mất kết nối - " + DateTime.Now);
                            axCZKEM1_OnDisConnected();
                           frmDetectFingerPrint_Load(null, null);
                        }
                        else
                        {

                            SendMail("[THUANHAI - iHRM] - Ping kiểm tra kết nối - " + Properties.Settings.Default.FP_soMay, "Tự động gửi mail để kiểm tra kết nối - Kết nối bình thường - " + DateTime.Now);
                    
                           axCZKEM1.EnableDevice(1, true);

                            int soMay = 0;
                            soMay = Convert.ToInt32(Properties.Settings.Default.FP_soMay);

                            if ( ( soMay % 2 == 0) && (DateTime.Now.Hour == 5 && DateTime.Now.Minute == 0) ||
                                (DateTime.Now.Hour == 9 && DateTime.Now.Minute == 0) || (DateTime.Now.Hour == 15 && DateTime.Now.Minute == 30) || 
                                (DateTime.Now.Hour == 23 && DateTime.Now.Minute == 30))
                            {
                                downDuLieuChamCong();
                            }else
                            {
                                if ((soMay % 2 != 0) && (DateTime.Now.Hour == 5 && DateTime.Now.Minute == 5) ||
                                (DateTime.Now.Hour == 9 && DateTime.Now.Minute == 5) || (DateTime.Now.Hour == 15 && DateTime.Now.Minute == 35) ||
                                (DateTime.Now.Hour == 23 && DateTime.Now.Minute == 35))
                                {
                                    downDuLieuChamCong();
                                }
                                
                            }
                        }
                        break;
                    case "COM":
                        break;
                    case "USB":
                        break;
                }
            }
            catch { }
        }

        private void downDuLieuChamCong()
        {
            int soMay = 0;
            try
            {
                var a = Properties.Settings.Default.FPstrcnn.Trim().Split(';');
              
                //if (LAN_ping(a[1]))
                //{
                    soMay = Convert.ToInt32(Properties.Settings.Default.FP_soMay);

                    DateTime tuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(-1);
                    DateTime denNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);


                    var dt = ConvertListToDataTable(GetAttMachine(tuNgay, denNgay).ToList());

                    SqlParameter pa = new SqlParameter("dtInOutInfo", SqlDbType.Structured);
                    pa.TypeName = "dtInOutInFo";
                    pa.Value = dt;
                    Business.ADOController.ExeProcedure("p_push_fingerPrint_Auto", pa);
                //}

                    //MessageBox.Show("Tự động đẩy dữ liệu về thành công");
            }
            catch (Exception ex)
            {

                SendMail("[THUANHAI - iHRM] - Lỗi tự động tải vân tay về - "+ DateTime.Now + " - " + soMay, "Lỗi tự động tải dữ liệu về: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable ConvertListToDataTable(List<InOutInfor> _lInOutInfo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EnrollNumber",typeof(string));
            dt.Columns.Add("DatePunch",typeof(DateTime));
            dt.Columns.Add("DateTimePunch",typeof(DateTime));
            dt.Columns.Add("TimePunch", typeof(DateTime));
            dt.Columns.Add("timeClient", typeof(DateTime));
            dt.Columns.Add("somay", typeof(string));
            foreach (var item in _lInOutInfo)
            {
                DataRow r = dt.NewRow();
                r["EnrollNumber"] = item.EnrollNumber;
                r["DatePunch"] = item.DatePunch;
                r["DateTimePunch"] = item.DateTimePunch;
                r["TimePunch"] = item.TimePunch;
                r["timeClient"] = DateTime.Now;
                r["somay"] = Properties.Settings.Default.FP_soMay;
                dt.Rows.Add(r);
            }
            return dt;
        }
        public ICollection<InOutInfor> GetAttMachine(DateTime startDate, DateTime endDate)
        {

                startDate = startDate.Date;
                endDate = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                int iMachineNumber = 1;

                int idwVerifyMode = 0;
                string sdwEnrollNumber = "";
                int idwInOutMode = 0;
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                int idwWorkcode = 0;
                axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
                ICollection<InOutInfor> _lInOut = new List<InOutInfor>();
            try
            {
                
                if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                {
                    // Đây là hàm lấy dữ liệu quẹt thẻ SSR_GetGeneralLogData.
                    while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                               out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                    {
                        DateTime tgQuet = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                        if (startDate <= tgQuet && tgQuet <= endDate)
                        {
                            _lInOut.Add(new InOutInfor
                            {
                                EnrollNumber = sdwEnrollNumber,
                                DateTimePunch = tgQuet,
                                DatePunch = tgQuet.Date,
                                TimePunch = tgQuet
                            });
                        }
                    }
                }

                axCZKEM1.EnableDevice(iMachineNumber, true);// Enable máy chấm công lên
                return _lInOut;
            }
            catch (Exception ex)
            {
                axCZKEM1.EnableDevice(iMachineNumber, true);// Enable máy chấm công lên
                return _lInOut;
            }

        }

        public class InOutInfor
        {
            public string EnrollNumber { get; set; }
            public DateTime DatePunch { get; set; }
            public DateTime DateTimePunch { get; set; }
            public DateTime TimePunch { get; set; }
        }

        public static void SendMail(string Subject, string body)
        {
            try
            {

                string From = "ihrm@thuanhai.com.vn";
                string Pass = "iHRM2108";

                MailMessage msg = new MailMessage();
                msg.Body = body;
                string smtpServer = "mail.thuanhai.com.vn";// khai báo server web mail
                string userName = From; // user login web mail
                string password = Pass; // pass login web mail
                int cdoBasic = 1; // mở smtpauthenticate = 1
                int cdoSendUsingPort = 2; // mở SendUsingPort = 2
                if (userName.Length > 0)
                {
                    // mở kết nối với server web mail
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpServer);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", cdoSendUsingPort);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", cdoBasic);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", userName);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
                }
                msg.From = userName; // tên email gửi đi
                msg.To = "ihrm@thuanhai.com.vn"; // email nhận mail
                msg.Subject = Subject; // tiêu đề
                msg.BodyEncoding = System.Text.Encoding.UTF8; // fortmat lại nội dung email tránh lỗi font
                msg.BodyFormat = MailFormat.Text;
                SmtpMail.SmtpServer = smtpServer; // gán server web mail
                SmtpMail.Send(msg); // gửi mail
            }
            catch
            {
            }
        }
    }
}
