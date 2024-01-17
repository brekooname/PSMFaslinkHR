﻿namespace iHRM.Win.Frm.Luong_v3
{
    partial class frmBangLuongThang_Tax
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblTuKhoa = new DevExpress.XtraEditors.LabelControl();
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.lblPB = new DevExpress.XtraEditors.LabelControl();
            this.lblThang = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripRemoveSearch = new System.Windows.Forms.ToolStripButton();
            this.txtSearchThang = new DevExpress.XtraEditors.DateEdit();
            this.txtTuKhoaSearch = new DevExpress.XtraEditors.TextEdit();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colEmployeeID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNgayVaoLam = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPosName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPB = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTongLuong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colPBThangTruoc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNote = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripDayLuongQuaThue = new System.Windows.Forms.ToolStripButton();
            this.toolStripDayQuaBaoCao = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuKhoaSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTuKhoa);
            this.splitContainerControl1.Panel1.Controls.Add(this.chonPhongBan1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPB);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblThang);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtSearchThang);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtTuKhoaSearch);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1279, 385);
            this.splitContainerControl1.SplitterPosition = 214;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblTuKhoa.Location = new System.Drawing.Point(3, 141);
            this.lblTuKhoa.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(47, 16);
            this.lblTuKhoa.TabIndex = 10;
            this.lblTuKhoa.Text = "Từ khóa";
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonPhongBan1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.chonPhongBan1.Location = new System.Drawing.Point(3, 104);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(180, 28);
            this.chonPhongBan1.TabIndex = 9;
            // 
            // lblPB
            // 
            this.lblPB.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblPB.Location = new System.Drawing.Point(3, 88);
            this.lblPB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(60, 16);
            this.lblPB.TabIndex = 8;
            this.lblPB.Text = "Phòng ban";
            // 
            // lblThang
            // 
            this.lblThang.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblThang.Location = new System.Drawing.Point(3, 42);
            this.lblThang.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(36, 16);
            this.lblThang.TabIndex = 3;
            this.lblThang.Text = "Tháng";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind,
            this.toolStripRemoveSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(183, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(81, 24);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripRemoveSearch
            // 
            this.toolStripRemoveSearch.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStripRemoveSearch.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.toolStripRemoveSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripRemoveSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRemoveSearch.Name = "toolStripRemoveSearch";
            this.toolStripRemoveSearch.Size = new System.Drawing.Size(101, 24);
            this.toolStripRemoveSearch.Text = "Bỏ điều kiện";
            this.toolStripRemoveSearch.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // txtSearchThang
            // 
            this.txtSearchThang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchThang.EditValue = null;
            this.txtSearchThang.Location = new System.Drawing.Point(3, 61);
            this.txtSearchThang.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtSearchThang.Name = "txtSearchThang";
            this.txtSearchThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtSearchThang.Properties.Appearance.Options.UseFont = true;
            this.txtSearchThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSearchThang.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSearchThang.Properties.DisplayFormat.FormatString = "MM - yyyy";
            this.txtSearchThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtSearchThang.Properties.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.txtSearchThang.Properties.Mask.EditMask = "MM - yyyy";
            this.txtSearchThang.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.txtSearchThang.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.txtSearchThang.Size = new System.Drawing.Size(180, 22);
            this.txtSearchThang.TabIndex = 4;
            // 
            // txtTuKhoaSearch
            // 
            this.txtTuKhoaSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTuKhoaSearch.Location = new System.Drawing.Point(3, 157);
            this.txtTuKhoaSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtTuKhoaSearch.Name = "txtTuKhoaSearch";
            this.txtTuKhoaSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtTuKhoaSearch.Properties.Appearance.Options.UseFont = true;
            this.txtTuKhoaSearch.Size = new System.Drawing.Size(180, 22);
            this.txtTuKhoaSearch.TabIndex = 11;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 27);
            this.grd.MainView = this.bandedGridView1;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemDateEdit1,
            this.repositoryItemCheckEdit1});
            this.grd.Size = new System.Drawing.Size(1091, 358);
            this.grd.TabIndex = 6;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.bandedGridView1.Appearance.BandPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.BandPanel.Options.UseTextOptions = true;
            this.bandedGridView1.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.bandedGridView1.Appearance.Row.Options.UseFont = true;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand1});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colEmployeeID,
            this.colEmployeeName,
            this.colNgayVaoLam,
            this.colPosName,
            this.colPB,
            this.colTongLuong,
            this.colNote,
            this.colPBThangTruoc});
            this.bandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.bandedGridView1.GridControl = this.grd;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.bandedGridView1.OptionsSelection.MultiSelect = true;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.OptionsView.ShowAutoFilterRow = true;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bandedGridView1_KeyDown);
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Nhân viên";
            this.gridBand2.Columns.Add(this.colEmployeeID);
            this.gridBand2.Columns.Add(this.colEmployeeName);
            this.gridBand2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 352;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Mã";
            this.colEmployeeID.FieldName = "nv_ma";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsColumn.AllowEdit = false;
            this.colEmployeeID.OptionsColumn.ReadOnly = true;
            this.colEmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "nv_ma", "Số NV = {0}")});
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.Width = 94;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Nhân viên";
            this.colEmployeeName.FieldName = "nv_ten";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.AllowEdit = false;
            this.colEmployeeName.OptionsColumn.ReadOnly = true;
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.Width = 258;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Thông tin";
            this.gridBand1.Columns.Add(this.colNgayVaoLam);
            this.gridBand1.Columns.Add(this.colPosName);
            this.gridBand1.Columns.Add(this.colPB);
            this.gridBand1.Columns.Add(this.colTongLuong);
            this.gridBand1.Columns.Add(this.colPBThangTruoc);
            this.gridBand1.Columns.Add(this.colNote);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 1;
            this.gridBand1.Width = 637;
            // 
            // colNgayVaoLam
            // 
            this.colNgayVaoLam.Caption = "Ngày vào làm";
            this.colNgayVaoLam.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayVaoLam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayVaoLam.FieldName = "nv_ngayvaolam";
            this.colNgayVaoLam.Name = "colNgayVaoLam";
            this.colNgayVaoLam.OptionsColumn.AllowEdit = false;
            this.colNgayVaoLam.OptionsColumn.ReadOnly = true;
            this.colNgayVaoLam.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayVaoLam.Visible = true;
            this.colNgayVaoLam.Width = 134;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Vị trí";
            this.colPosName.FieldName = "nv_chucvu";
            this.colPosName.Name = "colPosName";
            this.colPosName.OptionsColumn.AllowEdit = false;
            this.colPosName.OptionsColumn.ReadOnly = true;
            this.colPosName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPosName.Visible = true;
            this.colPosName.Width = 97;
            // 
            // colPB
            // 
            this.colPB.Caption = "Phòng ban";
            this.colPB.FieldName = "nv_phongban";
            this.colPB.Name = "colPB";
            this.colPB.OptionsColumn.AllowEdit = false;
            this.colPB.OptionsColumn.ReadOnly = true;
            this.colPB.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPB.Visible = true;
            this.colPB.Width = 163;
            // 
            // colTongLuong
            // 
            this.colTongLuong.AppearanceCell.BackColor = System.Drawing.Color.Pink;
            this.colTongLuong.AppearanceCell.Options.UseBackColor = true;
            this.colTongLuong.Caption = "Tổng lương";
            this.colTongLuong.ColumnEdit = this.repositoryItemCalcEdit1;
            this.colTongLuong.DisplayFormat.FormatString = "#,0";
            this.colTongLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTongLuong.FieldName = "tongLuong";
            this.colTongLuong.Name = "colTongLuong";
            this.colTongLuong.OptionsColumn.AllowEdit = false;
            this.colTongLuong.OptionsColumn.ReadOnly = true;
            this.colTongLuong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongLuong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tongLuong", "Tổng = {0:#,0}", "Tổng lương")});
            this.colTongLuong.Width = 145;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // colPBThangTruoc
            // 
            this.colPBThangTruoc.Caption = "Phòng ban tháng trước";
            this.colPBThangTruoc.FieldName = "nv_phongban";
            this.colPBThangTruoc.Name = "colPBThangTruoc";
            this.colPBThangTruoc.OptionsColumn.AllowEdit = false;
            this.colPBThangTruoc.OptionsColumn.ReadOnly = true;
            this.colPBThangTruoc.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPBThangTruoc.Visible = true;
            this.colPBThangTruoc.Width = 163;
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi chú";
            this.colNote.FieldName = "ghichu";
            this.colNote.Name = "colNote";
            this.colNote.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNote.Visible = true;
            this.colNote.Width = 80;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripDayLuongQuaThue,
            this.toolStripDayQuaBaoCao,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1091, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 24);
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripDayLuongQuaThue
            // 
            this.toolStripDayLuongQuaThue.Image = global::iHRM.Win.Properties.Resources.btnExport_Image;
            this.toolStripDayLuongQuaThue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDayLuongQuaThue.Name = "toolStripDayLuongQuaThue";
            this.toolStripDayLuongQuaThue.Size = new System.Drawing.Size(219, 24);
            this.toolStripDayLuongQuaThue.Text = "Đẩy dữ liệu thuế qua bảng lương";
            this.toolStripDayLuongQuaThue.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripDayQuaBaoCao
            // 
            this.toolStripDayQuaBaoCao.Image = global::iHRM.Win.Properties.Resources.btnExport_Image;
            this.toolStripDayQuaBaoCao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDayQuaBaoCao.Name = "toolStripDayQuaBaoCao";
            this.toolStripDayQuaBaoCao.Size = new System.Drawing.Size(268, 24);
            this.toolStripDayQuaBaoCao.Text = "Đẩy dữ liệu thuế qua bảng lương báo cáo";
            this.toolStripDayQuaBaoCao.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStripButton1.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(87, 24);
            this.toolStripButton1.Text = "Xuất excel";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // frmBangLuongThang_Tax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 385);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "frmBangLuongThang_Tax";
            this.Text = "Bảng thuế";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBangLuongThang_Tax_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuKhoaSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl lblThang;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.DateEdit txtSearchThang;
        private UC.ChonPhongBan chonPhongBan1;
        private DevExpress.XtraEditors.LabelControl lblPB;
        private DevExpress.XtraEditors.LabelControl lblTuKhoa;
        private DevExpress.XtraEditors.TextEdit txtTuKhoaSearch;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNgayVaoLam;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPosName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPB;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTongLuong;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStripButton toolStripRemoveSearch;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripDayLuongQuaThue;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPBThangTruoc;
        private System.Windows.Forms.ToolStripButton toolStripDayQuaBaoCao;
    }
}