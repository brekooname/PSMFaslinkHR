namespace iHRM.Win.Frm.QuetThe.CongGia
{
    partial class frmLayDuLieu_Emp
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
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.SuspendLayout();
            // 
            // btnLayDuLieuThat
            // 
            this.btnLayDuLieuThat.Location = new System.Drawing.Point(529, 17);
            this.btnLayDuLieuThat.Name = "btnLayDuLieuThat";
            this.btnLayDuLieuThat.Size = new System.Drawing.Size(149, 35);
            this.btnLayDuLieuThat.TabIndex = 1;
            this.btnLayDuLieuThat.Text = "Lấy dữ liệu vân tay";
            this.btnLayDuLieuThat.Click += new System.EventHandler(this.btnLayDuLieuThat_Click);
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2020, 3, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = true;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(12, 12);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(159, 103);
            this.chonKyLuong1.TabIndex = 0;
            this.chonKyLuong1.TuNgay = new System.DateTime(2020, 3, 1, 0, 0, 0, 0);
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(178, 17);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(328, 154);
            this.ucChonDoiTuong_DS1.TabIndex = 8;
            // 
            // frmLayDuLieu_Emp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 261);
            this.Controls.Add(this.ucChonDoiTuong_DS1);
            this.Controls.Add(this.btnLayDuLieuThat);
            this.Controls.Add(this.chonKyLuong1);
            this.Name = "frmLayDuLieu_Emp";
            this.ShowIcon = false;
            this.Text = "Lấy dữ liệu công sang báo cáo";
            this.Load += new System.EventHandler(this.frmLayDuLieu_Emp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.SimpleButton btnLayDuLieuThat;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
    }
}