using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace iHRM.Win.Frm.XtraReportTemplate
{
    public partial class rep_phieu_TM : XtraReport
    {
        public rep_phieu_TM()
        {
            InitializeComponent();
            xrRichText1.LoadFile(Path.Combine(win_globall.apppath, @"ExcelTemplate\TuyenDung\thumoiphongvan.docx"));
        }
        public void DataBindings(object dt)
        {
            this.DataSource = dt;
        }

    }
}
