namespace iHRM.Win.Frm.Employee
{
    partial class impEmpBankAcc
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
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(704, 65);
            // 
            // impEmpBankAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 356);
            this.Form_Description = "Nhập tài khoản ngân hàng cho nhân viên";
            this.Form_Title = "Import STK ngân hàng";
            this.Name = "impEmpBankAcc";
            this.Text = "Nhập tài khoản ngân hàng nhân viên theo file";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.impNhapBaoHiem_FormClosing);
            this.Load += new System.EventHandler(this.impDataTinhLuong_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}