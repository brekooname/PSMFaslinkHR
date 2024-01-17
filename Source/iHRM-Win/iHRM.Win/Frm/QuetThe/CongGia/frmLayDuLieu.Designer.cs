namespace iHRM.Win.Frm.QuetThe.CongGia
{
    partial class frmLayDuLieu
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
            this.btnLayDuLieuThat = new DevExpress.XtraEditors.SimpleButton();
            this.lblPB = new DevExpress.XtraEditors.LabelControl();
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.SuspendLayout();
            // 
            // btnLayDuLieuThat
            // 
            this.btnLayDuLieuThat.Location = new System.Drawing.Point(178, 71);
            this.btnLayDuLieuThat.Name = "btnLayDuLieuThat";
            this.btnLayDuLieuThat.Size = new System.Drawing.Size(149, 35);
            this.btnLayDuLieuThat.TabIndex = 1;
            this.btnLayDuLieuThat.Text = "Lấy dữ liệu vân tay";
            this.btnLayDuLieuThat.Click += new System.EventHandler(this.btnLayDuLieuThat_Click);
            // 
            // lblPB
            // 
            this.lblPB.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPB.Location = new System.Drawing.Point(178, 10);
            this.lblPB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(67, 19);
            this.lblPB.TabIndex = 7;
            this.lblPB.Text = "Phòng ban:";
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonPhongBan1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chonPhongBan1.Location = new System.Drawing.Point(178, 29);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.chonPhongBan1.MaximumSize = new System.Drawing.Size(227, 26);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(227, 26);
            this.chonPhongBan1.TabIndex = 8;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 8, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = true;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(12, 12);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(159, 103);
            this.chonKyLuong1.TabIndex = 0;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 8, 1, 0, 0, 0, 0);
            // 
            // frmLayDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 261);
            this.Controls.Add(this.chonPhongBan1);
            this.Controls.Add(this.lblPB);
            this.Controls.Add(this.btnLayDuLieuThat);
            this.Controls.Add(this.chonKyLuong1);
            this.Name = "frmLayDuLieu";
            this.ShowIcon = false;
            this.Text = "Lấy dữ liệu công sang báo cáo";
            this.Load += new System.EventHandler(this.frmLayDuLieu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.SimpleButton btnLayDuLieuThat;
        private UC.ChonPhongBan chonPhongBan1;
        private DevExpress.XtraEditors.LabelControl lblPB;
    }
}