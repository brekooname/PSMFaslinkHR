namespace iHRM.Win.Frm.Report
{
    partial class BCNVQuetTheKhongDKCaLam
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
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName_Final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditMay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTGQuet = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeID,
            this.colEmployeeName,
            this.colPosName,
            this.colDepName_Final,
            this.colSoMay,
            this.colTGQuet});
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
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Mã NV";
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 0;
            this.colEmployeeID.Width = 95;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Nhân Viên";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEmployeeName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "EmployeeName", "Tổng = {0:#,#}")});
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 236;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Chức vụ";
            this.colPosName.FieldName = "PosName";
            this.colPosName.Name = "colPosName";
            this.colPosName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPosName.Visible = true;
            this.colPosName.VisibleIndex = 2;
            this.colPosName.Width = 239;
            // 
            // colDepName_Final
            // 
            this.colDepName_Final.Caption = "Phòng Ban";
            this.colDepName_Final.FieldName = "DepName_Final";
            this.colDepName_Final.Name = "colDepName_Final";
            this.colDepName_Final.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName_Final.Visible = true;
            this.colDepName_Final.VisibleIndex = 3;
            this.colDepName_Final.Width = 278;
            // 
            // colSoMay
            // 
            this.colSoMay.Caption = "Máy Chấm Công";
            this.colSoMay.ColumnEdit = this.repositoryItemLookUpEditMay;
            this.colSoMay.FieldName = "soMay";
            this.colSoMay.Name = "colSoMay";
            this.colSoMay.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoMay.Visible = true;
            this.colSoMay.VisibleIndex = 4;
            this.colSoMay.Width = 193;
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
            // colTGQuet
            // 
            this.colTGQuet.Caption = "Thời Gian Chấm Công";
            this.colTGQuet.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colTGQuet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTGQuet.FieldName = "tgQuet";
            this.colTGQuet.Name = "colTGQuet";
            this.colTGQuet.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTGQuet.Visible = true;
            this.colTGQuet.VisibleIndex = 5;
            this.colTGQuet.Width = 192;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 10, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(2, 8);
            this.chonKyLuong1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnFind.Location = new System.Drawing.Point(464, 21);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(117, 35);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(169, 3);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(289, 150);
            this.ucChonDoiTuong_DS1.TabIndex = 9;
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.btnIn.Location = new System.Drawing.Point(464, 59);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(117, 35);
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
            this.btnXuatExel.Location = new System.Drawing.Point(464, 97);
            this.btnXuatExel.Name = "btnXuatExel";
            this.btnXuatExel.Size = new System.Drawing.Size(117, 35);
            this.btnXuatExel.TabIndex = 13;
            this.btnXuatExel.Text = "Xuất Exel";
            this.btnXuatExel.Click += new System.EventHandler(this.btnXuatExel_Click);
            // 
            // BCNVQuetTheKhongDKCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 517);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Name = "BCNVQuetTheKhongDKCaLam";
            this.ShowIcon = false;
            this.Text = "BC NV quét vân tay không ĐK ca làm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCNVQuetTheKhongDKCaLam_KeyDown);
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
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colTGQuet;
        private DevExpress.XtraGrid.Columns.GridColumn colSoMay;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditMay;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colPosName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName_Final;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnXuatExel;
    }
}