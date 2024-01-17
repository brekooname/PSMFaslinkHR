using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Configuration;
using SyncSV.Cls;
using SyncSV.Business;
using Microsoft.Win32;

namespace SyncSV.Frm.Common
{
    public partial class frmConnectFingerPrint : System.Windows.Forms.Form
    {
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        DevExpress.XtraWizard.WizardButton customButton;

        public frmConnectFingerPrint()
        {
            InitializeComponent();
        }
        private void main_Load(object sender, EventArgs e)
        {
            customButton = new DevExpress.XtraWizard.WizardButton(WizardControl1);
            customButton.Visible = false;

            setcauhinhstring(Properties.Settings.Default.FPstrcnn);
            axCZKEM1.OnConnected += axCZKEM1_OnConnected;
        }

        #region sub

        public bool SearchforCom(ref string sCom)//modify by Darcy on Nov.26 2009
        {
            string sComValue;
            string sTmpara;
            RegistryKey myReg = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
            string[] sComNames = myReg.GetValueNames();//strings array composed of the key name holded by the subkey "SERIALCOMM"
            for (int i = 0; i < sComNames.Length; i++)
            {
                sComValue = "";
                sComValue = myReg.GetValue(sComNames[i]).ToString();//obtain the key value of the corresponding key name
                if (sComValue == "")
                {
                    continue;
                }

                sCom = "";
                if (sComNames[i] == "\\Device\\USBSER000")//find the virtual serial port created by usbclient
                {
                    for (int j = 0; j <= 10; j++)
                    {
                        sTmpara = "";
                        RegistryKey myReg2 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\USB\VID_1B55&PID_B400\" + j.ToString() + @"\Device Parameters");//find the plug and play USB device
                        if (myReg2 != null)//add by Darcy on Nov.26 2009
                        {
                            sTmpara = myReg2.GetValue("PortName").ToString();

                            if (sComValue == sTmpara)
                            {
                                sCom = sTmpara;
                                return true;//add by Darcy on Nov.26 2009
                            }
                        }
                    }
                }
            }
            return false;//add by Darcy on Nov.26 2009
        }
        #endregion

        #region form event

        private void wizardControl1_CustomizeCommandButtons(object sender, DevExpress.XtraWizard.CustomizeCommandButtonsEventArgs e)
        {
            e.FinishButton.Visible = false;
            if (e.Page is DevExpress.XtraWizard.CompletionWizardPage)
            {
                customButton.Location = new Point(e.FinishButton.Location.X, e.PrevButton.Location.Y);
                customButton.Visible = true;
                customButton.Enabled = false;
            }
            else
                customButton.Visible = false;
        }

        private void btnInstallAsServer_Click(object sender, EventArgs e)
        {
            chkLAN.Checked = false;
            chkCOM.Checked = true;
            chkUSB.Checked = false;
        }
        private void btnInstallAsClient_Click(object sender, EventArgs e)
        {
            chkLAN.Checked = false;
            chkCOM.Checked = false;
            chkUSB.Checked = true;
        }
        private void btnInstallByLAN_Click(object sender, EventArgs e)
        {
            chkLAN.Checked = true;
            chkCOM.Checked = false;
            chkUSB.Checked = false;
        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == page1)
            {
                if (!chkCOM.Checked && !chkUSB.Checked && !chkLAN.Checked)
                {
                    GUIHelper.MessageError("Xin vui lòng chọn phương thức cài đặt");
                    e.Handled = true;
                }
                if (chkLAN.Checked)
                    WizardControl1.SelectedPage = page2;
                if (chkCOM.Checked)
                    WizardControl1.SelectedPage = page3;
                else if (chkUSB.Checked)
                    WizardControl1.SelectedPage = page4;
            }
            if (e.Page == page2 || e.Page == page3 || e.Page == page4)
            {
                WizardControl1.SelectedPage = page5;
            }

            e.Handled = true;
        }

        private void WizardControl1_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            WizardControl1.SelectedPage = page1;
            e.Handled = true;
        }

        private void WizardControl1_SelectedPageChanged(object sender, DevExpress.XtraWizard.WizardPageChangedEventArgs e)
        {
        }

        private void btnTestLANConnect_Click(object sender, EventArgs e)
        {

            if (txtIP.Text.Trim() == "" || txtPort.Text.Trim() == "")
            {
                MessageBox.Show("IP and Port cannot be null", "Error");
                return;
            }

            Cursor = Cursors.WaitCursor;
            bool bIsConnected = axCZKEM1.Connect_Net(txtIP.Text, Convert.ToInt32(txtPort.Text));
            if (bIsConnected == true)
            {
                saveConnection();
                MessageBox.Show("Connect success");
            }
            else
            {
                int idwErrorCode = 0;
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device, ErrorCode = " + idwErrorCode.ToString(), "Error");
            }
            Cursor = Cursors.Default;
        }

        private void btnTestCOMconnect_Click(object sender, EventArgs e)
        {
            if (cbCOMport.Text.Trim() == "" || cbBaudRate.Text.Trim() == "" || txtMachineSN.Text.Trim() == "")
            {
                MessageBox.Show("Port, BaudRate and MachineSN cannot be null", "Error");
                return;
            }

            Cursor = Cursors.WaitCursor;

            //accept serialport number from string like "COMi"
            int iMachineNumber = Convert.ToInt32(txtMachineSN.Text.Trim());//when you are using the serial port communication,you can distinguish different devices by their serial port number.
            bool bIsConnected = axCZKEM1.Connect_Com(int.Parse(cbCOMport.Text.Trim().Replace("COM", "")), iMachineNumber, Convert.ToInt32(cbBaudRate.Text.Trim()));
            if (bIsConnected == true)
            {
                MessageBox.Show("Connect success");
            }
            else
            {
                int idwErrorCode = 0;
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device, ErrorCode = " + idwErrorCode.ToString(), "Error");
            }

            Cursor = Cursors.Default;
        }

        private void btnTestUSBconnect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            bool bIsConnected = false;
            int iMachineNumber;

            if (rbUSB.Checked == true)//the common USBClient
            {
                iMachineNumber = 1; //In fact,when you are using common USBClient communication,parameter Machinenumber will be ignored,that is any integer will all right.Here we use 1.
                bIsConnected = axCZKEM1.Connect_USB(iMachineNumber);
            }
            else if (rbVUSB.Checked == true)//connect the device via the virtual serial port created by USB
            {
                string sCom = "";
                bool bSearch = SearchforCom(ref sCom);//modify by Darcy on Nov.26 2009
                if (bSearch == false)//modify by Darcy on Nov.26 2009
                {
                    MessageBox.Show("Can not find the virtual serial port that can be used", "Error");
                    Cursor = Cursors.Default;
                    return;
                }

                int iPort;
                for (iPort = 1; iPort < 10; iPort++)
                {
                    if (sCom.IndexOf(iPort.ToString()) > -1)
                    {
                        break;
                    }
                }

                iMachineNumber = Convert.ToInt32(txtMachineSN2.Text.Trim());
                if (iMachineNumber == 0 || iMachineNumber > 255)
                {
                    MessageBox.Show("The Machine Number is invalid!", "Error");
                    Cursor = Cursors.Default;
                    return;
                }

                int iBaudRate = 115200;//115200 is one possible baudrate value(its value cannot be 0)
                bIsConnected = axCZKEM1.Connect_Com(iPort, iMachineNumber, iBaudRate);
            }

            if (bIsConnected == true)
            {
                MessageBox.Show("Connect success");
            }
            else
            {
                int idwErrorCode = 0;
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }

            Cursor = Cursors.Default;
        }

        #endregion

        void axCZKEM1_OnConnected()
        {
            if (axCZKEM1.RegEvent(1, 65535))
                axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
        }
        void axCZKEM1_OnFinger()
        {
            saveConnection();
            this.Close();
        }

        void saveConnection()
        {
            Properties.Settings.Default.FPstrcnn = getcauhinhstring();
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// lấy thông tin cấu hình bởi 1 dòng
        /// </summary>
        /// <returns></returns>
        string getcauhinhstring()
        {
            if (chkLAN.Checked)
            {
                return string.Format("LAN;{0};{1}", txtIP.Text, txtPort.Text);
            }
            else if (chkCOM.Checked)
            {
                return string.Format("COM;{0};{1};{2}", int.Parse(cbCOMport.Text.Trim().Replace("COM", "")), Convert.ToInt32(txtMachineSN.Text.Trim()), Convert.ToInt32(cbBaudRate.Text.Trim()));
            }
            else if (rbUSB.Checked)
            {
                return string.Format("USB;{0}", 1);
            }
            else if (rbVUSB.Checked == true)//connect the device via the virtual serial port created by USB
            {
                string sCom = "";
                bool bSearch = SearchforCom(ref sCom);//modify by Darcy on Nov.26 2009
                if (bSearch == false)//modify by Darcy on Nov.26 2009
                {
                    MessageBox.Show("Can not find the virtual serial port that can be used", "Error");
                    Cursor = Cursors.Default;
                }
                else
                {
                    int iPort;
                    for (iPort = 1; iPort < 10; iPort++)
                    {
                        if (sCom.IndexOf(iPort.ToString()) > -1)
                        {
                            break;
                        }
                    }

                    return string.Format("COM;{0};{1};{2}", iPort, Convert.ToInt32(txtMachineSN2.Text.Trim()), 115200);
                }
            }

            return "???;???";
        }
        void setcauhinhstring(string cauhinh)
        {
            if (string.IsNullOrWhiteSpace(cauhinh) || cauhinh.StartsWith("???"))
                return;

            try
            {
                string[] a = cauhinh.Split(';');
                if (a[0] == "LAN")
                {
                    chkLAN.Checked = true;
                    txtIP.Text = a[1];
                    txtPort.Text = a[2];
                }
                else if (a[0] == "COM")
                {
                    chkCOM.Checked = true;
                    cbCOMport.Text = "COM" + a[1];
                    txtMachineSN.Text = a[2];
                    cbBaudRate.Text = a[3];
                }
                else
                {
                    rbUSB.Checked = chkUSB.Checked = true;
                }
            }
            catch { }
        }
    }
}
