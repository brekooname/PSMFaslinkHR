using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Controller.Report
{
    public class GetData
    {
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        public DataTable getDataReportChamCong_new(List<string> _lEmpID, DateTime TuNgay, DateTime DenNgay)
        {
            DataTable data = new DataTable();
            data = Provider.ExecuteDataTableReader("p_BaoCao_GetReportMonth_new",
                new SqlParameter("tuNgay", TuNgay),
                new SqlParameter("denNgay", DenNgay),
                Provider.CreateParameter_StringList("dtEmpID", _lEmpID)
            );
            return data;
        }
        public DataTable getDataReportChamCong_new_Fake(List<string> _lEmpID, DateTime TuNgay, DateTime DenNgay)
        {
            DataTable data = new DataTable();
            data = Provider.ExecuteDataTableReader("p_BaoCao_GetReportMonth_new_Fake",
                new SqlParameter("tuNgay", TuNgay),
                new SqlParameter("denNgay", DenNgay),
                Provider.CreateParameter_StringList("dtEmpID", _lEmpID)
            );
            return data;
        }
        public DataTable getDataReportChamCong(List<string> _lEmpID, DateTime TuNgay, DateTime DenNgay)
        {
            DataTable dt = new DataTable();
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            #region add datacolumn
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID"),
                new DataColumn("PosName"),
                new DataColumn("AppliedDate"),
                new DataColumn("tenNV"),
                new DataColumn("TeamName"),
                new DataColumn("LineName"),
                new DataColumn("DepName"),
                new DataColumn("IDCard"),
                new DataColumn("NghiLe" ),
                new DataColumn("NghiThaiSan"),
                new DataColumn("NghiKhongPhep"),
                new DataColumn("NghiKhongLuong"),
                new DataColumn("NghiTinhCong"),
                new DataColumn("NghiCoLuong"),
                new DataColumn("NghiPhepNam"),
                new DataColumn("kqNgayCong"),
                new DataColumn("TangCa"),
                new DataColumn("tgTinhTangCa"),
                new DataColumn("SoNgayCong", typeof(double)),
                new DataColumn("SoNgayCong_LamThem", typeof(double))
            });
            #endregion
            DataTable data = new DataTable();
            data = Provider.ExecuteDataTableReader("p_BaoCao_GetReportMonth",
                new SqlParameter("tuNgay", TuNgay),
                new SqlParameter("denNgay", DenNgay),
                Provider.CreateParameter_StringList("dtEmpID", _lEmpID)
            );

            List<string> list = new List<string>();

            if (data != null && data.Rows.Count > 0)
            {
                DataRow[] _rowlist = data.Select("", "ngay ASC");
                foreach (DataRow dr in _rowlist)
                {
                    DataRow r = null;
                    r = dt.NewRow();
                    r["TangCa"] = dr["tgTinhTangCa"];

                    if (!list.Contains(dr["EmployeeID"].ToString()))
                    {
                        list.Add(dr["EmployeeID"].ToString());
                        System.Data.DataView view = new System.Data.DataView(dt);
                        view.Sort = "EmployeeID";
                        r["EmployeeID"] = dr["EmployeeID"];
                        r["tenNV"] = dr["EmployeeName"];
                        r["DepName"] = dr["DepName"];
                        r["TeamName"] = dr["TeamName"];
                        r["LineName"] = dr["LineName"];
                        r["tgTinhTangCa"] = dr["tgTinhTangCa"];
                        r["PosName"] = dr["PosName"];
                        r["IDCard"] = dr["IDCard"];
                        r["NghiThaiSan"] = "0";
                        r["NghiPhepNam"] = "0";
                        r["NghiKhongLuong"] = "0";
                        r["NghiKhongPhep"] = "0";
                        r["NghiTinhCong"] = "0";
                        r["SoNgayCong"] = "0";
                        r["SoNgayCong_LamThem"] = "0";
                        r["NghiLe"] = "0";
                        if (dr["AppliedDate"] != DBNull.Value)
                        {
                            r["AppliedDate"] = Convert.ToDateTime(dr["AppliedDate"].ToString()).ToShortDateString();
                        }

                        double ketquaCong = 0;
                        double ketquaPhep = 0;
                        string LeaveID = "";

                        ketquaCong = Math.Round(DbHelper.DrGetDouble(dr, "kqNgayCong"), 2);
                        LeaveID = DbHelper.DrGetString(dr, "LeaveID");

                        if (LeaveID != "")
                        {
                            ketquaPhep = Convert.ToDouble(dr["PerTimeID"].ToString()) == 3 ? 1 : 0.5;
                            var leaveType = db.tblRef_LeaveTypes.Where(p => p.LeaveID == LeaveID && p.isTinhCong == true).FirstOrDefault();
                            if (leaveType != null)
                            {
                                r["NghiTinhCong"] = ketquaPhep;
                                ketquaCong = 0; // Nếu là nghỉ có tính công thì không tính vào số ngày công nữa.
                            }
                            else
                            {
                                if (DbHelper.DrGetDouble(dr, "daysOfNghiCoLuong") == 0)
                                {
                                    if (LeaveID == "KP")
                                    {
                                        r["NghiKhongPhep"] = ketquaPhep;
                                    }
                                    else
                                        r["NghiKhongLuong"] = ketquaPhep;
                                }
                                else
                                {
                                    if (LeaveID == "P")
                                    {
                                        r["NghiPhepNam"] = ketquaPhep;
                                    }
                                    else if (LeaveID == "TS")
                                    {
                                        r["NghiThaiSan"] = ketquaPhep;
                                    }
                                    else
                                    {
                                        r["NghiPhepNam"] = ketquaPhep;
                                    }
                                }
                            }
                        }
                        if (DbHelper.DrGetBoolean(dr, "tt_leTet") == true)
                        {
                            r["NghiLe"] = "1";
                        }

                        if (dr["dkLamThem"] != DBNull.Value)
                        {
                            var lthem = db.tbLoaiNgayLamThems.FirstOrDefault(p => p.id.ToString() == dr["dkLamThem"].ToString());
                            r["SoNgayCong_LamThem"] = DbHelper.DrGetDouble(r, "SoNgayCong_LamThem") + ketquaCong;
                            ketquaCong = 0;
                        }

                        r["SoNgayCong"] = ketquaCong;
                        dt.Rows.Add(r);
                    }
                    else// Nếu có nhân viên trong danh sách rồi thì add thêm vào.
                    {
                        var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"].ToString() + "' ")[0];
                        r1["TangCa"] = DbHelper.DrGetDouble(r1, "TangCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");

                        r1["DepName"] = dr["DepName"];
                        DataRow rtemp = r1;

                        double ketquaCong = 0;
                        double ketquaPhep = 0;
                        string LeaveID = "";

                        ketquaCong = Math.Round(DbHelper.DrGetDouble(dr, "kqNgayCong"), 2);
                        LeaveID = DbHelper.DrGetString(dr, "LeaveID");

                        if (LeaveID != "")
                        {
                            ketquaPhep = Convert.ToDouble(dr["PerTimeID"].ToString()) == 3 ? 1 : 0.5;
                            var leaveType = db.tblRef_LeaveTypes.Where(p => p.LeaveID == LeaveID && p.isTinhCong == true).FirstOrDefault();
                            if (leaveType != null)
                            {
                                r1["NghiTinhCong"] = DbHelper.DrGetDouble(r1, "NghiTinhCong") + ketquaPhep;
                                ketquaCong = 0; // Nếu là nghỉ có tính công thì không tính vào số ngày công nữa.
                            }
                            else
                            {
                                if (DbHelper.DrGetDouble(dr, "daysOfNghiCoLuong") == 0)
                                {
                                    if (LeaveID == "KP")
                                    {
                                        r1["NghiKhongPhep"] = DbHelper.DrGetDouble(r1, "NghiKhongPhep") + ketquaPhep;
                                    }
                                    else
                                        r1["NghiKhongLuong"] = DbHelper.DrGetDouble(r1, "NghiKhongLuong") + ketquaPhep;
                                }
                                else
                                {
                                    if (LeaveID == "P")
                                    {
                                        r1["NghiPhepNam"] = DbHelper.DrGetDouble(r1, "NghiPhepNam") + ketquaPhep;
                                    }
                                    else if (LeaveID == "TS")
                                    {
                                        r1["NghiThaiSan"] = DbHelper.DrGetDouble(r1, "NghiThaiSan") + ketquaPhep;
                                    }
                                    else
                                    {
                                        r1["NghiPhepNam"] = DbHelper.DrGetDouble(r1, "NghiPhepNam") + ketquaPhep;
                                    }
                                }
                            }
                        }
                        if (DbHelper.DrGetBoolean(dr, "tt_leTet") == true)
                        {
                            r1["NghiLe"] = DbHelper.DrGetDouble(r1, "NghiLe") + 1;
                        }

                        if (dr["dkLamThem"] != DBNull.Value)
                        {
                            var lthem = db.tbLoaiNgayLamThems.FirstOrDefault(p => p.id.ToString() == dr["dkLamThem"].ToString());
                            r1["SoNgayCong_LamThem"] = DbHelper.DrGetDouble(r1, "SoNgayCong_LamThem") + ketquaCong;
                            ketquaCong = 0;
                        }
                        r1["SoNgayCong"] = DbHelper.DrGetDouble(r1, "SoNgayCong") + ketquaCong;
                        r = r1;
                    }
                }
            }
            return dt;
        }
        public DataTable getDataDSHopDong(string EmpID, string DepID, DateTime TuNgay, DateTime DenNgay, string strHopDong)
        {
            DataTable data = new DataTable();
            data = logic.getDataDSHopDong(EmpID, DepID, TuNgay, DenNgay, strHopDong);
            return data;
        }
        public DataTable GetDataReportOvertime(List<string> dtEmpID, DateTime day, DateTime todates)
        {
            return logic.GetReportOvertime(day, todates, dtEmpID);
        }
        public string getPhongBan(string DepID, dcDatabaseDataContext db)
        {
            string strDep = "";
            List<tblRef_Department> child = (from c in db.tblRef_Departments where c.DepParent == DepID select c).ToList<tblRef_Department>();
            if (child != null)
            {
                if (child.Count > 0)
                {
                    string list = "";
                    foreach (tblRef_Department item in child)
                    {
                        list += item.DepID + ",";
                    }
                    strDep = list;
                }
                else
                {
                    strDep = DepID;
                }
            }
            return strDep;
        }
        public DataTable GetDataReportCaLamMonth(List<string> dtEmpID, DateTime day, DateTime todates, string DepID = "")
        {
            return logic.GetReportCaLamMonth(day, todates, dtEmpID, DepID);
        }
        public DataTable GetDataReportMonthExcel(List<string> listEmpID, DateTime day, DateTime todates)
        {
            DataTable dt = new DataTable();
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            #region add datacolumn
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID"),
                new DataColumn("PosName"),
                new DataColumn("AppliedDate"),
                new DataColumn("tenNV"),
                new DataColumn("TeamName"),
                new DataColumn("LineName"),
                new DataColumn("DepName_Final"),
                new DataColumn("IDCard"),
                new DataColumn("SoNgayCong", typeof(double)),
                new DataColumn("SoNgayCong_LamThem", typeof(double)),
                new DataColumn("NghiLe",typeof(double)),
                new DataColumn("NghiThaiSan",typeof(double)),
                new DataColumn("NghiKhongPhep",typeof(double)),
                new DataColumn("NghiKhongLuong",typeof(double)),
                new DataColumn("NghiTinhCong",typeof(double)),
                new DataColumn("NghiCoLuong",typeof(double)),
                new DataColumn("NghiPhepNam",typeof(double)),
                new DataColumn("kqNgayCong",typeof(double)),
                new DataColumn("DNgayCong",typeof(double)),
                new DataColumn("DTangCa",typeof(double)),
                new DataColumn("TangCa",typeof(double)),
                new DataColumn("tgTinhTangCa",typeof(double)),
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
                new DataColumn("T1"),
                new DataColumn("T2"),
                new DataColumn("T3"),
                new DataColumn("T4"),
                new DataColumn("T5"),
                new DataColumn("T6"),
                new DataColumn("T7"),
                new DataColumn("T8"),
                new DataColumn("T9"),
                new DataColumn("T10"),
                new DataColumn("T11"),
                new DataColumn("T12"),
                new DataColumn("T13"),
                new DataColumn("T14"),
                new DataColumn("T15"),
                new DataColumn("T16"),
                new DataColumn("T17"),
                new DataColumn("T18"),
                new DataColumn("T19"),
                new DataColumn("T20"),
                new DataColumn("T21"),
                new DataColumn("T22"),
                new DataColumn("T23"),
                new DataColumn("T24"),
                new DataColumn("T25"),
                new DataColumn("T26"),
                new DataColumn("T27"),
                new DataColumn("T28"),
                new DataColumn("T29"),
                new DataColumn("T30"),
                new DataColumn("T31"),
                new DataColumn("vitri"),
            });
            #endregion
            //logic.VirtualPaging.PageSize = e.Limit;
            //logic.VirtualPaging.Page = (int)(e.Start / e.Limit) + 1;
            DataTable data = new DataTable();
            data = logic.GetReportMonth(day, todates, listEmpID);

            List<string> list = new List<string>();

            if (data != null && data.Rows.Count > 0)
            {
                DataRow[] _rowlist = data.Select("", "ngay ASC");
                foreach (DataRow dr in _rowlist)
                {
                    DataRow r = null;
                    r = dt.NewRow();
                    r["T" + ((DateTime)dr["ngay"]).Day] = dr["tgTinhTangCa"];
                    r["TangCa"] = dr["tgTinhTangCa"];

                    if (!list.Contains(dr["EmployeeID"].ToString()))
                    {
                        list.Add(dr["EmployeeID"].ToString());
                        System.Data.DataView view = new System.Data.DataView(dt);
                        view.Sort = "EmployeeID";
                        r["EmployeeID"] = dr["EmployeeID"];
                        r["tenNV"] = dr["EmployeeName"];
                        r["DepName_Final"] = dr["DepName_Final"];
                        r["TeamName"] = dr["TeamName"];
                        r["LineName"] = dr["LineName"];
                        r["tgTinhTangCa"] = dr["tgTinhTangCa"];
                        r["PosName"] = dr["PosName"];
                        r["IDCard"] = dr["IDCard"];
                        r["NghiThaiSan"] = "0";
                        r["NghiPhepNam"] = "0";
                        r["NghiKhongLuong"] = "0";
                        r["NghiKhongPhep"] = "0";
                        r["NghiTinhCong"] = "0";
                        r["SoNgayCong"] = "0";
                        r["SoNgayCong_LamThem"] = "0";
                        r["NghiLe"] = "0";
                        if (dr["AppliedDate"] != DBNull.Value)
                        {
                            r["AppliedDate"] = Convert.ToDateTime(dr["AppliedDate"].ToString()).ToShortDateString();
                        }

                        double ketquaCong = 0;
                        double ketquaPhep = 0;
                        string LeaveID = "";

                        ketquaCong = Math.Round(DbHelper.DrGetDouble(dr, "kqNgayCong"), 2);
                        LeaveID = DbHelper.DrGetString(dr, "LeaveID");

                        if (LeaveID != "")
                        {
                            ketquaPhep = Convert.ToDouble(dr["PerTimeID"].ToString()) == 3 ? 1 : 0.5;
                            var leaveType = db.tblRef_LeaveTypes.Where(p => p.LeaveID == LeaveID && p.isTinhCong == true).FirstOrDefault();
                            if (leaveType != null)
                            {
                                r["NghiTinhCong"] = ketquaPhep;
                                ketquaCong = 0;
                            }
                            else
                            {
                                if (DbHelper.DrGetDouble(dr, "daysOfNghiCoLuong") == 0)
                                {
                                    if (LeaveID == "KP")
                                    {
                                        r["NghiKhongPhep"] = ketquaPhep;
                                    }
                                    else
                                        r["NghiKhongLuong"] = ketquaPhep;
                                }
                                else
                                {
                                    if (LeaveID == "P")
                                    {
                                        r["NghiPhepNam"] = ketquaPhep;
                                    }
                                    else if (LeaveID == "TS")
                                    {
                                        r["NghiThaiSan"] = ketquaPhep;
                                    }
                                    else
                                    {
                                        r["NghiCoLuong"] = ketquaPhep;
                                    }
                                }
                            }
                        }
                        r["D" + ((DateTime)dr["ngay"]).Day] = (ketquaCong == 0 ? "" : ketquaCong.ToString()) + (LeaveID == "" ? "" : " " + LeaveID);
                        if (DbHelper.DrGetBoolean(dr, "tt_leTet") == true)
                        {
                            r["NghiLe"] = "1";
                            r["D" + ((DateTime)dr["ngay"]).Day] = "LT";
                        }

                        if (dr["dkLamThem"] != DBNull.Value)
                        {
                            var lthem = db.tbLoaiNgayLamThems.FirstOrDefault(p => p.id.ToString() == dr["dkLamThem"].ToString());
                            r["SoNgayCong_LamThem"] = DbHelper.DrGetDouble(r, "SoNgayCong_LamThem") + ketquaCong;
                            ketquaCong = 0;
                            if (lthem != null)
                            {
                                r["D" + ((DateTime)dr["ngay"]).Day] = lthem.alias + " " + r["D" + ((DateTime)dr["ngay"]).Day].ToString();
                            }
                        }

                        r["SoNgayCong"] = ketquaCong;
                        dt.Rows.Add(r);
                    }
                    else// Nếu có nhân viên trong danh sách rồi thì add thêm vào.
                    {
                        var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"].ToString() + "' ")[0];
                        r1["T" + ((DateTime)dr["ngay"]).Day] = dr["tgTinhTangCa"];
                        r1["TangCa"] = DbHelper.DrGetDouble(r1, "TangCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");

                        r1["DepName_Final"] = dr["DepName_Final"];
                        DataRow rtemp = r1;

                        double ketquaCong = 0;
                        double ketquaPhep = 0;
                        string LeaveID = "";

                        ketquaCong = Math.Round(DbHelper.DrGetDouble(dr, "kqNgayCong"), 2);
                        LeaveID = DbHelper.DrGetString(dr, "LeaveID");

                        if (LeaveID != "")
                        {
                            ketquaPhep = Convert.ToDouble(dr["PerTimeID"].ToString()) == 3 ? 1 : 0.5;
                            var leaveType = db.tblRef_LeaveTypes.Where(p => p.LeaveID == LeaveID && p.isTinhCong == true).FirstOrDefault();
                            if (leaveType != null)
                            {
                                r1["NghiTinhCong"] = DbHelper.DrGetDouble(r1, "NghiTinhCong") + ketquaPhep;
                                ketquaCong = 0;
                            }
                            else
                            {
                                if (DbHelper.DrGetDouble(dr, "daysOfNghiCoLuong") == 0)
                                {
                                    if (LeaveID == "KP")
                                    {
                                        r1["NghiKhongPhep"] = DbHelper.DrGetDouble(r1, "NghiKhongPhep") + ketquaPhep;
                                    }
                                    else
                                        r1["NghiKhongLuong"] = DbHelper.DrGetDouble(r1, "NghiKhongLuong") + ketquaPhep;
                                }
                                else
                                {
                                    if (LeaveID == "P")
                                    {
                                        r1["NghiPhepNam"] = DbHelper.DrGetDouble(r1, "NghiPhepNam") + ketquaPhep;
                                    }
                                    else if (LeaveID == "TS")
                                    {
                                        r1["NghiThaiSan"] = DbHelper.DrGetDouble(r1, "NghiThaiSan") + ketquaPhep;
                                    }
                                    else
                                    {
                                        r1["NghiCoLuong"] = DbHelper.DrGetDouble(r1, "NghiCoLuong") + ketquaPhep;
                                    }
                                }
                            }
                        }
                        r1["D" + ((DateTime)dr["ngay"]).Day] = (ketquaCong == 0 ? "" : ketquaCong.ToString()) + (LeaveID == "" ? "" : " " + LeaveID);
                        if (DbHelper.DrGetBoolean(dr, "tt_leTet") == true)
                        {
                            r1["NghiLe"] = DbHelper.DrGetDouble(r1, "NghiLe") + 1;
                            r1["D" + ((DateTime)dr["ngay"]).Day] = "LT";
                        }

                        if (dr["dkLamThem"] != DBNull.Value)
                        {
                            var lthem = db.tbLoaiNgayLamThems.FirstOrDefault(p => p.id.ToString() == dr["dkLamThem"].ToString());
                            r1["SoNgayCong_LamThem"] = DbHelper.DrGetDouble(r1, "SoNgayCong_LamThem") + ketquaCong;
                            ketquaCong = 0;
                            if (lthem != null)
                            {
                                r1["D" + ((DateTime)dr["ngay"]).Day] = lthem.alias + " " + r1["D" + ((DateTime)dr["ngay"]).Day].ToString();
                            }
                        }

                        r1["SoNgayCong"] = DbHelper.DrGetDouble(r1, "SoNgayCong") + ketquaCong;
                        r = r1;
                    }
                }
            }
            return dt;
        }
        public DataTable GetDataReportTangCaHangThang(List<string> listEmpID, DateTime day, DateTime todates)
        {
            DataTable dt = new DataTable();
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            #region add datacolumn
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID"),
                new DataColumn("PosName"),
                new DataColumn("AppliedDate"),
                new DataColumn("EmployeeName"),
                new DataColumn("TeamName"),
                new DataColumn("LineName"),
                new DataColumn("DepName_Final"),
                new DataColumn("NgayThuong_Normal_KhongHS",typeof(double)),
                new DataColumn("NgayThuong_Night_KhongHS",typeof(double)),
                new DataColumn("ChuNhat_Normal_KhongHS",typeof(double)),
                new DataColumn("ChuNhat_Night_KhongHS",typeof(double)),
                new DataColumn("LetTet_Normal_KhongHS",typeof(double)),
                new DataColumn("LetTet_Night_KhongHS",typeof(double)),
                new DataColumn("TongTangCa_KhongHS",typeof(double)),
                new DataColumn("NgayThuong_Normal_CoHS",typeof(double)),
                new DataColumn("NgayThuong_Night_CoHS",typeof(double)),
                new DataColumn("ChuNhat_Normal_CoHS",typeof(double)),
                new DataColumn("ChuNhat_Night_CoHS",typeof(double)),
                new DataColumn("LetTet_Normal_CoHS",typeof(double)),
                new DataColumn("LetTet_Night_CoHS",typeof(double)),
                new DataColumn("TongTangCa_CoHS",typeof(double))
            });
            #endregion
            DataTable data = new DataTable();
            data = logic.GetReportMonth(day, todates, listEmpID);

            List<string> list = new List<string>();

            if (data != null && data.Rows.Count > 0)
            {
                DataRow[] _rowlist = data.Select("", "ngay ASC");
                foreach (DataRow dr in _rowlist)
                {
                    DataRow r = null;
                    r = dt.NewRow();
                    double NightOT = Convert.ToDouble(dr["NightOT"]);
                    double NormalOT = Convert.ToDouble(dr["NormalOT"]);
                    double hesoNgay = 1.5;
                    double hesoDem = 1.8;
                    int? dkLamThem = null;
                    if (dr["dkLamThem"] != DBNull.Value)
                    {
                        dkLamThem = Convert.ToInt16(dr["dkLamThem"]);
                    }

                    if (!list.Contains(dr["EmployeeID"].ToString()))
                    {
                        list.Add(dr["EmployeeID"].ToString());
                        System.Data.DataView view = new System.Data.DataView(dt);
                        view.Sort = "EmployeeID";
                        r["EmployeeID"] = dr["EmployeeID"];
                        r["EmployeeName"] = dr["EmployeeName"];
                        r["DepName_Final"] = dr["DepName_Final"];
                        r["TeamName"] = dr["TeamName"];
                        r["LineName"] = dr["LineName"];
                        r["PosName"] = dr["PosName"];

                        r["NgayThuong_Normal_KhongHS"] = 0;
                        r["NgayThuong_Night_KhongHS"] = 0;
                        r["ChuNhat_Normal_KhongHS"] = 0;
                        r["ChuNhat_Night_KhongHS"] = 0;
                        r["LetTet_Normal_KhongHS"] = 0;
                        r["LetTet_Night_KhongHS"] = 0;
                        r["TongTangCa_KhongHS"] = 0;

                        r["NgayThuong_Normal_CoHS"] = 0;
                        r["NgayThuong_Night_CoHS"] = 0;
                        r["ChuNhat_Normal_CoHS"] = 0;
                        r["ChuNhat_Night_CoHS"] = 0;
                        r["LetTet_Normal_CoHS"] = 0;
                        r["LetTet_Night_CoHS"] = 0;
                        r["TongTangCa_CoHS"] = 0;

                        if (dr["AppliedDate"] != DBNull.Value)
                        {
                            r["AppliedDate"] = Convert.ToDateTime(dr["AppliedDate"].ToString()).ToShortDateString();
                        }
                        if (dkLamThem != null)
                        {
                            var a = db.tbLoaiNgayLamThems.Where(p => p.id == dkLamThem).FirstOrDefault();
                            if (a != null)
                            {
                                hesoNgay = a.heSoLuongNgay.Value / 100;
                                hesoDem = a.heSoLuongDem.Value / 100;
                                if (dkLamThem == 0)//Ngày chủ nhật không hệ số
                                {
                                    r["NgayThuong_Normal_KhongHS"] = NormalOT;
                                    r["NgayThuong_Night_KhongHS"] = NightOT;
                                    r["NgayThuong_Normal_CoHS"] = NormalOT * hesoNgay;
                                    r["NgayThuong_Night_CoHS"] = NightOT * hesoDem;
                                }
                                else if (dkLamThem == 1)//Ngày chủ nhật hệ số
                                {
                                    r["ChuNhat_Normal_KhongHS"] = NormalOT;
                                    r["ChuNhat_Night_KhongHS"] = NightOT;
                                    r["ChuNhat_Normal_CoHS"] = NormalOT * hesoNgay;
                                    r["ChuNhat_Night_CoHS"] = NightOT * hesoDem;
                                }
                                else if (dkLamThem == 2 || dkLamThem == 3)//Ngày lễ
                                {
                                    r["LetTet_Normal_KhongHS"] = NormalOT;
                                    r["LetTet_Night_KhongHS"] = NightOT;
                                    r["LetTet_Normal_CoHS"] = NormalOT * hesoNgay;
                                    r["LetTet_Night_CoHS"] = NightOT * hesoDem;
                                }
                            }
                            else
                            {
                                r["NgayThuong_Normal_KhongHS"] = NormalOT;
                                r["NgayThuong_Night_KhongHS"] = NightOT;
                                r["NgayThuong_Normal_CoHS"] = NormalOT * hesoNgay;
                                r["NgayThuong_Night_CoHS"] = NightOT * hesoDem;
                            }
                        }
                        else
                        {
                            r["NgayThuong_Normal_KhongHS"] = NormalOT;
                            r["NgayThuong_Night_KhongHS"] = NightOT;
                            r["NgayThuong_Normal_CoHS"] = NormalOT * hesoNgay;
                            r["NgayThuong_Night_CoHS"] = NightOT * hesoDem;
                        }
                        r["TongTangCa_KhongHS"] = NightOT + NormalOT;
                        r["TongTangCa_CoHS"] = NormalOT * hesoNgay + NightOT * hesoDem;
                        dt.Rows.Add(r);
                    }
                    else// Nếu có nhân viên trong danh sách rồi thì add thêm vào.
                    {
                        var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"].ToString() + "' ")[0];

                        if (dkLamThem != null)
                        {
                            var a = db.tbLoaiNgayLamThems.Where(p => p.id == dkLamThem).FirstOrDefault();
                            if (a != null)
                            {
                                hesoNgay = a.heSoLuongNgay.Value / 100;
                                hesoDem = a.heSoLuongDem.Value / 100;

                                if (dkLamThem == 0)//Ngày chủ nhật không hệ số
                                {
                                    r1["NgayThuong_Normal_KhongHS"] = Convert.ToDouble(r1["NgayThuong_Normal_KhongHS"]) + NormalOT;
                                    r1["NgayThuong_Night_KhongHS"] = Convert.ToDouble(r1["NgayThuong_Night_KhongHS"]) + NightOT;
                                    r1["NgayThuong_Normal_CoHS"] = Convert.ToDouble(r1["NgayThuong_Normal_CoHS"]) + NormalOT * hesoNgay;
                                    r1["NgayThuong_Night_CoHS"] = Convert.ToDouble(r1["NgayThuong_Night_CoHS"]) + NightOT * hesoDem;
                                }
                                else if (dkLamThem == 1)//Ngày chủ nhật hệ số
                                {
                                    r1["ChuNhat_Normal_KhongHS"] = Convert.ToDouble(r1["ChuNhat_Normal_KhongHS"]) + NormalOT;
                                    r1["ChuNhat_Night_KhongHS"] = Convert.ToDouble(r1["ChuNhat_Night_KhongHS"]) + NightOT;
                                    r1["ChuNhat_Normal_CoHS"] = Convert.ToDouble(r1["ChuNhat_Normal_CoHS"]) + NormalOT * hesoNgay;
                                    r1["ChuNhat_Night_CoHS"] = Convert.ToDouble(r1["ChuNhat_Night_CoHS"]) + NightOT * hesoDem;
                                }
                                else if (dkLamThem == 2 || dkLamThem == 3)//Ngày lễ
                                {
                                    r1["LetTet_Normal_KhongHS"] = Convert.ToDouble(r1["LetTet_Normal_KhongHS"]) + NormalOT;
                                    r1["LetTet_Night_KhongHS"] = Convert.ToDouble(r1["LetTet_Night_KhongHS"]) + NightOT;
                                    r1["LetTet_Normal_CoHS"] = Convert.ToDouble(r1["LetTet_Normal_CoHS"]) + NormalOT * hesoNgay;
                                    r1["LetTet_Night_CoHS"] = Convert.ToDouble(r1["LetTet_Night_CoHS"]) + NightOT * hesoDem;
                                }
                            }
                            else
                            {
                                r1["NgayThuong_Normal_KhongHS"] = Convert.ToDouble(r1["NgayThuong_Normal_KhongHS"]) + NormalOT;
                                r1["NgayThuong_Night_KhongHS"] = Convert.ToDouble(r1["NgayThuong_Night_KhongHS"]) + NightOT;
                                r1["NgayThuong_Normal_CoHS"] = Convert.ToDouble(r1["NgayThuong_Normal_CoHS"]) + NormalOT * hesoNgay;
                                r1["NgayThuong_Night_CoHS"] = Convert.ToDouble(r1["NgayThuong_Night_CoHS"]) + NightOT * hesoDem;
                            }
                        }
                        else
                        {
                            r1["NgayThuong_Normal_KhongHS"] = Convert.ToDouble(r1["NgayThuong_Normal_KhongHS"]) + NormalOT;
                            r1["NgayThuong_Night_KhongHS"] = Convert.ToDouble(r1["NgayThuong_Night_KhongHS"]) + NightOT;
                            r1["NgayThuong_Normal_CoHS"] = Convert.ToDouble(r1["NgayThuong_Normal_CoHS"]) + NormalOT * hesoNgay;
                            r1["NgayThuong_Night_CoHS"] = Convert.ToDouble(r1["NgayThuong_Night_CoHS"]) + NightOT * hesoDem;
                        }
                        r1["TongTangCa_KhongHS"] = Convert.ToDouble(r1["TongTangCa_KhongHS"]) + NightOT + NormalOT;
                        r1["TongTangCa_CoHS"] = Convert.ToDouble(r1["TongTangCa_CoHS"]) + NormalOT * hesoNgay + NightOT * hesoDem;
                    }
                }
            }
            return dt;
        }
        public DataTable GetDataReportTangCaKhongHeSo(List<string> listEmpID, DateTime day, DateTime todates)
        {
            DataTable dt = new DataTable();
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            #region add datacolumn
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID"),
                new DataColumn("PosName"),
                new DataColumn("AppliedDate"),
                new DataColumn("EmployeeName"),
                new DataColumn("TeamName"),
                new DataColumn("LineName"),
                new DataColumn("DepName_Final"),
                new DataColumn("TangCa"),
                new DataColumn("tgTinhTangCa"),
                new DataColumn("D1",typeof(double)),
                new DataColumn("D2",typeof(double)),
                new DataColumn("D3",typeof(double)),
                new DataColumn("D4",typeof(double)),
                new DataColumn("D5",typeof(double)),
                new DataColumn("D6",typeof(double)),
                new DataColumn("D7",typeof(double)),
                new DataColumn("D8",typeof(double)),
                new DataColumn("D9",typeof(double)),
                new DataColumn("D10",typeof(double)),
                new DataColumn("D11",typeof(double)),
                new DataColumn("D12",typeof(double)),
                new DataColumn("D13",typeof(double)),
                new DataColumn("D14",typeof(double)),
                new DataColumn("D15",typeof(double)),
                new DataColumn("D16",typeof(double)),
                new DataColumn("D17",typeof(double)),
                new DataColumn("D18",typeof(double)),
                new DataColumn("D19",typeof(double)),
                new DataColumn("D20",typeof(double)),
                new DataColumn("D21",typeof(double)),
                new DataColumn("D22",typeof(double)),
                new DataColumn("D23",typeof(double)),
                new DataColumn("D24",typeof(double)),
                new DataColumn("D25",typeof(double)),
                new DataColumn("D26",typeof(double)),
                new DataColumn("D27",typeof(double)),
                new DataColumn("D28",typeof(double)),
                new DataColumn("D29",typeof(double)),
                new DataColumn("D30",typeof(double)),
                new DataColumn("D31",typeof(double)),
                new DataColumn("N1",typeof(double)),
                new DataColumn("N2",typeof(double)),
                new DataColumn("N3",typeof(double)),
                new DataColumn("N4",typeof(double)),
                new DataColumn("N5",typeof(double)),
                new DataColumn("N6",typeof(double)),
                new DataColumn("N7",typeof(double)),
                new DataColumn("N8",typeof(double)),
                new DataColumn("N9",typeof(double)),
                new DataColumn("N10",typeof(double)),
                new DataColumn("N11",typeof(double)),
                new DataColumn("N12",typeof(double)),
                new DataColumn("N13",typeof(double)),
                new DataColumn("N14",typeof(double)),
                new DataColumn("N15",typeof(double)),
                new DataColumn("N16",typeof(double)),
                new DataColumn("N17",typeof(double)),
                new DataColumn("N18",typeof(double)),
                new DataColumn("N19",typeof(double)),
                new DataColumn("N20",typeof(double)),
                new DataColumn("N21",typeof(double)),
                new DataColumn("N22",typeof(double)),
                new DataColumn("N23",typeof(double)),
                new DataColumn("N24",typeof(double)),
                new DataColumn("N25",typeof(double)),
                new DataColumn("N26",typeof(double)),
                new DataColumn("N27",typeof(double)),
                new DataColumn("N28",typeof(double)),
                new DataColumn("N29",typeof(double)),
                new DataColumn("N30",typeof(double)),
                new DataColumn("N31",typeof(double))
            });
            #endregion
            DataTable data = new DataTable();
            data = logic.GetReportMonth(day, todates, listEmpID);

            List<string> list = new List<string>();

            if (data != null && data.Rows.Count > 0)
            {
                DataRow[] _rowlist = data.Select("", "ngay ASC");
                foreach (DataRow dr in _rowlist)
                {
                    DataRow r = null;
                    r = dt.NewRow();
                    r["TangCa"] = dr["tgTinhTangCa"];

                    if (!list.Contains(dr["EmployeeID"].ToString()))
                    {
                        list.Add(dr["EmployeeID"].ToString());
                        System.Data.DataView view = new System.Data.DataView(dt);
                        view.Sort = "EmployeeID";
                        r["EmployeeID"] = dr["EmployeeID"];
                        r["EmployeeName"] = dr["EmployeeName"];
                        r["DepName_Final"] = dr["DepName_Final"];
                        r["TeamName"] = dr["TeamName"];
                        r["LineName"] = dr["LineName"];
                        r["tgTinhTangCa"] = dr["tgTinhTangCa"];
                        r["PosName"] = dr["PosName"];
                        if (dr["AppliedDate"] != DBNull.Value)
                        {
                            r["AppliedDate"] = Convert.ToDateTime(dr["AppliedDate"].ToString()).ToShortDateString();
                        }

                        r["D" + ((DateTime)dr["ngay"]).Day] = dr["NightOT"];
                        r["N" + ((DateTime)dr["ngay"]).Day] = dr["NormalOT"];
                        dt.Rows.Add(r);
                    }
                    else// Nếu có nhân viên trong danh sách rồi thì add thêm vào.
                    {
                        var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"].ToString() + "' ")[0];
                        r1["TangCa"] = DbHelper.DrGetDouble(r1, "TangCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");


                        r1["D" + ((DateTime)dr["ngay"]).Day] = dr["NightOT"];
                        r1["N" + ((DateTime)dr["ngay"]).Day] = dr["NormalOT"];
                    }
                }
            }
            return dt;
        }
        public DataTable GetDataReportTangCaCoHeSo(List<string> listEmpID, DateTime day, DateTime todates)
        {
            DataTable dt = new DataTable();
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            #region add datacolumn
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("EmployeeID"),
                new DataColumn("PosName"),
                new DataColumn("AppliedDate"),
                new DataColumn("EmployeeName"),
                new DataColumn("TeamName"),
                new DataColumn("LineName"),
                new DataColumn("DepName_Final"),
                new DataColumn("tgTinhTangCa"),
                new DataColumn("TangCa"),
                new DataColumn("D1",typeof(double)),
                new DataColumn("D2",typeof(double)),
                new DataColumn("D3",typeof(double)),
                new DataColumn("D4",typeof(double)),
                new DataColumn("D5",typeof(double)),
                new DataColumn("D6",typeof(double)),
                new DataColumn("D7",typeof(double)),
                new DataColumn("D8",typeof(double)),
                new DataColumn("D9",typeof(double)),
                new DataColumn("D10",typeof(double)),
                new DataColumn("D11",typeof(double)),
                new DataColumn("D12",typeof(double)),
                new DataColumn("D13",typeof(double)),
                new DataColumn("D14",typeof(double)),
                new DataColumn("D15",typeof(double)),
                new DataColumn("D16",typeof(double)),
                new DataColumn("D17",typeof(double)),
                new DataColumn("D18",typeof(double)),
                new DataColumn("D19",typeof(double)),
                new DataColumn("D20",typeof(double)),
                new DataColumn("D21",typeof(double)),
                new DataColumn("D22",typeof(double)),
                new DataColumn("D23",typeof(double)),
                new DataColumn("D24",typeof(double)),
                new DataColumn("D25",typeof(double)),
                new DataColumn("D26",typeof(double)),
                new DataColumn("D27",typeof(double)),
                new DataColumn("D28",typeof(double)),
                new DataColumn("D29",typeof(double)),
                new DataColumn("D30",typeof(double)),
                new DataColumn("D31",typeof(double)),
                new DataColumn("N1",typeof(double)),
                new DataColumn("N2",typeof(double)),
                new DataColumn("N3",typeof(double)),
                new DataColumn("N4",typeof(double)),
                new DataColumn("N5",typeof(double)),
                new DataColumn("N6",typeof(double)),
                new DataColumn("N7",typeof(double)),
                new DataColumn("N8",typeof(double)),
                new DataColumn("N9",typeof(double)),
                new DataColumn("N10",typeof(double)),
                new DataColumn("N11",typeof(double)),
                new DataColumn("N12",typeof(double)),
                new DataColumn("N13",typeof(double)),
                new DataColumn("N14",typeof(double)),
                new DataColumn("N15",typeof(double)),
                new DataColumn("N16",typeof(double)),
                new DataColumn("N17",typeof(double)),
                new DataColumn("N18",typeof(double)),
                new DataColumn("N19",typeof(double)),
                new DataColumn("N20",typeof(double)),
                new DataColumn("N21",typeof(double)),
                new DataColumn("N22",typeof(double)),
                new DataColumn("N23",typeof(double)),
                new DataColumn("N24",typeof(double)),
                new DataColumn("N25",typeof(double)),
                new DataColumn("N26",typeof(double)),
                new DataColumn("N27",typeof(double)),
                new DataColumn("N28",typeof(double)),
                new DataColumn("N29",typeof(double)),
                new DataColumn("N30",typeof(double)),
                new DataColumn("N31",typeof(double))
            });
            #endregion
            DataTable data = new DataTable();
            data = logic.GetReportMonth(day, todates, listEmpID);

            List<string> list = new List<string>();

            if (data != null && data.Rows.Count > 0)
            {
                DataRow[] _rowlist = data.Select("", "ngay ASC");
                foreach (DataRow dr in _rowlist)
                {
                    DataRow r = null;
                    r = dt.NewRow();
                    double NightOT = 0;
                    double NormalOT = 0;

                    if (!list.Contains(dr["EmployeeID"].ToString()))
                    {
                        list.Add(dr["EmployeeID"].ToString());
                        System.Data.DataView view = new System.Data.DataView(dt);
                        view.Sort = "EmployeeID";
                        r["EmployeeID"] = dr["EmployeeID"];
                        r["EmployeeName"] = dr["EmployeeName"];
                        r["DepName_Final"] = dr["DepName_Final"];
                        r["TeamName"] = dr["TeamName"];
                        r["LineName"] = dr["LineName"];
                        r["tgTinhTangCa"] = dr["tgTinhTangCa"];
                        r["PosName"] = dr["PosName"];
                        if (dr["AppliedDate"] != DBNull.Value)
                        {
                            r["AppliedDate"] = Convert.ToDateTime(dr["AppliedDate"].ToString()).ToShortDateString();
                        }
                        if (dr["NightOT"] != DBNull.Value)
                        {
                            NightOT = Convert.ToDouble(dr["NightOT"]);
                        }
                        if (dr["NormalOT"] != DBNull.Value)
                        {
                            NormalOT = Convert.ToDouble(dr["NormalOT"]);
                        }
                        if (dr["dkLamThem"] != DBNull.Value)
                        {
                            var dkLamThem = Convert.ToInt16(dr["dkLamThem"]);
                            var heso = db.tbLoaiNgayLamThems.Where(p => p.id == dkLamThem).FirstOrDefault();
                            if (heso != null)
                            {
                                r["D" + ((DateTime)dr["ngay"]).Day] = NightOT * heso.heSoLuongDem / 100;
                                r["N" + ((DateTime)dr["ngay"]).Day] = NormalOT * heso.heSoLuongNgay / 100;
                            }
                            else
                            {
                                r["D" + ((DateTime)dr["ngay"]).Day] = NightOT * 1.8;
                                r["N" + ((DateTime)dr["ngay"]).Day] = NormalOT * 1.5;
                            }
                        }
                        else
                        {
                            r["D" + ((DateTime)dr["ngay"]).Day] = NightOT * 1.8;
                            r["N" + ((DateTime)dr["ngay"]).Day] = NormalOT * 1.5;
                        }
                        r["TangCa"] = Convert.ToDouble(r["D" + ((DateTime)dr["ngay"]).Day]) + Convert.ToDouble(r["N" + ((DateTime)dr["ngay"]).Day]);
                        dt.Rows.Add(r);
                    }
                    else// Nếu có nhân viên trong danh sách rồi thì add thêm vào.
                    {
                        var r1 = dt.Select("EmployeeID='" + dr["EmployeeID"].ToString() + "' ")[0];
                        if (dr["NightOT"] != DBNull.Value)
                        {
                            NightOT = Convert.ToDouble(dr["NightOT"]);
                        }
                        if (dr["NormalOT"] != DBNull.Value)
                        {
                            NormalOT = Convert.ToDouble(dr["NormalOT"]);
                        }
                        if (dr["dkLamThem"] != DBNull.Value)
                        {
                            var dkLamThem = Convert.ToInt16(dr["dkLamThem"]);
                            var heso = db.tbLoaiNgayLamThems.Where(p => p.id == dkLamThem).FirstOrDefault();
                            if (heso != null)
                            {
                                r1["D" + ((DateTime)dr["ngay"]).Day] = NightOT * heso.heSoLuongDem / 100;
                                r1["N" + ((DateTime)dr["ngay"]).Day] = NormalOT * heso.heSoLuongNgay / 100;
                            }
                            else
                            {
                                r1["D" + ((DateTime)dr["ngay"]).Day] = NightOT * 1.8;
                                r1["N" + ((DateTime)dr["ngay"]).Day] = NormalOT * 1.5;
                            }
                        }
                        else
                        {
                            r1["D" + ((DateTime)dr["ngay"]).Day] = NightOT * 1.8;
                            r1["N" + ((DateTime)dr["ngay"]).Day] = NormalOT * 1.5;
                        }
                        r1["TangCa"] = Convert.ToDouble(r1["TangCa"]) + Convert.ToDouble(r1["D" + ((DateTime)dr["ngay"]).Day]) + Convert.ToDouble(r1["N" + ((DateTime)dr["ngay"]).Day]);
                    }
                }
            }
            return dt;
        }
        public DataTable GetDataReportMonthForm(List<string> listEmpID, DateTime day, DateTime todates)
        {
            DataTable dt = new DataTable();
            List<string> list = new List<string>();
            dt = GetDataReportMonthExcel(listEmpID, day, todates);
            DataTable dtResult = dt.Copy();
            foreach (DataRow row in dt.Rows)
            {
                DataRow newRow = dtResult.NewRow();
                newRow["EmployeeID"] = row["EmployeeID"];
                newRow["EmployeeName"] = row["EmployeeName"];
                newRow["DepName_Final"] = row["DepName_Final"];
                newRow["vitri"] = "2";
                for (int i = 1; i <= 31; i++)
                {
                    newRow["D" + i] = row["T" + i];
                }
                dtResult.Rows.Add(newRow);
            }
            return dtResult.Select("", "EmployeeID,vitri ASC").CopyToDataTable();
        }
        public DataTable GetReportNhanVienVangMat(DateTime day, DateTime todates, string LoaiNghi, List<string> ucChonDoiTuong_DS1)
        {
            DataTable data = logic.GetReportNhanVienVangMat(day, todates, ucChonDoiTuong_DS1, LoaiNghi);
            data.Columns.Add("loainghi");
            data.Columns.Add("songay");
            return data;
        }

        //public class Cong_item
        //{
        //    public double N1, N2, n3;//.....
        //}

        //public class bc_item
        //{


        //    public double luong;
        //    public string name;
        //    //...

        //    public Cong_item cong, tangca;

        //    public bc_item(DataRow dr)
        //    {
        //        luong = DbHelper.DrGetDouble(dr, "luong");
        //        name = DbHelper.DrGetString(dr, "ten");
        //        //..
        //    }

        //    public void TINHTOAN()
        //    {
        //        //tinh toan va gan luong
        //    }


        //    void write2exxcel(ExcelExportHelper ex, int x, int y)
        //    {
        //        //ex.write...
        //    }
        //}




        //public void GetBaoCao()
        //{
        //    DataTable dt = Provider.ExecuteDataTableReader("");

        //    var lst = new List<bc_item>();
        //    foreach (DataRow dr in dt.Rows)
        //        lst.Add(new bc_item(dr));

        //    ExcelExportHelper ex = new ExcelExportHelper();
        //    foreach (bc_item it in lst)
        //        it.write2exxcel(ex);

        //    //ex.Flush...
        //}


        public DataTable GetDataReportDuLieuChamCong(List<string> dtEmpID, DateTime day, DateTime todates, string NoNV)
        {
            return logic.GetReportDuLieuChamCong(day, todates, dtEmpID, NoNV);
        }
        public DataTable GetDataReportDuLieuChamCongFail(List<string> dtEmpID, DateTime day, DateTime todates, string NoNV)
        {
            return logic.GetReportDuLieuChamCongFail(day, todates, dtEmpID, NoNV);
        }
        public DataTable GetDataUngVienPVTrongNgay()
        {
            return logic.GetUngVienPhongVanTrongNgay();
        }
        public DataTable GetDuLieuNhanVienChamCong(List<string> dtEmpID, DateTime day, DateTime todates)
        {
            return logic.GetDuLieuNhanVienChamCong(day, todates, dtEmpID);
        }





    }
}
