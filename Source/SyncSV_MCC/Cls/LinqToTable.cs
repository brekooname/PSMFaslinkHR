using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyncSV.Cls
{
    public class LinqToTable
    {
        public static System.Data.DataTable LinqToDataTable<T>(System.Collections.Generic.IEnumerable<T> varlist)
        {
            try
            {
                System.Data.DataTable dtReturn = new System.Data.DataTable();
                System.Reflection.PropertyInfo[] oProps = null;
                if (varlist == null) return dtReturn;
                foreach (T rec in varlist)
                {
                    if (oProps == null)
                    {
                        oProps = ((Type)rec.GetType()).GetProperties();
                        foreach (System.Reflection.PropertyInfo pi in oProps)
                        {
                            Type colType = pi.PropertyType;
                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                            == typeof(Nullable<>)))
                            {
                                colType = colType.GetGenericArguments()[0];
                            }
                            dtReturn.Columns.Add(new System.Data.DataColumn(pi.Name, colType));
                        }
                    }
                    System.Data.DataRow dr = dtReturn.NewRow();
                    foreach (System.Reflection.PropertyInfo pi in oProps)
                    {
                        dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value :
                        pi.GetValue(rec, null);
                    }
                    dtReturn.Rows.Add(dr);
                }
                return dtReturn;
            }
            catch { return null; }
        }
    }
}