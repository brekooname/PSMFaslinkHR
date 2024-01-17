namespace iHRM.Win.Frm.Luong_v3.BaoCao
{
    partial class frmDanhSachChiLuong
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
            this.checkEditChuyenKhoanNH = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditNhanTienMat = new DevExpress.XtraEditors.CheckEdit();
            this.lblTuKhoa = new DevExpress.XtraEditors.LabelControl();
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.lblPB = new DevExpress.XtraEditors.LabelControl();
            this.lblKyLuong = new DevExpress.XtraEditors.LabelControl();
            this.lblThang = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripBoDieuKien = new System.Windows.Forms.ToolStripButton();
            this.txtSearchThang = new DevExpress.XtraEditors.DateEdit();
            this.txtTuKhoaSearch = new DevExpress.XtraEditors.TextEdit();
            this.cmbKyLuong = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVaoLam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripXuatExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripKhoiTaoDuLieuCL = new System.Windows.Forms.ToolStripButton();
            this.toolStripXoaDuLieuCL = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditChuyenKhoanNH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditNhanTienMat.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuKhoaSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.checkEditChuyenKhoanNH);
            this.splitContainerControl1.Panel1.Controls.Add(this.checkEditNhanTienMat);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTuKhoa);
            this.splitContainerControl1.Panel1.Controls.Add(this.chonPhongBan1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPB);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblKyLuong);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblThang);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtSearchThang);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtTuKhoaSearch);
            this.splitContainerControl1.Panel1.Controls.Add(this.cmbKyLuong);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1237, 495);
            this.splitContainerControl1.SplitterPosition = 239;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // checkEditChuyenKhoanNH
            // 
            this.checkEditChuyenKhoanNH.Location = new System.Drawing.Point(3, 274);
            this.checkEditChuyenKhoanNH.Name = "checkEditChuyenKhoanNH";
            this.checkEditChuyenKhoanNH.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.checkEditChuyenKhoanNH.Properties.Appearance.Options.UseFont = true;
            this.checkEditChuyenKhoanNH.Properties.Caption = "Chuyển khoản ngân hàng";
            this.checkEditChuyenKhoanNH.Properties.RadioGroupIndex = 0;
            this.checkEditChuyenKhoanNH.Size = new System.Drawing.Size(179, 20);
            this.checkEditChuyenKhoanNH.TabIndex = 12;
            this.checkEditChuyenKhoanNH.TabStop = false;
            // 
            // checkEditNhanTienMat
            // 
            this.checkEditNhanTienMat.Location = new System.Drawing.Point(3, 248);
            this.checkEditNhanTienMat.Name = "checkEditNhanTienMat";
            this.checkEditNhanTienMat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.checkEditNhanTienMat.Properties.Appearance.Options.UseFont = true;
            this.checkEditNhanTienMat.Properties.Caption = "Nhận tiền mặt";
            this.checkEditNhanTienMat.Properties.RadioGroupIndex = 0;
            this.checkEditNhanTienMat.Size = new System.Drawing.Size(109, 20);
            this.checkEditNhanTienMat.TabIndex = 12;
            this.checkEditNhanTienMat.TabStop = false;
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblTuKhoa.Location = new System.Drawing.Point(3, 148);
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
            this.chonPhongBan1.Location = new System.Drawing.Point(3, 111);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(201, 28);
            this.chonPhongBan1.TabIndex = 9;
            // 
            // lblPB
            // 
            this.lblPB.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblPB.Location = new System.Drawing.Point(3, 95);
            this.lblPB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(60, 16);
            this.lblPB.TabIndex = 8;
            this.lblPB.Text = "Phòng ban";
            // 
            // lblKyLuong
            // 
            this.lblKyLuong.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblKyLuong.Location = new System.Drawing.Point(3, 201);
            this.lblKyLuong.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblKyLuong.Name = "lblKyLuong";
            this.lblKyLuong.Size = new System.Drawing.Size(49, 16);
            this.lblKyLuong.TabIndex = 3;
            this.lblKyLuong.Text = "Kỳ lương";
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
            this.toolStripBoDieuKien});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(205, 27);
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
            // toolStripBoDieuKien
            // 
            this.toolStripBoDieuKien.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStripBoDieuKien.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.toolStripBoDieuKien.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBoDieuKien.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBoDieuKien.Name = "toolStripBoDieuKien";
            this.toolStripBoDieuKien.Size = new System.Drawing.Size(101, 24);
            this.toolStripBoDieuKien.Text = "Bỏ điều kiện";
            this.toolStripBoDieuKien.Click += new System.EventHandler(this.toolStripButton4_Click);
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
            this.txtSearchThang.Size = new System.Drawing.Size(201, 22);
            this.txtSearchThang.TabIndex = 4;
            // 
            // txtTuKhoaSearch
            // 
            this.txtTuKhoaSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTuKhoaSearch.Location = new System.Drawing.Point(3, 165);
            this.txtTuKhoaSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtTuKhoaSearch.Name = "txtTuKhoaSearch";
            this.txtTuKhoaSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtTuKhoaSearch.Properties.Appearance.Options.UseFont = true;
            this.txtTuKhoaSearch.Size = new System.Drawing.Size(201, 22);
            this.txtTuKhoaSearch.TabIndex = 11;
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKyLuong.Location = new System.Drawing.Point(3, 220);
            this.cmbKyLuong.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cmbKyLuong.Properties.Appearance.Options.UseFont = true;
            this.cmbKyLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKyLuong.Properties.Items.AddRange(new object[] {
            "Đợt 1",
            "Đợt 2"});
            this.cmbKyLuong.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbKyLuong.Size = new System.Drawing.Size(201, 22);
            this.cmbKyLuong.TabIndex = 4;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 27);
            this.grd.MainView = this.gridView1;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemDateEdit1,
            this.repositoryItemCheckEdit1});
            this.grd.Size = new System.Drawing.Size(1027, 468);
            this.grd.TabIndex = 6;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeID,
            this.colEmployeeName,
            this.colNgayVaoLam,
            this.colPosName,
            this.colPB,
            this.colSoTien,
            this.colNote});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.grd;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
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
            this.colEmployeeID.VisibleIndex = 0;
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
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 258;
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
            this.colNgayVaoLam.VisibleIndex = 2;
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
            this.colPosName.VisibleIndex = 3;
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
            this.colPB.VisibleIndex = 4;
            this.colPB.Width = 163;
            // 
            // colSoTien
            // 
            this.colSoTien.AppearanceCell.BackColor = System.Drawing.Color.Pink;
            this.colSoTien.AppearanceCell.Options.UseBackColor = true;
            this.colSoTien.Caption = "Số tiền";
            this.colSoTien.ColumnEdit = this.repositoryItemCalcEdit1;
            this.colSoTien.DisplayFormat.FormatString = "#,0";
            this.colSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoTien.FieldName = "tongLuong";
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.OptionsColumn.AllowEdit = false;
            this.colSoTien.OptionsColumn.ReadOnly = true;
            this.colSoTien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoTien.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tongLuong", "Tổng = {0:#,0}", "Tổng lương")});
            this.colSoTien.Visible = true;
            this.colSoTien.VisibleIndex = 5;
            this.colSoTien.Width = 145;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi chú";
            this.colNote.FieldName = "ghichu";
            this.colNote.Name = "colNote";
            this.colNote.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 6;
            this.colNote.Width = 258;
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
            this.toolStripXuatExcel,
            this.toolStripKhoiTaoDuLieuCL,
            this.toolStripXoaDuLieuCL});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1027, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripXuatExcel
            // 
            this.toolStripXuatExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripXuatExcel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStripXuatExcel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripXuatExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripXuatExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripXuatExcel.Name = "toolStripXuatExcel";
            this.toolStripXuatExcel.Size = new System.Drawing.Size(87, 24);
            this.toolStripXuatExcel.Text = "Xuất excel";
            this.toolStripXuatExcel.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripKhoiTaoDuLieuCL
            // 
            this.toolStripKhoiTaoDuLieuCL.Image = global::iHRM.Win.Properties.Resources.ico20_arrow_down;
            this.toolStripKhoiTaoDuLieuCL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripKhoiTaoDuLieuCL.Name = "toolStripKhoiTaoDuLieuCL";
            this.toolStripKhoiTaoDuLieuCL.Size = new System.Drawing.Size(177, 24);
            this.toolStripKhoiTaoDuLieuCL.Text = "Khởi tạo dữ liệu chi lương";
            this.toolStripKhoiTaoDuLieuCL.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripXoaDuLieuCL
            // 
            this.toolStripXoaDuLieuCL.Image = global::iHRM.Win.Properties.Resources.btnDelete_Image;
            this.toolStripXoaDuLieuCL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripXoaDuLieuCL.Name = "toolStripXoaDuLieuCL";
            this.toolStripXoaDuLieuCL.Size = new System.Drawing.Size(153, 24);
            this.toolStripXoaDuLieuCL.Text = "Xóa dữ liệu chi lương";
            this.toolStripXoaDuLieuCL.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // frmDanhSachChiLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 495);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "frmDanhSachChiLuong";
            this.Text = "Danh sách chi lương";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDanhSachChiLuong_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditChuyenKhoanNH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditNhanTienMat.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuKhoaSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit txtSearchThang;
        private UC.ChonPhongBan chonPhongBan1;
        private DevExpress.XtraEditors.LabelControl lblPB;
        private DevExpress.XtraEditors.LabelControl lblTuKhoa;
        private DevExpress.XtraEditors.TextEdit txtTuKhoaSearch;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStripButton toolStripXuatExcel;
        private System.Windows.Forms.ToolStripButton toolStripBoDieuKien;
        private DevExpress.XtraEditors.CheckEdit checkEditChuyenKhoanNH;
        private DevExpress.XtraEditors.CheckEdit checkEditNhanTienMat;
        private DevExpress.XtraEditors.LabelControl lblKyLuong;
        private DevExpress.XtraEditors.ComboBoxEdit cmbKyLuong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVaoLam;
        private DevExpress.XtraGrid.Columns.GridColumn colPosName;
        private DevExpress.XtraGrid.Columns.GridColumn colPB;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTien;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private System.Windows.Forms.ToolStripButton toolStripKhoiTaoDuLieuCL;
        private System.Windows.Forms.ToolStripButton toolStripXoaDuLieuCL;
    }
}