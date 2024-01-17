namespace iHRM.Win.Frm.Luong_v3
{
    partial class frmNhapThamSo_Tax
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
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.lblPB = new DevExpress.XtraEditors.LabelControl();
            this.lblThang = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.txtSearchThang = new DevExpress.XtraEditors.DateEdit();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colEmployeeID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNgayVaoLam = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPosName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDepName_Final = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripXoaDLTheoNhom = new System.Windows.Forms.ToolStripButton();
            this.toolStripTaiLaiDS = new System.Windows.Forms.ToolStripButton();
            this.toolStripKhoiTao = new System.Windows.Forms.ToolStripButton();
            this.toolStripHutTuBangLuong = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.chonPhongBan1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPB);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblThang);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtSearchThang);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1391, 488);
            this.splitContainerControl1.SplitterPosition = 211;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonPhongBan1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chonPhongBan1.Location = new System.Drawing.Point(3, 124);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(199, 28);
            this.chonPhongBan1.TabIndex = 9;
            // 
            // lblPB
            // 
            this.lblPB.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPB.Location = new System.Drawing.Point(3, 105);
            this.lblPB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(76, 19);
            this.lblPB.TabIndex = 8;
            this.lblPB.Text = "Phòng ban";
            // 
            // lblThang
            // 
            this.lblThang.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblThang.Location = new System.Drawing.Point(3, 54);
            this.lblThang.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(45, 19);
            this.lblThang.TabIndex = 3;
            this.lblThang.Text = "Tháng";
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
            this.toolStrip1.Size = new System.Drawing.Size(181, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(81, 22);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtSearchThang
            // 
            this.txtSearchThang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchThang.EditValue = null;
            this.txtSearchThang.Location = new System.Drawing.Point(3, 73);
            this.txtSearchThang.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtSearchThang.Name = "txtSearchThang";
            this.txtSearchThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtSearchThang.Properties.Appearance.Options.UseFont = true;
            this.txtSearchThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSearchThang.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSearchThang.Properties.DisplayFormat.FormatString = "MM - yyyy";
            this.txtSearchThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtSearchThang.Properties.Mask.EditMask = "MM - yyyy";
            this.txtSearchThang.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.txtSearchThang.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.txtSearchThang.Size = new System.Drawing.Size(199, 26);
            this.txtSearchThang.TabIndex = 4;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 27);
            this.grd.MainView = this.bandedGridView1;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemDateEdit1,
            this.repositoryItemCheckEdit1});
            this.grd.Size = new System.Drawing.Size(1205, 461);
            this.grd.TabIndex = 5;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.bandedGridView1.Appearance.BandPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.BandPanel.Options.UseTextOptions = true;
            this.bandedGridView1.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.bandedGridView1.Appearance.Row.Options.UseFont = true;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand1});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colEmployeeID,
            this.colEmployeeName,
            this.colNgayVaoLam,
            this.colPosName,
            this.colDepName_Final});
            this.bandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.bandedGridView1.GridControl = this.grd;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsDetail.EnableMasterViewMode = false;
            this.bandedGridView1.OptionsSelection.MultiSelect = true;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.OptionsView.ShowAutoFilterRow = true;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bandedGridView1_KeyDown);
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Nhân viên";
            this.gridBand2.Columns.Add(this.colEmployeeID);
            this.gridBand2.Columns.Add(this.colEmployeeName);
            this.gridBand2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 359;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Mã";
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsColumn.AllowEdit = false;
            this.colEmployeeID.OptionsColumn.ReadOnly = true;
            this.colEmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeID", "Tổng = {0:#,#}")});
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.Width = 106;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Nhân viên";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.AllowEdit = false;
            this.colEmployeeName.OptionsColumn.ReadOnly = true;
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.Width = 253;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Thông tin";
            this.gridBand1.Columns.Add(this.colNgayVaoLam);
            this.gridBand1.Columns.Add(this.colPosName);
            this.gridBand1.Columns.Add(this.colDepName_Final);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 1;
            this.gridBand1.Width = 450;
            // 
            // colNgayVaoLam
            // 
            this.colNgayVaoLam.Caption = "Ngày vào làm";
            this.colNgayVaoLam.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayVaoLam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayVaoLam.FieldName = "AppliedDate";
            this.colNgayVaoLam.Name = "colNgayVaoLam";
            this.colNgayVaoLam.OptionsColumn.AllowEdit = false;
            this.colNgayVaoLam.OptionsColumn.ReadOnly = true;
            this.colNgayVaoLam.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNgayVaoLam.Visible = true;
            this.colNgayVaoLam.Width = 145;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Vị trí";
            this.colPosName.FieldName = "PosName";
            this.colPosName.Name = "colPosName";
            this.colPosName.OptionsColumn.AllowEdit = false;
            this.colPosName.OptionsColumn.ReadOnly = true;
            this.colPosName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPosName.Visible = true;
            this.colPosName.Width = 128;
            // 
            // colDepName_Final
            // 
            this.colDepName_Final.Caption = "Phòng ban";
            this.colDepName_Final.FieldName = "DepName_Final";
            this.colDepName_Final.Name = "colDepName_Final";
            this.colDepName_Final.OptionsColumn.AllowEdit = false;
            this.colDepName_Final.OptionsColumn.ReadOnly = true;
            this.colDepName_Final.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName_Final.Visible = true;
            this.colDepName_Final.Width = 177;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnImport,
            this.toolStripXoaDLTheoNhom,
            this.toolStripTaiLaiDS,
            this.toolStripKhoiTao,
            this.toolStripHutTuBangLuong,
            this.toolStripButton5});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1205, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 24);
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnImport.Image = global::iHRM.Win.Properties.Resources.btnImport_Image;
            this.btnImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(106, 24);
            this.btnImport.Text = "Nhập từ excel";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // toolStripXoaDLTheoNhom
            // 
            this.toolStripXoaDLTheoNhom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripXoaDLTheoNhom.Image = global::iHRM.Win.Properties.Resources.btnDelete_Image;
            this.toolStripXoaDLTheoNhom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripXoaDLTheoNhom.Name = "toolStripXoaDLTheoNhom";
            this.toolStripXoaDLTheoNhom.Size = new System.Drawing.Size(222, 24);
            this.toolStripXoaDLTheoNhom.Text = "Xóa dữ liệu nhập theo phòng ban";
            this.toolStripXoaDLTheoNhom.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripTaiLaiDS
            // 
            this.toolStripTaiLaiDS.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTaiLaiDS.Image = global::iHRM.Win.Properties.Resources.btnRefresh_Image;
            this.toolStripTaiLaiDS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTaiLaiDS.Name = "toolStripTaiLaiDS";
            this.toolStripTaiLaiDS.Size = new System.Drawing.Size(204, 24);
            this.toolStripTaiLaiDS.Text = "Tải thêm danh sách nhân viên";
            this.toolStripTaiLaiDS.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripKhoiTao
            // 
            this.toolStripKhoiTao.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripKhoiTao.Image = global::iHRM.Win.Properties.Resources.btnAdd_Image;
            this.toolStripKhoiTao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripKhoiTao.Name = "toolStripKhoiTao";
            this.toolStripKhoiTao.Size = new System.Drawing.Size(162, 24);
            this.toolStripKhoiTao.Text = "Khởi tạo dữ liệu đầu kỳ";
            this.toolStripKhoiTao.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripHutTuBangLuong
            // 
            this.toolStripHutTuBangLuong.Image = global::iHRM.Win.Properties.Resources.btnExport_Image;
            this.toolStripHutTuBangLuong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripHutTuBangLuong.Name = "toolStripHutTuBangLuong";
            this.toolStripHutTuBangLuong.Size = new System.Drawing.Size(135, 24);
            this.toolStripHutTuBangLuong.Text = "Hút từ bảng lương";
            this.toolStripHutTuBangLuong.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = global::iHRM.Win.Properties.Resources.btnExport_Image;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(184, 24);
            this.toolStripButton5.Text = "Hút từ bảng lương báo cáo";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // frmNhapThamSo_Tax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 488);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "frmNhapThamSo_Tax";
            this.Text = "Nhập tham số thuế";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhapThamSo_Tax_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl lblThang;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private DevExpress.XtraGrid.GridControl grd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.DateEdit txtSearchThang;
        private UC.ChonPhongBan chonPhongBan1;
        private DevExpress.XtraEditors.LabelControl lblPB;
        private System.Windows.Forms.ToolStripButton btnImport;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNgayVaoLam;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPosName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDepName_Final;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private System.Windows.Forms.ToolStripButton toolStripKhoiTao;
        private System.Windows.Forms.ToolStripButton toolStripTaiLaiDS;
        private System.Windows.Forms.ToolStripButton toolStripXoaDLTheoNhom;
        private System.Windows.Forms.ToolStripButton toolStripHutTuBangLuong;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}