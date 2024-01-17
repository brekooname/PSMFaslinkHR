namespace iHRM.Win.Frm.QuetThe
{
    partial class dlgDangKyCa7h
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ucProgress1 = new iHRM.Win.UC.ucProgress();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.chkisLate = new DevExpress.XtraEditors.CheckEdit();
            this.lblchkDimuon = new DevExpress.XtraEditors.LabelControl();
            this.dateChild = new DevExpress.XtraEditors.DateEdit();
            this.lblChild = new DevExpress.XtraEditors.LabelControl();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblEnd = new DevExpress.XtraEditors.LabelControl();
            this.lblBegin = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkisLate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChild.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChild.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
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
            this.panelControl2.Controls.Add(this.ucProgress1);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 70);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(581, 385);
            this.panelControl2.TabIndex = 5;
            // 
            // ucProgress1
            // 
            this.ucProgress1.CurrentValue = 0;
            this.ucProgress1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProgress1.Location = new System.Drawing.Point(0, 244);
            this.ucProgress1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucProgress1.Message = "";
            this.ucProgress1.Name = "ucProgress1";
            this.ucProgress1.Size = new System.Drawing.Size(581, 141);
            this.ucProgress1.Status = "Đang đăng ký 30/100";
            this.ucProgress1.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.chkisLate);
            this.panelControl4.Controls.Add(this.lblchkDimuon);
            this.panelControl4.Controls.Add(this.dateChild);
            this.panelControl4.Controls.Add(this.lblChild);
            this.panelControl4.Controls.Add(this.ucChonDoiTuong_DS1);
            this.panelControl4.Controls.Add(this.dateBegin);
            this.panelControl4.Controls.Add(this.btnSave);
            this.panelControl4.Controls.Add(this.dateEnd);
            this.panelControl4.Controls.Add(this.lblEnd);
            this.panelControl4.Controls.Add(this.lblBegin);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(581, 244);
            this.panelControl4.TabIndex = 28;
            // 
            // chkisLate
            // 
            this.chkisLate.Location = new System.Drawing.Point(323, 208);
            this.chkisLate.Name = "chkisLate";
            this.chkisLate.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkisLate.Properties.Appearance.Options.UseFont = true;
            this.chkisLate.Properties.Caption = "Đi muộn";
            this.chkisLate.Size = new System.Drawing.Size(75, 21);
            this.chkisLate.TabIndex = 16;
            // 
            // lblchkDimuon
            // 
            this.lblchkDimuon.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchkDimuon.Location = new System.Drawing.Point(270, 209);
            this.lblchkDimuon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblchkDimuon.Name = "lblchkDimuon";
            this.lblchkDimuon.Size = new System.Drawing.Size(52, 17);
            this.lblchkDimuon.TabIndex = 15;
            this.lblchkDimuon.Text = "Check: ";
            // 
            // dateChild
            // 
            this.dateChild.EditValue = null;
            this.dateChild.Location = new System.Drawing.Point(106, 206);
            this.dateChild.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dateChild.Name = "dateChild";
            this.dateChild.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateChild.Properties.Appearance.Options.UseFont = true;
            this.dateChild.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dateChild.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateChild.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateChild.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateChild.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateChild.Properties.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.dateChild.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dateChild.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateChild.Size = new System.Drawing.Size(110, 26);
            this.dateChild.TabIndex = 13;
            // 
            // lblChild
            // 
            this.lblChild.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChild.Location = new System.Drawing.Point(5, 210);
            this.lblChild.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblChild.Name = "lblChild";
            this.lblChild.Size = new System.Drawing.Size(96, 17);
            this.lblChild.TabIndex = 14;
            this.lblChild.Text = "Ngày sinh con:";
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(0, 0);
            this.ucChonDoiTuong_DS1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(581, 158);
            this.ucChonDoiTuong_DS1.TabIndex = 0;
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(106, 166);
            this.dateBegin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBegin.Properties.Appearance.Options.UseFont = true;
            this.dateBegin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateBegin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBegin.Properties.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.dateBegin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dateBegin.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateBegin.Size = new System.Drawing.Size(110, 26);
            this.dateBegin.TabIndex = 1;
            this.dateBegin.Leave += new System.EventHandler(this.txtTuNgay_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(446, 164);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(323, 166);
            this.dateEnd.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEnd.Properties.Appearance.Options.UseFont = true;
            this.dateEnd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEnd.Properties.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.dateEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dateEnd.Size = new System.Drawing.Size(111, 26);
            this.dateEnd.TabIndex = 2;
            // 
            // lblEnd
            // 
            this.lblEnd.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(224, 169);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(96, 17);
            this.lblEnd.TabIndex = 11;
            this.lblEnd.Text = "Ngày kết thúc:";
            // 
            // lblBegin
            // 
            this.lblBegin.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBegin.Location = new System.Drawing.Point(12, 171);
            this.lblBegin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblBegin.Name = "lblBegin";
            this.lblBegin.Size = new System.Drawing.Size(89, 17);
            this.lblBegin.TabIndex = 12;
            this.lblBegin.Text = "Ngày bắt đầu:";
            // 
            // dlgDangKyCa7h
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 455);
            this.Controls.Add(this.panelControl2);
            this.Form_Description = "Thiết lập ca làm việc 7 giờ cho công nhân viên";
            this.Form_Title = "Đăng ký ca làm 7 giờ";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDangKyCa7h";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDangKyCa7h_FormClosing);
            this.Load += new System.EventHandler(this.dlgDangKyCa7h_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dlgDangKyCa7h_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkisLate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChild.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateChild.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private UC.ucProgress ucProgress1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.LabelControl lblEnd;
        private DevExpress.XtraEditors.LabelControl lblBegin;
        private DevExpress.XtraEditors.DateEdit dateChild;
        private DevExpress.XtraEditors.LabelControl lblChild;
        private DevExpress.XtraEditors.LabelControl lblchkDimuon;
        private DevExpress.XtraEditors.CheckEdit chkisLate;
    }
}