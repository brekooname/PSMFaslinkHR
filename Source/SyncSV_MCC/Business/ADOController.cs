using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SyncSV.Business
{
    public class ADOController
    {
        private static string _strcnn = null;
        public static string strcnn
        {
            get
            {
                if (_strcnn == null)
                    _strcnn = Frm.Common.frmCauHinh.buildcauhinh(Properties.Settings.Default.strcnn);
                return _strcnn;
            }
            set
            {
                _strcnn = value;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu vào DataBase.
        /// </summary>
        /// <returns>True: cập nhật thành công; False: cập nhật thất bại</returns>
        /// <author>Lttung - Một ngày đẹp trời năm 2011</author>
        public static bool UpdateData(DataSet dataset, string tableName)
        {
            if (dataset.Tables[tableName].GetChanges() == null)
                return false;


            bool blnResult = false;
            SqlConnection cnn = new SqlConnection(strcnn);
            SqlCommand cmd = cnn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            try
            {
                cmd.CommandText = "SELECT * FROM " + tableName;
                cb.ConflictOption = ConflictOption.OverwriteChanges;
                blnResult = da.Update(dataset, tableName) > 0;
            }
            catch
            {
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
            return blnResult;
        }

        /// <summary>
        /// Nạp dữ liệu.
        /// </summary>
        /// <author>Lttung - Một ngày đẹp trời năm 2011</author>
        public static void LoadData(DataSet dataset, string tableName, string sWhere = "")
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            SqlCommand cmd = cnn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                if (!string.IsNullOrEmpty(sWhere) && sWhere.IndexOf("where", StringComparison.CurrentCultureIgnoreCase) == -1)
                    sWhere = " WHERE " + sWhere;
                cmd.CommandText = "SELECT * FROM " + tableName + " " + sWhere;
                da.Fill(dataset, tableName);
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }

        public static void LoadDataBySql(DataSet dataset, string tableName, string sql)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            SqlCommand cmd = cnn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                cmd.CommandText = sql;
                da.Fill(dataset, tableName);
            }
            finally
            {
                cnn.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }

        public static int ExeNoneQuery(string sql, params SqlParameter[] pa)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            if (pa != null && pa.Length > 0)
                cmd.Parameters.AddRange(pa);
            try
            {
                cnn.Open();
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }

        public static DataTable ExeQuery(string sql, params SqlParameter[] pa)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            if (pa != null && pa.Length > 0)
                cmd.Parameters.AddRange(pa);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                return dt;
            }
            finally
            {
                cnn.Close();
            }
        }

        public static DataTable ExeQueryGetInfo(string sql, out string msg, out int rowAffect)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            StringBuilder sbMsg = new StringBuilder();
            cnn.InfoMessage += (object obj, SqlInfoMessageEventArgs e) => { sbMsg.AppendLine(e.Message); };
            try
            {
                da.Fill(dt);

                cmd.CommandText = "SELECT @@ROWCOUNT";
                DataTable dt2 = new DataTable();
                da.Fill(dt2);

                rowAffect = int.Parse("0" + dt2.Rows[0][0]);
                if (rowAffect == 0)
                    rowAffect = dt.Rows.Count;
                msg = sbMsg.ToString();
                return dt;
            }
            finally
            {
                cnn.Close();
            }
        }

        public static DataTable ExeProcedure(string procName, params SqlParameter[] pa)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            SqlCommand cmd = new SqlCommand(procName, cnn);
            if (pa != null && pa.Length > 0)
                cmd.Parameters.AddRange(pa);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                return dt;
            }
            finally
            {
                cnn.Close();
            }
        }
        public static int ExeProcedureNoneQuery(string procName, out string messages, params SqlParameter[] pa)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            SqlCommand cmd = new SqlCommand(procName, cnn);
            StringBuilder sbMsg = new StringBuilder();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(pa);
            cnn.InfoMessage += (object obj, SqlInfoMessageEventArgs e) => { sbMsg.AppendLine(e.Message); };
            try
            {
                cnn.Open();
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
                messages = sbMsg.ToString();
            }
        }

        public static object ExeGetValue(string sql)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                    return null;

                return dt.Rows[0][0];
            }
            finally
            {
                cnn.Close();
            }
        }

        public static bool CheckIdAvalidable(string TableName, string ColumnName, string Value, string OldValue = "", string IdColumn = "")
        {
            string sql = string.Format("SELECT TOP 1 {1} FROM {0} WHERE {1} = '{2}' {3}",
                TableName,
                ColumnName,
                Value,
                (string.IsNullOrWhiteSpace(OldValue) ? "" : string.Format(" AND {0} != '{1}'", IdColumn == "" ? ColumnName : IdColumn, OldValue))
            );
            DataTable dt = ExeQuery(sql);
            return dt.Rows.Count == 0;
        }
    }
}