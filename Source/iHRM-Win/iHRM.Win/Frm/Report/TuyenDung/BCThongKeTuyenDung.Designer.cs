namespace iHRM.Win.Frm.Report
{
    partial class BCThongKeTuyenDung
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
            this.lblViTriUngTuyen = new DevExpress.XtraEditors.LabelControl();
            this.lookupViTriTD = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViTri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaTuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhanVienNghiViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhongNhanViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConThieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhanViec = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.SplitterPosition = 199;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chonKyLuong1);
            this.flowLayoutPanel1.Controls.Add(this.lblViTriUngTuyen);
            this.flowLayoutPanel1.Controls.Add(this.lookupViTriTD);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(199, 592);
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
            // lblViTriUngTuyen
            // 
            this.lblViTriUngTuyen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblViTriUngTuyen.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViTriUngTuyen.Location = new System.Drawing.Point(10, 136);
            this.lblViTriUngTuyen.Margin = new System.Windows.Forms.Padding(7, 4, 3, 0);
            this.lblViTriUngTuyen.Name = "lblViTriUngTuyen";
            this.lblViTriUngTuyen.Size = new System.Drawing.Size(133, 22);
            this.lblViTriUngTuyen.TabIndex = 62;
            this.lblViTriUngTuyen.Text = "Vị trí ứng tuyển";
            // 
            // lookupViTriTD
            // 
            this.lookupViTriTD.EditValue = "";
            this.lookupViTriTD.Location = new System.Drawing.Point(6, 162);
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
            this.lookupViTriTD.Size = new System.Drawing.Size(192, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(199, 28);
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
            this.grd.Size = new System.Drawing.Size(1300, 592);
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
            this.colPB,
            this.colViTri,
            this.colSoLuong,
            this.colDaTuyen,
            this.colNhanVienNghiViec,
            this.colKhongNhanViec,
            this.colConThieu,
            this.colNhanViec});
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
            this.colID.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.colID.Width = 44;
            // 
            // colPB
            // 
            this.colPB.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPB.AppearanceCell.Options.UseFont = true;
            this.colPB.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPB.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colPB.AppearanceHeader.Options.UseFont = true;
            this.colPB.AppearanceHeader.Options.UseTextOptions = true;
            this.colPB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPB.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPB.Caption = "Phòng ban";
            this.colPB.FieldName = "KhoiPhongBan";
            this.colPB.Name = "colPB";
            this.colPB.Visible = true;
            this.colPB.VisibleIndex = 1;
            this.colPB.Width = 290;
            // 
            // colViTri
            // 
            this.colViTri.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.colViTri.VisibleIndex = 2;
            this.colViTri.Width = 294;
            // 
            // colSoLuong
            // 
            this.colSoLuong.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSoLuong.AppearanceCell.Options.UseFont = true;
            this.colSoLuong.AppearanceCell.Options.UseTextOptions = true;
            this.colSoLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoLuong.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSoLuong.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colSoLuong.AppearanceHeader.Options.UseFont = true;
            this.colSoLuong.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoLuong.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.FieldName = "soLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 3;
            this.colSoLuong.Width = 109;
            // 
            // colDaTuyen
            // 
            this.colDaTuyen.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDaTuyen.AppearanceCell.Options.UseFont = true;
            this.colDaTuyen.AppearanceCell.Options.UseTextOptions = true;
            this.colDaTuyen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDaTuyen.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDaTuyen.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colDaTuyen.AppearanceHeader.Options.UseFont = true;
            this.colDaTuyen.Caption = "Đã tuyển";
            this.colDaTuyen.FieldName = "DaTuyen";
            this.colDaTuyen.Name = "colDaTuyen";
            this.colDaTuyen.Visible = true;
            this.colDaTuyen.VisibleIndex = 4;
            this.colDaTuyen.Width = 92;
            // 
            // colNhanVienNghiViec
            // 
            this.colNhanVienNghiViec.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNhanVienNghiViec.AppearanceCell.Options.UseFont = true;
            this.colNhanVienNghiViec.AppearanceCell.Options.UseTextOptions = true;
            this.colNhanVienNghiViec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNhanVienNghiViec.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNhanVienNghiViec.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colNhanVienNghiViec.AppearanceHeader.Options.UseFont = true;
            this.colNhanVienNghiViec.AppearanceHeader.Options.UseTextOptions = true;
            this.colNhanVienNghiViec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNhanVienNghiViec.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNhanVienNghiViec.Caption = "Nhân viên nghỉ việc";
            this.colNhanVienNghiViec.FieldName = "NhanVienNghiViec";
            this.colNhanVienNghiViec.Name = "colNhanVienNghiViec";
            this.colNhanVienNghiViec.Visible = true;
            this.colNhanVienNghiViec.VisibleIndex = 5;
            this.colNhanVienNghiViec.Width = 137;
            // 
            // colKhongNhanViec
            // 
            this.colKhongNhanViec.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colKhongNhanViec.AppearanceCell.Options.UseFont = true;
            this.colKhongNhanViec.AppearanceCell.Options.UseTextOptions = true;
            this.colKhongNhanViec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKhongNhanViec.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colKhongNhanViec.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colKhongNhanViec.AppearanceHeader.Options.UseFont = true;
            this.colKhongNhanViec.Caption = "Không nhận việc";
            this.colKhongNhanViec.FieldName = "KhongNhanViec";
            this.colKhongNhanViec.Name = "colKhongNhanViec";
            this.colKhongNhanViec.Visible = true;
            this.colKhongNhanViec.VisibleIndex = 6;
            this.colKhongNhanViec.Width = 146;
            // 
            // colConThieu
            // 
            this.colConThieu.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colConThieu.AppearanceCell.Options.UseFont = true;
            this.colConThieu.AppearanceCell.Options.UseTextOptions = true;
            this.colConThieu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colConThieu.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colConThieu.AppearanceHeader.Options.UseFont = true;
            this.colConThieu.Caption = "Còn thiếu";
            this.colConThieu.FieldName = "ConThieu";
            this.colConThieu.Name = "colConThieu";
            this.colConThieu.Visible = true;
            this.colConThieu.VisibleIndex = 7;
            this.colConThieu.Width = 102;
            // 
            // colNhanViec
            // 
            this.colNhanViec.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNhanViec.AppearanceCell.Options.UseFont = true;
            this.colNhanViec.AppearanceCell.Options.UseTextOptions = true;
            this.colNhanViec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNhanViec.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNhanViec.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colNhanViec.AppearanceHeader.Options.UseFont = true;
            this.colNhanViec.AppearanceHeader.Options.UseTextOptions = true;
            this.colNhanViec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNhanViec.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNhanViec.Caption = "Nhận việc";
            this.colNhanViec.FieldName = "NhanViec";
            this.colNhanViec.Name = "colNhanViec";
            this.colNhanViec.Visible = true;
            this.colNhanViec.VisibleIndex = 8;
            this.colNhanViec.Width = 108;
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
            this.toolStrip2.Size = new System.Drawing.Size(1300, 28);
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
            // BCThongKeTuyenDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 620);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BCThongKeTuyenDung";
            this.Text = "Thống kê tuyển dụng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCThongKeTuyenDung_KeyDown);
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
        private DevExpress.XtraGrid.Columns.GridColumn colPB;
        private DevExpress.XtraGrid.Columns.GridColumn colViTri;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colNhanViec;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraGrid.Columns.GridColumn colNhanVienNghiViec;
        private DevExpress.XtraGrid.Columns.GridColumn colDaTuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colKhongNhanViec;
        private DevExpress.XtraEditors.SearchLookUpEdit lookupViTriTD;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn colConThieu;
        private DevExpress.XtraEditors.LabelControl lblViTriUngTuyen;
    }
}