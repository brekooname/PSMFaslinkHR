using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class calam : LogicBase
    {
        public calam() : base(TableConst.tbCaLamViec.TableName) { }

        public DataTable GetAllCaLam()
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetCaLam");
        }
        public DataTable GetData(string empID, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData",
                new SqlParameter("empID", empID),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetDataDangKy7Hours(List<string> _lempID, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            return Provider.ExecuteDataTable("p_chamcong_getDataDangKy7Hours",
                Provider.CreateParameter_StringList("dtEmpID", _lempID),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }
        public DataTable GetDataDangKyCaLam(string empID = null, DateTime? tuNgay = null, DateTime? denNgay = null, string depID = null)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData_DangKyCaLam",
                new SqlParameter("empID", empID),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("depID", depID)
            );
        }

        public DataTable GetDataDangKyLamThem(string empID = null, DateTime? tuNgay = null, DateTime? denNgay = null, string depID = null)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData_DangKyLamThem",
                new SqlParameter("empID", empID),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("depID", depID)
            );
        }

        public DataTable GetDataDangKyVangMat(List<string> _lEmpID, DateTime? tuNgay = null, DateTime? denNgay = null, bool? isAccept = null, int coHuongLuong = 0, string DepID = "")
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData_DangKyVangMat",
                Provider.CreateParameter_StringList("dtEmpID", _lEmpID),
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("isAccept", isAccept),
                new SqlParameter("coHuongLuong", coHuongLuong)
            );
        }
        public Base.ExecuteResult DangKyTangCa_KhongQuet(string empID, DateTime ngay, DateTime ngayYeuCau, TimeSpan? tuGio = null, TimeSpan? denGio = null, long? idUserRequest = null, string loaiDK = "", string ghiChu = "", byte[] datafileChoised = null, string duoiFile = null)
        {
            return Provider.ExecuteNonQuery("p_chamcong_CaNhan_DangKyTangCa_KhongQuet",
                new SqlParameter("empID", empID),
                new SqlParameter("ngay", ngay),
                new SqlParameter("@ngayYeuCau", ngayYeuCau),
                new SqlParameter("@tuGio", tuGio),
                new SqlParameter("@denGio", denGio),
                new SqlParameter("@idUserRequest", idUserRequest),
                new SqlParameter("@loaiDangKy", loaiDK),
                new SqlParameter("@ghiChu", ghiChu),
                new SqlParameter("@datafileChoised", datafileChoised),
                new SqlParameter("@duoiFile", duoiFile)
            );
        }
        public Base.ExecuteResult DangKyCaLam(string empID, DateTime ngay, Guid idCaLam, int? dkLamThem = null, int? hsLuong = null, long? userRequest = null, string soQD = null, byte[] datafileChoised = null, string duoiFile = null,bool? isDkTuGioDenGio = null, bool? isCaDem = null, TimeSpan? CaSang_TuGio = null, TimeSpan? CaSang_DenGio = null, TimeSpan? CaChieu_TuGio = null, TimeSpan? CaChieu_DenGio = null, double? soTiengTinhCa = null)
        {
            return Provider.ExecuteNonQuery("p_chamcong_CaNhan_DangKyCaLam",
                new SqlParameter("empID", empID),
                new SqlParameter("ngay", ngay),
                new SqlParameter("idCaLam", idCaLam),
                new SqlParameter("dkLamThem", dkLamThem),
                new SqlParameter("hsLuong", hsLuong),
                new SqlParameter("userRequest", userRequest),
                new SqlParameter("soQD", soQD),
                new SqlParameter("datafileChoised", datafileChoised),
                new SqlParameter("duoiFile", duoiFile),
                new SqlParameter("isDkTuGioDenGio", isDkTuGioDenGio),
                new SqlParameter("isCaDem", isCaDem),
                new SqlParameter("CaSang_TuGio", CaSang_TuGio),
                new SqlParameter("CaSang_DenGio", CaSang_DenGio),
                new SqlParameter("CaChieu_TuGio", CaChieu_TuGio),
                new SqlParameter("CaChieu_DenGio", CaChieu_DenGio),
                new SqlParameter("soTiengTinhCa", soTiengTinhCa)
            );
        }

        public Base.ExecuteResult DangKyCaLam7Hours(string empID, DateTime? RegistedDate, DateTime? BeginDate, DateTime? EndDate, int? isLate, DateTime? ChildDate = null)
        {
            return Provider.ExecuteNonQuery("p_chamcong_CaNhan_DangKyCaLam7Hours",
                new SqlParameter("EmployeeID", empID),
                new SqlParameter("RegistedDate", RegistedDate),
                new SqlParameter("BeginDate", BeginDate),
                new SqlParameter("EndDate", EndDate),
                new SqlParameter("ChildDate", ChildDate),
                new SqlParameter("isLate", isLate)
            );
        }

        public Base.ExecuteResult DangKyTangCa(string empID, DateTime ngay, DateTime ngayYeuCau, TimeSpan? tuGio = null, TimeSpan? denGio = null, long? idUserRequest = null, string loaiDK = "", string ghiChu = "", byte[] datafileChoised = null, string duoiFile = null)
        {
            return Provider.ExecuteNonQuery("p_chamcong_CaNhan_DangKyTangCa",
                new SqlParameter("empID", empID),
                new SqlParameter("ngay", ngay),
                new SqlParameter("@ngayYeuCau", ngayYeuCau),
                new SqlParameter("@tuGio", tuGio),
                new SqlParameter("@denGio", denGio),
                new SqlParameter("@idUserRequest", idUserRequest),
                new SqlParameter("@loaiDangKy", loaiDK),
                new SqlParameter("@ghiChu", ghiChu),
                new SqlParameter("@datafileChoised", datafileChoised),
                new SqlParameter("@duoiFile", duoiFile)
            );
        }

        public Base.ExecuteResult DangKyRaVao(string empID, DateTime ngay, DateTime ngayYeuCau, TimeSpan? tuGio = null, TimeSpan? denGio = null, long? idUserRequest = null, string loaiDK = "", string ghiChu = "", byte[] datafileChoised = null, string duoiFile = null)
        {
            return Provider.ExecuteNonQuery("p_chamcong_CaNhan_DangKyRaVao",
                new SqlParameter("empID", empID),
                new SqlParameter("ngay", ngay),
                new SqlParameter("@ngayYeuCau", ngayYeuCau),
                new SqlParameter("@tuGio", tuGio),
                new SqlParameter("@denGio", denGio),
                new SqlParameter("@idUserRequest", idUserRequest),
                new SqlParameter("@loaiDangKy", loaiDK),
                new SqlParameter("@ghiChu", ghiChu),
                new SqlParameter("@datafileChoised", datafileChoised),
                new SqlParameter("@duoiFile", duoiFile)
            );
        }

        public DataRow checkNV(string empID, string idKhoiPB = null)
        {
            empID = empID.Trim(' ', '\n', '\r', '\t');
            return Provider.ExecuteDataRow("p_chamcong_checkNV",
                new SqlParameter("empID", empID),
                 new SqlParameter("idKhoiPB", idKhoiPB)
                );
        }
        public DataRow checkPB(string depID)
        {
            depID = depID.Trim(' ', '\n', '\r', '\t');
            return Provider.ExecuteDataRow("p_chamcong_checkPB", new SqlParameter("depID", depID));
        }


        #region dk ca mac dinh
        public DataTable GetDataDKCaMacDinh(string empID = null, string depID = null)
        {
            return Provider.ExecuteDataTableReader("p_chamcong_GetData_DKCaMacDinh",
                new SqlParameter("empID", empID),
                new SqlParameter("depID", depID)
            );
        }
        public int DKCaMacDinh_DKnhom1(int idNhom1, Guid idCaLam, int? heSoLuong = null, bool chuNhat = false)
        {
            return Provider.ExecNoneQuery("p_chamcong_CaNhan_DKCaMacDinh_DKnhom1",
                new SqlParameter("idNhom1", idNhom1),
                new SqlParameter("idCaLam", idCaLam),
                new SqlParameter("heSoLuong", heSoLuong),
                new SqlParameter("chuNhat", chuNhat)
            );
        }

        public int DKCaMacDinh_DKtapThe(string maTapThe, Guid idCaLam, int? heSoLuong = null, bool chuNhat = false)
        {
            return Provider.ExecNoneQuery("p_chamcong_CaNhan_DKCaMacDinh_DKtapThe",
                new SqlParameter("maTapThe", maTapThe),
                new SqlParameter("idCaLam", idCaLam),
                new SqlParameter("heSoLuong", heSoLuong),
                new SqlParameter("chuNhat", chuNhat)
            );
        }
        #endregion
    }
}
