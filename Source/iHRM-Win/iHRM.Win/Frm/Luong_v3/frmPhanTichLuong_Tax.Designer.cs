namespace iHRM.Win.Frm.Luong_v3
{
    partial class frmPhanTichLuong_Tax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanTichLuong_Tax));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.lblPB = new DevExpress.XtraEditors.LabelControl();
            this.lblThang = new DevExpress.XtraEditors.LabelControl();
            this.txtSearchThang = new DevExpress.XtraEditors.DateEdit();
            this.logger1 = new iHRM.Win.UC.Logger();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExxecute = new DevExpress.XtraEditors.SimpleButton();
            this.checkPhanTichOK = new DevExpress.XtraEditors.CheckEdit();
            this.chkPtCongThuc = new DevExpress.XtraEditors.CheckEdit();
            this.chkHutDuLieu = new DevExpress.XtraEditors.CheckEdit();
            this.chkDlNhapTay = new DevExpress.XtraEditors.CheckEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPhanTichOK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPtCongThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHutDuLieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDlNhapTay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.chonPhongBan1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPB);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblThang);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtSearchThang);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.logger1);
            this.splitContainerControl1.Panel2.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1193, 474);
            this.splitContainerControl1.SplitterPosition = 213;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonPhongBan1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chonPhongBan1.Location = new System.Drawing.Point(3, 142);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(234, 34);
            this.chonPhongBan1.TabIndex = 9;
            // 
            // lblPB
            // 
            this.lblPB.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPB.Location = new System.Drawing.Point(3, 118);
            this.lblPB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(94, 24);
            this.lblPB.TabIndex = 8;
            this.lblPB.Text = "Phòng ban";
            // 
            // lblThang
            // 
            this.lblThang.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblThang.Location = new System.Drawing.Point(3, 52);
            this.lblThang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(56, 24);
            this.lblThang.TabIndex = 3;
            this.lblThang.Text = "Tháng";
            // 
            // txtSearchThang
            // 
            this.txtSearchThang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchThang.EditValue = null;
            this.txtSearchThang.Location = new System.Drawing.Point(3, 75);
            this.txtSearchThang.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.txtSearchThang.Name = "txtSearchThang";
            this.txtSearchThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtSearchThang.Properties.Appearance.Options.UseFont = true;
            this.txtSearchThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSearchThang.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSearchThang.Properties.DisplayFormat.FormatString = "MM - yyyy";
            this.txtSearchThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtSearchThang.Properties.Mask.EditMask = "MM - yyyy";
            this.txtSearchThang.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.txtSearchThang.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.txtSearchThang.Size = new System.Drawing.Size(234, 30);
            this.txtSearchThang.TabIndex = 4;
            // 
            // logger1
            // 
            this.logger1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logger1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logger1.Location = new System.Drawing.Point(0, 176);
            this.logger1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.logger1.Name = "logger1";
            this.logger1.Size = new System.Drawing.Size(939, 298);
            this.logger1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExxecute);
            this.panel1.Controls.Add(this.checkPhanTichOK);
            this.panel1.Controls.Add(this.chkPtCongThuc);
            this.panel1.Controls.Add(this.chkHutDuLieu);
            this.panel1.Controls.Add(this.chkDlNhapTay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 176);
            this.panel1.TabIndex = 3;
            // 
            // btnExxecute
            // 
            this.btnExxecute.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnExxecute.Appearance.Options.UseFont = true;
            this.btnExxecute.Enabled = false;
            this.btnExxecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExxecute.Image")));
            this.btnExxecute.Location = new System.Drawing.Point(17, 107);
            this.btnExxecute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExxecute.Name = "btnExxecute";
            this.btnExxecute.Size = new System.Drawing.Size(223, 46);
            this.btnExxecute.TabIndex = 1;
            this.btnExxecute.Text = "Tiến hành phân tích";
            this.btnExxecute.Click += new System.EventHandler(this.btnExxecute_Click);
            // 
            // checkPhanTichOK
            // 
            this.checkPhanTichOK.Location = new System.Drawing.Point(17, 71);
            this.checkPhanTichOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkPhanTichOK.Name = "checkPhanTichOK";
            this.checkPhanTichOK.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.checkPhanTichOK.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkPhanTichOK.Properties.Appearance.Options.UseFont = true;
            this.checkPhanTichOK.Properties.Appearance.Options.UseForeColor = true;
            this.checkPhanTichOK.Properties.Caption = "Tôi hiểu rằng khi ấn nút phân tích sẽ ghi đè dữ liệu của lần phân tích trước";
            this.checkPhanTichOK.Size = new System.Drawing.Size(682, 28);
            this.checkPhanTichOK.TabIndex = 0;
            this.checkPhanTichOK.CheckedChanged += new System.EventHandler(this.checkEdit5_CheckedChanged);
            // 
            // chkPtCongThuc
            // 
            this.chkPtCongThuc.Location = new System.Drawing.Point(477, 15);
            this.chkPtCongThuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPtCongThuc.Name = "chkPtCongThuc";
            this.chkPtCongThuc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chkPtCongThuc.Properties.Appearance.Options.UseFont = true;
            this.chkPtCongThuc.Properties.Caption = "Tính toán các tham số";
            this.chkPtCongThuc.Size = new System.Drawing.Size(223, 28);
            this.chkPtCongThuc.TabIndex = 0;
            // 
            // chkHutDuLieu
            // 
            this.chkHutDuLieu.Location = new System.Drawing.Point(247, 15);
            this.chkHutDuLieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkHutDuLieu.Name = "chkHutDuLieu";
            this.chkHutDuLieu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chkHutDuLieu.Properties.Appearance.Options.UseFont = true;
            this.chkHutDuLieu.Properties.Caption = "Hút dữ liệu từ module";
            this.chkHutDuLieu.Size = new System.Drawing.Size(223, 28);
            this.chkHutDuLieu.TabIndex = 0;
            // 
            // chkDlNhapTay
            // 
            this.chkDlNhapTay.Location = new System.Drawing.Point(17, 15);
            this.chkDlNhapTay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDlNhapTay.Name = "chkDlNhapTay";
            this.chkDlNhapTay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chkDlNhapTay.Properties.Appearance.Options.UseFont = true;
            this.chkDlNhapTay.Properties.Caption = "Chuyển dữ liệu tự nhập";
            this.chkDlNhapTay.Size = new System.Drawing.Size(223, 28);
            this.chkDlNhapTay.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmPhanTichLuong_Tax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 474);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPhanTichLuong_Tax";
            this.Text = "Phân tích thuế";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhanTichLuong_Tax_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkPhanTichOK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPtCongThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHutDuLieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDlNhapTay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl lblThang;
        private DevExpress.XtraEditors.DateEdit txtSearchThang;
        private UC.ChonPhongBan chonPhongBan1;
        private DevExpress.XtraEditors.LabelControl lblPB;
        private System.Windows.Forms.Panel panel1;
        private UC.Logger logger1;
        private DevExpress.XtraEditors.SimpleButton btnExxecute;
        private DevExpress.XtraEditors.CheckEdit checkPhanTichOK;
        private DevExpress.XtraEditors.CheckEdit chkPtCongThuc;
        private DevExpress.XtraEditors.CheckEdit chkHutDuLieu;
        private DevExpress.XtraEditors.CheckEdit chkDlNhapTay;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}