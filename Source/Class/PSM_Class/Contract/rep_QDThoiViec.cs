using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace iHRM.Win.ExtClass.Contract
{
    public partial class rep_QDThoiViec : XtraReport
    {
        public rep_QDThoiViec(string strFile)
        {
            InitializeComponent();

            try
            {
                xrRichText1.Clear();
                xrRichText1.LoadFile(strFile);
            }
            catch(Exception ex)
            {

            }
        }

        public void bindData(object dt)
        {
            this.DataSource = dt;
        }

    }
}
