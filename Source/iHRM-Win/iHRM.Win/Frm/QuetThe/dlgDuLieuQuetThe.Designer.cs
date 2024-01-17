namespace iHRM.Win.Frm.QuetThe
{
    partial class dlgDuLieuQuetThe
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
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemQLDuyet = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repItemTrinhDo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repItemLink1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repItemVTriTD = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repItemidDotTD = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemQLDuyet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemTrinhDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemLink1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemVTriTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemidDotTD)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.MainView = this.grv;
            this.grd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemQLDuyet,
            this.repItemTrinhDo,
            this.repItemLink1,
            this.repItemVTriTD,
            this.repItemidDotTD});
            this.grd.Size = new System.Drawing.Size(581, 343);
            this.grd.TabIndex = 11;
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
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã nhân viên";
            this.gridColumn1.FieldName = "maNV";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 122;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Họ tên";
            this.gridColumn2.FieldName = "EmployeeName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 184;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Thời gian";
            this.gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "thoigian";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 172;
            // 
            // repItemQLDuyet
            // 
            this.repItemQLDuyet.AutoHeight = false;
            this.repItemQLDuyet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemQLDuyet.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("caption", "Tên")});
            this.repItemQLDuyet.DisplayMember = "caption";
            this.repItemQLDuyet.Name = "repItemQLDuyet";
            this.repItemQLDuyet.NullText = "";
            this.repItemQLDuyet.ValueMember = "id";
            // 
            // repItemTrinhDo
            // 
            this.repItemTrinhDo.AutoHeight = false;
            this.repItemTrinhDo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemTrinhDo.DisplayMember = "EducationType";
            this.repItemTrinhDo.Name = "repItemTrinhDo";
            this.repItemTrinhDo.NullText = "";
            this.repItemTrinhDo.ValueMember = "EducationID";
            // 
            // repItemLink1
            // 
            this.repItemLink1.AutoHeight = false;
            this.repItemLink1.Name = "repItemLink1";
            this.repItemLink1.NullText = "Xem File";
            // 
            // repItemVTriTD
            // 
            this.repItemVTriTD.AutoHeight = false;
            this.repItemVTriTD.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemVTriTD.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmpTypeName", "Chức vụ")});
            this.repItemVTriTD.DisplayMember = "PosName";
            this.repItemVTriTD.Name = "repItemVTriTD";
            this.repItemVTriTD.NullText = "";
            this.repItemVTriTD.ValueMember = "PosID";
            // 
            // repItemidDotTD
            // 
            this.repItemidDotTD.AutoHeight = false;
            this.repItemidDotTD.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemidDotTD.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenDotTD", "Tên đợt")});
            this.repItemidDotTD.DisplayMember = "tenDotTD";
            this.repItemidDotTD.Name = "repItemidDotTD";
            this.repItemidDotTD.NullText = "";
            this.repItemidDotTD.ValueMember = "id";
            // 
            // dlgDuLieuQuetThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 343);
            this.Controls.Add(this.grd);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "dlgDuLieuQuetThe";
            this.ShowIcon = false;
            this.Text = "Dữ liệu quẹt thẻ của nhân viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDuLieuQuetThe_FormClosing);
            this.Load += new System.EventHandler(this.dlgDuLieuQuetThe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemQLDuyet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemTrinhDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemLink1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemVTriTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemidDotTD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemQLDuyet;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemTrinhDo;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repItemLink1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemVTriTD;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemidDotTD;


    }
}