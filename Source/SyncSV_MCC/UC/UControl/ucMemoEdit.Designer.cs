namespace SyncSV.UC.UControl
{
    partial class ucMemoEdit
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
            this.edit1 = new DevExpress.XtraEditors.MemoExEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.edit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit1.Location = new System.Drawing.Point(108, 0);
            this.edit1.Name = "textEdit1";
            this.edit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edit1.Size = new System.Drawing.Size(155, 20);
            this.edit1.TabIndex = 1;
            // 
            // ucMemoEdit
            // 
            this.Controls.Add(this.edit1);
            this.Name = "ucMemoEdit";
            this.Size = new System.Drawing.Size(263, 20);
            this.Controls.SetChildIndex(this.edit1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoExEdit edit1;


    }
}
