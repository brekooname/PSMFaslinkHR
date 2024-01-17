namespace iHRM.Win.Frm.Luong_v3
{
    partial class dlgChuyenNhomHL_NV
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
            this.lblNomHT = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblDSNV = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtDSNV = new DevExpress.XtraEditors.MemoEdit();
            this.txt_NhomHL = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_NhomHLChuyen = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NhomHL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NhomHLChuyen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomHT
            // 
            this.lblNomHT.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomHT.Location = new System.Drawing.Point(55, 92);
            this.lblNomHT.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblNomHT.Name = "lblNomHT";
            this.lblNomHT.Size = new System.Drawing.Size(96, 17);
            this.lblNomHT.TabIndex = 19;
            this.lblNomHT.Text = "Nhóm hiện tại:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(356, 92);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 17);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "Nhóm chuyển: ";
            // 
            // lblDSNV
            // 
            this.lblDSNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDSNV.Location = new System.Drawing.Point(12, 10);
            this.lblDSNV.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblDSNV.Name = "lblDSNV";
            this.lblDSNV.Size = new System.Drawing.Size(139, 17);
            this.lblDSNV.TabIndex = 23;
            this.lblDSNV.Text = "Danh sách nhân viên:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(272, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 35);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Chuyển dữ liệu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDSNV
            // 
            this.txtDSNV.Location = new System.Drawing.Point(157, 8);
            this.txtDSNV.Name = "txtDSNV";
            this.txtDSNV.Properties.ReadOnly = true;
            this.txtDSNV.Size = new System.Drawing.Size(466, 73);
            this.txtDSNV.TabIndex = 25;
            // 
            // txt_NhomHL
            // 
            this.txt_NhomHL.Location = new System.Drawing.Point(157, 89);
            this.txt_NhomHL.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txt_NhomHL.Name = "txt_NhomHL";
            this.txt_NhomHL.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txt_NhomHL.Properties.Appearance.Options.UseFont = true;
            this.txt_NhomHL.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txt_NhomHL.Properties.AppearanceDropDown.Options.UseFont = true;
            this.txt_NhomHL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txt_NhomHL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_NhomHL.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ten", "Tên nhóm")});
            this.txt_NhomHL.Properties.DisplayMember = "ten";
            this.txt_NhomHL.Properties.ImmediatePopup = true;
            this.txt_NhomHL.Properties.NullText = "Chọn nhóm hưởng lương";
            this.txt_NhomHL.Properties.PopupSizeable = false;
            this.txt_NhomHL.Properties.ReadOnly = true;
            this.txt_NhomHL.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txt_NhomHL.Properties.ValueMember = "id";
            this.txt_NhomHL.Size = new System.Drawing.Size(163, 26);
            this.txt_NhomHL.TabIndex = 16;
            // 
            // txt_NhomHLChuyen
            // 
            this.txt_NhomHLChuyen.Location = new System.Drawing.Point(460, 89);
            this.txt_NhomHLChuyen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txt_NhomHLChuyen.Name = "txt_NhomHLChuyen";
            this.txt_NhomHLChuyen.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txt_NhomHLChuyen.Properties.Appearance.Options.UseFont = true;
            this.txt_NhomHLChuyen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.txt_NhomHLChuyen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.txt_NhomHLChuyen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txt_NhomHLChuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_NhomHLChuyen.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ten", "Tên nhóm")});
            this.txt_NhomHLChuyen.Properties.DisplayMember = "ten";
            this.txt_NhomHLChuyen.Properties.NullText = "Chọn nhóm hưởng lương";
            this.txt_NhomHLChuyen.Properties.PopupSizeable = false;
            this.txt_NhomHLChuyen.Properties.ValueMember = "id";
            this.txt_NhomHLChuyen.Size = new System.Drawing.Size(163, 26);
            this.txt_NhomHLChuyen.TabIndex = 26;
            // 
            // dlgChuyenNhomHL_NV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 176);
            this.Controls.Add(this.txtDSNV);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDSNV);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblNomHT);
            this.Controls.Add(this.txt_NhomHL);
            this.Controls.Add(this.txt_NhomHLChuyen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dlgChuyenNhomHL_NV";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển nhóm hưởng lương nhân viên";
            this.Load += new System.EventHandler(this.EvaluatorEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDSNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NhomHL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NhomHLChuyen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblNomHT;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblDSNV;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.MemoEdit txtDSNV;
        private DevExpress.XtraEditors.LookUpEdit txt_NhomHL;
        private DevExpress.XtraEditors.LookUpEdit txt_NhomHLChuyen;

    }
}