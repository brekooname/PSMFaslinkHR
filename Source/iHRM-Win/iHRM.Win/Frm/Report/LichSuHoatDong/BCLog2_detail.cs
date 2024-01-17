using iHRM.Core.i_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace iHRM.Win.Frm.Report
{
    public partial class BCLog2_detail : frmBase
    {
        dcDatabaseFilesDataContext db;
        public Guid? myID = null;
        public tbLog2 myValue = null;

        public BCLog2_detail()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ViewData();
        }
        public void ViewData()
        {
            db = new dcDatabaseFilesDataContext(iHRM.Core.Business.Provider.ConnectionString_Files);

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing += (s, ev) =>
            {
                myValue = db.tbLog2s.SingleOrDefault(i => i.id == myID);
                dw_it.bw.ReportProgress(1);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        textBox1.Text = myValue.uid.ToString();
                        textBox2.Text = myValue.uname;
                        textBox3.Text = myValue.tbConnectionInfo.IPAdress;
                        textBox4.Text = myValue.tbConnectionInfo.DomainName;
                        textBox5.Text = myValue.tbConnectionInfo.MachineName;
                        textBox6.Text = myValue.tbConnectionInfo.OperationSystem;
                        textBox7.Text = myValue.tbConnectionInfo.OSVersion;
                        textBox8.Text = myValue.tbConnectionInfo.sHRM_version;

                        grcNVLamCa.DataSource = myValue.tbLog2_details;
                        btnFind.Enabled = true;
                        break;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grcNVLamCa);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void BCLog2_detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcNVLamCa.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }
    }
}
