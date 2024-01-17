namespace iHRM.Win.Frm.Report
{
    partial class BCTuyenDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCTuyenDung));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboNam = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboPhongBan = new iHRM.Win.UC.ChonPhongBan();
            this.lblNam = new DevExpress.XtraEditors.LabelControl();
            this.lblPB = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.label41 = new System.Windows.Forms.Label();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViTri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripExcel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNam.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.label41);
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1589, 534);
            this.splitContainerControl1.SplitterPosition = 237;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboNam);
            this.panel1.Controls.Add(this.cboPhongBan);
            this.panel1.Controls.Add(this.lblNam);
            this.panel1.Controls.Add(this.lblPB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 506);
            this.panel1.TabIndex = 6;
            // 
            // cboNam
            // 
            this.cboNam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNam.Location = new System.Drawing.Point(6, 137);
            this.cboNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboNam.Name = "cboNam";
            this.cboNam.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.Properties.Appearance.Options.UseFont = true;
            this.cboNam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cboNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNam.Size = new System.Drawing.Size(152, 30);
            this.cboNam.TabIndex = 10;
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPhongBan.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhongBan.Location = new System.Drawing.Point(6, 70);
            this.cboPhongBan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.SelectedValue = null;
            this.cboPhongBan.Size = new System.Drawing.Size(231, 34);
            this.cboPhongBan.TabIndex = 5;
            // 
            // lblNam
            // 
            this.lblNam.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNam.Location = new System.Drawing.Point(6, 112);
            this.lblNam.Margin = new System.Windows.Forms.Padding(7, 4, 3, 0);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(44, 22);
            this.lblNam.TabIndex = 3;
            this.lblNam.Text = "Năm:";
            // 
            // lblPB
            // 
            this.lblPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPB.Appearance.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPB.Location = new System.Drawing.Point(6, 46);
            this.lblPB.Margin = new System.Windows.Forms.Padding(7, 4, 3, 0);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(96, 22);
            this.lblPB.TabIndex = 3;
            this.lblPB.Text = "Phòng ban:";
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
            this.toolStrip1.Size = new System.Drawing.Size(237, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(102, 25);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(-261, 281);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(78, 21);
            this.label41.TabIndex = 60;
            this.label41.Text = "Chức vụ:";
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Location = new System.Drawing.Point(0, 28);
            this.grd.MainView = this.grv;
            this.grd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grd.Size = new System.Drawing.Size(1347, 506);
            this.grd.TabIndex = 3;
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
            this.colPhongBan,
            this.colViTri,
            this.colThang1,
            this.colThang2,
            this.colThang3,
            this.colThang4,
            this.colThang5,
            this.colThang6,
            this.colThang7,
            this.colThang8,
            this.colThang9,
            this.colThang10,
            this.colThang11,
            this.colThang12});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT1C", this.colThang1, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT2C", this.colThang2, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT3C", this.colThang3, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT4C", this.colThang4, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT5C", this.colThang5, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT6C", this.colThang6, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT7C", this.colThang7, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT8C", this.colThang8, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT9C", this.colThang9, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT10C", this.colThang10, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT11C", this.colThang11, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLT12C", this.colThang12, "")});
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsSelection.MultiSelect = true;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // colPhongBan
            // 
            this.colPhongBan.Caption = "Phòng Ban";
            this.colPhongBan.FieldName = "DepName";
            this.colPhongBan.Name = "colPhongBan";
            this.colPhongBan.Visible = true;
            this.colPhongBan.VisibleIndex = 0;
            this.colPhongBan.Width = 240;
            // 
            // colViTri
            // 
            this.colViTri.Caption = "Vị trí";
            this.colViTri.FieldName = "PosName";
            this.colViTri.Name = "colViTri";
            this.colViTri.Visible = true;
            this.colViTri.VisibleIndex = 1;
            this.colViTri.Width = 235;
            // 
            // colThang1
            // 
            this.colThang1.Caption = "T1";
            this.colThang1.FieldName = "SLT1C";
            this.colThang1.Name = "colThang1";
            this.colThang1.Visible = true;
            this.colThang1.VisibleIndex = 2;
            this.colThang1.Width = 30;
            // 
            // colThang2
            // 
            this.colThang2.Caption = "T2";
            this.colThang2.FieldName = "SLT2C";
            this.colThang2.Name = "colThang2";
            this.colThang2.Visible = true;
            this.colThang2.VisibleIndex = 3;
            this.colThang2.Width = 30;
            // 
            // colThang3
            // 
            this.colThang3.Caption = "T3";
            this.colThang3.FieldName = "SLT3C";
            this.colThang3.Name = "colThang3";
            this.colThang3.Visible = true;
            this.colThang3.VisibleIndex = 4;
            this.colThang3.Width = 30;
            // 
            // colThang4
            // 
            this.colThang4.Caption = "T4";
            this.colThang4.FieldName = "SLT4C";
            this.colThang4.Name = "colThang4";
            this.colThang4.Visible = true;
            this.colThang4.VisibleIndex = 5;
            this.colThang4.Width = 30;
            // 
            // colThang5
            // 
            this.colThang5.Caption = "T5";
            this.colThang5.FieldName = "SLT5C";
            this.colThang5.Name = "colThang5";
            this.colThang5.Visible = true;
            this.colThang5.VisibleIndex = 6;
            this.colThang5.Width = 30;
            // 
            // colThang6
            // 
            this.colThang6.Caption = "T6";
            this.colThang6.FieldName = "SLT6C";
            this.colThang6.Name = "colThang6";
            this.colThang6.Visible = true;
            this.colThang6.VisibleIndex = 7;
            this.colThang6.Width = 30;
            // 
            // colThang7
            // 
            this.colThang7.Caption = "T7";
            this.colThang7.FieldName = "SLT7C";
            this.colThang7.Name = "colThang7";
            this.colThang7.Visible = true;
            this.colThang7.VisibleIndex = 8;
            this.colThang7.Width = 30;
            // 
            // colThang8
            // 
            this.colThang8.Caption = "T8";
            this.colThang8.FieldName = "SLT8C";
            this.colThang8.Name = "colThang8";
            this.colThang8.Visible = true;
            this.colThang8.VisibleIndex = 9;
            this.colThang8.Width = 30;
            // 
            // colThang9
            // 
            this.colThang9.Caption = "T9";
            this.colThang9.FieldName = "SLT9C";
            this.colThang9.Name = "colThang9";
            this.colThang9.Visible = true;
            this.colThang9.VisibleIndex = 10;
            this.colThang9.Width = 30;
            // 
            // colThang10
            // 
            this.colThang10.Caption = "T10";
            this.colThang10.FieldName = "SLT10C";
            this.colThang10.Name = "colThang10";
            this.colThang10.Visible = true;
            this.colThang10.VisibleIndex = 11;
            this.colThang10.Width = 33;
            // 
            // colThang11
            // 
            this.colThang11.Caption = "T11";
            this.colThang11.FieldName = "SLT11C";
            this.colThang11.Name = "colThang11";
            this.colThang11.Visible = true;
            this.colThang11.VisibleIndex = 12;
            this.colThang11.Width = 38;
            // 
            // colThang12
            // 
            this.colThang12.Caption = "T12";
            this.colThang12.FieldName = "SLT12C";
            this.colThang12.Name = "colThang12";
            this.colThang12.Visible = true;
            this.colThang12.VisibleIndex = 13;
            this.colThang12.Width = 30;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Xóa";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExcel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1347, 28);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripExcel
            // 
            this.toolStripExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripExcel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExcel.Image")));
            this.toolStripExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExcel.Name = "toolStripExcel";
            this.toolStripExcel.Size = new System.Drawing.Size(71, 25);
            this.toolStripExcel.Text = "Excel";
            this.toolStripExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // BCTuyenDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1589, 534);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BCTuyenDung";
            this.Text = "Báo cáo tuyển dụng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BCTuyenDung_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNam.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripButton btnFind;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private System.Windows.Forms.ToolStripButton toolStripExcel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.GridControl grd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colThang3;
        private DevExpress.XtraGrid.Columns.GridColumn colPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn colViTri;
        private DevExpress.XtraGrid.Columns.GridColumn colThang1;
        private DevExpress.XtraGrid.Columns.GridColumn colThang2;
        private System.Windows.Forms.Panel panel1;
        private UC.ChonPhongBan cboPhongBan;
        private DevExpress.XtraEditors.LabelControl lblPB;
        private DevExpress.XtraGrid.Columns.GridColumn colThang6;
        private DevExpress.XtraGrid.Columns.GridColumn colThang7;
        private DevExpress.XtraGrid.Columns.GridColumn colThang4;
        private DevExpress.XtraGrid.Columns.GridColumn colThang8;
        private DevExpress.XtraGrid.Columns.GridColumn colThang5;
        private System.Windows.Forms.Label label41;
        private DevExpress.XtraGrid.Columns.GridColumn colThang9;
        private DevExpress.XtraGrid.Columns.GridColumn colThang10;
        private DevExpress.XtraGrid.Columns.GridColumn colThang11;
        private DevExpress.XtraGrid.Columns.GridColumn colThang12;
        private DevExpress.XtraEditors.LabelControl lblNam;
        private DevExpress.XtraEditors.ComboBoxEdit cboNam;
    }
}