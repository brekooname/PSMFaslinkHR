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

namespace iHRM.Win.Frm.LogAction
{
    public static class LogAction
    {
        public static bool PushLog(string Action, string Target1, string Target2, string ActionText, string TableTarget)
        {
            bool isSuccess = false;
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand("p_PushLog", objConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("UserID", LoginHelper.user.id);
                cmd.Parameters.AddWithValue("LogTime", DateTime.Now);
                cmd.Parameters.AddWithValue("Action", Action);
                cmd.Parameters.AddWithValue("Target1", Target1);
                cmd.Parameters.AddWithValue("Target2", Target2);
                cmd.Parameters.AddWithValue("ActionText", ActionText);
                cmd.Parameters.AddWithValue("TableTarget", TableTarget);
                cmd.Parameters.AddWithValue("OperationSystem", LoginHelper.ConnectionInfo.OperationSystem);
                cmd.Parameters.AddWithValue("MachineName", LoginHelper.ConnectionInfo.MachineName);
                cmd.Parameters.AddWithValue("DomainName", LoginHelper.ConnectionInfo.DomainName);
                cmd.Parameters.AddWithValue("IPAdress", LoginHelper.ConnectionInfo.IPAdress);
                cmd.Parameters.AddWithValue("OSVersion", LoginHelper.ConnectionInfo.OSVersion);
                cmd.Parameters.AddWithValue("sHRM_version", LoginHelper.ConnectionInfo.sHRM_version);
                isSuccess = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            return isSuccess;
        }
        public static bool PushLog(string Action, List<string> Target1, string Target2, string ActionText, string TableTarget)
        {
            bool isSuccess = false;
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand("p_PushLog", objConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("UserID", LoginHelper.user.id);
                cmd.Parameters.AddWithValue("LogTime", DateTime.Now);
                cmd.Parameters.AddWithValue("Action", Action);
                cmd.Parameters.AddWithValue("Target1", string.Join(",", Target1));
                cmd.Parameters.AddWithValue("Target2", Target2);
                cmd.Parameters.AddWithValue("ActionText", ActionText);
                cmd.Parameters.AddWithValue("TableTarget", TableTarget);
                cmd.Parameters.AddWithValue("OperationSystem", LoginHelper.ConnectionInfo.OperationSystem);
                cmd.Parameters.AddWithValue("MachineName", LoginHelper.ConnectionInfo.MachineName);
                cmd.Parameters.AddWithValue("DomainName", LoginHelper.ConnectionInfo.DomainName);
                cmd.Parameters.AddWithValue("IPAdress", LoginHelper.ConnectionInfo.IPAdress);
                cmd.Parameters.AddWithValue("OSVersion", LoginHelper.ConnectionInfo.OSVersion);
                cmd.Parameters.AddWithValue("sHRM_version", LoginHelper.ConnectionInfo.sHRM_version);
                isSuccess = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            return isSuccess;
        }
        public static bool PushLog(List<ActionClass> listAction)
        {
            bool isSuccess = true;
            using (var objConn = _CreateConnection())
            {
                foreach (var item in listAction)
                {
                    var cmd = new SqlCommand("p_PushLog", objConn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("UserID", LoginHelper.user.id);
                    cmd.Parameters.AddWithValue("LogTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("Action", item.Action);
                    cmd.Parameters.AddWithValue("Target1", item.Target1);
                    cmd.Parameters.AddWithValue("Target2", item.Target2);
                    cmd.Parameters.AddWithValue("ActionText", item.ActionText);
                    cmd.Parameters.AddWithValue("TableTarget", item.TableTarget);
                    cmd.Parameters.AddWithValue("OperationSystem", LoginHelper.ConnectionInfo.OperationSystem);
                    cmd.Parameters.AddWithValue("MachineName", LoginHelper.ConnectionInfo.MachineName);
                    cmd.Parameters.AddWithValue("DomainName", LoginHelper.ConnectionInfo.DomainName);
                    cmd.Parameters.AddWithValue("IPAdress", LoginHelper.ConnectionInfo.IPAdress);
                    cmd.Parameters.AddWithValue("OSVersion", LoginHelper.ConnectionInfo.OSVersion);
                    cmd.Parameters.AddWithValue("sHRM_version", LoginHelper.ConnectionInfo.sHRM_version);
                    if (cmd.ExecuteNonQuery() <= 0)
                    {
                        isSuccess = false;
                    }
                }
            }
            return isSuccess;
        }
        public static DataTable GetLog(DateTime tuNgay, DateTime denNgay, string idUser = null, string tableName = null)
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand("p_GetLog", objConn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("userID", idUser);
                cmd.Parameters.AddWithValue("tableName", tableName);
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
        public static DataTable GetTableTarget()
        {
            using (var objConn = _CreateConnection())
            {
                var cmd = new SqlCommand("p_GetTableTarget", objConn) { CommandType = CommandType.StoredProcedure };
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
    }
    public class ActionClass
    {
        private string p1;
        private string p2;
        private string p3;
        private string p4;

        public string Action { get; set; }
        public string Target1 { get; set; }
        public string Target2 { get; set; }
        public string ActionText { get; set; }
        public string TableTarget { get; set; }
        public ActionClass(string Action, string Target1, string Target2, string ActionText, string TableTarget)
        {
            this.Action = Action;
            this.Target1 = Target1;
            this.Target2 = Target2;
            this.ActionText = ActionText;
            this.TableTarget = TableTarget;
        }

    }
}