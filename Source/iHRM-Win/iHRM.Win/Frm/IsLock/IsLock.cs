using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace iHRM.Win.Frm.IsLock
{
    public static class IsLock
    {
        public static bool Check_IsLock(string tbName, DateTime ngay)
        {
            var a = Provider.ExecuteScalar("p_CheckIsLock",
                new SqlParameter("tableName", tbName),
                new SqlParameter("ngay", ngay)
                );
            return a != null;
        }

        public static bool Check_IsLock_Type(string tbName, DateTime ngay, int loaikhoa)
        {
            var a = Provider.ExecuteScalar("p_CheckIsLock_Type",
                new SqlParameter("tableName", tbName),
                new SqlParameter("ngay", ngay),
                new SqlParameter("loaikhoa", loaikhoa)
                );
            return a != null;
        }
        public static bool Check_DangKyCaLam(string EmployeeID, DateTime ngay)
        {
            var a = Provider.ExecuteScalar("p_CheckIsLock_tbDangKyCaLam",
                new SqlParameter("EmployeeID", EmployeeID),
                new SqlParameter("ngay", ngay)
                );
            return a != null;
        }

        public static bool Check_DangKyTangCa(string EmployeeID, DateTime ngay)
        {
            var a = Provider.ExecuteScalar("p_CheckIsLock_tbDangKyTangCa",
                new SqlParameter("EmployeeID", EmployeeID),
                new SqlParameter("ngay", ngay)
                );
            return a != null;
        }

        public static bool Check_IsdkCaLam(string EmployeeID, DateTime ngay)
        {
            var a = Provider.ExecuteScalar("p_Check_IsdkCaLam",
                new SqlParameter("EmployeeID", EmployeeID),
                new SqlParameter("ngay", ngay)
                );
            return a != null;
        }

        public static bool p_Check_IsdklamThem(string EmployeeID, DateTime ngay)
        {
            var a = Provider.ExecuteScalar("p_Check_IsdklamThem",
                new SqlParameter("EmployeeID", EmployeeID),
                new SqlParameter("ngay", ngay)
                );
            return a != null;
        }

        private static SqlConnection _CreateConnection()
        {
            var cnn = new SqlConnection(Provider.ConnectionString);
            cnn.Open();
            return cnn;
        }
    }
}