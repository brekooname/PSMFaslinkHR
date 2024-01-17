using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Common.Code
{
    public class Enums
    {

        public enum eFunction { Custom = 0, Find = 1, New = 2, Edit = 4, Delete = 8, Import = 16, Export = 32, Print = 64, Choose = 128, Save = 256, Exit = 512 }
        public static Dictionary<int, string> elTrangThaiTD = new Dictionary<int, string>() {
            { 0, "Lên kế hoạch" },
            { 1, "Đang thực hiện"},
            { 2, "Đã kết thúc" }
        };
        public enum eStatus { None = 0, KichHoat = 1, KhongKichHoat = 2 }
        public static Dictionary<eStatus, string> eStatus_Alias = new Dictionary<eStatus, string>()
        {
            {eStatus.KichHoat, "Kích hoạt" },
            {eStatus.KhongKichHoat, "Không kích hoạt" }

        };

        public enum eTTLoaiQuetThe { None = 0, VaoKhongRa = 1, RaKhongVao = 2, NhieuLanVaoRA = 3, MotLanVaoRa = 4, All = 5 }
        public static Dictionary<eTTLoaiQuetThe, string> eTTLoaiQuetThe_Alias = new Dictionary<eTTLoaiQuetThe, string>()
        {
            {eTTLoaiQuetThe.None, "Không quẹt" },
            {eTTLoaiQuetThe.VaoKhongRa, "Vào - không ra" },
            {eTTLoaiQuetThe.RaKhongVao, "Ra - Không vào" },
            {eTTLoaiQuetThe.NhieuLanVaoRA, "Nhiều lần vào - ra" },
            {eTTLoaiQuetThe.MotLanVaoRa, "Một lần Vào -Ra" },
            {eTTLoaiQuetThe.All, "Tất cả" },


        };


        //Please do not change,,, it fixed in sql statement
        /// <summary>
        /// Các lý do xin nghỉ
        /// </summary>
        public enum eLyDoNghi
        {
            NghiPhepNam = 1,
            KetHon = 2,
            MaChay = 3,
        }
        public static Dictionary<int, string> LyDoNghi_CodeAlias = new Dictionary<int, string>()
        {
            { (int)eLyDoNghi.NghiPhepNam, "PN" }, //ldNghiPhepNam
            { (int)eLyDoNghi.KetHon, "KH" }, //ldKetHon
            { (int)eLyDoNghi.MaChay, "TC" }, //ldMaChay
        };
        public enum KhoiPhongBan_Alias
        {
            KhoiDuAn = 2,
            KhoiVanPhong = 3,
            KhoiVanTai = 9,
            KhoiKho = 12
        };


        public enum eTTVayVon
        {
            taoMoi = 0,
            daDuyet = 1,
            daHoanThanh = 2,
            daThanhLy = 3,
            daHuy = -1
        };
        public static Dictionary<int, string> eTTVayVon_Alias = new Dictionary<int, string>()
        {
            { (int)eTTVayVon.taoMoi, "Chờ duyệt" }, 
            { (int)eTTVayVon.daDuyet, "Đã duyệt" }, 
            { (int)eTTVayVon.daHoanThanh, "Đã hoàn thành" }, 
            { (int)eTTVayVon.daThanhLy, "Đã thanh lý" }, 
            { (int)eTTVayVon.daHuy, "Đã hủy" }
        };
    }
}