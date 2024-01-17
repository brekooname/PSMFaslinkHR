namespace iHRM.Win.Frm.i_Import
{
    partial class FixImporter
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFilePath = new DevExpress.XtraEditors.ButtonEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.prg = new DevExpress.XtraEditors.ProgressBarControl();
            this.bgw_import = new System.ComponentModel.BackgroundWorker();
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(12, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "labelControl1";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(35, 21);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.txtFilePath.Properties.Appearance.Options.UseFont = true;
            this.txtFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFilePath.Size = new System.Drawing.Size(457, 24);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFilePath_ButtonClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.richTextBox1);
            this.panelControl1.Location = new System.Drawing.Point(35, 75);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(582, 205);
            this.panelControl1.TabIndex = 13;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(578, 201);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // prg
            // 
            this.prg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prg.Location = new System.Drawing.Point(35, 51);
            this.prg.Name = "prg";
            this.prg.Size = new System.Drawing.Size(582, 18);
            this.prg.TabIndex = 14;
            // 
            // bgw_import
            // 
            this.bgw_import.WorkerReportsProgress = true;
            this.bgw_import.WorkerSupportsCancellation = true;
            this.bgw_import.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_import_DoWork);
            this.bgw_import.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_import_ProgressChanged);
            this.bgw_import.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_import_RunWorkerCompleted);
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "&Đóng lại";
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishText = "&Xóa log";
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&Tiếp tục »";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wizardPage2,
            this.wizardPage1});
            this.wizardControl1.PreviousText = "« &Quay lại";
            this.wizardControl1.Size = new System.Drawing.Size(690, 428);
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.btnImport);
            this.wizardPage1.Controls.Add(this.prg);
            this.wizardPage1.Controls.Add(this.panelControl1);
            this.wizardPage1.Controls.Add(this.txtFilePath);
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.DescriptionText = "Tải lên file dữ liệu của bạn";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(658, 283);
            this.wizardPage1.Text = "Nhập file dữ liệu";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Image = global::iHRM.Win.Properties.Resources.play;
            this.btnImport.Location = new System.Drawing.Point(498, 20);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(117, 26);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "Thực hiện";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label2.Location = new System.Drawing.Point(32, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn file excel chứa dữ liệu";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.labelControl3);
            this.wizardPage2.Controls.Add(this.linkLabel1);
            this.wizardPage2.Controls.Add(this.labelControl2);
            this.wizardPage2.DescriptionText = "Thuật sỹ sẽ hướng dẫn bạn thực hiện từng bước";
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(658, 283);
            this.wizardPage2.Text = "Bắt đầu";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.labelControl3.Location = new System.Drawing.Point(36, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(408, 18);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Sau khi nhập dữ liệu đầy đủ vào file excel, ấn Next để tiếp tục";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.linkLabel1.Location = new System.Drawing.Point(431, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(84, 18);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Tải file mẫu";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.labelControl2.Location = new System.Drawing.Point(36, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(389, 18);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "File nhập dữ liệu là file excel giống với file mẫu của chúng tôi";
            // 
            // FixImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 428);
            this.Controls.Add(this.wizardControl1);
            this.Name = "FixImporter";
            this.Text = "Nhập dữ liệu từ excel";
            this.Load += new System.EventHandler(this.Importer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.ButtonEdit txtFilePath;
        public DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public DevExpress.XtraEditors.ProgressBarControl prg;
        public System.ComponentModel.BackgroundWorker bgw_import;
        public DevExpress.XtraWizard.WizardControl wizardControl1;
        public DevExpress.XtraWizard.WizardPage wizardPage1;
        public DevExpress.XtraWizard.WizardPage wizardPage2;
        public DevExpress.XtraEditors.LabelControl labelControl3;
        public System.Windows.Forms.LinkLabel linkLabel1;
        public DevExpress.XtraEditors.LabelControl labelControl2;
        public System.Windows.Forms.Label label2;
        public DevExpress.XtraEditors.SimpleButton btnImport;

    }
}