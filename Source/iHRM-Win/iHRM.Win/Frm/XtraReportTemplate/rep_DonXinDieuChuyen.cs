﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;

namespace iHRM.Win.Frm.XtraReportTemplate
{
    public partial class rep_DonXinDieuChuyen : DevExpress.XtraReports.UI.XtraReport
    {
        public rep_DonXinDieuChuyen()
        {
            InitializeComponent();

            xrRichText1.Clear();

            xrRichText1.LoadFile(Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\SW_HR_DONXINDIEUCHUYEN.docx"));
        }

        public void DataBindings(object dt)
        {
            this.DataSource = dt;
        }
    }
}
