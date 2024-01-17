using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace iHRM.Win.ExtClass
{
    public partial class rep_InTheNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public rep_InTheNhanVien()
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
                tbcellCMND.DataBindings.Add("Text", bindingSource1, "IDCard");
                tbcellBoPhan.DataBindings.Add("Text", bindingSource1, "DepName");
                tbcellNgayVao.DataBindings.Add("Text", bindingSource1, "AppliedDate", "{0:dd/MM/yyyy}");

                picDaiDien.DataBindings.Add("Image", bindingSource1, "dataFile");
            }
            catch (Exception ex)
            {

            }
        }

    }
}
