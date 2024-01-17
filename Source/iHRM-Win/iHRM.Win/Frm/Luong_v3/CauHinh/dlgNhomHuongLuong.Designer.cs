namespace iHRM.Win.Frm.Luong_v3
{
    partial class dlgNhomHuongLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgNhomHuongLuong));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtMa = new DevExpress.XtraEditors.TextEdit();
            this.lblMa = new DevExpress.XtraEditors.LabelControl();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.lblNhomHuongLuong = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Size = new System.Drawing.Size(749, 86);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(623, 35);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 43);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(232, 114);
            this.txtMa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMa.Name = "txtMa";
            this.txtMa.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Properties.Appearance.Options.UseFont = true;
            this.txtMa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtMa.Size = new System.Drawing.Size(229, 30);
            this.txtMa.TabIndex = 0;
            // 
            // lblMa
            // 
            this.lblMa.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.lblMa.Location = new System.Drawing.Point(35, 119);
            this.lblMa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 0);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(30, 25);
            this.lblMa.TabIndex = 11;
            this.lblMa.Text = "Mã";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(232, 158);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Properties.Appearance.Options.UseFont = true;
            this.txtTen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTen.Size = new System.Drawing.Size(501, 32);
            this.txtTen.TabIndex = 2;
            // 
            // lblNhomHuongLuong
            // 
            this.lblNhomHuongLuong.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.lblNhomHuongLuong.Location = new System.Drawing.Point(35, 162);
            this.lblNhomHuongLuong.Margin = new System.Windows.Forms.Padding(4, 3, 4, 0);
            this.lblNhomHuongLuong.Name = "lblNhomHuongLuong";
            this.lblNhomHuongLuong.Size = new System.Drawing.Size(169, 25);
            this.lblNhomHuongLuong.TabIndex = 11;
            this.lblNhomHuongLuong.Text = "Nhóm hưởng lương";
            // 
            // dlgNhomHuongLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 375);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lblNhomHuongLuong);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.txtTen);
            this.Form_Description = "Định nghĩa nhóm hưởng lương";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Định nghĩa nhóm hưởng lương";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgNhomHuongLuong";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDangKyCaLam_FormClosing);
            this.Load += new System.EventHandler(this.dlgNhomHuongLuong_Load);
            this.Controls.SetChildIndex(this.txtTen, 0);
            this.Controls.SetChildIndex(this.lblMa, 0);
            this.Controls.SetChildIndex(this.lblNhomHuongLuong, 0);
            this.Controls.SetChildIndex(this.txtMa, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.TextEdit txtMa;
        private DevExpress.XtraEditors.LabelControl lblMa;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.LabelControl lblNhomHuongLuong;
    }
}