using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHRM.Common.DungChung
{
    public static class Ham
    {
        /// <summary>
        /// đếm số ngày công (trừ chủ nhật)
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static int DemNgayCong(DateTime startDate, DateTime endDate)
        {
            int c = 0;
            while (startDate <= endDate)
            {
                if (startDate.DayOfWeek != DayOfWeek.Sunday)
                    c += 1;

                startDate = startDate.AddDays(1);
            }
            return c;
        }
        public static DateTime GetTuNgay(DateTime d)
        {
            return (new DateTime(d.Year, d.Month, d.Day, 0, 0, 0));
        }
        public static DateTime GetDenNgay(DateTime d)
        {
            return (new DateTime(d.Year, d.Month, d.Day, 23, 59, 59));
        }
    }
}
