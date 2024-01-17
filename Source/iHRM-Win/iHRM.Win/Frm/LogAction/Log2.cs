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
using iHRM.Core.Business.DbObject;

namespace iHRM.Win
{
    public static class Log2
    {
        public enum Log2Action { them, sua, xoa, phantich, xem, xuat_bc }

        static dcDatabaseFilesDataContext db = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        public static bool PushLog(tbLog2 item)
        {
            db.tbLog2s.InsertOnSubmit(item);
            db.SubmitChanges();
            return true;
        }
        public static tbLog2 CreateLog(Log2Action action, string description, string target1 = "", string target2 = "")
        {
            tbLog2 it = new tbLog2();
            it.action = action.ToString();
            it.cid = LoginHelper.ConnectionInfo.id;
            it.createDate = getSvTime();
            it.description = description;
            it.id = Guid.NewGuid();
            it.target1 = target1;
            it.target2 = target2;
            it.tbLog2_details = new System.Data.Linq.EntitySet<tbLog2_detail>();
            it.uid = LoginHelper.user.id;
            it.uname = LoginHelper.user.caption;
            return it;
        }
        public static void AddLogDetail(tbLog2 log, string[] fields, object obj)
        {
            foreach(var fName in fields)
            {
                var v = Common.Code.PropertyExtension1.GetPropValue(obj, fName);
                string fValue = "";
                if (v is string)
                    fValue = v as string;
                else if (v != null)
                    fValue = v.ToString();

                if (fValue.Length > 255)
                    fValue = fValue.Substring(0, 255);

                log.tbLog2_details.Add(new tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = fName,
                    value1 = fValue
                });
            }
        }
        public static void AddLogDetail(tbLog2 log, string[] fields, DataRow r)
        {
            foreach(var fName in fields)
            {
                var v = r[fName];
                string fValue = "";
                if (v is string)
                    fValue = v as string;
                else if (v != DBNull.Value && v != null)
                    fValue = v.ToString();

                if (fValue.Length > 255)
                    fValue = fValue.Substring(0, 255);

                log.tbLog2_details.Add(new tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = fName,
                    value1 = fValue
                });
            }
        }

        public static DataTable GetLog(DateTime tuNgay, DateTime denNgay, long? uid = null)
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand("p_GetLog2", objConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("uid", uid);
                cmd.Parameters.AddWithValue("tuNgay", tuNgay);
                cmd.Parameters.AddWithValue("denNgay", denNgay);
                var data = new DataTable();
                using (var dr = cmd.ExecuteReader())
                {
                    //if (dr.HasRows)
                    data.Load(dr);
                }
                return data;
            }
        }

        private static SqlConnection _CreateConnection()
        {
            try
            {
                var cnn = new SqlConnection(Provider.ConnectionString_Files);
                cnn.Open();
                return cnn;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        static DateTime getSvTime()
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand("getSvTime", objConn) { CommandType = CommandType.StoredProcedure };
                var d = cmd.ExecuteScalar() as DateTime?;
                return d ?? DateTime.Now;
            }
        }
    }
}