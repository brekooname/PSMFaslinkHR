namespace iHRM.Win.Frm.QuetThe.Tools
{
    partial class ConfigAttendane_BaoCaoTuan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigAttendane_BaoCaoTuan));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.ucProgress1 = new iHRM.Win.UC.ucProgress();
            this.btnCatQua4hTC = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoTieng = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTieng.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(701, 70);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(0, 71);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(403, 164);
            this.ucChonDoiTuong_DS1.TabIndex = 21;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2018, 4, 25, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(406, 71);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(163, 113);
            this.chonKyLuong1.TabIndex = 22;
            this.chonKyLuong1.TuNgay = new System.DateTime(2018, 3, 26, 0, 0, 0, 0);
            // 
            // ucProgress1
            // 
            this.ucProgress1.CurrentValue = 0;
            this.ucProgress1.Location = new System.Drawing.Point(8, 236);
            this.ucProgress1.Message = "";
            this.ucProgress1.Name = "ucProgress1";
            this.ucProgress1.Size = new System.Drawing.Size(682, 263);
            this.ucProgress1.Status = "Đang đăng ký 30/100";
            this.ucProgress1.TabIndex = 23;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Số tiếng: ";
            // 
            // txtSoTieng
            // 
            this.txtSoTieng.Location = new System.Drawing.Point(67, 4);
            this.txtSoTieng.Name = "txtSoTieng";
            this.txtSoTieng.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTieng.Properties.Appearance.Options.UseFont = true;
            this.txtSoTieng.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSoTieng.Size = new System.Drawing.Size(90, 26);
            this.txtSoTieng.TabIndex = 25;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtSoTieng);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.btnCatQua4hTC);
            this.panelControl1.Location = new System.Drawing.Point(407, 176);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(162, 73);
            this.panelControl1.TabIndex = 27;
            // 
            // ConfigAttendane_BaoCaoTuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 511);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ucProgress1);
            this.Controls.Add(this.chonKyLuong1);
            this.Controls.Add(this.ucChonDoiTuong_DS1);
            this.Form_Description = "Cắt dữ liệu chấm công";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Chỉnh sửa dữ liệu";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigAttendane_BaoCaoTuan";
            this.ShowIcon = false;
            this.Text = "Sửa lại dữ liệu tuần <= 60h";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDangKyCaLam_FormClosing);
            this.Load += new System.EventHandler(this.dlgDangKyCaLam_Load);
            this.Controls.SetChildIndex(this.ucChonDoiTuong_DS1, 0);
            this.Controls.SetChildIndex(this.chonKyLuong1, 0);
            this.Controls.SetChildIndex(this.ucProgress1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTieng.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private UC.ChonKyLuong chonKyLuong1;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private UC.ucProgress ucProgress1;
        private DevExpress.XtraEditors.SimpleButton btnCatQua4hTC;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtSoTieng;
        private System.Windows.Forms.Label label1;
    }
}