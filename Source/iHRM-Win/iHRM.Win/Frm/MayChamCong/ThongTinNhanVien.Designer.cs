namespace iHRM.Win.Frm.MayChamCong
{
    partial class ThongTinNhanVien
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
            this.groupDanhSachNhanVien = new DevExpress.XtraEditors.GroupControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.grcTTNV = new DevExpress.XtraGrid.GridControl();
            this.grvTTNV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayChamCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenChamCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTheQuet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaThesHRM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepName_Final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.MenuExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRefresh_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupDanhSachNhanVien)).BeginInit();
            this.groupDanhSachNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTTNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTTNV)).BeginInit();
            this.menuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDanhSachNhanVien
            // 
            this.groupDanhSachNhanVien.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDanhSachNhanVien.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupDanhSachNhanVien.AppearanceCaption.Options.UseFont = true;
            this.groupDanhSachNhanVien.AppearanceCaption.Options.UseForeColor = true;
            this.groupDanhSachNhanVien.Controls.Add(this.lblStatus);
            this.groupDanhSachNhanVien.Controls.Add(this.grcTTNV);
            this.groupDanhSachNhanVien.Controls.Add(this.menuStrip3);
            this.groupDanhSachNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDanhSachNhanVien.Location = new System.Drawing.Point(0, 0);
            this.groupDanhSachNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupDanhSachNhanVien.Name = "groupDanhSachNhanVien";
            this.groupDanhSachNhanVien.Size = new System.Drawing.Size(1079, 521);
            this.groupDanhSachNhanVien.TabIndex = 0;
            this.groupDanhSachNhanVien.Text = "Danh sách nhân viên";
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.LineColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(810, 9);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(293, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Loại nhân viên. 0:User.  3: Administrator";
            // 
            // grcTTNV
            // 
            this.grcTTNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcTTNV.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcTTNV.Location = new System.Drawing.Point(2, 67);
            this.grcTTNV.MainView = this.grvTTNV;
            this.grcTTNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grcTTNV.Name = "grcTTNV";
            this.grcTTNV.Size = new System.Drawing.Size(1075, 452);
            this.grcTTNV.TabIndex = 4;
            this.grcTTNV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTTNV});
            // 
            // grvTTNV
            // 
            this.grvTTNV.ColumnPanelRowHeight = 30;
            this.grvTTNV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colMayChamCong,
            this.colTenChamCong,
            this.colSoTheQuet,
            this.colMaThesHRM,
            this.colLoaiNhanVien,
            this.colDepName_Final});
            this.grvTTNV.GridControl = this.grcTTNV;
            this.grvTTNV.Name = "grvTTNV";
            this.grvTTNV.NewItemRowText = "Nhập nhân viên mới";
            this.grvTTNV.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvTTNV.OptionsView.RowAutoHeight = true;
            this.grvTTNV.OptionsView.ShowAutoFilterRow = true;
            this.grvTTNV.OptionsView.ShowGroupPanel = false;
            this.grvTTNV.RowHeight = 26;
            this.grvTTNV.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvKhaibaoMCC_InitNewRow_1);
            this.grvTTNV.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTTNV_CellValueChanged);
            this.grvTTNV.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvKhaiBaoMCC_CustomUnboundColumnData);
            this.grvTTNV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvTTNV_KeyDown);
            // 
            // colSTT
            // 
            this.colSTT.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
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
            this.colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 69;
            // 
            // colMayChamCong
            // 
            this.colMayChamCong.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.colMayChamCong.AppearanceCell.Options.UseFont = true;
            this.colMayChamCong.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colMayChamCong.AppearanceHeader.Options.UseFont = true;
            this.colMayChamCong.AppearanceHeader.Options.UseTextOptions = true;
            this.colMayChamCong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMayChamCong.Caption = "Mã Chấm Công";
            this.colMayChamCong.FieldName = "maChamCong";
            this.colMayChamCong.Name = "colMayChamCong";
            this.colMayChamCong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMayChamCong.Visible = true;
            this.colMayChamCong.VisibleIndex = 1;
            this.colMayChamCong.Width = 117;
            // 
            // colTenChamCong
            // 
            this.colTenChamCong.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.colTenChamCong.AppearanceCell.Options.UseFont = true;
            this.colTenChamCong.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colTenChamCong.AppearanceHeader.Options.UseFont = true;
            this.colTenChamCong.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenChamCong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenChamCong.Caption = "Tên Chấm Công";
            this.colTenChamCong.FieldName = "tenChamCong";
            this.colTenChamCong.Name = "colTenChamCong";
            this.colTenChamCong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenChamCong.Visible = true;
            this.colTenChamCong.VisibleIndex = 2;
            this.colTenChamCong.Width = 314;
            // 
            // colSoTheQuet
            // 
            this.colSoTheQuet.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.colSoTheQuet.AppearanceCell.Options.UseFont = true;
            this.colSoTheQuet.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colSoTheQuet.AppearanceHeader.Options.UseFont = true;
            this.colSoTheQuet.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoTheQuet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoTheQuet.Caption = "Số Thẻ ( Thẻ Quẹt)";
            this.colSoTheQuet.FieldName = "maThe";
            this.colSoTheQuet.Name = "colSoTheQuet";
            this.colSoTheQuet.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSoTheQuet.Visible = true;
            this.colSoTheQuet.VisibleIndex = 4;
            this.colSoTheQuet.Width = 313;
            // 
            // colMaThesHRM
            // 
            this.colMaThesHRM.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.colMaThesHRM.AppearanceCell.Options.UseFont = true;
            this.colMaThesHRM.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colMaThesHRM.AppearanceHeader.Options.UseFont = true;
            this.colMaThesHRM.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaThesHRM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaThesHRM.Caption = "Mã nhân viên iHRM";
            this.colMaThesHRM.FieldName = "maNV";
            this.colMaThesHRM.Name = "colMaThesHRM";
            this.colMaThesHRM.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaThesHRM.Visible = true;
            this.colMaThesHRM.VisibleIndex = 5;
            this.colMaThesHRM.Width = 270;
            // 
            // colLoaiNhanVien
            // 
            this.colLoaiNhanVien.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.colLoaiNhanVien.AppearanceCell.Options.UseFont = true;
            this.colLoaiNhanVien.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colLoaiNhanVien.AppearanceHeader.Options.UseFont = true;
            this.colLoaiNhanVien.AppearanceHeader.Options.UseTextOptions = true;
            this.colLoaiNhanVien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLoaiNhanVien.Caption = "Loại nhân viên";
            this.colLoaiNhanVien.FieldName = "loaiNhanVien";
            this.colLoaiNhanVien.Name = "colLoaiNhanVien";
            this.colLoaiNhanVien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colLoaiNhanVien.Visible = true;
            this.colLoaiNhanVien.VisibleIndex = 3;
            this.colLoaiNhanVien.Width = 218;
            // 
            // colDepName_Final
            // 
            this.colDepName_Final.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.colDepName_Final.AppearanceCell.Options.UseFont = true;
            this.colDepName_Final.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.colDepName_Final.AppearanceHeader.Options.UseFont = true;
            this.colDepName_Final.AppearanceHeader.Options.UseTextOptions = true;
            this.colDepName_Final.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepName_Final.Caption = "Phòng ban";
            this.colDepName_Final.FieldName = "DepName_Final";
            this.colDepName_Final.Name = "colDepName_Final";
            this.colDepName_Final.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDepName_Final.Width = 331;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExcel,
            this.menuSave_LuongCB,
            this.menuEdit_LuongCB,
            this.menuDelete_LuongCB,
            this.menuRefresh_LuongCB});
            this.menuStrip3.Location = new System.Drawing.Point(2, 31);
            this.menuStrip3.MinimumSize = new System.Drawing.Size(0, 36);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip3.Size = new System.Drawing.Size(1075, 36);
            this.menuStrip3.TabIndex = 3;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // MenuExcel
            // 
            this.MenuExcel.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.MenuExcel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.MenuExcel.Name = "MenuExcel";
            this.MenuExcel.Size = new System.Drawing.Size(80, 32);
            this.MenuExcel.Tag = "Excel";
            this.MenuExcel.Text = "Excel";
            this.MenuExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MenuExcel.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // menuSave_LuongCB
            // 
            this.menuSave_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuSave_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.menuSave_LuongCB.Name = "menuSave_LuongCB";
            this.menuSave_LuongCB.Size = new System.Drawing.Size(92, 32);
            this.menuSave_LuongCB.Text = "Lưu lại";
            this.menuSave_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuSave_LuongCB.Click += new System.EventHandler(this.menuSave_LuongCB_Click);
            // 
            // menuEdit_LuongCB
            // 
            this.menuEdit_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuEdit_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnEdit_Image;
            this.menuEdit_LuongCB.Name = "menuEdit_LuongCB";
            this.menuEdit_LuongCB.Size = new System.Drawing.Size(69, 32);
            this.menuEdit_LuongCB.Text = "Sửa";
            this.menuEdit_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuEdit_LuongCB.Click += new System.EventHandler(this.menuEdit_LuongCB_Click);
            // 
            // menuDelete_LuongCB
            // 
            this.menuDelete_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuDelete_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnDelete_Image;
            this.menuDelete_LuongCB.Name = "menuDelete_LuongCB";
            this.menuDelete_LuongCB.Size = new System.Drawing.Size(94, 32);
            this.menuDelete_LuongCB.Text = "Xóa bỏ";
            this.menuDelete_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuDelete_LuongCB.Click += new System.EventHandler(this.menuDelete_LuongCB_Click);
            // 
            // menuRefresh_LuongCB
            // 
            this.menuRefresh_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuRefresh_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnRefresh_Image;
            this.menuRefresh_LuongCB.Name = "menuRefresh_LuongCB";
            this.menuRefresh_LuongCB.Size = new System.Drawing.Size(107, 32);
            this.menuRefresh_LuongCB.Text = "Làm mới";
            this.menuRefresh_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuRefresh_LuongCB.Click += new System.EventHandler(this.menuRefresh_LuongCB_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.groupDanhSachNhanVien);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1079, 521);
            this.panelControl1.TabIndex = 1;
            // 
            // ThongTinNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 521);
            this.Controls.Add(this.panelControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ThongTinNhanVien";
            this.Text = "Danh sách thông tin nhân viên";
            this.Load += new System.EventHandler(this.KhaibaoMCC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ThongTinNhanVien_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupDanhSachNhanVien)).EndInit();
            this.groupDanhSachNhanVien.ResumeLayout(false);
            this.groupDanhSachNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTTNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTTNV)).EndInit();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupDanhSachNhanVien;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem menuSave_LuongCB;
        private System.Windows.Forms.ToolStripMenuItem menuDelete_LuongCB;
        private System.Windows.Forms.ToolStripMenuItem menuRefresh_LuongCB;
        private DevExpress.XtraGrid.GridControl grcTTNV;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTTNV;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colMayChamCong;
        private DevExpress.XtraGrid.Columns.GridColumn colTenChamCong;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTheQuet;
        private DevExpress.XtraGrid.Columns.GridColumn colMaThesHRM;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiNhanVien;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private System.Windows.Forms.ToolStripMenuItem menuEdit_LuongCB;
        private DevExpress.XtraGrid.Columns.GridColumn colDepName_Final;
        private System.Windows.Forms.ToolStripMenuItem MenuExcel;
    }
}