using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncSV
{
    public partial class frmConncetMCC : Form
    {
        public frmConncetMCC()
        {
            InitializeComponent();
        }
        public zkemkeeper.CZKEMClass axCZKEM1;
        public zkemkeeper.CZKEMClass axCZKEM2;
        public zkemkeeper.CZKEMClass axCZKEM3;
        public zkemkeeper.CZKEMClass axCZKEM4;
        public zkemkeeper.CZKEMClass axCZKEM5;

        DataTable dataMCC01 = Business.ADOController.ExeProcedure("p_mcc_getAll");
        DataTable dataMCC02 = Business.ADOController.ExeProcedure("p_mcc_getAll");
        DataTable dataMCC03 = Business.ADOController.ExeProcedure("p_mcc_getAll");
        DataTable dataMCC04 = Business.ADOController.ExeProcedure("p_mcc_getAll");
        DataTable dataMCC05 = Business.ADOController.ExeProcedure("p_mcc_getAll");

        private void frmConncetMCC_Load(object sender, EventArgs e)
        {
            //cboChonMCC01.Items.Add("Chọn máy chấm công");
            //cboChonMCC01.SelectedIndex = 0;

            //cboChonMCC01.DataSource = dataMCC01;
            //cboChonMCC01.DisplayMember = "tenMay";
            //cboChonMCC01.ValueMember = "id";

            //cboChonMCC02.DataSource = dataMCC02;
            //cboChonMCC02.DisplayMember = "tenMay";
            //cboChonMCC02.ValueMember = "id";


            //cboChonMCC03.DataSource = dataMCC03;
            //cboChonMCC03.DisplayMember = "tenMay";
            //cboChonMCC03.ValueMember = "id";


            //cboChonMCC04.DataSource = dataMCC04;
            //cboChonMCC04.DisplayMember = "tenMay";
            //cboChonMCC04.ValueMember = "id";

            //cboChonMCC05.DataSource = dataMCC05;
            //cboChonMCC05.DisplayMember = "tenMay";
            //cboChonMCC05.ValueMember = "id";
        }

        // KIỂM TRA IP có ping được không
        static bool LAN_ping(string add)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply rep = p.Send(add);
            return (rep.Status == System.Net.NetworkInformation.IPStatus.Success);
        }

        public class InOutInfor
        {
            public string EnrollNumber { get; set; }
            public DateTime DatePunch { get; set; }
            public DateTime DateTimePunch { get; set; }
            public DateTime TimePunch { get; set; }
        }

        private void btnTestNet01_Click(object sender, EventArgs e)
        {

           if(LAN_ping(txtIP01.Text.Trim()))
           {
               //concet thành công             
               MessageBox.Show("CÓ thể kết nối với máy chấm công " + txtIP01.Text.Trim(), "Thông báo");
           }
            else
           {
               //kết nối không thành công              
               MessageBox.Show("KHÔNG thể kết nối với máy chấm công " + txtIP01.Text.Trim(), "Thông báo");
           }
        }

        private void btnTestNet02_Click(object sender, EventArgs e)
        {
            if (LAN_ping(txtIP02.Text.Trim()))
            {         
                //concet thành công               
                MessageBox.Show("CÓ thể kết nối với máy chấm công " + txtIP02.Text.Trim(), "Thông báo");
            }
            else
            {
                //kết nối không thành công              
                MessageBox.Show("KHÔNG thể kết nối với máy chấm công " + txtIP02.Text.Trim(), "Thông báo");
            }
        }

        private void btnTestNet03_Click(object sender, EventArgs e)
        {
            if (LAN_ping(txtIP03.Text.Trim()))
            {
                //concet thành công             
                MessageBox.Show("CÓ thể kết nối với máy chấm công " + txtIP03.Text.Trim(), "Thông báo");
            }
            else
            {
                //kết nối không thành công              
                MessageBox.Show("KHÔNG thể kết nối với máy chấm công " + txtIP03.Text.Trim(), "Thông báo");
            }
        }

        private void btnTestNet04_Click(object sender, EventArgs e)
        {
            if (LAN_ping(txtIP04.Text.Trim()))
            {
                //concet thành công             
                MessageBox.Show("CÓ thể kết nối với máy chấm công " + txtIP04.Text.Trim(), "Thông báo");
            }
            else
            {
                //kết nối không thành công              
                MessageBox.Show("KHÔNG thể kết nối với máy chấm công " + txtIP04.Text.Trim(), "Thông báo");
            }
        }

        private void btnTestNet05_Click(object sender, EventArgs e)
        {
            if (LAN_ping(txtIP05.Text.Trim()))
            {
                //concet thành công             
                MessageBox.Show("CÓ thể kết nối với máy chấm công " + txtIP05.Text.Trim(), "Thông báo");
            }
            else
            {
                //kết nối không thành công              
                MessageBox.Show("KHÔNG thể kết nối với máy chấm công " + txtIP05.Text.Trim(), "Thông báo");
            }
        }

        #region Hàm sử lý máy chấm công
        // máy 001
        private void axCZKEM1_OnConnected01()
        {           
            lblMaNV01.Text = "-";
            lblTenNV01.Text = "-";
            lblTGQuet01.Text = "-";
        }
        private void axCZKEM1_OnFinger01()
        {
            MessageBox.Show("Test");
        }
        void axCZKEM1_OnVerify01(int UserID)
        {
            if (UserID == -1)
            {
                lblMaNV01.Text = "";
                lblTenNV01.Text = "Không có dữ liệu về NV này!";
                lblTenNV01.ForeColor = Color.Red;
            }
        }
        void axCZKEM1_OnAttTransaction01(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
        }
        private void axCZKEM1_OnDisConnected01()
        {          
            lblStatus01.Text = "Mất kết nối";
            lblStatus01.ForeColor = Color.Red;
        }
        void axCZKEM1_OnAttTransactionEx01(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            try
            {
                var time = new DateTime(Year, Month, Day, Hour, Minute, Second);
                var r = Business.ADOController.ExeProcedure("p_push_fingerPrint",
                    new System.Data.SqlClient.SqlParameter("ma_cc", EnrollNumber),
                    new System.Data.SqlClient.SqlParameter("somay", soMay01),
                    new System.Data.SqlClient.SqlParameter("time", time),
                    new System.Data.SqlClient.SqlParameter("timeClient", DateTime.Now)

                );
                lblMaNV01.Text = r.Rows.Count == 0 ? "-" : r.Rows[0]["maChamCong"].ToString();
                lblTenNV01.Text = r.Rows.Count == 0 ? "Nhân viên chưa được khai báo trên phần mềm!" : r.Rows[0]["tenChamCong"] as string;
                lblTenNV01.ForeColor = Color.Black;
                lblTGQuet01.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", time);
            }
            catch (Exception ex)
            {
                lblTenNV01.Text = ex.Message;
                lblTenNV01.ForeColor = Color.Red;
                lblMaNV01.Text = "-";
                lblTGQuet01.Text = "-";
            }
        }
        
        // máy 002
        private void axCZKEM1_OnConnected02()
        {
            lblMaNV02.Text = "-";
            lblTenNV02.Text = "-";
            lblTGQuet02.Text = "-";
        }
        private void axCZKEM1_OnFinger02()
        {
            MessageBox.Show("Test");
        }
        void axCZKEM1_OnVerify02(int UserID)
        {
            if (UserID == -1)
            {
                lblMaNV02.Text = "";
                lblTenNV02.Text = "Không có dữ liệu về NV này!";
                lblTenNV02.ForeColor = Color.Red;

                //label4.Text = "-";
            }
        }
        void axCZKEM1_OnAttTransaction02(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
        }
        private void axCZKEM1_OnDisConnected02()
        {
            lblStatus02.Text = "Mất kết nối";
            lblStatus02.ForeColor = Color.Red;
        }
        void axCZKEM1_OnAttTransactionEx02(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            try
            {
                var time = new DateTime(Year, Month, Day, Hour, Minute, Second);
                var r = Business.ADOController.ExeProcedure("p_push_fingerPrint",
                    new System.Data.SqlClient.SqlParameter("ma_cc", EnrollNumber),
                    new System.Data.SqlClient.SqlParameter("somay", soMay02),
                    new System.Data.SqlClient.SqlParameter("time", time),
                    new System.Data.SqlClient.SqlParameter("timeClient", DateTime.Now)

                );
                lblMaNV02.Text = r.Rows.Count == 0 ? "-" : r.Rows[0]["maChamCong"].ToString();
                lblTenNV02.Text = r.Rows.Count == 0 ? "Nhân viên chưa được khai báo trên phần mềm!" : r.Rows[0]["tenChamCong"] as string;
                lblTenNV02.ForeColor = Color.Black;
                lblTGQuet02.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", time);
            }
            catch (Exception ex)
            {
                lblTenNV02.Text = ex.Message;
                lblTenNV02.ForeColor = Color.Red;
                lblMaNV02.Text = "-";
                lblTGQuet02.Text = "-";
            }
        }

        // máy 003
        private void axCZKEM1_OnConnected03()
        {
            lblMaNV02.Text = "-";
            lblTenNV02.Text = "-";
            lblTGQuet02.Text = "-";
        }
        private void axCZKEM1_OnFinger03()
        {
            MessageBox.Show("Test");
        }
        void axCZKEM1_OnVerify03(int UserID)
        {
            if (UserID == -1)
            {
                lblMaNV03.Text = "";
                lblTenNV03.Text = "Không có dữ liệu về NV này!";
                lblTenNV03.ForeColor = Color.Red;

                //label4.Text = "-";
            }
        }
        void axCZKEM1_OnAttTransaction03(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
        }
        private void axCZKEM1_OnDisConnected03()
        {
            lblStatus03.Text = "Mất kết nối";
            lblStatus03.ForeColor = Color.Red;
        }
        void axCZKEM1_OnAttTransactionEx03(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            try
            {
                var time = new DateTime(Year, Month, Day, Hour, Minute, Second);
                var r = Business.ADOController.ExeProcedure("p_push_fingerPrint",
                    new System.Data.SqlClient.SqlParameter("ma_cc", EnrollNumber),
                    new System.Data.SqlClient.SqlParameter("somay", soMay03),
                    new System.Data.SqlClient.SqlParameter("time", time),
                    new System.Data.SqlClient.SqlParameter("timeClient", DateTime.Now)

                );
                lblMaNV03.Text = r.Rows.Count == 0 ? "-" : r.Rows[0]["maChamCong"].ToString();
                lblTenNV03.Text = r.Rows.Count == 0 ? "Nhân viên chưa được khai báo trên phần mềm!" : r.Rows[0]["tenChamCong"] as string;
                lblTenNV03.ForeColor = Color.Black;
                lblTGQuet03.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", time);
            }
            catch (Exception ex)
            {
                lblTenNV03.Text = ex.Message;
                lblTenNV03.ForeColor = Color.Red;
                lblMaNV03.Text = "-";
                lblTGQuet03.Text = "-";
            }
        }
        
        //Máy 004
        private void axCZKEM1_OnConnected04()
        {
            lblMaNV04.Text = "-";
            lblTenNV04.Text = "-";
            lblTGQuet04.Text = "-";
        }
        private void axCZKEM1_OnFinger04()
        {
            MessageBox.Show("Test");
        }
        void axCZKEM1_OnVerify04(int UserID)
        {
            if (UserID == -1)
            {
                lblMaNV04.Text = "";
                lblTenNV04.Text = "Không có dữ liệu về NV này!";
                lblTenNV04.ForeColor = Color.Red;

                //label4.Text = "-";
            }
        }
        void axCZKEM1_OnAttTransaction04(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
        }
        private void axCZKEM1_OnDisConnected04()
        {
            lblStatus04.Text = "Mất kết nối";
            lblStatus04.ForeColor = Color.Red;
        }
        void axCZKEM1_OnAttTransactionEx04(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            try
            {
                var time = new DateTime(Year, Month, Day, Hour, Minute, Second);
                var r = Business.ADOController.ExeProcedure("p_push_fingerPrint",
                    new System.Data.SqlClient.SqlParameter("ma_cc", EnrollNumber),
                    new System.Data.SqlClient.SqlParameter("somay", soMay04),
                    new System.Data.SqlClient.SqlParameter("time", time),
                    new System.Data.SqlClient.SqlParameter("timeClient", DateTime.Now)

                );
                lblMaNV04.Text = r.Rows.Count == 0 ? "-" : r.Rows[0]["maChamCong"].ToString();
                lblTenNV04.Text = r.Rows.Count == 0 ? "Nhân viên chưa được khai báo trên phần mềm!" : r.Rows[0]["tenChamCong"] as string;
                lblTenNV04.ForeColor = Color.Black;
                lblTGQuet04.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", time);
            }
            catch (Exception ex)
            {
                lblTenNV04.Text = ex.Message;
                lblTenNV04.ForeColor = Color.Red;
                lblMaNV04.Text = "-";
                lblTGQuet04.Text = "-";
            }
        }
        
        //máy 005
        private void axCZKEM1_OnConnected05()
        {
            lblMaNV05.Text = "-";
            lblTenNV05.Text = "-";
            lblTGQuet05.Text = "-";
        }
        private void axCZKEM1_OnFinger05()
        {
            MessageBox.Show("Test");
        }
        void axCZKEM1_OnVerify05(int UserID)
        {
            if (UserID == -1)
            {
                lblMaNV05.Text = "";
                lblTenNV05.Text = "Không có dữ liệu về NV này!";
                lblTenNV05.ForeColor = Color.Red;

                
            }
        }
        void axCZKEM1_OnAttTransaction05(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
        }
        private void axCZKEM1_OnDisConnected05()
        {
            lblStatus05.Text = "Mất kết nối";
            lblStatus05.ForeColor = Color.Red;
        }
        void axCZKEM1_OnAttTransactionEx05(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            try
            {
                var time = new DateTime(Year, Month, Day, Hour, Minute, Second);
                var r = Business.ADOController.ExeProcedure("p_push_fingerPrint",
                    new System.Data.SqlClient.SqlParameter("ma_cc", EnrollNumber),
                    new System.Data.SqlClient.SqlParameter("somay", soMay05),
                    new System.Data.SqlClient.SqlParameter("time", time),
                    new System.Data.SqlClient.SqlParameter("timeClient", DateTime.Now)

                );
                lblMaNV05.Text = r.Rows.Count == 0 ? "-" : r.Rows[0]["maChamCong"].ToString();
                lblTenNV05.Text = r.Rows.Count == 0 ? "Nhân viên chưa được khai báo trên phần mềm!" : r.Rows[0]["tenChamCong"] as string;
                lblTenNV05.ForeColor = Color.Black;
                lblTGQuet05.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", time);
            }
            catch (Exception ex)
            {
                lblTenNV05.Text = ex.Message;
                lblTenNV05.ForeColor = Color.Red;
                lblMaNV05.Text = "-";
                lblTGQuet05.Text = "-";
            }
        }
        #endregion

        #region Khu vực gọi hàm get dữ liệu theo máy
        public void RunMCC01()
        {
            axCZKEM1 = new zkemkeeper.CZKEMClass();
            axCZKEM1.OnConnected += axCZKEM1_OnConnected01;
            axCZKEM1.OnDisConnected += axCZKEM1_OnDisConnected01;

            try
            {
                var isCOnnected = false;

                isCOnnected = axCZKEM1.Connect_Net(txtIP01.Text.Trim(), Convert.ToInt32(txtPort01.Text.Trim()));

                if (isCOnnected)
                {
                    axCZKEM1.EnableDevice(1, true);
                    if (axCZKEM1.RegEvent(1, 32767))
                    {
                        axCZKEM1.OnVerify += axCZKEM1_OnVerify01;
                        axCZKEM1.OnAttTransaction += new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction01);
                        axCZKEM1.OnAttTransactionEx += axCZKEM1_OnAttTransactionEx01;
                    }

                    lblStatus01.Text = "Đang kết nối";
                    lblStatus01.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kết nối máy chấm công 01 không thành công");
            }

            timerMCC01.Start();
        }
      
        public void RunMCC02()
        {
            axCZKEM2 = new zkemkeeper.CZKEMClass();
            axCZKEM2.OnConnected += axCZKEM1_OnConnected02;
            axCZKEM2.OnDisConnected += axCZKEM1_OnDisConnected02;

            try
            {
                var isCOnnected = false;
               
                isCOnnected = axCZKEM2.Connect_Net(txtIP02.Text.Trim(), Convert.ToInt32(txtPort02.Text.Trim()));
                      
                if (isCOnnected)
                {
                    axCZKEM2.EnableDevice(1, true);
                    if (axCZKEM2.RegEvent(1, 32767))
                    {
                        axCZKEM2.OnVerify += axCZKEM1_OnVerify02;
                        axCZKEM2.OnAttTransaction += new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction02);
                        axCZKEM2.OnAttTransactionEx += axCZKEM1_OnAttTransactionEx02;
                    }
                    lblStatus02.Text = "Đang kết nối";
                    lblStatus02.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kết nối máy chấm công 02 không thành công");
            }

            timerMCC02.Start();
        }

        public void RunMCC03()
        {
            axCZKEM3 = new zkemkeeper.CZKEMClass();
            axCZKEM3.OnConnected += axCZKEM1_OnConnected03;
            axCZKEM3.OnDisConnected += axCZKEM1_OnDisConnected03;

            try
            {
                var isCOnnected = false;

                isCOnnected = axCZKEM3.Connect_Net(txtIP03.Text.Trim(), Convert.ToInt32(txtPort03.Text.Trim()));

                if (isCOnnected)
                {
                    axCZKEM3.EnableDevice(1, true);
                    if (axCZKEM3.RegEvent(1, 32767))
                    {
                        axCZKEM3.OnVerify += axCZKEM1_OnVerify03;
                        axCZKEM3.OnAttTransaction += new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction03);
                        axCZKEM3.OnAttTransactionEx += axCZKEM1_OnAttTransactionEx03;
                    }
                    lblStatus03.Text = "Đang kết nối";
                    lblStatus03.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kết nối máy chấm công 03 không thành công");
            }

            timerMCC03.Start();
        }
        public void RunMCC04()
        {
            axCZKEM4 = new zkemkeeper.CZKEMClass();
            axCZKEM4.OnConnected += axCZKEM1_OnConnected04;
            axCZKEM4.OnDisConnected += axCZKEM1_OnDisConnected01;

            try
            {
                var isCOnnected = false;

                isCOnnected = axCZKEM4.Connect_Net(txtIP04.Text.Trim(), Convert.ToInt32(txtPort04.Text.Trim()));

                if (isCOnnected)
                {
                    axCZKEM4.EnableDevice(1, true);
                    if (axCZKEM4.RegEvent(1, 32767))
                    {
                        axCZKEM4.OnVerify += axCZKEM1_OnVerify01;
                        axCZKEM4.OnAttTransaction += new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction01);
                        axCZKEM4.OnAttTransactionEx += axCZKEM1_OnAttTransactionEx01;
                    }
                    lblStatus04.Text = "Đang kết nối";
                    lblStatus04.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kết nối máy chấm công 04 không thành công");
            }

            timerMCC04.Start();
        }
        public void RunMCC05()
        {
            axCZKEM5 = new zkemkeeper.CZKEMClass();
            axCZKEM5.OnConnected += axCZKEM1_OnConnected05;
            axCZKEM5.OnDisConnected += axCZKEM1_OnDisConnected05;

            try
            {
                var isCOnnected = false;

                isCOnnected = axCZKEM5.Connect_Net(txtIP05.Text.Trim(), Convert.ToInt32(txtPort05.Text.Trim()));
                       
                if (isCOnnected)
                {
                    axCZKEM5.EnableDevice(1, true);
                    if (axCZKEM5.RegEvent(1, 32767))
                    {
                        axCZKEM5.OnVerify += axCZKEM1_OnVerify05;
                        axCZKEM5.OnAttTransaction += new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction05);
                        axCZKEM5.OnAttTransactionEx += axCZKEM1_OnAttTransactionEx05;
                    }
                    lblStatus05.Text = "Đang kết nối";
                    lblStatus05.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kết nối máy chấm công 05 không thành công");
            }

            timerMCC05.Start();
        }
        #endregion

        #region Timer chạy
        private void timerMCC01_Tick(object sender, EventArgs e)
        {

            try
            {
                if (!LAN_ping(txtIP01.Text.Trim()))
                {
                    axCZKEM1_OnDisConnected01();
                    RunMCC01();
                }
                else
                {
                    axCZKEM1.EnableDevice(1, true);
                }
            }
            catch { }
        }

        private void timerMCC02_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!LAN_ping(txtIP02.Text.Trim()))
                {
                    axCZKEM1_OnDisConnected02();
                    RunMCC02();
                }
                else
                {
                    axCZKEM2.EnableDevice(1, true);
                }
            }
            catch { }
        }

        private void timerMCC03_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!LAN_ping(txtIP03.Text.Trim()))
                {
                    axCZKEM1_OnDisConnected03();
                    RunMCC03();
                }
                else
                {
                    axCZKEM3.EnableDevice(1, true);
                }
            }
            catch { }
        }

        private void timerMCC04_Tick(object sender, EventArgs e)
        {
            try
            {

                if (!LAN_ping(txtIP04.Text.Trim()))
                {
                    axCZKEM1_OnDisConnected04();
                    RunMCC04();
                }
                else
                {
                    axCZKEM4.EnableDevice(1, true);
                 
                }
                       
            }
            catch { }
        }

        private void timerMCC05_Tick(object sender, EventArgs e)
        {
            try
            {

                if (!LAN_ping(txtIP05.Text.Trim()))
                {
                    axCZKEM1_OnDisConnected05();
                    RunMCC05();
                }
                else
                {
                    axCZKEM5.EnableDevice(1, true);
                }
                       
            }
            catch { }
        }
        #endregion

        private void btnConnect01_Click(object sender, EventArgs e)
        {
           if(btnConnect01.Text=="Kết nối")
           {

               RunMCC01();
               btnConnect01.Text = "Ngắt kết nối";

               cboChonMCC01.Enabled = false;
               txtIP01.Enabled = false;
               txtPort01.Enabled = false;
               btnTestNet01.Enabled = false;

           }
            else
           {
               //ngắt kết nối
               axCZKEM1.Disconnect();
               btnConnect01.Text = "Kết nối";

               lblStatus01.Text = "Chưa kết nối";
               lblStatus01.ForeColor = Color.Red;

               cboChonMCC01.Enabled = true;
               txtIP01.Enabled = true;
               txtPort01.Enabled = true;
               btnTestNet01.Enabled = true;

               timerMCC01.Stop();
           }
        }

        private void btnConnect02_Click(object sender, EventArgs e)
        {
            if (btnConnect02.Text == "Kết nối")
            {

                RunMCC02();
                btnConnect02.Text = "Ngắt kết nối";

                cboChonMCC02.Enabled = false;
                txtIP02.Enabled = false;
                txtPort02.Enabled = false;
                btnTestNet02.Enabled = false;

            }
            else
            {
                //ngắt kết nối
                axCZKEM2.Disconnect();
                btnConnect02.Text = "Kết nối";

                lblStatus02.Text = "Chưa kết nối";
                lblStatus02.ForeColor = Color.Red;

                cboChonMCC02.Enabled = true;
                txtIP02.Enabled = true;
                txtPort02.Enabled = true;
                btnTestNet02.Enabled = true;

                timerMCC02.Stop();
            }
        }

        private void btnConnect03_Click(object sender, EventArgs e)
        {
            if (btnConnect03.Text == "Kết nối")
            {

                RunMCC03();
                btnConnect03.Text = "Ngắt kết nối";

                cboChonMCC03.Enabled = false;
                txtIP03.Enabled = false;
                txtPort03.Enabled = false;
                btnTestNet03.Enabled = false;
            }
            else
            {
                //ngắt kết nối
                axCZKEM3.Disconnect();
                btnConnect03.Text = "Kết nối";

                lblStatus03.Text = "Chưa kết nối";
                lblStatus03.ForeColor = Color.Red;

                cboChonMCC03.Enabled = true;
                txtIP03.Enabled = true;
                txtPort03.Enabled = true;
                btnTestNet03.Enabled = true;

                timerMCC03.Stop();
            }
        }

        private void btnConnect04_Click(object sender, EventArgs e)
        {
            if (btnConnect04.Text == "Kết nối")
            {

                RunMCC04();
                btnConnect04.Text = "Ngắt kết nối";

                cboChonMCC04.Enabled = false;
                txtIP04.Enabled = false;
                txtPort04.Enabled = false;
                btnTestNet04.Enabled = false;
            }
            else
            {
                //ngắt kết nối
                axCZKEM4.Disconnect();
                btnConnect04.Text = "Kết nối";

                lblStatus04.Text = "Chưa kết nối";
                lblStatus04.ForeColor = Color.Red;

                cboChonMCC04.Enabled = true;
                txtIP04.Enabled = true;
                txtPort04.Enabled = true;
                btnTestNet04.Enabled = true;

                timerMCC04.Stop();
            }
        }

        private void btnConnect05_Click(object sender, EventArgs e)
        {
            if (btnConnect05.Text == "Kết nối")
            {

                RunMCC05();
                btnConnect05.Text = "Ngắt kết nối";

                cboChonMCC05.Enabled = false;
                txtIP05.Enabled = false;
                txtPort05.Enabled = false;
                btnTestNet05.Enabled = false;
            }
            else
            {
                //ngắt kết nối
                axCZKEM5.Disconnect();
                btnConnect05.Text = "Kết nối";

                lblStatus05.Text = "Chưa kết nối";
                lblStatus05.ForeColor = Color.Red;

                cboChonMCC05.Enabled = true;
                txtIP05.Enabled = true;
                txtPort05.Enabled = true;
                btnTestNet05.Enabled = true;

                timerMCC05.Stop();
            }
        }

        #region  combobox select
        // khắc phục số mày vl 
        int soMay01,soMay02,soMay03,soMay04,soMay05;
        private void cboChonMCC01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChonMCC01.SelectedIndex >= 0 && cboChonMCC01.DataSource!=null)
            {                
                DataRow[] dr = dataMCC01.Select("id = '" + cboChonMCC01.SelectedValue.ToString() + "'");
                if (dr.Count() > 0)
                {
                    txtIP01.Text = dr[0]["diaChiIP"].ToString();
                    txtPort01.Text = dr[0]["port"].ToString();
                    soMay01 = Convert.ToInt32(dr[0]["soMay"].ToString());
                }
            }
           
        }

        private void cboChonMCC02_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChonMCC02.SelectedIndex >= 0 && cboChonMCC02.DataSource!=null)
            {

                DataRow[] dr = dataMCC02.Select("id = '" + cboChonMCC02.SelectedValue.ToString() + "'");
                if (dr.Count() > 0)
                {
                    txtIP02.Text = dr[0]["diaChiIP"].ToString();
                    txtPort02.Text = dr[0]["port"].ToString();
                    soMay02 = Convert.ToInt32(dr[0]["soMay"].ToString());
                }
            }
        }

        private void cboChonMCC03_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChonMCC03.SelectedIndex >= 0 && cboChonMCC03.DataSource != null)
            {
                DataRow[] dr = dataMCC03.Select("id = '" + cboChonMCC03.SelectedValue.ToString() + "'");
                if (dr.Count() > 0)
                {
                    txtIP03.Text = dr[0]["diaChiIP"].ToString();
                    txtPort03.Text = dr[0]["port"].ToString();
                    soMay03 = Convert.ToInt32(dr[0]["soMay"].ToString());
                }
            }
        }

        private void cboChonMCC04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChonMCC04.SelectedIndex >= 0 && cboChonMCC04.DataSource != null)
            {
                DataRow[] dr = dataMCC04.Select("id = '" + cboChonMCC04.SelectedValue.ToString() + "'");
                if (dr.Count() > 0)
                {
                    txtIP04.Text = dr[0]["diaChiIP"].ToString();
                    txtPort04.Text = dr[0]["port"].ToString();
                    soMay04 = Convert.ToInt32(dr[0]["soMay"].ToString());
                }
            }
        }

        private void cboChonMCC05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChonMCC05.SelectedIndex >= 0 && cboChonMCC05.DataSource != null)
            {
                DataRow[] dr = dataMCC05.Select("id = '" + cboChonMCC05.SelectedValue.ToString() + "'");
                if (dr.Count() > 0)
                {
                    txtIP05.Text = dr[0]["diaChiIP"].ToString();
                    txtPort05.Text = dr[0]["port"].ToString();
                    soMay05 = Convert.ToInt32(dr[0]["soMay"].ToString());
                }
            }
        }
        #endregion

        private void cboChonMCC01_MouseClick(object sender, MouseEventArgs e)
        {
            cboChonMCC01.DataSource = dataMCC01;
            cboChonMCC01.DisplayMember = "tenMay";
            cboChonMCC01.ValueMember = "id";
        }

        private void cboChonMCC02_MouseClick(object sender, MouseEventArgs e)
        {
            cboChonMCC02.DataSource = dataMCC02;
            cboChonMCC02.DisplayMember = "tenMay";
            cboChonMCC02.ValueMember = "id";
        }

        private void cboChonMCC03_MouseClick(object sender, MouseEventArgs e)
        {
            cboChonMCC03.DataSource = dataMCC03;
            cboChonMCC03.DisplayMember = "tenMay";
            cboChonMCC03.ValueMember = "id";
        }

        private void cboChonMCC04_MouseClick(object sender, MouseEventArgs e)
        {
            cboChonMCC04.DataSource = dataMCC04;
            cboChonMCC04.DisplayMember = "tenMay";
            cboChonMCC04.ValueMember = "id";
        }

        private void cboChonMCC05_MouseClick(object sender, MouseEventArgs e)
        {
            cboChonMCC05.DataSource = dataMCC05;
            cboChonMCC05.DisplayMember = "tenMay";
            cboChonMCC05.ValueMember = "id";
        }

    }
}
