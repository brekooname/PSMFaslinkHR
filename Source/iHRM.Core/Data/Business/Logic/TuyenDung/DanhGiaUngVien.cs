using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.TuyenDung
{
    public class DanhGiaUngVien : LogicBase
    {        
        public VirtualPagingInfo VirtualPaging
        {
            get { return _VirtualPaging; }
            set { _VirtualPaging = value; }
        }

        public DanhGiaUngVien()
            : base("tblUV_DanhGia")
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
