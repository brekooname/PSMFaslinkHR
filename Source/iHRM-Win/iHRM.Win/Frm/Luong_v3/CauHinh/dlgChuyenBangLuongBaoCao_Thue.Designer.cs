namespace iHRM.Win.Frm.Luong_v3
{
    partial class dlgChuyenBangLuongBaoCao_Thue
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
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_TsLuong = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt_TsThue = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtThangLuong = new DevExpress.XtraEditors.DateEdit();
            this.txt_ThangThue = new DevExpress.XtraEditors.DateEdit();
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TsLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TsThue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThangLuong.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThangLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ThangThue.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ThangThue.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(406, 48);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(108, 17);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "Tháng tính thuế:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(8, 47);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(169, 17);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "Tháng tính lương báo cáo:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(22, 87);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(155, 17);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Tham số lương báo cáo:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(420, 88);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 17);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "Tham số thuế:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(104, 8);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 17);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Phòng ban:";
            // 
            // txt_TsLuong
            // 
            this.txt_TsLuong.Location = new System.Drawing.Point(187, 84);
            this.txt_TsLuong.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txt_TsLuong.Name = "txt_TsLuong";
            this.txt_TsLuong.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txt_TsLuong.Properties.Appearance.Options.UseFont = true;
            this.txt_TsLuong.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txt_TsLuong.Properties.AppearanceDropDown.Options.UseFont = true;
            this.txt_TsLuong.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txt_TsLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_TsLuong.Properties.DisplayMember = "ten";
            this.txt_TsLuong.Properties.NullText = "";
            this.txt_TsLuong.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txt_TsLuong.Properties.PopupSizeable = false;
            this.txt_TsLuong.Properties.ValueMember = "tsIdx";
            this.txt_TsLuong.Properties.View = this.searchLookUpEdit1View;
            this.txt_TsLuong.Size = new System.Drawing.Size(197, 26);
            this.txt_TsLuong.TabIndex = 16;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ts";
            this.gridColumn1.FieldName = "tsIdx";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 212;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên";
            this.gridColumn2.FieldName = "ten";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 1404;
            // 
            // txt_TsThue
            // 
            this.txt_TsThue.Location = new System.Drawing.Point(520, 84);
            this.txt_TsThue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txt_TsThue.Name = "txt_TsThue";
            this.txt_TsThue.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txt_TsThue.Properties.Appearance.Options.UseFont = true;
            this.txt_TsThue.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txt_TsThue.Properties.AppearanceDropDown.Options.UseFont = true;
            this.txt_TsThue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txt_TsThue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_TsThue.Properties.DisplayMember = "ten";
            this.txt_TsThue.Properties.NullText = "";
            this.txt_TsThue.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txt_TsThue.Properties.PopupSizeable = false;
            this.txt_TsThue.Properties.ValueMember = "tsIdx";
            this.txt_TsThue.Properties.View = this.gridView1;
            this.txt_TsThue.Size = new System.Drawing.Size(197, 26);
            this.txt_TsThue.TabIndex = 21;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ts";
            this.gridColumn3.FieldName = "tsIdx";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 201;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tên";
            this.gridColumn4.FieldName = "ten";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 1415;
            // 
            // txtThangLuong
            // 
            this.txtThangLuong.EditValue = null;
            this.txtThangLuong.Location = new System.Drawing.Point(187, 48);
            this.txtThangLuong.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtThangLuong.Name = "txtThangLuong";
            this.txtThangLuong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtThangLuong.Properties.Appearance.Options.UseFont = true;
            this.txtThangLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtThangLuong.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtThangLuong.Properties.DisplayFormat.FormatString = "MM - yyyy";
            this.txtThangLuong.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtThangLuong.Properties.Mask.EditMask = "MM - yyyy";
            this.txtThangLuong.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.txtThangLuong.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.txtThangLuong.Size = new System.Drawing.Size(197, 22);
            this.txtThangLuong.TabIndex = 25;
            // 
            // txt_ThangThue
            // 
            this.txt_ThangThue.EditValue = null;
            this.txt_ThangThue.Location = new System.Drawing.Point(520, 48);
            this.txt_ThangThue.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txt_ThangThue.Name = "txt_ThangThue";
            this.txt_ThangThue.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txt_ThangThue.Properties.Appearance.Options.UseFont = true;
            this.txt_ThangThue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_ThangThue.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_ThangThue.Properties.DisplayFormat.FormatString = "MM - yyyy";
            this.txt_ThangThue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txt_ThangThue.Properties.Mask.EditMask = "MM - yyyy";
            this.txt_ThangThue.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.txt_ThangThue.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.txt_ThangThue.Size = new System.Drawing.Size(197, 22);
            this.txt_ThangThue.TabIndex = 26;
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.chonPhongBan1.Location = new System.Drawing.Point(187, 8);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(197, 28);
            this.chonPhongBan1.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(326, 128);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 35);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Hút dữ liệu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dlgChuyenBangLuongBaoCao_Thue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 184);
            this.Controls.Add(this.txt_ThangThue);
            this.Controls.Add(this.txtThangLuong);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.chonPhongBan1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txt_TsLuong);
            this.Controls.Add(this.txt_TsThue);
            this.Name = "dlgChuyenBangLuongBaoCao_Thue";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển tham số lương báo cáo sang thuế";
            this.Load += new System.EventHandler(this.EvaluatorEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_TsLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TsThue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThangLuong.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThangLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ThangThue.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ThangThue.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private UC.ChonPhongBan chonPhongBan1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SearchLookUpEdit txt_TsLuong;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit txt_TsThue;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.DateEdit txtThangLuong;
        private DevExpress.XtraEditors.DateEdit txt_ThangThue;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;

    }
}