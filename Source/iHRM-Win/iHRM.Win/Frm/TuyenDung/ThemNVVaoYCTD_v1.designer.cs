namespace iHRM.Win.Frm.TuyenDung
{
    partial class ThemNVVaoYCTD_v1
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.grcYCTD = new DevExpress.XtraGrid.GridControl();
            this.grvYCTD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdDotTD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoYeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChucVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcNhanVien = new DevExpress.XtraGrid.GridControl();
            this.grvNhanVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQueQuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoKhau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.grcDotTuyenDung = new DevExpress.XtraGrid.GridControl();
            this.grvDotTuyenDung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDotTD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTuNgay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDenNgay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnXoaUV = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemUV = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grcYCTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDotTuyenDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDotTuyenDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grcYCTD
            // 
            this.grcYCTD.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grcYCTD.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcYCTD.Location = new System.Drawing.Point(2, 278);
            this.grcYCTD.MainView = this.grvYCTD;
            this.grcYCTD.Name = "grcYCTD";
            this.grcYCTD.Size = new System.Drawing.Size(356, 354);
            this.grcYCTD.TabIndex = 0;
            this.grcYCTD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvYCTD});
            // 
            // grvYCTD
            // 
            this.grvYCTD.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.grvYCTD.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvYCTD.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvYCTD.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvYCTD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdDotTD,
            this.colSoYeuCau,
            this.colChucVu,
            this.colPB,
            this.colSoLuong});
            this.grvYCTD.GridControl = this.grcYCTD;
            this.grvYCTD.Name = "grvYCTD";
            this.grvYCTD.OptionsBehavior.Editable = false;
            this.grvYCTD.OptionsBehavior.ReadOnly = true;
            this.grvYCTD.OptionsView.ColumnAutoWidth = false;
            this.grvYCTD.OptionsView.ShowAutoFilterRow = true;
            this.grvYCTD.OptionsView.ShowGroupPanel = false;
            this.grvYCTD.OptionsView.ShowViewCaption = true;
            this.grvYCTD.ViewCaption = "Các yêu cầu tuyển dụng";
            this.grvYCTD.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvYCTD_FocusedRowChanged);
            this.grvYCTD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvYCTD_KeyDown);
            this.grvYCTD.DataSourceChanged += new System.EventHandler(this.grvYCTD_DataSourceChanged);
            // 
            // colIdDotTD
            // 
            this.colIdDotTD.Caption = "id";
            this.colIdDotTD.FieldName = "id";
            this.colIdDotTD.Name = "colIdDotTD";
            // 
            // colSoYeuCau
            // 
            this.colSoYeuCau.Caption = "Số yêu cầu";
            this.colSoYeuCau.FieldName = "SoYeuCau";
            this.colSoYeuCau.Name = "colSoYeuCau";
            this.colSoYeuCau.OptionsColumn.AllowEdit = false;
            this.colSoYeuCau.OptionsColumn.ReadOnly = true;
            this.colSoYeuCau.Visible = true;
            this.colSoYeuCau.VisibleIndex = 0;
            this.colSoYeuCau.Width = 99;
            // 
            // colChucVu
            // 
            this.colChucVu.Caption = "Chức vụ";
            this.colChucVu.FieldName = "PosName";
            this.colChucVu.Name = "colChucVu";
            this.colChucVu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colChucVu.Visible = true;
            this.colChucVu.VisibleIndex = 2;
            this.colChucVu.Width = 157;
            // 
            // colPB
            // 
            this.colPB.Caption = "Phòng ban";
            this.colPB.FieldName = "DepName";
            this.colPB.Name = "colPB";
            this.colPB.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPB.Visible = true;
            this.colPB.VisibleIndex = 1;
            this.colPB.Width = 120;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.DisplayFormat.FormatString = "#,#";
            this.colSoLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoLuong.FieldName = "soLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.OptionsColumn.AllowEdit = false;
            this.colSoLuong.OptionsColumn.AllowMove = false;
            this.colSoLuong.OptionsColumn.ReadOnly = true;
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 3;
            this.colSoLuong.Width = 61;
            // 
            // grcNhanVien
            // 
            this.grcNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcNhanVien.Location = new System.Drawing.Point(2, 2);
            this.grcNhanVien.MainView = this.grvNhanVien;
            this.grcNhanVien.Name = "grcNhanVien";
            this.grcNhanVien.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.grcNhanVien.Size = new System.Drawing.Size(987, 630);
            this.grcNhanVien.TabIndex = 4;
            this.grcNhanVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNhanVien});
            // 
            // grvNhanVien
            // 
            this.grvNhanVien.Appearance.EvenRow.BackColor = System.Drawing.Color.LemonChiffon;
            this.grvNhanVien.Appearance.EvenRow.BackColor2 = System.Drawing.Color.LemonChiffon;
            this.grvNhanVien.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grvNhanVien.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvNhanVien.Appearance.EvenRow.Options.UseFont = true;
            this.grvNhanVien.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.grvNhanVien.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvNhanVien.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvNhanVien.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvNhanVien.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvNhanVien.Appearance.OddRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvNhanVien.Appearance.OddRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.grvNhanVien.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grvNhanVien.Appearance.OddRow.Options.UseBackColor = true;
            this.grvNhanVien.Appearance.OddRow.Options.UseFont = true;
            this.grvNhanVien.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grvNhanVien.Appearance.Row.Options.UseFont = true;
            this.grvNhanVien.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grvNhanVien.Appearance.SelectedRow.Options.UseFont = true;
            this.grvNhanVien.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GreenYellow;
            this.grvNhanVien.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grvNhanVien.AppearancePrint.EvenRow.Options.UseBackColor = true;
            this.grvNhanVien.AppearancePrint.OddRow.BackColor = System.Drawing.Color.Khaki;
            this.grvNhanVien.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grvNhanVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeID,
            this.colHoTen,
            this.colGioiTinh,
            this.colNgaySinh,
            this.colSDT,
            this.colDiaChi,
            this.colQueQuan,
            this.colHoKhau,
            this.colCMND,
            this.colNgayCap,
            this.colNoiCap,
            this.colNgayVao});
            this.grvNhanVien.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvNhanVien.GridControl = this.grcNhanVien;
            this.grvNhanVien.Name = "grvNhanVien";
            this.grvNhanVien.OptionsBehavior.Editable = false;
            this.grvNhanVien.OptionsBehavior.ReadOnly = true;
            this.grvNhanVien.OptionsView.ColumnAutoWidth = false;
            this.grvNhanVien.OptionsView.EnableAppearanceEvenRow = true;
            this.grvNhanVien.OptionsView.EnableAppearanceOddRow = true;
            this.grvNhanVien.OptionsView.ShowAutoFilterRow = true;
            this.grvNhanVien.OptionsView.ShowGroupPanel = false;
            this.grvNhanVien.OptionsView.ShowViewCaption = true;
            this.grvNhanVien.RowHeight = 26;
            this.grvNhanVien.ViewCaption = "Danh sách các nhân viên";
            this.grvNhanVien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvNhanVien_KeyDown);
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colEmployeeID.AppearanceCell.Options.UseFont = true;
            this.colEmployeeID.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colEmployeeID.AppearanceHeader.Options.UseFont = true;
            this.colEmployeeID.Caption = "Mã NV";
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 0;
            this.colEmployeeID.Width = 67;
            // 
            // colHoTen
            // 
            this.colHoTen.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colHoTen.AppearanceCell.Options.UseFont = true;
            this.colHoTen.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colHoTen.AppearanceHeader.Options.UseFont = true;
            this.colHoTen.Caption = "Họ tên";
            this.colHoTen.FieldName = "EmployeeName";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHoTen.Visible = true;
            this.colHoTen.VisibleIndex = 1;
            this.colHoTen.Width = 105;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colGioiTinh.AppearanceCell.Options.UseFont = true;
            this.colGioiTinh.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colGioiTinh.AppearanceHeader.Options.UseFont = true;
            this.colGioiTinh.Caption = "Giới tính";
            this.colGioiTinh.FieldName = "SexID";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 3;
            this.colGioiTinh.Width = 64;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colNgaySinh.AppearanceCell.Options.UseFont = true;
            this.colNgaySinh.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colNgaySinh.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colNgaySinh.AppearanceHeader.Options.UseFont = true;
            this.colNgaySinh.Caption = "Ngày sinh";
            this.colNgaySinh.FieldName = "Birthday";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 2;
            this.colNgaySinh.Width = 76;
            // 
            // colSDT
            // 
            this.colSDT.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colSDT.AppearanceCell.Options.UseFont = true;
            this.colSDT.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colSDT.AppearanceHeader.Options.UseFont = true;
            this.colSDT.Caption = "Số ĐT";
            this.colSDT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSDT.FieldName = "Phone";
            this.colSDT.Name = "colSDT";
            this.colSDT.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSDT.Visible = true;
            this.colSDT.VisibleIndex = 4;
            this.colSDT.Width = 90;
            // 
            // colDiaChi
            // 
            this.colDiaChi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colDiaChi.AppearanceCell.Options.UseFont = true;
            this.colDiaChi.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colDiaChi.AppearanceHeader.Options.UseFont = true;
            this.colDiaChi.Caption = "Địa Chỉ";
            this.colDiaChi.FieldName = "Address";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 5;
            this.colDiaChi.Width = 174;
            // 
            // colQueQuan
            // 
            this.colQueQuan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colQueQuan.AppearanceCell.Options.UseFont = true;
            this.colQueQuan.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colQueQuan.AppearanceHeader.Options.UseFont = true;
            this.colQueQuan.Caption = "Quê Quán";
            this.colQueQuan.FieldName = "NativeCountry";
            this.colQueQuan.Name = "colQueQuan";
            this.colQueQuan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colQueQuan.Visible = true;
            this.colQueQuan.VisibleIndex = 10;
            this.colQueQuan.Width = 141;
            // 
            // colHoKhau
            // 
            this.colHoKhau.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colHoKhau.AppearanceCell.Options.UseFont = true;
            this.colHoKhau.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colHoKhau.AppearanceHeader.Options.UseFont = true;
            this.colHoKhau.Caption = "Hộ khẩu thường trú";
            this.colHoKhau.FieldName = "PermanentAddress";
            this.colHoKhau.Name = "colHoKhau";
            this.colHoKhau.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHoKhau.Visible = true;
            this.colHoKhau.VisibleIndex = 11;
            this.colHoKhau.Width = 146;
            // 
            // colCMND
            // 
            this.colCMND.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colCMND.AppearanceCell.Options.UseFont = true;
            this.colCMND.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colCMND.AppearanceHeader.Options.UseFont = true;
            this.colCMND.Caption = "CMND";
            this.colCMND.FieldName = "IDCard";
            this.colCMND.Name = "colCMND";
            this.colCMND.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 6;
            this.colCMND.Width = 94;
            // 
            // colNgayCap
            // 
            this.colNgayCap.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colNgayCap.AppearanceCell.Options.UseFont = true;
            this.colNgayCap.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colNgayCap.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colNgayCap.AppearanceHeader.Options.UseFont = true;
            this.colNgayCap.Caption = "Ngày cấp";
            this.colNgayCap.FieldName = "IssueDate";
            this.colNgayCap.Name = "colNgayCap";
            this.colNgayCap.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayCap.Visible = true;
            this.colNgayCap.VisibleIndex = 7;
            // 
            // colNoiCap
            // 
            this.colNoiCap.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colNoiCap.AppearanceCell.Options.UseFont = true;
            this.colNoiCap.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colNoiCap.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colNoiCap.AppearanceHeader.Options.UseFont = true;
            this.colNoiCap.Caption = "Nơi cấp";
            this.colNoiCap.FieldName = "IssuePlace";
            this.colNoiCap.Name = "colNoiCap";
            this.colNoiCap.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNoiCap.Visible = true;
            this.colNoiCap.VisibleIndex = 8;
            // 
            // colNgayVao
            // 
            this.colNgayVao.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colNgayVao.AppearanceCell.Options.UseFont = true;
            this.colNgayVao.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colNgayVao.AppearanceHeader.Options.UseFont = true;
            this.colNgayVao.Caption = "Ngày vào";
            this.colNgayVao.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayVao.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayVao.FieldName = "AppliedDate";
            this.colNgayVao.Name = "colNgayVao";
            this.colNgayVao.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayVao.Visible = true;
            this.colNgayVao.VisibleIndex = 9;
            this.colNgayVao.Width = 88;
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
            // grcDotTuyenDung
            // 
            this.grcDotTuyenDung.Dock = System.Windows.Forms.DockStyle.Top;
            gridLevelNode2.RelationName = "Level1";
            this.grcDotTuyenDung.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grcDotTuyenDung.Location = new System.Drawing.Point(2, 2);
            this.grcDotTuyenDung.MainView = this.grvDotTuyenDung;
            this.grcDotTuyenDung.Name = "grcDotTuyenDung";
            this.grcDotTuyenDung.Size = new System.Drawing.Size(356, 276);
            this.grcDotTuyenDung.TabIndex = 2;
            this.grcDotTuyenDung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDotTuyenDung});
            // 
            // grvDotTuyenDung
            // 
            this.grvDotTuyenDung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvDotTuyenDung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDotTuyenDung.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDotTuyenDung.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDotTuyenDung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colDotTD,
            this.colTuNgay,
            this.colDenNgay});
            this.grvDotTuyenDung.GridControl = this.grcDotTuyenDung;
            this.grvDotTuyenDung.Name = "grvDotTuyenDung";
            this.grvDotTuyenDung.OptionsBehavior.Editable = false;
            this.grvDotTuyenDung.OptionsBehavior.ReadOnly = true;
            this.grvDotTuyenDung.OptionsDetail.EnableMasterViewMode = false;
            this.grvDotTuyenDung.OptionsView.ShowAutoFilterRow = true;
            this.grvDotTuyenDung.OptionsView.ShowGroupPanel = false;
            this.grvDotTuyenDung.OptionsView.ShowViewCaption = true;
            this.grvDotTuyenDung.ViewCaption = "Các đợt tuyển dụng";
            this.grvDotTuyenDung.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvDotTuyenDung_FocusedRowChanged);
            this.grvDotTuyenDung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvDotTuyenDung_KeyDown);
            // 
            // colId
            // 
            this.colId.Caption = "id";
            this.colId.FieldName = "id";
            this.colId.Name = "colId";
            // 
            // colDotTD
            // 
            this.colDotTD.Caption = "Đợt tuyển dụng";
            this.colDotTD.FieldName = "tenDotTD";
            this.colDotTD.Name = "colDotTD";
            this.colDotTD.OptionsColumn.AllowEdit = false;
            this.colDotTD.OptionsColumn.AllowMove = false;
            this.colDotTD.OptionsColumn.ReadOnly = true;
            this.colDotTD.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDotTD.Visible = true;
            this.colDotTD.VisibleIndex = 0;
            this.colDotTD.Width = 190;
            // 
            // colTuNgay
            // 
            this.colTuNgay.AppearanceCell.Options.UseTextOptions = true;
            this.colTuNgay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTuNgay.Caption = "Từ ngày";
            this.colTuNgay.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colTuNgay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTuNgay.FieldName = "BeginDate";
            this.colTuNgay.Name = "colTuNgay";
            this.colTuNgay.Visible = true;
            this.colTuNgay.VisibleIndex = 1;
            this.colTuNgay.Width = 79;
            // 
            // colDenNgay
            // 
            this.colDenNgay.AppearanceCell.Options.UseTextOptions = true;
            this.colDenNgay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDenNgay.Caption = "Đến ngày";
            this.colDenNgay.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDenNgay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDenNgay.FieldName = "EndDate";
            this.colDenNgay.Name = "colDenNgay";
            this.colDenNgay.Visible = true;
            this.colDenNgay.VisibleIndex = 2;
            this.colDenNgay.Width = 69;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnXoaUV);
            this.panelControl1.Controls.Add(this.btnThemUV);
            this.panelControl1.Controls.Add(this.grcNhanVien);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(360, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(991, 634);
            this.panelControl1.TabIndex = 5;
            // 
            // btnXoaUV
            // 
            this.btnXoaUV.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaUV.Appearance.Options.UseFont = true;
            this.btnXoaUV.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.btnXoaUV.Location = new System.Drawing.Point(78, 2);
            this.btnXoaUV.Name = "btnXoaUV";
            this.btnXoaUV.Size = new System.Drawing.Size(70, 23);
            this.btnXoaUV.TabIndex = 5;
            this.btnXoaUV.Text = "Xóa";
            this.btnXoaUV.Click += new System.EventHandler(this.btnXoaUV_Click);
            // 
            // btnThemUV
            // 
            this.btnThemUV.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemUV.Appearance.Options.UseFont = true;
            this.btnThemUV.Image = global::iHRM.Win.Properties.Resources.ico20_new;
            this.btnThemUV.Location = new System.Drawing.Point(6, 2);
            this.btnThemUV.Name = "btnThemUV";
            this.btnThemUV.Size = new System.Drawing.Size(70, 23);
            this.btnThemUV.TabIndex = 5;
            this.btnThemUV.Text = "Thêm";
            this.btnThemUV.Click += new System.EventHandler(this.btnThemUV_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grcYCTD);
            this.panelControl2.Controls.Add(this.grcDotTuyenDung);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(360, 634);
            this.panelControl2.TabIndex = 6;
            // 
            // ThemNVVaoYCTD_v1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 634);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Name = "ThemNVVaoYCTD_v1";
            this.ShowIcon = false;
            this.Text = "Danh sách ứng viên trong yêu cầu tuyển dụng";
            this.Load += new System.EventHandler(this.ThemNVVaoYCTD_v1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ThemNVVaoYCTD_v1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grcYCTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDotTuyenDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDotTuyenDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grcYCTD;
        private DevExpress.XtraGrid.Views.Grid.GridView grvYCTD;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDotTD;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.GridControl grcNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colSDT;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colQueQuan;
        private DevExpress.XtraGrid.Columns.GridColumn colHoKhau;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayCap;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiCap;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVao;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.GridControl grcDotTuyenDung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDotTuyenDung;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDotTD;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colChucVu;
        private DevExpress.XtraGrid.Columns.GridColumn colPB;
        private DevExpress.XtraGrid.Columns.GridColumn colTuNgay;
        private DevExpress.XtraGrid.Columns.GridColumn colDenNgay;
        private DevExpress.XtraEditors.SimpleButton btnThemUV;
        private DevExpress.XtraEditors.SimpleButton btnXoaUV;
        private DevExpress.XtraGrid.Columns.GridColumn colSoYeuCau;
        //private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
    }
}