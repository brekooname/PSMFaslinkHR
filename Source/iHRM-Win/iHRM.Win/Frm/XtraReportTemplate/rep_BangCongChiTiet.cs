using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using iHRM.Win.ExtClass;

namespace iHRM.Win.Frm.XtraReportTemplate
{
    public partial class rep_BangCongChiTiet : DevExpress.XtraReports.UI.XtraReport
    {
        List<Emp_KQ> _lEmpKQ;
        public rep_BangCongChiTiet()
        {
            InitializeComponent();
        }
        public void BindData(List<Emp_KQ> lEmpKQ)
        {
            lbMaNV.DataBindings.Add("Text", null, "EmployeeID");
            lbTenNV.DataBindings.Add("Text", null, "EmployeeName");
            lbPhongBan.DataBindings.Add("Text", null, "DepName_Final");
            colGio.DataBindings.Add("Text", null, "SoGio");
            colCong.DataBindings.Add("Text", null, "Cong");
            colTangCa2.DataBindings.Add("Text", null, "TangCa");
            colSoLanTre.DataBindings.Add("Text", null, "SoLanTre");
            colSoLanSom.DataBindings.Add("Text", null, "SoLanSom");
            colVangKP.DataBindings.Add("Text", null, "VangKP");
            colSoPhutTre.DataBindings.Add("Text", null, "SoPhutTre");
            colSoPhutSom.DataBindings.Add("Text", null, "SoPhutSom");
            colVangCP.DataBindings.Add("Text", null, "VangCP");
            colTangCaNgayLe.DataBindings.Add("Text", null, "TangCaNgayLe");

            // Kết quả quẹt thẻ

            //colNgay.DataBindings.Add("Text", null, "ngay").FormatString = "{0:dd/MM/yyyy}";            
            colNgay.DataBindings.Add("Text", null, "ngay", "{0:dd/MM/yyyy}");
            colCaLam.DataBindings.Add("Text", null, "caLam");
            //colGioVao.DataBindings.Add("Text", null, "tgQuetDen").FormatString = "{0:HH:mm}";
            colGioVao.DataBindings.Add("Text", null, "tgQuetDen");
            colDiMuon.DataBindings.Add("Text", null, "tgDiMuon");
            //colGioRa.DataBindings.Add("Text", null, "tgQuetVe").FormatString = "{0:HH:mm}";
            colGioRa.DataBindings.Add("Text", null, "tgQuetVe");
            colVeSom.DataBindings.Add("Text", null, "tgVeSom");
            colTangCa.DataBindings.Add("Text", null, "OT");
            colLyDoNghi.DataBindings.Add("Text", null, "lyDoNghi");

            //Thong Lieu thêm '02-03-2019'
            //colNT.DataBindings.Add("Text", null, "NT");
            //colNT2.DataBindings.Add("Text", null, "NT2");
            colTG.DataBindings.Add("Text", null, "TG");

            List<Emp_KQ> _lEmpKQ = new List<Emp_KQ>();
            _lEmpKQ = lEmpKQ;
            bindingSource1.DataSource = _lEmpKQ;
        }
        private void DetailReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _lEmpKQ = bindingSource1.DataSource as List<Emp_KQ>;
            var a23 = this.GetCurrentColumnValue("EmployeeID");
            if (this.GetCurrentColumnValue("EmployeeID") != null && _lEmpKQ != null)
            {
                string empID = this.GetCurrentColumnValue("EmployeeID").ToString();
                var a = _lEmpKQ.FindAll(p => p.EmployeeID == empID);

                bindingSource2.DataSource = a[0]._lKQQT;
            }
            else bindingSource2.DataSource = null;
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                var a = DetailReport.GetCurrentRow() as KQQT; 
                   var r = xrTable3.Rows[0];
                //var a = r.Cells["colNgay"].Text;
                if (Convert.ToDateTime(a.ngay).DayOfWeek == DayOfWeek.Sunday)
                {
                    r.BackColor = Color.Yellow;
                }
                else
                {
                    r.BackColor = Color.White;
                }
            }
            catch (Exception)
            {
            }
        }

        private void xrTableRow5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //var currValue = this.GetCurrentRow();//.GetCurrentColumnValue("colNgay");
            //if (currValue != null && Convert.ToDateTime(currValue).DayOfWeek == DayOfWeek.Sunday)
            //{
            //    XRTableRow row = sender as XRTableRow;
            //    row.BackColor = Color.Yellow;
            //}
        }
    }
}
