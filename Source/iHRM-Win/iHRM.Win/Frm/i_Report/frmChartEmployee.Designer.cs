namespace iHRM.Win.Frm.i_Report
{
    partial class frmChartEmployee
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
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView5 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView6 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.chartEmployee = new DevExpress.XtraCharts.ChartControl();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colM12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblNam = new System.Windows.Forms.Label();
            this.cbbNam = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbNam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chartEmployee
            // 
            xyDiagram2.AxisX.Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chartEmployee.Diagram = xyDiagram2;
            this.chartEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartEmployee.Legend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartEmployee.Location = new System.Drawing.Point(0, 365);
            this.chartEmployee.Name = "chartEmployee";
            pointSeriesLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.Label = pointSeriesLabel2;
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.Name = "Vào làm";
            lineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.View = lineSeriesView4;
            series5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.Name = "Nghỉ việc";
            lineSeriesView5.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.View = lineSeriesView5;
            series6.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series6.Name = "Hiện tại";
            lineSeriesView6.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series6.View = lineSeriesView6;
            this.chartEmployee.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4,
        series5,
        series6};
            this.chartEmployee.Size = new System.Drawing.Size(1264, 316);
            this.chartEmployee.TabIndex = 0;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle2.Text = "THỐNG KÊ NHÂN VIÊN THEO THÁNG";
            chartTitle2.TextColor = System.Drawing.Color.Navy;
            this.chartEmployee.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Top;
            this.grd.Location = new System.Drawing.Point(0, 38);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemSpinEdit1});
            this.grd.Size = new System.Drawing.Size(1264, 327);
            this.grd.TabIndex = 4;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDep,
            this.colM1,
            this.colM2,
            this.colM3,
            this.colM4,
            this.colM5,
            this.colM6,
            this.colM7,
            this.colM8,
            this.colM9,
            this.colM10,
            this.colM11,
            this.colM12});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsSelection.MultiSelect = true;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowFooter = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            // 
            // colDep
            // 
            this.colDep.Caption = "Phòng ban";
            this.colDep.FieldName = "DepName";
            this.colDep.Name = "colDep";
            this.colDep.Visible = true;
            this.colDep.VisibleIndex = 0;
            this.colDep.Width = 220;
            // 
            // colM1
            // 
            this.colM1.Caption = "Tháng 1";
            this.colM1.FieldName = "t1";
            this.colM1.Name = "colM1";
            this.colM1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t1", "Tổng = {0:0.##}")});
            this.colM1.Visible = true;
            this.colM1.VisibleIndex = 1;
            this.colM1.Width = 105;
            // 
            // colM2
            // 
            this.colM2.Caption = "Tháng 2";
            this.colM2.FieldName = "t2";
            this.colM2.Name = "colM2";
            this.colM2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t2", "Tổng = {0:0.##}")});
            this.colM2.Visible = true;
            this.colM2.VisibleIndex = 2;
            this.colM2.Width = 105;
            // 
            // colM3
            // 
            this.colM3.Caption = "Tháng 3";
            this.colM3.FieldName = "t3";
            this.colM3.Name = "colM3";
            this.colM3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t3", "Tổng = {0:0.##}")});
            this.colM3.Visible = true;
            this.colM3.VisibleIndex = 3;
            this.colM3.Width = 105;
            // 
            // colM4
            // 
            this.colM4.Caption = "Tháng 4";
            this.colM4.FieldName = "t4";
            this.colM4.Name = "colM4";
            this.colM4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t4", "Tổng = {0:0.##}")});
            this.colM4.Visible = true;
            this.colM4.VisibleIndex = 4;
            this.colM4.Width = 105;
            // 
            // colM5
            // 
            this.colM5.Caption = "Tháng 5";
            this.colM5.FieldName = "t5";
            this.colM5.Name = "colM5";
            this.colM5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t5", "Tổng = {0:0.##}")});
            this.colM5.Visible = true;
            this.colM5.VisibleIndex = 5;
            this.colM5.Width = 105;
            // 
            // colM6
            // 
            this.colM6.Caption = "Tháng 6";
            this.colM6.FieldName = "t6";
            this.colM6.Name = "colM6";
            this.colM6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t6", "Tổng = {0:0.##}")});
            this.colM6.Visible = true;
            this.colM6.VisibleIndex = 6;
            this.colM6.Width = 105;
            // 
            // colM7
            // 
            this.colM7.Caption = "Tháng 7";
            this.colM7.FieldName = "t7";
            this.colM7.Name = "colM7";
            this.colM7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t7", "Tổng = {0:0.##}")});
            this.colM7.Visible = true;
            this.colM7.VisibleIndex = 7;
            this.colM7.Width = 105;
            // 
            // colM8
            // 
            this.colM8.Caption = "Tháng 8";
            this.colM8.FieldName = "t8";
            this.colM8.Name = "colM8";
            this.colM8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t8", "Tổng = {0:0.##}")});
            this.colM8.Visible = true;
            this.colM8.VisibleIndex = 8;
            this.colM8.Width = 105;
            // 
            // colM9
            // 
            this.colM9.Caption = "Tháng 9";
            this.colM9.FieldName = "t9";
            this.colM9.Name = "colM9";
            this.colM9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t9", "Tổng = {0:0.##}")});
            this.colM9.Visible = true;
            this.colM9.VisibleIndex = 9;
            this.colM9.Width = 105;
            // 
            // colM10
            // 
            this.colM10.Caption = "Tháng 10";
            this.colM10.FieldName = "t10";
            this.colM10.Name = "colM10";
            this.colM10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t10", "Tổng = {0:0.##}")});
            this.colM10.Visible = true;
            this.colM10.VisibleIndex = 10;
            this.colM10.Width = 105;
            // 
            // colM11
            // 
            this.colM11.Caption = "Tháng 11";
            this.colM11.FieldName = "t11";
            this.colM11.Name = "colM11";
            this.colM11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t11", "Tổng = {0:0.##}")});
            this.colM11.Visible = true;
            this.colM11.VisibleIndex = 11;
            this.colM11.Width = 105;
            // 
            // colM12
            // 
            this.colM12.Caption = "Tháng 12";
            this.colM12.FieldName = "t12";
            this.colM12.Name = "colM12";
            this.colM12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "t12", "Tổng = {0:0.##}")});
            this.colM12.Visible = true;
            this.colM12.VisibleIndex = 12;
            this.colM12.Width = 105;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Xóa";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblNam);
            this.panelControl2.Controls.Add(this.cbbNam);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1264, 38);
            this.panelControl2.TabIndex = 5;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblNam.Location = new System.Drawing.Point(12, 9);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(74, 19);
            this.lblNam.TabIndex = 1;
            this.lblNam.Text = "Chọn năm:";
            // 
            // cbbNam
            // 
            this.cbbNam.Location = new System.Drawing.Point(92, 5);
            this.cbbNam.Name = "cbbNam";
            this.cbbNam.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.cbbNam.Properties.Appearance.Options.UseFont = true;
            this.cbbNam.Properties.AutoHeight = false;
            this.cbbNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbNam.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("chartYear", "Năm")});
            this.cbbNam.Properties.DisplayMember = "chartYear";
            this.cbbNam.Properties.NullText = "";
            this.cbbNam.Properties.PopupSizeable = false;
            this.cbbNam.Properties.ValueMember = "chartYear";
            this.cbbNam.Size = new System.Drawing.Size(97, 26);
            this.cbbNam.TabIndex = 0;
            this.cbbNam.EditValueChanged += new System.EventHandler(this.cbbNam_EditValueChanged);
            // 
            // frmChartEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.chartEmployee);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.panelControl2);
            this.KeyPreview = true;
            this.Name = "frmChartEmployee";
            this.Text = "Thống kê số lượng nhân viên theo tháng";
            this.Load += new System.EventHandler(this.frmChartEmployee_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChartEmployee_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbNam.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartEmployee;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colDep;
        private DevExpress.XtraGrid.Columns.GridColumn colM1;
        private DevExpress.XtraGrid.Columns.GridColumn colM2;
        private DevExpress.XtraGrid.Columns.GridColumn colM3;
        private DevExpress.XtraGrid.Columns.GridColumn colM4;
        private DevExpress.XtraGrid.Columns.GridColumn colM5;
        private DevExpress.XtraGrid.Columns.GridColumn colM6;
        private DevExpress.XtraGrid.Columns.GridColumn colM7;
        private DevExpress.XtraGrid.Columns.GridColumn colM8;
        private DevExpress.XtraGrid.Columns.GridColumn colM9;
        private DevExpress.XtraGrid.Columns.GridColumn colM10;
        private DevExpress.XtraGrid.Columns.GridColumn colM11;
        private DevExpress.XtraGrid.Columns.GridColumn colM12;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label lblNam;
        private DevExpress.XtraEditors.LookUpEdit cbbNam;
    }
}