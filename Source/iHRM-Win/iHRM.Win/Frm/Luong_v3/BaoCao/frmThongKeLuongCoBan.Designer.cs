namespace iHRM.Win.Frm.Luong_v3.BaoCao
{
    partial class frmThongKeLuongCoBan
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtTuKhoaSearch = new DevExpress.XtraEditors.TextEdit();
            this.lblNam = new DevExpress.XtraEditors.LabelControl();
            this.lblTuKhoa = new DevExpress.XtraEditors.LabelControl();
            this.txtSearchNam = new DevExpress.XtraEditors.DateEdit();
            this.ucChonDoiTuong_DS = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVaoLam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripXuatTheoLuoi = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuKhoaSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchNam.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchNam.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
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
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1608, 767);
            this.splitContainerControl1.SplitterPosition = 281;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 318);
            this.panel1.TabIndex = 14;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtTuKhoaSearch);
            this.splitContainer1.Panel1.Controls.Add(this.lblNam);
            this.splitContainer1.Panel1.Controls.Add(this.lblTuKhoa);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchNam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucChonDoiTuong_DS);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(281, 318);
            this.splitContainer1.SplitterDistance = 103;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtTuKhoaSearch
            // 
            this.txtTuKhoaSearch.Location = new System.Drawing.Point(3, 20);
            this.txtTuKhoaSearch.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.txtTuKhoaSearch.Name = "txtTuKhoaSearch";
            this.txtTuKhoaSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtTuKhoaSearch.Properties.Appearance.Options.UseFont = true;
            this.txtTuKhoaSearch.Size = new System.Drawing.Size(281, 26);
            this.txtTuKhoaSearch.TabIndex = 11;
            // 
            // lblNam
            // 
            this.lblNam.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblNam.Location = new System.Drawing.Point(3, 47);
            this.lblNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(33, 19);
            this.lblNam.TabIndex = 12;
            this.lblNam.Text = "Năm";
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblTuKhoa.Location = new System.Drawing.Point(3, 1);
            this.lblTuKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(60, 21);
            this.lblTuKhoa.TabIndex = 10;
            this.lblTuKhoa.Text = "Từ khóa";
            // 
            // txtSearchNam
            // 
            this.txtSearchNam.EditValue = null;
            this.txtSearchNam.Location = new System.Drawing.Point(3, 70);
            this.txtSearchNam.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.txtSearchNam.Name = "txtSearchNam";
            this.txtSearchNam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtSearchNam.Properties.Appearance.Options.UseFont = true;
            this.txtSearchNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSearchNam.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSearchNam.Properties.DisplayFormat.FormatString = "yyyy";
            this.txtSearchNam.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtSearchNam.Properties.Mask.EditMask = "yyyy";
            this.txtSearchNam.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            this.txtSearchNam.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.txtSearchNam.Size = new System.Drawing.Size(194, 26);
            this.txtSearchNam.TabIndex = 13;
            // 
            // ucChonDoiTuong_DS
            // 
            this.ucChonDoiTuong_DS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChonDoiTuong_DS.Location = new System.Drawing.Point(0, 0);
            this.ucChonDoiTuong_DS.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ucChonDoiTuong_DS.Name = "ucChonDoiTuong_DS";
            this.ucChonDoiTuong_DS.radioSelected = 0;
            this.ucChonDoiTuong_DS.Size = new System.Drawing.Size(281, 211);
            this.ucChonDoiTuong_DS.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(281, 28);
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
            this.btnFind.Size = new System.Drawing.Size(98, 25);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStripButton4.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(125, 25);
            this.toolStripButton4.Text = "Bỏ điều kiện";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Location = new System.Drawing.Point(0, 28);
            this.grd.MainView = this.grv;
            this.grd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemDateEdit1,
            this.repositoryItemCheckEdit1});
            this.grd.Size = new System.Drawing.Size(1322, 739);
            this.grd.TabIndex = 6;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeID,
            this.colEmployeeName,
            this.colNgayVaoLam,
            this.colPosName,
            this.colPB,
            this.colThang1,
            this.colThang2,
            this.colThang3,
            this.colThang4,
            this.colThang5,
            this.colThang6,
            this.colThang7,
            this.colThang8,
            this.colThang9,
            this.colThang10,
            this.colThang11,
            this.colThang12,
            this.colTongLuong,
            this.colNote});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsDetail.EnableMasterViewMode = false;
            this.grv.OptionsSelection.MultiSelect = true;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Mã";
            this.colEmployeeID.FieldName = "EmployeeID";
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
            this.colEmployeeName.FieldName = "EmployeeName";
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
            // colThang1
            // 
            this.colThang1.Caption = "Tháng 1";
            this.colThang1.DisplayFormat.FormatString = "#,0";
            this.colThang1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang1.FieldName = "T1";
            this.colThang1.Name = "colThang1";
            this.colThang1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang1.Visible = true;
            this.colThang1.VisibleIndex = 5;
            // 
            // colThang2
            // 
            this.colThang2.Caption = "Tháng 2";
            this.colThang2.DisplayFormat.FormatString = "#,0";
            this.colThang2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang2.FieldName = "T2";
            this.colThang2.Name = "colThang2";
            this.colThang2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang2.Visible = true;
            this.colThang2.VisibleIndex = 6;
            // 
            // colThang3
            // 
            this.colThang3.Caption = "Tháng 3";
            this.colThang3.DisplayFormat.FormatString = "#,0";
            this.colThang3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang3.FieldName = "T3";
            this.colThang3.Name = "colThang3";
            this.colThang3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang3.Visible = true;
            this.colThang3.VisibleIndex = 7;
            // 
            // colThang4
            // 
            this.colThang4.Caption = "Tháng 4";
            this.colThang4.DisplayFormat.FormatString = "#,0";
            this.colThang4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang4.FieldName = "T4";
            this.colThang4.Name = "colThang4";
            this.colThang4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang4.Visible = true;
            this.colThang4.VisibleIndex = 8;
            // 
            // colThang5
            // 
            this.colThang5.Caption = "Tháng 5";
            this.colThang5.DisplayFormat.FormatString = "#,0";
            this.colThang5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang5.FieldName = "T5";
            this.colThang5.Name = "colThang5";
            this.colThang5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang5.Visible = true;
            this.colThang5.VisibleIndex = 9;
            // 
            // colThang6
            // 
            this.colThang6.Caption = "Tháng 6";
            this.colThang6.DisplayFormat.FormatString = "#,0";
            this.colThang6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang6.FieldName = "T6";
            this.colThang6.Name = "colThang6";
            this.colThang6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang6.Visible = true;
            this.colThang6.VisibleIndex = 10;
            // 
            // colThang7
            // 
            this.colThang7.Caption = "Tháng 7";
            this.colThang7.DisplayFormat.FormatString = "#,0";
            this.colThang7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang7.FieldName = "T7";
            this.colThang7.Name = "colThang7";
            this.colThang7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang7.Visible = true;
            this.colThang7.VisibleIndex = 11;
            // 
            // colThang8
            // 
            this.colThang8.Caption = "Tháng 8";
            this.colThang8.DisplayFormat.FormatString = "#,0";
            this.colThang8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang8.FieldName = "T8";
            this.colThang8.Name = "colThang8";
            this.colThang8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang8.Visible = true;
            this.colThang8.VisibleIndex = 12;
            // 
            // colThang9
            // 
            this.colThang9.Caption = "Tháng 9";
            this.colThang9.DisplayFormat.FormatString = "#,0";
            this.colThang9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang9.FieldName = "T9";
            this.colThang9.Name = "colThang9";
            this.colThang9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang9.Visible = true;
            this.colThang9.VisibleIndex = 13;
            // 
            // colThang10
            // 
            this.colThang10.Caption = "Tháng 10";
            this.colThang10.DisplayFormat.FormatString = "#,0";
            this.colThang10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang10.FieldName = "T10";
            this.colThang10.Name = "colThang10";
            this.colThang10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang10.Visible = true;
            this.colThang10.VisibleIndex = 14;
            // 
            // colThang11
            // 
            this.colThang11.Caption = "Tháng 11";
            this.colThang11.DisplayFormat.FormatString = "#,0";
            this.colThang11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang11.FieldName = "T11";
            this.colThang11.Name = "colThang11";
            this.colThang11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang11.Visible = true;
            this.colThang11.VisibleIndex = 15;
            // 
            // colThang12
            // 
            this.colThang12.Caption = "Tháng 12";
            this.colThang12.DisplayFormat.FormatString = "#,0";
            this.colThang12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colThang12.FieldName = "T12";
            this.colThang12.Name = "colThang12";
            this.colThang12.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThang12.Visible = true;
            this.colThang12.VisibleIndex = 16;
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
            this.colTongLuong.Visible = true;
            this.colTongLuong.VisibleIndex = 17;
            this.colTongLuong.Width = 145;
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
            this.colNote.Width = 80;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
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
            this.toolStripXuatTheoLuoi});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1322, 28);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripXuatTheoLuoi
            // 
            this.toolStripXuatTheoLuoi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripXuatTheoLuoi.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStripXuatTheoLuoi.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripXuatTheoLuoi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripXuatTheoLuoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripXuatTheoLuoi.Name = "toolStripXuatTheoLuoi";
            this.toolStripXuatTheoLuoi.Size = new System.Drawing.Size(134, 25);
            this.toolStripXuatTheoLuoi.Text = "Xuất theo lưới";
            this.toolStripXuatTheoLuoi.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // frmThongKeLuongCoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1608, 767);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmThongKeLuongCoBan";
            this.ShowIcon = false;
            this.Text = "Bảng tổng hợp lương cơ bản";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThongKeLuongCoBan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTuKhoaSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchNam.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchNam.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private DevExpress.XtraEditors.LabelControl lblTuKhoa;
        private DevExpress.XtraEditors.TextEdit txtTuKhoaSearch;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripXuatTheoLuoi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.LabelControl lblNam;
        private DevExpress.XtraEditors.DateEdit txtSearchNam;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVaoLam;
        private DevExpress.XtraGrid.Columns.GridColumn colPosName;
        private DevExpress.XtraGrid.Columns.GridColumn colPB;
        private DevExpress.XtraGrid.Columns.GridColumn colThang1;
        private DevExpress.XtraGrid.Columns.GridColumn colThang2;
        private DevExpress.XtraGrid.Columns.GridColumn colThang3;
        private DevExpress.XtraGrid.Columns.GridColumn colThang4;
        private DevExpress.XtraGrid.Columns.GridColumn colThang5;
        private DevExpress.XtraGrid.Columns.GridColumn colThang6;
        private DevExpress.XtraGrid.Columns.GridColumn colThang7;
        private DevExpress.XtraGrid.Columns.GridColumn colThang8;
        private DevExpress.XtraGrid.Columns.GridColumn colThang9;
        private DevExpress.XtraGrid.Columns.GridColumn colThang10;
        private DevExpress.XtraGrid.Columns.GridColumn colThang11;
        private DevExpress.XtraGrid.Columns.GridColumn colThang12;
        private DevExpress.XtraGrid.Columns.GridColumn colTongLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
    }
}