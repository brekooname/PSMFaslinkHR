namespace iHRM.Win.Frm.TuyenDung
{
    partial class frmDotTuyenDung
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.lblTuKhoa = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.grcDotTD = new DevExpress.XtraGrid.GridControl();
            this.grvDotTD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChiPhi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupTrangThaiTD = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemSearchLookUpViTri = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupDonViCongTac = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pageNavigator1 = new iHRM.Win.UC.PageNavigator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnThemNV = new System.Windows.Forms.ToolStripButton();
            this.toolExcel = new System.Windows.Forms.ToolStripButton();
            this.toolCapNhat = new System.Windows.Forms.ToolStripButton();
            this.toolXoa = new System.Windows.Forms.ToolStripButton();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDotTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDotTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTrangThaiTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpViTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDonViCongTac)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.chonKyLuong1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTuKhoa);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grcDotTD);
            this.splitContainerControl1.Panel2.Controls.Add(this.pageNavigator1);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1292, 425);
            this.splitContainerControl1.SplitterPosition = 164;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 5, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = true;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(6, 105);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(153, 99);
            this.chonKyLuong1.TabIndex = 0;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 5, 1, 0, 0, 0, 0);
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuKhoa.Location = new System.Drawing.Point(3, 51);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(60, 17);
            this.lblTuKhoa.TabIndex = 7;
            this.lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 71);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSearch.Size = new System.Drawing.Size(148, 26);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearchKey_Leave);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(164, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(85, 23);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // grcDotTD
            // 
            this.grcDotTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcDotTD.Location = new System.Drawing.Point(0, 27);
            this.grcDotTD.MainView = this.grvDotTD;
            this.grcDotTD.Name = "grcDotTD";
            this.grcDotTD.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemSearchLookUpViTri,
            this.lookupTrangThaiTD,
            this.lookupDonViCongTac});
            this.grcDotTD.Size = new System.Drawing.Size(1123, 369);
            this.grcDotTD.TabIndex = 3;
            this.grcDotTD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDotTD});
            this.grcDotTD.DataSourceChanged += new System.EventHandler(this.grd_DataSourceChanged);
            // 
            // grvDotTD
            // 
            this.grvDotTD.Appearance.EvenRow.BackColor = System.Drawing.Color.LemonChiffon;
            this.grvDotTD.Appearance.EvenRow.BackColor2 = System.Drawing.Color.LemonChiffon;
            this.grvDotTD.Appearance.EvenRow.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grvDotTD.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvDotTD.Appearance.EvenRow.Options.UseFont = true;
            this.grvDotTD.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.grvDotTD.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDotTD.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDotTD.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDotTD.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvDotTD.Appearance.OddRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvDotTD.Appearance.OddRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.grvDotTD.Appearance.OddRow.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grvDotTD.Appearance.OddRow.Options.UseBackColor = true;
            this.grvDotTD.Appearance.OddRow.Options.UseFont = true;
            this.grvDotTD.Appearance.SelectedRow.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grvDotTD.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDotTD.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GreenYellow;
            this.grvDotTD.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grvDotTD.AppearancePrint.EvenRow.Options.UseBackColor = true;
            this.grvDotTD.AppearancePrint.OddRow.BackColor = System.Drawing.Color.Khaki;
            this.grvDotTD.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grvDotTD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colTen,
            this.colNgayBatDau,
            this.colNgayKetThuc,
            this.colSoLuong,
            this.colChiPhi,
            this.colTrangThai});
            this.grvDotTD.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvDotTD.GridControl = this.grcDotTD;
            this.grvDotTD.Name = "grvDotTD";
            this.grvDotTD.OptionsBehavior.Editable = false;
            this.grvDotTD.OptionsView.ColumnAutoWidth = false;
            this.grvDotTD.OptionsView.EnableAppearanceEvenRow = true;
            this.grvDotTD.OptionsView.EnableAppearanceOddRow = true;
            this.grvDotTD.OptionsView.ShowAutoFilterRow = true;
            this.grvDotTD.OptionsView.ShowGroupPanel = false;
            this.grvDotTD.RowHeight = 26;
            this.grvDotTD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvDotTD_KeyDown);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "id";
            this.colID.Name = "colID";
            this.colID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên đợt tuyển dụng";
            this.colTen.FieldName = "tenDotTD";
            this.colTen.Name = "colTen";
            this.colTen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 1;
            this.colTen.Width = 252;
            // 
            // colNgayBatDau
            // 
            this.colNgayBatDau.Caption = "Ngày bắt đầu";
            this.colNgayBatDau.FieldName = "BeginDate";
            this.colNgayBatDau.Name = "colNgayBatDau";
            this.colNgayBatDau.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayBatDau.Visible = true;
            this.colNgayBatDau.VisibleIndex = 2;
            this.colNgayBatDau.Width = 110;
            // 
            // colNgayKetThuc
            // 
            this.colNgayKetThuc.Caption = "Ngày kết thúc";
            this.colNgayKetThuc.FieldName = "EndDate";
            this.colNgayKetThuc.Name = "colNgayKetThuc";
            this.colNgayKetThuc.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayKetThuc.Visible = true;
            this.colNgayKetThuc.VisibleIndex = 3;
            this.colNgayKetThuc.Width = 111;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số lượng dự kiến";
            this.colSoLuong.DisplayFormat.FormatString = "n0";
            this.colSoLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoLuong.FieldName = "soLuongDuKien";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 4;
            this.colSoLuong.Width = 121;
            // 
            // colChiPhi
            // 
            this.colChiPhi.Caption = "Chi phí dự kiến";
            this.colChiPhi.DisplayFormat.FormatString = "n0";
            this.colChiPhi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colChiPhi.FieldName = "chiPhiDuKien";
            this.colChiPhi.Name = "colChiPhi";
            this.colChiPhi.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colChiPhi.Visible = true;
            this.colChiPhi.VisibleIndex = 5;
            this.colChiPhi.Width = 111;
            // 
            // colTrangThai
            // 
            this.colTrangThai.Caption = "Trạng thái thực hiện";
            this.colTrangThai.ColumnEdit = this.lookupTrangThaiTD;
            this.colTrangThai.FieldName = "trangThaiThucHien";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTrangThai.Visible = true;
            this.colTrangThai.VisibleIndex = 6;
            this.colTrangThai.Width = 147;
            // 
            // lookupTrangThaiTD
            // 
            this.lookupTrangThaiTD.AutoHeight = false;
            this.lookupTrangThaiTD.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupTrangThaiTD.DisplayMember = "Value";
            this.lookupTrangThaiTD.Name = "lookupTrangThaiTD";
            this.lookupTrangThaiTD.NullText = "";
            this.lookupTrangThaiTD.ValueMember = "Key";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // repositoryItemSearchLookUpViTri
            // 
            this.repositoryItemSearchLookUpViTri.AutoHeight = false;
            this.repositoryItemSearchLookUpViTri.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpViTri.DisplayMember = "PosName";
            this.repositoryItemSearchLookUpViTri.Name = "repositoryItemSearchLookUpViTri";
            this.repositoryItemSearchLookUpViTri.NullText = "";
            this.repositoryItemSearchLookUpViTri.ValueMember = "PosID";
            this.repositoryItemSearchLookUpViTri.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.repositoryItemSearchLookUpEdit1View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemSearchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemSearchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Vị trí";
            this.gridColumn7.FieldName = "PosName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "ID";
            this.gridColumn8.FieldName = "id";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // lookupDonViCongTac
            // 
            this.lookupDonViCongTac.AutoHeight = false;
            this.lookupDonViCongTac.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupDonViCongTac.DisplayMember = "PosName";
            this.lookupDonViCongTac.Name = "lookupDonViCongTac";
            this.lookupDonViCongTac.NullText = "";
            this.lookupDonViCongTac.ValueMember = "PosID";
            // 
            // pageNavigator1
            // 
            this.pageNavigator1.CurrentPage = 1;
            this.pageNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageNavigator1.Location = new System.Drawing.Point(0, 396);
            this.pageNavigator1.MaximumSize = new System.Drawing.Size(4000, 29);
            this.pageNavigator1.MinimumSize = new System.Drawing.Size(400, 29);
            this.pageNavigator1.Name = "pageNavigator1";
            this.pageNavigator1.PageSize = 10;
            this.pageNavigator1.RecordCount = 0;
            this.pageNavigator1.Size = new System.Drawing.Size(1123, 29);
            this.pageNavigator1.TabIndex = 4;
            this.pageNavigator1.OnPageChange += new System.EventHandler(this.pageNavigator1_OnPageChange);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemNV,
            this.toolExcel,
            this.toolCapNhat,
            this.toolXoa});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1123, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnThemNV
            // 
            this.btnThemNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNV.Image = global::iHRM.Win.Properties.Resources.ico20_new;
            this.btnThemNV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnThemNV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(93, 24);
            this.btnThemNV.Text = "Thêm mới";
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click_Click);
            // 
            // toolExcel
            // 
            this.toolExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolExcel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExcel.Name = "toolExcel";
            this.toolExcel.Size = new System.Drawing.Size(62, 24);
            this.toolExcel.Text = "Excel";
            this.toolExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolCapNhat
            // 
            this.toolCapNhat.Image = global::iHRM.Win.Properties.Resources.btnEdit_Image;
            this.toolCapNhat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCapNhat.Name = "toolCapNhat";
            this.toolCapNhat.Size = new System.Drawing.Size(84, 24);
            this.toolCapNhat.Text = "Cập nhật";
            this.toolCapNhat.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolXoa
            // 
            this.toolXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolXoa.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.toolXoa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolXoa.Name = "toolXoa";
            this.toolXoa.Size = new System.Drawing.Size(79, 24);
            this.toolXoa.Text = "Xóa bỏ";
            this.toolXoa.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // frmDotTuyenDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 425);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "frmDotTuyenDung";
            this.ShowIcon = false;
            this.Text = "Danh sách các đợt tuyển dụng";
            this.Load += new System.EventHandler(this.frmDotTuyenDung_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDotTuyenDung_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDotTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDotTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTrangThaiTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpViTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDonViCongTac)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnThemNV;
        private System.Windows.Forms.ToolStripButton toolExcel;
        private System.Windows.Forms.ToolStripButton toolXoa;
        private DevExpress.XtraGrid.GridControl grcDotTD;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDotTD;
        private UC.PageNavigator pageNavigator1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpViTri;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colChiPhi;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.LabelControl lblTuKhoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupDonViCongTac;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupTrangThaiTD;
        private UC.ChonKyLuong chonKyLuong1;
        private System.Windows.Forms.ToolStripButton toolCapNhat;
    }
}