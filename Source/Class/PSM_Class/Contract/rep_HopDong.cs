﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace iHRM.Win.ExtClass.Contract
{
    public partial class rep_HopDong : XtraReport
    {
        public rep_HopDong(string strFile)
        {
            InitializeComponent();
            xrRichText1.Clear();
            xrRichText1.LoadFile(strFile);
        }

        public void bindData(object dt)
        {
            this.DataSource = dt;
        }

    }
}