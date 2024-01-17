namespace iHRM.Win.Frm.TuyenDung
{
    partial class frmKeHoachTuyenDung
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cboNam = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboViTriTuyenDung = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPosID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboPhongBan = new iHRM.Win.UC.ChonPhongBan();
            this.lblVitriTD = new DevExpress.XtraEditors.LabelControl();
            this.lblPB = new DevExpress.XtraEditors.LabelControl();
            this.lblNam = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVitri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhichu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.pageNavigator1 = new iHRM.Win.UC.PageNavigator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnThemNV = new System.Windows.Forms.ToolStripButton();
            this.toolExcel = new System.Windows.Forms.ToolStripButton();
            this.toolCapNhat = new System.Windows.Forms.ToolStripButton();
            this.toolXoa = new System.Windows.Forms.ToolStripButton();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboViTriTuyenDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cboNam);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboViTriTuyenDung);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboPhongBan);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblVitriTD);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPB);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblNam);
            this.splitContainerControl1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grd);
            this.splitContainerControl1.Panel2.Controls.Add(this.pageNavigator1);
            this.splitContainerControl1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1362, 532);
            this.splitContainerControl1.SplitterPosition = 206;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // cboNam
            // 
            this.cboNam.Location = new System.Drawing.Point(5, 84);
            this.cboNam.Name = "cboNam";
            this.cboNam.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.Properties.Appearance.Options.UseFont = true;
            this.cboNam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cboNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNam.Size = new System.Drawing.Size(140, 26);
            this.cboNam.TabIndex = 51;
            // 
            // cboViTriTuyenDung
            // 
            this.cboViTriTuyenDung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboViTriTuyenDung.EditValue = "";
            this.cboViTriTuyenDung.Location = new System.Drawing.Point(5, 191);
            this.cboViTriTuyenDung.Name = "cboViTriTuyenDung";
            this.cboViTriTuyenDung.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboViTriTuyenDung.Properties.Appearance.Options.UseFont = true;
            this.cboViTriTuyenDung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboViTriTuyenDung.Properties.DisplayMember = "PosName";
            this.cboViTriTuyenDung.Properties.NullText = "";
            this.cboViTriTuyenDung.Properties.ValueMember = "PosID";
            this.cboViTriTuyenDung.Properties.View = this.searchLookUpEdit1View;
            this.cboViTriTuyenDung.Size = new System.Drawing.Size(200, 24);
            this.cboViTriTuyenDung.TabIndex = 47;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPosID,
            this.colPosName});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colPosID
            // 
            this.colPosID.Caption = "ID";
            this.colPosID.FieldName = "PosID";
            this.colPosID.Name = "colPosID";
            this.colPosID.Visible = true;
            this.colPosID.VisibleIndex = 0;
            this.colPosID.Width = 79;
            // 
            // colPosName
            // 
            this.colPosName.Caption = "Name";
            this.colPosName.FieldName = "PosName";
            this.colPosName.Name = "colPosName";
            this.colPosName.Visible = true;
            this.colPosName.VisibleIndex = 1;
            this.colPosName.Width = 617;
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPhongBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPhongBan.Location = new System.Drawing.Point(5, 134);
            this.cboPhongBan.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.SelectedValue = null;
            this.cboPhongBan.Size = new System.Drawing.Size(200, 28);
            this.cboPhongBan.TabIndex = 10;
            // 
            // lblVitriTD
            // 
            this.lblVitriTD.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.lblVitriTD.Location = new System.Drawing.Point(5, 168);
            this.lblVitriTD.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblVitriTD.Name = "lblVitriTD";
            this.lblVitriTD.Size = new System.Drawing.Size(122, 20);
            this.lblVitriTD.TabIndex = 3;
            this.lblVitriTD.Text = "Vị trí tuyển dụng";
            // 
            // lblPB
            // 
            this.lblPB.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.lblPB.Location = new System.Drawing.Point(5, 115);
            this.lblPB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(73, 19);
            this.lblPB.TabIndex = 3;
            this.lblPB.Text = "Phòng Ban";
            // 
            // lblNam
            // 
            this.lblNam.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.lblNam.Location = new System.Drawing.Point(5, 62);
            this.lblNam.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(32, 19);
            this.lblNam.TabIndex = 3;
            this.lblNam.Text = "Năm";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(206, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(85, 23);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 27);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.grd.Size = new System.Drawing.Size(1151, 476);
            this.grd.TabIndex = 5;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.EvenRow.BackColor = System.Drawing.Color.LemonChiffon;
            this.grv.Appearance.EvenRow.BackColor2 = System.Drawing.Color.LemonChiffon;
            this.grv.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grv.Appearance.EvenRow.Options.UseBackColor = true;
            this.grv.Appearance.EvenRow.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv.Appearance.OddRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grv.Appearance.OddRow.BackColor2 = System.Drawing.Color.AliceBlue;
            this.grv.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grv.Appearance.OddRow.Options.UseBackColor = true;
            this.grv.Appearance.OddRow.Options.UseFont = true;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grv.Appearance.SelectedRow.Options.UseFont = true;
            this.grv.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GreenYellow;
            this.grv.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grv.AppearancePrint.EvenRow.Options.UseBackColor = true;
            this.grv.AppearancePrint.OddRow.BackColor = System.Drawing.Color.Khaki;
            this.grv.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colPB,
            this.colVitri,
            this.colT1,
            this.colT2,
            this.colT3,
            this.colT4,
            this.colT5,
            this.colT6,
            this.colT7,
            this.colT8,
            this.colT9,
            this.colT10,
            this.colT11,
            this.colT12,
            this.colGhichu});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.EnableAppearanceEvenRow = true;
            this.grv.OptionsView.EnableAppearanceOddRow = true;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.RowHeight = 26;
            this.grv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grv_KeyDown);
            // 
            // colSTT
            // 
            this.colSTT.AppearanceCell.Options.UseTextOptions = true;
            this.colSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "RowNum";
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 52;
            // 
            // colPB
            // 
            this.colPB.Caption = "Phòng ban";
            this.colPB.FieldName = "DepName";
            this.colPB.Name = "colPB";
            this.colPB.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colPB.Visible = true;
            this.colPB.VisibleIndex = 1;
            this.colPB.Width = 165;
            // 
            // colVitri
            // 
            this.colVitri.Caption = "Vị trí";
            this.colVitri.FieldName = "PosName";
            this.colVitri.Name = "colVitri";
            this.colVitri.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVitri.Visible = true;
            this.colVitri.VisibleIndex = 2;
            this.colVitri.Width = 216;
            // 
            // colT1
            // 
            this.colT1.AppearanceCell.Options.UseTextOptions = true;
            this.colT1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT1.Caption = "T1";
            this.colT1.FieldName = "SLT1";
            this.colT1.Name = "colT1";
            this.colT1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT1.Visible = true;
            this.colT1.VisibleIndex = 3;
            // 
            // colT2
            // 
            this.colT2.AppearanceCell.Options.UseTextOptions = true;
            this.colT2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT2.Caption = "T2";
            this.colT2.FieldName = "SLT2";
            this.colT2.Name = "colT2";
            this.colT2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT2.Visible = true;
            this.colT2.VisibleIndex = 4;
            // 
            // colT3
            // 
            this.colT3.AppearanceCell.Options.UseTextOptions = true;
            this.colT3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT3.Caption = "T3";
            this.colT3.FieldName = "SLT3";
            this.colT3.Name = "colT3";
            this.colT3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT3.Visible = true;
            this.colT3.VisibleIndex = 5;
            // 
            // colT4
            // 
            this.colT4.AppearanceCell.Options.UseTextOptions = true;
            this.colT4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT4.Caption = "T4";
            this.colT4.FieldName = "SLT4";
            this.colT4.Name = "colT4";
            this.colT4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT4.Visible = true;
            this.colT4.VisibleIndex = 6;
            // 
            // colT5
            // 
            this.colT5.AppearanceCell.Options.UseTextOptions = true;
            this.colT5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT5.Caption = "T5";
            this.colT5.FieldName = "SLT5";
            this.colT5.Name = "colT5";
            this.colT5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT5.Visible = true;
            this.colT5.VisibleIndex = 7;
            // 
            // colT6
            // 
            this.colT6.AppearanceCell.Options.UseTextOptions = true;
            this.colT6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT6.Caption = "T6";
            this.colT6.FieldName = "SLT6";
            this.colT6.Name = "colT6";
            this.colT6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT6.Visible = true;
            this.colT6.VisibleIndex = 8;
            // 
            // colT7
            // 
            this.colT7.AppearanceCell.Options.UseTextOptions = true;
            this.colT7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT7.Caption = "T7";
            this.colT7.FieldName = "SLT7";
            this.colT7.Name = "colT7";
            this.colT7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT7.Visible = true;
            this.colT7.VisibleIndex = 9;
            // 
            // colT8
            // 
            this.colT8.AppearanceCell.Options.UseTextOptions = true;
            this.colT8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT8.Caption = "T8";
            this.colT8.FieldName = "SLT8";
            this.colT8.Name = "colT8";
            this.colT8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT8.Visible = true;
            this.colT8.VisibleIndex = 10;
            // 
            // colT9
            // 
            this.colT9.AppearanceCell.Options.UseTextOptions = true;
            this.colT9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT9.Caption = "T9";
            this.colT9.FieldName = "SLT9";
            this.colT9.Name = "colT9";
            this.colT9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT9.Visible = true;
            this.colT9.VisibleIndex = 11;
            // 
            // colT10
            // 
            this.colT10.AppearanceCell.Options.UseTextOptions = true;
            this.colT10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT10.Caption = "T10";
            this.colT10.FieldName = "SLT10";
            this.colT10.Name = "colT10";
            this.colT10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT10.Visible = true;
            this.colT10.VisibleIndex = 12;
            // 
            // colT11
            // 
            this.colT11.AppearanceCell.Options.UseTextOptions = true;
            this.colT11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT11.Caption = "T11";
            this.colT11.FieldName = "SLT11";
            this.colT11.Name = "colT11";
            this.colT11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT11.Visible = true;
            this.colT11.VisibleIndex = 13;
            // 
            // colT12
            // 
            this.colT12.AppearanceCell.Options.UseTextOptions = true;
            this.colT12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT12.Caption = "T12";
            this.colT12.FieldName = "SLT12";
            this.colT12.Name = "colT12";
            this.colT12.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colT12.Visible = true;
            this.colT12.VisibleIndex = 14;
            // 
            // colGhichu
            // 
            this.colGhichu.Caption = "Ghi chú";
            this.colGhichu.FieldName = "GhiChu";
            this.colGhichu.Name = "colGhichu";
            this.colGhichu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGhichu.Visible = true;
            this.colGhichu.VisibleIndex = 15;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.EditFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // pageNavigator1
            // 
            this.pageNavigator1.CurrentPage = 1;
            this.pageNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageNavigator1.Location = new System.Drawing.Point(0, 503);
            this.pageNavigator1.MaximumSize = new System.Drawing.Size(4000, 29);
            this.pageNavigator1.MinimumSize = new System.Drawing.Size(400, 29);
            this.pageNavigator1.Name = "pageNavigator1";
            this.pageNavigator1.PageSize = 10;
            this.pageNavigator1.RecordCount = 0;
            this.pageNavigator1.Size = new System.Drawing.Size(1151, 29);
            this.pageNavigator1.TabIndex = 4;
            this.pageNavigator1.OnPageChange += new System.EventHandler(this.pageNavigator1_OnPageChange);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemNV,
            this.toolExcel,
            this.toolCapNhat,
            this.toolXoa});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1151, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnThemNV
            // 
            this.btnThemNV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNV.Image = global::iHRM.Win.Properties.Resources.ico20_new;
            this.btnThemNV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnThemNV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(67, 24);
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click_Click);
            // 
            // toolExcel
            // 
            this.toolExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolExcel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolExcel.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExcel.Name = "toolExcel";
            this.toolExcel.Size = new System.Drawing.Size(62, 24);
            this.toolExcel.Text = "Excel";
            this.toolExcel.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolCapNhat
            // 
            this.toolCapNhat.Image = global::iHRM.Win.Properties.Resources.btnEdit_Image;
            this.toolCapNhat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCapNhat.Name = "toolCapNhat";
            this.toolCapNhat.Size = new System.Drawing.Size(84, 24);
            this.toolCapNhat.Text = "Cập nhật";
            this.toolCapNhat.Click += new System.EventHandler(this.toolStripButton3_Click_1);
            // 
            // toolXoa
            // 
            this.toolXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolXoa.Image = global::iHRM.Win.Properties.Resources.ico20_delete;
            this.toolXoa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolXoa.Name = "toolXoa";
            this.toolXoa.Size = new System.Drawing.Size(79, 24);
            this.toolXoa.Text = "Xóa bỏ";
            this.toolXoa.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // frmKeHoachTuyenDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 532);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "frmKeHoachTuyenDung";
            this.ShowIcon = false;
            this.Text = "Kế hoạch tuyển dụng";
            this.Load += new System.EventHandler(this.frmKeHoachTuyenDung_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKeHoachTuyenDung_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboViTriTuyenDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnThemNV;
        private System.Windows.Forms.ToolStripButton toolExcel;
        private System.Windows.Forms.ToolStripButton toolXoa;
        private UC.PageNavigator pageNavigator1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraEditors.LabelControl lblNam;
        private UC.ChonPhongBan cboPhongBan;
        private DevExpress.XtraEditors.LabelControl lblVitriTD;
        private DevExpress.XtraEditors.LabelControl lblPB;
        private DevExpress.XtraEditors.SearchLookUpEdit cboViTriTuyenDung;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.ToolStripButton toolCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colPosID;
        private DevExpress.XtraGrid.Columns.GridColumn colPosName;
        private DevExpress.XtraEditors.ComboBoxEdit cboNam;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colPB;
        private DevExpress.XtraGrid.Columns.GridColumn colVitri;
        private DevExpress.XtraGrid.Columns.GridColumn colT1;
        private DevExpress.XtraGrid.Columns.GridColumn colT2;
        private DevExpress.XtraGrid.Columns.GridColumn colT3;
        private DevExpress.XtraGrid.Columns.GridColumn colT4;
        private DevExpress.XtraGrid.Columns.GridColumn colT5;
        private DevExpress.XtraGrid.Columns.GridColumn colT6;
        private DevExpress.XtraGrid.Columns.GridColumn colT7;
        private DevExpress.XtraGrid.Columns.GridColumn colT8;
        private DevExpress.XtraGrid.Columns.GridColumn colT9;
        private DevExpress.XtraGrid.Columns.GridColumn colT10;
        private DevExpress.XtraGrid.Columns.GridColumn colT11;
        private DevExpress.XtraGrid.Columns.GridColumn colT12;
        private DevExpress.XtraGrid.Columns.GridColumn colGhichu;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}