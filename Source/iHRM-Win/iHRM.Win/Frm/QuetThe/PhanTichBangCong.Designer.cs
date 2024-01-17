namespace iHRM.Win.Frm.QuetThe
{
    partial class PhanTichBangCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhanTichBangCong));
            this.btnDoImport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chk_SanCongThang = new DevExpress.XtraEditors.CheckEdit();
            this.bgw_import = new System.ComponentModel.BackgroundWorker();
            this.ucProgressRichtext1 = new iHRM.Win.UC.ucProgressRichtext();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_SanCongThang.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDoImport);
            this.panel1.Size = new System.Drawing.Size(690, 81);
            this.panel1.Controls.SetChildIndex(this.btnDoImport, 0);
            // 
            // btnDoImport
            // 
            this.btnDoImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoImport.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.btnDoImport.Appearance.Options.UseFont = true;
            this.btnDoImport.Image = global::iHRM.Win.Properties.Resources.play;
            this.btnDoImport.Location = new System.Drawing.Point(579, 29);
            this.btnDoImport.Name = "btnDoImport";
            this.btnDoImport.Size = new System.Drawing.Size(105, 33);
            this.btnDoImport.TabIndex = 0;
            this.btnDoImport.Text = "Analyze";
            this.btnDoImport.Click += new System.EventHandler(this.btnDoImport_Click);
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
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2022, 6, 30, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = true;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(18, 9);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(153, 99);
            this.chonKyLuong1.TabIndex = 5;
            this.chonKyLuong1.TuNgay = new System.DateTime(2022, 6, 1, 0, 0, 0, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chk_SanCongThang);
            this.panelControl1.Controls.Add(this.chonKyLuong1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 81);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(690, 121);
            this.panelControl1.TabIndex = 7;
            // 
            // chk_SanCongThang
            // 
            this.chk_SanCongThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_SanCongThang.EditValue = true;
            this.chk_SanCongThang.Location = new System.Drawing.Point(177, 52);
            this.chk_SanCongThang.Name = "chk_SanCongThang";
            this.chk_SanCongThang.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_SanCongThang.Properties.Appearance.Options.UseFont = true;
            this.chk_SanCongThang.Properties.Caption = "San công tháng";
            this.chk_SanCongThang.Size = new System.Drawing.Size(124, 23);
            this.chk_SanCongThang.TabIndex = 6;
            // 
            // bgw_import
            // 
            this.bgw_import.WorkerReportsProgress = true;
            this.bgw_import.WorkerSupportsCancellation = true;
            this.bgw_import.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_import_DoWork);
            this.bgw_import.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_import_ProgressChanged);
            this.bgw_import.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_import_RunWorkerCompleted);
            // 
            // ucProgressRichtext1
            // 
            this.ucProgressRichtext1.CurrentValue = 0;
            this.ucProgressRichtext1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProgressRichtext1.Location = new System.Drawing.Point(0, 202);
            this.ucProgressRichtext1.Message = "\n\n\n\n\n\n";
            this.ucProgressRichtext1.Name = "ucProgressRichtext1";
            this.ucProgressRichtext1.Size = new System.Drawing.Size(690, 267);
            this.ucProgressRichtext1.Status = "Đang tải dữ liệu...";
            this.ucProgressRichtext1.TabIndex = 8;
            // 
            // PhanTichBangCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 469);
            this.Controls.Add(this.ucProgressRichtext1);
            this.Controls.Add(this.panelControl1);
            this.Form_Description = "Hành động này sẽ phân tích tất cả kết quả quẹt thẻ của bảng công \r\nđể làm bước đệ" +
    "m cho hành động phân tích dữ liệu lương.  ";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Phân tích bảng công ";
            this.Name = "PhanTichBangCong";
            this.Text = "Phân tích bảng công ";
            this.Load += new System.EventHandler(this.XuLyDuLieu_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.ucProgressRichtext1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk_SanCongThang.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnDoImport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.ComponentModel.BackgroundWorker bgw_import;
        private UC.ucProgressRichtext ucProgressRichtext1;
        private DevExpress.XtraEditors.CheckEdit chk_SanCongThang;
    }
}