namespace iHRM.Win.Frm.Report
{
    partial class BCCaoDuLieuNhanVienChamCong
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaChamCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltenchamcong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngayquet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsoMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditMay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.coltgQuet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName_Old = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnXuatExel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 172);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1007, 345);
            this.panelControl1.TabIndex = 7;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(2, 2);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditMay});
            this.grd.Size = new System.Drawing.Size(1003, 341);
            this.grd.TabIndex = 4;
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
            this.colSTT,
            this.colMaChamCong,
            this.coltenchamcong,
            this.EmployeeID,
            this.colEmployeeID,
            this.colEmpTypeName,
            this.colDepName,
            this.colngayquet,
            this.colsoMay,
            this.coltgQuet,
            this.colDepName_Old});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.grv.OptionsBehavior.AutoExpandAllGroups = true;
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsPrint.UsePrintStyles = false;
            this.grv.OptionsSelection.MultiSelect = true;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupedColumns = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // colSTT
            // 
            this.colSTT.Caption = "Index";
            this.colSTT.FieldName = "idx";
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colMaChamCong
            // 
            this.colMaChamCong.Caption = "Mã Chấm Công";
            this.colMaChamCong.FieldName = "maChamCong";
            this.colMaChamCong.Name = "colMaChamCong";
            this.colMaChamCong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaChamCong.Visible = true;
            this.colMaChamCong.VisibleIndex = 0;
            this.colMaChamCong.Width = 131;
            // 
            // coltenchamcong
            // 
            this.coltenchamcong.Caption = "Tên Chấm Công";
            this.coltenchamcong.FieldName = "tenChamCong";
            this.coltenchamcong.Name = "coltenchamcong";
            this.coltenchamcong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltenchamcong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "tenChamCong", "Tổng = {0:#,#}")});
            this.coltenchamcong.Visible = true;
            this.coltenchamcong.VisibleIndex = 1;
            this.coltenchamcong.Width = 195;
            // 
            // EmployeeID
            // 
            this.EmployeeID.Caption = "Mã Nhân Viên";
            this.EmployeeID.FieldName = "EmployeeID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.EmployeeID.Visible = true;
            this.EmployeeID.VisibleIndex = 2;
            this.EmployeeID.Width = 139;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Nhân Viên";
            this.colEmployeeID.FieldName = "EmployeeName";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 3;
            this.colEmployeeID.Width = 190;
            // 
            // colEmpTypeName
            // 
            this.colEmpTypeName.Caption = "Chức vụ";
            this.colEmpTypeName.FieldName = "PosName";
            this.colEmpTypeName.Name = "colEmpTypeName";
            this.colEmpTypeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmpTypeName.Visible = true;
            this.colEmpTypeName.VisibleIndex = 4;
            this.colEmpTypeName.Width = 171;
            // 
            // colDepName
            // 
            this.colDepName.Caption = "Phòng Ban";
            this.colDepName.FieldName = "DepName";
            this.colDepName.Name = "colDepName";
            this.colDepName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName.Visible = true;
            this.colDepName.VisibleIndex = 5;
            this.colDepName.Width = 244;
            // 
            // colngayquet
            // 
            this.colngayquet.Caption = "Ngày Quẹt MCC";
            this.colngayquet.FieldName = "ngayQuet";
            this.colngayquet.Name = "colngayquet";
            this.colngayquet.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colngayquet.Visible = true;
            this.colngayquet.VisibleIndex = 6;
            this.colngayquet.Width = 135;
            // 
            // colsoMay
            // 
            this.colsoMay.Caption = "Máy Chấm Công";
            this.colsoMay.ColumnEdit = this.repositoryItemLookUpEditMay;
            this.colsoMay.FieldName = "soMay";
            this.colsoMay.Name = "colsoMay";
            this.colsoMay.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colsoMay.Visible = true;
            this.colsoMay.VisibleIndex = 7;
            this.colsoMay.Width = 150;
            // 
            // repositoryItemLookUpEditMay
            // 
            this.repositoryItemLookUpEditMay.AutoHeight = false;
            this.repositoryItemLookUpEditMay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditMay.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("soMay", "Số Máy", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenMay", "Tên Máy")});
            this.repositoryItemLookUpEditMay.DisplayMember = "tenMay";
            this.repositoryItemLookUpEditMay.Name = "repositoryItemLookUpEditMay";
            this.repositoryItemLookUpEditMay.NullText = "";
            this.repositoryItemLookUpEditMay.ValueMember = "soMay";
            // 
            // coltgQuet
            // 
            this.coltgQuet.Caption = "Thời Gian MCC";
            this.coltgQuet.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.coltgQuet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coltgQuet.FieldName = "tgQuet";
            this.coltgQuet.Name = "coltgQuet";
            this.coltgQuet.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltgQuet.Visible = true;
            this.coltgQuet.VisibleIndex = 8;
            this.coltgQuet.Width = 192;
            // 
            // colDepName_Old
            // 
            this.colDepName_Old.Caption = "Phòng Ban Trước ĐC";
            this.colDepName_Old.FieldName = "DepName_Old";
            this.colDepName_Old.Name = "colDepName_Old";
            this.colDepName_Old.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName_Old.Width = 195;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 10, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = false;
            this.chonKyLuong1.Location = new System.Drawing.Point(2, 8);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(160, 100);
            this.chonKyLuong1.TabIndex = 6;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 10, 1, 0, 0, 0, 0);
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.Location = new System.Drawing.Point(434, 21);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(119, 34);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(167, 0);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(260, 150);
            this.ucChonDoiTuong_DS1.TabIndex = 9;
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.btnIn.Location = new System.Drawing.Point(434, 58);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(119, 34);
            this.btnIn.TabIndex = 12;
            this.btnIn.Text = "In theo lưới";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnXuatExel);
            this.panelControl2.Controls.Add(this.btnIn);
            this.panelControl2.Controls.Add(this.ucChonDoiTuong_DS1);
            this.panelControl2.Controls.Add(this.btnFind);
            this.panelControl2.Controls.Add(this.chonKyLuong1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1007, 172);
            this.panelControl2.TabIndex = 3;
            // 
            // btnXuatExel
            // 
            this.btnXuatExel.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExel.Appearance.Options.UseFont = true;
            this.btnXuatExel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.btnXuatExel.Location = new System.Drawing.Point(434, 95);
            this.btnXuatExel.Name = "btnXuatExel";
            this.btnXuatExel.Size = new System.Drawing.Size(119, 34);
            this.btnXuatExel.TabIndex = 13;
            this.btnXuatExel.Text = "Xuất Exel";
            this.btnXuatExel.Click += new System.EventHandler(this.btnXuatExel_Click);
            // 
            // BCCaoDuLieuNhanVienChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 517);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Name = "BCCaoDuLieuNhanVienChamCong";
            this.ShowIcon = false;
            this.Text = "BC Thời gian nhân viên chấm công";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCCaoDuLieuNhanVienChamCong_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colMaChamCong;
        private DevExpress.XtraGrid.Columns.GridColumn coltenchamcong;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colngayquet;
        private DevExpress.XtraGrid.Columns.GridColumn coltgQuet;
        private DevExpress.XtraGrid.Columns.GridColumn colsoMay;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditMay;
        private DevExpress.XtraGrid.Columns.GridColumn EmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName_Old;
        private DevExpress.XtraEditors.SimpleButton btnXuatExel;
    }
}