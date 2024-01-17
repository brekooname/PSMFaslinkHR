using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;

namespace iHRM.Win.Frm.XtraReportTemplate
{
    public partial class rep_DanhGiaNV : DevExpress.XtraReports.UI.XtraReport
    {
        public rep_DanhGiaNV(int _flag)
        {
            InitializeComponent();

            xrRichText1.Clear();

            if (_flag == 0)

                xrRichText1.LoadFile(Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\SW_HR_DANHGIA1NAM.docx"));

            else

                xrRichText1.LoadFile(Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\SW_HR_DANHGIA1NAM_TT.docx"));
        }

        public void DataBindings(object dt)
        {
            this.DataSource = dt;
        }
    }
}
