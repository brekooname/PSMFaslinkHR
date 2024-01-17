namespace iHRM.Win.Frm.Employee
{
    partial class frmGiayPhepLaoDong_v1
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
            this.txtSearchKey = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTInh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoGiayPhep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoHoChieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiLamViec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToChuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChucVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrinhDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnThemNV = new System.Windows.Forms.ToolStripButton();
            this.toolExcel = new System.Windows.Forms.ToolStripButton();
            this.btnCapNhat = new System.Windows.Forms.ToolStripButton();
            this.toolXoa = new System.Windows.Forms.ToolStripButton();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.txtSearchKey);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1354, 425);
            this.splitContainerControl1.SplitterPosition = 183;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 11, 30, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = true;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(5, 83);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(178, 99);
            this.chonKyLuong1.TabIndex = 5;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 11, 1, 0, 0, 0, 0);
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuKhoa.Location = new System.Drawing.Point(5, 29);
            this.lblTuKhoa.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(62, 19);
            this.lblTuKhoa.TabIndex = 3;
            this.lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchKey.Location = new System.Drawing.Point(5, 49);
            this.txtSearchKey.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchKey.Properties.Appearance.Options.UseFont = true;
            this.txtSearchKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSearchKey.Size = new System.Drawing.Size(177, 28);
            this.txtSearchKey.TabIndex = 4;
            this.txtSearchKey.Leave += new System.EventHandler(this.txtSearchKey_Leave);
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
            this.toolStrip1.Size = new System.Drawing.Size(183, 26);
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
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 27);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.grd.Size = new System.Drawing.Size(1166, 398);
            this.grd.TabIndex = 3;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            this.grd.DataSourceChanged += new System.EventHandler(this.grd_DataSourceChanged);
            // 
            // grv
            // 
            this.grv.Appearance.EvenRow.BackColor = System.Drawing.Color.LemonChiffon;
            this.grv.Appearance.EvenRow.BackColor2 = System.Drawing.Color.LemonChiffon;
            this.grv.Appearance.EvenRow.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grv.Appearance.EvenRow.Options.UseBackColor = true;
            this.grv.Appearance.EvenRow.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv.Appearance.OddRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grv.Appearance.OddRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.grv.Appearance.OddRow.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grv.Appearance.OddRow.Options.UseBackColor = true;
            this.grv.Appearance.OddRow.Options.UseFont = true;
            this.grv.Appearance.SelectedRow.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grv.Appearance.SelectedRow.Options.UseFont = true;
            this.grv.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GreenYellow;
            this.grv.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grv.AppearancePrint.EvenRow.Options.UseBackColor = true;
            this.grv.AppearancePrint.OddRow.BackColor = System.Drawing.Color.Khaki;
            this.grv.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colEmployeeID,
            this.colEmployeeName,
            this.colGioiTInh,
            this.colNgaySinh,
            this.colSoGiayPhep,
            this.colSoHoChieu,
            this.colNoiLamViec,
            this.colToChuc,
            this.colChucVu,
            this.colTrinhDo,
            this.colNgayBatDau,
            this.colNgayKetThuc,
            this.colNgayKy,
            this.colNoiKy});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.EnableAppearanceEvenRow = true;
            this.grv.OptionsView.EnableAppearanceOddRow = true;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.RowHeight = 26;
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "id";
            this.colId.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colId.Name = "colId";
            this.colId.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Mã NV";
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 1;
            this.colEmployeeID.Width = 67;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Họ tên";
            this.colEmployeeName.FieldName = "hoTen";
            this.colEmployeeName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "hoTen", "Tổng = {0:#,#}")});
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 2;
            this.colEmployeeName.Width = 180;
            // 
            // colGioiTInh
            // 
            this.colGioiTInh.Caption = "Giới tính";
            this.colGioiTInh.FieldName = "gioiTinh";
            this.colGioiTInh.Name = "colGioiTInh";
            this.colGioiTInh.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGioiTInh.Visible = true;
            this.colGioiTInh.VisibleIndex = 4;
            this.colGioiTInh.Width = 64;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày sinh";
            this.colNgaySinh.FieldName = "ngaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 3;
            this.colNgaySinh.Width = 76;
            // 
            // colSoGiayPhep
            // 
            this.colSoGiayPhep.Caption = "Số giấy phép";
            this.colSoGiayPhep.FieldName = "soGiayPhep";
            this.colSoGiayPhep.Name = "colSoGiayPhep";
            this.colSoGiayPhep.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoGiayPhep.Visible = true;
            this.colSoGiayPhep.VisibleIndex = 5;
            this.colSoGiayPhep.Width = 97;
            // 
            // colSoHoChieu
            // 
            this.colSoHoChieu.Caption = "Số hộ chiếu";
            this.colSoHoChieu.FieldName = "soHoChieu";
            this.colSoHoChieu.Name = "colSoHoChieu";
            this.colSoHoChieu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoHoChieu.Visible = true;
            this.colSoHoChieu.VisibleIndex = 6;
            this.colSoHoChieu.Width = 110;
            // 
            // colNoiLamViec
            // 
            this.colNoiLamViec.Caption = "Nơi làm việc";
            this.colNoiLamViec.FieldName = "noiLamViec";
            this.colNoiLamViec.Name = "colNoiLamViec";
            this.colNoiLamViec.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNoiLamViec.Visible = true;
            this.colNoiLamViec.VisibleIndex = 10;
            this.colNoiLamViec.Width = 146;
            // 
            // colToChuc
            // 
            this.colToChuc.Caption = "Tổ chức làm việc";
            this.colToChuc.FieldName = "toChucLamViec";
            this.colToChuc.Name = "colToChuc";
            this.colToChuc.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colToChuc.Visible = true;
            this.colToChuc.VisibleIndex = 7;
            this.colToChuc.Width = 121;
            // 
            // colChucVu
            // 
            this.colChucVu.Caption = "Vị trí công việc";
            this.colChucVu.FieldName = "viTriCongViec";
            this.colChucVu.Name = "colChucVu";
            this.colChucVu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colChucVu.Visible = true;
            this.colChucVu.VisibleIndex = 8;
            this.colChucVu.Width = 126;
            // 
            // colTrinhDo
            // 
            this.colTrinhDo.Caption = "Trình độ chuyên môn";
            this.colTrinhDo.FieldName = "trinhDoChuyenMon";
            this.colTrinhDo.Name = "colTrinhDo";
            this.colTrinhDo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTrinhDo.Visible = true;
            this.colTrinhDo.VisibleIndex = 9;
            this.colTrinhDo.Width = 147;
            // 
            // colNgayBatDau
            // 
            this.colNgayBatDau.Caption = "Ngày bắt đầu";
            this.colNgayBatDau.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayBatDau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayBatDau.FieldName = "BeginDate";
            this.colNgayBatDau.Name = "colNgayBatDau";
            this.colNgayBatDau.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayBatDau.Visible = true;
            this.colNgayBatDau.VisibleIndex = 11;
            this.colNgayBatDau.Width = 99;
            // 
            // colNgayKetThuc
            // 
            this.colNgayKetThuc.Caption = "Ngày kết thúc";
            this.colNgayKetThuc.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayKetThuc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayKetThuc.FieldName = "EndDate";
            this.colNgayKetThuc.Name = "colNgayKetThuc";
            this.colNgayKetThuc.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayKetThuc.Visible = true;
            this.colNgayKetThuc.VisibleIndex = 12;
            this.colNgayKetThuc.Width = 99;
            // 
            // colNgayKy
            // 
            this.colNgayKy.Caption = "Ngày ký";
            this.colNgayKy.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayKy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayKy.FieldName = "ngayKy";
            this.colNgayKy.Name = "colNgayKy";
            this.colNgayKy.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayKy.Visible = true;
            this.colNgayKy.VisibleIndex = 13;
            // 
            // colNoiKy
            // 
            this.colNoiKy.Caption = "Nơi ký";
            this.colNoiKy.FieldName = "noiKy";
            this.colNoiKy.Name = "colNoiKy";
            this.colNoiKy.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNoiKy.Visible = true;
            this.colNoiKy.VisibleIndex = 14;
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
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemNV,
            this.toolExcel,
            this.btnCapNhat,
            this.toolXoa});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1166, 27);
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
            this.btnThemNV.Size = new System.Drawing.Size(129, 24);
            this.btnThemNV.Text = "Thêm giấy phép";
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
            // btnCapNhat
            // 
            this.btnCapNhat.Image = global::iHRM.Win.Properties.Resources.btnEdit_Image;
            this.btnCapNhat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(84, 24);
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
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
            // frmGiayPhepLaoDong_v1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 425);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "frmGiayPhepLaoDong_v1";
            this.ShowIcon = false;
            this.Text = "Thông tin giấy phép lao động";
            this.Load += new System.EventHandler(this.frmGiayPhepLaoDong_v1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGiayPhepLaoDong_v1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl lblTuKhoa;
        private DevExpress.XtraEditors.TextEdit txtSearchKey;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnThemNV;
        private System.Windows.Forms.ToolStripButton toolExcel;
        private System.Windows.Forms.ToolStripButton toolXoa;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTInh;
        private DevExpress.XtraGrid.Columns.GridColumn colSoGiayPhep;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHoChieu;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiLamViec;
        private DevExpress.XtraGrid.Columns.GridColumn colToChuc;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayBatDau;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colChucVu;
        private DevExpress.XtraGrid.Columns.GridColumn colTrinhDo;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKy;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiKy;
        private System.Windows.Forms.ToolStripButton btnCapNhat;
        private UC.ChonKyLuong chonKyLuong1;
    }
}