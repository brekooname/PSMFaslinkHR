namespace iHRM.Win.Frm.Employee
{
    partial class frmTaiNanLaoDong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucChonDoiTuong_DS = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.rdAccept = new DevExpress.XtraEditors.RadioGroup();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripGoDuyet = new System.Windows.Forms.ToolStripButton();
            this.toolStripNotAccept = new System.Windows.Forms.ToolStripButton();
            this.toolStripAccept = new System.Windows.Forms.ToolStripButton();
            this.toolStripAcceptAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripGoDuyetChotCong = new System.Windows.Forms.ToolStripButton();
            this.toolStripNotAccept_DA = new System.Windows.Forms.ToolStripButton();
            this.toolStripAccept_DA = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLuu = new System.Windows.Forms.ToolStripButton();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.pageNavigator1 = new iHRM.Win.UC.PageNavigator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRowNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidNVBaoCao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenNVBaoCao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colboPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colchucVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngayBaoCaoTaiNan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsoTiepNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkhiNao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmucDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colquyTrinhXayRaTaiNan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldiaDiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colisAccept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluserAccept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemQLDuyet = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repItemTrinhDo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repItemLink1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repItemVTriTD = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repItemidDotTD = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdAccept.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemQLDuyet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemTrinhDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemLink1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemVTriTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemidDotTD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucChonDoiTuong_DS);
            this.panel1.Controls.Add(this.rdAccept);
            this.panel1.Controls.Add(this.chonKyLuong1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 502);
            this.panel1.TabIndex = 1;
            // 
            // ucChonDoiTuong_DS
            // 
            this.ucChonDoiTuong_DS.Location = new System.Drawing.Point(2, 134);
            this.ucChonDoiTuong_DS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS.Name = "ucChonDoiTuong_DS";
            this.ucChonDoiTuong_DS.radioSelected = 0;
            this.ucChonDoiTuong_DS.Size = new System.Drawing.Size(265, 150);
            this.ucChonDoiTuong_DS.TabIndex = 6;
            // 
            // rdAccept
            // 
            this.rdAccept.Location = new System.Drawing.Point(161, 32);
            this.rdAccept.Name = "rdAccept";
            this.rdAccept.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tất cả"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Đã duyệt"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Không duyệt")});
            this.rdAccept.Size = new System.Drawing.Size(100, 96);
            this.rdAccept.TabIndex = 5;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2022, 6, 30, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = true;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(2, 29);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(153, 99);
            this.chonKyLuong1.TabIndex = 4;
            this.chonKyLuong1.TuNgay = new System.DateTime(2022, 6, 1, 0, 0, 0, 0);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(267, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::iHRM.Win.Properties.Resources.btnRefresh_Image;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 24);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 24);
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIn,
            this.toolStripButton2,
            this.toolStripGoDuyet,
            this.toolStripNotAccept,
            this.toolStripAccept,
            this.toolStripAcceptAll,
            this.toolStripGoDuyetChotCong,
            this.toolStripNotAccept_DA,
            this.toolStripAccept_DA,
            this.toolStripDelete,
            this.toolStripLuu,
            this.btnThem,
            this.btnSua,
            this.btnXoa});
            this.toolStrip2.Location = new System.Drawing.Point(267, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1097, 27);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnIn
            // 
            this.btnIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.btnIn.Image = global::iHRM.Win.Properties.Resources.btnPrint_Image;
            this.btnIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(44, 24);
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(61, 24);
            this.toolStripButton2.Text = "Excel";
            // 
            // toolStripGoDuyet
            // 
            this.toolStripGoDuyet.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripGoDuyet.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.toolStripGoDuyet.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.toolStripGoDuyet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripGoDuyet.Name = "toolStripGoDuyet";
            this.toolStripGoDuyet.Size = new System.Drawing.Size(86, 24);
            this.toolStripGoDuyet.Text = "Gỡ duyệt";
            this.toolStripGoDuyet.Click += new System.EventHandler(this.toolStripGoDuyet_Click);
            // 
            // toolStripNotAccept
            // 
            this.toolStripNotAccept.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripNotAccept.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripNotAccept.Image = global::iHRM.Win.Properties.Resources.ico20_stop;
            this.toolStripNotAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNotAccept.Name = "toolStripNotAccept";
            this.toolStripNotAccept.Size = new System.Drawing.Size(107, 24);
            this.toolStripNotAccept.Text = "Không duyệt";
            this.toolStripNotAccept.Click += new System.EventHandler(this.toolStripNotAccept_Click);
            // 
            // toolStripAccept
            // 
            this.toolStripAccept.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripAccept.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripAccept.Image = global::iHRM.Win.Properties.Resources.ico20_tick;
            this.toolStripAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAccept.Name = "toolStripAccept";
            this.toolStripAccept.Size = new System.Drawing.Size(68, 24);
            this.toolStripAccept.Text = "Duyệt";
            this.toolStripAccept.ToolTipText = "Duyệt";
            this.toolStripAccept.Click += new System.EventHandler(this.toolStripAccept_Click);
            // 
            // toolStripAcceptAll
            // 
            this.toolStripAcceptAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripAcceptAll.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripAcceptAll.Image = global::iHRM.Win.Properties.Resources.ico20_tick;
            this.toolStripAcceptAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAcceptAll.Name = "toolStripAcceptAll";
            this.toolStripAcceptAll.Size = new System.Drawing.Size(105, 24);
            this.toolStripAcceptAll.Text = "Duyệt tất cả";
            this.toolStripAcceptAll.ToolTipText = "Duyệt tất cả";
            this.toolStripAcceptAll.Click += new System.EventHandler(this.toolStripAcceptAll_Click);
            // 
            // toolStripGoDuyetChotCong
            // 
            this.toolStripGoDuyetChotCong.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripGoDuyetChotCong.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.toolStripGoDuyetChotCong.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.toolStripGoDuyetChotCong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripGoDuyetChotCong.Name = "toolStripGoDuyetChotCong";
            this.toolStripGoDuyetChotCong.Size = new System.Drawing.Size(143, 24);
            this.toolStripGoDuyetChotCong.Text = "Gỡ duyệt chốt nghỉ";
            this.toolStripGoDuyetChotCong.Visible = false;
            // 
            // toolStripNotAccept_DA
            // 
            this.toolStripNotAccept_DA.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripNotAccept_DA.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripNotAccept_DA.Image = global::iHRM.Win.Properties.Resources.ico20_stop;
            this.toolStripNotAccept_DA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNotAccept_DA.Name = "toolStripNotAccept_DA";
            this.toolStripNotAccept_DA.Size = new System.Drawing.Size(164, 24);
            this.toolStripNotAccept_DA.Text = "Không duyệt chốt nghỉ";
            this.toolStripNotAccept_DA.Visible = false;
            // 
            // toolStripAccept_DA
            // 
            this.toolStripAccept_DA.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripAccept_DA.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripAccept_DA.Image = global::iHRM.Win.Properties.Resources.ico20_tick;
            this.toolStripAccept_DA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAccept_DA.Name = "toolStripAccept_DA";
            this.toolStripAccept_DA.Size = new System.Drawing.Size(125, 24);
            this.toolStripAccept_DA.Text = "Duyệt chốt nghỉ";
            this.toolStripAccept_DA.ToolTipText = "Duyệt chốt công";
            this.toolStripAccept_DA.Visible = false;
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDelete.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDelete.Image = global::iHRM.Win.Properties.Resources.btnDelete_Image;
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(74, 24);
            this.toolStripDelete.Text = "Xóa bỏ";
            this.toolStripDelete.Visible = false;
            // 
            // toolStripLuu
            // 
            this.toolStripLuu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLuu.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLuu.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.toolStripLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLuu.Name = "toolStripLuu";
            this.toolStripLuu.Size = new System.Drawing.Size(73, 24);
            this.toolStripLuu.Text = "Lưu lại";
            this.toolStripLuu.Click += new System.EventHandler(this.toolStripLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::iHRM.Win.Properties.Resources.ico20_new;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(66, 24);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::iHRM.Win.Properties.Resources.btnEdit_Image;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 24);
            this.btnSua.Text = "Cập nhật";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(74, 24);
            this.btnXoa.Text = "Xóa bỏ";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // pageNavigator1
            // 
            this.pageNavigator1.CurrentPage = 1;
            this.pageNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageNavigator1.Location = new System.Drawing.Point(267, 473);
            this.pageNavigator1.Margin = new System.Windows.Forms.Padding(4);
            this.pageNavigator1.MaximumSize = new System.Drawing.Size(4000, 29);
            this.pageNavigator1.MinimumSize = new System.Drawing.Size(400, 29);
            this.pageNavigator1.Name = "pageNavigator1";
            this.pageNavigator1.PageSize = 10;
            this.pageNavigator1.RecordCount = 0;
            this.pageNavigator1.Size = new System.Drawing.Size(1097, 29);
            this.pageNavigator1.TabIndex = 13;
            this.pageNavigator1.OnPageChange += new System.EventHandler(this.pageNavigator1_OnPageChange);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(267, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1097, 446);
            this.panel2.TabIndex = 14;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemQLDuyet,
            this.repItemTrinhDo,
            this.repItemLink1,
            this.repItemVTriTD,
            this.repItemidDotTD});
            this.grd.Size = new System.Drawing.Size(1097, 446);
            this.grd.TabIndex = 13;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            this.grd.DataSourceChanged += new System.EventHandler(this.grd_DataSourceChanged);
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
            this.colRowNum,
            this.colidNVBaoCao,
            this.coltenNVBaoCao,
            this.colboPhan,
            this.colchucVu,
            this.colngayBaoCaoTaiNan,
            this.colsoTiepNhan,
            this.colkhiNao,
            this.colmucDo,
            this.colquyTrinhXayRaTaiNan,
            this.coldiaDiem,
            this.colisAccept,
            this.coluserAccept});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grv_RowStyle);
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // colRowNum
            // 
            this.colRowNum.AppearanceHeader.Options.UseTextOptions = true;
            this.colRowNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRowNum.Caption = "STT";
            this.colRowNum.FieldName = "RowNum";
            this.colRowNum.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colRowNum.Name = "colRowNum";
            this.colRowNum.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colRowNum.Visible = true;
            this.colRowNum.VisibleIndex = 0;
            // 
            // colidNVBaoCao
            // 
            this.colidNVBaoCao.Caption = "Mã nhân viên";
            this.colidNVBaoCao.FieldName = "idNVBaoCao";
            this.colidNVBaoCao.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colidNVBaoCao.Name = "colidNVBaoCao";
            this.colidNVBaoCao.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colidNVBaoCao.Visible = true;
            this.colidNVBaoCao.VisibleIndex = 1;
            this.colidNVBaoCao.Width = 119;
            // 
            // coltenNVBaoCao
            // 
            this.coltenNVBaoCao.Caption = "Người báo cáo";
            this.coltenNVBaoCao.FieldName = "tenNVBaoCao";
            this.coltenNVBaoCao.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.coltenNVBaoCao.Name = "coltenNVBaoCao";
            this.coltenNVBaoCao.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltenNVBaoCao.Visible = true;
            this.coltenNVBaoCao.VisibleIndex = 2;
            this.coltenNVBaoCao.Width = 185;
            // 
            // colboPhan
            // 
            this.colboPhan.Caption = "Bộ phận báo cáo";
            this.colboPhan.FieldName = "boPhan";
            this.colboPhan.Name = "colboPhan";
            this.colboPhan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colboPhan.Visible = true;
            this.colboPhan.VisibleIndex = 4;
            this.colboPhan.Width = 224;
            // 
            // colchucVu
            // 
            this.colchucVu.Caption = "Chức vụ";
            this.colchucVu.FieldName = "chucVu";
            this.colchucVu.Name = "colchucVu";
            this.colchucVu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colchucVu.Visible = true;
            this.colchucVu.VisibleIndex = 5;
            this.colchucVu.Width = 236;
            // 
            // colngayBaoCaoTaiNan
            // 
            this.colngayBaoCaoTaiNan.AppearanceCell.Options.UseTextOptions = true;
            this.colngayBaoCaoTaiNan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colngayBaoCaoTaiNan.Caption = "Ngày báo cáo";
            this.colngayBaoCaoTaiNan.FieldName = "ngayBaoCaoTaiNan";
            this.colngayBaoCaoTaiNan.Name = "colngayBaoCaoTaiNan";
            this.colngayBaoCaoTaiNan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colngayBaoCaoTaiNan.Visible = true;
            this.colngayBaoCaoTaiNan.VisibleIndex = 6;
            this.colngayBaoCaoTaiNan.Width = 141;
            // 
            // colsoTiepNhan
            // 
            this.colsoTiepNhan.Caption = "Số tiếp nhận";
            this.colsoTiepNhan.FieldName = "soTiepNhan";
            this.colsoTiepNhan.Name = "colsoTiepNhan";
            this.colsoTiepNhan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colsoTiepNhan.Visible = true;
            this.colsoTiepNhan.VisibleIndex = 3;
            this.colsoTiepNhan.Width = 114;
            // 
            // colkhiNao
            // 
            this.colkhiNao.AppearanceCell.Options.UseTextOptions = true;
            this.colkhiNao.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colkhiNao.Caption = "Thời gian tai nạn";
            this.colkhiNao.FieldName = "khiNao";
            this.colkhiNao.Name = "colkhiNao";
            this.colkhiNao.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colkhiNao.Visible = true;
            this.colkhiNao.VisibleIndex = 7;
            this.colkhiNao.Width = 133;
            // 
            // colmucDo
            // 
            this.colmucDo.AppearanceCell.Options.UseTextOptions = true;
            this.colmucDo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colmucDo.Caption = "Mức độ";
            this.colmucDo.FieldName = "mucDo";
            this.colmucDo.Name = "colmucDo";
            this.colmucDo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colmucDo.Visible = true;
            this.colmucDo.VisibleIndex = 8;
            this.colmucDo.Width = 70;
            // 
            // colquyTrinhXayRaTaiNan
            // 
            this.colquyTrinhXayRaTaiNan.Caption = "Quy trình xảy ra";
            this.colquyTrinhXayRaTaiNan.FieldName = "quyTrinhXayRaTaiNan";
            this.colquyTrinhXayRaTaiNan.Name = "colquyTrinhXayRaTaiNan";
            this.colquyTrinhXayRaTaiNan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colquyTrinhXayRaTaiNan.Visible = true;
            this.colquyTrinhXayRaTaiNan.VisibleIndex = 9;
            this.colquyTrinhXayRaTaiNan.Width = 183;
            // 
            // coldiaDiem
            // 
            this.coldiaDiem.Caption = "Địa điểm";
            this.coldiaDiem.FieldName = "diaDiem";
            this.coldiaDiem.Name = "coldiaDiem";
            this.coldiaDiem.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coldiaDiem.Visible = true;
            this.coldiaDiem.VisibleIndex = 10;
            this.coldiaDiem.Width = 191;
            // 
            // colisAccept
            // 
            this.colisAccept.Caption = "Trạng thái";
            this.colisAccept.FieldName = "Accept";
            this.colisAccept.Name = "colisAccept";
            this.colisAccept.OptionsColumn.AllowEdit = false;
            this.colisAccept.OptionsColumn.ReadOnly = true;
            this.colisAccept.OptionsColumn.TabStop = false;
            this.colisAccept.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colisAccept.UnboundExpression = "IIF([isAccept] == 1,\'Đã duyệt\',IIF([isAccept] == 0,\'Không duyệt\',\'\'))";
            this.colisAccept.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colisAccept.Visible = true;
            this.colisAccept.VisibleIndex = 11;
            this.colisAccept.Width = 114;
            // 
            // coluserAccept
            // 
            this.coluserAccept.Caption = "Người duyệt";
            this.coluserAccept.ColumnEdit = this.repItemQLDuyet;
            this.coluserAccept.FieldName = "userAccept";
            this.coluserAccept.Name = "coluserAccept";
            this.coluserAccept.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coluserAccept.Visible = true;
            this.coluserAccept.VisibleIndex = 12;
            this.coluserAccept.Width = 238;
            // 
            // repItemQLDuyet
            // 
            this.repItemQLDuyet.AutoHeight = false;
            this.repItemQLDuyet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemQLDuyet.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("caption", "Tên")});
            this.repItemQLDuyet.DisplayMember = "caption";
            this.repItemQLDuyet.Name = "repItemQLDuyet";
            this.repItemQLDuyet.NullText = "";
            this.repItemQLDuyet.ValueMember = "id";
            // 
            // repItemTrinhDo
            // 
            this.repItemTrinhDo.AutoHeight = false;
            this.repItemTrinhDo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemTrinhDo.DisplayMember = "EducationType";
            this.repItemTrinhDo.Name = "repItemTrinhDo";
            this.repItemTrinhDo.NullText = "";
            this.repItemTrinhDo.ValueMember = "EducationID";
            // 
            // repItemLink1
            // 
            this.repItemLink1.AutoHeight = false;
            this.repItemLink1.Name = "repItemLink1";
            this.repItemLink1.NullText = "Xem File";
            // 
            // repItemVTriTD
            // 
            this.repItemVTriTD.AutoHeight = false;
            this.repItemVTriTD.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemVTriTD.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpTypeName", "Chức vụ")});
            this.repItemVTriTD.DisplayMember = "EmpTypeName";
            this.repItemVTriTD.Name = "repItemVTriTD";
            this.repItemVTriTD.NullText = "";
            this.repItemVTriTD.ValueMember = "EmpTypeID";
            // 
            // repItemidDotTD
            // 
            this.repItemidDotTD.AutoHeight = false;
            this.repItemidDotTD.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemidDotTD.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenDotTD", "Tên đợt")});
            this.repItemidDotTD.DisplayMember = "tenDotTD";
            this.repItemidDotTD.Name = "repItemidDotTD";
            this.repItemidDotTD.NullText = "";
            this.repItemidDotTD.ValueMember = "id";
            // 
            // frmTaiNanLaoDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 502);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pageNavigator1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmTaiNanLaoDong";
            this.Text = "Báo cáo tai nạn lao động";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTaiNanLaoDong_FormClosing);
            this.Load += new System.EventHandler(this.frmTaiNanLaoDong_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTaiNanLaoDong_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdAccept.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemQLDuyet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemTrinhDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemLink1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemVTriTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemidDotTD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS;
        private DevExpress.XtraEditors.RadioGroup rdAccept;
        private UC.ChonKyLuong chonKyLuong1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripGoDuyet;
        private System.Windows.Forms.ToolStripButton toolStripNotAccept;
        private System.Windows.Forms.ToolStripButton toolStripAccept;
        private System.Windows.Forms.ToolStripButton toolStripAcceptAll;
        private System.Windows.Forms.ToolStripButton toolStripGoDuyetChotCong;
        private System.Windows.Forms.ToolStripButton toolStripNotAccept_DA;
        private System.Windows.Forms.ToolStripButton toolStripAccept_DA;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripButton toolStripLuu;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnSua;
        private UC.PageNavigator pageNavigator1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colidNVBaoCao;
        private DevExpress.XtraGrid.Columns.GridColumn coltenNVBaoCao;
        private DevExpress.XtraGrid.Columns.GridColumn colboPhan;
        private DevExpress.XtraGrid.Columns.GridColumn colchucVu;
        private DevExpress.XtraGrid.Columns.GridColumn colngayBaoCaoTaiNan;
        private DevExpress.XtraGrid.Columns.GridColumn colsoTiepNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colkhiNao;
        private DevExpress.XtraGrid.Columns.GridColumn colmucDo;
        private DevExpress.XtraGrid.Columns.GridColumn colquyTrinhXayRaTaiNan;
        private DevExpress.XtraGrid.Columns.GridColumn coldiaDiem;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemQLDuyet;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemTrinhDo;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repItemLink1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemVTriTD;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemidDotTD;
        private DevExpress.XtraGrid.Columns.GridColumn colisAccept;
        private DevExpress.XtraGrid.Columns.GridColumn coluserAccept;
        private DevExpress.XtraGrid.Columns.GridColumn colRowNum;
        private System.Windows.Forms.ToolStripButton btnIn;

    }
}