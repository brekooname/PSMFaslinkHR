namespace SyncSV.UC.UControl
{
    partial class ucPictureEdit
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
            this.edit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.labelControl1.Location = new System.Drawing.Point(1, 1);
            this.labelControl1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.labelControl1.Size = new System.Drawing.Size(73, 19);
            // 
            // edit1
            // 
            this.edit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit1.Location = new System.Drawing.Point(0, 0);
            this.edit1.Name = "edit1";
            this.edit1.Properties.NullText = "Click đúp để chọn ảnh...";
            this.edit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            this.edit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.edit1.Size = new System.Drawing.Size(209, 93);
            this.edit1.TabIndex = 1;
            this.edit1.TabStop = true;
            this.edit1.DoubleClick += new System.EventHandler(this.edit1_DoubleClick);
            // 
            // ucPictureEdit
            // 
            this.Controls.Add(this.edit1);
            this.Name = "ucPictureEdit";
            this.Size = new System.Drawing.Size(209, 93);
            this.Controls.SetChildIndex(this.edit1, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit edit1;

    }
}
