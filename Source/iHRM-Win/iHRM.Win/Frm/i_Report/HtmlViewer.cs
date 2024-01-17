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

namespace iHRM.Win.Frm.i_Report
{
    public partial class HtmlViewer : frmBase
    {
        private string _html = "";
        public string HTML
        {
            get { return _html; }
            set { _html = value; }
        }
        
        public HtmlViewer()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            richEditControl1.HtmlText = _html;
        }
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richEditControl1.Print();
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
