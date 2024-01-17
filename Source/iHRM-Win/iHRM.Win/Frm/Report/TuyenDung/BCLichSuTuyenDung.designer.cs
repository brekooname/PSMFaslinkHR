namespace iHRM.Win.Frm.Report
{
    partial class BCLichSuTuyenDung
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.lblViTriTuyenDung = new DevExpress.XtraEditors.LabelControl();
            this.lookupViTriTD = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViTri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoSoNop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoSoBiLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoSoPhongVan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoSoPhongVanLan1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoSoPhongVanLan2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoSoChuaPhongVan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoSoPhongVanDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoSoNhanViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoSoChuaNhanViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripExcel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupViTriTD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
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
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1504, 620);
            this.splitContainerControl1.SplitterPosition = 186;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chonKyLuong1);
            this.flowLayoutPanel1.Controls.Add(this.lblViTriTuyenDung);
            this.flowLayoutPanel1.Controls.Add(this.lookupViTriTD);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(186, 592);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 5, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(8, 9);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(5);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(166, 118);
            this.chonKyLuong1.TabIndex = 6;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 5, 1, 0, 0, 0, 0);
            // 
            // lblViTriTuyenDung
            // 
            this.lblViTriTuyenDung.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViTriTuyenDung.Location = new System.Drawing.Point(6, 135);
            this.lblViTriTuyenDung.Name = "lblViTriTuyenDung";
            this.lblViTriTuyenDung.Size = new System.Drawing.Size(121, 21);
            this.lblViTriTuyenDung.TabIndex = 60;
            this.lblViTriTuyenDung.Text = "Vị trí ứng tuyển:";
            // 
            // lookupViTriTD
            // 
            this.lookupViTriTD.EditValue = "";
            this.lookupViTriTD.Location = new System.Drawing.Point(6, 163);
            this.lookupViTriTD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookupViTriTD.Name = "lookupViTriTD";
            this.lookupViTriTD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupViTriTD.Properties.Appearance.Options.UseFont = true;
            this.lookupViTriTD.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupViTriTD.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookupViTriTD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lookupViTriTD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupViTriTD.Properties.DisplayMember = "PosName";
            this.lookupViTriTD.Properties.NullText = "";
            this.lookupViTriTD.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookupViTriTD.Properties.ValueMember = "PosID";
            this.lookupViTriTD.Properties.View = this.searchLookUpEdit1View;
            this.lookupViTriTD.Size = new System.Drawing.Size(219, 30);
            this.lookupViTriTD.TabIndex = 61;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn14});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Mã";
            this.gridColumn13.FieldName = "PosID";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            this.gridColumn13.Width = 174;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Vị trí";
            this.gridColumn14.FieldName = "PosName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            this.gridColumn14.Width = 904;
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
            this.toolStrip1.Size = new System.Drawing.Size(186, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Location = new System.Drawing.Point(0, 28);
            this.grd.MainView = this.grv;
            this.grd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grd.Size = new System.Drawing.Size(1313, 592);
            this.grd.TabIndex = 3;
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
            this.colID,
            this.colViTri,
            this.colHoSoNop,
            this.colHoSoBiLoai,
            this.colHoSoPhongVan,
            this.colHoSoPhongVanLan1,
            this.colHoSoPhongVanLan2,
            this.colHoSoChuaPhongVan,
            this.colHoSoPhongVanDau,
            this.colHoSoNhanViec,
            this.colHoSoChuaNhanViec});
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
            // colID
            // 
            this.colID.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colID.AppearanceCell.Options.UseFont = true;
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colID.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "id";
            this.colID.Name = "colID";
            this.colID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "id", "Tổng: {0:#,0}")});
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 63;
            // 
            // colViTri
            // 
            this.colViTri.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colViTri.AppearanceCell.Options.UseFont = true;
            this.colViTri.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colViTri.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colViTri.AppearanceHeader.Options.UseFont = true;
            this.colViTri.AppearanceHeader.Options.UseTextOptions = true;
            this.colViTri.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colViTri.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colViTri.Caption = "Vị trí";
            this.colViTri.FieldName = "ViTri";
            this.colViTri.Name = "colViTri";
            this.colViTri.Visible = true;
            this.colViTri.VisibleIndex = 1;
            this.colViTri.Width = 271;
            // 
            // colHoSoNop
            // 
            this.colHoSoNop.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colHoSoNop.AppearanceCell.Options.UseFont = true;
            this.colHoSoNop.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoSoNop.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colHoSoNop.AppearanceHeader.Options.UseFont = true;
            this.colHoSoNop.AppearanceHeader.Options.UseTextOptions = true;
            this.colHoSoNop.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoNop.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHoSoNop.Caption = "Hồ sơ nộp";
            this.colHoSoNop.FieldName = "HoSoNop";
            this.colHoSoNop.Name = "colHoSoNop";
            this.colHoSoNop.Visible = true;
            this.colHoSoNop.VisibleIndex = 2;
            this.colHoSoNop.Width = 88;
            // 
            // colHoSoBiLoai
            // 
            this.colHoSoBiLoai.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colHoSoBiLoai.AppearanceCell.Options.UseFont = true;
            this.colHoSoBiLoai.AppearanceCell.Options.UseTextOptions = true;
            this.colHoSoBiLoai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoBiLoai.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoSoBiLoai.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colHoSoBiLoai.AppearanceHeader.Options.UseFont = true;
            this.colHoSoBiLoai.AppearanceHeader.Options.UseTextOptions = true;
            this.colHoSoBiLoai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoBiLoai.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHoSoBiLoai.Caption = "Hồ sơ bị loại";
            this.colHoSoBiLoai.FieldName = "HoSoFail";
            this.colHoSoBiLoai.Name = "colHoSoBiLoai";
            this.colHoSoBiLoai.Visible = true;
            this.colHoSoBiLoai.VisibleIndex = 3;
            this.colHoSoBiLoai.Width = 109;
            // 
            // colHoSoPhongVan
            // 
            this.colHoSoPhongVan.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colHoSoPhongVan.AppearanceCell.Options.UseFont = true;
            this.colHoSoPhongVan.AppearanceCell.Options.UseTextOptions = true;
            this.colHoSoPhongVan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoPhongVan.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoSoPhongVan.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colHoSoPhongVan.AppearanceHeader.Options.UseFont = true;
            this.colHoSoPhongVan.Caption = "Hồ sơ phỏng vấn";
            this.colHoSoPhongVan.FieldName = "HoSoChoPV";
            this.colHoSoPhongVan.Name = "colHoSoPhongVan";
            this.colHoSoPhongVan.Visible = true;
            this.colHoSoPhongVan.VisibleIndex = 4;
            this.colHoSoPhongVan.Width = 154;
            // 
            // colHoSoPhongVanLan1
            // 
            this.colHoSoPhongVanLan1.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colHoSoPhongVanLan1.AppearanceCell.Options.UseFont = true;
            this.colHoSoPhongVanLan1.AppearanceCell.Options.UseTextOptions = true;
            this.colHoSoPhongVanLan1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoPhongVanLan1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoSoPhongVanLan1.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colHoSoPhongVanLan1.AppearanceHeader.Options.UseFont = true;
            this.colHoSoPhongVanLan1.AppearanceHeader.Options.UseTextOptions = true;
            this.colHoSoPhongVanLan1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoPhongVanLan1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHoSoPhongVanLan1.Caption = "HS phỏng vấn lần 1";
            this.colHoSoPhongVanLan1.FieldName = "HoSoPhongVanLan1";
            this.colHoSoPhongVanLan1.Name = "colHoSoPhongVanLan1";
            this.colHoSoPhongVanLan1.Visible = true;
            this.colHoSoPhongVanLan1.VisibleIndex = 5;
            this.colHoSoPhongVanLan1.Width = 137;
            // 
            // colHoSoPhongVanLan2
            // 
            this.colHoSoPhongVanLan2.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colHoSoPhongVanLan2.AppearanceCell.Options.UseFont = true;
            this.colHoSoPhongVanLan2.AppearanceCell.Options.UseTextOptions = true;
            this.colHoSoPhongVanLan2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoPhongVanLan2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoSoPhongVanLan2.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colHoSoPhongVanLan2.AppearanceHeader.Options.UseFont = true;
            this.colHoSoPhongVanLan2.Caption = "HS phỏng vấn lần 2";
            this.colHoSoPhongVanLan2.FieldName = "HoSoPhongVanLan2";
            this.colHoSoPhongVanLan2.Name = "colHoSoPhongVanLan2";
            this.colHoSoPhongVanLan2.Visible = true;
            this.colHoSoPhongVanLan2.VisibleIndex = 6;
            this.colHoSoPhongVanLan2.Width = 146;
            // 
            // colHoSoChuaPhongVan
            // 
            this.colHoSoChuaPhongVan.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colHoSoChuaPhongVan.AppearanceCell.Options.UseFont = true;
            this.colHoSoChuaPhongVan.AppearanceCell.Options.UseTextOptions = true;
            this.colHoSoChuaPhongVan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoChuaPhongVan.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoSoChuaPhongVan.AppearanceHeader.Options.UseFont = true;
            this.colHoSoChuaPhongVan.Caption = "Hồ sơ chưa phỏng vấn";
            this.colHoSoChuaPhongVan.FieldName = "HoSoChuaPhongVan";
            this.colHoSoChuaPhongVan.Name = "colHoSoChuaPhongVan";
            this.colHoSoChuaPhongVan.Visible = true;
            this.colHoSoChuaPhongVan.VisibleIndex = 7;
            this.colHoSoChuaPhongVan.Width = 164;
            // 
            // colHoSoPhongVanDau
            // 
            this.colHoSoPhongVanDau.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colHoSoPhongVanDau.AppearanceCell.Options.UseFont = true;
            this.colHoSoPhongVanDau.AppearanceCell.Options.UseTextOptions = true;
            this.colHoSoPhongVanDau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoPhongVanDau.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoSoPhongVanDau.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colHoSoPhongVanDau.AppearanceHeader.Options.UseFont = true;
            this.colHoSoPhongVanDau.AppearanceHeader.Options.UseTextOptions = true;
            this.colHoSoPhongVanDau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoPhongVanDau.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHoSoPhongVanDau.Caption = "Hồ sơ phỏng vấn đậu";
            this.colHoSoPhongVanDau.FieldName = "HoSoPhongVanDau";
            this.colHoSoPhongVanDau.Name = "colHoSoPhongVanDau";
            this.colHoSoPhongVanDau.Visible = true;
            this.colHoSoPhongVanDau.VisibleIndex = 8;
            this.colHoSoPhongVanDau.Width = 189;
            // 
            // colHoSoNhanViec
            // 
            this.colHoSoNhanViec.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colHoSoNhanViec.AppearanceCell.Options.UseFont = true;
            this.colHoSoNhanViec.AppearanceCell.Options.UseTextOptions = true;
            this.colHoSoNhanViec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoNhanViec.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoSoNhanViec.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colHoSoNhanViec.AppearanceHeader.Options.UseFont = true;
            this.colHoSoNhanViec.AppearanceHeader.Options.UseTextOptions = true;
            this.colHoSoNhanViec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoNhanViec.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHoSoNhanViec.Caption = "Hồ sơ đã nhân việc";
            this.colHoSoNhanViec.FieldName = "HoSoDaNhanViec";
            this.colHoSoNhanViec.Name = "colHoSoNhanViec";
            this.colHoSoNhanViec.Visible = true;
            this.colHoSoNhanViec.VisibleIndex = 9;
            this.colHoSoNhanViec.Width = 147;
            // 
            // colHoSoChuaNhanViec
            // 
            this.colHoSoChuaNhanViec.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colHoSoChuaNhanViec.AppearanceCell.Options.UseFont = true;
            this.colHoSoChuaNhanViec.AppearanceCell.Options.UseTextOptions = true;
            this.colHoSoChuaNhanViec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoChuaNhanViec.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHoSoChuaNhanViec.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colHoSoChuaNhanViec.AppearanceHeader.Options.UseFont = true;
            this.colHoSoChuaNhanViec.AppearanceHeader.Options.UseTextOptions = true;
            this.colHoSoChuaNhanViec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoSoChuaNhanViec.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHoSoChuaNhanViec.Caption = "Hồ sơ chưa nhận việc";
            this.colHoSoChuaNhanViec.FieldName = "HoSoChuaNhanViec";
            this.colHoSoChuaNhanViec.Name = "colHoSoChuaNhanViec";
            this.colHoSoChuaNhanViec.Visible = true;
            this.colHoSoChuaNhanViec.VisibleIndex = 10;
            this.colHoSoChuaNhanViec.Width = 198;
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
            this.toolStrip2.Size = new System.Drawing.Size(1313, 28);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripExcel
            // 
            this.toolStripExcel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripExcel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExcel.Name = "toolStripExcel";
            this.toolStripExcel.Size = new System.Drawing.Size(71, 25);
            this.toolStripExcel.Text = "Excel";
            this.toolStripExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // BCLichSuTuyenDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 620);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BCLichSuTuyenDung";
            this.Text = "Báo cáo tình hình tuyển dụng của các vị trí";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCLichSuTuyenDung_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupViTriTD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colViTri;
        private DevExpress.XtraGrid.Columns.GridColumn colHoSoNop;
        private DevExpress.XtraGrid.Columns.GridColumn colHoSoBiLoai;
        private DevExpress.XtraGrid.Columns.GridColumn colHoSoPhongVanDau;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraGrid.Columns.GridColumn colHoSoPhongVanLan1;
        private DevExpress.XtraGrid.Columns.GridColumn colHoSoNhanViec;
        private DevExpress.XtraGrid.Columns.GridColumn colHoSoChuaNhanViec;
        private DevExpress.XtraGrid.Columns.GridColumn colHoSoPhongVan;
        private DevExpress.XtraGrid.Columns.GridColumn colHoSoPhongVanLan2;
        private DevExpress.XtraEditors.SearchLookUpEdit lookupViTriTD;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn colHoSoChuaPhongVan;
        private DevExpress.XtraEditors.LabelControl lblViTriTuyenDung;
    }
}