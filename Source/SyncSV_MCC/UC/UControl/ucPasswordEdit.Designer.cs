namespace SyncSV.UC.UControl
{
    partial class ucPasswordEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPasswordEdit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edit2 = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.edit1 = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edit2.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edit2
            // 
            this.edit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit2.Location = new System.Drawing.Point(188, 0);
            this.edit2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.edit2.Name = "edit2";
            this.edit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.edit2.Properties.Appearance.Options.UseFont = true;
            this.edit2.Properties.PasswordChar = '■';
            this.edit2.Size = new System.Drawing.Size(183, 20);
            this.edit2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.edit2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.edit1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(108, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(371, 20);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // edit1
            // 
            this.edit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit1.Location = new System.Drawing.Point(0, 0);
            this.edit1.Margin = new System.Windows.Forms.Padding(0);
            this.edit1.Name = "edit1";
            this.edit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("edit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.edit1.Properties.PasswordChar = '■';
            this.edit1.Size = new System.Drawing.Size(185, 22);
            this.edit1.TabIndex = 0;
            this.edit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edit1_ButtonClick);
            this.edit1.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edit1_ButtonPressed);
            this.edit1.TextChanged += new System.EventHandler(this.edit1_TextChanged);
            // 
            // ucPasswordEdit
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucPasswordEdit";
            this.Size = new System.Drawing.Size(479, 20);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edit2.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit edit2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ButtonEdit edit1;
    }
}
