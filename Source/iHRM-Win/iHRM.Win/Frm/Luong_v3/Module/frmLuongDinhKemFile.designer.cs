namespace iHRM.Win.Frm.Luong_v3.Module
{
    partial class frmLuongDinhKemFile
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleDataBar formatConditionRuleDataBar1 = new DevExpress.XtraEditors.FormatConditionRuleDataBar();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grColDinhKem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resItemButtonFile = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colIdFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDuoiFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLuu = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblKyLuong = new DevExpress.XtraEditors.LabelControl();
            this.deKiLuong = new DevExpress.XtraEditors.DateEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSearch = new System.Windows.Forms.ToolStripButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemButtonFile)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deKiLuong.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deKiLuong.Properties)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(222, 29);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.resItemButtonFile});
            this.grd.Size = new System.Drawing.Size(1130, 471);
            this.grd.TabIndex = 5;
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
            this.grColDinhKem,
            this.colIdFile,
            this.colDataFile,
            this.colDuoiFile,
            this.colMaID,
            this.colTen,
            this.colNgay});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleDataBar1.AxisColor = System.Drawing.Color.Lime;
            formatConditionRuleDataBar1.PredefinedName = null;
            gridFormatRule1.Rule = formatConditionRuleDataBar1;
            this.grv.FormatRules.Add(gridFormatRule1);
            this.grv.GridControl = this.grd;
            this.grv.IndicatorWidth = 50;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grv.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.grv.OptionsSelection.MultiSelect = true;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grv_CustomDrawRowIndicator);
            this.grv.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grv_InitNewRow);
            this.grv.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grv_ValidateRow);
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // grColDinhKem
            // 
            this.grColDinhKem.Caption = "File đính kèm";
            this.grColDinhKem.ColumnEdit = this.resItemButtonFile;
            this.grColDinhKem.Name = "grColDinhKem";
            this.grColDinhKem.Visible = true;
            this.grColDinhKem.VisibleIndex = 3;
            this.grColDinhKem.Width = 108;
            // 
            // resItemButtonFile
            // 
            this.resItemButtonFile.AutoHeight = false;
            this.resItemButtonFile.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Xem", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleLeft, global::iHRM.Win.Properties.Resources.btnImport_Image, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "1", null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Chọn", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, global::iHRM.Win.Properties.Resources.ico20_edit, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", "2", null, true)});
            this.resItemButtonFile.Name = "resItemButtonFile";
            this.resItemButtonFile.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.resItemButtonFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.resItemButtonFile_ButtonClick);
            // 
            // colIdFile
            // 
            this.colIdFile.Caption = "ID file";
            this.colIdFile.FieldName = "idFile";
            this.colIdFile.Name = "colIdFile";
            this.colIdFile.OptionsColumn.AllowShowHide = false;
            // 
            // colDataFile
            // 
            this.colDataFile.Caption = "Data file";
            this.colDataFile.FieldName = "dataFile";
            this.colDataFile.Name = "colDataFile";
            // 
            // colDuoiFile
            // 
            this.colDuoiFile.Caption = "Đuôi file";
            this.colDuoiFile.FieldName = "duoiFile";
            this.colDuoiFile.Name = "colDuoiFile";
            this.colDuoiFile.OptionsColumn.AllowEdit = false;
            this.colDuoiFile.OptionsColumn.ReadOnly = true;
            this.colDuoiFile.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDuoiFile.Visible = true;
            this.colDuoiFile.VisibleIndex = 2;
            this.colDuoiFile.Width = 96;
            // 
            // colMaID
            // 
            this.colMaID.Caption = "Mã file";
            this.colMaID.FieldName = "idFile";
            this.colMaID.Name = "colMaID";
            // 
            // colTen
            // 
            this.colTen.Caption = "Tên";
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 0;
            this.colTen.Width = 319;
            // 
            // colNgay
            // 
            this.colNgay.Caption = "Kì lương";
            this.colNgay.DisplayFormat.FormatString = "MM/yyyy";
            this.colNgay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgay.FieldName = "Date";
            this.colNgay.Name = "colNgay";
            this.colNgay.OptionsColumn.AllowEdit = false;
            this.colNgay.OptionsColumn.ReadOnly = true;
            this.colNgay.Visible = true;
            this.colNgay.VisibleIndex = 1;
            this.colNgay.Width = 123;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripDelete,
            this.toolStripLuu,
            this.btnEdit});
            this.toolStrip1.Location = new System.Drawing.Point(222, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1130, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(61, 24);
            this.toolStripButton2.Text = "Excel";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDelete.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDelete.Image = global::iHRM.Win.Properties.Resources.btnDelete_Image;
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(74, 24);
            this.toolStripDelete.Text = "Xóa bỏ";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // toolStripLuu
            // 
            this.toolStripLuu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLuu.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLuu.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.toolStripLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLuu.Name = "toolStripLuu";
            this.toolStripLuu.Size = new System.Drawing.Size(73, 24);
            this.toolStripLuu.Text = "Lưu lại";
            this.toolStripLuu.Click += new System.EventHandler(this.toolStripLuu_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.btnEdit.Image = global::iHRM.Win.Properties.Resources.btnEdit_Image;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 24);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lblKyLuong);
            this.panelControl1.Controls.Add(this.deKiLuong);
            this.panelControl1.Controls.Add(this.toolStrip2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(220, 498);
            this.panelControl1.TabIndex = 7;
            // 
            // lblKyLuong
            // 
            this.lblKyLuong.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.lblKyLuong.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblKyLuong.Location = new System.Drawing.Point(14, 42);
            this.lblKyLuong.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblKyLuong.Name = "lblKyLuong";
            this.lblKyLuong.Size = new System.Drawing.Size(77, 20);
            this.lblKyLuong.TabIndex = 13;
            this.lblKyLuong.Text = "Kỳ lương :";
            // 
            // deKiLuong
            // 
            this.deKiLuong.EditValue = new System.DateTime(2017, 10, 13, 9, 40, 57, 312);
            this.deKiLuong.Location = new System.Drawing.Point(14, 66);
            this.deKiLuong.Name = "deKiLuong";
            this.deKiLuong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deKiLuong.Properties.Appearance.Options.UseFont = true;
            this.deKiLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deKiLuong.Properties.CalendarTimeProperties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deKiLuong.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deKiLuong.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "MM/yyyy";
            this.deKiLuong.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deKiLuong.Properties.CalendarTimeProperties.EditFormat.FormatString = "MM/yyyy";
            this.deKiLuong.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deKiLuong.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.deKiLuong.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deKiLuong.Properties.Mask.EditMask = "MM/yyyy";
            this.deKiLuong.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.deKiLuong.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.deKiLuong.Size = new System.Drawing.Size(199, 24);
            this.deKiLuong.TabIndex = 11;
            this.deKiLuong.EditValueChanged += new System.EventHandler(this.deKiLuong_EditValueChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSearch});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(220, 27);
            this.toolStrip2.TabIndex = 10;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::iHRM.Win.Properties.Resources.btnRefresh_Image;
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(82, 24);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSearch
            // 
            this.toolStripSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripSearch.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.toolStripSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSearch.Name = "toolStripSearch";
            this.toolStripSearch.Size = new System.Drawing.Size(89, 24);
            this.toolStripSearch.Text = "Tìm kiếm";
            this.toolStripSearch.Click += new System.EventHandler(this.toolStripSearch_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grd);
            this.panelControl2.Controls.Add(this.toolStrip1);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1354, 502);
            this.panelControl2.TabIndex = 7;
            // 
            // frmLuongDinhKemFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 502);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Name = "frmLuongDinhKemFile";
            this.ShowIcon = false;
            this.Text = "Lương _ Đính Kèm File";
            this.Load += new System.EventHandler(this.frmLuongDinhKemFile_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLuongDinhKemFile_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resItemButtonFile)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deKiLuong.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deKiLuong.Properties)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn grColDinhKem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit resItemButtonFile;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripLuu;
        private DevExpress.XtraGrid.Columns.GridColumn colIdFile;
        private DevExpress.XtraGrid.Columns.GridColumn colDataFile;
        private DevExpress.XtraGrid.Columns.GridColumn colDuoiFile;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripSearch;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private DevExpress.XtraEditors.DateEdit deKiLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colMaID;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colNgay;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private DevExpress.XtraEditors.LabelControl lblKyLuong;
    }
}