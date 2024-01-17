namespace iHRM.Win.UC
{
    partial class ucChonDoiTuong_DS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboSearchNhom = new DevExpress.XtraEditors.LookUpEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.panelCheck = new DevExpress.XtraEditors.PanelControl();
            this.cboSearchTen = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mmMaNV = new DevExpress.XtraEditors.MemoEdit();
            this.panelDanhSach = new DevExpress.XtraEditors.PanelControl();
            this.btnDSNV = new DevExpress.XtraEditors.SimpleButton();
            this.rdLoaiDK = new DevExpress.XtraEditors.RadioGroup();
            this.panelTitle = new DevExpress.XtraEditors.PanelControl();
            this.groupDSNV = new DevExpress.XtraEditors.GroupControl();
            this.EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DepName_Final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.splitDSNV = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchNhom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCheck)).BeginInit();
            this.panelCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDanhSach)).BeginInit();
            this.panelDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdLoaiDK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).BeginInit();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupDSNV)).BeginInit();
            this.groupDSNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDSNV)).BeginInit();
            this.splitDSNV.Panel1.SuspendLayout();
            this.splitDSNV.Panel2.SuspendLayout();
            this.splitDSNV.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSearchNhom
            // 
            this.cboSearchNhom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearchNhom.Location = new System.Drawing.Point(96, 65);
            this.cboSearchNhom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cboSearchNhom.Name = "cboSearchNhom";
            this.cboSearchNhom.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.cboSearchNhom.Properties.Appearance.Options.UseFont = true;
            this.cboSearchNhom.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboSearchNhom.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboSearchNhom.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.cboSearchNhom.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cboSearchNhom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cboSearchNhom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSearchNhom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("gName", 220, "Nhóm")});
            this.cboSearchNhom.Properties.DisplayMember = "gName";
            this.cboSearchNhom.Properties.NullText = "Chọn nhóm";
            this.cboSearchNhom.Properties.PopupSizeable = false;
            this.cboSearchNhom.Properties.ValueMember = "id";
            this.cboSearchNhom.Size = new System.Drawing.Size(225, 26);
            this.cboSearchNhom.TabIndex = 10;
            this.cboSearchNhom.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
            // 
            // checkEdit3
            // 
            this.checkEdit3.EditValue = null;
            this.checkEdit3.Location = new System.Drawing.Point(3, 66);
            this.checkEdit3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.checkEdit3.Properties.Appearance.Options.UseFont = true;
            this.checkEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit3.Properties.Caption = "Nhóm NV:";
            this.checkEdit3.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
            this.checkEdit3.Properties.RadioGroupIndex = 1;
            this.checkEdit3.Size = new System.Drawing.Size(90, 22);
            this.checkEdit3.TabIndex = 11;
            this.checkEdit3.TabStop = false;
            this.checkEdit3.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // checkEdit2
            // 
            this.checkEdit2.EditValue = null;
            this.checkEdit2.Location = new System.Drawing.Point(3, 35);
            this.checkEdit2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.checkEdit2.Properties.Appearance.Options.UseFont = true;
            this.checkEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit2.Properties.Caption = "Phòng ban:";
            this.checkEdit2.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
            this.checkEdit2.Properties.RadioGroupIndex = 1;
            this.checkEdit2.Size = new System.Drawing.Size(90, 22);
            this.checkEdit2.TabIndex = 12;
            this.checkEdit2.TabStop = false;
            this.checkEdit2.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = null;
            this.checkEdit1.Location = new System.Drawing.Point(3, 5);
            this.checkEdit1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit1.Properties.Caption = "Nhân viên:";
            this.checkEdit1.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
            this.checkEdit1.Properties.RadioGroupIndex = 1;
            this.checkEdit1.Size = new System.Drawing.Size(88, 22);
            this.checkEdit1.TabIndex = 13;
            this.checkEdit1.TabStop = false;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // txtMaNV
            // 
            this.txtMaNV.EditValue = "";
            this.txtMaNV.Location = new System.Drawing.Point(96, 3);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtMaNV.Properties.Appearance.Options.UseFont = true;
            this.txtMaNV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtMaNV.Size = new System.Drawing.Size(73, 26);
            this.txtMaNV.TabIndex = 14;
            this.txtMaNV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaNV_KeyDown);
            // 
            // panelCheck
            // 
            this.panelCheck.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCheck.Controls.Add(this.checkEdit1);
            this.panelCheck.Controls.Add(this.checkEdit2);
            this.panelCheck.Controls.Add(this.cboSearchTen);
            this.panelCheck.Controls.Add(this.chonPhongBan1);
            this.panelCheck.Controls.Add(this.checkEdit3);
            this.panelCheck.Controls.Add(this.txtMaNV);
            this.panelCheck.Controls.Add(this.cboSearchNhom);
            this.panelCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheck.Location = new System.Drawing.Point(2, 55);
            this.panelCheck.Name = "panelCheck";
            this.panelCheck.Size = new System.Drawing.Size(324, 97);
            this.panelCheck.TabIndex = 17;
            this.panelCheck.Visible = false;
            // 
            // cboSearchTen
            // 
            this.cboSearchTen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearchTen.Location = new System.Drawing.Point(172, 3);
            this.cboSearchTen.Name = "cboSearchTen";
            this.cboSearchTen.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchTen.Properties.Appearance.Options.UseFont = true;
            this.cboSearchTen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cboSearchTen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSearchTen.Properties.NullText = "Nhập tên";
            this.cboSearchTen.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cboSearchTen.Properties.View = this.searchLookUpEdit1View;
            this.cboSearchTen.Size = new System.Drawing.Size(148, 26);
            this.cboSearchTen.TabIndex = 16;
            this.cboSearchTen.EditValueChanged += new System.EventHandler(this.cboSearchTen_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EmployeeCode,
            this.EmployeeName,
            this.DepName_Final});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // mmMaNV
            // 
            this.mmMaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mmMaNV.Location = new System.Drawing.Point(0, 0);
            this.mmMaNV.Name = "mmMaNV";
            this.mmMaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmMaNV.Properties.Appearance.Options.UseFont = true;
            this.mmMaNV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mmMaNV.Size = new System.Drawing.Size(324, 68);
            this.mmMaNV.TabIndex = 21;
            // 
            // panelDanhSach
            // 
            this.panelDanhSach.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelDanhSach.Controls.Add(this.splitDSNV);
            this.panelDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDanhSach.Location = new System.Drawing.Point(2, 55);
            this.panelDanhSach.Name = "panelDanhSach";
            this.panelDanhSach.Size = new System.Drawing.Size(324, 97);
            this.panelDanhSach.TabIndex = 26;
            // 
            // btnDSNV
            // 
            this.btnDSNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnDSNV.Appearance.Options.UseFont = true;
            this.btnDSNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDSNV.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDSNV.Location = new System.Drawing.Point(0, 0);
            this.btnDSNV.Name = "btnDSNV";
            this.btnDSNV.Size = new System.Drawing.Size(324, 25);
            this.btnDSNV.TabIndex = 22;
            this.btnDSNV.Text = "Danh sách nhân viên";
            this.btnDSNV.Click += new System.EventHandler(this.btnDSNV_Click);
            // 
            // rdLoaiDK
            // 
            this.rdLoaiDK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdLoaiDK.EditValue = ((short)(0));
            this.rdLoaiDK.Location = new System.Drawing.Point(0, 0);
            this.rdLoaiDK.Name = "rdLoaiDK";
            this.rdLoaiDK.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLoaiDK.Properties.Appearance.Options.UseFont = true;
            this.rdLoaiDK.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.rdLoaiDK.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Chọn danh sách"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Chọn theo NV và PB")});
            this.rdLoaiDK.Size = new System.Drawing.Size(324, 29);
            this.rdLoaiDK.TabIndex = 24;
            this.rdLoaiDK.SelectedIndexChanged += new System.EventHandler(this.rdLoaiDK_SelectedIndexChanged);
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTitle.Controls.Add(this.rdLoaiDK);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(2, 26);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(324, 29);
            this.panelTitle.TabIndex = 25;
            // 
            // groupDSNV
            // 
            this.groupDSNV.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDSNV.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupDSNV.AppearanceCaption.Options.UseFont = true;
            this.groupDSNV.AppearanceCaption.Options.UseForeColor = true;
            this.groupDSNV.AppearanceCaption.Options.UseTextOptions = true;
            this.groupDSNV.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupDSNV.Controls.Add(this.panelDanhSach);
            this.groupDSNV.Controls.Add(this.panelCheck);
            this.groupDSNV.Controls.Add(this.panelTitle);
            this.groupDSNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDSNV.Location = new System.Drawing.Point(0, 0);
            this.groupDSNV.Name = "groupDSNV";
            this.groupDSNV.Size = new System.Drawing.Size(328, 154);
            this.groupDSNV.TabIndex = 22;
            this.groupDSNV.Text = "Danh sách nhân viên";
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.Caption = "Mã nhân viên";
            this.EmployeeCode.FieldName = "EmployeeCode";
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.Visible = true;
            this.EmployeeCode.VisibleIndex = 0;
            this.EmployeeCode.Width = 319;
            // 
            // EmployeeName
            // 
            this.EmployeeName.Caption = "Tên nhân viên";
            this.EmployeeName.FieldName = "EmployeeName";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Visible = true;
            this.EmployeeName.VisibleIndex = 1;
            this.EmployeeName.Width = 656;
            // 
            // DepName_Final
            // 
            this.DepName_Final.Caption = "Phòng ban";
            this.DepName_Final.FieldName = "DepName_Final";
            this.DepName_Final.Name = "DepName_Final";
            this.DepName_Final.Visible = true;
            this.DepName_Final.VisibleIndex = 2;
            this.DepName_Final.Width = 657;
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonPhongBan1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.chonPhongBan1.Location = new System.Drawing.Point(96, 34);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(225, 28);
            this.chonPhongBan1.TabIndex = 15;
            this.chonPhongBan1.OnSelected += new System.EventHandler(this.chonPhongBan1_OnSelected);
            // 
            // splitDSNV
            // 
            this.splitDSNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDSNV.Location = new System.Drawing.Point(0, 0);
            this.splitDSNV.Name = "splitDSNV";
            this.splitDSNV.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitDSNV.Panel1
            // 
            this.splitDSNV.Panel1.Controls.Add(this.btnDSNV);
            // 
            // splitDSNV.Panel2
            // 
            this.splitDSNV.Panel2.Controls.Add(this.mmMaNV);
            this.splitDSNV.Size = new System.Drawing.Size(324, 97);
            this.splitDSNV.SplitterDistance = 25;
            this.splitDSNV.TabIndex = 23;
            // 
            // ucChonDoiTuong_DS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupDSNV);
            this.Name = "ucChonDoiTuong_DS";
            this.Size = new System.Drawing.Size(328, 154);
            this.Load += new System.EventHandler(this.ucChonDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchNhom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCheck)).EndInit();
            this.panelCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDanhSach)).EndInit();
            this.panelDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdLoaiDK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).EndInit();
            this.panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupDSNV)).EndInit();
            this.groupDSNV.ResumeLayout(false);
            this.splitDSNV.Panel1.ResumeLayout(false);
            this.splitDSNV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDSNV)).EndInit();
            this.splitDSNV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ChonPhongBan chonPhongBan1;
        private DevExpress.XtraEditors.LookUpEdit cboSearchNhom;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraEditors.PanelControl panelCheck;
        private DevExpress.XtraEditors.RadioGroup rdLoaiDK;
        private DevExpress.XtraEditors.PanelControl panelTitle;
        private DevExpress.XtraEditors.PanelControl panelDanhSach;
        private DevExpress.XtraEditors.GroupControl groupDSNV;
        private DevExpress.XtraEditors.MemoEdit mmMaNV;
        private DevExpress.XtraEditors.SearchLookUpEdit cboSearchTen;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn EmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn EmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn DepName_Final;
        private DevExpress.XtraEditors.SimpleButton btnDSNV;
        private System.Windows.Forms.SplitContainer splitDSNV;
    }
}
