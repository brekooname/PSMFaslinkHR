namespace iHRM.Win.Frm.Report
{
    partial class BCLogAction
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
            this.lookUpBangDL = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNguoiDung = new DevExpress.XtraEditors.LabelControl();
            this.lblBangDuLieu = new DevExpress.XtraEditors.LabelControl();
            this.searchLookUpNguoiSD = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.grcNVLamCa = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNguoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServerTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarget1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarget2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTableTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperationSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPAdress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomainName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOSVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripExcel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBangDL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpNguoiSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcNVLamCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
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
            this.splitContainerControl1.Panel2.Controls.Add(this.grcNVLamCa);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1580, 647);
            this.splitContainerControl1.SplitterPosition = 256;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lookUpBangDL);
            this.panel1.Controls.Add(this.lblNguoiDung);
            this.panel1.Controls.Add(this.lblBangDuLieu);
            this.panel1.Controls.Add(this.searchLookUpNguoiSD);
            this.panel1.Controls.Add(this.chonKyLuong1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 619);
            this.panel1.TabIndex = 6;
            // 
            // lookUpBangDL
            // 
            this.lookUpBangDL.Location = new System.Drawing.Point(5, 230);
            this.lookUpBangDL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.lookUpBangDL.Properties.DisplayMember = "TableTarget";
            this.lookUpBangDL.Properties.NullText = "Tất cả";
            this.lookUpBangDL.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpBangDL.Properties.ValueMember = "TableTarget";
            this.lookUpBangDL.Size = new System.Drawing.Size(293, 30);
            this.lookUpBangDL.TabIndex = 9;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDung.Location = new System.Drawing.Point(5, 132);
            this.lblNguoiDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(120, 22);
            this.lblNguoiDung.TabIndex = 8;
            this.lblNguoiDung.Text = "Người sử dụng";
            // 
            // lblBangDuLieu
            // 
            this.lblBangDuLieu.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBangDuLieu.Location = new System.Drawing.Point(5, 201);
            this.lblBangDuLieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblBangDuLieu.Name = "lblBangDuLieu";
            this.lblBangDuLieu.Size = new System.Drawing.Size(103, 22);
            this.lblBangDuLieu.TabIndex = 8;
            this.lblBangDuLieu.Text = "Bảng dữ liệu";
            // 
            // searchLookUpNguoiSD
            // 
            this.searchLookUpNguoiSD.EditValue = "Tất cả người dùng";
            this.searchLookUpNguoiSD.Location = new System.Drawing.Point(5, 160);
            this.searchLookUpNguoiSD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchLookUpNguoiSD.Name = "searchLookUpNguoiSD";
            this.searchLookUpNguoiSD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLookUpNguoiSD.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpNguoiSD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.searchLookUpNguoiSD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpNguoiSD.Properties.DisplayMember = "caption";
            this.searchLookUpNguoiSD.Properties.NullText = "Tất cả";
            this.searchLookUpNguoiSD.Properties.ValueMember = "id";
            this.searchLookUpNguoiSD.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpNguoiSD.Size = new System.Drawing.Size(293, 30);
            this.searchLookUpNguoiSD.TabIndex = 7;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.searchLookUpEdit1View.Appearance.HeaderPanel.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.searchLookUpEdit1View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.searchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.searchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "ID";
            this.gridColumn10.FieldName = "id";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 108;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Caption";
            this.gridColumn11.FieldName = "caption";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 390;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Email";
            this.gridColumn12.FieldName = "Email";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 350;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Is Admin";
            this.gridColumn13.FieldName = "isAdmin";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            this.gridColumn13.Width = 164;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 5, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(5, 6);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(201, 124);
            this.chonKyLuong1.TabIndex = 6;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 5, 1, 0, 0, 0, 0);
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
            this.toolStrip1.Size = new System.Drawing.Size(299, 28);
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
            this.btnFind.Size = new System.Drawing.Size(102, 25);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // grcNVLamCa
            // 
            this.grcNVLamCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcNVLamCa.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcNVLamCa.Location = new System.Drawing.Point(0, 28);
            this.grcNVLamCa.MainView = this.grv;
            this.grcNVLamCa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcNVLamCa.Name = "grcNVLamCa";
            this.grcNVLamCa.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grcNVLamCa.Size = new System.Drawing.Size(1276, 619);
            this.grcNVLamCa.TabIndex = 3;
            this.grcNVLamCa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.colUserID,
            this.colTenNguoiDung,
            this.colLogTime,
            this.colServerTime,
            this.colAction,
            this.colTarget1,
            this.colTarget2,
            this.colActionText,
            this.colTableTarget,
            this.colOperationSystem,
            this.colIPAdress,
            this.colDomainName,
            this.colVersion,
            this.colOSVersion,
            this.colMachineName});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grcNVLamCa;
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
            // colUserID
            // 
            this.colUserID.Caption = "ID User";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUserID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "UserID", "Tổng: {0:n0}")});
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 0;
            this.colUserID.Width = 98;
            // 
            // colTenNguoiDung
            // 
            this.colTenNguoiDung.Caption = "Tên người dùng";
            this.colTenNguoiDung.FieldName = "caption";
            this.colTenNguoiDung.Name = "colTenNguoiDung";
            this.colTenNguoiDung.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenNguoiDung.Visible = true;
            this.colTenNguoiDung.VisibleIndex = 1;
            this.colTenNguoiDung.Width = 173;
            // 
            // colLogTime
            // 
            this.colLogTime.Caption = "Thời gian";
            this.colLogTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colLogTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLogTime.FieldName = "LogTime";
            this.colLogTime.Name = "colLogTime";
            this.colLogTime.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLogTime.Visible = true;
            this.colLogTime.VisibleIndex = 2;
            this.colLogTime.Width = 147;
            // 
            // colServerTime
            // 
            this.colServerTime.Caption = "Thời gian Server";
            this.colServerTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colServerTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colServerTime.FieldName = "ServerTime";
            this.colServerTime.Name = "colServerTime";
            this.colServerTime.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colServerTime.Visible = true;
            this.colServerTime.VisibleIndex = 3;
            this.colServerTime.Width = 140;
            // 
            // colAction
            // 
            this.colAction.Caption = "Hành động";
            this.colAction.FieldName = "Action";
            this.colAction.Name = "colAction";
            this.colAction.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAction.Visible = true;
            this.colAction.VisibleIndex = 4;
            this.colAction.Width = 141;
            // 
            // colTarget1
            // 
            this.colTarget1.Caption = "Đối tượng 1";
            this.colTarget1.FieldName = "Target1";
            this.colTarget1.Name = "colTarget1";
            this.colTarget1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTarget1.Visible = true;
            this.colTarget1.VisibleIndex = 7;
            this.colTarget1.Width = 114;
            // 
            // colTarget2
            // 
            this.colTarget2.Caption = "Đối tượng 2";
            this.colTarget2.FieldName = "Target2";
            this.colTarget2.Name = "colTarget2";
            this.colTarget2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTarget2.Visible = true;
            this.colTarget2.VisibleIndex = 8;
            this.colTarget2.Width = 119;
            // 
            // colActionText
            // 
            this.colActionText.Caption = "Mô tả hành động";
            this.colActionText.FieldName = "ActionText";
            this.colActionText.Name = "colActionText";
            this.colActionText.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colActionText.Visible = true;
            this.colActionText.VisibleIndex = 6;
            this.colActionText.Width = 345;
            // 
            // colTableTarget
            // 
            this.colTableTarget.Caption = "Bảng dữ liệu";
            this.colTableTarget.FieldName = "TableTarget";
            this.colTableTarget.Name = "colTableTarget";
            this.colTableTarget.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTableTarget.Visible = true;
            this.colTableTarget.VisibleIndex = 5;
            this.colTableTarget.Width = 185;
            // 
            // colOperationSystem
            // 
            this.colOperationSystem.Caption = "Hệ điều hành";
            this.colOperationSystem.FieldName = "OperationSystem";
            this.colOperationSystem.Name = "colOperationSystem";
            this.colOperationSystem.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colOperationSystem.Visible = true;
            this.colOperationSystem.VisibleIndex = 12;
            this.colOperationSystem.Width = 111;
            // 
            // colIPAdress
            // 
            this.colIPAdress.Caption = "Địa chỉ IP";
            this.colIPAdress.FieldName = "IPAdress";
            this.colIPAdress.Name = "colIPAdress";
            this.colIPAdress.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIPAdress.Visible = true;
            this.colIPAdress.VisibleIndex = 10;
            this.colIPAdress.Width = 115;
            // 
            // colDomainName
            // 
            this.colDomainName.Caption = "Tên domain";
            this.colDomainName.FieldName = "DomainName";
            this.colDomainName.Name = "colDomainName";
            this.colDomainName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDomainName.Visible = true;
            this.colDomainName.VisibleIndex = 11;
            this.colDomainName.Width = 169;
            // 
            // colVersion
            // 
            this.colVersion.Caption = "Version sHRM";
            this.colVersion.FieldName = "sHRM_version";
            this.colVersion.Name = "colVersion";
            this.colVersion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVersion.Visible = true;
            this.colVersion.VisibleIndex = 14;
            this.colVersion.Width = 110;
            // 
            // colOSVersion
            // 
            this.colOSVersion.Caption = "Version OS";
            this.colOSVersion.FieldName = "OSVersion";
            this.colOSVersion.Name = "colOSVersion";
            this.colOSVersion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colOSVersion.Visible = true;
            this.colOSVersion.VisibleIndex = 13;
            this.colOSVersion.Width = 108;
            // 
            // colMachineName
            // 
            this.colMachineName.Caption = "Tên máy tính";
            this.colMachineName.FieldName = "MachineName";
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMachineName.Visible = true;
            this.colMachineName.VisibleIndex = 9;
            this.colMachineName.Width = 127;
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
            this.toolStripExcel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1276, 28);
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
            this.toolStripExcel.Size = new System.Drawing.Size(71, 25);
            this.toolStripExcel.Text = "Excel";
            this.toolStripExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // BCLogAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 647);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BCLogAction";
            this.Text = "Thống kê các hành động của người sử dụng ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCLogAction_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBangDL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpNguoiSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcNVLamCa)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grcNVLamCa;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colActionText;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNguoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colLogTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTableTarget;
        private DevExpress.XtraGrid.Columns.GridColumn colTarget1;
        private System.Windows.Forms.Panel panel1;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpNguoiSD;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl lblNguoiDung;
        private DevExpress.XtraEditors.LabelControl lblBangDuLieu;
        private DevExpress.XtraEditors.LookUpEdit lookUpBangDL;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn colServerTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTarget2;
        private DevExpress.XtraGrid.Columns.GridColumn colIPAdress;
        private DevExpress.XtraGrid.Columns.GridColumn colDomainName;
        private DevExpress.XtraGrid.Columns.GridColumn colVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colOSVersion;
    }
}