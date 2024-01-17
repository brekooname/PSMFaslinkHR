using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iHRM.Core.Business.Logic.Report
{
    public class BaoCao : LogicBase
    {
        public VirtualPagingInfo VirtualPaging
        {
            get { return _VirtualPaging; }
            set { _VirtualPaging = value; }
        }
        public BaoCao()
            : base("tblEmployee")
        {
            _VirtualPaging = new VirtualPagingInfo();
        }
        public DataTable GetReportChuhat(DateTime date, DateTime today, string empID = null, string DepID = null)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetReportChuhat",
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", today),
                new SqlParameter("depID", DepID),
                new SqlParameter("empID", empID)
            );
        }
        public DataTable GetReportQuetTheByDate(DateTime date, DateTime today, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetReportQuetTheByDate",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", today)
            );
        }
        public DataTable GetReportNhanVienNuoiConNho(DateTime date, DateTime todate, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_NhanVienNuoiConNho",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("tungay", date),
                new SqlParameter("denngay", todate)
            );
        }
        public DataTable GetReportNhanVienThaiThangThu7(DateTime date, DateTime todate, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_NhanVienThaiThangThu7",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("tungay", date),
                new SqlParameter("denngay", todate)
            );
        }

        public DataTable GetReportNhanVienNghiThaiSan(DateTime date, DateTime todate, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_NhanVienNghiThaiSan",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("tungay", date),
                new SqlParameter("denngay", todate)
            );
        }

        public DataTable GetReportNhanVienVangMat(DateTime date, DateTime todate, List<string> listEmpID, string LoaiNghi)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_NhanVienVangMat",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("loainghi", LoaiNghi),
                new SqlParameter("tungay", date),
                new SqlParameter("denngay", todate)
            );
        }
        public DataTable GetReportMonth(DateTime date, DateTime todate, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetReportMonth",
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", todate),
                Provider.CreateParameter_StringList("dtEmpID", listEmpID)
            );
        }
        public DataTable GetReportCaLamMonth(DateTime date, DateTime todate, List<string> dtEmpID, string DepID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetReportCaLamMonth",
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", todate),
                new SqlParameter("DepID", DepID),
                Provider.CreateParameter_StringList("dtEmpID", dtEmpID)
            );
        }
        public DataTable GetReportTangCa6H(DateTime date, DateTime todate, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetReportTangCa6H",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", todate)
            );
        }
        public DataTable GetReportThongKePhepNam(string DepID = null)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_ThongKePhepNam",
                new SqlParameter("depID", DepID)
            );
        }
        public DataTable GetReportOvertime(DateTime date, DateTime todate, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_GetDataReportOvertimeForm",
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", todate),
                Provider.CreateParameter_StringList("dtEmpID", listEmpID)
            );
        }
        public DataTable GetReportNVSapHetHopDong(DateTime tuNgay, DateTime denNgay, List<string> _lEmpID, Boolean chkHdCuoi = false)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetNV_HetHopDong",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                Provider.CreateParameter_StringList("dtEmpID", _lEmpID),
                new SqlParameter("hdCuoi", chkHdCuoi)
            );
        }
        public DataTable GetReportNVKoDiLamLonHon14(DateTime tuNgay, DateTime denNgay)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetNV_KoDiLamLonHon14",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public int GetReportNVKoDiLamLonHon14_Count(DateTime tuNgay, DateTime denNgay)
        {
            return (int)Provider.ExecuteScalar("p_BaoCao_GetNV_KoDiLamLonHon14_Count",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetReportNVThayDoiMucLuong(DateTime tuNgay, DateTime denNgay, string DepID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetNV_NVThayDoiMucLuong",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("depID", DepID)
            );
        }
        public int GetReportNVSapHetHopDong_Count(DateTime date, string DepID = null, Boolean chkHdCuoi = false)
        {
            return (int)Provider.ExecuteScalar("p_BaoCao_GetNV_HetHopDong_Count",
                new SqlParameter("ThoiGianTinh", date),
                new SqlParameter("depID", DepID),
                new SqlParameter("hdCuoi", chkHdCuoi)
            );
        }
        public int GetReportNVHetHanNghiThaiSan_Count(DateTime ngayHienTai, string DepID = "", int soNgay = 7)
        {
            return (int)Provider.ExecuteScalar("p_BaoCao_getNV_HetHanThaiSan_Count",
                new SqlParameter("MaPB", DepID),
                new SqlParameter("NgayHienTai", ngayHienTai),
                new SqlParameter("soNgay", soNgay)
            );
        }
        public DataTable GetReportNVHetHanNghiThaiSan(DateTime ngayHienTai, List<string> listEmpID, int soNgay = 7)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_getNV_HetHanThaiSan",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("NgayHienTai", ngayHienTai),
                new SqlParameter("soNgay", soNgay)
            );
        }
        public DataTable GetReportTuanThaiSan(DateTime ngayHienTai, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_getNV_TuanThaiSan",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("NgayHienTai", ngayHienTai)
            );
        }
        public DataTable GetReportNVDuoi18Tuoi(DateTime date, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetNV_Duoi18Tuoi",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("ThoiGianTinh", date)
            );
        }
        public DataTable getDataDSHopDong(string EmpID, string DepID, DateTime TuNgay, DateTime DenNgay, string strHopDong)
        {
            return Provider.ExecuteDataTableReader("p_Report_getDataDSHopDong", new SqlParameter[]{
                new SqlParameter("EmpID",EmpID),
                new SqlParameter("DepID",DepID),
                new SqlParameter("TuNgay",TuNgay),
                new SqlParameter("DenNgay",DenNgay),
                new SqlParameter("strHopDong",strHopDong)
            });
        }
        public DataTable GetReportNhanVien(DateTime date, DateTime todate, List<string> listEmpID, string strNghiVaoLam = "tatca", string strGioiTinh = "tatca")
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetReportNhanVien",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", todate),
                new SqlParameter("strNghiVaoLam", strNghiVaoLam),
                new SqlParameter("strGioitinh", strGioiTinh)
            );
        }
        public DataTable GetReportTotalHours(DateTime date, DateTime todate, List<string> listEmpID)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetReportTotalHours",
                Provider.CreateParameter_StringList("dtEmployeeID", listEmpID),
                new SqlParameter("tungay", date),
                new SqlParameter("denngay", todate)
            );
        }
        public DataTable GetReportquetTheMonth(DateTime date, DateTime todate, List<string> _lEmpID)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetReportQuetTheByMonth",
               new SqlParameter("tuNgay", date),
               new SqlParameter("denNgay", todate),
               Provider.CreateParameter_StringList("dtEmpID", _lEmpID)
           );
        }
        public DataTable GetReportquetTheMonth_Fake(DateTime date, DateTime todate, List<string> _lEmpID)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetReportQuetTheByMonth_Fake",
               new SqlParameter("tuNgay", date),
               new SqlParameter("denNgay", todate),
               Provider.CreateParameter_StringList("dtEmpID", _lEmpID)
           );
        }
        public DataTable GetReportquetTheGoc(DateTime date, DateTime todate, string DepID = null, string empID = null)
        {

            SqlConnection cnn = Provider.CreateConnection();
            SqlCommand cmd = new SqlCommand("p_chamcong_GetReportQuetTheGoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@tuNgay", date));
            cmd.Parameters.Add(new SqlParameter("@todate", todate));
            cmd.Parameters.Add(new SqlParameter("@depID", DepID));
            cmd.Parameters.Add(new SqlParameter("@empID", empID));
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

        public DataTable GetReportDuLieuChamCong(DateTime date, DateTime todate, List<string> dtEmpID, string NoNV)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetReportChamCong",
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", todate),
                new SqlParameter("NoNV", NoNV),
                Provider.CreateParameter_StringList("dtEmpID", dtEmpID)
            );
        }
        public DataTable GetReportDuLieuChamCongFail(DateTime date, DateTime todate, List<string> dtEmpID, string NoNV)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetReportChamCong_Fail",
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", todate),
                new SqlParameter("NoNV", NoNV),
                Provider.CreateParameter_StringList("dtEmpID", dtEmpID)
                );
        }
        public DataTable GetUngVienPhongVanTrongNgay()
        {
            return Provider.ExecuteDataTableReader("p_tblUngVienSoBO_GetPhongVan");
        }

        public DataTable GetDuLieuNhanVienChamCong(DateTime date, DateTime todate, List<string> dtEmpID)
        {
            return Provider.ExecuteDataTableReader("p_BaoCao_GetDuLieuNhanVienChamCong",
                new SqlParameter("tuNgay", date),
                new SqlParameter("denNgay", todate),
                Provider.CreateParameter_StringList("dtEmpID", dtEmpID)
            );
        }

    }
}