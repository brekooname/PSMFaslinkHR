namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    partial class CaLam
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
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCaLam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTuGio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTieng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTiengTinhCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTCTrachNhiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTiengTinhTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName_Final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Dept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.buttonPanel1 = new iHRM.Win.UC.ButtonPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Dept)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 42);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_Dept});
            this.grd.Size = new System.Drawing.Size(895, 314);
            this.grd.TabIndex = 1;
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
            this.colCaLam,
            this.colTuGio,
            this.colSoTieng,
            this.colSoTiengTinhCa,
            this.colTCTrachNhiem,
            this.colSoTiengTinhTC,
            this.colAlias,
            this.colDepName_Final});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grv_FocusedRowChanged);
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            this.grv.DoubleClick += new System.EventHandler(this.buttonPanel1_OnEdit);
            // 
            // colCaLam
            // 
            this.colCaLam.Caption = "Ca làm";
            this.colCaLam.FieldName = "ten";
            this.colCaLam.Name = "colCaLam";
            this.colCaLam.Visible = true;
            this.colCaLam.VisibleIndex = 0;
            this.colCaLam.Width = 193;
            // 
            // colTuGio
            // 
            this.colTuGio.Caption = "Từ giờ";
            this.colTuGio.DisplayFormat.FormatString = "{0:HH:mm}";
            this.colTuGio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTuGio.FieldName = "tuGio";
            this.colTuGio.Name = "colTuGio";
            this.colTuGio.Visible = true;
            this.colTuGio.VisibleIndex = 2;
            this.colTuGio.Width = 52;
            // 
            // colSoTieng
            // 
            this.colSoTieng.Caption = "Số tiếng";
            this.colSoTieng.DisplayFormat.FormatString = "HH:mm";
            this.colSoTieng.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSoTieng.FieldName = "denGio";
            this.colSoTieng.Name = "colSoTieng";
            this.colSoTieng.Visible = true;
            this.colSoTieng.VisibleIndex = 3;
            this.colSoTieng.Width = 68;
            // 
            // colSoTiengTinhCa
            // 
            this.colSoTiengTinhCa.Caption = "Số tiếng tính ca";
            this.colSoTiengTinhCa.DisplayFormat.FormatString = "#,0";
            this.colSoTiengTinhCa.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoTiengTinhCa.FieldName = "soTiengTinhCa";
            this.colSoTiengTinhCa.Name = "colSoTiengTinhCa";
            this.colSoTiengTinhCa.Visible = true;
            this.colSoTiengTinhCa.VisibleIndex = 4;
            this.colSoTiengTinhCa.Width = 100;
            // 
            // colTCTrachNhiem
            // 
            this.colTCTrachNhiem.Caption = "TC trách nhiệm";
            this.colTCTrachNhiem.DisplayFormat.FormatString = "#,0";
            this.colTCTrachNhiem.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTCTrachNhiem.FieldName = "soTiengTangCaTrachNhiem";
            this.colTCTrachNhiem.Name = "colTCTrachNhiem";
            this.colTCTrachNhiem.Visible = true;
            this.colTCTrachNhiem.VisibleIndex = 5;
            this.colTCTrachNhiem.Width = 105;
            // 
            // colSoTiengTinhTC
            // 
            this.colSoTiengTinhTC.Caption = "Số tiếng tính tăng ca";
            this.colSoTiengTinhTC.DisplayFormat.FormatString = "{#.#},0";
            this.colSoTiengTinhTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoTiengTinhTC.FieldName = "soTiengTinhTangCa";
            this.colSoTiengTinhTC.Name = "colSoTiengTinhTC";
            this.colSoTiengTinhTC.Visible = true;
            this.colSoTiengTinhTC.VisibleIndex = 6;
            this.colSoTiengTinhTC.Width = 115;
            // 
            // colAlias
            // 
            this.colAlias.Caption = "Alias";
            this.colAlias.FieldName = "Alias";
            this.colAlias.Name = "colAlias";
            this.colAlias.Visible = true;
            this.colAlias.VisibleIndex = 7;
            this.colAlias.Width = 67;
            // 
            // colDepName_Final
            // 
            this.colDepName_Final.Caption = "Phòng ban";
            this.colDepName_Final.ColumnEdit = this.rep_Dept;
            this.colDepName_Final.FieldName = "idKhoiPB";
            this.colDepName_Final.Name = "colDepName_Final";
            this.colDepName_Final.Visible = true;
            this.colDepName_Final.VisibleIndex = 1;
            this.colDepName_Final.Width = 141;
            // 
            // rep_Dept
            // 
            this.rep_Dept.AutoHeight = false;
            this.rep_Dept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_Dept.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepID", "Mã Phòng Ban", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepName", "Phòng ban")});
            this.rep_Dept.DisplayMember = "DepName";
            this.rep_Dept.Name = "rep_Dept";
            this.rep_Dept.NullText = "";
            this.rep_Dept.ValueMember = "DepID";
            // 
            // buttonPanel1
            // 
            this.buttonPanel1.BackColor = System.Drawing.Color.Transparent;
            this.buttonPanel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.buttonPanel1.enableButtonChoose = true;
            this.buttonPanel1.enableButtonDelete = true;
            this.buttonPanel1.enableButtonEdit = true;
            this.buttonPanel1.enableButtonExit = true;
            this.buttonPanel1.enableButtonExport = true;
            this.buttonPanel1.enableButtonFind = true;
            this.buttonPanel1.enableButtonImport = true;
            this.buttonPanel1.enableButtonNew = true;
            this.buttonPanel1.enableButtonPrint = true;
            this.buttonPanel1.enableButtonSave = true;
            this.buttonPanel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPanel1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.buttonPanel1.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel1.Name = "buttonPanel1";
            this.buttonPanel1.showButtonChoose = false;
            this.buttonPanel1.showButtonDelete = true;
            this.buttonPanel1.showButtonEdit = true;
            this.buttonPanel1.showButtonExit = true;
            this.buttonPanel1.showButtonExport = false;
            this.buttonPanel1.showButtonFind = true;
            this.buttonPanel1.showButtonImport = false;
            this.buttonPanel1.showButtonNew = true;
            this.buttonPanel1.showButtonPrint = false;
            this.buttonPanel1.showButtonSave = false;
            this.buttonPanel1.ShowStyle = iHRM.Win.UC.ButtonPanel.eShowStyle.Custom;
            this.buttonPanel1.Size = new System.Drawing.Size(895, 42);
            this.buttonPanel1.TabIndex = 0;
            this.buttonPanel1.Text = "buttonPanel1";
            this.buttonPanel1.TextAndImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPanel1.useButtonChoose = false;
            this.buttonPanel1.useButtonDelete = true;
            this.buttonPanel1.useButtonEdit = true;
            this.buttonPanel1.useButtonExit = true;
            this.buttonPanel1.useButtonExport = false;
            this.buttonPanel1.useButtonFind = true;
            this.buttonPanel1.useButtonImport = false;
            this.buttonPanel1.useButtonNew = true;
            this.buttonPanel1.useButtonPrint = false;
            this.buttonPanel1.useButtonSave = false;
            this.buttonPanel1.OnFind += new System.EventHandler(this.buttonPanel1_OnFind);
            this.buttonPanel1.OnNew += new System.EventHandler(this.buttonPanel1_OnNew);
            this.buttonPanel1.OnEdit += new System.EventHandler(this.buttonPanel1_OnEdit);
            this.buttonPanel1.OnDelete += new System.EventHandler(this.buttonPanel1_OnDelete);
            // 
            // CaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 356);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.buttonPanel1);
            this.KeyPreview = true;
            this.Name = "CaLam";
            this.Text = "Cấu hình ca làm việc";
            this.Load += new System.EventHandler(this.CaLam_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CaLam_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Dept)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC.ButtonPanel buttonPanel1;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colCaLam;
        private DevExpress.XtraGrid.Columns.GridColumn colTuGio;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTieng;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTiengTinhCa;
        private DevExpress.XtraGrid.Columns.GridColumn colTCTrachNhiem;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTiengTinhTC;
        private DevExpress.XtraGrid.Columns.GridColumn colAlias;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName_Final;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep_Dept;
    }
}