namespace iHRM.Win.Frm.QuetThe
{
    partial class dlgDangKyCaLam
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ucProgress1 = new iHRM.Win.UC.ucProgress();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnDangKyDA = new DevExpress.XtraEditors.SimpleButton();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.txtTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.btnDangKyExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblCaLam = new DevExpress.XtraEditors.LabelControl();
            this.txtCaLam = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioVaoCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioRaCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTienHetCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTienTangCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbHeSoLuong = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblHeSo = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaLam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHeSoLuong.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbHeSoLuong);
            this.panel1.Controls.Add(this.lblHeSo);
            this.panel1.Size = new System.Drawing.Size(581, 70);
            this.panel1.Controls.SetChildIndex(this.lblHeSo, 0);
            this.panel1.Controls.SetChildIndex(this.cmbHeSoLuong, 0);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.ucProgress1);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 70);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(581, 511);
            this.panelControl2.TabIndex = 5;
            // 
            // ucProgress1
            // 
            this.ucProgress1.CurrentValue = 0;
            this.ucProgress1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProgress1.Location = new System.Drawing.Point(0, 288);
            this.ucProgress1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucProgress1.Message = "";
            this.ucProgress1.Name = "ucProgress1";
            this.ucProgress1.Size = new System.Drawing.Size(581, 223);
            this.ucProgress1.Status = "Đang đăng ký 30/100";
            this.ucProgress1.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.btnDangKyDA);
            this.panelControl4.Controls.Add(this.ucChonDoiTuong_DS1);
            this.panelControl4.Controls.Add(this.txtTuNgay);
            this.panelControl4.Controls.Add(this.btnDangKyExcel);
            this.panelControl4.Controls.Add(this.btnSave);
            this.panelControl4.Controls.Add(this.txtDenNgay);
            this.panelControl4.Controls.Add(this.lblDenNgay);
            this.panelControl4.Controls.Add(this.lblTuNgay);
            this.panelControl4.Controls.Add(this.lblCaLam);
            this.panelControl4.Controls.Add(this.txtCaLam);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(581, 288);
            this.panelControl4.TabIndex = 28;
            // 
            // btnDangKyDA
            // 
            this.btnDangKyDA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangKyDA.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKyDA.Appearance.Options.UseFont = true;
            this.btnDangKyDA.Image = global::iHRM.Win.Properties.Resources.btnImport_Image;
            this.btnDangKyDA.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDangKyDA.Location = new System.Drawing.Point(426, 245);
            this.btnDangKyDA.Name = "btnDangKyDA";
            this.btnDangKyDA.Size = new System.Drawing.Size(150, 36);
            this.btnDangKyDA.TabIndex = 6;
            this.btnDangKyDA.Text = "ĐK Tháng";
            this.btnDangKyDA.Click += new System.EventHandler(this.btnDangKyDA_Click);
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(0, 0);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(581, 158);
            this.ucChonDoiTuong_DS1.TabIndex = 0;
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.EditValue = null;
            this.txtTuNgay.Location = new System.Drawing.Point(76, 166);
            this.txtTuNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuNgay.Properties.Appearance.Options.UseFont = true;
            this.txtTuNgay.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.txtTuNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTuNgay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTuNgay.Size = new System.Drawing.Size(110, 26);
            this.txtTuNgay.TabIndex = 1;
            this.txtTuNgay.Leave += new System.EventHandler(this.txtTuNgay_Leave);
            // 
            // btnDangKyExcel
            // 
            this.btnDangKyExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangKyExcel.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKyExcel.Appearance.Options.UseFont = true;
            this.btnDangKyExcel.Image = global::iHRM.Win.Properties.Resources.btnImport_Image;
            this.btnDangKyExcel.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDangKyExcel.Location = new System.Drawing.Point(426, 204);
            this.btnDangKyExcel.Name = "btnDangKyExcel";
            this.btnDangKyExcel.Size = new System.Drawing.Size(150, 36);
            this.btnDangKyExcel.TabIndex = 5;
            this.btnDangKyExcel.Text = "ĐK bằng excel";
            this.btnDangKyExcel.Click += new System.EventHandler(this.btnDangKyExcel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(426, 164);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "  Đăng ký";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.EditValue = null;
            this.txtDenNgay.Location = new System.Drawing.Point(295, 166);
            this.txtDenNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenNgay.Properties.Appearance.Options.UseFont = true;
            this.txtDenNgay.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay.Properties.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.txtDenNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDenNgay.Size = new System.Drawing.Size(111, 26);
            this.txtDenNgay.TabIndex = 2;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.Location = new System.Drawing.Point(220, 171);
            this.lblDenNgay.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(66, 17);
            this.lblDenNgay.TabIndex = 11;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.Location = new System.Drawing.Point(5, 171);
            this.lblTuNgay.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(58, 17);
            this.lblTuNgay.TabIndex = 12;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblCaLam
            // 
            this.lblCaLam.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaLam.Location = new System.Drawing.Point(6, 206);
            this.lblCaLam.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblCaLam.Name = "lblCaLam";
            this.lblCaLam.Size = new System.Drawing.Size(50, 17);
            this.lblCaLam.TabIndex = 13;
            this.lblCaLam.Text = "Ca làm:";
            // 
            // txtCaLam
            // 
            this.txtCaLam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaLam.Location = new System.Drawing.Point(76, 201);
            this.txtCaLam.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtCaLam.Name = "txtCaLam";
            this.txtCaLam.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txtCaLam.Properties.Appearance.Options.UseFont = true;
            this.txtCaLam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txtCaLam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.txtCaLam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtCaLam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCaLam.Properties.DisplayMember = "ten";
            this.txtCaLam.Properties.NullText = "";
            this.txtCaLam.Properties.PopupSizeable = false;
            this.txtCaLam.Properties.ValueMember = "id";
            this.txtCaLam.Properties.View = this.searchLookUpEdit1View;
            this.txtCaLam.Size = new System.Drawing.Size(330, 26);
            this.txtCaLam.TabIndex = 3;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenCa,
            this.colGioVaoCa,
            this.colGioRaCa,
            this.colSoTienHetCa,
            this.colSoTienTangCa,
            this.gridColumn6});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colTenCa
            // 
            this.colTenCa.Caption = "Tên ca";
            this.colTenCa.FieldName = "ten";
            this.colTenCa.Name = "colTenCa";
            this.colTenCa.Visible = true;
            this.colTenCa.VisibleIndex = 0;
            this.colTenCa.Width = 108;
            // 
            // colGioVaoCa
            // 
            this.colGioVaoCa.Caption = "Giờ vào ca";
            this.colGioVaoCa.FieldName = "tuGio";
            this.colGioVaoCa.Name = "colGioVaoCa";
            this.colGioVaoCa.Visible = true;
            this.colGioVaoCa.VisibleIndex = 1;
            this.colGioVaoCa.Width = 82;
            // 
            // colGioRaCa
            // 
            this.colGioRaCa.Caption = "Giờ ra ca";
            this.colGioRaCa.FieldName = "denGio";
            this.colGioRaCa.Name = "colGioRaCa";
            this.colGioRaCa.Visible = true;
            this.colGioRaCa.VisibleIndex = 2;
            this.colGioRaCa.Width = 72;
            // 
            // colSoTienHetCa
            // 
            this.colSoTienHetCa.Caption = "Số tiếng hết ca";
            this.colSoTienHetCa.FieldName = "soTieng";
            this.colSoTienHetCa.Name = "colSoTienHetCa";
            this.colSoTienHetCa.Visible = true;
            this.colSoTienHetCa.VisibleIndex = 3;
            this.colSoTienHetCa.Width = 83;
            // 
            // colSoTienTangCa
            // 
            this.colSoTienTangCa.Caption = "Số tiếng tăng ca";
            this.colSoTienTangCa.FieldName = "soTiengTinhTangCa";
            this.colSoTienTangCa.Name = "colSoTienTangCa";
            this.colSoTienTangCa.Visible = true;
            this.colSoTienTangCa.VisibleIndex = 4;
            this.colSoTienTangCa.Width = 92;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "id";
            this.gridColumn6.FieldName = "id";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // cmbHeSoLuong
            // 
            this.cmbHeSoLuong.EditValue = "100";
            this.cmbHeSoLuong.Location = new System.Drawing.Point(474, 22);
            this.cmbHeSoLuong.Name = "cmbHeSoLuong";
            this.cmbHeSoLuong.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.cmbHeSoLuong.Properties.Appearance.Options.UseFont = true;
            this.cmbHeSoLuong.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cmbHeSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbHeSoLuong.Properties.DropDownRows = 3;
            this.cmbHeSoLuong.Properties.Items.AddRange(new object[] {
            "100",
            "150",
            "200",
            "300"});
            this.cmbHeSoLuong.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbHeSoLuong.Size = new System.Drawing.Size(92, 26);
            this.cmbHeSoLuong.TabIndex = 27;
            this.cmbHeSoLuong.Visible = false;
            // 
            // lblHeSo
            // 
            this.lblHeSo.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeSo.Location = new System.Drawing.Point(385, 27);
            this.lblHeSo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblHeSo.Name = "lblHeSo";
            this.lblHeSo.Size = new System.Drawing.Size(85, 17);
            this.lblHeSo.TabIndex = 14;
            this.lblHeSo.Text = "Hệ số lương:";
            this.lblHeSo.Visible = false;
            // 
            // dlgDangKyCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 581);
            this.Controls.Add(this.panelControl2);
            this.Form_Description = "Thiết lập ca làm việc cho công nhân viên";
            this.Form_Title = "Đăng ký ca làm việc";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDangKyCaLam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDangKyCaLam_FormClosing);
            this.Load += new System.EventHandler(this.dlgDangKyCaLam_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dlgDangKyCaLam_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaLam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHeSoLuong.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private UC.ucProgress ucProgress1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbHeSoLuong;
        private DevExpress.XtraEditors.DateEdit txtTuNgay;
        private DevExpress.XtraEditors.SimpleButton btnDangKyExcel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.DateEdit txtDenNgay;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.LabelControl lblHeSo;
        private DevExpress.XtraEditors.LabelControl lblCaLam;
        private DevExpress.XtraEditors.SimpleButton btnDangKyDA;
        private DevExpress.XtraEditors.SearchLookUpEdit txtCaLam;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colTenCa;
        private DevExpress.XtraGrid.Columns.GridColumn colGioVaoCa;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTienHetCa;
        private DevExpress.XtraGrid.Columns.GridColumn colGioRaCa;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTienTangCa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}