namespace iHRM.Win.Frm.mainForm
{
    partial class main5
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main5));
            DevExpress.Utils.Animation.Transition transition1 = new DevExpress.Utils.Animation.Transition();
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            this.mainTileBar = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup2 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.tileBarItem1 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.tileBarItem3 = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.transitionManager1 = new DevExpress.Utils.Animation.TransitionManager();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTileBar
            // 
            this.mainTileBar.AllowDrag = false;
            this.mainTileBar.AllowSelectedItem = true;
            this.mainTileBar.AppearanceGroupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.mainTileBar.AppearanceGroupText.Options.UseForeColor = true;
            this.mainTileBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.mainTileBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainTileBar.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.mainTileBar.Groups.Add(this.tileBarGroup2);
            this.mainTileBar.Location = new System.Drawing.Point(0, 0);
            this.mainTileBar.MaxId = 13;
            this.mainTileBar.Name = "mainTileBar";
            this.mainTileBar.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.mainTileBar.SelectionBorderWidth = 2;
            this.mainTileBar.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.mainTileBar.Size = new System.Drawing.Size(1307, 103);
            this.mainTileBar.TabIndex = 2;
            this.mainTileBar.Text = "tileBar1";
            // 
            // tileBarGroup2
            // 
            this.tileBarGroup2.Name = "tileBarGroup2";
            // 
            // tileBarItem1
            // 
            this.tileBarItem1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Text = "tileBarItem1";
            this.tileBarItem1.Elements.Add(tileItemElement1);
            this.tileBarItem1.Id = 9;
            this.tileBarItem1.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem1.Name = "tileBarItem1";
            // 
            // tileBarItem3
            // 
            this.tileBarItem3.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.tileBarItem3.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(109)))), ((int)(((byte)(0)))));
            this.tileBarItem3.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBarItem3.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.Image = ((System.Drawing.Image)(resources.GetObject("tileItemElement2.Image")));
            tileItemElement2.Text = "Employees";
            this.tileBarItem3.Elements.Add(tileItemElement2);
            this.tileBarItem3.Id = 2;
            this.tileBarItem3.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.tileBarItem3.Name = "tileBarItem3";
            this.tileBarItem3.ShowDropDownButton = DevExpress.Utils.DefaultBoolean.True;
            this.tileBarItem3.ShowItemShadow = DevExpress.Utils.DefaultBoolean.False;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 103);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1307, 398);
            this.panelControl1.TabIndex = 3;
            // 
            // transitionManager1
            // 
            this.transitionManager1.FrameCount = 3000;
            this.transitionManager1.ShowWaitingIndicator = false;
            transition1.Control = null;
            transition1.EasingMode = DevExpress.Data.Utils.EasingMode.EaseInOut;
            transition1.TransitionType = pushTransition1;
            this.transitionManager1.Transitions.Add(transition1);
            // 
            // main5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 501);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.mainTileBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main5";
            this.Text = "iHRM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraBars.Navigation.TileBar mainTileBar;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup2;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem1;
        private DevExpress.XtraBars.Navigation.TileBarItem tileBarItem3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.Utils.Animation.TransitionManager transitionManager1;
    }
}