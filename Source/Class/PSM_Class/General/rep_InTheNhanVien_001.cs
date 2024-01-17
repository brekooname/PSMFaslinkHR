using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iHRM.Win.ExtClass
{
    public partial class rep_InTheNhanVien_001 : DevExpress.XtraReports.UI.XtraReport
    {
        public rep_InTheNhanVien_001()
        {
            InitializeComponent();
        }
        public void DataBindings(object dtSource) 
        {
            bindingSource1.DataSource = dtSource;

            try
            {
                //THÔNG TIN CHUNG.
                tbcellMaNV.DataBindings.Add("Text", bindingSource1, "EmployeeID");
                tbcellTenNV.DataBindings.Add("Text", bindingSource1, "EmployeeName");
                tbcellBoPhan.DataBindings.Add("Text", bindingSource1, "DepName");
                tbcellPosName.DataBindings.Add("Text", bindingSource1, "PosName");

                picDaiDien.DataBindings.Add("Image", bindingSource1, "dataFile");
            }
            catch (Exception ex)
            {

            }
        }

    }
}
