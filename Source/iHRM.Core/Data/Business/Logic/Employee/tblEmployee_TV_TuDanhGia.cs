using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Employee
{
    public class tblEmployee_TV_TuDanhGia : LogicBase
    {        
        public VirtualPagingInfo VirtualPaging
        {
            get { return _VirtualPaging; }
            set { _VirtualPaging = value; }
        }

        public tblEmployee_TV_TuDanhGia()
            : base("tblEmployee_TV_TuDanhGia")
        {
            _VirtualPaging = new VirtualPagingInfo();
        }
        
        //public virtual DataTable getEmployeeByDepID(string depID = null)
        //{
        //    return Provider.ExecuteDataTable("p_getAllKeHoachTuyenDung",
        //        new SqlParameter("depID", depID)
        //    );
        //}

    }
}
