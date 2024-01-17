namespace iHRM.Win.Frm.Luong
{
    partial class frmCachTinhThueTNCN
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcSoNgPT = new DevExpress.XtraGrid.GridControl();
            this.grvSoNgPT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNgayDK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtMoney = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colMaNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoNguoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.cmbLoaiNV = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.lookupLoaiNV = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolstripSave = new System.Windows.Forms.ToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSoNgPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSoNgPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLoaiNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grcSoNgPT;
            this.gridView1.Name = "gridView1";
            // 
            // grcSoNgPT
            // 
            this.grcSoNgPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcSoNgPT.Location = new System.Drawing.Point(0, 0);
            this.grcSoNgPT.MainView = this.grvSoNgPT;
            this.grcSoNgPT.Name = "grcSoNgPT";
            this.grcSoNgPT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbLoaiNV,
            this.lookupLoaiNV,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemCheckEdit1,
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemTxtMoney});
            this.grcSoNgPT.Size = new System.Drawing.Size(1019, 538);
            this.grcSoNgPT.TabIndex = 1;
            this.grcSoNgPT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSoNgPT,
            this.gridView2,
            this.gridView1});
            // 
            // grvSoNgPT
            // 
            this.grvSoNgPT.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvSoNgPT.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSoNgPT.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvSoNgPT.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvSoNgPT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNgayDK,
            this.colMaNV,
            this.colTenNV,
            this.colSoNguoi,
            this.colXoa});
            this.grvSoNgPT.GridControl = this.grcSoNgPT;
            this.grvSoNgPT.Name = "grvSoNgPT";
            this.grvSoNgPT.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.grvSoNgPT.OptionsSelection.MultiSelect = true;
            this.grvSoNgPT.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvSoNgPT.OptionsView.ShowGroupPanel = false;
            this.grvSoNgPT.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvDK7h_RowCellClick);
            this.grvSoNgPT.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvDK7h_InitNewRow);
            this.grvSoNgPT.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvDK7h_CellValueChanged);
            // 
            // colNgayDK
            // 
            this.colNgayDK.Caption = "Số tiền bắt đầu";
            this.colNgayDK.ColumnEdit = this.repositoryItemTxtMoney;
            this.colNgayDK.FieldName = "SoTienBatDau";
            this.colNgayDK.Name = "colNgayDK";
            this.colNgayDK.Visible = true;
            this.colNgayDK.VisibleIndex = 0;
            this.colNgayDK.Width = 99;
            // 
            // repositoryItemTxtMoney
            // 
            this.repositoryItemTxtMoney.AutoHeight = false;
            this.repositoryItemTxtMoney.DisplayFormat.FormatString = "n0";
            this.repositoryItemTxtMoney.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTxtMoney.EditFormat.FormatString = "n0";
            this.repositoryItemTxtMoney.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTxtMoney.Mask.EditMask = "n0";
            this.repositoryItemTxtMoney.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtMoney.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtMoney.Name = "repositoryItemTxtMoney";
            // 
            // colMaNV
            // 
            this.colMaNV.Caption = "Số tiền đến";
            this.colMaNV.ColumnEdit = this.repositoryItemTxtMoney;
            this.colMaNV.FieldName = "SoTienDen";
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.Visible = true;
            this.colMaNV.VisibleIndex = 1;
            this.colMaNV.Width = 93;
            // 
            // colTenNV
            // 
            this.colTenNV.Caption = "Thuế suất";
            this.colTenNV.DisplayFormat.FormatString = "{0}%";
            this.colTenNV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTenNV.FieldName = "ThueSuat";
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.Visible = true;
            this.colTenNV.VisibleIndex = 2;
            this.colTenNV.Width = 151;
            // 
            // colSoNguoi
            // 
            this.colSoNguoi.Caption = "Khoản bù trừ";
            this.colSoNguoi.ColumnEdit = this.repositoryItemTxtMoney;
            this.colSoNguoi.DisplayFormat.FormatString = "#,0";
            this.colSoNguoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoNguoi.FieldName = "SoTienBuTru";
            this.colSoNguoi.Name = "colSoNguoi";
            this.colSoNguoi.Visible = true;
            this.colSoNguoi.VisibleIndex = 3;
            this.colSoNguoi.Width = 125;
            // 
            // colXoa
            // 
            this.colXoa.Caption = "Action";
            this.colXoa.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.colXoa.Name = "colXoa";
            this.colXoa.Visible = true;
            this.colXoa.VisibleIndex = 4;
            this.colXoa.Width = 79;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Xóa";
            // 
            // cmbLoaiNV
            // 
            this.cmbLoaiNV.AutoHeight = false;
            this.cmbLoaiNV.Name = "cmbLoaiNV";
            // 
            // lookupLoaiNV
            // 
            this.lookupLoaiNV.AutoHeight = false;
            this.lookupLoaiNV.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupLoaiNV.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpTypeName", "Loại nhân viên")});
            this.lookupLoaiNV.DisplayMember = "EmpTypeName";
            this.lookupLoaiNV.Name = "lookupLoaiNV";
            this.lookupLoaiNV.NullText = "";
            this.lookupLoaiNV.ValueMember = "EmpTypeID";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "[123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.repositoryItemDateEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grcSoNgPT;
            this.gridView2.Name = "gridView2";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolstripSave});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1023, 28);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStripButton2.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(64, 25);
            this.toolStripButton2.Text = "Excel";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(83, 25);
            this.toolStripButton1.Text = "Tìm kiếm";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolstripSave
            // 
            this.toolstripSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.toolstripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripSave.Name = "toolstripSave";
            this.toolstripSave.Size = new System.Drawing.Size(71, 25);
            this.toolstripSave.Text = "Lưu lại";
            this.toolstripSave.Click += new System.EventHandler(this.toolstripSave_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 28);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1023, 542);
            this.panelControl1.TabIndex = 4;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.grcSoNgPT);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1019, 538);
            this.panelControl3.TabIndex = 5;
            // 
            // frmCachTinhThueTNCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 570);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "frmCachTinhThueTNCN";
            this.Text = "Cách tính thuế thu nhập cá nhân";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDangKyCaLam_FormClosed);
            this.Load += new System.EventHandler(this.frmDangKyCaLam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSoNgPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSoNgPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoaiNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLoaiNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl grcSoNgPT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSoNgPT;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayDK;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNV;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNV;
        private DevExpress.XtraGrid.Columns.GridColumn colSoNguoi;
        private DevExpress.XtraGrid.Columns.GridColumn colXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbLoaiNV;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupLoaiNV;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolstripSave;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtMoney;
    }
}