namespace iHRM.Win.Frm.MayChamCong
{
    partial class KhaibaoMCC
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
            this.groupDanhSachMCC = new DevExpress.XtraEditors.GroupControl();
            this.grcKhaibaoMCC = new DevExpress.XtraGrid.GridControl();
            this.grvKhaibaoMCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChiIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.menuSave_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRefresh_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupDanhSachMCC)).BeginInit();
            this.groupDanhSachMCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcKhaibaoMCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKhaibaoMCC)).BeginInit();
            this.menuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDanhSachMCC
            // 
            this.groupDanhSachMCC.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDanhSachMCC.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupDanhSachMCC.AppearanceCaption.Options.UseFont = true;
            this.groupDanhSachMCC.AppearanceCaption.Options.UseForeColor = true;
            this.groupDanhSachMCC.Controls.Add(this.grcKhaibaoMCC);
            this.groupDanhSachMCC.Controls.Add(this.menuStrip3);
            this.groupDanhSachMCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDanhSachMCC.Location = new System.Drawing.Point(0, 0);
            this.groupDanhSachMCC.Name = "groupDanhSachMCC";
            this.groupDanhSachMCC.Size = new System.Drawing.Size(925, 423);
            this.groupDanhSachMCC.TabIndex = 0;
            this.groupDanhSachMCC.Text = "Danh sách máy chấm công";
            // 
            // grcKhaibaoMCC
            // 
            this.grcKhaibaoMCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcKhaibaoMCC.Location = new System.Drawing.Point(2, 56);
            this.grcKhaibaoMCC.MainView = this.grvKhaibaoMCC;
            this.grcKhaibaoMCC.Name = "grcKhaibaoMCC";
            this.grcKhaibaoMCC.Size = new System.Drawing.Size(921, 365);
            this.grcKhaibaoMCC.TabIndex = 4;
            this.grcKhaibaoMCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKhaibaoMCC});
            // 
            // grvKhaibaoMCC
            // 
            this.grvKhaibaoMCC.ColumnPanelRowHeight = 30;
            this.grvKhaibaoMCC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colSoMay,
            this.colTenMay,
            this.colDiaChiIP,
            this.colPort});
            this.grvKhaibaoMCC.GridControl = this.grcKhaibaoMCC;
            this.grvKhaibaoMCC.Name = "grvKhaibaoMCC";
            this.grvKhaibaoMCC.NewItemRowText = "Nhập máy chấm công mới";
            this.grvKhaibaoMCC.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvKhaibaoMCC.OptionsView.ShowAutoFilterRow = true;
            this.grvKhaibaoMCC.OptionsView.ShowGroupPanel = false;
            this.grvKhaibaoMCC.RowHeight = 26;
            this.grvKhaibaoMCC.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvKhaibaoMCC_InitNewRow_1);
            this.grvKhaibaoMCC.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvKhaiBaoMCC_CustomUnboundColumnData);
            // 
            // colSTT
            // 
            this.colSTT.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colSTT.AppearanceCell.Options.UseFont = true;
            this.colSTT.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colSTT.AppearanceHeader.Options.UseFont = true;
            this.colSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "gridColumn1";
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsColumn.AllowEdit = false;
            this.colSTT.OptionsColumn.AllowFocus = false;
            this.colSTT.OptionsColumn.ReadOnly = true;
            this.colSTT.OptionsColumn.TabStop = false;
            this.colSTT.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 226;
            // 
            // colSoMay
            // 
            this.colSoMay.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colSoMay.AppearanceCell.Options.UseFont = true;
            this.colSoMay.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colSoMay.AppearanceHeader.Options.UseFont = true;
            this.colSoMay.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoMay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoMay.Caption = "Số máy";
            this.colSoMay.FieldName = "soMay";
            this.colSoMay.Name = "colSoMay";
            this.colSoMay.OptionsColumn.AllowEdit = false;
            this.colSoMay.OptionsColumn.AllowFocus = false;
            this.colSoMay.OptionsColumn.ReadOnly = true;
            this.colSoMay.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoMay.Visible = true;
            this.colSoMay.VisibleIndex = 1;
            // 
            // colTenMay
            // 
            this.colTenMay.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colTenMay.AppearanceCell.Options.UseFont = true;
            this.colTenMay.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colTenMay.AppearanceHeader.Options.UseFont = true;
            this.colTenMay.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenMay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenMay.Caption = "Tên máy";
            this.colTenMay.FieldName = "tenMay";
            this.colTenMay.Name = "colTenMay";
            this.colTenMay.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenMay.Visible = true;
            this.colTenMay.VisibleIndex = 2;
            this.colTenMay.Width = 468;
            // 
            // colDiaChiIP
            // 
            this.colDiaChiIP.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colDiaChiIP.AppearanceCell.Options.UseFont = true;
            this.colDiaChiIP.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colDiaChiIP.AppearanceHeader.Options.UseFont = true;
            this.colDiaChiIP.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiaChiIP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiaChiIP.Caption = "Địa chỉ IP";
            this.colDiaChiIP.FieldName = "diaChiIP";
            this.colDiaChiIP.Name = "colDiaChiIP";
            this.colDiaChiIP.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDiaChiIP.Visible = true;
            this.colDiaChiIP.VisibleIndex = 3;
            this.colDiaChiIP.Width = 468;
            // 
            // colPort
            // 
            this.colPort.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.colPort.AppearanceCell.Options.UseFont = true;
            this.colPort.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colPort.AppearanceHeader.Options.UseFont = true;
            this.colPort.AppearanceHeader.Options.UseTextOptions = true;
            this.colPort.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPort.Caption = "Port";
            this.colPort.FieldName = "port";
            this.colPort.Name = "colPort";
            this.colPort.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPort.Visible = true;
            this.colPort.VisibleIndex = 4;
            this.colPort.Width = 470;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSave_LuongCB,
            this.menuDelete_LuongCB,
            this.menuRefresh_LuongCB,
            this.menuEdit_LuongCB});
            this.menuStrip3.Location = new System.Drawing.Point(2, 27);
            this.menuStrip3.MinimumSize = new System.Drawing.Size(0, 29);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip3.Size = new System.Drawing.Size(921, 29);
            this.menuStrip3.TabIndex = 3;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // menuSave_LuongCB
            // 
            this.menuSave_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuSave_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.menuSave_LuongCB.Name = "menuSave_LuongCB";
            this.menuSave_LuongCB.Size = new System.Drawing.Size(79, 25);
            this.menuSave_LuongCB.Text = "Lưu lại";
            this.menuSave_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuSave_LuongCB.Click += new System.EventHandler(this.menuSave_LuongCB_Click);
            // 
            // menuDelete_LuongCB
            // 
            this.menuDelete_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuDelete_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnDelete_Image;
            this.menuDelete_LuongCB.Name = "menuDelete_LuongCB";
            this.menuDelete_LuongCB.Size = new System.Drawing.Size(81, 25);
            this.menuDelete_LuongCB.Text = "Xóa bỏ";
            this.menuDelete_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuDelete_LuongCB.Click += new System.EventHandler(this.menuDelete_LuongCB_Click);
            // 
            // menuRefresh_LuongCB
            // 
            this.menuRefresh_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuRefresh_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnRefresh_Image;
            this.menuRefresh_LuongCB.Name = "menuRefresh_LuongCB";
            this.menuRefresh_LuongCB.Size = new System.Drawing.Size(90, 25);
            this.menuRefresh_LuongCB.Text = "Làm mới";
            this.menuRefresh_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuRefresh_LuongCB.Click += new System.EventHandler(this.menuRefresh_LuongCB_Click);
            // 
            // menuEdit_LuongCB
            // 
            this.menuEdit_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuEdit_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnEdit_Image;
            this.menuEdit_LuongCB.Name = "menuEdit_LuongCB";
            this.menuEdit_LuongCB.Size = new System.Drawing.Size(62, 25);
            this.menuEdit_LuongCB.Text = "Sửa";
            this.menuEdit_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuEdit_LuongCB.Click += new System.EventHandler(this.menuEdit_LuongCB_Click_1);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.groupDanhSachMCC);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(925, 423);
            this.panelControl1.TabIndex = 1;
            // 
            // KhaibaoMCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 423);
            this.Controls.Add(this.panelControl1);
            this.KeyPreview = true;
            this.Name = "KhaibaoMCC";
            this.Text = "Khai báo máy chấm công";
            this.Load += new System.EventHandler(this.KhaibaoMCC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KhaibaoMCC_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupDanhSachMCC)).EndInit();
            this.groupDanhSachMCC.ResumeLayout(false);
            this.groupDanhSachMCC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcKhaibaoMCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKhaibaoMCC)).EndInit();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupDanhSachMCC;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem menuSave_LuongCB;
        private System.Windows.Forms.ToolStripMenuItem menuDelete_LuongCB;
        private System.Windows.Forms.ToolStripMenuItem menuRefresh_LuongCB;
        private DevExpress.XtraGrid.GridControl grcKhaibaoMCC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKhaibaoMCC;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colSoMay;
        private DevExpress.XtraGrid.Columns.GridColumn colTenMay;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChiIP;
        private DevExpress.XtraGrid.Columns.GridColumn colPort;
        private System.Windows.Forms.ToolStripMenuItem menuEdit_LuongCB;
    }
}