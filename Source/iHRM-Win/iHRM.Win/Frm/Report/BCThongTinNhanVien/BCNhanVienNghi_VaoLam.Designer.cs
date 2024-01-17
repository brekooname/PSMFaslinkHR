namespace iHRM.Win.Frm.Report
{
    partial class BCNhanVienNghi_VaoLam
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.lookupTimKiem = new DevExpress.XtraEditors.LookUpEdit();
            this.lookupGioiTinh = new DevExpress.XtraEditors.LookUpEdit();
            this.lblGioiTinh = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssuePlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaTheChamCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVaoLam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNghiLam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeftTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripExcelATM = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTimKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupGioiTinh.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1362, 434);
            this.splitContainerControl1.SplitterPosition = 323;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucChonDoiTuong_DS1);
            this.panel1.Controls.Add(this.chonKyLuong1);
            this.panel1.Controls.Add(this.lookupTimKiem);
            this.panel1.Controls.Add(this.lookupGioiTinh);
            this.panel1.Controls.Add(this.lblGioiTinh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 409);
            this.panel1.TabIndex = 6;
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(3, 164);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(261, 150);
            this.ucChonDoiTuong_DS1.TabIndex = 14;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonKyLuong1.DenNgay = new System.DateTime(2022, 8, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(3, 3);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(150, 100);
            this.chonKyLuong1.TabIndex = 13;
            this.chonKyLuong1.TuNgay = new System.DateTime(2022, 8, 1, 0, 0, 0, 0);
            // 
            // lookupTimKiem
            // 
            this.lookupTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupTimKiem.Location = new System.Drawing.Point(1, 137);
            this.lookupTimKiem.Name = "lookupTimKiem";
            this.lookupTimKiem.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupTimKiem.Properties.Appearance.Options.UseFont = true;
            this.lookupTimKiem.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupTimKiem.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookupTimKiem.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupTimKiem.Properties.AppearanceDropDownHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lookupTimKiem.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lookupTimKiem.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
            this.lookupTimKiem.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookupTimKiem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lookupTimKiem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupTimKiem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("text", "Tìm kiếm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("value", "Giá trị", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lookupTimKiem.Properties.DisplayMember = "text";
            this.lookupTimKiem.Properties.DropDownRows = 3;
            this.lookupTimKiem.Properties.NullText = "";
            this.lookupTimKiem.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookupTimKiem.Properties.ValueMember = "value";
            this.lookupTimKiem.Size = new System.Drawing.Size(262, 26);
            this.lookupTimKiem.TabIndex = 9;
            // 
            // lookupGioiTinh
            // 
            this.lookupGioiTinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupGioiTinh.Location = new System.Drawing.Point(71, 104);
            this.lookupGioiTinh.Name = "lookupGioiTinh";
            this.lookupGioiTinh.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupGioiTinh.Properties.Appearance.Options.UseFont = true;
            this.lookupGioiTinh.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupGioiTinh.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookupGioiTinh.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupGioiTinh.Properties.AppearanceDropDownHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lookupGioiTinh.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lookupGioiTinh.Properties.AppearanceDropDownHeader.Options.UseTextOptions = true;
            this.lookupGioiTinh.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookupGioiTinh.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lookupGioiTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupGioiTinh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("text", "Giới tính"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("value", "Giá trị", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lookupGioiTinh.Properties.DisplayMember = "text";
            this.lookupGioiTinh.Properties.DropDownRows = 3;
            this.lookupGioiTinh.Properties.NullText = "";
            this.lookupGioiTinh.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookupGioiTinh.Properties.ValueMember = "value";
            this.lookupGioiTinh.Size = new System.Drawing.Size(192, 26);
            this.lookupGioiTinh.TabIndex = 8;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.Location = new System.Drawing.Point(3, 107);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(6, 3, 3, 0);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(61, 17);
            this.lblGioiTinh.TabIndex = 7;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(323, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(83, 22);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 25);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grd.Size = new System.Drawing.Size(1034, 409);
            this.grd.TabIndex = 3;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeID,
            this.colEmployeeName,
            this.colGioiTinh,
            this.colPB,
            this.colNgaySinh,
            this.colSoCMND,
            this.colIssueDate,
            this.colIssuePlace,
            this.colMaTheChamCong,
            this.colPosName,
            this.colNgayVaoLam,
            this.colNgayNghiLam,
            this.colLeftTypeName});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsSelection.MultiSelect = true;
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
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeID", "Tổng: {0:#,0}")});
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 0;
            this.colEmployeeID.Width = 81;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Nhân viên";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 179;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Caption = "Giới tính";
            this.colGioiTinh.FieldName = "SexID";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 2;
            // 
            // colPB
            // 
            this.colPB.Caption = "Phòng ban";
            this.colPB.FieldName = "DepName";
            this.colPB.Name = "colPB";
            this.colPB.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPB.Visible = true;
            this.colPB.VisibleIndex = 4;
            this.colPB.Width = 190;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày sinh";
            this.colNgaySinh.FieldName = "Birthday";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 5;
            this.colNgaySinh.Width = 110;
            // 
            // colSoCMND
            // 
            this.colSoCMND.Caption = "Số CMND/CCCD";
            this.colSoCMND.FieldName = "IDCard";
            this.colSoCMND.Name = "colSoCMND";
            this.colSoCMND.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoCMND.Visible = true;
            this.colSoCMND.VisibleIndex = 6;
            this.colSoCMND.Width = 126;
            // 
            // colIssueDate
            // 
            this.colIssueDate.Caption = "Ngày cấp CMND/CCCD";
            this.colIssueDate.FieldName = "IssueDate";
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIssueDate.Visible = true;
            this.colIssueDate.VisibleIndex = 7;
            this.colIssueDate.Width = 169;
            // 
            // colIssuePlace
            // 
            this.colIssuePlace.Caption = "Nơi cấp CMND/CCCD";
            this.colIssuePlace.FieldName = "IssuePlace";
            this.colIssuePlace.Name = "colIssuePlace";
            this.colIssuePlace.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIssuePlace.Visible = true;
            this.colIssuePlace.VisibleIndex = 8;
            this.colIssuePlace.Width = 200;
            // 
            // colMaTheChamCong
            // 
            this.colMaTheChamCong.Caption = "Mã thẻ chấm công";
            this.colMaTheChamCong.FieldName = "CardID";
            this.colMaTheChamCong.Name = "colMaTheChamCong";
            this.colMaTheChamCong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaTheChamCong.Width = 133;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Chức vụ";
            this.colPosName.FieldName = "PosName";
            this.colPosName.Name = "colPosName";
            this.colPosName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPosName.Visible = true;
            this.colPosName.VisibleIndex = 3;
            this.colPosName.Width = 168;
            // 
            // colNgayVaoLam
            // 
            this.colNgayVaoLam.Caption = "Ngày vào làm";
            this.colNgayVaoLam.FieldName = "AppliedDate";
            this.colNgayVaoLam.Name = "colNgayVaoLam";
            this.colNgayVaoLam.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayVaoLam.Visible = true;
            this.colNgayVaoLam.VisibleIndex = 10;
            this.colNgayVaoLam.Width = 143;
            // 
            // colNgayNghiLam
            // 
            this.colNgayNghiLam.Caption = "Ngày nghỉ làm";
            this.colNgayNghiLam.FieldName = "LeftDate";
            this.colNgayNghiLam.Name = "colNgayNghiLam";
            this.colNgayNghiLam.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayNghiLam.Visible = true;
            this.colNgayNghiLam.VisibleIndex = 9;
            this.colNgayNghiLam.Width = 119;
            // 
            // colLeftTypeName
            // 
            this.colLeftTypeName.Caption = "Loại nghỉ việc";
            this.colLeftTypeName.FieldName = "LeftTypeName";
            this.colLeftTypeName.Name = "colLeftTypeName";
            this.colLeftTypeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLeftTypeName.Visible = true;
            this.colLeftTypeName.VisibleIndex = 11;
            this.colLeftTypeName.Width = 135;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Xóa";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExcelATM,
            this.toolStripExcel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1034, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripExcel
            // 
            this.toolStripExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripExcel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripExcel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExcel.Name = "toolStripExcel";
            this.toolStripExcel.Size = new System.Drawing.Size(61, 22);
            this.toolStripExcel.Text = "Excel";
            this.toolStripExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripExcelATM
            // 
            this.toolStripExcelATM.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripExcelATM.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripExcelATM.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripExcelATM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExcelATM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExcelATM.Name = "toolStripExcelATM";
            this.toolStripExcelATM.Size = new System.Drawing.Size(95, 22);
            this.toolStripExcelATM.Text = "Excel ATM";
            this.toolStripExcelATM.Click += new System.EventHandler(this.toolStripExcelATM_Click);
            // 
            // BCNhanVienNghi_VaoLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 434);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "BCNhanVienNghi_VaoLam";
            this.Text = "BC nhân viên nghỉ - vào làm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCNhanVienNghi_VaoLam_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTimKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupGioiTinh.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripButton btnFind;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private System.Windows.Forms.ToolStripButton toolStripExcel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.GridControl grd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTheChamCong;
        private DevExpress.XtraGrid.Columns.GridColumn colPosName;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNghiLam;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colPB;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVaoLam;
        private DevExpress.XtraEditors.LabelControl lblGioiTinh;
        private DevExpress.XtraEditors.LookUpEdit lookupGioiTinh;
        private DevExpress.XtraEditors.LookUpEdit lookupTimKiem;
        private UC.ChonKyLuong chonKyLuong1;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraGrid.Columns.GridColumn colLeftTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colIssueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIssuePlace;
        private System.Windows.Forms.ToolStripButton toolStripExcelATM;
    }
}