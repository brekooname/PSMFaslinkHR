namespace iHRM.Win.Frm.Employee
{
    partial class impEmployee_Child
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
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.txtFilePath.Properties.Appearance.Options.UseFont = true;
            this.txtFilePath.Size = new System.Drawing.Size(471, 24);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(596, 133);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(592, 129);
            // 
            // prg
            // 
            this.prg.Size = new System.Drawing.Size(596, 18);
            // 
            // wizardControl1
            // 
            this.wizardControl1.Size = new System.Drawing.Size(704, 356);
            this.wizardControl1.Controls.SetChildIndex(this.wizardPage2, 0);
            this.wizardControl1.Controls.SetChildIndex(this.wizardPage1, 0);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Size = new System.Drawing.Size(672, 211);
            // 
            // wizardPage2
            // 
            this.wizardPage2.Size = new System.Drawing.Size(672, 211);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            // 
            // btnImport
            // 
            this.btnImport.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Location = new System.Drawing.Point(512, 20);
            // 
            // impEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 356);
            this.Name = "impEmployee_PC";
            this.ShowIcon = false;
            this.Text = "Nhập thông tin của nhân viên từ excel";
            this.Load += new System.EventHandler(this.impEmployee_Child_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}