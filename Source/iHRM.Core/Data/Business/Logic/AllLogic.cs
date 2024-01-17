using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHRM.Core.Business.Logic
{
    /// <summary>
    /// Thông Liêu Cập nhật: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public class AllLogic
    {

        public static bool checkID(string table, string field, string value, string oldValue = "")
        {
            string sql = string.Format("Select Count(*) FROM {1} Where {0}='{2}' And {0}<>'{3}'", field, table, value, oldValue);
            var c = Provider.ExecSqlScalar(sql);

            return ((c as int?) ?? 0) == 0;
        }
        public static bool checkID(System.Data.DataRow dr, string field, string idField = "id")
        {
            string sql = string.Format("Select Count(*) FROM {0} Where {1}='{2}' And {3}<>'{4}'", dr.Table.TableName, field, dr[field], idField, dr[idField]);
            var c = Provider.ExecSqlScalar(sql);

            return ((c as int?) ?? 0) == 0;
        }


        public static DataTable ucSearch(string ProcName, string Keyword)
        {

            SqlConnection cnn = Provider.CreateConnection();
            SqlCommand cmd = new SqlCommand(ProcName, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("Keyword", Keyword));
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch
            {
                if (globall.indebug) throw;
            }
            finally
            {
                cnn.Close();
            }

            return new DataTable();
        }

        public static string SysPa_Get(string code)
        {
            return Provider.ExecuteScalar("p_SysPa_Get", new SqlParameter("Code", code)) as string;
        }
        public static void SysPa_Set(string code, string value)
        {
            Provider.ExecuteScalar("p_SysPa_Set", new SqlParameter("Code", code), new SqlParameter("Value", value));
        }

        public static string SaveData_Get(string code)
        {
            return Provider.ExecuteScalar("p_SaveData_Get", new SqlParameter("code", code)) as string;
        }
        public static void SaveData_Set(string code, string value)
        {
            Provider.ExecuteScalar("p_SaveData_Set", new SqlParameter("code", code), new SqlParameter("data", value));
        }

        public static string GenNextMa(string tableName, string colName, string preFix, bool useDatePrefix = true)
        {
            if (useDatePrefix)
                preFix += DateTime.Today.ToString("ddMMyy");

            object o = Provider.ExecuteScalar("p_GenNextMa",
                new SqlParameter("tableName", tableName),
                new SqlParameter("colName", colName),
                new SqlParameter("preFix", preFix)
            );

            if (Convert.IsDBNull(o) || o == null)
                return preFix + "00001";

            try
            {
                string s = o.ToString();
                return preFix + (Convert.ToInt32(s.Substring(preFix.Length)) + 1).ToString("00000");
            }
            catch
            {
                return preFix + "00001";
            }
        }

        public static bool DelInStatusById(string tableName, string colName, string value, string StatusColName = "status", int DelStatus = -1)
        {
            return (Provider.ExecuteScalar("p_DelInStatusById",
                new SqlParameter("tableName", tableName),
                new SqlParameter("colName", colName),
                new SqlParameter("value", value),
                new SqlParameter("StatusColName", StatusColName),
                new SqlParameter("DelStatus", DelStatus)
            ) as int?) > 0;
        }

        /// <summary>
        /// gán giá trị nhanh cho 1 trường
        /// </summary>
        /// <param name="tableName">tên bảng</param>
        /// <param name="colSelect">tên cột chọn</param>
        /// <param name="valueSelect">giá trị chọn</param>
        /// <param name="colName">tên cột muốn set giá trị</param>
        /// <param name="value">giá trị muốn sét</param>
        /// <returns></returns>
        public static bool SetAllValue(string tableName, string colSelect, string valueSelect, string colName, string value)
        {
            return (Provider.ExecuteScalar("p_SetAllValue",
                new SqlParameter("tableName", tableName),
                new SqlParameter("colSelect", colSelect),
                new SqlParameter("valueSelect", valueSelect),
                new SqlParameter("colName", colName),
                new SqlParameter("value", value)
            ) as int?) > 0;
        }
        public static bool checkEmployeeIDInDep(string employeeID, int? depID)
        {
            if (depID == null)
            {
                return true;
            }
            var a = Provider.ExecuteScalar("p_checkEmployeeIDInDep",
                new SqlParameter("employeeID", employeeID),
                new SqlParameter("depID", depID)
                );
            return a != null;
        }

        public static bool checkDkSuaCong(string employeeID, DateTime ngay, int add)
        {
            var b = Provider.ExecuteScalar("p_checkDkSuaCong",
                new SqlParameter("employeeID", employeeID),
                new SqlParameter("ngay", ngay),
                 new SqlParameter("add", add)
                );
            return b != null;
        }

        public static bool checkDkLamThem_KhoaDK(string employeeID, DateTime ngay)
        {
            var b = Provider.ExecuteScalar("checkDkLamThem_KhoaDK",
                new SqlParameter("employeeID", employeeID),
                new SqlParameter("ngay", ngay)
                );
            return b != null;
        }

        public static bool insert_YeuCauSuaCong(String empID, DateTime ngay, DateTime ngayYC, TimeSpan gioVao_Request, TimeSpan gioRa_Request, bool isCheck, String ghiChu, String idFile, long? userID) //Thong Lieu: '19-12-2018'
        {
            if (idFile.ToString() == "" || idFile == null)
            {
                var b = Provider.ExecuteScalar("p_chamcong_tbRequestEditAttendane_v1",
                                            new SqlParameter("@employeeID", empID),
                                            new SqlParameter("@ngay", ngay),
                                            new SqlParameter("@ngayYeuCau", ngayYC),
                                            new SqlParameter("@gioVao_Request", gioVao_Request),
                                            new SqlParameter("@gioRa_Request", gioRa_Request),
                                            new SqlParameter("@isCaDemTrongNgay", isCheck),
                                            new SqlParameter("@ghiChu", ghiChu),
                                            new SqlParameter("@idFile", DBNull.Value),
                                            new SqlParameter("@idUserRequest", userID)
                                            );
                return b != null;
            }
            else
            {
                var b = Provider.ExecuteScalar("p_chamcong_tbRequestEditAttendane_v1",
                                            new SqlParameter("@employeeID", empID),
                                            new SqlParameter("@ngay", ngay),
                                            new SqlParameter("@ngayYeuCau", ngayYC),
                                            new SqlParameter("@gioVao_Request", gioVao_Request),
                                            new SqlParameter("@gioRa_Request", gioRa_Request),
                                            new SqlParameter("@isCaDemTrongNgay", isCheck),
                                            new SqlParameter("@ghiChu", ghiChu),
                                            new SqlParameter("@idFile", Guid.Parse(idFile)),
                                            new SqlParameter("@idUserRequest", userID)
                                            );
                return b != null;
            }
        }
    }
}
