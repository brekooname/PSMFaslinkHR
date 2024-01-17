using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSV.Business
{
    public class AllLogic
    {
        public static string getMaxID(string table, string field, string prefix = "")
        {
            string sql = string.Format("Select MAX({0}) FROM {1} Where {0} like '{2}%'", field, table, prefix);
            var c = ADOController.ExeGetValue(sql);

            return Convert.ToString(c);
        }
        public static bool checkHasField(string table, string field, string value)
        {
            string sql = string.Format("Select Count(*) FROM {1} Where {0}='{2}'", field, table, value);
            var c = ADOController.ExeGetValue(sql);

            return ((c as int?) ?? 0) > 0;
        }
        public static bool checkID(string table, string field, string value, string oldValue = "")
        {
            string sql = string.Format("Select Count(*) FROM {1} Where {0}='{2}' And {0}<>'{3}'", field, table, value, oldValue);
            var c = ADOController.ExeGetValue(sql);

            return ((c as int?) ?? 0) == 0;
        }
        public static bool checkID(System.Data.DataRow dr, string field, string idField = "id")
        {
            string sql = string.Format("Select Count(*) FROM {0} Where {1}='{2}' And {3}<>'{4}'", dr.Table.TableName, field, dr[field], idField, dr[idField]);
            var c = ADOController.ExeGetValue(sql);

            return ((c as int?) ?? 0) == 0;
        }
    }
}
