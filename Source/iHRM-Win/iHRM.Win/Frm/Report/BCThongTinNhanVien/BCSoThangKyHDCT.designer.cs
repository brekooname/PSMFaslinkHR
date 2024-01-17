﻿namespace iHRM.Win.Frm.Report
{
    partial class BCSoThangKyHDCT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCSoThangKyHDCT));
            this.pnControl = new DevExpress.XtraEditors.PanelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.grcBaoCaoSoThangKyHopDongChinhThuc = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName_Final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripExcel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnControl)).BeginInit();
            this.pnControl.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBaoCaoSoThangKyHopDongChinhThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnControl
            // 
            this.pnControl.Controls.Add(this.toolStrip1);
            this.pnControl.Controls.Add(this.chonKyLuong1);
            this.pnControl.Controls.Add(this.ucChonDoiTuong_DS1);
            this.pnControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnControl.Location = new System.Drawing.Point(0, 0);
            this.pnControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnControl.Name = "pnControl";
            this.pnControl.Size = new System.Drawing.Size(309, 596);
            this.pnControl.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(305, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(102, 25);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 5, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(6, 31);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(175, 123);
            this.chonKyLuong1.TabIndex = 9;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 5, 1, 0, 0, 0, 0);
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(5, 158);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(303, 185);
            this.ucChonDoiTuong_DS1.TabIndex = 4;
            // 
            // grcBaoCaoSoThangKyHopDongChinhThuc
            // 
            this.grcBaoCaoSoThangKyHopDongChinhThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcBaoCaoSoThangKyHopDongChinhThuc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcBaoCaoSoThangKyHopDongChinhThuc.Location = new System.Drawing.Point(309, 28);
            this.grcBaoCaoSoThangKyHopDongChinhThuc.MainView = this.grv;
            this.grcBaoCaoSoThangKyHopDongChinhThuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcBaoCaoSoThangKyHopDongChinhThuc.Name = "grcBaoCaoSoThangKyHopDongChinhThuc";
            this.grcBaoCaoSoThangKyHopDongChinhThuc.Size = new System.Drawing.Size(1280, 568);
            this.grcBaoCaoSoThangKyHopDongChinhThuc.TabIndex = 0;
            this.grcBaoCaoSoThangKyHopDongChinhThuc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.ColumnPanelRowHeight = 25;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeID,
            this.colEmployeeName,
            this.colDepName_Final,
            this.colBeginDate,
            this.colEndDate,
            this.colContractTypeName,
            this.colPosName,
            this.colSoHopDong,
            this.colGioiTinh,
            this.colNgaySinh});
            this.grv.GridControl = this.grcBaoCaoSoThangKyHopDongChinhThuc;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsBehavior.ReadOnly = true;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Mã NV";
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeID", "Tổng: {0}")});
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 0;
            this.colEmployeeID.Width = 120;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Tên nhân viên";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 221;
            // 
            // colDepName_Final
            // 
            this.colDepName_Final.Caption = "Phòng ban";
            this.colDepName_Final.FieldName = "DepName_Final";
            this.colDepName_Final.Name = "colDepName_Final";
            this.colDepName_Final.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName_Final.Visible = true;
            this.colDepName_Final.VisibleIndex = 5;
            this.colDepName_Final.Width = 276;
            // 
            // colBeginDate
            // 
            this.colBeginDate.Caption = "Ngày bắt đầu";
            this.colBeginDate.FieldName = "BeginDate";
            this.colBeginDate.Name = "colBeginDate";
            this.colBeginDate.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBeginDate.Visible = true;
            this.colBeginDate.VisibleIndex = 8;
            this.colBeginDate.Width = 142;
            // 
            // colEndDate
            // 
            this.colEndDate.Caption = "Ngày kết thúc";
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 9;
            this.colEndDate.Width = 150;
            // 
            // colContractTypeName
            // 
            this.colContractTypeName.Caption = "Loại hợp đồng";
            this.colContractTypeName.FieldName = "ContractTypeName";
            this.colContractTypeName.Name = "colContractTypeName";
            this.colContractTypeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colContractTypeName.Visible = true;
            this.colContractTypeName.VisibleIndex = 6;
            this.colContractTypeName.Width = 242;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Chức vụ";
            this.colPosName.FieldName = "PosName";
            this.colPosName.Name = "colPosName";
            this.colPosName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPosName.Visible = true;
            this.colPosName.VisibleIndex = 4;
            this.colPosName.Width = 221;
            // 
            // colSoHopDong
            // 
            this.colSoHopDong.Caption = "Số hợp đồng";
            this.colSoHopDong.FieldName = "ContractID";
            this.colSoHopDong.Name = "colSoHopDong";
            this.colSoHopDong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoHopDong.Visible = true;
            this.colSoHopDong.VisibleIndex = 7;
            this.colSoHopDong.Width = 153;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Caption = "Giới tính";
            this.colGioiTinh.FieldName = "SexID";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 3;
            this.colGioiTinh.Width = 106;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày sinh";
            this.colNgaySinh.FieldName = "Birthday";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 2;
            this.colNgaySinh.Width = 98;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExcel});
            this.toolStrip2.Location = new System.Drawing.Point(309, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1280, 28);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripExcel
            // 
            this.toolStripExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripExcel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExcel.Image")));
            this.toolStripExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExcel.Name = "toolStripExcel";
            this.toolStripExcel.Size = new System.Drawing.Size(71, 25);
            this.toolStripExcel.Text = "Excel";
            this.toolStripExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // BCSoThangKyHDCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1589, 596);
            this.Controls.Add(this.grcBaoCaoSoThangKyHopDongChinhThuc);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.pnControl);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BCSoThangKyHDCT";
            this.Text = "Báo cáo số tháng ký hợp đồng chính thức";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaoCaoSoThangKyHopDongChinhThuc_FormClosed);
            this.Load += new System.EventHandler(this.BaoCaoSoThangKyHopDongChinhThuc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCSoThangKyHDCT_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnControl)).EndInit();
            this.pnControl.ResumeLayout(false);
            this.pnControl.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBaoCaoSoThangKyHopDongChinhThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnControl;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraGrid.GridControl grcBaoCaoSoThangKyHopDongChinhThuc;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colBeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colContractTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName_Final;
        private UC.ChonKyLuong chonKyLuong1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colPosName;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
    }
}