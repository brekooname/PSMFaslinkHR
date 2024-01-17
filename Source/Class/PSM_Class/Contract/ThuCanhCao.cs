using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System.Linq;

namespace iHRM.Win.ExtClass.Contract
{
    public partial class ThuCanhCao : DevExpress.XtraReports.UI.XtraReport
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public ThuCanhCao()
        {
            InitializeComponent();
        }
        public void BindingData(object dt) 
        {
            bindingSource1.DataSource = dt;
            xrLabel4.Text = "No.(số):_____/HR" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00"); 
            lbMaNV.DataBindings.Add("Text", bindingSource1, "EmployeeID");
            lbNhanVien.DataBindings.Add("Text", bindingSource1, "EmployeeName");
            xrLabel14.DataBindings.Add("Text", bindingSource1, "EmpTypeName");
            lbBoPhan.DataBindings.Add("Text", bindingSource1, "DepName");
        }

    }
}
