namespace iHRM.Win.Frm.LockTable
{
    partial class frmLockTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLockTable));
            this.lookUpBangDL = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnUnLock = new DevExpress.XtraEditors.SimpleButton();
            this.btnLock = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lookLoaiKhoa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBangDL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLoaiKhoa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpBangDL
            // 
            this.lookUpBangDL.Location = new System.Drawing.Point(22, 48);
            this.lookUpBangDL.Name = "lookUpBangDL";
            this.lookUpBangDL.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpBangDL.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpBangDL.Properties.Appearance.Options.UseFont = true;
            this.lookUpBangDL.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpBangDL.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookUpBangDL.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpBangDL.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lookUpBangDL.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
            this.lookUpBangDL.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUpBangDL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lookUpBangDL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpBangDL.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tableDisplay", "Tên bảng dữ liệu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tableName", "Name3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lookUpBangDL.Properties.DisplayMember = "tableDisplay";
            this.lookUpBangDL.Properties.NullText = "Chọn bảng";
            this.lookUpBangDL.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpBangDL.Properties.ValueMember = "tableName";
            this.lookUpBangDL.Size = new System.Drawing.Size(275, 26);
            this.lookUpBangDL.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(22, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 17);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Bảng dữ liệu";
            // 
            // btnUnLock
            // 
            this.btnUnLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnLock.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnLock.Appearance.Options.UseFont = true;
            this.btnUnLock.Image = ((System.Drawing.Image)(resources.GetObject("btnUnLock.Image")));
            this.btnUnLock.Location = new System.Drawing.Point(646, 114);
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Size = new System.Drawing.Size(100, 27);
            this.btnUnLock.TabIndex = 14;
            this.btnUnLock.Text = "Un-Lock";
            this.btnUnLock.Click += new System.EventHandler(this.btnUnLock_Click);
            // 
            // btnLock
            // 
            this.btnLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLock.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.Appearance.Options.UseFont = true;
            this.btnLock.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.Image")));
            this.btnLock.Location = new System.Drawing.Point(646, 81);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(100, 27);
            this.btnLock.TabIndex = 13;
            this.btnLock.Text = "Lock";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Location = new System.Drawing.Point(322, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 17);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Lưu ý:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Location = new System.Drawing.Point(324, 133);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(331, 17);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Khi mở khóa DBảng đăng ký ca làm hoặc làm thêm";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl4.Location = new System.Drawing.Point(324, 156);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(239, 17);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "phải mở khóa luôn CBảng công xử lý";
            // 
            // lookLoaiKhoa
            // 
            this.lookLoaiKhoa.Location = new System.Drawing.Point(22, 101);
            this.lookLoaiKhoa.Name = "lookLoaiKhoa";
            this.lookLoaiKhoa.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookLoaiKhoa.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookLoaiKhoa.Properties.Appearance.Options.UseFont = true;
            this.lookLoaiKhoa.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookLoaiKhoa.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookLoaiKhoa.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookLoaiKhoa.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lookLoaiKhoa.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
            this.lookLoaiKhoa.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookLoaiKhoa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lookLoaiKhoa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLoaiKhoa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LockID", "LockID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LockType", "Loại khóa")});
            this.lookLoaiKhoa.Properties.DisplayMember = "LockType";
            this.lookLoaiKhoa.Properties.NullText = "Chọn loại khóa";
            this.lookLoaiKhoa.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookLoaiKhoa.Properties.ValueMember = "LockID";
            this.lookLoaiKhoa.Size = new System.Drawing.Size(275, 26);
            this.lookLoaiKhoa.TabIndex = 19;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(22, 77);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 17);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "Loại khóa";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Location = new System.Drawing.Point(322, 87);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(251, 17);
            this.labelControl6.TabIndex = 20;
            this.labelControl6.Text = "Chỉ khóa đăng ký mới và quản lý duyệt";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl7.Location = new System.Drawing.Point(322, 110);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(158, 17);
            this.labelControl7.TabIndex = 21;
            this.labelControl7.Text = "ở các bảng đăng ký công";
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2018, 3, 25, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(22, 133);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(274, 99);
            this.chonKyLuong1.TabIndex = 12;
            this.chonKyLuong1.TuNgay = new System.DateTime(2018, 2, 26, 0, 0, 0, 0);
            // 
            // frmLockTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 370);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.lookLoaiKhoa);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnUnLock);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.chonKyLuong1);
            this.Controls.Add(this.lookUpBangDL);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmLockTable";
            this.ShowIcon = false;
            this.Text = "Khóa bảng dữ liệu";
            this.Load += new System.EventHandler(this.frmLockTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBangDL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLoaiKhoa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpBangDL;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.SimpleButton btnUnLock;
        private DevExpress.XtraEditors.SimpleButton btnLock;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lookLoaiKhoa;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}