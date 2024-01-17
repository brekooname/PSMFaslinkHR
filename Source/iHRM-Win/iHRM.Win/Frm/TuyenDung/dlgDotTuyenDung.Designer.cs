namespace iHRM.Win.Frm.TuyenDung
{
    partial class dlgDotTuyenDung
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
            this.lookupTrangThai = new DevExpress.XtraEditors.LookUpEdit();
            this.txtChiPhiDuKien = new DevExpress.XtraEditors.TextEdit();
            this.txtSoLuongDuKien = new DevExpress.XtraEditors.TextEdit();
            this.dateNgayBD = new DevExpress.XtraEditors.DateEdit();
            this.dateNgayKT = new DevExpress.XtraEditors.DateEdit();
            this.memoYeuCauTuyenDung = new DevExpress.XtraEditors.MemoEdit();
            this.lblChiPhi = new DevExpress.XtraEditors.LabelControl();
            this.lblTrangThai = new DevExpress.XtraEditors.LabelControl();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.lblNgayKetThuc = new DevExpress.XtraEditors.LabelControl();
            this.lblNgayBatDau = new DevExpress.XtraEditors.LabelControl();
            this.txtTenDotTD = new DevExpress.XtraEditors.TextEdit();
            this.lblTenDot = new DevExpress.XtraEditors.LabelControl();
            this.lblSoChungTu = new DevExpress.XtraEditors.LabelControl();
            this.txtSoChungTu = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTrangThai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiPhiDuKien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongDuKien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKT.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoYeuCauTuyenDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDotTD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoChungTu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookupTrangThai
            // 
            this.lookupTrangThai.Enabled = false;
            this.lookupTrangThai.Location = new System.Drawing.Point(143, 187);
            this.lookupTrangThai.Name = "lookupTrangThai";
            this.lookupTrangThai.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupTrangThai.Properties.Appearance.Options.UseFont = true;
            this.lookupTrangThai.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lookupTrangThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupTrangThai.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Mã trạng thái"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Trạng thái thực hiện")});
            this.lookupTrangThai.Properties.DisplayMember = "Value";
            this.lookupTrangThai.Properties.NullText = "";
            this.lookupTrangThai.Properties.ValueMember = "Key";
            this.lookupTrangThai.Size = new System.Drawing.Size(448, 26);
            this.lookupTrangThai.TabIndex = 6;
            // 
            // txtChiPhiDuKien
            // 
            this.txtChiPhiDuKien.Location = new System.Drawing.Point(450, 154);
            this.txtChiPhiDuKien.Name = "txtChiPhiDuKien";
            this.txtChiPhiDuKien.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiPhiDuKien.Properties.Appearance.Options.UseFont = true;
            this.txtChiPhiDuKien.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtChiPhiDuKien.Properties.Mask.EditMask = "n0";
            this.txtChiPhiDuKien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtChiPhiDuKien.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtChiPhiDuKien.Size = new System.Drawing.Size(141, 26);
            this.txtChiPhiDuKien.TabIndex = 5;
            // 
            // txtSoLuongDuKien
            // 
            this.txtSoLuongDuKien.Location = new System.Drawing.Point(143, 154);
            this.txtSoLuongDuKien.Name = "txtSoLuongDuKien";
            this.txtSoLuongDuKien.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuongDuKien.Properties.Appearance.Options.UseFont = true;
            this.txtSoLuongDuKien.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSoLuongDuKien.Properties.Mask.EditMask = "n0";
            this.txtSoLuongDuKien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoLuongDuKien.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSoLuongDuKien.Size = new System.Drawing.Size(145, 26);
            this.txtSoLuongDuKien.TabIndex = 4;
            // 
            // dateNgayBD
            // 
            this.dateNgayBD.EditValue = null;
            this.dateNgayBD.Location = new System.Drawing.Point(143, 121);
            this.dateNgayBD.Name = "dateNgayBD";
            this.dateNgayBD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgayBD.Properties.Appearance.Options.UseFont = true;
            this.dateNgayBD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dateNgayBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayBD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayBD.Properties.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.dateNgayBD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dateNgayBD.Size = new System.Drawing.Size(145, 26);
            this.dateNgayBD.TabIndex = 2;
            this.dateNgayBD.EditValueChanged += new System.EventHandler(this.dateNgayBD_EditValueChanged);
            // 
            // dateNgayKT
            // 
            this.dateNgayKT.EditValue = null;
            this.dateNgayKT.Location = new System.Drawing.Point(450, 121);
            this.dateNgayKT.Name = "dateNgayKT";
            this.dateNgayKT.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgayKT.Properties.Appearance.Options.UseFont = true;
            this.dateNgayKT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dateNgayKT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayKT.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayKT.Properties.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.dateNgayKT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dateNgayKT.Size = new System.Drawing.Size(141, 26);
            this.dateNgayKT.TabIndex = 3;
            // 
            // memoYeuCauTuyenDung
            // 
            this.memoYeuCauTuyenDung.Location = new System.Drawing.Point(143, 221);
            this.memoYeuCauTuyenDung.Name = "memoYeuCauTuyenDung";
            this.memoYeuCauTuyenDung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memoYeuCauTuyenDung.Size = new System.Drawing.Size(448, 92);
            this.memoYeuCauTuyenDung.TabIndex = 7;
            // 
            // lblChiPhi
            // 
            this.lblChiPhi.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiPhi.Location = new System.Drawing.Point(318, 159);
            this.lblChiPhi.Name = "lblChiPhi";
            this.lblChiPhi.Size = new System.Drawing.Size(119, 17);
            this.lblChiPhi.TabIndex = 15;
            this.lblChiPhi.Text = "Tổng chi phí dự kiến";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(15, 192);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(117, 17);
            this.lblTrangThai.TabIndex = 12;
            this.lblTrangThai.Text = "Trạng thái thực hiện";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Location = new System.Drawing.Point(15, 223);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(45, 17);
            this.lblGhiChu.TabIndex = 13;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.Location = new System.Drawing.Point(15, 159);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(99, 17);
            this.lblSoLuong.TabIndex = 11;
            this.lblSoLuong.Text = "Số lượng dự kiến";
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKetThuc.Location = new System.Drawing.Point(318, 126);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(83, 17);
            this.lblNgayKetThuc.TabIndex = 14;
            this.lblNgayKetThuc.Text = "Ngày kết thúc";
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.Location = new System.Drawing.Point(15, 126);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(80, 17);
            this.lblNgayBatDau.TabIndex = 10;
            this.lblNgayBatDau.Text = "Ngày bắt đầu";
            // 
            // txtTenDotTD
            // 
            this.txtTenDotTD.Location = new System.Drawing.Point(143, 89);
            this.txtTenDotTD.Name = "txtTenDotTD";
            this.txtTenDotTD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDotTD.Properties.Appearance.Options.UseFont = true;
            this.txtTenDotTD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTenDotTD.Size = new System.Drawing.Size(448, 26);
            this.txtTenDotTD.TabIndex = 1;
            // 
            // lblTenDot
            // 
            this.lblTenDot.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDot.Location = new System.Drawing.Point(15, 93);
            this.lblTenDot.Name = "lblTenDot";
            this.lblTenDot.Size = new System.Drawing.Size(115, 17);
            this.lblTenDot.TabIndex = 9;
            this.lblTenDot.Text = "Tên đợt tuyển dụng";
            // 
            // lblSoChungTu
            // 
            this.lblSoChungTu.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoChungTu.Location = new System.Drawing.Point(15, 62);
            this.lblSoChungTu.Name = "lblSoChungTu";
            this.lblSoChungTu.Size = new System.Drawing.Size(71, 17);
            this.lblSoChungTu.TabIndex = 8;
            this.lblSoChungTu.Text = "Số chứng từ";
            // 
            // txtSoChungTu
            // 
            this.txtSoChungTu.Enabled = false;
            this.txtSoChungTu.Location = new System.Drawing.Point(143, 57);
            this.txtSoChungTu.Name = "txtSoChungTu";
            this.txtSoChungTu.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoChungTu.Properties.Appearance.Options.UseFont = true;
            this.txtSoChungTu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSoChungTu.Size = new System.Drawing.Size(448, 26);
            this.txtSoChungTu.TabIndex = 0;
            // 
            // dlgDotTuyenDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 321);
            this.Controls.Add(this.txtSoChungTu);
            this.Controls.Add(this.lookupTrangThai);
            this.Controls.Add(this.txtChiPhiDuKien);
            this.Controls.Add(this.txtSoLuongDuKien);
            this.Controls.Add(this.dateNgayBD);
            this.Controls.Add(this.dateNgayKT);
            this.Controls.Add(this.memoYeuCauTuyenDung);
            this.Controls.Add(this.lblChiPhi);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblNgayKetThuc);
            this.Controls.Add(this.lblNgayBatDau);
            this.Controls.Add(this.txtTenDotTD);
            this.Controls.Add(this.lblSoChungTu);
            this.Controls.Add(this.lblTenDot);
            this.KeyPreview = true;
            this.Name = "dlgDotTuyenDung";
            this.Text = "Thông tin đợt tuyển dụng";
            this.Load += new System.EventHandler(this.dlgTuyenDung_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dlgDotTuyenDung_KeyDown);
            this.Controls.SetChildIndex(this.lblTenDot, 0);
            this.Controls.SetChildIndex(this.lblSoChungTu, 0);
            this.Controls.SetChildIndex(this.txtTenDotTD, 0);
            this.Controls.SetChildIndex(this.lblNgayBatDau, 0);
            this.Controls.SetChildIndex(this.lblNgayKetThuc, 0);
            this.Controls.SetChildIndex(this.lblSoLuong, 0);
            this.Controls.SetChildIndex(this.lblGhiChu, 0);
            this.Controls.SetChildIndex(this.lblTrangThai, 0);
            this.Controls.SetChildIndex(this.lblChiPhi, 0);
            this.Controls.SetChildIndex(this.memoYeuCauTuyenDung, 0);
            this.Controls.SetChildIndex(this.dateNgayKT, 0);
            this.Controls.SetChildIndex(this.dateNgayBD, 0);
            this.Controls.SetChildIndex(this.txtSoLuongDuKien, 0);
            this.Controls.SetChildIndex(this.txtChiPhiDuKien, 0);
            this.Controls.SetChildIndex(this.lookupTrangThai, 0);
            this.Controls.SetChildIndex(this.txtSoChungTu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lookupTrangThai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChiPhiDuKien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongDuKien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKT.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoYeuCauTuyenDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDotTD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoChungTu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookupTrangThai;
        private DevExpress.XtraEditors.TextEdit txtChiPhiDuKien;
        private DevExpress.XtraEditors.TextEdit txtSoLuongDuKien;
        private DevExpress.XtraEditors.DateEdit dateNgayBD;
        private DevExpress.XtraEditors.DateEdit dateNgayKT;
        private DevExpress.XtraEditors.MemoEdit memoYeuCauTuyenDung;
        private DevExpress.XtraEditors.LabelControl lblChiPhi;
        private DevExpress.XtraEditors.LabelControl lblTrangThai;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
        private DevExpress.XtraEditors.LabelControl lblNgayKetThuc;
        private DevExpress.XtraEditors.LabelControl lblNgayBatDau;
        private DevExpress.XtraEditors.TextEdit txtTenDotTD;
        private DevExpress.XtraEditors.LabelControl lblTenDot;
        private DevExpress.XtraEditors.LabelControl lblSoChungTu;
        private DevExpress.XtraEditors.TextEdit txtSoChungTu;
    }
}