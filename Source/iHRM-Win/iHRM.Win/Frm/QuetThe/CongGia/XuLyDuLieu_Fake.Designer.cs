namespace iHRM.Win.Frm.QuetThe.CongGia
{
    partial class XuLyDuLieu_Fake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XuLyDuLieu_Fake));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.prg = new DevExpress.XtraEditors.ProgressBarControl();
            this.bsMapping = new System.Windows.Forms.BindingSource(this.components);
            this.bgw_import = new System.ComponentModel.BackgroundWorker();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtSoTieng = new DevExpress.XtraEditors.TextEdit();
            this.lblSoTieng = new System.Windows.Forms.Label();
            this.btnCatQua4hTC = new DevExpress.XtraEditors.SimpleButton();
            this.btnDoImport = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTieng.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDoImport);
            this.panel1.Size = new System.Drawing.Size(1019, 70);
            this.panel1.Controls.SetChildIndex(this.btnDoImport, 0);
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
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.richTextBox1);
            this.panelControl1.Location = new System.Drawing.Point(63, 259);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(903, 381);
            this.panelControl1.TabIndex = 13;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(899, 377);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // prg
            // 
            this.prg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prg.Location = new System.Drawing.Point(65, 243);
            this.prg.Name = "prg";
            this.prg.Size = new System.Drawing.Size(901, 15);
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
            // checkEdit1
            // 
            this.checkEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkEdit1.Location = new System.Drawing.Point(593, 176);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "Đưa về dữ liệu GỐC";
            this.checkEdit1.Size = new System.Drawing.Size(179, 23);
            this.checkEdit1.TabIndex = 5;
            this.checkEdit1.Visible = false;
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(227, 79);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(360, 158);
            this.ucChonDoiTuong_DS1.TabIndex = 19;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2022, 3, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = true;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(65, 79);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(156, 105);
            this.chonKyLuong1.TabIndex = 20;
            this.chonKyLuong1.TuNgay = new System.DateTime(2022, 3, 1, 0, 0, 0, 0);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.txtSoTieng);
            this.panelControl2.Controls.Add(this.lblSoTieng);
            this.panelControl2.Controls.Add(this.btnCatQua4hTC);
            this.panelControl2.Location = new System.Drawing.Point(593, 79);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(165, 73);
            this.panelControl2.TabIndex = 28;
            // 
            // txtSoTieng
            // 
            this.txtSoTieng.EditValue = "1";
            this.txtSoTieng.Location = new System.Drawing.Point(67, 4);
            this.txtSoTieng.Name = "txtSoTieng";
            this.txtSoTieng.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTieng.Properties.Appearance.Options.UseFont = true;
            this.txtSoTieng.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSoTieng.Size = new System.Drawing.Size(90, 26);
            this.txtSoTieng.TabIndex = 25;
            // 
            // lblSoTieng
            // 
            this.lblSoTieng.AutoSize = true;
            this.lblSoTieng.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTieng.Location = new System.Drawing.Point(2, 9);
            this.lblSoTieng.Name = "lblSoTieng";
            this.lblSoTieng.Size = new System.Drawing.Size(62, 17);
            this.lblSoTieng.TabIndex = 26;
            this.lblSoTieng.Text = "Số tiếng: ";
            // 
            // btnCatQua4hTC
            // 
            this.btnCatQua4hTC.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatQua4hTC.Appearance.Options.UseFont = true;
            this.btnCatQua4hTC.Location = new System.Drawing.Point(5, 36);
            this.btnCatQua4hTC.Name = "btnCatQua4hTC";
            this.btnCatQua4hTC.Size = new System.Drawing.Size(151, 32);
            this.btnCatQua4hTC.TabIndex = 7;
            this.btnCatQua4hTC.Text = "Cắt OT quá số tiếng";
            this.btnCatQua4hTC.Click += new System.EventHandler(this.btnCatQua4hTC_Click);
            // 
            // btnDoImport
            // 
            this.btnDoImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoImport.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoImport.Appearance.Options.UseFont = true;
            this.btnDoImport.Image = global::iHRM.Win.Properties.Resources.play;
            this.btnDoImport.Location = new System.Drawing.Point(873, 20);
            this.btnDoImport.Name = "btnDoImport";
            this.btnDoImport.Size = new System.Drawing.Size(105, 33);
            this.btnDoImport.TabIndex = 29;
            this.btnDoImport.Text = "Analyze";
            this.btnDoImport.Click += new System.EventHandler(this.btnDoImport_Click);
            // 
            // XuLyDuLieu_Fake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 680);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.chonKyLuong1);
            this.Controls.Add(this.ucChonDoiTuong_DS1);
            this.Controls.Add(this.prg);
            this.Controls.Add(this.panelControl1);
            this.Form_Description = "Hành động này sẽ phân tích tất cả dữ liệu đã được kết chuyển \r\nvà thực hiện cập n" +
    "hật tính công cho nhân viên làm ca.";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Tính công báo cáo";
            this.KeyPreview = true;
            this.Name = "XuLyDuLieu_Fake";
            this.Text = "Xử lý dữ liệu báo cáo";
            this.Load += new System.EventHandler(this.XuLyDuLieu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XuLyDuLieu_Fake_KeyDown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.prg, 0);
            this.Controls.SetChildIndex(this.ucChonDoiTuong_DS1, 0);
            this.Controls.SetChildIndex(this.chonKyLuong1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.checkEdit1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTieng.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.ProgressBarControl prg;
        private System.Windows.Forms.BindingSource bsMapping;
        private System.ComponentModel.BackgroundWorker bgw_import;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtSoTieng;
        private System.Windows.Forms.Label lblSoTieng;
        private DevExpress.XtraEditors.SimpleButton btnCatQua4hTC;
        private DevExpress.XtraEditors.SimpleButton btnDoImport;
    }
}