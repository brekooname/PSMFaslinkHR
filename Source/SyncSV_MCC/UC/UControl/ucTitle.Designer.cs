namespace SyncSV.UC.UControl
{
    partial class ucTitle
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
            components = new System.ComponentModel.Container();

            ///////
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.Text = "Chọn dữ liệu...";
        }

        #endregion
    }
}
