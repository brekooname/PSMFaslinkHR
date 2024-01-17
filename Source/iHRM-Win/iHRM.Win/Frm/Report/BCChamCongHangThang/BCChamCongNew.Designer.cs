namespace iHRM.Win.Frm.Report
{
    partial class BCChamCongNew
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
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongNgayCongThang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongNgayCongThucTe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongNghiCV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoGioLamCaDem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoGioTangCa150 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoGioTangCa200 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoGioTangCa300 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongNghiPhepNam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltongNghiCheDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltongNghiCoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongNghiLeTet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongNghiKhongPhep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongNghiKhongLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripExcel = new System.Windows.Forms.ToolStripButton();
            this.colTongNghiKLBH = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1362, 587);
            this.splitContainerControl1.SplitterPosition = 265;
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
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(265, 562);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2023, 5, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(7, 7);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(150, 100);
            this.chonKyLuong1.TabIndex = 12;
            this.chonKyLuong1.TuNgay = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(7, 114);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(256, 150);
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
            this.toolStrip1.Size = new System.Drawing.Size(265, 25);
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
            this.grd.Size = new System.Drawing.Size(1092, 562);
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
            this.colPosName,
            this.colDepName,
            this.colTongNgayCongThang,
            this.colTongNgayCongThucTe,
            this.colTongNghiCV,
            this.colSoGioLamCaDem,
            this.colSoGioTangCa150,
            this.colSoGioTangCa200,
            this.colSoGioTangCa300,
            this.colTongNghiPhepNam,
            this.coltongNghiCheDo,
            this.coltongNghiCoLuong,
            this.colTongNghiLeTet,
            this.colTongNghiKhongPhep,
            this.colTongNghiKhongLuong,
            this.colTongNghiKLBH});
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
            this.colEmployeeID.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeID", "Tổng: {0:#,0}")});
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 0;
            this.colEmployeeID.Width = 85;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Tên nhân viên";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 185;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Chức vụ";
            this.colPosName.FieldName = "PosName";
            this.colPosName.Name = "colPosName";
            this.colPosName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPosName.Visible = true;
            this.colPosName.VisibleIndex = 2;
            this.colPosName.Width = 186;
            // 
            // colDepName
            // 
            this.colDepName.Caption = "Phòng ban";
            this.colDepName.FieldName = "DepName";
            this.colDepName.Name = "colDepName";
            this.colDepName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName.Visible = true;
            this.colDepName.VisibleIndex = 3;
            this.colDepName.Width = 232;
            // 
            // colTongNgayCongThang
            // 
            this.colTongNgayCongThang.Caption = "Tổng ngày công tháng";
            this.colTongNgayCongThang.FieldName = "TongNgayCongThang";
            this.colTongNgayCongThang.Name = "colTongNgayCongThang";
            this.colTongNgayCongThang.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongNgayCongThang.Visible = true;
            this.colTongNgayCongThang.VisibleIndex = 4;
            this.colTongNgayCongThang.Width = 153;
            // 
            // colTongNgayCongThucTe
            // 
            this.colTongNgayCongThucTe.Caption = "Tổng ngày công thực tế";
            this.colTongNgayCongThucTe.FieldName = "TongNgayCongThucTe";
            this.colTongNgayCongThucTe.Name = "colTongNgayCongThucTe";
            this.colTongNgayCongThucTe.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongNgayCongThucTe.Visible = true;
            this.colTongNgayCongThucTe.VisibleIndex = 5;
            this.colTongNgayCongThucTe.Width = 163;
            // 
            // colTongNghiCV
            // 
            this.colTongNghiCV.Caption = "Số ngày nghỉ 70%";
            this.colTongNghiCV.FieldName = "TongNghiCV";
            this.colTongNghiCV.Name = "colTongNghiCV";
            this.colTongNghiCV.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongNghiCV.Visible = true;
            this.colTongNghiCV.VisibleIndex = 6;
            this.colTongNghiCV.Width = 127;
            // 
            // colSoGioLamCaDem
            // 
            this.colSoGioLamCaDem.Caption = "Số giờ làm việc ca đêm";
            this.colSoGioLamCaDem.FieldName = "SoGioLamCaDem";
            this.colSoGioLamCaDem.Name = "colSoGioLamCaDem";
            this.colSoGioLamCaDem.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoGioLamCaDem.Visible = true;
            this.colSoGioLamCaDem.VisibleIndex = 8;
            this.colSoGioLamCaDem.Width = 158;
            // 
            // colSoGioTangCa150
            // 
            this.colSoGioTangCa150.Caption = "Số giờ tăng ca 1.5";
            this.colSoGioTangCa150.FieldName = "SoGioTangCa150";
            this.colSoGioTangCa150.Name = "colSoGioTangCa150";
            this.colSoGioTangCa150.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoGioTangCa150.Visible = true;
            this.colSoGioTangCa150.VisibleIndex = 9;
            this.colSoGioTangCa150.Width = 124;
            // 
            // colSoGioTangCa200
            // 
            this.colSoGioTangCa200.Caption = "Số giờ tăng ca 2.0";
            this.colSoGioTangCa200.FieldName = "SoGioTangCa200";
            this.colSoGioTangCa200.Name = "colSoGioTangCa200";
            this.colSoGioTangCa200.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoGioTangCa200.Visible = true;
            this.colSoGioTangCa200.VisibleIndex = 10;
            this.colSoGioTangCa200.Width = 124;
            // 
            // colSoGioTangCa300
            // 
            this.colSoGioTangCa300.Caption = "Số giờ tăng ca 3.0";
            this.colSoGioTangCa300.FieldName = "SoGioTangCa300";
            this.colSoGioTangCa300.Name = "colSoGioTangCa300";
            this.colSoGioTangCa300.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoGioTangCa300.Visible = true;
            this.colSoGioTangCa300.VisibleIndex = 11;
            this.colSoGioTangCa300.Width = 124;
            // 
            // colTongNghiPhepNam
            // 
            this.colTongNghiPhepNam.Caption = "Tổng nghỉ phép năm";
            this.colTongNghiPhepNam.FieldName = "TongNghiPhepNam";
            this.colTongNghiPhepNam.Name = "colTongNghiPhepNam";
            this.colTongNghiPhepNam.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongNghiPhepNam.Visible = true;
            this.colTongNghiPhepNam.VisibleIndex = 13;
            this.colTongNghiPhepNam.Width = 143;
            // 
            // coltongNghiCheDo
            // 
            this.coltongNghiCheDo.Caption = "Tổng nghỉ chế độ";
            this.coltongNghiCheDo.FieldName = "tongNghiCheDo";
            this.coltongNghiCheDo.Name = "coltongNghiCheDo";
            this.coltongNghiCheDo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltongNghiCheDo.Visible = true;
            this.coltongNghiCheDo.VisibleIndex = 14;
            this.coltongNghiCheDo.Width = 123;
            // 
            // coltongNghiCoLuong
            // 
            this.coltongNghiCoLuong.Caption = "Tổng nghỉ có lương";
            this.coltongNghiCoLuong.FieldName = "tongNghiCoLuong";
            this.coltongNghiCoLuong.Name = "coltongNghiCoLuong";
            this.coltongNghiCoLuong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltongNghiCoLuong.Visible = true;
            this.coltongNghiCoLuong.VisibleIndex = 15;
            this.coltongNghiCoLuong.Width = 136;
            // 
            // colTongNghiLeTet
            // 
            this.colTongNghiLeTet.Caption = "Tổng nghỉ lễ tết";
            this.colTongNghiLeTet.FieldName = "TongNghiLeTet";
            this.colTongNghiLeTet.Name = "colTongNghiLeTet";
            this.colTongNghiLeTet.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongNghiLeTet.Visible = true;
            this.colTongNghiLeTet.VisibleIndex = 12;
            this.colTongNghiLeTet.Width = 114;
            // 
            // colTongNghiKhongPhep
            // 
            this.colTongNghiKhongPhep.Caption = "Tổng nghỉ không phép";
            this.colTongNghiKhongPhep.FieldName = "TongNghiKhongPhep";
            this.colTongNghiKhongPhep.Name = "colTongNghiKhongPhep";
            this.colTongNghiKhongPhep.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongNghiKhongPhep.Visible = true;
            this.colTongNghiKhongPhep.VisibleIndex = 7;
            this.colTongNghiKhongPhep.Width = 157;
            // 
            // colTongNghiKhongLuong
            // 
            this.colTongNghiKhongLuong.Caption = "Tổng nghỉ không lương";
            this.colTongNghiKhongLuong.FieldName = "TongNghiKhongLuong";
            this.colTongNghiKhongLuong.Name = "colTongNghiKhongLuong";
            this.colTongNghiKhongLuong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongNghiKhongLuong.Visible = true;
            this.colTongNghiKhongLuong.VisibleIndex = 16;
            this.colTongNghiKhongLuong.Width = 162;
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
            this.toolStrip2.Size = new System.Drawing.Size(1092, 25);
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
            this.toolStripExcel.Size = new System.Drawing.Size(61, 22);
            this.toolStripExcel.Text = "Excel";
            this.toolStripExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // colTongNghiKLBH
            // 
            this.colTongNghiKLBH.Caption = "Tổng nghỉ KLBH";
            this.colTongNghiKLBH.FieldName = "TongNghiKLBH";
            this.colTongNghiKLBH.Name = "colTongNghiKLBH";
            this.colTongNghiKLBH.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTongNghiKLBH.Visible = true;
            this.colTongNghiKLBH.VisibleIndex = 17;
            this.colTongNghiKLBH.Width = 147;
            // 
            // BCChamCongNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 587);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "BCChamCongNew";
            this.Text = "BC Chấm công tổng hợp tháng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCChamCongNew_KeyDown);
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
        private DevExpress.XtraGrid.Columns.GridColumn colDepName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private UC.ChonKyLuong chonKyLuong1;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraGrid.Columns.GridColumn colPosName;
        private DevExpress.XtraGrid.Columns.GridColumn colTongNgayCongThang;
        private DevExpress.XtraGrid.Columns.GridColumn colTongNgayCongThucTe;
        private DevExpress.XtraGrid.Columns.GridColumn colTongNghiCV;
        private DevExpress.XtraGrid.Columns.GridColumn colSoGioLamCaDem;
        private DevExpress.XtraGrid.Columns.GridColumn colSoGioTangCa150;
        private DevExpress.XtraGrid.Columns.GridColumn colSoGioTangCa200;
        private DevExpress.XtraGrid.Columns.GridColumn colSoGioTangCa300;
        private DevExpress.XtraGrid.Columns.GridColumn colTongNghiPhepNam;
        private DevExpress.XtraGrid.Columns.GridColumn coltongNghiCheDo;
        private DevExpress.XtraGrid.Columns.GridColumn coltongNghiCoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colTongNghiLeTet;
        private DevExpress.XtraGrid.Columns.GridColumn colTongNghiKhongPhep;
        private DevExpress.XtraGrid.Columns.GridColumn colTongNghiKhongLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colTongNghiKLBH;
    }
}