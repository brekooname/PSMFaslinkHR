namespace iHRM.Win.Frm.QuetThe
{
    partial class dlgLyDoDuyet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgLyDoDuyet));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.butClosed = new DevExpress.XtraEditors.SimpleButton();
            this.butAgree = new DevExpress.XtraEditors.SimpleButton();
            this.txtReason = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(581, 70);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 70);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(581, 185);
            this.panelControl2.TabIndex = 5;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.butClosed);
            this.panelControl4.Controls.Add(this.butAgree);
            this.panelControl4.Controls.Add(this.txtReason);
            this.panelControl4.Controls.Add(this.labelControl3);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(581, 184);
            this.panelControl4.TabIndex = 28;
            // 
            // butClosed
            // 
            this.butClosed.Image = ((System.Drawing.Image)(resources.GetObject("butClosed.Image")));
            this.butClosed.Location = new System.Drawing.Point(487, 150);
            this.butClosed.Name = "butClosed";
            this.butClosed.Size = new System.Drawing.Size(82, 27);
            this.butClosed.TabIndex = 1019;
            this.butClosed.Text = "Thoát";
            this.butClosed.Click += new System.EventHandler(this.butClosed_Click);
            // 
            // butAgree
            // 
            this.butAgree.Image = ((System.Drawing.Image)(resources.GetObject("butAgree.Image")));
            this.butAgree.Location = new System.Drawing.Point(406, 150);
            this.butAgree.Name = "butAgree";
            this.butAgree.Size = new System.Drawing.Size(80, 27);
            this.butAgree.TabIndex = 1018;
            this.butAgree.Text = "Đồng ý";
            this.butAgree.Click += new System.EventHandler(this.butAgree_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(3, 30);
            this.txtReason.Name = "txtReason";
            this.txtReason.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Azure;
            this.txtReason.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtReason.Size = new System.Drawing.Size(566, 114);
            this.txtReason.TabIndex = 1017;
            this.txtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReason_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(12, 10);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(114, 17);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Nhập lý do duyệt:";
            // 
            // dlgLyDoDuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 255);
            this.Controls.Add(this.panelControl2);
            this.Form_Description = "Nhập lý do Duyệt, Không duyệt";
            this.Form_Image = global::iHRM.Win.Properties.Resources.bg_edit;
            this.Form_Title = "Lý do duyệt";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgLyDoDuyet";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgLyDoDuyet_FormClosing);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton butClosed;
        private DevExpress.XtraEditors.SimpleButton butAgree;
        private DevExpress.XtraEditors.MemoEdit txtReason;
    }
}