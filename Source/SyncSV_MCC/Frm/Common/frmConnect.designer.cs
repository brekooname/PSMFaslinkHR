namespace SyncSV.Frm.Common
{
    partial class frmCauHinh
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauHinh));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.WizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.page4 = new DevExpress.XtraWizard.WizardPage();
            this.btnTestConnect = new DevExpress.XtraEditors.SimpleButton();
            this.cboSV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDB = new System.Windows.Forms.ComboBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAU = new System.Windows.Forms.ComboBox();
            this.page2 = new DevExpress.XtraWizard.WizardPage();
            this.chkInstallAsClient = new DevExpress.XtraEditors.CheckEdit();
            this.chkInstallAsServer = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnInstallAsClient = new System.Windows.Forms.Button();
            this.btnInstallAsServer = new System.Windows.Forms.Button();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.WizardControl1)).BeginInit();
            this.WizardControl1.SuspendLayout();
            this.page4.SuspendLayout();
            this.page2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInstallAsClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInstallAsServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // WizardControl1
            // 
            resources.ApplyResources(this.WizardControl1, "WizardControl1");
            this.WizardControl1.Controls.Add(this.page4);
            this.WizardControl1.Controls.Add(this.page2);
            this.WizardControl1.Image = ((System.Drawing.Image)(resources.GetObject("WizardControl1.Image")));
            this.WizardControl1.Name = "WizardControl1";
            this.WizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.page2,
            this.page4});
            this.WizardControl1.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            this.WizardControl1.SelectedPageChanged += new DevExpress.XtraWizard.WizardPageChangedEventHandler(this.WizardControl1_SelectedPageChanged);
            this.WizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.WizardControl1_FinishClick);
            this.WizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            // 
            // page4
            // 
            this.page4.Controls.Add(this.btnTestConnect);
            this.page4.Controls.Add(this.cboSV);
            this.page4.Controls.Add(this.label1);
            this.page4.Controls.Add(this.cboDB);
            this.page4.Controls.Add(this.txtPW);
            this.page4.Controls.Add(this.label2);
            this.page4.Controls.Add(this.txtID);
            this.page4.Controls.Add(this.label5);
            this.page4.Controls.Add(this.label4);
            this.page4.Controls.Add(this.label3);
            this.page4.Controls.Add(this.cboAU);
            resources.ApplyResources(this.page4, "page4");
            this.page4.Name = "page4";
            // 
            // btnTestConnect
            // 
            resources.ApplyResources(this.btnTestConnect, "btnTestConnect");
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // cboSV
            // 
            this.cboSV.FormattingEnabled = true;
            this.cboSV.Items.AddRange(new object[] {
            resources.GetString("cboSV.Items")});
            resources.ApplyResources(this.cboSV, "cboSV");
            this.cboSV.Name = "cboSV";
            this.cboSV.DropDown += new System.EventHandler(this.cboSV_DropDown);
            this.cboSV.SelectedIndexChanged += new System.EventHandler(this.cboSV_SelectedIndexChanged);
            this.cboSV.TextChanged += new System.EventHandler(this.cboSV_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cboDB
            // 
            this.cboDB.DisplayMember = "DATABASE_NAME";
            this.cboDB.FormattingEnabled = true;
            resources.ApplyResources(this.cboDB, "cboDB");
            this.cboDB.Name = "cboDB";
            this.cboDB.ValueMember = "DATABASE_NAME";
            this.cboDB.DropDown += new System.EventHandler(this.cboDB_DropDown);
            this.cboDB.SelectedIndexChanged += new System.EventHandler(this.cboDB_SelectedIndexChanged);
            // 
            // txtPW
            // 
            resources.ApplyResources(this.txtPW, "txtPW");
            this.txtPW.Name = "txtPW";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtID
            // 
            resources.ApplyResources(this.txtID, "txtID");
            this.txtID.Name = "txtID";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cboAU
            // 
            this.cboAU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAU.FormattingEnabled = true;
            this.cboAU.Items.AddRange(new object[] {
            resources.GetString("cboAU.Items"),
            resources.GetString("cboAU.Items1")});
            resources.ApplyResources(this.cboAU, "cboAU");
            this.cboAU.Name = "cboAU";
            this.cboAU.SelectedIndexChanged += new System.EventHandler(this.cboAU_SelectedIndexChanged);
            // 
            // page2
            // 
            this.page2.Controls.Add(this.chkInstallAsClient);
            this.page2.Controls.Add(this.chkInstallAsServer);
            this.page2.Controls.Add(this.labelControl1);
            this.page2.Controls.Add(this.btnInstallAsClient);
            this.page2.Controls.Add(this.btnInstallAsServer);
            resources.ApplyResources(this.page2, "page2");
            this.page2.Name = "page2";
            // 
            // chkInstallAsClient
            // 
            resources.ApplyResources(this.chkInstallAsClient, "chkInstallAsClient");
            this.chkInstallAsClient.Name = "chkInstallAsClient";
            this.chkInstallAsClient.Properties.Caption = resources.GetString("chkInstallAsClient.Properties.Caption");
            // 
            // chkInstallAsServer
            // 
            resources.ApplyResources(this.chkInstallAsServer, "chkInstallAsServer");
            this.chkInstallAsServer.Name = "chkInstallAsServer";
            this.chkInstallAsServer.Properties.Caption = resources.GetString("chkInstallAsServer.Properties.Caption");
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // btnInstallAsClient
            // 
            resources.ApplyResources(this.btnInstallAsClient, "btnInstallAsClient");
            this.btnInstallAsClient.Name = "btnInstallAsClient";
            this.btnInstallAsClient.UseVisualStyleBackColor = true;
            this.btnInstallAsClient.Click += new System.EventHandler(this.btnInstallAsClient_Click);
            // 
            // btnInstallAsServer
            // 
            resources.ApplyResources(this.btnInstallAsServer, "btnInstallAsServer");
            this.btnInstallAsServer.Name = "btnInstallAsServer";
            this.btnInstallAsServer.UseVisualStyleBackColor = true;
            this.btnInstallAsServer.Click += new System.EventHandler(this.btnInstallAsServer_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "en");
            this.imageCollection1.Images.SetKeyName(1, "vi");
            // 
            // frmCauHinh
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WizardControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCauHinh";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Connector_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Connector_FormClosed);
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WizardControl1)).EndInit();
            this.WizardControl1.ResumeLayout(false);
            this.page4.ResumeLayout(false);
            this.page4.PerformLayout();
            this.page2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkInstallAsClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInstallAsServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraWizard.WizardControl WizardControl1;
        private DevExpress.XtraWizard.WizardPage page4;
        private System.Windows.Forms.ComboBox cboSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDB;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAU;
        private DevExpress.XtraWizard.WizardPage page2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnInstallAsClient;
        private System.Windows.Forms.Button btnInstallAsServer;
        private DevExpress.XtraEditors.CheckEdit chkInstallAsClient;
        private DevExpress.XtraEditors.CheckEdit chkInstallAsServer;
        private DevExpress.XtraEditors.SimpleButton btnTestConnect;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}