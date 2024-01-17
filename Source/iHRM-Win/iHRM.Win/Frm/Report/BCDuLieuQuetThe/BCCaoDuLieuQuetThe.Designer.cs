namespace iHRM.Win.Frm.Report
{
    partial class BCCaoDuLieuQuetThe
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
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
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
            this.coltgMayClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltgMayServer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngaygioQuet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName_Old = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.chkNoNv = new System.Windows.Forms.CheckBox();
            this.chkNVFail = new System.Windows.Forms.CheckBox();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditMay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 10, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = false;
            this.chonKyLuong1.Location = new System.Drawing.Point(2, 8);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(160, 100);
            this.chonKyLuong1.TabIndex = 6;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 10, 1, 0, 0, 0, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 157);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1007, 360);
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
            this.grd.Size = new System.Drawing.Size(1003, 356);
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
            this.coltgMayClient,
            this.coltgMayServer,
            this.colstype,
            this.colngaygioQuet,
            this.colDepName_Old,
            this.gridColumn1});
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
            this.grv.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grv_RowStyle);
            // 
            // colSTT
            // 
            this.colSTT.Caption = "Index";
            this.colSTT.FieldName = "idx";
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            // 
            // colMaChamCong
            // 
            this.colMaChamCong.Caption = "Mã Chấm Công";
            this.colMaChamCong.FieldName = "maChamCong";
            this.colMaChamCong.Name = "colMaChamCong";
            this.colMaChamCong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaChamCong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "maChamCong", "Tổng = {0:#,#}")});
            this.colMaChamCong.Visible = true;
            this.colMaChamCong.VisibleIndex = 1;
            this.colMaChamCong.Width = 114;
            // 
            // coltenchamcong
            // 
            this.coltenchamcong.Caption = "Tên Chấm Công";
            this.coltenchamcong.FieldName = "tenChamCong";
            this.coltenchamcong.Name = "coltenchamcong";
            this.coltenchamcong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltenchamcong.Visible = true;
            this.coltenchamcong.VisibleIndex = 2;
            this.coltenchamcong.Width = 161;
            // 
            // EmployeeID
            // 
            this.EmployeeID.Caption = "Mã Nhân Viên";
            this.EmployeeID.FieldName = "EmployeeID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.EmployeeID.Visible = true;
            this.EmployeeID.VisibleIndex = 3;
            this.EmployeeID.Width = 105;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Nhân Viên";
            this.colEmployeeID.FieldName = "EmployeeName";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 4;
            this.colEmployeeID.Width = 171;
            // 
            // colEmpTypeName
            // 
            this.colEmpTypeName.Caption = "Loại Nhân Viên";
            this.colEmpTypeName.FieldName = "EmpTypeName";
            this.colEmpTypeName.Name = "colEmpTypeName";
            this.colEmpTypeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmpTypeName.Visible = true;
            this.colEmpTypeName.VisibleIndex = 5;
            this.colEmpTypeName.Width = 142;
            // 
            // colDepName
            // 
            this.colDepName.Caption = "Phòng Ban hiện tại";
            this.colDepName.FieldName = "DepName";
            this.colDepName.Name = "colDepName";
            this.colDepName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName.Visible = true;
            this.colDepName.VisibleIndex = 6;
            this.colDepName.Width = 171;
            // 
            // colngayquet
            // 
            this.colngayquet.Caption = "Ngày Quẹt MCC";
            this.colngayquet.FieldName = "ngayQuet";
            this.colngayquet.Name = "colngayquet";
            this.colngayquet.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colngayquet.Visible = true;
            this.colngayquet.VisibleIndex = 9;
            this.colngayquet.Width = 130;
            // 
            // colsoMay
            // 
            this.colsoMay.Caption = "Máy Chấm Công";
            this.colsoMay.ColumnEdit = this.repositoryItemLookUpEditMay;
            this.colsoMay.FieldName = "soMay";
            this.colsoMay.Name = "colsoMay";
            this.colsoMay.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colsoMay.Visible = true;
            this.colsoMay.VisibleIndex = 11;
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
            this.coltgQuet.VisibleIndex = 12;
            this.coltgQuet.Width = 149;
            // 
            // coltgMayClient
            // 
            this.coltgMayClient.Caption = "Thời Gian Máy Trạm";
            this.coltgMayClient.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.coltgMayClient.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coltgMayClient.FieldName = "tgMayClient";
            this.coltgMayClient.Name = "coltgMayClient";
            this.coltgMayClient.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltgMayClient.Visible = true;
            this.coltgMayClient.VisibleIndex = 13;
            this.coltgMayClient.Width = 127;
            // 
            // coltgMayServer
            // 
            this.coltgMayServer.Caption = "Thời Gian Máy Chủ";
            this.coltgMayServer.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.coltgMayServer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coltgMayServer.FieldName = "tgMayServer";
            this.coltgMayServer.Name = "coltgMayServer";
            this.coltgMayServer.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.coltgMayServer.Visible = true;
            this.coltgMayServer.VisibleIndex = 14;
            this.coltgMayServer.Width = 121;
            // 
            // colstype
            // 
            this.colstype.Caption = "Loại CC";
            this.colstype.FieldName = "stype";
            this.colstype.Name = "colstype";
            this.colstype.Visible = true;
            this.colstype.VisibleIndex = 8;
            // 
            // colngaygioQuet
            // 
            this.colngaygioQuet.Caption = "Ngày Giờ Quẹt MCC";
            this.colngaygioQuet.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.colngaygioQuet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colngaygioQuet.FieldName = "ngaygioQuet";
            this.colngaygioQuet.Name = "colngaygioQuet";
            this.colngaygioQuet.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colngaygioQuet.Visible = true;
            this.colngaygioQuet.VisibleIndex = 10;
            this.colngaygioQuet.Width = 167;
            // 
            // colDepName_Old
            // 
            this.colDepName_Old.Caption = "Phòng ban trước ĐC";
            this.colDepName_Old.FieldName = "DepName_Old";
            this.colDepName_Old.Name = "colDepName_Old";
            this.colDepName_Old.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName_Old.Visible = true;
            this.colDepName_Old.VisibleIndex = 7;
            this.colDepName_Old.Width = 157;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tự tải về";
            this.gridColumn1.FieldName = "isAuto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 15;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnIn);
            this.panelControl2.Controls.Add(this.chkNoNv);
            this.panelControl2.Controls.Add(this.chkNVFail);
            this.panelControl2.Controls.Add(this.ucChonDoiTuong_DS1);
            this.panelControl2.Controls.Add(this.btnExcel);
            this.panelControl2.Controls.Add(this.btnFind);
            this.panelControl2.Controls.Add(this.chonKyLuong1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1007, 157);
            this.panelControl2.TabIndex = 3;
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.btnIn.Location = new System.Drawing.Point(465, 89);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(119, 34);
            this.btnIn.TabIndex = 12;
            this.btnIn.Text = "In theo lưới";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // chkNoNv
            // 
            this.chkNoNv.AutoSize = true;
            this.chkNoNv.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoNv.Location = new System.Drawing.Point(6, 133);
            this.chkNoNv.Name = "chkNoNv";
            this.chkNoNv.Size = new System.Drawing.Size(138, 21);
            this.chkNoNv.TabIndex = 11;
            this.chkNoNv.Text = "Chưa khai báo NV";
            this.chkNoNv.UseVisualStyleBackColor = true;
            // 
            // chkNVFail
            // 
            this.chkNVFail.AutoSize = true;
            this.chkNVFail.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNVFail.Location = new System.Drawing.Point(6, 110);
            this.chkNVFail.Name = "chkNVFail";
            this.chkNVFail.Size = new System.Drawing.Size(158, 21);
            this.chkNVFail.TabIndex = 10;
            this.chkNVFail.Text = "Nhân viên quẹt thẻ sai";
            this.chkNVFail.UseVisualStyleBackColor = true;
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(168, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(291, 150);
            this.ucChonDoiTuong_DS1.TabIndex = 9;
            // 
            // btnExcel
            // 
            this.btnExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Appearance.Options.UseFont = true;
            this.btnExcel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.btnExcel.Location = new System.Drawing.Point(465, 53);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(119, 34);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.Location = new System.Drawing.Point(465, 17);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(119, 34);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // BCCaoDuLieuQuetThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 517);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "BCCaoDuLieuQuetThe";
            this.Text = "BC Dữ liệu quẹt vân tay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditMay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colMaChamCong;
        private DevExpress.XtraGrid.Columns.GridColumn coltenchamcong;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colngayquet;
        private DevExpress.XtraGrid.Columns.GridColumn coltgQuet;
        private DevExpress.XtraGrid.Columns.GridColumn coltgMayClient;
        private DevExpress.XtraGrid.Columns.GridColumn coltgMayServer;
        private DevExpress.XtraGrid.Columns.GridColumn colsoMay;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditMay;
        private DevExpress.XtraGrid.Columns.GridColumn colstype;
        private DevExpress.XtraGrid.Columns.GridColumn EmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName;
        private DevExpress.XtraGrid.Columns.GridColumn colngaygioQuet;
        private System.Windows.Forms.CheckBox chkNVFail;
        private System.Windows.Forms.CheckBox chkNoNv;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName_Old;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}