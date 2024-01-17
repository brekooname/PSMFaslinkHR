namespace iHRM.Win.Frm.Report
{
    partial class BCNhatKyNguoiDung
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
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNguoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServerTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarget1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName_Final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDomainName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPAdress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditMay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.btnInTheoLuoi = new DevExpress.XtraEditors.SimpleButton();
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
            this.panelControl1.Location = new System.Drawing.Point(0, 140);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1175, 496);
            this.panelControl1.TabIndex = 7;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Location = new System.Drawing.Point(2, 2);
            this.grd.MainView = this.grv;
            this.grd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditMay});
            this.grd.Size = new System.Drawing.Size(1171, 492);
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
            this.colID,
            this.colUserID,
            this.colTenNguoiDung,
            this.colLogTime,
            this.colServerTime,
            this.colAction,
            this.colTarget1,
            this.colEmployeeName,
            this.colPosName,
            this.colDepName_Final,
            this.colActionText,
            this.colMachineName,
            this.colDomainName,
            this.colIPAdress,
            this.colVersion});
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
            // colID
            // 
            this.colID.Caption = "id";
            this.colID.FieldName = "id";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 64;
            // 
            // colUserID
            // 
            this.colUserID.Caption = "Mã người dùng";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.OptionsColumn.ReadOnly = true;
            this.colUserID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 1;
            this.colUserID.Width = 111;
            // 
            // colTenNguoiDung
            // 
            this.colTenNguoiDung.Caption = "Tên người dùng";
            this.colTenNguoiDung.FieldName = "caption";
            this.colTenNguoiDung.Name = "colTenNguoiDung";
            this.colTenNguoiDung.OptionsColumn.ReadOnly = true;
            this.colTenNguoiDung.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenNguoiDung.Visible = true;
            this.colTenNguoiDung.VisibleIndex = 2;
            this.colTenNguoiDung.Width = 205;
            // 
            // colLogTime
            // 
            this.colLogTime.Caption = "Giờ máy trạm";
            this.colLogTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colLogTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLogTime.FieldName = "LogTime";
            this.colLogTime.Name = "colLogTime";
            this.colLogTime.OptionsColumn.ReadOnly = true;
            this.colLogTime.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLogTime.Visible = true;
            this.colLogTime.VisibleIndex = 3;
            this.colLogTime.Width = 131;
            // 
            // colServerTime
            // 
            this.colServerTime.Caption = "Giờ máy chủ";
            this.colServerTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colServerTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colServerTime.FieldName = "ServerTime";
            this.colServerTime.Name = "colServerTime";
            this.colServerTime.OptionsColumn.ReadOnly = true;
            this.colServerTime.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colServerTime.Visible = true;
            this.colServerTime.VisibleIndex = 4;
            this.colServerTime.Width = 159;
            // 
            // colAction
            // 
            this.colAction.Caption = "Hành động";
            this.colAction.FieldName = "Action";
            this.colAction.Name = "colAction";
            this.colAction.OptionsColumn.ReadOnly = true;
            this.colAction.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAction.Visible = true;
            this.colAction.VisibleIndex = 5;
            this.colAction.Width = 160;
            // 
            // colTarget1
            // 
            this.colTarget1.Caption = "Đối tượng";
            this.colTarget1.FieldName = "Target1";
            this.colTarget1.Name = "colTarget1";
            this.colTarget1.OptionsColumn.ReadOnly = true;
            this.colTarget1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTarget1.Visible = true;
            this.colTarget1.VisibleIndex = 6;
            this.colTarget1.Width = 160;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Tên nhân viên";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.ReadOnly = true;
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 7;
            this.colEmployeeName.Width = 221;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Chức vụ";
            this.colPosName.FieldName = "PosName";
            this.colPosName.Name = "colPosName";
            this.colPosName.OptionsColumn.ReadOnly = true;
            this.colPosName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPosName.Visible = true;
            this.colPosName.VisibleIndex = 8;
            this.colPosName.Width = 210;
            // 
            // colDepName_Final
            // 
            this.colDepName_Final.Caption = "Phòng ban";
            this.colDepName_Final.FieldName = "DepName_Final";
            this.colDepName_Final.Name = "colDepName_Final";
            this.colDepName_Final.OptionsColumn.ReadOnly = true;
            this.colDepName_Final.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName_Final.Visible = true;
            this.colDepName_Final.VisibleIndex = 9;
            this.colDepName_Final.Width = 202;
            // 
            // colActionText
            // 
            this.colActionText.Caption = "Nội dung";
            this.colActionText.FieldName = "ActionText";
            this.colActionText.Name = "colActionText";
            this.colActionText.OptionsColumn.ReadOnly = true;
            this.colActionText.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colActionText.Visible = true;
            this.colActionText.VisibleIndex = 10;
            this.colActionText.Width = 188;
            // 
            // colMachineName
            // 
            this.colMachineName.Caption = "Tên máy";
            this.colMachineName.FieldName = "MachineName";
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.OptionsColumn.ReadOnly = true;
            this.colMachineName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMachineName.Visible = true;
            this.colMachineName.VisibleIndex = 11;
            this.colMachineName.Width = 167;
            // 
            // colDomainName
            // 
            this.colDomainName.Caption = "Tên domain";
            this.colDomainName.FieldName = "DomainName";
            this.colDomainName.Name = "colDomainName";
            this.colDomainName.OptionsColumn.ReadOnly = true;
            this.colDomainName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDomainName.Visible = true;
            this.colDomainName.VisibleIndex = 12;
            this.colDomainName.Width = 172;
            // 
            // colIPAdress
            // 
            this.colIPAdress.Caption = "Địa chỉ IP";
            this.colIPAdress.FieldName = "IPAdress";
            this.colIPAdress.Name = "colIPAdress";
            this.colIPAdress.OptionsColumn.ReadOnly = true;
            this.colIPAdress.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIPAdress.Visible = true;
            this.colIPAdress.VisibleIndex = 13;
            this.colIPAdress.Width = 127;
            // 
            // colVersion
            // 
            this.colVersion.Caption = "iHRM version";
            this.colVersion.FieldName = "sHRM_version";
            this.colVersion.Name = "colVersion";
            this.colVersion.OptionsColumn.ReadOnly = true;
            this.colVersion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVersion.Visible = true;
            this.colVersion.VisibleIndex = 14;
            this.colVersion.Width = 129;
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
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 5, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = false;
            this.chonKyLuong1.Location = new System.Drawing.Point(2, 10);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(187, 123);
            this.chonKyLuong1.TabIndex = 6;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 5, 1, 0, 0, 0, 0);
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.Location = new System.Drawing.Point(197, 30);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(139, 38);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnInTheoLuoi
            // 
            this.btnInTheoLuoi.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInTheoLuoi.Appearance.Options.UseFont = true;
            this.btnInTheoLuoi.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.btnInTheoLuoi.Location = new System.Drawing.Point(196, 70);
            this.btnInTheoLuoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInTheoLuoi.Name = "btnInTheoLuoi";
            this.btnInTheoLuoi.Size = new System.Drawing.Size(139, 38);
            this.btnInTheoLuoi.TabIndex = 12;
            this.btnInTheoLuoi.Text = "In theo lưới";
            this.btnInTheoLuoi.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnXuatExel);
            this.panelControl2.Controls.Add(this.btnInTheoLuoi);
            this.panelControl2.Controls.Add(this.btnFind);
            this.panelControl2.Controls.Add(this.chonKyLuong1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1175, 140);
            this.panelControl2.TabIndex = 3;
            // 
            // btnXuatExel
            // 
            this.btnXuatExel.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExel.Appearance.Options.UseFont = true;
            this.btnXuatExel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.btnXuatExel.Location = new System.Drawing.Point(342, 70);
            this.btnXuatExel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXuatExel.Name = "btnXuatExel";
            this.btnXuatExel.Size = new System.Drawing.Size(139, 38);
            this.btnXuatExel.TabIndex = 13;
            this.btnXuatExel.Text = "Xuất Exel";
            this.btnXuatExel.Click += new System.EventHandler(this.btnXuatExel_Click);
            // 
            // BCNhatKyNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 636);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BCNhatKyNguoiDung";
            this.ShowIcon = false;
            this.Text = "BC Nhật ký người dùng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCNhatKyNguoiDung_KeyDown);
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
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditMay;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraEditors.SimpleButton btnInTheoLuoi;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNguoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colLogTime;
        private DevExpress.XtraGrid.Columns.GridColumn colServerTime;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraGrid.Columns.GridColumn colTarget1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colPosName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName_Final;
        private DevExpress.XtraGrid.Columns.GridColumn colActionText;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colDomainName;
        private DevExpress.XtraGrid.Columns.GridColumn colIPAdress;
        private DevExpress.XtraGrid.Columns.GridColumn colVersion;
        private DevExpress.XtraEditors.SimpleButton btnXuatExel;
    }
}