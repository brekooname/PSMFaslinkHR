using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncSV.Cls
{
    public class enums
    {
        public enum eFormAttackMode { None, View, Add, Edit }

        public enum TrangThaiUser { KoKichHoat, KichHoat }
        public static Dictionary<TrangThaiUser, string> TrangThaiUser_Alias = new Dictionary<TrangThaiUser, string>()
        {
            {TrangThaiUser.KichHoat, "Đã kích hoạt"},
            {TrangThaiUser.KoKichHoat, "Không kích hoạt"}
        };

        public enum GioiTinh { Chon, Nam, Nu}
        public static Dictionary<GioiTinh, string> GioiTinh_Alias = new Dictionary<GioiTinh, string>()
        {
            {GioiTinh.Chon, "Chọn"},
            {GioiTinh.Nam, "Nam"},
            {GioiTinh.Nu, "Nữ"}
        };

    }
}
