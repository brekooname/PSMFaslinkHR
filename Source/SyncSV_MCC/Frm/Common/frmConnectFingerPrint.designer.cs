namespace SyncSV.Frm.Common
{
    partial class frmConnectFingerPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnectFingerPrint));
            this.WizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.page2 = new DevExpress.XtraWizard.WizardPage();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.txtIP = new DevExpress.XtraEditors.TextEdit();
            this.btnTestLANConnect = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.page1 = new DevExpress.XtraWizard.WizardPage();
            this.chkUSB = new DevExpress.XtraEditors.CheckEdit();
            this.chkLAN = new DevExpress.XtraEditors.CheckEdit();
            this.chkCOM = new DevExpress.XtraEditors.CheckEdit();
            this.btnInstallAsClient = new System.Windows.Forms.Button();
            this.btnInstallByLAN = new System.Windows.Forms.Button();
            this.btnInstallAsServer = new System.Windows.Forms.Button();
            this.page4 = new DevExpress.XtraWizard.WizardPage();
            this.btnTestUSBconnect = new DevExpress.XtraEditors.SimpleButton();
            this.rbUSB = new System.Windows.Forms.RadioButton();
            this.rbVUSB = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMachineSN2 = new System.Windows.Forms.TextBox();
            this.page3 = new DevExpress.XtraWizard.WizardPage();
            this.btnTestCOMconnect = new DevExpress.XtraEditors.SimpleButton();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMachineSN = new System.Windows.Forms.TextBox();
            this.cbCOMport = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.page5 = new DevExpress.XtraWizard.WizardPage();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WizardControl1)).BeginInit();
            this.WizardControl1.SuspendLayout();
            this.page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).BeginInit();
            this.page1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUSB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCOM.Properties)).BeginInit();
            this.page4.SuspendLayout();
            this.page3.SuspendLayout();
            this.page5.SuspendLayout();
            this.SuspendLayout();
            // 
            // WizardControl1
            // 
            resources.ApplyResources(this.WizardControl1, "WizardControl1");
            this.WizardControl1.Controls.Add(this.page2);
            this.WizardControl1.Controls.Add(this.page1);
            this.WizardControl1.Controls.Add(this.page4);
            this.WizardControl1.Controls.Add(this.page3);
            this.WizardControl1.Controls.Add(this.page5);
            this.WizardControl1.Image = ((System.Drawing.Image)(resources.GetObject("WizardControl1.Image")));
            this.WizardControl1.Name = "WizardControl1";
            this.WizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.page1,
            this.page2,
            this.page3,
            this.page4,
            this.page5});
            this.WizardControl1.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            this.WizardControl1.SelectedPageChanged += new DevExpress.XtraWizard.WizardPageChangedEventHandler(this.WizardControl1_SelectedPageChanged);
            this.WizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            this.WizardControl1.PrevClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.WizardControl1_PrevClick);
            this.WizardControl1.CustomizeCommandButtons += new DevExpress.XtraWizard.WizardCustomizeCommandButtonsEventHandler(this.wizardControl1_CustomizeCommandButtons);
            // 
            // page2
            // 
            this.page2.Controls.Add(this.txtPort);
            this.page2.Controls.Add(this.txtIP);
            this.page2.Controls.Add(this.btnTestLANConnect);
            this.page2.Controls.Add(this.label2);
            this.page2.Controls.Add(this.label1);
            resources.ApplyResources(this.page2, "page2");
            this.page2.Name = "page2";
            // 
            // txtPort
            // 
            resources.ApplyResources(this.txtPort, "txtPort");
            this.txtPort.Name = "txtPort";
            this.txtPort.Properties.Mask.EditMask = resources.GetString("txtPort.Properties.Mask.EditMask");
            this.txtPort.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtPort.Properties.Mask.MaskType")));
            // 
            // txtIP
            // 
            resources.ApplyResources(this.txtIP, "txtIP");
            this.txtIP.Name = "txtIP";
            this.txtIP.Properties.Mask.EditMask = resources.GetString("txtIP.Properties.Mask.EditMask");
            this.txtIP.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtIP.Properties.Mask.MaskType")));
            // 
            // btnTestLANConnect
            // 
            resources.ApplyResources(this.btnTestLANConnect, "btnTestLANConnect");
            this.btnTestLANConnect.Name = "btnTestLANConnect";
            this.btnTestLANConnect.Click += new System.EventHandler(this.btnTestLANConnect_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // page1
            // 
            this.page1.Controls.Add(this.chkUSB);
            this.page1.Controls.Add(this.chkLAN);
            this.page1.Controls.Add(this.chkCOM);
            this.page1.Controls.Add(this.btnInstallAsClient);
            this.page1.Controls.Add(this.btnInstallByLAN);
            this.page1.Controls.Add(this.btnInstallAsServer);
            resources.ApplyResources(this.page1, "page1");
            this.page1.Name = "page1";
            // 
            // chkUSB
            // 
            resources.ApplyResources(this.chkUSB, "chkUSB");
            this.chkUSB.Name = "chkUSB";
            this.chkUSB.Properties.Caption = resources.GetString("chkUSB.Properties.Caption");
            // 
            // chkLAN
            // 
            resources.ApplyResources(this.chkLAN, "chkLAN");
            this.chkLAN.Name = "chkLAN";
            this.chkLAN.Properties.Caption = resources.GetString("chkLAN.Properties.Caption");
            // 
            // chkCOM
            // 
            resources.ApplyResources(this.chkCOM, "chkCOM");
            this.chkCOM.Name = "chkCOM";
            this.chkCOM.Properties.Caption = resources.GetString("chkCOM.Properties.Caption");
            // 
            // btnInstallAsClient
            // 
            resources.ApplyResources(this.btnInstallAsClient, "btnInstallAsClient");
            this.btnInstallAsClient.Name = "btnInstallAsClient";
            this.btnInstallAsClient.UseVisualStyleBackColor = true;
            this.btnInstallAsClient.Click += new System.EventHandler(this.btnInstallAsClient_Click);
            // 
            // btnInstallByLAN
            // 
            resources.ApplyResources(this.btnInstallByLAN, "btnInstallByLAN");
            this.btnInstallByLAN.Name = "btnInstallByLAN";
            this.btnInstallByLAN.UseVisualStyleBackColor = true;
            this.btnInstallByLAN.Click += new System.EventHandler(this.btnInstallByLAN_Click);
            // 
            // btnInstallAsServer
            // 
            resources.ApplyResources(this.btnInstallAsServer, "btnInstallAsServer");
            this.btnInstallAsServer.Name = "btnInstallAsServer";
            this.btnInstallAsServer.UseVisualStyleBackColor = true;
            this.btnInstallAsServer.Click += new System.EventHandler(this.btnInstallAsServer_Click);
            // 
            // page4
            // 
            this.page4.Controls.Add(this.btnTestUSBconnect);
            this.page4.Controls.Add(this.rbUSB);
            this.page4.Controls.Add(this.rbVUSB);
            this.page4.Controls.Add(this.label3);
            this.page4.Controls.Add(this.txtMachineSN2);
            this.page4.Name = "page4";
            resources.ApplyResources(this.page4, "page4");
            // 
            // btnTestUSBconnect
            // 
            resources.ApplyResources(this.btnTestUSBconnect, "btnTestUSBconnect");
            this.btnTestUSBconnect.Name = "btnTestUSBconnect";
            this.btnTestUSBconnect.Click += new System.EventHandler(this.btnTestUSBconnect_Click);
            // 
            // rbUSB
            // 
            resources.ApplyResources(this.rbUSB, "rbUSB");
            this.rbUSB.Name = "rbUSB";
            this.rbUSB.UseVisualStyleBackColor = true;
            // 
            // rbVUSB
            // 
            resources.ApplyResources(this.rbVUSB, "rbVUSB");
            this.rbVUSB.Checked = true;
            this.rbVUSB.Name = "rbVUSB";
            this.rbVUSB.TabStop = true;
            this.rbVUSB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtMachineSN2
            // 
            this.txtMachineSN2.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMachineSN2.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.txtMachineSN2, "txtMachineSN2");
            this.txtMachineSN2.Name = "txtMachineSN2";
            // 
            // page3
            // 
            this.page3.Controls.Add(this.btnTestCOMconnect);
            this.page3.Controls.Add(this.cbBaudRate);
            this.page3.Controls.Add(this.label5);
            this.page3.Controls.Add(this.txtMachineSN);
            this.page3.Controls.Add(this.cbCOMport);
            this.page3.Controls.Add(this.label7);
            this.page3.Controls.Add(this.label6);
            this.page3.Name = "page3";
            resources.ApplyResources(this.page3, "page3");
            // 
            // btnTestCOMconnect
            // 
            resources.ApplyResources(this.btnTestCOMconnect, "btnTestCOMconnect");
            this.btnTestCOMconnect.Name = "btnTestCOMconnect";
            this.btnTestCOMconnect.Click += new System.EventHandler(this.btnTestCOMconnect_Click);
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            resources.GetString("cbBaudRate.Items"),
            resources.GetString("cbBaudRate.Items1"),
            resources.GetString("cbBaudRate.Items2"),
            resources.GetString("cbBaudRate.Items3"),
            resources.GetString("cbBaudRate.Items4"),
            resources.GetString("cbBaudRate.Items5"),
            resources.GetString("cbBaudRate.Items6")});
            resources.ApplyResources(this.cbBaudRate, "cbBaudRate");
            this.cbBaudRate.Name = "cbBaudRate";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtMachineSN
            // 
            resources.ApplyResources(this.txtMachineSN, "txtMachineSN");
            this.txtMachineSN.Name = "txtMachineSN";
            // 
            // cbCOMport
            // 
            this.cbCOMport.FormattingEnabled = true;
            this.cbCOMport.Items.AddRange(new object[] {
            resources.GetString("cbCOMport.Items"),
            resources.GetString("cbCOMport.Items1"),
            resources.GetString("cbCOMport.Items2"),
            resources.GetString("cbCOMport.Items3"),
            resources.GetString("cbCOMport.Items4"),
            resources.GetString("cbCOMport.Items5"),
            resources.GetString("cbCOMport.Items6"),
            resources.GetString("cbCOMport.Items7"),
            resources.GetString("cbCOMport.Items8")});
            resources.ApplyResources(this.cbCOMport, "cbCOMport");
            this.cbCOMport.Name = "cbCOMport";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // page5
            // 
            this.page5.Controls.Add(this.label4);
            this.page5.Name = "page5";
            resources.ApplyResources(this.page5, "page5");
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // frmConnectFingerPrint
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WizardControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnectFingerPrint";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WizardControl1)).EndInit();
            this.WizardControl1.ResumeLayout(false);
            this.page2.ResumeLayout(false);
            this.page2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).EndInit();
            this.page1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkUSB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCOM.Properties)).EndInit();
            this.page4.ResumeLayout(false);
            this.page4.PerformLayout();
            this.page3.ResumeLayout(false);
            this.page3.PerformLayout();
            this.page5.ResumeLayout(false);
            this.page5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl WizardControl1;
        private DevExpress.XtraWizard.WizardPage page2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraWizard.WizardPage page1;
        private System.Windows.Forms.Button btnInstallAsClient;
        private System.Windows.Forms.Button btnInstallAsServer;
        private DevExpress.XtraEditors.CheckEdit chkUSB;
        private DevExpress.XtraEditors.CheckEdit chkCOM;
        private DevExpress.XtraEditors.SimpleButton btnTestLANConnect;
        private DevExpress.XtraEditors.CheckEdit chkLAN;
        private System.Windows.Forms.Button btnInstallByLAN;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.TextEdit txtIP;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraWizard.WizardPage page4;
        private DevExpress.XtraWizard.WizardPage page3;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMachineSN;
        private System.Windows.Forms.ComboBox cbCOMport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnTestCOMconnect;
        private DevExpress.XtraEditors.SimpleButton btnTestUSBconnect;
        private System.Windows.Forms.RadioButton rbUSB;
        private System.Windows.Forms.RadioButton rbVUSB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMachineSN2;
        private DevExpress.XtraWizard.WizardPage page5;
        private System.Windows.Forms.Label label4;
    }
}