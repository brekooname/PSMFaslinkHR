namespace iHRM.Win.Frm.Report
{
    partial class BCTangCaTrongThang
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
            this.grc = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.colNhanVien = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colEmployeeID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colThongTinNhanVien = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colPosName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDepName_Final = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSoGioTangCaChuaHS = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNgayThuongChuaHS = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grlNgay_Thuong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grlDem_Thuong = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colChuNhatChuaHS = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grlNgay_CN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grlDem_CN = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLeTetChuaHS = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grlNgay_Le = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grlDem_Le = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTongCong1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grlTongCongKhongHeSo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSoGioTangCaDaHS = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNgayThuongDaHS = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grlNgay_Thuong2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grlDem_Thuong2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colChuNhatDaHS = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grlNgay_CN2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grlDem_CN2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLeTetDaHS = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grlNgay_Le2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grlDem_Le2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTongCong = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grlTongCongCoHeSo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNote = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnXuatTheoLuoi = new DevExpress.XtraEditors.SimpleButton();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.btnExcelIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            ((System.ComponentModel.ISupportInitialize)(this.grc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grc
            // 
            this.grc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grc.Location = new System.Drawing.Point(0, 142);
            this.grc.MainView = this.grv;
            this.grc.Name = "grc";
            this.grc.Size = new System.Drawing.Size(1370, 607);
            this.grc.TabIndex = 0;
            this.grc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.colNhanVien,
            this.colThongTinNhanVien,
            this.colSoGioTangCaChuaHS,
            this.colTongCong1,
            this.colSoGioTangCaDaHS,
            this.colTongCong,
            this.colGhiChu});
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colEmployeeID,
            this.colEmployeeName,
            this.colPosName,
            this.colDepName_Final,
            this.grlNgay_Thuong,
            this.grlDem_Thuong,
            this.grlNgay_CN,
            this.grlDem_CN,
            this.grlNgay_Le,
            this.grlDem_Le,
            this.grlNgay_Thuong2,
            this.grlDem_Thuong2,
            this.grlNgay_CN2,
            this.grlDem_CN2,
            this.grlNgay_Le2,
            this.grlDem_Le2,
            this.grlTongCongKhongHeSo,
            this.grlTongCongCoHeSo,
            this.colNote});
            this.grv.GridControl = this.grc;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsBehavior.ReadOnly = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // colNhanVien
            // 
            this.colNhanVien.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.colNhanVien.AppearanceHeader.Options.UseFont = true;
            this.colNhanVien.AppearanceHeader.Options.UseTextOptions = true;
            this.colNhanVien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNhanVien.Caption = "Nhân viên";
            this.colNhanVien.Columns.Add(this.colEmployeeID);
            this.colNhanVien.Columns.Add(this.colEmployeeName);
            this.colNhanVien.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colNhanVien.Name = "colNhanVien";
            this.colNhanVien.VisibleIndex = 0;
            this.colNhanVien.Width = 253;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Mã NV";
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.Visible = true;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Tên nhân viên";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeName", "Tổng = {0:#,#}")});
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.Width = 178;
            // 
            // colThongTinNhanVien
            // 
            this.colThongTinNhanVien.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colThongTinNhanVien.AppearanceHeader.Options.UseFont = true;
            this.colThongTinNhanVien.AppearanceHeader.Options.UseTextOptions = true;
            this.colThongTinNhanVien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThongTinNhanVien.Caption = "Thông tin nhân viên";
            this.colThongTinNhanVien.Columns.Add(this.colPosName);
            this.colThongTinNhanVien.Columns.Add(this.colDepName_Final);
            this.colThongTinNhanVien.Name = "colThongTinNhanVien";
            this.colThongTinNhanVien.VisibleIndex = 1;
            this.colThongTinNhanVien.Width = 314;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Chức vụ";
            this.colPosName.FieldName = "PosName";
            this.colPosName.Name = "colPosName";
            this.colPosName.Visible = true;
            this.colPosName.Width = 110;
            // 
            // colDepName_Final
            // 
            this.colDepName_Final.Caption = "Phòng ban";
            this.colDepName_Final.FieldName = "DepName_Final";
            this.colDepName_Final.Name = "colDepName_Final";
            this.colDepName_Final.Visible = true;
            this.colDepName_Final.Width = 204;
            // 
            // colSoGioTangCaChuaHS
            // 
            this.colSoGioTangCaChuaHS.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSoGioTangCaChuaHS.AppearanceHeader.Options.UseFont = true;
            this.colSoGioTangCaChuaHS.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoGioTangCaChuaHS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoGioTangCaChuaHS.Caption = "Số giờ tăng ca (chưa nhân hệ số)";
            this.colSoGioTangCaChuaHS.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.colNgayThuongChuaHS,
            this.colChuNhatChuaHS,
            this.colLeTetChuaHS});
            this.colSoGioTangCaChuaHS.Name = "colSoGioTangCaChuaHS";
            this.colSoGioTangCaChuaHS.RowCount = 2;
            this.colSoGioTangCaChuaHS.VisibleIndex = 2;
            this.colSoGioTangCaChuaHS.Width = 540;
            // 
            // colNgayThuongChuaHS
            // 
            this.colNgayThuongChuaHS.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNgayThuongChuaHS.AppearanceHeader.Options.UseFont = true;
            this.colNgayThuongChuaHS.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayThuongChuaHS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayThuongChuaHS.Caption = "Ngày thường";
            this.colNgayThuongChuaHS.Columns.Add(this.grlNgay_Thuong);
            this.colNgayThuongChuaHS.Columns.Add(this.grlDem_Thuong);
            this.colNgayThuongChuaHS.Name = "colNgayThuongChuaHS";
            this.colNgayThuongChuaHS.RowCount = 2;
            this.colNgayThuongChuaHS.VisibleIndex = 0;
            this.colNgayThuongChuaHS.Width = 180;
            // 
            // grlNgay_Thuong
            // 
            this.grlNgay_Thuong.Caption = "Ban ngày";
            this.grlNgay_Thuong.FieldName = "NgayThuong_Normal_KhongHS";
            this.grlNgay_Thuong.Name = "grlNgay_Thuong";
            this.grlNgay_Thuong.Visible = true;
            this.grlNgay_Thuong.Width = 84;
            // 
            // grlDem_Thuong
            // 
            this.grlDem_Thuong.Caption = "Đêm (22h-6h)";
            this.grlDem_Thuong.FieldName = "NgayThuong_Night_KhongHS";
            this.grlDem_Thuong.Name = "grlDem_Thuong";
            this.grlDem_Thuong.Visible = true;
            this.grlDem_Thuong.Width = 96;
            // 
            // colChuNhatChuaHS
            // 
            this.colChuNhatChuaHS.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colChuNhatChuaHS.AppearanceHeader.Options.UseFont = true;
            this.colChuNhatChuaHS.AppearanceHeader.Options.UseTextOptions = true;
            this.colChuNhatChuaHS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChuNhatChuaHS.Caption = "Chủ nhật";
            this.colChuNhatChuaHS.Columns.Add(this.grlNgay_CN);
            this.colChuNhatChuaHS.Columns.Add(this.grlDem_CN);
            this.colChuNhatChuaHS.Name = "colChuNhatChuaHS";
            this.colChuNhatChuaHS.VisibleIndex = 1;
            this.colChuNhatChuaHS.Width = 180;
            // 
            // grlNgay_CN
            // 
            this.grlNgay_CN.Caption = "Ban ngày";
            this.grlNgay_CN.FieldName = "ChuNhat_Normal_KhongHS";
            this.grlNgay_CN.Name = "grlNgay_CN";
            this.grlNgay_CN.Visible = true;
            this.grlNgay_CN.Width = 80;
            // 
            // grlDem_CN
            // 
            this.grlDem_CN.Caption = "Đêm (22h-6h)";
            this.grlDem_CN.FieldName = "ChuNhat_Night_KhongHS";
            this.grlDem_CN.Name = "grlDem_CN";
            this.grlDem_CN.Visible = true;
            this.grlDem_CN.Width = 100;
            // 
            // colLeTetChuaHS
            // 
            this.colLeTetChuaHS.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colLeTetChuaHS.AppearanceHeader.Options.UseFont = true;
            this.colLeTetChuaHS.AppearanceHeader.Options.UseTextOptions = true;
            this.colLeTetChuaHS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLeTetChuaHS.Caption = "Lễ tết";
            this.colLeTetChuaHS.Columns.Add(this.grlNgay_Le);
            this.colLeTetChuaHS.Columns.Add(this.grlDem_Le);
            this.colLeTetChuaHS.Name = "colLeTetChuaHS";
            this.colLeTetChuaHS.VisibleIndex = 2;
            this.colLeTetChuaHS.Width = 180;
            // 
            // grlNgay_Le
            // 
            this.grlNgay_Le.Caption = "Ban ngày";
            this.grlNgay_Le.FieldName = "LetTet_Normal_KhongHS";
            this.grlNgay_Le.Name = "grlNgay_Le";
            this.grlNgay_Le.Visible = true;
            this.grlNgay_Le.Width = 80;
            // 
            // grlDem_Le
            // 
            this.grlDem_Le.Caption = "Đêm (22h-6h)";
            this.grlDem_Le.FieldName = "LetTet_Night_KhongHS";
            this.grlDem_Le.Name = "grlDem_Le";
            this.grlDem_Le.Visible = true;
            this.grlDem_Le.Width = 100;
            // 
            // colTongCong1
            // 
            this.colTongCong1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.colTongCong1.AppearanceHeader.Options.UseFont = true;
            this.colTongCong1.AppearanceHeader.Options.UseTextOptions = true;
            this.colTongCong1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTongCong1.Caption = "Tổng cộng";
            this.colTongCong1.Columns.Add(this.grlTongCongKhongHeSo);
            this.colTongCong1.Name = "colTongCong1";
            this.colTongCong1.VisibleIndex = 3;
            this.colTongCong1.Width = 100;
            // 
            // grlTongCongKhongHeSo
            // 
            this.grlTongCongKhongHeSo.Caption = "Tổng cộng";
            this.grlTongCongKhongHeSo.FieldName = "TongTangCa_KhongHS";
            this.grlTongCongKhongHeSo.Name = "grlTongCongKhongHeSo";
            this.grlTongCongKhongHeSo.Visible = true;
            this.grlTongCongKhongHeSo.Width = 100;
            // 
            // colSoGioTangCaDaHS
            // 
            this.colSoGioTangCaDaHS.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSoGioTangCaDaHS.AppearanceHeader.Options.UseFont = true;
            this.colSoGioTangCaDaHS.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoGioTangCaDaHS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoGioTangCaDaHS.Caption = "Số giờ tăng ca (đã nhân hệ số)";
            this.colSoGioTangCaDaHS.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.colNgayThuongDaHS,
            this.colChuNhatDaHS,
            this.colLeTetDaHS});
            this.colSoGioTangCaDaHS.Name = "colSoGioTangCaDaHS";
            this.colSoGioTangCaDaHS.RowCount = 2;
            this.colSoGioTangCaDaHS.VisibleIndex = 4;
            this.colSoGioTangCaDaHS.Width = 540;
            // 
            // colNgayThuongDaHS
            // 
            this.colNgayThuongDaHS.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colNgayThuongDaHS.AppearanceHeader.Options.UseFont = true;
            this.colNgayThuongDaHS.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayThuongDaHS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayThuongDaHS.Caption = "Ngày thường";
            this.colNgayThuongDaHS.Columns.Add(this.grlNgay_Thuong2);
            this.colNgayThuongDaHS.Columns.Add(this.grlDem_Thuong2);
            this.colNgayThuongDaHS.Name = "colNgayThuongDaHS";
            this.colNgayThuongDaHS.VisibleIndex = 0;
            this.colNgayThuongDaHS.Width = 180;
            // 
            // grlNgay_Thuong2
            // 
            this.grlNgay_Thuong2.Caption = "Ban ngày";
            this.grlNgay_Thuong2.FieldName = "NgayThuong_Normal_CoHS";
            this.grlNgay_Thuong2.Name = "grlNgay_Thuong2";
            this.grlNgay_Thuong2.Visible = true;
            this.grlNgay_Thuong2.Width = 83;
            // 
            // grlDem_Thuong2
            // 
            this.grlDem_Thuong2.Caption = "Đêm (22h-6h)";
            this.grlDem_Thuong2.FieldName = "NgayThuong_Night_CoHS";
            this.grlDem_Thuong2.Name = "grlDem_Thuong2";
            this.grlDem_Thuong2.Visible = true;
            this.grlDem_Thuong2.Width = 97;
            // 
            // colChuNhatDaHS
            // 
            this.colChuNhatDaHS.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colChuNhatDaHS.AppearanceHeader.Options.UseFont = true;
            this.colChuNhatDaHS.AppearanceHeader.Options.UseTextOptions = true;
            this.colChuNhatDaHS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChuNhatDaHS.Caption = "Chủ nhật";
            this.colChuNhatDaHS.Columns.Add(this.grlNgay_CN2);
            this.colChuNhatDaHS.Columns.Add(this.grlDem_CN2);
            this.colChuNhatDaHS.Name = "colChuNhatDaHS";
            this.colChuNhatDaHS.VisibleIndex = 1;
            this.colChuNhatDaHS.Width = 180;
            // 
            // grlNgay_CN2
            // 
            this.grlNgay_CN2.Caption = "Ban ngày";
            this.grlNgay_CN2.FieldName = "ChuNhat_Normal_CoHS";
            this.grlNgay_CN2.Name = "grlNgay_CN2";
            this.grlNgay_CN2.Visible = true;
            this.grlNgay_CN2.Width = 85;
            // 
            // grlDem_CN2
            // 
            this.grlDem_CN2.Caption = "Đêm (22h-6h)";
            this.grlDem_CN2.FieldName = "ChuNhat_Night_CoHS";
            this.grlDem_CN2.Name = "grlDem_CN2";
            this.grlDem_CN2.Visible = true;
            this.grlDem_CN2.Width = 95;
            // 
            // colLeTetDaHS
            // 
            this.colLeTetDaHS.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colLeTetDaHS.AppearanceHeader.Options.UseFont = true;
            this.colLeTetDaHS.AppearanceHeader.Options.UseTextOptions = true;
            this.colLeTetDaHS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLeTetDaHS.Caption = "Lễ tết";
            this.colLeTetDaHS.Columns.Add(this.grlNgay_Le2);
            this.colLeTetDaHS.Columns.Add(this.grlDem_Le2);
            this.colLeTetDaHS.Name = "colLeTetDaHS";
            this.colLeTetDaHS.VisibleIndex = 2;
            this.colLeTetDaHS.Width = 180;
            // 
            // grlNgay_Le2
            // 
            this.grlNgay_Le2.Caption = "Ban ngày";
            this.grlNgay_Le2.FieldName = "LetTet_Normal_CoHS";
            this.grlNgay_Le2.Name = "grlNgay_Le2";
            this.grlNgay_Le2.Visible = true;
            this.grlNgay_Le2.Width = 83;
            // 
            // grlDem_Le2
            // 
            this.grlDem_Le2.Caption = "Đêm (22h-6h)";
            this.grlDem_Le2.FieldName = "LetTet_Night_CoHS";
            this.grlDem_Le2.Name = "grlDem_Le2";
            this.grlDem_Le2.Visible = true;
            this.grlDem_Le2.Width = 97;
            // 
            // colTongCong
            // 
            this.colTongCong.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.colTongCong.AppearanceHeader.Options.UseFont = true;
            this.colTongCong.AppearanceHeader.Options.UseTextOptions = true;
            this.colTongCong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTongCong.Caption = "Tổng cộng";
            this.colTongCong.Columns.Add(this.grlTongCongCoHeSo);
            this.colTongCong.Name = "colTongCong";
            this.colTongCong.VisibleIndex = 5;
            this.colTongCong.Width = 100;
            // 
            // grlTongCongCoHeSo
            // 
            this.grlTongCongCoHeSo.Caption = "Tổng cộng";
            this.grlTongCongCoHeSo.FieldName = "TongTangCa_CoHS";
            this.grlTongCongCoHeSo.Name = "grlTongCongCoHeSo";
            this.grlTongCongCoHeSo.Visible = true;
            this.grlTongCongCoHeSo.Width = 100;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.colGhiChu.AppearanceHeader.Options.UseFont = true;
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.Columns.Add(this.colNote);
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.VisibleIndex = 6;
            this.colGhiChu.Width = 192;
            // 
            // colNote
            // 
            this.colNote.Caption = "Notes";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.Width = 192;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnXuatTheoLuoi);
            this.panelControl2.Controls.Add(this.ucChonDoiTuong_DS1);
            this.panelControl2.Controls.Add(this.btnExcelIn);
            this.panelControl2.Controls.Add(this.btnFind);
            this.panelControl2.Controls.Add(this.chonKyLuong1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1370, 142);
            this.panelControl2.TabIndex = 4;
            // 
            // btnXuatTheoLuoi
            // 
            this.btnXuatTheoLuoi.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatTheoLuoi.Appearance.Options.UseFont = true;
            this.btnXuatTheoLuoi.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.btnXuatTheoLuoi.Location = new System.Drawing.Point(510, 94);
            this.btnXuatTheoLuoi.Name = "btnXuatTheoLuoi";
            this.btnXuatTheoLuoi.Size = new System.Drawing.Size(118, 35);
            this.btnXuatTheoLuoi.TabIndex = 12;
            this.btnXuatTheoLuoi.Text = "Xuất theo lưới";
            this.btnXuatTheoLuoi.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(175, 0);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(328, 139);
            this.ucChonDoiTuong_DS1.TabIndex = 9;
            // 
            // btnExcelIn
            // 
            this.btnExcelIn.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelIn.Appearance.Options.UseFont = true;
            this.btnExcelIn.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.btnExcelIn.Location = new System.Drawing.Point(510, 55);
            this.btnExcelIn.Name = "btnExcelIn";
            this.btnExcelIn.Size = new System.Drawing.Size(118, 35);
            this.btnExcelIn.TabIndex = 8;
            this.btnExcelIn.Text = "Xuất excel";
            this.btnExcelIn.Click += new System.EventHandler(this.btnExcelIn_Click);
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.Location = new System.Drawing.Point(510, 16);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(118, 35);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 10, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(9, 5);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(160, 93);
            this.chonKyLuong1.TabIndex = 6;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 10, 1, 0, 0, 0, 0);
            // 
            // BCTangCaTrongThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.grc);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Name = "BCTangCaTrongThang";
            this.Text = "Báo cáo tăng ca trong tháng";
            this.Load += new System.EventHandler(this.BCTangCaTrongThang_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCTangCaTrongThang_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grc;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView grv;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPosName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDepName_Final;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlNgay_Thuong;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlDem_Thuong;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlNgay_CN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlDem_CN;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlNgay_Le;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlDem_Le;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlNgay_Thuong2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlDem_Thuong2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlNgay_CN2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlDem_CN2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlNgay_Le2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlDem_Le2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlTongCongKhongHeSo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn grlTongCongCoHeSo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNote;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraEditors.SimpleButton btnExcelIn;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.SimpleButton btnXuatTheoLuoi;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colNhanVien;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colThongTinNhanVien;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colSoGioTangCaChuaHS;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colNgayThuongChuaHS;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colChuNhatChuaHS;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colLeTetChuaHS;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colTongCong1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colSoGioTangCaDaHS;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colNgayThuongDaHS;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colChuNhatDaHS;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colLeTetDaHS;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colTongCong;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand colGhiChu;
    }
}

