using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iHRM.Win.Frm.LogAction;

namespace iHRM.Win.Frm.LockTable
{
    public partial class frmLockTable : Form
    {
        List<ActionClass> _lActionClass = new List<ActionClass>();

        public frmLockTable()
        {
            InitializeComponent();
        }

        private void frmLockTable_Load(object sender, EventArgs e)
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            lookUpBangDL.Properties.DataSource = db.tblRef_BangKhoaDuLieus.OrderBy( p => p.tableDisplay);


            _lActionClass.Clear();

            List<TypeLock> arrTypeLock = new List<TypeLock>();

            arrTypeLock.Add(new TypeLock { LockID = "1", LockType = "Khóa chốt dữ liệu" });
            arrTypeLock.Add(new TypeLock { LockID = "2", LockType = "Khóa đăng ký mới" });
            arrTypeLock.Add(new TypeLock { LockID = "3", LockType = "Khóa quản lý phê duyệt" });

            lookLoaiKhoa.Properties.DataSource = arrTypeLock;

            //btnLock.Visible = btnUnLock.Visible = LoginHelper.user.isAdmin;

        }

        private void btnLock_Click(object sender, EventArgs e)
        {

            string t = lookUpBangDL.EditValue.ToString();
            if (t == string.Empty)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            string t1 = lookLoaiKhoa.EditValue.ToString();
            if (t1 == string.Empty)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            DateTime tuNgay = chonKyLuong1.TuNgay;
            DateTime denNgay = chonKyLuong1.DenNgay_End;

            //Provider.ExecNoneQuery("p_IsLockTableData",
            //    new SqlParameter("tableName_Param", t),
            //    new SqlParameter("tuNgay_Param", tuNgay),
            //    new SqlParameter("denNgay_Param", denNgay),
            //    new SqlParameter("isDel", "0")
            //    );
            Provider.ExecNoneQuery("p_IsLockTableData_Type",
              new SqlParameter("tableName_Param", t),
              new SqlParameter("tuNgay_Param", tuNgay),
              new SqlParameter("denNgay_Param", denNgay),
               new SqlParameter("loaikhoa_Param", lookLoaiKhoa.EditValue),
              new SqlParameter("isDel", "0")
              );

            _lActionClass.Add(new ActionClass("Thêm dữ liệu", "", "", string.Format("Khóa dữ liệu từ ngày {0: dd/MM/yyyy} đến ngày {1: dd/MM/yyyy} bảng: {2}, loại khóa: {3}", tuNgay, denNgay, lookUpBangDL.Text, lookLoaiKhoa.Text), "tblRef_IsLock"));

            LogAction.LogAction.PushLog(_lActionClass);
            _lActionClass.Clear();
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
            
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            string t = lookUpBangDL.EditValue.ToString();
            if (t == string.Empty)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            string t1 = lookLoaiKhoa.EditValue.ToString();
            if (t1 == string.Empty)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            DateTime tuNgay = chonKyLuong1.TuNgay;
            DateTime denNgay = chonKyLuong1.DenNgay_End;

            //Provider.ExecNoneQuery("p_IsLockTableData",
            //    new SqlParameter("tableName_Param", t),
            //    new SqlParameter("tuNgay_Param", tuNgay),
            //    new SqlParameter("denNgay_Param", denNgay),
            //    new SqlParameter("isDel", 1)
            //    );

            Provider.ExecNoneQuery("p_IsLockTableData_Type",
             new SqlParameter("tableName_Param", t),
             new SqlParameter("tuNgay_Param", tuNgay),
             new SqlParameter("denNgay_Param", denNgay),
              new SqlParameter("loaikhoa_Param", lookLoaiKhoa.EditValue),
             new SqlParameter("isDel", 1)
             );
            _lActionClass.Add(new ActionClass("Xóa dữ liệu", "", "", string.Format("Mở khóa dữ liệu từ ngày {0: dd/MM/yyyy} đến ngày {1: dd/MM/yyyy} bảng: {2}, loại khóa: {3}", tuNgay, denNgay, lookUpBangDL.Text, lookLoaiKhoa.Text), "tblRef_IsLock"));

            LogAction.LogAction.PushLog(_lActionClass);
            _lActionClass.Clear();
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
        }

        private class TypeLock
        {
            public string LockID { get; set; }
            public string LockType { get; set; }
        }
    }
}
