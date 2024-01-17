using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Core.Business;
using System.Data.SqlClient;
using iHRM.Common.Code;

namespace iHRM.Core.Controller.QuetThe
{
    public class ReportMonth : LogicBase
    {
        ReportMonthLogic logic = new ReportMonthLogic();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        public DataTable GetData(List<string> dtEmpID, DateTime tuNgay, DateTime denNgay, bool isWinform = false, string DepID = "")
        {
            DataTable dtData;
            dtData = logic.GetReportMonth(tuNgay, denNgay, dtEmpID, DepID);

            if (dtData == null || dtData.Rows.Count == 0)
                return dtData;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID"),
                new DataColumn("tenNV"),
                new DataColumn("ngayVao", typeof(DateTime)),
                new DataColumn("Leftdate"),
                new DataColumn("TeamName"),
                new DataColumn("LineName"),
                new DataColumn("DepName"),
                new DataColumn("DH_Khoi"),
                new DataColumn("DH_Donvi"),
                new DataColumn("DH_Phongban"),
                new DataColumn("PosName"),
                new DataColumn("D1"),
                new DataColumn("D2"),
                new DataColumn("D3"),
                new DataColumn("D4"),
                new DataColumn("D5"),
                new DataColumn("D6"),
                new DataColumn("D7"),
                new DataColumn("D8"),
                new DataColumn("D9"),
                new DataColumn("D10"),
                new DataColumn("D11"),
                new DataColumn("D12"),
                new DataColumn("D13"),
                new DataColumn("D14"),
                new DataColumn("D15"),
                new DataColumn("D16"),
                new DataColumn("D17"),
                new DataColumn("D18"),
                new DataColumn("D19"),
                new DataColumn("D20"),
                new DataColumn("D21"),
                new DataColumn("D22"),
                new DataColumn("D23"),
                new DataColumn("D24"),
                new DataColumn("D25"),
                new DataColumn("D26"),
                new DataColumn("D27"),
                new DataColumn("D28"),
                new DataColumn("D29"),
                new DataColumn("D30"),
                new DataColumn("D31"),
                new DataColumn("NghiCoLuong",typeof(double)),
                new DataColumn("NghiPhepNam",typeof(double)),
                new DataColumn("NghiKhongLuong",typeof(double)),
                new DataColumn("NghiKhongPhep",typeof(double)),
                new DataColumn("NghiCheDo",typeof(double)),
                new DataColumn("NghiLeTet",typeof(double)),
                new DataColumn("NightDay",typeof(double)),
                new DataColumn("TotalDiTreVeSom",typeof(double)),
                new DataColumn("SoLanDTVS5",typeof(double)),
                new DataColumn("SoLanDTVS510",typeof(double)),
                new DataColumn("SoLanDTVS10",typeof(double)),
                new DataColumn("Total",typeof(double)),
                new DataColumn("Total_LamThem",typeof(double)),


                new DataColumn("NormalOT",typeof(double)),
                new DataColumn("NightOT",typeof(double)),
                new DataColumn("TCNgayLT",typeof(double)),
                new DataColumn("TCDemLT",typeof(double)),
                new DataColumn("TotalOT",typeof(double)),
                new DataColumn("TotalOTCN",typeof(double)),
                new DataColumn("TotalOTLT",typeof(double)),
                new DataColumn("TotalOTLe",typeof(double)),

                new DataColumn("TotalOT03",typeof(double)),
                new DataColumn("TotalOT15",typeof(double)),
                new DataColumn("TotalOT20",typeof(double)),

                new DataColumn("Total_Luong",typeof(double)),
            });

            foreach (DataRow dr in dtData.Rows)
            {
                DataRow r = null;

                var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"] + "'");
                if (r1 == null || r1.Length == 0)
                {
                    r = dt.NewRow();
                    r["EmployeeID"] = dr["EmployeeID"];
                    r["tenNV"] = dr["EmployeeName"];
                    r["ngayVao"] = dr["AppliedDate"];
                    r["Leftdate"] = dr["Leftdate"];
                    r["TeamName"] = dr["TeamName"];
                    r["LineName"] = dr["LineName"];
                    r["DepName"] = dr["DepName"];
                    r["DH_Khoi"] = dr["DH_Khoi"];
                    r["DH_Donvi"] = dr["DH_Donvi"];
                    r["DH_Phongban"] = dr["DH_Phongban"];
                    r["PosName"] = dr["PosName"];
                    r["Total"] = "0";
                    r["Total_LamThem"] = "0";
                    r["NghiCoLuong"] = 0;
                    r["NghiPhepNam"] = 0;
                    r["NghiKhongLuong"] = 0;
                    r["NghiCheDo"] = 0;
                    r["NghiLeTet"] = 0;
                    r["NightDay"] = 0;
                    r["NghiKhongPhep"] = 0;
                    r["TotalDiTreVeSom"] = 0;
                    r["SoLanDTVS5"] = 0;
                    r["SoLanDTVS510"] = 0;
                    r["SoLanDTVS10"] = 0;

                    r["NormalOT"] = 0;
                    r["NightOT"] = 0;
                    r["TCNgayLT"] = 0;
                    r["TCDemLT"] = 0;
                    r["TotalOT"] = 0;
                    r["TotalOTLT"] = 0;
                    r["TotalOTCN"] = 0;
                    r["TotalOTLe"] = 0;

                    r["TotalOT03"] = 0;
                    r["TotalOT15"] = 0;
                    r["TotalOT20"] = 0;

                    r["Total_Luong"] = 0;
                    dt.Rows.Add(r);
                }
                else
                {
                    r = r1[0];
                }
                r["D" + ((DateTime)dr["ngay"]).Day] = Helper.GetTrangThai(dr, 1, isWinform);
                string LeaveID = DbHelper.DrGetString(dr, "LeaveID");
                int tt_nghiPhep = DbHelper.DrGetInt(dr, "tt_nghiPhep");
                double daysOfNghiCoLuong = DbHelper.DrGetDouble(dr, "daysOfNghiCoLuong");
                double perDayLeave = 0;

                var calam = db.tbCaLamViecs.Where(p => p.id == DbHelper.DrGetGuid(dr, "idCaLam")).FirstOrDefault();

                if (dr["PerTimeID"] != DBNull.Value && dr["PerTimeID"].ToString() != "0")
                {
                    perDayLeave = dr["PerTimeID"].ToString() != "3" ? 0.5 : 1;
                }

                if (LeaveID == "KP")
                {
                    r["NghiKhongPhep"] = Convert.ToDouble(r["NghiKhongPhep"]) + 1;
                }
                else
                {
                    if (tt_nghiPhep > 0)
                    {
                        if (daysOfNghiCoLuong > 0)
                        {
                            if (LeaveID == "KH" || LeaveID == "TC")
                            {
                                r["NghiCheDo"] = Convert.ToDouble(r["NghiCheDo"]) + daysOfNghiCoLuong;
                            }
                            else if (LeaveID == "PN")
                            {
                                r["NghiPhepNam"] = Convert.ToDouble(r["NghiPhepNam"]) + daysOfNghiCoLuong;
                            }
                            else if (LeaveID != "KH" && LeaveID != "TC" && LeaveID != "PN")
                            {
                                r["NghiCoLuong"] = Convert.ToDouble(r["NghiCoLuong"]) + daysOfNghiCoLuong;
                            }
                        }
                        else
                        {
                            r["NghiKhongLuong"] = Convert.ToDouble(r["NghiKhongLuong"]) + perDayLeave;
                        }
                    }
                }

                if (dr["dkLamThem"] != DBNull.Value && Convert.ToBoolean(dr["tt_leTet"]) == true) // A trọng sửa từ dklamthem = 3 sang tt_leTet = true 26/02/2018
                {
                    r["NghiLeTet"] = Convert.ToDouble(r["NghiLeTet"]) + 1;
                }

                if (Convert.ToDouble(dr["tgVeSom"]) > 0)
                {

                    if (Convert.ToBoolean(dr["isPhepTreSom"]) != true)
                    {
                        r["TotalDiTreVeSom"] = Math.Round(Convert.ToDouble(r["TotalDiTreVeSom"]) + (Convert.ToDouble(dr["tgVeSom"])), 2);

                        //if (Convert.ToDouble(dr["tgVeSom"]) >= 3 && Convert.ToDouble(dr["tgVeSom"]) < 5)
                        //{
                        //    r["SoLanDTVS5"] = Convert.ToDouble(r["SoLanDTVS5"]) + 1;
                        //}
                        //if (Convert.ToDouble(dr["tgVeSom"]) >= 5 && Convert.ToDouble(dr["tgVeSom"]) <= 10)
                        //{
                        //    r["SoLanDTVS510"] = Convert.ToDouble(r["SoLanDTVS510"]) + 1;
                        //}
                        //if (Convert.ToDouble(dr["tgVeSom"]) > 10)
                        //{
                        //    r["SoLanDTVS10"] = Convert.ToDouble(r["SoLanDTVS10"]) + 1;
                        //}
                    }
                }
                if (Convert.ToDouble(dr["tgDiMuon"]) > 0)
                {
                    if (Convert.ToBoolean(dr["isPhepTreSom"]) != true)
                    {
                        r["TotalDiTreVeSom"] = Math.Round(Convert.ToDouble(r["TotalDiTreVeSom"]) + (Convert.ToDouble(dr["tgDiMuon"])), 2);

                        if (Convert.ToDouble(dr["tgDiMuon"]) >= 3 && Convert.ToDouble(dr["tgDiMuon"]) < 5)
                        {
                            r["SoLanDTVS5"] = Convert.ToDouble(r["SoLanDTVS5"]) + 1;
                        }
                        if (Convert.ToDouble(dr["tgDiMuon"]) >= 5 && Convert.ToDouble(dr["tgDiMuon"]) <= 10)
                        {
                            r["SoLanDTVS510"] = Convert.ToDouble(r["SoLanDTVS510"]) + 1;
                        }
                        if (Convert.ToDouble(dr["tgDiMuon"]) > 10)
                        {
                            r["SoLanDTVS10"] = Convert.ToDouble(r["SoLanDTVS10"]) + 1;
                        }
                    }
                }

                r["NormalOT"] = Math.Round(Convert.ToDouble(r["NormalOT"]) + Convert.ToDouble(dr["NormalOT"]), 2);

                r["TotalOT"] = Math.Round(Convert.ToDouble(r["TotalOT"]) + Convert.ToDouble(dr["NormalOT"]) + Convert.ToDouble(dr["NightOT"]), 2);


                if (dr["dkLamThem"] == DBNull.Value || Convert.ToInt32(dr["dkLamThem"]) == 0) // Không phải làm thêm
                {
                    r["Total"] = Math.Round(Convert.ToDouble(r["Total"]) + (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"])), 2);

                    r["NightOT"] = Math.Round(Convert.ToDouble(r["NightOT"]) + Convert.ToDouble(dr["NightOT"]), 2);

                    r["NightDay"] = Math.Round(Convert.ToDouble(r["NightDay"]) + Convert.ToDouble(dr["NightDay"]) * Convert.ToDouble(dr["SoTiengTinhCa"]), 2);

                    r["TotalOT15"] = Math.Round(Convert.ToDouble(r["TotalOT15"]) + Convert.ToDouble(dr["NormalOT"]), 2);

                    r["TotalOT20"] = Math.Round(Convert.ToDouble(r["TotalOT20"]) + Convert.ToDouble(dr["NightOT"]), 2);

                }
                else // làm thêm
                {
                    r["Total_LamThem"] = Math.Round(Convert.ToDouble(r["Total_LamThem"]) + (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"])), 2);

                    r["TCNgayLT"] = Math.Round(Convert.ToDouble(r["TCNgayLT"]) + (dr["NormalOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NormalOT"])), 2);

                    r["TCDemLT"] = Math.Round(Convert.ToDouble(r["TCDemLT"]) + (dr["NightOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NightOT"])), 2);

                    r["TotalOTCN"] = Math.Round(Convert.ToDouble(r["TotalOTCN"]) + Convert.ToDouble(dr["NightDay"]) * Convert.ToDouble(dr["SoTiengTinhCa"]) + (dr["NightOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NightOT"])), 2);

                    r["TotalOT20"] = Math.Round(Convert.ToDouble(r["TotalOT20"]) + Convert.ToDouble(dr["NormalOT"]), 2);
                    r["TotalOT20"] = Math.Round(Convert.ToDouble(r["TotalOT20"]) + Convert.ToDouble(dr["NightOT"]), 2);
                    r["TotalOT20"] = Math.Round(Convert.ToDouble(r["TotalOT20"]) + Convert.ToDouble(dr["WorkingHours"]), 2);
                }

                if (Convert.ToDouble(dr["kqNgayCong"]) > 0 && calam.caDem == true)
                {
                    r["TotalOT03"] = Convert.ToDouble(r["TotalOT03"]) + Convert.ToDouble(dr["WorkingHours"]);
                }

                if (dr["dkLamThem"] != DBNull.Value || Convert.ToBoolean(dr["tt_leTet"]) == true)
                {
                    r["TotalOTLT"] = Math.Round(Convert.ToDouble(r["TotalOTLT"]) + Convert.ToDouble(dr["NormalOT"]) + (dr["NightOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NightOT"])), 2);
                }

                if (Convert.ToBoolean(dr["tt_leTet"]) == true)
                {
                    r["TotalOTLe"] = Math.Round(Convert.ToDouble(r["TotalOTLe"]) + Convert.ToDouble(dr["NightDay"]) * Convert.ToDouble(dr["SoTiengTinhCa"]) + (dr["NightOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NightOT"])), 2);
                }

                r["Total_Luong"] = Math.Round(Convert.ToDouble(r["Total"]) + Convert.ToDouble(r["NghiCheDo"]) + Convert.ToDouble(r["NghiPhepNam"]) + Convert.ToDouble(r["NghiCoLuong"]),2);
            }

            return dt;
        }
        public DataTable GetData_Fake(List<string> dtEmpID, DateTime tuNgay, DateTime denNgay, bool isWinform = false, string DepID = "")
        {
            DataTable dtData;
            dtData = logic.GetReportMonth_Fake(tuNgay, denNgay, dtEmpID, DepID);

            if (dtData == null || dtData.Rows.Count == 0)
                return dtData;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID"),
                new DataColumn("tenNV"),
                new DataColumn("ngayVao", typeof(DateTime)),
                new DataColumn("Leftdate"),
                new DataColumn("TeamName"),
                new DataColumn("LineName"),
                new DataColumn("DepName"),
                new DataColumn("DH_Khoi"),
                new DataColumn("DH_Donvi"),
                new DataColumn("DH_Phongban"),
                new DataColumn("PosName"),
                new DataColumn("D1"),
                new DataColumn("D2"),
                new DataColumn("D3"),
                new DataColumn("D4"),
                new DataColumn("D5"),
                new DataColumn("D6"),
                new DataColumn("D7"),
                new DataColumn("D8"),
                new DataColumn("D9"),
                new DataColumn("D10"),
                new DataColumn("D11"),
                new DataColumn("D12"),
                new DataColumn("D13"),
                new DataColumn("D14"),
                new DataColumn("D15"),
                new DataColumn("D16"),
                new DataColumn("D17"),
                new DataColumn("D18"),
                new DataColumn("D19"),
                new DataColumn("D20"),
                new DataColumn("D21"),
                new DataColumn("D22"),
                new DataColumn("D23"),
                new DataColumn("D24"),
                new DataColumn("D25"),
                new DataColumn("D26"),
                new DataColumn("D27"),
                new DataColumn("D28"),
                new DataColumn("D29"),
                new DataColumn("D30"),
                new DataColumn("D31"),
                new DataColumn("NghiCoLuong",typeof(double)),
                new DataColumn("NghiPhepNam",typeof(double)),
                new DataColumn("NghiKhongLuong",typeof(double)),
                new DataColumn("NghiKhongPhep",typeof(double)),
                new DataColumn("NghiCheDo",typeof(double)),
                new DataColumn("NghiLeTet",typeof(double)),
                new DataColumn("NightDay",typeof(double)),
                new DataColumn("TotalDiTreVeSom",typeof(double)),
                new DataColumn("SoLanDTVS5",typeof(double)),
                new DataColumn("SoLanDTVS510",typeof(double)),
                new DataColumn("SoLanDTVS10",typeof(double)),
                new DataColumn("Total",typeof(double)),
                new DataColumn("Total_LamThem",typeof(double)),


                new DataColumn("NormalOT",typeof(double)),
                new DataColumn("NightOT",typeof(double)),
                new DataColumn("TCNgayLT",typeof(double)),
                new DataColumn("TCDemLT",typeof(double)),
                new DataColumn("TotalOT",typeof(double)),
                new DataColumn("TotalOTCN",typeof(double)),
                new DataColumn("TotalOTLT",typeof(double)),
                new DataColumn("TotalOTLe",typeof(double)),

                new DataColumn("TotalOT03",typeof(double)),
                new DataColumn("TotalOT15",typeof(double)),
                new DataColumn("TotalOT20",typeof(double)),

                new DataColumn("Total_Luong",typeof(double)),
            });

            foreach (DataRow dr in dtData.Rows)
            {
                DataRow r = null;

                var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"] + "'");
                if (r1 == null || r1.Length == 0)
                {
                    r = dt.NewRow();
                    r["EmployeeID"] = dr["EmployeeID"];
                    r["tenNV"] = dr["EmployeeName"];
                    r["ngayVao"] = dr["AppliedDate"];
                    r["Leftdate"] = dr["Leftdate"];
                    r["TeamName"] = dr["TeamName"];
                    r["LineName"] = dr["LineName"];
                    r["DepName"] = dr["DepName"];
                    r["DH_Khoi"] = dr["DH_Khoi"];
                    r["DH_Donvi"] = dr["DH_Donvi"];
                    r["DH_Phongban"] = dr["DH_Phongban"];
                    r["PosName"] = dr["PosName"];
                    r["Total"] = "0";
                    r["Total_LamThem"] = "0";
                    r["NghiCoLuong"] = 0;
                    r["NghiPhepNam"] = 0;
                    r["NghiKhongLuong"] = 0;
                    r["NghiCheDo"] = 0;
                    r["NghiLeTet"] = 0;
                    r["NightDay"] = 0;
                    r["NghiKhongPhep"] = 0;
                    r["TotalDiTreVeSom"] = 0;
                    r["SoLanDTVS5"] = 0;
                    r["SoLanDTVS510"] = 0;
                    r["SoLanDTVS10"] = 0;

                    r["NormalOT"] = 0;
                    r["NightOT"] = 0;
                    r["TCNgayLT"] = 0;
                    r["TCDemLT"] = 0;
                    r["TotalOT"] = 0;
                    r["TotalOTLT"] = 0;
                    r["TotalOTCN"] = 0;
                    r["TotalOTLe"] = 0;

                    r["TotalOT03"] = 0;
                    r["TotalOT15"] = 0;
                    r["TotalOT20"] = 0;

                    r["Total_Luong"] = 0;
                    dt.Rows.Add(r);
                }
                else
                {
                    r = r1[0];
                }
                r["D" + ((DateTime)dr["ngay"]).Day] = Helper.GetTrangThai(dr, 1, isWinform);
                string LeaveID = DbHelper.DrGetString(dr, "LeaveID");
                int tt_nghiPhep = DbHelper.DrGetInt(dr, "tt_nghiPhep");
                double daysOfNghiCoLuong = DbHelper.DrGetDouble(dr, "daysOfNghiCoLuong");
                double perDayLeave = 0;

                var calam = db.tbCaLamViecs.Where(p => p.id == DbHelper.DrGetGuid(dr, "idCaLam")).FirstOrDefault();

                if (dr["PerTimeID"] != DBNull.Value && dr["PerTimeID"].ToString() != "0")
                {
                    perDayLeave = dr["PerTimeID"].ToString() != "3" ? 0.5 : 1;
                }

                if (LeaveID == "KP")
                {
                    r["NghiKhongPhep"] = Convert.ToDouble(r["NghiKhongPhep"]) + 1;
                }
                else
                {
                    if (tt_nghiPhep > 0)
                    {
                        if (daysOfNghiCoLuong > 0)
                        {
                            if (LeaveID == "KH" || LeaveID == "TC")
                            {
                                r["NghiCheDo"] = Convert.ToDouble(r["NghiCheDo"]) + daysOfNghiCoLuong;
                            }
                            else if (LeaveID == "PN")
                            {
                                r["NghiPhepNam"] = Convert.ToDouble(r["NghiPhepNam"]) + daysOfNghiCoLuong;
                            }
                            else if (LeaveID != "KH" && LeaveID != "TC" && LeaveID != "PN")
                            {
                                r["NghiCoLuong"] = Convert.ToDouble(r["NghiCoLuong"]) + daysOfNghiCoLuong;
                            }
                        }
                        else
                        {
                            r["NghiKhongLuong"] = Convert.ToDouble(r["NghiKhongLuong"]) + perDayLeave;
                        }
                    }
                }

                if (dr["dkLamThem"] != DBNull.Value && Convert.ToBoolean(dr["tt_leTet"]) == true) // A trọng sửa từ dklamthem = 3 sang tt_leTet = true 26/02/2018
                {
                    r["NghiLeTet"] = Convert.ToDouble(r["NghiLeTet"]) + 1;
                }

                if (Convert.ToDouble(dr["tgVeSom"]) > 0)
                {

                    if (Convert.ToBoolean(dr["isPhepTreSom"]) != true)
                    {
                        r["TotalDiTreVeSom"] = Math.Round(Convert.ToDouble(r["TotalDiTreVeSom"]) + (Convert.ToDouble(dr["tgVeSom"])), 2);

                        //if (Convert.ToDouble(dr["tgVeSom"]) >= 3 && Convert.ToDouble(dr["tgVeSom"]) < 5)
                        //{
                        //    r["SoLanDTVS5"] = Convert.ToDouble(r["SoLanDTVS5"]) + 1;
                        //}
                        //if (Convert.ToDouble(dr["tgVeSom"]) >= 5 && Convert.ToDouble(dr["tgVeSom"]) <= 10)
                        //{
                        //    r["SoLanDTVS510"] = Convert.ToDouble(r["SoLanDTVS510"]) + 1;
                        //}
                        //if (Convert.ToDouble(dr["tgVeSom"]) > 10)
                        //{
                        //    r["SoLanDTVS10"] = Convert.ToDouble(r["SoLanDTVS10"]) + 1;
                        //}
                    }
                }
                if (Convert.ToDouble(dr["tgDiMuon"]) > 0)
                {
                    if (Convert.ToBoolean(dr["isPhepTreSom"]) != true)
                    {
                        r["TotalDiTreVeSom"] = Math.Round(Convert.ToDouble(r["TotalDiTreVeSom"]) + (Convert.ToDouble(dr["tgDiMuon"])), 2);

                        if (Convert.ToDouble(dr["tgDiMuon"]) >= 3 && Convert.ToDouble(dr["tgDiMuon"]) < 5)
                        {
                            r["SoLanDTVS5"] = Convert.ToDouble(r["SoLanDTVS5"]) + 1;
                        }
                        if (Convert.ToDouble(dr["tgDiMuon"]) >= 5 && Convert.ToDouble(dr["tgDiMuon"]) <= 10)
                        {
                            r["SoLanDTVS510"] = Convert.ToDouble(r["SoLanDTVS510"]) + 1;
                        }
                        if (Convert.ToDouble(dr["tgDiMuon"]) > 10)
                        {
                            r["SoLanDTVS10"] = Convert.ToDouble(r["SoLanDTVS10"]) + 1;
                        }
                    }
                }

                r["NormalOT"] = Math.Round(Convert.ToDouble(r["NormalOT"]) + Convert.ToDouble(dr["NormalOT"]), 2);

                r["TotalOT"] = Math.Round(Convert.ToDouble(r["TotalOT"]) + Convert.ToDouble(dr["NormalOT"]) + Convert.ToDouble(dr["NightOT"]), 2);


                if (dr["dkLamThem"] == DBNull.Value || Convert.ToInt32(dr["dkLamThem"]) == 0) // Không phải làm thêm
                {
                    r["Total"] = Math.Round(Convert.ToDouble(r["Total"]) + (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"])), 2);

                    r["NightOT"] = Math.Round(Convert.ToDouble(r["NightOT"]) + Convert.ToDouble(dr["NightOT"]), 2);

                    r["NightDay"] = Math.Round(Convert.ToDouble(r["NightDay"]) + Convert.ToDouble(dr["NightDay"]) * Convert.ToDouble(dr["SoTiengTinhCa"]), 2);

                    r["TotalOT15"] = Math.Round(Convert.ToDouble(r["TotalOT15"]) + Convert.ToDouble(dr["NormalOT"]), 2);

                    r["TotalOT20"] = Math.Round(Convert.ToDouble(r["TotalOT20"]) + Convert.ToDouble(dr["NightOT"]), 2);

                }
                else // làm thêm
                {
                    r["Total_LamThem"] = Math.Round(Convert.ToDouble(r["Total_LamThem"]) + (dr["kqNgayCong"] == DBNull.Value ? 0 : Convert.ToDouble(dr["kqNgayCong"])), 2);

                    r["TCNgayLT"] = Math.Round(Convert.ToDouble(r["TCNgayLT"]) + (dr["NormalOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NormalOT"])), 2);

                    r["TCDemLT"] = Math.Round(Convert.ToDouble(r["TCDemLT"]) + (dr["NightOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NightOT"])), 2);

                    r["TotalOTCN"] = Math.Round(Convert.ToDouble(r["TotalOTCN"]) + Convert.ToDouble(dr["NightDay"]) * Convert.ToDouble(dr["SoTiengTinhCa"]) + (dr["NightOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NightOT"])), 2);

                    r["TotalOT20"] = Math.Round(Convert.ToDouble(r["TotalOT20"]) + Convert.ToDouble(dr["NormalOT"]), 2);
                    r["TotalOT20"] = Math.Round(Convert.ToDouble(r["TotalOT20"]) + Convert.ToDouble(dr["NightOT"]), 2);
                    r["TotalOT20"] = Math.Round(Convert.ToDouble(r["TotalOT20"]) + Convert.ToDouble(dr["WorkingHours"]), 2);
                }

                if (Convert.ToDouble(dr["kqNgayCong"]) > 0 && calam.caDem == true)
                {
                    r["TotalOT03"] = Convert.ToDouble(r["TotalOT03"]) + Convert.ToDouble(dr["WorkingHours"]);
                }

                if (dr["dkLamThem"] != DBNull.Value || Convert.ToBoolean(dr["tt_leTet"]) == true)
                {
                    r["TotalOTLT"] = Math.Round(Convert.ToDouble(r["TotalOTLT"]) + Convert.ToDouble(dr["NormalOT"]) + (dr["NightOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NightOT"])), 2);
                }

                if (Convert.ToBoolean(dr["tt_leTet"]) == true)
                {
                    r["TotalOTLe"] = Math.Round(Convert.ToDouble(r["TotalOTLe"]) + Convert.ToDouble(dr["NightDay"]) * Convert.ToDouble(dr["SoTiengTinhCa"]) + (dr["NightOT"] == DBNull.Value ? 0 : Convert.ToDouble(dr["NightOT"])), 2);
                }

                r["Total_Luong"] = Math.Round(Convert.ToDouble(r["Total"]) + Convert.ToDouble(r["NghiCheDo"]) + Convert.ToDouble(r["NghiPhepNam"]) + Convert.ToDouble(r["NghiCoLuong"]), 2);
            }

            return dt;
        }
      }
}
