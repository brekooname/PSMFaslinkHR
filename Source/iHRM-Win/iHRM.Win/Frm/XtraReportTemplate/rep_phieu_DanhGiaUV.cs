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
    public partial class rep_phieu_DanhGiaUV : XtraReport
    {
        public rep_phieu_DanhGiaUV()
        {
            InitializeComponent();
            xrRichText1.LoadFile(Path.Combine(win_globall.apppath, @"ExcelTemplate\TuyenDung\danhgiaphongvan.docx"));
        }
        public void DataBindings(object dt)
        {
            this.DataSource = dt;
        }

    }
}
