namespace SyncSV.UC.UControl
{
    partial class ucChooseEdit
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
            this.text1 = new DevExpress.XtraEditors.ButtonEdit();
            this.edit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.text1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            // 
            // text1
            // 
            this.text1.Dock = System.Windows.Forms.DockStyle.Left;
            this.text1.EditValue = "";
            this.text1.Location = new System.Drawing.Point(108, 0);
            this.text1.Name = "text1";
            this.text1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.text1.Size = new System.Drawing.Size(80, 20);
            this.text1.TabIndex = 2;
            this.text1.Visible = false;
            this.text1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text1_KeyDown);
            // 
            // edit1
            // 
            this.edit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit1.Location = new System.Drawing.Point(188, 0);
            this.edit1.Name = "edit1";
            this.edit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edit1.Properties.NullText = "Chọn...";
            this.edit1.Properties.View = this.searchLookUpEdit1View;
            this.edit1.Size = new System.Drawing.Size(92, 20);
            this.edit1.TabIndex = 3;
            this.edit1.EditValueChanged += new System.EventHandler(this.edit1_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ucChooseEdit
            // 
            this.Controls.Add(this.edit1);
            this.Controls.Add(this.text1);
            this.Name = "ucChooseEdit";
            this.Size = new System.Drawing.Size(280, 20);
            this.Load += new System.EventHandler(this.ucChooseEdit_Load);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.text1, 0);
            this.Controls.SetChildIndex(this.edit1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.text1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit text1;
        public DevExpress.XtraEditors.SearchLookUpEdit edit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;


    }
}
