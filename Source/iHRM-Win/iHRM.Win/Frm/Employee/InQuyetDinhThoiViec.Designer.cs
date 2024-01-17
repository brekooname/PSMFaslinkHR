namespace iHRM.Win.Frm.Employee
{
    partial class InQuyetDinhThoiViec
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
            this.btnInQD = new DevExpress.XtraEditors.SimpleButton();
            this.grcEmployee = new DevExpress.XtraGrid.GridControl();
            this.grvEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkEmp = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNghi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupInHoSo = new DevExpress.XtraEditors.GroupControl();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.rdGroupInQD = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.grcEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInHoSo)).BeginInit();
            this.groupInHoSo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdGroupInQD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInQD
            // 
            this.btnInQD.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInQD.Appearance.Options.UseFont = true;
            this.btnInQD.Image = global::iHRM.Win.Properties.Resources.btnPrint_Image;
            this.btnInQD.Location = new System.Drawing.Point(1047, 57);
            this.btnInQD.Name = "btnInQD";
            this.btnInQD.Size = new System.Drawing.Size(160, 60);
            this.btnInQD.TabIndex = 1;
            this.btnInQD.Text = "In quyết định";
            this.btnInQD.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // grcEmployee
            // 
            this.grcEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcEmployee.Location = new System.Drawing.Point(0, 183);
            this.grcEmployee.MainView = this.grvEmployee;
            this.grcEmployee.Name = "grcEmployee";
            this.grcEmployee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkEmp});
            this.grcEmployee.Size = new System.Drawing.Size(1233, 370);
            this.grcEmployee.TabIndex = 3;
            this.grcEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployee});
            // 
            // grvEmployee
            // 
            this.grvEmployee.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grvEmployee.Appearance.Row.Options.UseFont = true;
            this.grvEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheck,
            this.colEmpID,
            this.colName,
            this.colBoPhan,
            this.colCMND,
            this.colNgayVao,
            this.colNgayNghi,
            this.colNgaySinh});
            this.grvEmployee.GridControl = this.grcEmployee;
            this.grvEmployee.Name = "grvEmployee";
            this.grvEmployee.OptionsView.ShowAutoFilterRow = true;
            this.grvEmployee.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.grvEmployee.OptionsView.ShowGroupPanel = false;
            this.grvEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvEmployee_KeyDown);
            // 
            // colCheck
            // 
            this.colCheck.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colCheck.AppearanceCell.Options.UseFont = true;
            this.colCheck.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colCheck.AppearanceHeader.Options.UseFont = true;
            this.colCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCheck.Caption = "Chọn";
            this.colCheck.ColumnEdit = this.chkEmp;
            this.colCheck.FieldName = "chkEmp";
            this.colCheck.Name = "colCheck";
            this.colCheck.Visible = true;
            this.colCheck.VisibleIndex = 0;
            this.colCheck.Width = 50;
            // 
            // chkEmp
            // 
            this.chkEmp.AutoHeight = false;
            this.chkEmp.Name = "chkEmp";
            // 
            // colEmpID
            // 
            this.colEmpID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colEmpID.AppearanceCell.Options.UseFont = true;
            this.colEmpID.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colEmpID.AppearanceHeader.Options.UseFont = true;
            this.colEmpID.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmpID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmpID.Caption = "Mã NV";
            this.colEmpID.FieldName = "EmployeeID";
            this.colEmpID.Name = "colEmpID";
            this.colEmpID.OptionsColumn.AllowEdit = false;
            this.colEmpID.Visible = true;
            this.colEmpID.VisibleIndex = 1;
            this.colEmpID.Width = 80;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colName.AppearanceCell.Options.UseFont = true;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Họ Tên";
            this.colName.FieldName = "EmployeeName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 185;
            // 
            // colBoPhan
            // 
            this.colBoPhan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colBoPhan.AppearanceCell.Options.UseFont = true;
            this.colBoPhan.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colBoPhan.AppearanceHeader.Options.UseFont = true;
            this.colBoPhan.AppearanceHeader.Options.UseTextOptions = true;
            this.colBoPhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBoPhan.Caption = "Bộ Phận";
            this.colBoPhan.FieldName = "DepName_Final";
            this.colBoPhan.Name = "colBoPhan";
            this.colBoPhan.OptionsColumn.AllowEdit = false;
            this.colBoPhan.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colBoPhan.Visible = true;
            this.colBoPhan.VisibleIndex = 7;
            this.colBoPhan.Width = 311;
            // 
            // colCMND
            // 
            this.colCMND.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colCMND.AppearanceCell.Options.UseFont = true;
            this.colCMND.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colCMND.AppearanceHeader.Options.UseFont = true;
            this.colCMND.AppearanceHeader.Options.UseTextOptions = true;
            this.colCMND.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCMND.Caption = "Số CMND";
            this.colCMND.FieldName = "IDCard";
            this.colCMND.Name = "colCMND";
            this.colCMND.OptionsColumn.AllowEdit = false;
            this.colCMND.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 3;
            this.colCMND.Width = 102;
            // 
            // colNgayVao
            // 
            this.colNgayVao.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colNgayVao.AppearanceCell.Options.UseFont = true;
            this.colNgayVao.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colNgayVao.AppearanceHeader.Options.UseFont = true;
            this.colNgayVao.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayVao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayVao.Caption = "Ngày vào";
            this.colNgayVao.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayVao.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayVao.FieldName = "AppliedDate";
            this.colNgayVao.Name = "colNgayVao";
            this.colNgayVao.OptionsColumn.AllowEdit = false;
            this.colNgayVao.Visible = true;
            this.colNgayVao.VisibleIndex = 6;
            this.colNgayVao.Width = 137;
            // 
            // colNgayNghi
            // 
            this.colNgayNghi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colNgayNghi.AppearanceCell.Options.UseFont = true;
            this.colNgayNghi.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colNgayNghi.AppearanceHeader.Options.UseFont = true;
            this.colNgayNghi.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayNghi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayNghi.Caption = "Ngày nghỉ";
            this.colNgayNghi.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayNghi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayNghi.FieldName = "LeftDate";
            this.colNgayNghi.Name = "colNgayNghi";
            this.colNgayNghi.OptionsColumn.AllowEdit = false;
            this.colNgayNghi.Visible = true;
            this.colNgayNghi.VisibleIndex = 4;
            this.colNgayNghi.Width = 101;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colNgaySinh.AppearanceCell.Options.UseFont = true;
            this.colNgaySinh.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.colNgaySinh.AppearanceHeader.Options.UseFont = true;
            this.colNgaySinh.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgaySinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgaySinh.Caption = "Ngày sinh";
            this.colNgaySinh.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgaySinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgaySinh.FieldName = "Birthday";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.OptionsColumn.AllowEdit = false;
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 5;
            this.colNgaySinh.Width = 112;
            // 
            // groupInHoSo
            // 
            this.groupInHoSo.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupInHoSo.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupInHoSo.AppearanceCaption.Options.UseFont = true;
            this.groupInHoSo.AppearanceCaption.Options.UseForeColor = true;
            this.groupInHoSo.Controls.Add(this.chonKyLuong1);
            this.groupInHoSo.Controls.Add(this.ucChonDoiTuong_DS1);
            this.groupInHoSo.Controls.Add(this.btnSearch);
            this.groupInHoSo.Controls.Add(this.btnInQD);
            this.groupInHoSo.Controls.Add(this.rdGroupInQD);
            this.groupInHoSo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupInHoSo.Location = new System.Drawing.Point(0, 0);
            this.groupInHoSo.Name = "groupInHoSo";
            this.groupInHoSo.Size = new System.Drawing.Size(1233, 183);
            this.groupInHoSo.TabIndex = 4;
            this.groupInHoSo.Text = "In quyết định thôi việc nhân viên";
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2019, 5, 31, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(832, 37);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(160, 99);
            this.chonKyLuong1.TabIndex = 5;
            this.chonKyLuong1.TuNgay = new System.DateTime(2019, 5, 1, 0, 0, 0, 0);
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(396, 25);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(434, 158);
            this.ucChonDoiTuong_DS1.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnSearch.Location = new System.Drawing.Point(832, 142);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(160, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm kiếm nhân viên";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdGroupInQD
            // 
            this.rdGroupInQD.Location = new System.Drawing.Point(5, 25);
            this.rdGroupInQD.Name = "rdGroupInQD";
            this.rdGroupInQD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdGroupInQD.Properties.Appearance.Options.UseFont = true;
            this.rdGroupInQD.Size = new System.Drawing.Size(391, 158);
            this.rdGroupInQD.TabIndex = 3;
            // 
            // InQuyetDinhThoiViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 553);
            this.Controls.Add(this.grcEmployee);
            this.Controls.Add(this.groupInHoSo);
            this.KeyPreview = true;
            this.Name = "InQuyetDinhThoiViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In quyết đinh thôi việc ";
            this.Load += new System.EventHandler(this.InQuyetDinhThoiViec_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InQuyetDinhThoiViec_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grcEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInHoSo)).EndInit();
            this.groupInHoSo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdGroupInQD.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnInQD;
        private DevExpress.XtraGrid.GridControl grcEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEmp;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBoPhan;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVao;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraEditors.GroupControl groupInHoSo;
        private DevExpress.XtraEditors.RadioGroup rdGroupInQD;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNghi;
    }
}