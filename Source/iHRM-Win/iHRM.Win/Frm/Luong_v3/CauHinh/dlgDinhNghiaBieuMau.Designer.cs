namespace iHRM.Win.Frm.Luong_v3
{
    partial class dlgDinhNghiaBieuMau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDinhNghiaBieuMau));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.lblTenBieuMau = new DevExpress.XtraEditors.LabelControl();
            this.lblTrangThai = new DevExpress.XtraEditors.LabelControl();
            this.chkStatus = new DevExpress.XtraEditors.CheckEdit();
            this.lblTenFile = new DevExpress.XtraEditors.LabelControl();
            this.txtFilePath = new DevExpress.XtraEditors.ButtonEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.lblHTML = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHienBC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThamSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkShowTotalGroup = new DevExpress.XtraEditors.CheckEdit();
            this.lblHienTongCong = new DevExpress.XtraEditors.LabelControl();
            this.txtNhomNV = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblNhomHuongLuong = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTotalGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomNV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(1047, 86);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(900, 140);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 43);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(208, 33);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtTen.Properties.Appearance.Options.UseFont = true;
            this.txtTen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTen.Size = new System.Drawing.Size(803, 28);
            this.txtTen.TabIndex = 2;
            // 
            // lblTenBieuMau
            // 
            this.lblTenBieuMau.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblTenBieuMau.Location = new System.Drawing.Point(32, 38);
            this.lblTenBieuMau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.lblTenBieuMau.Name = "lblTenBieuMau";
            this.lblTenBieuMau.Size = new System.Drawing.Size(101, 21);
            this.lblTenBieuMau.TabIndex = 11;
            this.lblTenBieuMau.Text = "Tên biểu mẫu";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblTrangThai.Location = new System.Drawing.Point(32, 117);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(76, 21);
            this.lblTrangThai.TabIndex = 5;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // chkStatus
            // 
            this.chkStatus.Location = new System.Drawing.Point(208, 114);
            this.chkStatus.Margin = new System.Windows.Forms.Padding(4);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.chkStatus.Properties.Appearance.Options.UseFont = true;
            this.chkStatus.Properties.Caption = "Có sử dụng";
            this.chkStatus.Size = new System.Drawing.Size(149, 25);
            this.chkStatus.TabIndex = 7;
            // 
            // lblTenFile
            // 
            this.lblTenFile.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblTenFile.Location = new System.Drawing.Point(32, 80);
            this.lblTenFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.lblTenFile.Name = "lblTenFile";
            this.lblTenFile.Size = new System.Drawing.Size(53, 19);
            this.lblTenFile.TabIndex = 11;
            this.lblTenFile.Text = "Tên file";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(208, 75);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtFilePath.Properties.Appearance.Options.UseFont = true;
            this.txtFilePath.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFilePath.Size = new System.Drawing.Size(803, 28);
            this.txtFilePath.TabIndex = 2;
            this.txtFilePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtNhom_ButtonClick);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 86);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1047, 585);
            this.xtraTabControl1.TabIndex = 12;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnSave);
            this.xtraTabPage1.Controls.Add(this.lblTenBieuMau);
            this.xtraTabPage1.Controls.Add(this.chkStatus);
            this.xtraTabPage1.Controls.Add(this.txtFilePath);
            this.xtraTabPage1.Controls.Add(this.lblHTML);
            this.xtraTabPage1.Controls.Add(this.lblTrangThai);
            this.xtraTabPage1.Controls.Add(this.lblTenFile);
            this.xtraTabPage1.Controls.Add(this.txtTen);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1041, 553);
            this.xtraTabPage1.Text = "Thông tin chung";
            // 
            // lblHTML
            // 
            this.lblHTML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHTML.Appearance.Font = new System.Drawing.Font("Tahoma", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHTML.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblHTML.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblHTML.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHTML.Location = new System.Drawing.Point(557, 396);
            this.lblHTML.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.lblHTML.Name = "lblHTML";
            this.lblHTML.Size = new System.Drawing.Size(453, 143);
            this.lblHTML.TabIndex = 5;
            this.lblHTML.Text = "html";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.grd);
            this.xtraTabPage2.Controls.Add(this.panel2);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageEnabled = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(1041, 553);
            this.xtraTabPage2.Text = "Các tham số xuất ra";
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grd.Location = new System.Drawing.Point(0, 97);
            this.grd.MainView = this.grv;
            this.grd.Margin = new System.Windows.Forms.Padding(4);
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grd.Size = new System.Drawing.Size(1041, 456);
            this.grd.TabIndex = 6;
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
            this.colMa,
            this.colTen,
            this.colHienBC,
            this.colNhom,
            this.colThamSo});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.GroupCount = 1;
            this.grv.Name = "grv";
            this.grv.OptionsDetail.EnableMasterViewMode = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNhom, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMa
            // 
            this.colMa.Caption = "Mã";
            this.colMa.FieldName = "ma";
            this.colMa.Name = "colMa";
            this.colMa.OptionsColumn.AllowEdit = false;
            this.colMa.OptionsColumn.FixedWidth = true;
            this.colMa.OptionsColumn.ReadOnly = true;
            this.colMa.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMa.Visible = true;
            this.colMa.VisibleIndex = 0;
            this.colMa.Width = 188;
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên";
            this.colTen.FieldName = "ten";
            this.colTen.Name = "colTen";
            this.colTen.OptionsColumn.AllowEdit = false;
            this.colTen.OptionsColumn.ReadOnly = true;
            this.colTen.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 1;
            this.colTen.Width = 947;
            // 
            // colHienBC
            // 
            this.colHienBC.Caption = "Hiện BC";
            this.colHienBC.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colHienBC.FieldName = "hienTrenBangLuong";
            this.colHienBC.Name = "colHienBC";
            this.colHienBC.OptionsColumn.FixedWidth = true;
            this.colHienBC.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colHienBC.Visible = true;
            this.colHienBC.VisibleIndex = 3;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colNhom
            // 
            this.colNhom.Caption = "Nhóm";
            this.colNhom.FieldName = "nhom";
            this.colNhom.Name = "colNhom";
            this.colNhom.OptionsColumn.AllowEdit = false;
            this.colNhom.OptionsColumn.ReadOnly = true;
            this.colNhom.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNhom.Visible = true;
            this.colNhom.VisibleIndex = 5;
            // 
            // colThamSo
            // 
            this.colThamSo.Caption = "Tham số";
            this.colThamSo.FieldName = "tsIdx";
            this.colThamSo.Name = "colThamSo";
            this.colThamSo.OptionsColumn.AllowEdit = false;
            this.colThamSo.OptionsColumn.ReadOnly = true;
            this.colThamSo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colThamSo.Visible = true;
            this.colThamSo.VisibleIndex = 2;
            this.colThamSo.Width = 272;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkShowTotalGroup);
            this.panel2.Controls.Add(this.lblHienTongCong);
            this.panel2.Controls.Add(this.txtNhomNV);
            this.panel2.Controls.Add(this.simpleButtonSave);
            this.panel2.Controls.Add(this.lblNhomHuongLuong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1041, 97);
            this.panel2.TabIndex = 7;
            // 
            // chkShowTotalGroup
            // 
            this.chkShowTotalGroup.Location = new System.Drawing.Point(307, 49);
            this.chkShowTotalGroup.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowTotalGroup.Name = "chkShowTotalGroup";
            this.chkShowTotalGroup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.chkShowTotalGroup.Properties.Appearance.Options.UseFont = true;
            this.chkShowTotalGroup.Properties.Caption = "Hiện trên mỗi nhóm";
            this.chkShowTotalGroup.Size = new System.Drawing.Size(192, 25);
            this.chkShowTotalGroup.TabIndex = 11;
            // 
            // lblHienTongCong
            // 
            this.lblHienTongCong.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblHienTongCong.Location = new System.Drawing.Point(307, 22);
            this.lblHienTongCong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.lblHienTongCong.Name = "lblHienTongCong";
            this.lblHienTongCong.Size = new System.Drawing.Size(111, 21);
            this.lblHienTongCong.TabIndex = 10;
            this.lblHienTongCong.Text = "Hiện tổng cộng";
            // 
            // txtNhomNV
            // 
            this.txtNhomNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNhomNV.Location = new System.Drawing.Point(15, 46);
            this.txtNhomNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtNhomNV.Name = "txtNhomNV";
            this.txtNhomNV.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtNhomNV.Properties.Appearance.Options.UseFont = true;
            this.txtNhomNV.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtNhomNV.Properties.AppearanceDropDown.Options.UseFont = true;
            this.txtNhomNV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtNhomNV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNhomNV.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ten", "Module")});
            this.txtNhomNV.Properties.DisplayMember = "ten";
            this.txtNhomNV.Properties.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.AutoSearch;
            this.txtNhomNV.Properties.NullText = "";
            this.txtNhomNV.Properties.PopupSizeable = false;
            this.txtNhomNV.Properties.ValueMember = "id";
            this.txtNhomNV.Size = new System.Drawing.Size(405, 28);
            this.txtNhomNV.TabIndex = 9;
            this.txtNhomNV.EditValueChanged += new System.EventHandler(this.txtNhomNV_EditValueChanged);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.simpleButtonSave.Appearance.Options.UseFont = true;
            this.simpleButtonSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.simpleButtonSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButtonSave.Location = new System.Drawing.Point(921, 34);
            this.simpleButtonSave.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(111, 43);
            this.simpleButtonSave.TabIndex = 1;
            this.simpleButtonSave.Text = "Lưu lại";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lblNhomHuongLuong
            // 
            this.lblNhomHuongLuong.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblNhomHuongLuong.Location = new System.Drawing.Point(15, 22);
            this.lblNhomHuongLuong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.lblNhomHuongLuong.Name = "lblNhomHuongLuong";
            this.lblNhomHuongLuong.Size = new System.Drawing.Size(140, 21);
            this.lblNhomHuongLuong.TabIndex = 8;
            this.lblNhomHuongLuong.Text = "Nhóm hưởng lương";
            // 
            // dlgDinhNghiaBieuMau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 671);
            this.Controls.Add(this.xtraTabControl1);
            this.Form_Description = "Định nghĩa biểu mẫu xuất bảng lương";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Định nghĩa biểu mẫu";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDinhNghiaBieuMau";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDangKyCaLam_FormClosing);
            this.Load += new System.EventHandler(this.dlgDinhNghiaThamSo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dlgDinhNghiaBieuMau_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowTotalGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomNV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.CheckEdit chkStatus;
        private DevExpress.XtraEditors.LabelControl lblTenBieuMau;
        private DevExpress.XtraEditors.LabelControl lblTrangThai;
        private DevExpress.XtraEditors.LabelControl lblTenFile;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.ButtonEdit txtFilePath;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colMa;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colHienBC;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNhom;
        private DevExpress.XtraGrid.Columns.GridColumn colThamSo;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.LookUpEdit txtNhomNV;
        private DevExpress.XtraEditors.LabelControl lblNhomHuongLuong;
        private DevExpress.XtraEditors.CheckEdit chkShowTotalGroup;
        private DevExpress.XtraEditors.LabelControl lblHienTongCong;
        private DevExpress.XtraEditors.LabelControl lblHTML;
    }
}