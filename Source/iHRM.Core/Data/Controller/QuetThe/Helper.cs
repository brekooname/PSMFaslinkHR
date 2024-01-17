using iHRM.Common.Code;
using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace iHRM.Core.Controller.QuetThe
{
    public class Helper
    {
        public static DateTime GetStartDateSalaryCycle
        {
            get
            {
                var d = DateTime.Today;
                return new DateTime(d.Year, d.Month, 17).AddMonths(-1);
            }
        }

        public static string GetTrangThai(DataRow dr, int type = 1, bool isWinform = false)
        {
            bool? tt_leTet = DbHelper.DrGetBoolean(dr, "tt_leTet");
            int? dkLamThem = DbHelper.DrGetInt(dr, "dkLamThem");
            int tt_diMuonVeSom = DbHelper.DrGetInt(dr, "tt_diMuonVeSom");
            int tt_nghiPhep = DbHelper.DrGetInt(dr, "tt_nghiPhep");
            string tt_nghiPhep_Alias = DbHelper.DrGetString(dr, "tt_nghiPhep_Alias");
            int PerTimeID = DbHelper.DrGetInt(dr, "PerTimeID");
            int tt_coQuetTay = DbHelper.DrGetInt(dr, "tt_coQuetTay");
            bool tt_chuNhat = DbHelper.DrGetBoolean(dr, "tt_chuNhat") ?? false;
            double kqNgayCong = DbHelper.DrGetFloat(dr, "kqNgayCong");
            double tgTinhTangCa = DbHelper.DrGetFloat(dr, "tgTinhTangCa");
            double WorkingHours = DbHelper.DrGetFloat(dr, "WorkingHours");

            bool is7Hours = DbHelper.DrGetBoolean(dr, "is7Hours") ?? false;
            bool isPhepTreSom = DbHelper.DrGetBoolean(dr, "isPhepTreSom") ?? false;

            string s = "";
            if (isPhepTreSom)
                s = "PT";
            if (WorkingHours > 0)
                s = s + string.Format("{0:0.##}", is7Hours == true  && WorkingHours == 7 ? WorkingHours + 1 : WorkingHours);

            if (tt_leTet == true)
                s = "LT " + s;
            else
            {
                 if (tt_nghiPhep_Alias != "")
                {
                    if (PerTimeID == 3)
                    {
                        s = "1" + DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") + " " + s;
                    }else
                    {
                        s = "0.5" + DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") + " " + s;
                    }
                   
                }
            }
            if (tt_coQuetTay == 1)
                s = "Out";
            else if (tt_coQuetTay == 2)
                s = "In";

            if (tgTinhTangCa > 0)
            {
                if (type == 1)
                    //s += string.Format("{1}{0:0.###}", tgTinhTangCa, isWinform ? "\n" : "<br />");
                    s += string.Format("{1}{0:0.00}", tgTinhTangCa, isWinform ? "+" : "<br />");
                else if (type == 2)
                    s += string.Format(" ({0:0.00})", tgTinhTangCa);
            }
            return s;
        }
    }
}