namespace iHRM.Win.Frm.Report
{
    partial class BCTongHopThongTinCC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCTongHopThongTinCC));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName_Final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaLamDK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDKLamThem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYeuCauSuaCongTuGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTGQuetDen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNghiCoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNghiKhongLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTGQuetVe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYeuCauTCTuGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYeuCauTCKTuGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYeuCauSuaCongDenGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYeuCauTCDenGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYeuCauTCKDenGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripExcel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.splitContainerControl1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1370, 587);
            this.splitContainerControl1.SplitterPosition = 262;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chonKyLuong1);
            this.flowLayoutPanel1.Controls.Add(this.ucChonDoiTuong_DS1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(225, 562);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 6, 30, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(7, 7);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(150, 100);
            this.chonKyLuong1.TabIndex = 12;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 6, 1, 0, 0, 0, 0);
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(7, 114);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(260, 150);
            this.ucChonDoiTuong_DS1.TabIndex = 13;
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
            this.toolStrip1.Size = new System.Drawing.Size(225, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
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
            this.grd.Size = new System.Drawing.Size(1140, 562);
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
            this.colDepName_Final,
            this.colNgay,
            this.colCaLamDK,
            this.colDKLamThem,
            this.colYeuCauSuaCongTuGio,
            this.colTGQuetDen,
            this.colNghiCoLuong,
            this.colNghiKhongLuong,
            this.colTGQuetVe,
            this.colYeuCauTCTuGio,
            this.colYeuCauTCKTuGio,
            this.colYeuCauSuaCongDenGio,
            this.colYeuCauTCDenGio,
            this.colYeuCauTCKDenGio});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
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
            this.colEmployeeID.Width = 76;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Tên nhân viên";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 169;
            // 
            // colDepName_Final
            // 
            this.colDepName_Final.Caption = "Phòng ban";
            this.colDepName_Final.FieldName = "DepName_Final";
            this.colDepName_Final.Name = "colDepName_Final";
            this.colDepName_Final.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName_Final.Visible = true;
            this.colDepName_Final.VisibleIndex = 2;
            this.colDepName_Final.Width = 168;
            // 
            // colNgay
            // 
            this.colNgay.Caption = "Ngày";
            this.colNgay.FieldName = "ngay";
            this.colNgay.Name = "colNgay";
            this.colNgay.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgay.Visible = true;
            this.colNgay.VisibleIndex = 3;
            this.colNgay.Width = 99;
            // 
            // colCaLamDK
            // 
            this.colCaLamDK.Caption = "Ca làm ĐK";
            this.colCaLamDK.FieldName = "tenCaLam";
            this.colCaLamDK.Name = "colCaLamDK";
            this.colCaLamDK.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCaLamDK.Visible = true;
            this.colCaLamDK.VisibleIndex = 4;
            this.colCaLamDK.Width = 107;
            // 
            // colDKLamThem
            // 
            this.colDKLamThem.Caption = "ĐK làm thêm";
            this.colDKLamThem.FieldName = "loaiLamThem";
            this.colDKLamThem.Name = "colDKLamThem";
            this.colDKLamThem.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDKLamThem.Visible = true;
            this.colDKLamThem.VisibleIndex = 5;
            this.colDKLamThem.Width = 137;
            // 
            // colYeuCauSuaCongTuGio
            // 
            this.colYeuCauSuaCongTuGio.Caption = "Yêu cầu sửa công vào";
            this.colYeuCauSuaCongTuGio.FieldName = "YeuCauSuaCongTuGio";
            this.colYeuCauSuaCongTuGio.Name = "colYeuCauSuaCongTuGio";
            this.colYeuCauSuaCongTuGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colYeuCauSuaCongTuGio.Visible = true;
            this.colYeuCauSuaCongTuGio.VisibleIndex = 10;
            this.colYeuCauSuaCongTuGio.Width = 156;
            // 
            // colTGQuetDen
            // 
            this.colTGQuetDen.AppearanceCell.Options.UseTextOptions = true;
            this.colTGQuetDen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTGQuetDen.Caption = "Giờ vào";
            this.colTGQuetDen.FieldName = "tgQuetDen";
            this.colTGQuetDen.Name = "colTGQuetDen";
            this.colTGQuetDen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTGQuetDen.Visible = true;
            this.colTGQuetDen.VisibleIndex = 6;
            this.colTGQuetDen.Width = 79;
            // 
            // colNghiCoLuong
            // 
            this.colNghiCoLuong.Caption = "Nghỉ có lương";
            this.colNghiCoLuong.FieldName = "NghiCoLuong";
            this.colNghiCoLuong.Name = "colNghiCoLuong";
            this.colNghiCoLuong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNghiCoLuong.Visible = true;
            this.colNghiCoLuong.VisibleIndex = 8;
            this.colNghiCoLuong.Width = 121;
            // 
            // colNghiKhongLuong
            // 
            this.colNghiKhongLuong.Caption = "Nghi không lương";
            this.colNghiKhongLuong.FieldName = "NghiKhongLuong";
            this.colNghiKhongLuong.Name = "colNghiKhongLuong";
            this.colNghiKhongLuong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNghiKhongLuong.Visible = true;
            this.colNghiKhongLuong.VisibleIndex = 9;
            this.colNghiKhongLuong.Width = 126;
            // 
            // colTGQuetVe
            // 
            this.colTGQuetVe.AppearanceCell.Options.UseTextOptions = true;
            this.colTGQuetVe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTGQuetVe.Caption = "Giờ ra";
            this.colTGQuetVe.FieldName = "tgQuetVe";
            this.colTGQuetVe.Name = "colTGQuetVe";
            this.colTGQuetVe.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTGQuetVe.Visible = true;
            this.colTGQuetVe.VisibleIndex = 7;
            this.colTGQuetVe.Width = 71;
            // 
            // colYeuCauTCTuGio
            // 
            this.colYeuCauTCTuGio.Caption = "Tăng ca vào";
            this.colYeuCauTCTuGio.FieldName = "YeuCauTCTuGio";
            this.colYeuCauTCTuGio.Name = "colYeuCauTCTuGio";
            this.colYeuCauTCTuGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colYeuCauTCTuGio.Visible = true;
            this.colYeuCauTCTuGio.VisibleIndex = 12;
            this.colYeuCauTCTuGio.Width = 119;
            // 
            // colYeuCauTCKTuGio
            // 
            this.colYeuCauTCKTuGio.Caption = "Tăng ca KQT vào";
            this.colYeuCauTCKTuGio.FieldName = "YeuCauTCKTuGio";
            this.colYeuCauTCKTuGio.Name = "colYeuCauTCKTuGio";
            this.colYeuCauTCKTuGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colYeuCauTCKTuGio.Visible = true;
            this.colYeuCauTCKTuGio.VisibleIndex = 14;
            this.colYeuCauTCKTuGio.Width = 136;
            // 
            // colYeuCauSuaCongDenGio
            // 
            this.colYeuCauSuaCongDenGio.Caption = "Yêu cầu sửa công ra";
            this.colYeuCauSuaCongDenGio.FieldName = "YeuCauSuaCongDenGio";
            this.colYeuCauSuaCongDenGio.Name = "colYeuCauSuaCongDenGio";
            this.colYeuCauSuaCongDenGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colYeuCauSuaCongDenGio.Visible = true;
            this.colYeuCauSuaCongDenGio.VisibleIndex = 11;
            this.colYeuCauSuaCongDenGio.Width = 142;
            // 
            // colYeuCauTCDenGio
            // 
            this.colYeuCauTCDenGio.Caption = "Tăng ca ra";
            this.colYeuCauTCDenGio.FieldName = "YeuCauTCDenGio";
            this.colYeuCauTCDenGio.Name = "colYeuCauTCDenGio";
            this.colYeuCauTCDenGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colYeuCauTCDenGio.Visible = true;
            this.colYeuCauTCDenGio.VisibleIndex = 13;
            this.colYeuCauTCDenGio.Width = 119;
            // 
            // colYeuCauTCKDenGio
            // 
            this.colYeuCauTCKDenGio.Caption = "Tăng ca KQT ra";
            this.colYeuCauTCKDenGio.FieldName = "YeuCauTCKDenGio";
            this.colYeuCauTCKDenGio.Name = "colYeuCauTCKDenGio";
            this.colYeuCauTCKDenGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colYeuCauTCKDenGio.Visible = true;
            this.colYeuCauTCKDenGio.VisibleIndex = 15;
            this.colYeuCauTCKDenGio.Width = 128;
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
            this.toolStrip2.Size = new System.Drawing.Size(1140, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripExcel
            // 
            this.toolStripExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripExcel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExcel.Image")));
            this.toolStripExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExcel.Name = "toolStripExcel";
            this.toolStripExcel.Size = new System.Drawing.Size(61, 22);
            this.toolStripExcel.Text = "Excel";
            this.toolStripExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // BCTongHopThongTinCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 587);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "BCTongHopThongTinCC";
            this.ShowIcon = false;
            this.Text = "BC tổng hợp thông tin CC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCTongHopThongTinCC_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn colDepName_Final;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay;
        private DevExpress.XtraGrid.Columns.GridColumn colTGQuetDen;
        private DevExpress.XtraGrid.Columns.GridColumn colDKLamThem;
        private DevExpress.XtraGrid.Columns.GridColumn colNghiCoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colCaLamDK;
        private DevExpress.XtraGrid.Columns.GridColumn colYeuCauSuaCongTuGio;
        private UC.ChonKyLuong chonKyLuong1;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraGrid.Columns.GridColumn colNghiKhongLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colTGQuetVe;
        private DevExpress.XtraGrid.Columns.GridColumn colYeuCauTCTuGio;
        private DevExpress.XtraGrid.Columns.GridColumn colYeuCauTCKTuGio;
        private DevExpress.XtraGrid.Columns.GridColumn colYeuCauSuaCongDenGio;
        private DevExpress.XtraGrid.Columns.GridColumn colYeuCauTCDenGio;
        private DevExpress.XtraGrid.Columns.GridColumn colYeuCauTCKDenGio;
    }
}