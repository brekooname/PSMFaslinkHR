namespace iHRM.Win.Frm.Luong_v3
{
    partial class frmDinhNghiaThamSo_ModuleSelect
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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtModule = new DevExpress.XtraEditors.LookUpEdit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModule.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(576, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 22);
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.labelControl8.Location = new System.Drawing.Point(12, 46);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(53, 19);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Module";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(12, 69);
            this.txtModule.Name = "txtModule";
            this.txtModule.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtModule.Properties.Appearance.Options.UseFont = true;
            this.txtModule.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtModule.Properties.AppearanceDropDown.Options.UseFont = true;
            this.txtModule.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtModule.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ten", "Module")});
            this.txtModule.Properties.DisplayMember = "ten";
            this.txtModule.Properties.NullText = "";
            this.txtModule.Properties.PopupSizeable = false;
            this.txtModule.Properties.ValueMember = "id";
            this.txtModule.Size = new System.Drawing.Size(552, 28);
            this.txtModule.TabIndex = 4;
            // 
            // frmDinhNghiaThamSo_ModuleSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 132);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.txtModule);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDinhNghiaThamSo_ModuleSelect";
            this.ShowIcon = false;
            this.Text = "Chọn module";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FormClosed);
            this.Load += new System.EventHandler(this.frm_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModule.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LookUpEdit txtModule;
    }
}