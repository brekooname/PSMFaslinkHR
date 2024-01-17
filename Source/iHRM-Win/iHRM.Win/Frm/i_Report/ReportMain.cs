using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm.i_Report
{
    public partial class ReportMain : Form
    {
        public class DataItem
        {
            public string name { get; set; }
            public string path { get; set; }
            public List<DataItem> childs { get; set; }
        }

        public ReportMain()
        {
            InitializeComponent();
        }

        private void ReportMain_Load(object sender, EventArgs e)
        {

        }
    }
}
