using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Win.Cls
{
    public class CacheDataTable
    {
        public static DataSet ds = new DataSet();

        public static DataTable GetCacheDataTable(string TableName)
        {
            if (!ds.Tables.Contains(TableName))
            {
                var dt = Core.Business.Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM [{0}]", TableName));
                dt.TableName = TableName;
                ds.Tables.Add(dt);
            }

            return ds.Tables[TableName];
        }

        public static DataTable GetCacheDataTable_Dep(string TableName)
        {
            if (!ds.Tables.Contains(TableName))
            {
                var dt = Core.Business.Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM [{0}] ORDER BY CONVERT(INT, DepID)", TableName));
                dt.TableName = TableName;
                ds.Tables.Add(dt);
            }

            return ds.Tables[TableName];
        }

        public static void ResetCacheOnTable(string TableName)
        {
            if (ds.Tables.Contains(TableName))
                ds.Tables.Remove(TableName);
        }
    }
}
