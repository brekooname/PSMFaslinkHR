namespace iHRM.Win.Frm.Report
{
    partial class BCThoiGianKyHD
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colHetHan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSoNgay = new DevExpress.XtraEditors.TextEdit();
            this.deThoiGian = new DevExpress.XtraEditors.DateEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSearch = new System.Windows.Forms.ToolStripButton();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoThangNgayTuNgayKi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeLam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripExcel = new System.Windows.Forms.ToolStripButton();
            this.lblTGXemBaoCao = new DevExpress.XtraEditors.LabelControl();
            this.lblSoNgayBatDau = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiGian.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiGian.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // colHetHan
            // 
            this.colHetHan.AppearanceCell.Options.UseTextOptions = true;
            this.colHetHan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHetHan.Caption = "Hêt Hạn";
            this.colHetHan.FieldName = "HetHan";
            this.colHetHan.Name = "colHetHan";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucChonDoiTuong_DS1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grd);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(1800, 875);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(0, 190);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(356, 185);
            this.ucChonDoiTuong_DS1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSoNgayBatDau);
            this.panel1.Controls.Add(this.lblTGXemBaoCao);
            this.panel1.Controls.Add(this.txtSoNgay);
            this.panel1.Controls.Add(this.deThoiGian);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 161);
            this.panel1.TabIndex = 6;
            // 
            // txtSoNgay
            // 
            this.txtSoNgay.Location = new System.Drawing.Point(16, 110);
            this.txtSoNgay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSoNgay.Name = "txtSoNgay";
            this.txtSoNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoNgay.Properties.Appearance.Options.UseFont = true;
            this.txtSoNgay.Size = new System.Drawing.Size(193, 30);
            this.txtSoNgay.TabIndex = 9;
            // 
            // deThoiGian
            // 
            this.deThoiGian.EditValue = null;
            this.deThoiGian.Location = new System.Drawing.Point(16, 42);
            this.deThoiGian.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deThoiGian.Name = "deThoiGian";
            this.deThoiGian.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deThoiGian.Properties.Appearance.Options.UseFont = true;
            this.deThoiGian.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deThoiGian.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deThoiGian.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deThoiGian.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deThoiGian.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deThoiGian.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deThoiGian.Size = new System.Drawing.Size(193, 30);
            this.deThoiGian.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(356, 29);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSearch
            // 
            this.toolStripSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripSearch.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.toolStripSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSearch.Name = "toolStripSearch";
            this.toolStripSearch.Size = new System.Drawing.Size(109, 26);
            this.toolStripSearch.Text = "Tìm kiếm";
            this.toolStripSearch.Click += new System.EventHandler(this.toolStripSearch_Click);
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grd.Location = new System.Drawing.Point(0, 29);
            this.grd.MainView = this.grv;
            this.grd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(1439, 846);
            this.grd.TabIndex = 1;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNV,
            this.colTenNV,
            this.colNgaySinh,
            this.colCMND,
            this.colGioiTinh,
            this.colLoaiNV,
            this.colPhongBan,
            this.colLoaiHopDong,
            this.colSoHopDong,
            this.colNgayBatDau,
            this.colNgayKetThuc,
            this.colSoThangNgayTuNgayKi,
            this.colTimeLam,
            this.colHetHan});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colHetHan;
            gridFormatRule1.Name = "HetHan";
            formatConditionRuleValue1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "1";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.grv.FormatRules.Add(gridFormatRule1);
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // colMaNV
            // 
            this.colMaNV.AppearanceCell.Options.UseTextOptions = true;
            this.colMaNV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaNV.Caption = "Mã NV";
            this.colMaNV.FieldName = "EmployeeCode";
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeCode", "Tổng: {0:#,0}")});
            this.colMaNV.Visible = true;
            this.colMaNV.VisibleIndex = 0;
            this.colMaNV.Width = 80;
            // 
            // colTenNV
            // 
            this.colTenNV.Caption = "Tên nhân viên";
            this.colTenNV.FieldName = "EmployeeName";
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.Visible = true;
            this.colTenNV.VisibleIndex = 1;
            this.colTenNV.Width = 224;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.AppearanceCell.Options.UseTextOptions = true;
            this.colNgaySinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgaySinh.Caption = "Ngày sinh";
            this.colNgaySinh.FieldName = "Birthday";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 2;
            this.colNgaySinh.Width = 107;
            // 
            // colCMND
            // 
            this.colCMND.AppearanceCell.Options.UseTextOptions = true;
            this.colCMND.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCMND.Caption = "Số CMND";
            this.colCMND.FieldName = "IDCard";
            this.colCMND.Name = "colCMND";
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 4;
            this.colCMND.Width = 110;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.AppearanceCell.Options.UseTextOptions = true;
            this.colGioiTinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGioiTinh.Caption = "Giới tính";
            this.colGioiTinh.FieldName = "SexID";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 3;
            this.colGioiTinh.Width = 76;
            // 
            // colLoaiNV
            // 
            this.colLoaiNV.Caption = "Chức vụ";
            this.colLoaiNV.FieldName = "PosName";
            this.colLoaiNV.Name = "colLoaiNV";
            this.colLoaiNV.Visible = true;
            this.colLoaiNV.VisibleIndex = 5;
            this.colLoaiNV.Width = 246;
            // 
            // colPhongBan
            // 
            this.colPhongBan.Caption = "Phòng ban";
            this.colPhongBan.FieldName = "DepName";
            this.colPhongBan.Name = "colPhongBan";
            this.colPhongBan.Visible = true;
            this.colPhongBan.VisibleIndex = 6;
            this.colPhongBan.Width = 272;
            // 
            // colLoaiHopDong
            // 
            this.colLoaiHopDong.Caption = "Loại hợp đồng";
            this.colLoaiHopDong.FieldName = "ContractTypeName";
            this.colLoaiHopDong.Name = "colLoaiHopDong";
            this.colLoaiHopDong.Visible = true;
            this.colLoaiHopDong.VisibleIndex = 7;
            this.colLoaiHopDong.Width = 136;
            // 
            // colSoHopDong
            // 
            this.colSoHopDong.AppearanceCell.Options.UseTextOptions = true;
            this.colSoHopDong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoHopDong.Caption = "Số hợp đồng";
            this.colSoHopDong.FieldName = "ContractID";
            this.colSoHopDong.Name = "colSoHopDong";
            this.colSoHopDong.Visible = true;
            this.colSoHopDong.VisibleIndex = 8;
            this.colSoHopDong.Width = 214;
            // 
            // colNgayBatDau
            // 
            this.colNgayBatDau.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayBatDau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayBatDau.Caption = "Ngày bắt đầu";
            this.colNgayBatDau.FieldName = "BeginDate";
            this.colNgayBatDau.Name = "colNgayBatDau";
            this.colNgayBatDau.Visible = true;
            this.colNgayBatDau.VisibleIndex = 9;
            this.colNgayBatDau.Width = 107;
            // 
            // colNgayKetThuc
            // 
            this.colNgayKetThuc.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayKetThuc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayKetThuc.Caption = "Ngày kết thúc";
            this.colNgayKetThuc.FieldName = "EndDate";
            this.colNgayKetThuc.Name = "colNgayKetThuc";
            this.colNgayKetThuc.Visible = true;
            this.colNgayKetThuc.VisibleIndex = 10;
            this.colNgayKetThuc.Width = 105;
            // 
            // colSoThangNgayTuNgayKi
            // 
            this.colSoThangNgayTuNgayKi.AppearanceCell.Options.UseTextOptions = true;
            this.colSoThangNgayTuNgayKi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoThangNgayTuNgayKi.Caption = "Số ngày kể từ ngày bắt đầu";
            this.colSoThangNgayTuNgayKi.FieldName = "SoNgay";
            this.colSoThangNgayTuNgayKi.Name = "colSoThangNgayTuNgayKi";
            this.colSoThangNgayTuNgayKi.Width = 188;
            // 
            // colTimeLam
            // 
            this.colTimeLam.Caption = "Thời gian kể từ khi bắt đầu";
            this.colTimeLam.FieldName = "NgayThangNamLamDuoc";
            this.colTimeLam.Name = "colTimeLam";
            this.colTimeLam.Visible = true;
            this.colTimeLam.VisibleIndex = 11;
            this.colTimeLam.Width = 224;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExcel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1439, 29);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripExcel
            // 
            this.toolStripExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripExcel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExcel.Name = "toolStripExcel";
            this.toolStripExcel.Size = new System.Drawing.Size(79, 26);
            this.toolStripExcel.Text = "Excel";
            this.toolStripExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // lblTGXemBaoCao
            // 
            this.lblTGXemBaoCao.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTGXemBaoCao.Location = new System.Drawing.Point(15, 13);
            this.lblTGXemBaoCao.Name = "lblTGXemBaoCao";
            this.lblTGXemBaoCao.Size = new System.Drawing.Size(186, 22);
            this.lblTGXemBaoCao.TabIndex = 10;
            this.lblTGXemBaoCao.Text = "Thời gian xem báo cáo:";
            // 
            // lblSoNgayBatDau
            // 
            this.lblSoNgayBatDau.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoNgayBatDau.Location = new System.Drawing.Point(16, 81);
            this.lblSoNgayBatDau.Name = "lblSoNgayBatDau";
            this.lblSoNgayBatDau.Size = new System.Drawing.Size(215, 22);
            this.lblSoNgayBatDau.TabIndex = 11;
            this.lblSoNgayBatDau.Text = "Số ngày kể từ ngày bắt đầu:";
            // 
            // BCThoiGianKyHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 875);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BCThoiGianKyHD";
            this.Text = "BC thời gian kí hợp đồng";
            this.Load += new System.EventHandler(this.frmRPThoiGianKiHopDong_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCThoiGianKyHD_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiGian.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deThoiGian.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripSearch;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private System.Windows.Forms.ToolStripButton toolStripExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNV;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNV;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiNV;
        private DevExpress.XtraGrid.Columns.GridColumn colPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colSoThangNgayTuNgayKi;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeLam;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtSoNgay;
        private DevExpress.XtraEditors.DateEdit deThoiGian;
        private DevExpress.XtraGrid.Columns.GridColumn colHetHan;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraEditors.LabelControl lblSoNgayBatDau;
        private DevExpress.XtraEditors.LabelControl lblTGXemBaoCao;
    }
}