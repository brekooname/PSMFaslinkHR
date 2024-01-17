using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class ReportMonthLogic
    {
        public DataTable GetReportMonth(DateTime tuNgay, DateTime denNgay, List<string> dtEmpID, string DepID)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetReportMonth_byList",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                 new SqlParameter("DepID", DepID),
                Provider.CreateParameter_StringList("dtEmpID", dtEmpID)
            );
        }public DataTable GetReportMonth_Fake(DateTime tuNgay, DateTime denNgay, List<string> dtEmpID, string DepID)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetReportMonth_Fake_byList",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                 new SqlParameter("DepID", DepID),
                Provider.CreateParameter_StringList("dtEmpID", dtEmpID)
            );
        }
        public DataTable GetReportQuetTheByDate(DateTime date, string DepID = null)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetReportQuetTheByDate",
                new SqlParameter("Ngay", date),

                new SqlParameter("DepartmentID", DepID)
            );
        }
        public static int UpdateReportMonth(Guid id, TimeSpan? tgQuetDen, TimeSpan? tgQuetVe, int? tgDiMuon, int? tgVeSom,
            double kqNgayCong, double tgTinhTangCa,
            int tt_ok, int tt_diMuonVeSom, int tt_nghiPhep, int tt_coQuetTay, bool tt_chuNhat)
        {
            return Provider.ExecNoneQuery("p_chamcong_UpdateReportMonth",
                new SqlParameter("id", id),
                new SqlParameter("tgQuetDen", tgQuetDen),
                new SqlParameter("tgQuetVe", tgQuetVe),
                new SqlParameter("tgDiMuon", tgDiMuon),
                new SqlParameter("tgVeSom", tgVeSom),
                new SqlParameter("tt_ok", tt_ok),
                new SqlParameter("tt_diMuonVeSom", tt_diMuonVeSom),
                new SqlParameter("tt_nghiPhep", tt_nghiPhep),
                new SqlParameter("tt_coQuetTay", tt_coQuetTay),
                new SqlParameter("tt_chuNhat", tt_chuNhat),
                new SqlParameter("kqNgayCong", kqNgayCong),
                new SqlParameter("tgTinhTangCa", tgTinhTangCa)
            );
        }

    }
}
