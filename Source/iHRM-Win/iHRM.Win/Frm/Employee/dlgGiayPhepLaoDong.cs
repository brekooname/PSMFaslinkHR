using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass;
using DevExpress.XtraEditors;

namespace iHRM.Win.Frm.Employee
{
    public partial class dlgGiayPhepLaoDong : dlgBase
    {
        string _empID = "";
        List<Sex> arrSex = new List<Sex>();
        public dlgGiayPhepLaoDong()
        {
            InitializeComponent();
            dlgData.IdColumnName = "id";
            dlgData.CaptionColumnName = "hoTen";
            dlgData.FormCaption = "Thông tin giấy phép lao động ";
            AddControlBinding();
            txtMaNhanVien.Focus();
        }
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        private void dlgEmployee_Load(object sender, EventArgs e)
        {
            //txtMaNhanVien.Focus();
            //LoadPreData();
            //searchLookUpEdit1.Properties.DataSource = db.tblEmployees;
        }

        //private void LoadPreData()
        //{
        //    // Giới tính
        //    arrSex = new List<Sex>();
        //    arrSex.Add(new Sex { SexName = "Nam", SexID = "Nam" });
        //    arrSex.Add(new Sex { SexName = "Nữ", SexID = "Nữ" });
        //    lookupGioitinh.Properties.DataSource = arrSex;

        //}
        private class Sex
        {
            public string SexName { get; set; }
            public string SexID { get; set; }
        }
        protected override void FormSetData()
        {
            base.FormSetData();
            _empID = myID as string;
        }

        public void AddControlBinding()
        {
            //Start thông tin cơ bản
            dlgData.CB.Add(new ControlBinding("EmployeeID", txtMaNhanVien, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("soGiayPhep", txtSoGiayPhep, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("hoTen", txtHoTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("soHoChieu", txtSoHoChieu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("toChucLamViec", txtToChucLamViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("noiLamViec", txtNoiLamViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("viTriCongViec", txtViTriCongViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("trinhDoChuyenMon", txtTrinhDoChuyenMon, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BeginDate", dateNgayBD, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("EndDate", dateNgayKT, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("ngayKy", dateNgayKy, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("noiKy", txtNoiKy, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ngaySinh", dateNgaySinh, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("gioiTinh", txtGioiTinh, ControlBinding_DataType.String));
        }

        #region Set DateEdit null if Blank
        private void setDateNullIfBlank(DateEdit d)
        {
            if (d.Text == "")
            {
                d.EditValue = null;
            }
        }
        private void dateNgayBD_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayBD);
        }

        private void dateNgayKT_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayKT);
        }

        private void dateNgayKy_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayKy);
        }

        private void dateNgaySinh_EditValueChanged_1(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgaySinh);
        }
        #endregion



        private void txtHovaTen_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtHoTen_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                   if(txtMaNhanVien.Text != string.Empty)
                   {
                       var data = db.tblEmployees.FirstOrDefault(i => i.EmployeeID == txtMaNhanVien.Text);
                       if (data == null)
                       {
                           GUIHelper.MessageBox("Nhân viên này không tồn tại.");
                       }
                       else
                       {
                           txtHoTen.Text = data.EmployeeName;
                           dateNgaySinh.EditValue = data.Birthday;
                           txtGioiTinh.Text = data.SexID;
                           txtTrinhDoChuyenMon.Text = data.EducationType;
                       }
                   }
                   else
                       GUIHelper.MessageBox("Chưa nhập mã nhân viên.");

                }
                catch { }
            }
        }

        private void txtTrinhDoChuyenMon_EditValueChanged(object sender, EventArgs e)
        {

        }


    }
}