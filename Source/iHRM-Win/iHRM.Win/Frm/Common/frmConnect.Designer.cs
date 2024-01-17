namespace iHRM.Win.Frm.Common
{
    partial class frmConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnect));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblCSDL = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInstallAsClient = new System.Windows.Forms.Button();
            this.btnInstallAsServer = new System.Windows.Forms.Button();
            this.lbl_Info = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Conncet = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Refresh1 = new System.Windows.Forms.LinkLabel();
            this.lbl_Refresh2 = new System.Windows.Forms.LinkLabel();
            this.btnConnectSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestConnect = new DevExpress.XtraEditors.SimpleButton();
            this.cboSV = new System.Windows.Forms.ComboBox();
            this.lbl_SeverName = new System.Windows.Forms.Label();
            this.cboDB = new System.Windows.Forms.ComboBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.lblDataAuth = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbl_Database = new System.Windows.Forms.Label();
            this.lbl_Pass = new System.Windows.Forms.Label();
            this.lbl_Login = new System.Windows.Forms.Label();
            this.cboAU = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.btn_UpdateSave = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.lbl_Config = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.txtUpdateFile = new System.Windows.Forms.TextBox();
            this.txtRarfileHost = new System.Windows.Forms.TextBox();
            this.lbl_ConfigUpdate = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Refresh3 = new System.Windows.Forms.LinkLabel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_Linkhost = new System.Windows.Forms.Label();
            this.lbl_Rar = new System.Windows.Forms.Label();
            this.lbl_UpdateInHost = new System.Windows.Forms.Label();
            this.txtLinkHost = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_UpdateSave)).BeginInit();
            this.btn_UpdateSave.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::iHRM.Win.Properties.Resources.ac03;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.lblCSDL);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 73);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(126, 73);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.labelControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.Image")));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(587, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 16);
            this.labelControl1.TabIndex = 3;
            // 
            // lblCSDL
            // 
            this.lblCSDL.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblCSDL.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblCSDL.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblCSDL.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCSDL.Location = new System.Drawing.Point(130, 47);
            this.lblCSDL.Name = "lblCSDL";
            this.lblCSDL.Size = new System.Drawing.Size(108, 19);
            this.lblCSDL.TabIndex = 3;
            this.lblCSDL.Text = "Kết nối tới CSDL";
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblTitle.Location = new System.Drawing.Point(130, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(442, 26);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Công Ty Cổ Phần Công Nghiệp Đông Hưng";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(451, 164);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnInstallAsClient
            // 
            this.btnInstallAsClient.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallAsClient.Image = ((System.Drawing.Image)(resources.GetObject("btnInstallAsClient.Image")));
            this.btnInstallAsClient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInstallAsClient.Location = new System.Drawing.Point(104, 238);
            this.btnInstallAsClient.Name = "btnInstallAsClient";
            this.btnInstallAsClient.Size = new System.Drawing.Size(306, 50);
            this.btnInstallAsClient.TabIndex = 11;
            this.btnInstallAsClient.Text = "Cài đặt như máy khách";
            this.btnInstallAsClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInstallAsClient.UseVisualStyleBackColor = true;
            this.btnInstallAsClient.Click += new System.EventHandler(this.btnInstallAsClient_Click);
            // 
            // btnInstallAsServer
            // 
            this.btnInstallAsServer.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallAsServer.Image = ((System.Drawing.Image)(resources.GetObject("btnInstallAsServer.Image")));
            this.btnInstallAsServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInstallAsServer.Location = new System.Drawing.Point(104, 182);
            this.btnInstallAsServer.Name = "btnInstallAsServer";
            this.btnInstallAsServer.Size = new System.Drawing.Size(306, 50);
            this.btnInstallAsServer.TabIndex = 10;
            this.btnInstallAsServer.Text = "Cài đặt như máy chủ";
            this.btnInstallAsServer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInstallAsServer.UseVisualStyleBackColor = true;
            this.btnInstallAsServer.Click += new System.EventHandler(this.btnInstallAsServer_Click);
            // 
            // lbl_Info
            // 
            this.lbl_Info.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.lbl_Info.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbl_Info.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbl_Info.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl_Info.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_Info.Location = new System.Drawing.Point(38, 62);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(483, 90);
            this.lbl_Info.TabIndex = 3;
            this.lbl_Info.Text = resources.GetString("lbl_Info.Text");
            // 
            // lbl_Conncet
            // 
            this.lbl_Conncet.Appearance.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Conncet.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbl_Conncet.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbl_Conncet.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_Conncet.Location = new System.Drawing.Point(38, 14);
            this.lbl_Conncet.Name = "lbl_Conncet";
            this.lbl_Conncet.Size = new System.Drawing.Size(306, 31);
            this.lbl_Conncet.TabIndex = 3;
            this.lbl_Conncet.Text = "Chọn phương thức kết nối";
            // 
            // lbl_Refresh1
            // 
            this.lbl_Refresh1.AutoSize = true;
            this.lbl_Refresh1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lbl_Refresh1.Location = new System.Drawing.Point(444, 60);
            this.lbl_Refresh1.Name = "lbl_Refresh1";
            this.lbl_Refresh1.Size = new System.Drawing.Size(68, 21);
            this.lbl_Refresh1.TabIndex = 33;
            this.lbl_Refresh1.TabStop = true;
            this.lbl_Refresh1.Text = "Refresh";
            this.lbl_Refresh1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lbl_Refresh2
            // 
            this.lbl_Refresh2.AutoSize = true;
            this.lbl_Refresh2.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lbl_Refresh2.Location = new System.Drawing.Point(444, 220);
            this.lbl_Refresh2.Name = "lbl_Refresh2";
            this.lbl_Refresh2.Size = new System.Drawing.Size(68, 21);
            this.lbl_Refresh2.TabIndex = 33;
            this.lbl_Refresh2.TabStop = true;
            this.lbl_Refresh2.Text = "Refresh";
            this.lbl_Refresh2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // btnConnectSave
            // 
            this.btnConnectSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConnectSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnConnectSave.Appearance.Options.UseFont = true;
            this.btnConnectSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnConnectSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConnectSave.Location = new System.Drawing.Point(287, 263);
            this.btnConnectSave.Name = "btnConnectSave";
            this.btnConnectSave.Size = new System.Drawing.Size(125, 45);
            this.btnConnectSave.TabIndex = 32;
            this.btnConnectSave.Text = "Lưu";
            this.btnConnectSave.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestConnect.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnTestConnect.Appearance.Options.UseFont = true;
            this.btnTestConnect.Image = global::iHRM.Win.Properties.Resources.btnChoose_Image;
            this.btnTestConnect.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnTestConnect.Location = new System.Drawing.Point(158, 263);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(125, 45);
            this.btnTestConnect.TabIndex = 32;
            this.btnTestConnect.Text = "Kiểm tra";
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // cboSV
            // 
            this.cboSV.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.cboSV.FormattingEnabled = true;
            this.cboSV.Items.AddRange(new object[] {
            "Đang tải danh sách máy chủ..."});
            this.cboSV.Location = new System.Drawing.Point(158, 56);
            this.cboSV.Margin = new System.Windows.Forms.Padding(4);
            this.cboSV.Name = "cboSV";
            this.cboSV.Size = new System.Drawing.Size(279, 29);
            this.cboSV.TabIndex = 26;
            // 
            // lbl_SeverName
            // 
            this.lbl_SeverName.AutoSize = true;
            this.lbl_SeverName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SeverName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_SeverName.Location = new System.Drawing.Point(27, 62);
            this.lbl_SeverName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_SeverName.Name = "lbl_SeverName";
            this.lbl_SeverName.Size = new System.Drawing.Size(110, 21);
            this.lbl_SeverName.TabIndex = 22;
            this.lbl_SeverName.Text = "Server Name:";
            // 
            // cboDB
            // 
            this.cboDB.DisplayMember = "DATABASE_NAME";
            this.cboDB.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.cboDB.FormattingEnabled = true;
            this.cboDB.Location = new System.Drawing.Point(158, 212);
            this.cboDB.Margin = new System.Windows.Forms.Padding(4);
            this.cboDB.Name = "cboDB";
            this.cboDB.Size = new System.Drawing.Size(279, 29);
            this.cboDB.TabIndex = 31;
            this.cboDB.ValueMember = "DATABASE_NAME";
            // 
            // txtPW
            // 
            this.txtPW.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPW.Location = new System.Drawing.Point(158, 173);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '*';
            this.txtPW.Size = new System.Drawing.Size(279, 29);
            this.txtPW.TabIndex = 29;
            // 
            // lblDataAuth
            // 
            this.lblDataAuth.AutoSize = true;
            this.lblDataAuth.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataAuth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataAuth.Location = new System.Drawing.Point(27, 101);
            this.lblDataAuth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataAuth.Name = "lblDataAuth";
            this.lblDataAuth.Size = new System.Drawing.Size(121, 21);
            this.lblDataAuth.TabIndex = 23;
            this.lblDataAuth.Text = "Authentication:";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtID.Location = new System.Drawing.Point(158, 134);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(279, 29);
            this.txtID.TabIndex = 28;
            // 
            // lbl_Database
            // 
            this.lbl_Database.AutoSize = true;
            this.lbl_Database.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Database.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Database.Location = new System.Drawing.Point(27, 218);
            this.lbl_Database.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Database.Name = "lbl_Database";
            this.lbl_Database.Size = new System.Drawing.Size(82, 21);
            this.lbl_Database.TabIndex = 30;
            this.lbl_Database.Text = "Database:";
            // 
            // lbl_Pass
            // 
            this.lbl_Pass.AutoSize = true;
            this.lbl_Pass.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Pass.Location = new System.Drawing.Point(27, 179);
            this.lbl_Pass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Pass.Name = "lbl_Pass";
            this.lbl_Pass.Size = new System.Drawing.Size(88, 21);
            this.lbl_Pass.TabIndex = 25;
            this.lbl_Pass.Text = "Password:";
            // 
            // lbl_Login
            // 
            this.lbl_Login.AutoSize = true;
            this.lbl_Login.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Login.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Login.Location = new System.Drawing.Point(27, 140);
            this.lbl_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Login.Name = "lbl_Login";
            this.lbl_Login.Size = new System.Drawing.Size(57, 21);
            this.lbl_Login.TabIndex = 24;
            this.lbl_Login.Text = "Login:";
            // 
            // cboAU
            // 
            this.cboAU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAU.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.cboAU.FormattingEnabled = true;
            this.cboAU.Items.AddRange(new object[] {
            "Windows Authentication",
            "Sql Server Authentication"});
            this.cboAU.Location = new System.Drawing.Point(158, 95);
            this.cboAU.Margin = new System.Windows.Forms.Padding(4);
            this.cboAU.Name = "cboAU";
            this.cboAU.Size = new System.Drawing.Size(279, 29);
            this.cboAU.TabIndex = 27;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(438, 164);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(158, 154);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // btn_UpdateSave
            // 
            this.btn_UpdateSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_UpdateSave.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.btn_UpdateSave.Location = new System.Drawing.Point(0, 73);
            this.btn_UpdateSave.Name = "btn_UpdateSave";
            this.btn_UpdateSave.SelectedTabPage = this.xtraTabPage1;
            this.btn_UpdateSave.Size = new System.Drawing.Size(622, 349);
            this.btn_UpdateSave.TabIndex = 13;
            this.btn_UpdateSave.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnInstallAsClient);
            this.xtraTabPage1.Controls.Add(this.lbl_Conncet);
            this.xtraTabPage1.Controls.Add(this.btnInstallAsServer);
            this.xtraTabPage1.Controls.Add(this.lbl_Info);
            this.xtraTabPage1.Controls.Add(this.pictureBox1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(616, 321);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.lbl_Config);
            this.xtraTabPage2.Controls.Add(this.lbl_Refresh1);
            this.xtraTabPage2.Controls.Add(this.cboSV);
            this.xtraTabPage2.Controls.Add(this.lbl_Refresh2);
            this.xtraTabPage2.Controls.Add(this.btnConnectSave);
            this.xtraTabPage2.Controls.Add(this.cboAU);
            this.xtraTabPage2.Controls.Add(this.btnTestConnect);
            this.xtraTabPage2.Controls.Add(this.lbl_Login);
            this.xtraTabPage2.Controls.Add(this.lbl_Pass);
            this.xtraTabPage2.Controls.Add(this.lbl_SeverName);
            this.xtraTabPage2.Controls.Add(this.lbl_Database);
            this.xtraTabPage2.Controls.Add(this.cboDB);
            this.xtraTabPage2.Controls.Add(this.txtID);
            this.xtraTabPage2.Controls.Add(this.txtPW);
            this.xtraTabPage2.Controls.Add(this.lblDataAuth);
            this.xtraTabPage2.Controls.Add(this.pictureBox3);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(616, 321);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // lbl_Config
            // 
            this.lbl_Config.Appearance.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Config.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbl_Config.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbl_Config.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_Config.Location = new System.Drawing.Point(38, 14);
            this.lbl_Config.Name = "lbl_Config";
            this.lbl_Config.Size = new System.Drawing.Size(196, 31);
            this.lbl_Config.TabIndex = 35;
            this.lbl_Config.Text = "Cấu hình kết nối";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.txtUpdateFile);
            this.xtraTabPage3.Controls.Add(this.txtRarfileHost);
            this.xtraTabPage3.Controls.Add(this.lbl_ConfigUpdate);
            this.xtraTabPage3.Controls.Add(this.lbl_Refresh3);
            this.xtraTabPage3.Controls.Add(this.simpleButton2);
            this.xtraTabPage3.Controls.Add(this.lbl_Linkhost);
            this.xtraTabPage3.Controls.Add(this.lbl_Rar);
            this.xtraTabPage3.Controls.Add(this.lbl_UpdateInHost);
            this.xtraTabPage3.Controls.Add(this.txtLinkHost);
            this.xtraTabPage3.Controls.Add(this.pictureBox4);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(616, 321);
            this.xtraTabPage3.Text = "xtraTabPage3";
            // 
            // txtUpdateFile
            // 
            this.txtUpdateFile.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateFile.Location = new System.Drawing.Point(165, 127);
            this.txtUpdateFile.Name = "txtUpdateFile";
            this.txtUpdateFile.Size = new System.Drawing.Size(204, 29);
            this.txtUpdateFile.TabIndex = 53;
            // 
            // txtRarfileHost
            // 
            this.txtRarfileHost.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRarfileHost.Location = new System.Drawing.Point(165, 90);
            this.txtRarfileHost.Name = "txtRarfileHost";
            this.txtRarfileHost.Size = new System.Drawing.Size(204, 29);
            this.txtRarfileHost.TabIndex = 52;
            // 
            // lbl_ConfigUpdate
            // 
            this.lbl_ConfigUpdate.Appearance.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ConfigUpdate.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbl_ConfigUpdate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbl_ConfigUpdate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_ConfigUpdate.Location = new System.Drawing.Point(35, 9);
            this.lbl_ConfigUpdate.Name = "lbl_ConfigUpdate";
            this.lbl_ConfigUpdate.Size = new System.Drawing.Size(196, 31);
            this.lbl_ConfigUpdate.TabIndex = 51;
            this.lbl_ConfigUpdate.Text = "Cấu hình update";
            // 
            // lbl_Refresh3
            // 
            this.lbl_Refresh3.AutoSize = true;
            this.lbl_Refresh3.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lbl_Refresh3.Location = new System.Drawing.Point(441, 215);
            this.lbl_Refresh3.Name = "lbl_Refresh3";
            this.lbl_Refresh3.Size = new System.Drawing.Size(68, 21);
            this.lbl_Refresh3.TabIndex = 49;
            this.lbl_Refresh3.TabStop = true;
            this.lbl_Refresh3.Text = "Refresh";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.simpleButton2.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton2.Location = new System.Drawing.Point(165, 173);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(125, 45);
            this.simpleButton2.TabIndex = 46;
            this.simpleButton2.Text = "Lưu";
            // 
            // lbl_Linkhost
            // 
            this.lbl_Linkhost.AutoSize = true;
            this.lbl_Linkhost.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Linkhost.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Linkhost.Location = new System.Drawing.Point(12, 56);
            this.lbl_Linkhost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Linkhost.Name = "lbl_Linkhost";
            this.lbl_Linkhost.Size = new System.Drawing.Size(84, 21);
            this.lbl_Linkhost.TabIndex = 38;
            this.lbl_Linkhost.Text = "Link host:";
            // 
            // lbl_Rar
            // 
            this.lbl_Rar.AutoSize = true;
            this.lbl_Rar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Rar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Rar.Location = new System.Drawing.Point(12, 94);
            this.lbl_Rar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Rar.Name = "lbl_Rar";
            this.lbl_Rar.Size = new System.Drawing.Size(105, 21);
            this.lbl_Rar.TabIndex = 39;
            this.lbl_Rar.Text = "Rar file host:";
            // 
            // lbl_UpdateInHost
            // 
            this.lbl_UpdateInHost.AutoSize = true;
            this.lbl_UpdateInHost.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UpdateInHost.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_UpdateInHost.Location = new System.Drawing.Point(12, 131);
            this.lbl_UpdateInHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_UpdateInHost.Name = "lbl_UpdateInHost";
            this.lbl_UpdateInHost.Size = new System.Drawing.Size(150, 21);
            this.lbl_UpdateInHost.TabIndex = 44;
            this.lbl_UpdateInHost.Text = "Update file in host:";
            // 
            // txtLinkHost
            // 
            this.txtLinkHost.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLinkHost.Location = new System.Drawing.Point(165, 49);
            this.txtLinkHost.Name = "txtLinkHost";
            this.txtLinkHost.Size = new System.Drawing.Size(204, 29);
            this.txtLinkHost.TabIndex = 42;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(435, 159);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(158, 154);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 50;
            this.pictureBox4.TabStop = false;
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 422);
            this.ControlBox = false;
            this.Controls.Add(this.btn_UpdateSave);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Connector_FormClosing);
            this.Load += new System.EventHandler(this.login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_UpdateSave)).EndInit();
            this.btn_UpdateSave.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.LabelControl lblCSDL;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        protected System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lbl_Info;
        private DevExpress.XtraEditors.LabelControl lbl_Conncet;
        private System.Windows.Forms.Button btnInstallAsClient;
        private System.Windows.Forms.Button btnInstallAsServer;
        private DevExpress.XtraEditors.SimpleButton btnTestConnect;
        private System.Windows.Forms.ComboBox cboSV;
        private System.Windows.Forms.Label lbl_SeverName;
        private System.Windows.Forms.ComboBox cboDB;
        private System.Windows.Forms.Label lblDataAuth;
        private System.Windows.Forms.Label lbl_Database;
        private System.Windows.Forms.Label lbl_Pass;
        private System.Windows.Forms.Label lbl_Login;
        private System.Windows.Forms.ComboBox cboAU;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPW;
        private DevExpress.XtraEditors.SimpleButton btnConnectSave;
        private System.Windows.Forms.LinkLabel lbl_Refresh1;
        private System.Windows.Forms.LinkLabel lbl_Refresh2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private DevExpress.XtraTab.XtraTabControl btn_UpdateSave;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl lbl_Config;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.LabelControl lbl_ConfigUpdate;
        private System.Windows.Forms.LinkLabel lbl_Refresh3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Label lbl_Linkhost;
        private System.Windows.Forms.Label lbl_Rar;
        private System.Windows.Forms.Label lbl_UpdateInHost;
        private System.Windows.Forms.TextBox txtLinkHost;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtUpdateFile;
        private System.Windows.Forms.TextBox txtRarfileHost;
    }
}

