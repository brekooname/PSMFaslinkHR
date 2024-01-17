namespace iHRM.Win.Frm.QuetThe
{
    partial class frmDangKyLamThem
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
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.lblPB = new DevExpress.XtraEditors.LabelControl();
            this.lblTuKhoa = new DevExpress.XtraEditors.LabelControl();
            this.txtSearchKey = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName_Final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayDK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaLam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiLamThem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDuoiFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXemFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoQD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaSang_TuGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaSang_DenGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaChieu_TuGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaChieu_DenGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaCaDem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDKLamThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripGoDuyet = new System.Windows.Forms.ToolStripButton();
            this.toolStripAccept = new System.Windows.Forms.ToolStripButton();
            this.toolStripAcceptAll = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.chonKyLuong1);
            this.splitContainerControl1.Panel1.Controls.Add(this.chonPhongBan1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPB);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTuKhoa);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtSearchKey);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1362, 570);
            this.splitContainerControl1.SplitterPosition = 177;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 6, 30, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = true;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(6, 82);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(170, 99);
            this.chonKyLuong1.TabIndex = 7;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 6, 1, 0, 0, 0, 0);
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonPhongBan1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chonPhongBan1.Location = new System.Drawing.Point(6, 203);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(170, 28);
            this.chonPhongBan1.TabIndex = 6;
            // 
            // lblPB
            // 
            this.lblPB.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPB.Location = new System.Drawing.Point(6, 184);
            this.lblPB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(74, 19);
            this.lblPB.TabIndex = 3;
            this.lblPB.Text = "Phòng ban:";
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuKhoa.Location = new System.Drawing.Point(6, 31);
            this.lblTuKhoa.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(63, 17);
            this.lblTuKhoa.TabIndex = 3;
            this.lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchKey.Location = new System.Drawing.Point(6, 50);
            this.txtSearchKey.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchKey.Properties.Appearance.Options.UseFont = true;
            this.txtSearchKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSearchKey.Size = new System.Drawing.Size(170, 26);
            this.txtSearchKey.TabIndex = 4;
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
            this.toolStrip1.Size = new System.Drawing.Size(177, 26);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 27);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1180, 543);
            this.panelControl1.TabIndex = 4;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.grd);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1176, 539);
            this.panelControl3.TabIndex = 5;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit2});
            this.grd.Size = new System.Drawing.Size(1176, 539);
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
            this.colCMND,
            this.colDepName_Final,
            this.colPosName,
            this.colNgayDK,
            this.colCaLam,
            this.gridColumn2,
            this.colLoaiLamThem,
            this.colDuoiFile,
            this.colXemFile,
            this.colFile,
            this.colSoQD,
            this.colCaSang_TuGio,
            this.colCaSang_DenGio,
            this.colCaChieu_TuGio,
            this.colCaChieu_DenGio,
            this.colAccept,
            this.colLaCaDem});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsSelection.MultiSelect = true;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grv_RowCellClick);
            this.grv.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grv_RowStyle);
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
            this.colEmployeeID.Width = 99;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Nhân viên";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 203;
            // 
            // colCMND
            // 
            this.colCMND.Caption = "Số CMND";
            this.colCMND.FieldName = "IDCard";
            this.colCMND.Name = "colCMND";
            this.colCMND.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCMND.Width = 81;
            // 
            // colDepName_Final
            // 
            this.colDepName_Final.Caption = "Phòng ban";
            this.colDepName_Final.FieldName = "DepName_Final";
            this.colDepName_Final.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colDepName_Final.Name = "colDepName_Final";
            this.colDepName_Final.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName_Final.Visible = true;
            this.colDepName_Final.VisibleIndex = 2;
            this.colDepName_Final.Width = 143;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Chức vụ";
            this.colPosName.FieldName = "PosName";
            this.colPosName.Name = "colPosName";
            this.colPosName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPosName.Visible = true;
            this.colPosName.VisibleIndex = 3;
            this.colPosName.Width = 132;
            // 
            // colNgayDK
            // 
            this.colNgayDK.Caption = "Ngày ĐK";
            this.colNgayDK.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayDK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayDK.FieldName = "ngay";
            this.colNgayDK.Name = "colNgayDK";
            this.colNgayDK.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayDK.Visible = true;
            this.colNgayDK.VisibleIndex = 4;
            this.colNgayDK.Width = 132;
            // 
            // colCaLam
            // 
            this.colCaLam.Caption = "Ca làm";
            this.colCaLam.FieldName = "calam";
            this.colCaLam.Name = "colCaLam";
            this.colCaLam.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCaLam.Visible = true;
            this.colCaLam.VisibleIndex = 6;
            this.colCaLam.Width = 103;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "HSL";
            this.gridColumn2.DisplayFormat.FormatString = "#,0";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "heSoLuong";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // colLoaiLamThem
            // 
            this.colLoaiLamThem.Caption = "Loại làm thêm";
            this.colLoaiLamThem.FieldName = "tenLoai";
            this.colLoaiLamThem.Name = "colLoaiLamThem";
            this.colLoaiLamThem.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLoaiLamThem.Visible = true;
            this.colLoaiLamThem.VisibleIndex = 5;
            this.colLoaiLamThem.Width = 154;
            // 
            // colDuoiFile
            // 
            this.colDuoiFile.Caption = "Đuôi file";
            this.colDuoiFile.FieldName = "duoiFile";
            this.colDuoiFile.Name = "colDuoiFile";
            this.colDuoiFile.Visible = true;
            this.colDuoiFile.VisibleIndex = 8;
            // 
            // colXemFile
            // 
            this.colXemFile.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colXemFile.AppearanceCell.Options.UseFont = true;
            this.colXemFile.AppearanceCell.Options.UseTextOptions = true;
            this.colXemFile.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXemFile.Caption = "Thao tác";
            this.colXemFile.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.colXemFile.FieldName = "Xem file";
            this.colXemFile.Name = "colXemFile";
            this.colXemFile.Visible = true;
            this.colXemFile.VisibleIndex = 9;
            this.colXemFile.Width = 74;
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.repositoryItemHyperLinkEdit2.NullText = "Xem file";
            // 
            // colFile
            // 
            this.colFile.Caption = "Data file";
            this.colFile.FieldName = "dataFile";
            this.colFile.Name = "colFile";
            // 
            // colSoQD
            // 
            this.colSoQD.Caption = "Số Q.định";
            this.colSoQD.FieldName = "soQdDkLamThem";
            this.colSoQD.Name = "colSoQD";
            this.colSoQD.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoQD.Visible = true;
            this.colSoQD.VisibleIndex = 7;
            // 
            // colCaSang_TuGio
            // 
            this.colCaSang_TuGio.Caption = "Ca sáng - Từ giờ";
            this.colCaSang_TuGio.FieldName = "CaSang_TuGio";
            this.colCaSang_TuGio.Name = "colCaSang_TuGio";
            this.colCaSang_TuGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCaSang_TuGio.Visible = true;
            this.colCaSang_TuGio.VisibleIndex = 10;
            this.colCaSang_TuGio.Width = 120;
            // 
            // colCaSang_DenGio
            // 
            this.colCaSang_DenGio.Caption = "Ca sáng - Đến giờ";
            this.colCaSang_DenGio.FieldName = "CaSang_DenGio";
            this.colCaSang_DenGio.Name = "colCaSang_DenGio";
            this.colCaSang_DenGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCaSang_DenGio.Visible = true;
            this.colCaSang_DenGio.VisibleIndex = 11;
            this.colCaSang_DenGio.Width = 126;
            // 
            // colCaChieu_TuGio
            // 
            this.colCaChieu_TuGio.Caption = "Ca chiều - Từ giờ";
            this.colCaChieu_TuGio.DisplayFormat.FormatString = "HH:mm";
            this.colCaChieu_TuGio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCaChieu_TuGio.FieldName = "CaChieu_TuGio";
            this.colCaChieu_TuGio.Name = "colCaChieu_TuGio";
            this.colCaChieu_TuGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCaChieu_TuGio.Visible = true;
            this.colCaChieu_TuGio.VisibleIndex = 12;
            this.colCaChieu_TuGio.Width = 130;
            // 
            // colCaChieu_DenGio
            // 
            this.colCaChieu_DenGio.Caption = "Ca chiều - Đến giờ";
            this.colCaChieu_DenGio.FieldName = "CaChieu_DenGio";
            this.colCaChieu_DenGio.Name = "colCaChieu_DenGio";
            this.colCaChieu_DenGio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCaChieu_DenGio.Visible = true;
            this.colCaChieu_DenGio.VisibleIndex = 13;
            this.colCaChieu_DenGio.Width = 130;
            // 
            // colAccept
            // 
            this.colAccept.Caption = "Chốt dữ liệu";
            this.colAccept.FieldName = "colAccept";
            this.colAccept.Name = "colAccept";
            this.colAccept.UnboundExpression = "IIF([isAccept]== 1,\'Đã chốt\',\'Chưa chốt\')";
            this.colAccept.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colAccept.Width = 103;
            // 
            // colLaCaDem
            // 
            this.colLaCaDem.Caption = "Là ca đêm";
            this.colLaCaDem.FieldName = "isCaDem";
            this.colLaCaDem.Name = "colLaCaDem";
            this.colLaCaDem.Visible = true;
            this.colLaCaDem.VisibleIndex = 14;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripDKLamThem,
            this.toolStripDelete,
            this.toolStripGoDuyet,
            this.toolStripAccept,
            this.toolStripAcceptAll});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1180, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(62, 24);
            this.toolStripButton2.Text = "Excel";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripDKLamThem
            // 
            this.toolStripDKLamThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDKLamThem.Image = global::iHRM.Win.Properties.Resources.btnAdd_Image;
            this.toolStripDKLamThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDKLamThem.Name = "toolStripDKLamThem";
            this.toolStripDKLamThem.Size = new System.Drawing.Size(142, 24);
            this.toolStripDKLamThem.Text = "Đăng ký làm thêm";
            this.toolStripDKLamThem.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDelete.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.toolStripDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(79, 24);
            this.toolStripDelete.Text = "Xóa bỏ";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripGoDuyet
            // 
            this.toolStripGoDuyet.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripGoDuyet.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.toolStripGoDuyet.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.toolStripGoDuyet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripGoDuyet.Name = "toolStripGoDuyet";
            this.toolStripGoDuyet.Size = new System.Drawing.Size(122, 24);
            this.toolStripGoDuyet.Text = "Gỡ chốt dữ liệu";
            this.toolStripGoDuyet.Visible = false;
            this.toolStripGoDuyet.Click += new System.EventHandler(this.toolStripGoDuyet_Click);
            // 
            // toolStripAccept
            // 
            this.toolStripAccept.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripAccept.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripAccept.Image = global::iHRM.Win.Properties.Resources.ico20_tick;
            this.toolStripAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAccept.Name = "toolStripAccept";
            this.toolStripAccept.Size = new System.Drawing.Size(103, 24);
            this.toolStripAccept.Text = "Chốt dữ liệu";
            this.toolStripAccept.ToolTipText = "Duyệt";
            this.toolStripAccept.Visible = false;
            this.toolStripAccept.Click += new System.EventHandler(this.toolStripAccept_Click);
            // 
            // toolStripAcceptAll
            // 
            this.toolStripAcceptAll.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripAcceptAll.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripAcceptAll.Image = global::iHRM.Win.Properties.Resources.ico20_tick;
            this.toolStripAcceptAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAcceptAll.Name = "toolStripAcceptAll";
            this.toolStripAcceptAll.Size = new System.Drawing.Size(140, 24);
            this.toolStripAcceptAll.Text = "Chốt tất cả dữ liệu";
            this.toolStripAcceptAll.ToolTipText = "Duyệt tất cả";
            this.toolStripAcceptAll.Visible = false;
            this.toolStripAcceptAll.Click += new System.EventHandler(this.toolStripAcceptAll_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDangKyLamThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 570);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "frmDangKyLamThem";
            this.Text = "Đăng ký làm thêm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDangKyCaLam_FormClosed);
            this.Load += new System.EventHandler(this.frmDangKyCaLam_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDangKyLamThem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl lblTuKhoa;
        private DevExpress.XtraEditors.TextEdit txtSearchKey;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private DevExpress.XtraEditors.LabelControl lblPB;
        private UC.ChonPhongBan chonPhongBan1;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName_Final;
        private DevExpress.XtraGrid.Columns.GridColumn colPosName;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayDK;
        private DevExpress.XtraGrid.Columns.GridColumn colCaLam;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripButton toolStripDKLamThem;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiLamThem;
        private DevExpress.XtraGrid.Columns.GridColumn colDuoiFile;
        private DevExpress.XtraGrid.Columns.GridColumn colXemFile;
        private DevExpress.XtraGrid.Columns.GridColumn colFile;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colSoQD;
        private DevExpress.XtraGrid.Columns.GridColumn colCaSang_TuGio;
        private DevExpress.XtraGrid.Columns.GridColumn colCaSang_DenGio;
        private DevExpress.XtraGrid.Columns.GridColumn colCaChieu_TuGio;
        private DevExpress.XtraGrid.Columns.GridColumn colCaChieu_DenGio;
        private System.Windows.Forms.ToolStripButton toolStripGoDuyet;
        private System.Windows.Forms.ToolStripButton toolStripAcceptAll;
        private System.Windows.Forms.ToolStripButton toolStripAccept;
        private DevExpress.XtraGrid.Columns.GridColumn colAccept;
        private DevExpress.XtraGrid.Columns.GridColumn colLaCaDem;
        private UC.ChonKyLuong chonKyLuong1;
    }
}