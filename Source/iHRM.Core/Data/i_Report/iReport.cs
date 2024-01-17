using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHRM.Core.i_Report
{
    public class iReport
    {
        public String StoredName { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public List<String> ListEmp { get; set; }
        public DataTable Data { get; set; }
        public iReport()
        {
            StoredName = "";

            ToDate = new DateTime();

            FromDate = new DateTime();

            ListEmp = new List<String>();

            Data = new DataTable();
        }
    }
}
