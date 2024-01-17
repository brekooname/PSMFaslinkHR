using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;

namespace iHRM.Win.Frm.XtraReportTemplate
{
    public partial class rep_DonXinNghiViec : DevExpress.XtraReports.UI.XtraReport
    {
        public rep_DonXinNghiViec()
        {
            InitializeComponent();

            xrRichText1.Clear();

            xrRichText1.LoadFile(Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\SW_HR_DONXINNGHIVIEC.docx"));
        }

        public void DataBindings(object dt)
        {
            this.DataSource = dt;
        }

    }
}
