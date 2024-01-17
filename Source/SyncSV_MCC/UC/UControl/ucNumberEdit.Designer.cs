namespace SyncSV.UC.UControl
{
    partial class ucNumberEdit
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
            this.edit1 = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edit1
            // 
            this.edit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit1.Location = new System.Drawing.Point(108, 0);
            this.edit1.Name = "edit1";
            this.edit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edit1.Properties.DisplayFormat.FormatString = "#,0";
            this.edit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edit1.Properties.EditFormat.FormatString = "#,0";
            this.edit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.edit1.Size = new System.Drawing.Size(155, 20);
            this.edit1.TabIndex = 1;
            // 
            // ucNumberEdit
            // 
            this.Controls.Add(this.edit1);
            this.Name = "ucNumberEdit";
            this.Size = new System.Drawing.Size(263, 20);
            this.Controls.SetChildIndex(this.edit1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CalcEdit edit1;

    }
}
