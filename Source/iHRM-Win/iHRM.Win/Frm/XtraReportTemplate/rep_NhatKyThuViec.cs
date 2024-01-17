using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;

namespace iHRM.Win.Frm.XtraReport_Template
{
    public partial class rep_NhatKyThuViec : DevExpress.XtraReports.UI.XtraReport
    {
        public rep_NhatKyThuViec()
        {
            InitializeComponent();
            xrRichText1.LoadFile(Path.Combine(win_globall.apppath, @"ExcelTemplate\TuyenDung\nhatkythuviec.docx"));
        }
        public void DataBindings(object dt)
        {
            this.DataSource = dt;
        }
    }
}
