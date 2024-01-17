using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class PhanTichBangCong : dlgCustomBase
    {
        DataTable dt = new DataTable();
        dsXuLyQuetThe ds = new dsXuLyQuetThe();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        public PhanTichBangCong()
        {
            InitializeComponent();
        }

        private void XuLyDuLieu_Load(object sender, EventArgs e)
        {
            this.Form_Title = SelectTranslate("PhanTichBangCong_Tilte", LoginHelper.langTrans);
            this.Text = SelectTranslate("PhanTichBangCong_Tilte", LoginHelper.langTrans);
            this.Form_Description = SelectTranslate("PhanTichBangCong_Des", LoginHelper.langTrans);
            
        }

        private void btnDoImport_Click(object sender, EventArgs e)
        {
            bgw_import.RunWorkerAsync();
        }

        private bool isLuongMoi(string empID, DateTime ngay)
        {
            var rs = ds.tblEmpSalary.Where(p => p.EmployeeID == empID && p.DateChange >= chonKyLuong1.TuNgay && p.DateChange <= chonKyLuong1.DenNgay);

            if (rs.Count() > 0)
            {
                var l = rs.OrderByDescending(p => p.DateChange).First();

                if (ngay >= l.DateChange)
                {
                    return true;
                }
                else

                    return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 1: Nghỉ phép năm 
        /// 2: Nghỉ chế độ
        /// 3: Nghỉ có lương.
        /// 4: Tính công ngày thường.
        /// 5: Tăng ca thường.
        /// 6: Tăng ca chủ nhật.
        /// 7: Tăng ca lễ tết.
        /// </summary>
        /// <param name="kq"></param>
        /// <param name="type">12313</param>
        /// <param name="khongTinhHeSo">Không tính hệ số</param>
        /// <returns></returns>
        private double tinhCongTheoLoai(dsXuLyQuetThe.tbKetQuaQuetTheRow kq, int type)
        {
            double result = 0;

            double hslNgay = 1.5, hslDem = 2.0;

            if (!kq.IsdkLamThemNull())
            {
                var ot_HSL = ds.tbLoaiNgayLamThem.Where(p => p.id == kq.dkLamThem).FirstOrDefault();

                if (ot_HSL != null)
                {
                    hslNgay = ot_HSL.IsheSoLuongNgayNull() ? 0 : ((double)ot_HSL.heSoLuongNgay / 100);

                    hslDem = ot_HSL.IsheSoLuongDemNull() ? 0 : ((double)ot_HSL.heSoLuongDem / 100);
                }
            }
            switch (type)
            {
                #region Nghỉ phép
                case 1: // 1: Nghỉ phép năm.

                    if (kq.tt_nghiPhep == 1 && kq.tt_nghiPhep_Alias == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam])
                    {
                        result = kq.daysOfNghiCoLuong;
                    }

                    break;

                case 2: // 2: Nghỉ chế độ.

                    if (kq.tt_nghiPhep == 1 && 
                        (kq.tt_nghiPhep_Alias == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.KetHon] 
                        || kq.tt_nghiPhep_Alias == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.MaChay]
                        ))
                    {
                        result = kq.daysOfNghiCoLuong;
                    }

                    break;

                case 3: // 2: Nghỉ có lương.

                    if (kq.tt_nghiPhep == 1 
                        && kq.tt_nghiPhep_Alias != Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam] 
                        && kq.tt_nghiPhep_Alias != Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.KetHon]
                        && kq.tt_nghiPhep_Alias != Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.MaChay])
                    {
                        result = kq.daysOfNghiCoLuong;
                    }

                    break;

                #endregion

                #region Tính công.
                case 4:// 4: Tính công ngày thường.

                    if (kq.IsdkLamThemNull())
                    {
                        result = kq.IskqNgayCongNull() ? 0 : kq.kqNgayCong;
                    }

                    break;

                #endregion

                #region Tính tăng ca.
                case 5: // 5: Tăng ca thường.

                    if (kq.IsdkLamThemNull())
                    {
                        result += (kq.IsNightOTNull() ? 0 : kq.NightOT) * hslDem;

                        result += (kq.IsNormalOTNull() ? 0 : kq.NormalOT) * hslNgay;
                    }
                    else if (kq.dkLamThem == 0)
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) * kq.SoTiengTinhCa * hslNgay;

                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay) * kq.SoTiengTinhCa * hslDem;

                        result += (kq.IsNightOTNull() ? 0 : kq.NightOT) * hslDem;

                        result += (kq.IsNormalOTNull() ? 0 : kq.NormalOT) * hslNgay;
                    }

                    break;

                case 6: // 6: Tăng ca chủ nhật. 1. ngày nghỉ. 2. ngày nghỉ bù lễ

                    if (!kq.IsdkLamThemNull() && (kq.dkLamThem == 2 || kq.dkLamThem == 1))
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) * kq.SoTiengTinhCa * hslNgay;

                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay) * kq.SoTiengTinhCa * hslDem;

                        result += (kq.IsNormalOTNull() ? 0 : kq.NormalOT) * hslNgay;

                        result += (kq.IsNightOTNull() ? 0 : kq.NightOT) * hslDem;
                    }

                    break;

                case 7: // 7: Tăng ca lễ tết.

                    if (!kq.IsdkLamThemNull() && kq.dkLamThem == 3)
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) * kq.SoTiengTinhCa * hslNgay;

                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay) * kq.SoTiengTinhCa * hslDem;

                        result += (kq.IsNormalOTNull() ? 0 : kq.NormalOT) * hslNgay;

                        result += (kq.IsNightOTNull() ? 0 : kq.NightOT) * hslDem;
                    }

                    break;

                case 8: // kq.SoTiengTinhCa: Nghỉ lễ tết.
                    // Nếu nghỉ lễ thì được hưởng lương ngày hôm đó.
                    // Không tính ngày chủ nhật.
                    if (!kq.IsdkLamThemNull() && kq.tt_leTet && kq.ngay.DayOfWeek != DayOfWeek.Sunday)
                    {
                        result = 1;
                    }

                    break;

                #endregion

                #region Tính tăng ca không hệ số.

                case 10: // 10: Tăng ca NormalOT.

                    if (kq.IsdkLamThemNull())
                    {
                        result += (kq.IsNormalOTNull() ? 0 : kq.NormalOT);
                    }
                    else if (kq.dkLamThem == 0)
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) * kq.SoTiengTinhCa;

                        result += (kq.IsNormalOTNull() ? 0 : kq.NormalOT);
                    }

                    break;

                case 11: // 11: Tăng ca NormalOT_ChuNhat. 1. ngày nghỉ. 2. ngày nghỉ bù lễ

                    if (!kq.IsdkLamThemNull() && (kq.dkLamThem == 1 || kq.dkLamThem == 2))
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) * kq.SoTiengTinhCa;

                        result += (kq.IsNormalOTNull() ? 0 : kq.NormalOT);
                    }

                    break;

                case 12: // 12: Tăng ca tongNormalOT_LT.

                    if (!kq.IsdkLamThemNull() && kq.dkLamThem == 3)
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) * kq.SoTiengTinhCa;

                        result += (kq.IsNormalOTNull() ? 0 : kq.NormalOT);
                    }

                    break;

                case 13: // 10: Tăng ca NightOT.

                    if (kq.IsdkLamThemNull())
                    {
                        result += (kq.IsNightOTNull() ? 0 : kq.NightOT);
                    }
                    else if (kq.dkLamThem == 0)
                    {
                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay) * kq.SoTiengTinhCa;

                        result += (kq.IsNightOTNull() ? 0 : kq.NightOT);
                    }

                    break;

                case 14: // 11: Tăng ca NightOT_ChuNhat. 1. ngày nghỉ. 2. ngày nghỉ bù lễ

                    if (!kq.IsdkLamThemNull() && (kq.dkLamThem == 1 || kq.dkLamThem == 2))
                    {
                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay) * kq.SoTiengTinhCa;

                        result += (kq.IsNightOTNull() ? 0 : kq.NightOT);
                    }

                    break;

                case 15: // 12: Tăng ca NightOT_LT.

                    if (!kq.IsdkLamThemNull() && kq.dkLamThem == 3)
                    {
                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay) * kq.SoTiengTinhCa;

                        result += (kq.IsNightOTNull() ? 0 : kq.NightOT);
                    }

                    break;

                case 20: // 20: Nghỉ không lương.

                    if (!kq.IsLeaveIDNull() && kq.LeaveID != "KP" && kq.daysOfNghiCoLuong == 0 )
                    {
                        var CT = db.tblRef_LeaveTypes.Where(p => p.LeaveID == kq.LeaveID && p.isTinhCong == true).FirstOrDefault();

                        if(CT == null)
                        {
                            if (kq.PerTimeID == 3 )
                            {
                                result += kq.PerTimeID == 3 ? 1 : 0.5;
                            }
                            if (kq.PerTimeID != 3  && (kq.PerTimeID == 1 || kq.PerTimeID == 2))
                            {
                                result += kq.PerTimeID == 3 ? 1 : 0.5;
                            }
                        }
                    }

                    break;

                case 21: // 21: Nghỉ không phép.

                    if (!kq.IsLeaveIDNull() && kq.LeaveID == "KP" && kq.IsdkLamThemNull())
                    {
                        result += 1;
                    }

                    break;

                case 22: // 22: Nghỉ không phép làm thêm.

                    if (!kq.IsLeaveIDNull() && kq.LeaveID == "KP" && !kq.IsdkLamThemNull())
                    {
                        result += 1;
                    }

                    break;


                case 23: // 23: Tăng ca tongCongNormalDay.
                    if (kq.IsdkLamThemNull() || ( !kq.IsdkLamThemNull() && kq.dkLamThem == 0))
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) ;
                    }

                    break;

                case 24: // 24: Tăng ca tongCongNightDay.
                    if (kq.IsdkLamThemNull() || (!kq.IsdkLamThemNull() && kq.dkLamThem == 0))
                    {
                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay);
                    }

                    break;

                case 25: // 23: Tăng ca tongCongNormalDay_ChuNhat Không nhân hệ số. //phước add thêm 15/02/2019

                    if (!kq.IsdkLamThemNull() && (kq.dkLamThem == 1 || kq.dkLamThem == 2))
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) ;  
                    }

                    break;

                case 26: // 26: Tăng ca tongCongNightDay_ChuNhat Không nhân hệ số. //phước add thêm 15/02/2019

                    if (!kq.IsdkLamThemNull() && (kq.dkLamThem == 1 || kq.dkLamThem == 2))
                    {
                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay);
                    }

                    break;
                case 27: //27: Tăng ca tongCongNormalDay_LT Không nhân hệ số. //phước add thêm 15/02/2019

                    if (!kq.IsdkLamThemNull() && kq.dkLamThem == 3 )
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) ;
                    }

                    break;

                case 28: //28: Tăng ca tongCongNightDay_LT Không nhân hệ số. //phước add thêm 15/02/2019

                    if (!kq.IsdkLamThemNull() && kq.dkLamThem == 3)
                    {
                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay);
                    }

                    break;


                case 29: // 29: Tăng ca tongCongNormalDay.
                    if (kq.IsdkLamThemNull() || (!kq.IsdkLamThemNull() && kq.dkLamThem == 0))
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) * kq.SoTiengTinhCa ;
                    }

                    break;

                case 30: // 30: Tăng ca tongCongNightDay.
                    if (kq.IsdkLamThemNull() || (!kq.IsdkLamThemNull() && kq.dkLamThem == 0))
                    {
                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay) * kq.SoTiengTinhCa;
                    }

                    break;

                case 31: // 23: Tăng ca tongCongNormalDay_ChuNhat Không nhân hệ số. //phước add thêm 15/02/2019

                    if (!kq.IsdkLamThemNull() && (kq.dkLamThem == 1 || kq.dkLamThem == 2))
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) * kq.SoTiengTinhCa;
                    }

                    break;

                case 32: // 26: Tăng ca tongCongNightDay_ChuNhat Không nhân hệ số. //phước add thêm 15/02/2019

                    if (!kq.IsdkLamThemNull() && (kq.dkLamThem == 1 || kq.dkLamThem == 2))
                    {
                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay) * kq.SoTiengTinhCa;
                    }

                    break;
                case 33: //27: Tăng ca tongCongNormalDay_LT Không nhân hệ số. //phước add thêm 15/02/2019

                    if (!kq.IsdkLamThemNull() && kq.dkLamThem == 3)
                    {
                        result += (kq.IsNormalDayNull() ? 0 : kq.NormalDay) * kq.SoTiengTinhCa;
                    }

                    break;

                case 34: //28: Tăng ca tongCongNightDay_LT Không nhân hệ số. //phước add thêm 15/02/2019

                    if (!kq.IsdkLamThemNull() && kq.dkLamThem == 3)
                    {
                        result += (kq.IsNightDayNull() ? 0 : kq.NightDay) * kq.SoTiengTinhCa;
                    }

                    break;

                #endregion

                #region Tính ra vào giữa ca.
                case 35: //35: Tính ra vào giữa ca.
                    result += (kq.IsNormalOISDayNull() ? 0 : kq.NormalOISDay);
                    result += (kq.IsNightOISDayNull() ? 0 : kq.NightOISDay);
                    break;
                #endregion

                default:

                    result = 0;

                    break;
            }

            return result;
        }

        private void bgw_import_DoWork(object sender, DoWorkEventArgs e)
        {
            string thongtin = "";

            DateTime thangXuLy = chonKyLuong1.Thang;

            if (IsLock.IsLock.Check_IsLock("tbBangCongThang", chonKyLuong1.TuNgay) || IsLock.IsLock.Check_IsLock("tbBangCongThang", chonKyLuong1.DenNgay))
            {
                GUIHelper.MessageBox(string.Format("Dữ liệu đã chốt công từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy} khổng thể thao tác!", chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));

                return;
            }
            try
            {
                var dtEmp = Provider.ExecuteDataTableReader("p_getAllEmpIDtbKetQuaQuetThe"
                                                            , new System.Data.SqlClient.SqlParameter("tuNgay", chonKyLuong1.TuNgay)
                                                            , new System.Data.SqlClient.SqlParameter("denNgay", chonKyLuong1.DenNgay));

                bgw_import.ReportProgress(1, dtEmp.Rows.Count);

                bgw_import.ReportProgress(4, "Đang lấy dữ liệu");

                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Đang lấy dữ liệu", DateTime.Now));

                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Danh sách nhân viên tính lương trong tháng {1:MM/yyyy}: {2:n0} records", DateTime.Now, thangXuLy, dtEmp.Rows.Count));
                
                #region Sang công tháng
                if(chk_SanCongThang.Checked)
                {
                    bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Tính lại ngày công tính lương", DateTime.Now));

                    foreach (DataRow rEmp in dtEmp.Rows)
                    {
                        string empID = rEmp["EmployeeID"].ToString();

                        Provider.ExecNoneQuery("p_tinhCong_SangCongThang", new SqlParameter("empID", empID), new SqlParameter("thangXuLy", thangXuLy));
                    }

                    bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Tính lại bảng công thành công", DateTime.Now));
                }
                #endregion

                Provider.LoadDataByProc(ds
                                        , "tbKetQuaQuetthe"
                                        , "p_BangCongThang_getAllKQQT"
                                        , new System.Data.SqlClient.SqlParameter("tuNgay", chonKyLuong1.TuNgay)
                                        , new System.Data.SqlClient.SqlParameter("denNgay", chonKyLuong1.DenNgay));
                
                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Dữ liệu kết quả quẹt thẻ: {1:n0} records", DateTime.Now, ds.tbKetQuaQuetThe.Rows.Count));
                
                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Reset bảng công tháng: {1:n0} records", DateTime.Now, Provider.ExecNoneQuery("p_tinhCong_ResetBangCongThang", new System.Data.SqlClient.SqlParameter("thang", chonKyLuong1.Thang))));
                
                Provider.LoadDataBySql(ds, "tblEmpSalary", "SELECT * FROM tblEmpSalary");
                
                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Dữ liệu thay đổi lương: {1:n0} records", DateTime.Now, ds.tblEmpSalary.Rows.Count));
                
                Provider.LoadDataBySql(ds, "tbLoaiNgayLamThem", "SELECT * FROM tbLoaiNgayLamThem");
                
                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Dữ liệu loại ngày làm thêm: {1:n0} records", DateTime.Now, ds.tbLoaiNgayLamThem.Rows.Count));
                
                int count = 0;
                
                bgw_import.ReportProgress(4, "Đang xử lý dữ liệu");
                
                foreach (DataRow rEmp in dtEmp.Rows)
                {
                    string empID = rEmp["EmployeeID"].ToString();

                    string strAction = "";

                    var _lKQ = ds.tbKetQuaQuetThe.Where(p => p.EmployeeID == empID && p.ngay >= chonKyLuong1.TuNgay && p.ngay <= chonKyLuong1.DenNgay);

                    var bc = ds.tbBangCongThang.Where(p => p.EmployeeID == empID && p.thang == thangXuLy).FirstOrDefault();

                    if (bc == null)
                    {
                        bc = ds.tbBangCongThang.NewRow() as dsXuLyQuetThe.tbBangCongThangRow;

                        bc.thang = thangXuLy;

                        bc.EmployeeID = empID;

                        bc.tongCong_CuMoi = 0;

                        bc.tongNghiKhongPhepLThem = 0;

                        #region Tính công mới
                        bc.tongNghiPhepNam_Moi = 0;

                        bc.tongNghiCheDo_Moi = 0;

                        bc.tongNghiKhongLuong_Moi = 0;

                        bc.tongNghiKhongPhep_Moi = 0;

                        bc.tongNghiCoLuong_Moi = 0;

                        bc.tongNghiLT_Moi = 0;

                        bc.tongCong_Moi = 0;

                        bc.tongTCChuNhat_Moi = 0;

                        bc.tongTCLeTet_Moi = 0;

                        bc.tongTC_Moi = 0;
                        #endregion

                        #region Tính công cũ
                        bc.tongNghiPhepNam_Cu = 0;

                        bc.tongNghiCheDo_Cu = 0;

                        bc.tongNghiKhongLuong_Cu = 0;

                        bc.tongNghiKhongPhep_Cu = 0;

                        bc.tongNghiCoLuong_Cu = 0;

                        bc.tongNghiLT_Cu = 0;

                        bc.tongCong_Cu = 0;

                        bc.tongTCChuNhat_Cu = 0;

                        bc.tongTCLeTet_Cu = 0;

                        bc.tongTC_Cu = 0;
                        #endregion

                        #region Tính tăng ca ngày đêm không hệ số
                        bc.tongNormalOT_Cu = 0;

                        bc.tongNormalOT_ChuNhat_Cu = 0;

                        bc.tongNormalOT_LT_Cu = 0;

                        bc.tongNightOT_Cu = 0;

                        bc.tongNightOT_ChuNhat_Cu = 0;

                        bc.tongNightOT_LT_Cu = 0;

                        bc.tongNormalOT_Moi = 0;

                        bc.tongNormalOT_ChuNhat_Moi = 0;

                        bc.tongNormalOT_LT_Moi = 0;

                        bc.tongNightOT_Moi = 0;

                        bc.tongNightOT_ChuNhat_Moi = 0;

                        bc.tongNightOT_LT_Moi = 0;
                        #endregion

                        #region Tính Ngày công làm thêm không nhân hệ số

                        bc.tongCongNormalDay_Cu = 0;
                        bc.tongCongNormalDay_Moi = 0;
                        bc.tongCongNormalDay_ChuNhat_Cu = 0;
                        bc.tongCongNormalDay_ChuNhat_Moi = 0;
                        bc.tongCongNormalDay_LT_Cu = 0;
                        bc.tongCongNormalDay_LT_Moi = 0;
                        bc.tongCongNightDay_Cu = 0;
                        bc.tongCongNightDay_Moi = 0;
                        bc.tongCongNightDay_ChuNhat_Cu = 0;
                        bc.tongCongNightDay_ChuNhat_Moi = 0;
                        bc.tongCongNightDay_LT_Cu = 0;
                        bc.tongCongNightDay_LT_Moi = 0;
                        #endregion

                        #region Tính Giờ công làm thêm không nhân hệ số

                        bc.tongGioNormalDay_Cu = 0;
                        bc.tongGioNormalDay_Moi = 0;
                        bc.tongGioNormalDay_ChuNhat_Cu = 0;
                        bc.tongGioNormalDay_ChuNhat_Moi = 0;
                        bc.tongGioNormalDay_LT_Cu = 0;
                        bc.tongGioNormalDay_LT_Moi = 0;
                        bc.tongGioNightDay_Cu = 0;
                        bc.tongGioNightDay_Moi = 0;
                        bc.tongGioNightDay_ChuNhat_Cu = 0;
                        bc.tongGioNightDay_ChuNhat_Moi = 0;
                        bc.tongGioNightDay_LT_Cu = 0;
                        bc.tongGioNightDay_LT_Moi = 0;
                        #endregion

                        #region Tính ra vào giữa ca
                        bc.tongOIS_Cu = 0;
                        bc.tongOIS_Moi = 0;
                        #endregion

                        strAction = "addNew";
                    }
                    foreach (var kq in _lKQ)
                    {
                        try
                        {
                            DateTime ngay = kq.ngay;

                            thongtin += empID + " " + ngay.ToShortDateString();

                            if (isLuongMoi(empID, ngay))
                            #region Tính công mới
                            {
                                #region Tính nghỉ phép
                                bc.tongNghiPhepNam_Moi += tinhCongTheoLoai(kq, 1);

                                bc.tongNghiCheDo_Moi += tinhCongTheoLoai(kq, 2);

                                bc.tongNghiCoLuong_Moi += tinhCongTheoLoai(kq, 3);

                                bc.tongNghiLT_Moi += tinhCongTheoLoai(kq, 8);

                                bc.tongNghiKhongLuong_Moi += tinhCongTheoLoai(kq, 20);

                                bc.tongNghiKhongPhep_Moi += tinhCongTheoLoai(kq, 21);

                                bc.tongNghiKhongPhepLThem += tinhCongTheoLoai(kq, 22);
                                #endregion

                                #region Tính công
                                bc.tongCong_Moi += tinhCongTheoLoai(kq, 4);
                                #endregion

                                #region Tính tăng ca
                                bc.tongTC_Moi += tinhCongTheoLoai(kq, 5);

                                bc.tongTCChuNhat_Moi += tinhCongTheoLoai(kq, 6);

                                bc.tongTCLeTet_Moi += tinhCongTheoLoai(kq, 7);
                                #endregion

                                #region Tính tăng ca không hệ số
                                bc.tongNormalOT_Moi += tinhCongTheoLoai(kq, 10);

                                bc.tongNormalOT_ChuNhat_Moi += tinhCongTheoLoai(kq, 11);

                                bc.tongNormalOT_LT_Moi += tinhCongTheoLoai(kq, 12);

                                bc.tongNightOT_Moi += tinhCongTheoLoai(kq, 13);

                                bc.tongNightOT_ChuNhat_Moi += tinhCongTheoLoai(kq, 14);

                                bc.tongNightOT_LT_Moi += tinhCongTheoLoai(kq, 15);
                                #endregion

                                #region Tính Ngày công làm thêm không nhân hệ số

                                bc.tongCongNormalDay_Moi += tinhCongTheoLoai(kq, 23); 
                                bc.tongCongNormalDay_ChuNhat_Moi += tinhCongTheoLoai(kq, 25); 
                                bc.tongCongNormalDay_LT_Moi += tinhCongTheoLoai(kq, 27); 

                                bc.tongCongNightDay_Moi += tinhCongTheoLoai(kq, 24); 
                                bc.tongCongNightDay_ChuNhat_Moi += tinhCongTheoLoai(kq, 26); 
                                bc.tongCongNightDay_LT_Moi += tinhCongTheoLoai(kq, 28);                                 

                                #endregion

                                #region Tính Giờ công làm thêm không nhân hệ số

                                bc.tongGioNormalDay_Moi += tinhCongTheoLoai(kq, 29);
                                bc.tongGioNormalDay_ChuNhat_Moi += tinhCongTheoLoai(kq, 31);
                                bc.tongGioNormalDay_LT_Moi += tinhCongTheoLoai(kq, 33);

                                bc.tongGioNightDay_Moi += tinhCongTheoLoai(kq, 30);
                                bc.tongGioNightDay_ChuNhat_Moi += tinhCongTheoLoai(kq, 32);
                                bc.tongGioNightDay_LT_Moi += tinhCongTheoLoai(kq, 34);

                                #endregion

                                #region Tính ra vào giữa ca
                                bc.tongOIS_Moi += tinhCongTheoLoai(kq, 35);
                                #endregion
                            }
                            #endregion
                            else
                            #region Tính công cũ
                            {
                                #region Tính nghỉ phép
                                bc.tongNghiPhepNam_Cu += tinhCongTheoLoai(kq, 1);

                                bc.tongNghiCheDo_Cu += tinhCongTheoLoai(kq, 2);

                                bc.tongNghiCoLuong_Cu += tinhCongTheoLoai(kq, 3);

                                bc.tongNghiLT_Cu += tinhCongTheoLoai(kq, 8);

                                bc.tongNghiKhongLuong_Cu += tinhCongTheoLoai(kq, 20);

                                bc.tongNghiKhongPhep_Cu += tinhCongTheoLoai(kq, 21);

                                bc.tongNghiKhongPhepLThem += tinhCongTheoLoai(kq, 22);
                                #endregion

                                #region Tính công
                                bc.tongCong_Cu += tinhCongTheoLoai(kq, 4);
                                #endregion

                                #region Tính tăng ca
                                bc.tongTC_Cu += tinhCongTheoLoai(kq, 5);

                                bc.tongTCChuNhat_Cu += tinhCongTheoLoai(kq, 6);

                                bc.tongTCLeTet_Cu += tinhCongTheoLoai(kq, 7);
                                #endregion

                                #region Tính tăng ca không hệ số
                                bc.tongNormalOT_Cu += tinhCongTheoLoai(kq, 10);

                                bc.tongNormalOT_ChuNhat_Cu += tinhCongTheoLoai(kq, 11);

                                bc.tongNormalOT_LT_Cu += tinhCongTheoLoai(kq, 12);

                                bc.tongNightOT_Cu += tinhCongTheoLoai(kq, 13);

                                bc.tongNightOT_ChuNhat_Cu += tinhCongTheoLoai(kq, 14);

                                bc.tongNightOT_LT_Cu += tinhCongTheoLoai(kq, 15);
                                #endregion

                                #region Tính Ngày công làm thêm không nhân hệ số

                                bc.tongCongNormalDay_Cu += tinhCongTheoLoai(kq, 23); 
                                bc.tongCongNormalDay_ChuNhat_Cu += tinhCongTheoLoai(kq, 25); 
                                bc.tongCongNormalDay_LT_Cu += tinhCongTheoLoai(kq, 27); 

                                bc.tongCongNightDay_Cu += tinhCongTheoLoai(kq, 24); 
                                bc.tongCongNightDay_ChuNhat_Cu += tinhCongTheoLoai(kq, 26); 
                                bc.tongCongNightDay_LT_Cu += tinhCongTheoLoai(kq, 28);    
                            

                                #endregion

                                #region Tính Giờ công làm thêm không nhân hệ số

                                bc.tongGioNormalDay_Cu += tinhCongTheoLoai(kq, 29);
                                bc.tongGioNormalDay_ChuNhat_Cu += tinhCongTheoLoai(kq, 31);
                                bc.tongGioNormalDay_LT_Cu += tinhCongTheoLoai(kq, 33);

                                bc.tongGioNightDay_Cu += tinhCongTheoLoai(kq, 30);
                                bc.tongGioNightDay_ChuNhat_Cu += tinhCongTheoLoai(kq, 32);
                                bc.tongGioNightDay_LT_Cu += tinhCongTheoLoai(kq, 34);

                                #endregion

                                #region Tính ra vào giữa ca
                                bc.tongOIS_Cu += tinhCongTheoLoai(kq, 35);
                                #endregion
                            }
                            #endregion

                            #region Tính tổng công cũ mới
                            bc.tongCong_CuMoi = bc.tongCong_Cu + bc.tongCong_Moi;
                            #endregion

                        }
                        catch (Exception ex)
                        {
                            bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Phân tích ngày {1:dd/MM/yyyy} nhân viên {1} bị lỗi: \n{2}", DateTime.Now, kq.ngay, kq.EmployeeID, ex.Message));
                        }

                        count++;

                        bgw_import.ReportProgress(3, count);
                    }

                    if (strAction == "addNew")
                    {
                        ds.tbBangCongThang.AddtbBangCongThangRow(bc);
                    }
                }

                bgw_import.ReportProgress(4, "Đang đẩy dữ liệu lên server");

                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Commit database: {1:n0} records", DateTime.Now, ds.tbBangCongThang.Rows.Count));

                Provider.UpdateData(ds, "tbBangCongThang");

                //bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Tính lại số tiếng đi trễ, về sớm, nghỉ", DateTime.Now));
                //foreach (DataRow rEmp in dtEmp.Rows)
                //{
                //    string empID = rEmp["EmployeeID"].ToString();
                //    //Số tiếng đi trễ, về sớm, nghỉ		
                //    Provider.ExecNoneQuery("p_tinhCong_SoTiengDiTreVeSomNghi", new SqlParameter("empID", empID), new SqlParameter("thangXuLy", thangXuLy));
                //}

                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Phân tích bảng công thành công", DateTime.Now));

                LogAction.LogAction.PushLog("Analyze"
                                            , ""
                                            , ""
                                            , string.Format("Phân tích bảng công tháng {0:dd/MM/yyyy}",thangXuLy)
                                            , "tbBangCongThang");

            }
            catch (Exception ex)
            {
                bgw_import.ReportProgress(2, string.Format("{0}: Phân tích bảng công bị lỗi: \n {1}", DateTime.Now, ex.Message));
            }
        }

        private void bgw_import_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                ucProgressRichtext1.start(1, Convert.ToInt32(e.UserState));

                btnDoImport.Enabled = false;
            }
            else if (e.ProgressPercentage == 2)
            {
                ucProgressRichtext1.Message = e.UserState.ToString();
            }
            else if (e.ProgressPercentage == 3)
            {
                ucProgressRichtext1.CurrentValue = Convert.ToInt32(e.UserState);
            }
            else if (e.ProgressPercentage == 4)
            {
                ucProgressRichtext1.Status = e.UserState.ToString();
            }
        }

        private void bgw_import_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDoImport.Enabled = true;

            ucProgressRichtext1.Status = "Phân tích dữ liệu thành công!";
        }


        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new System.Data.SqlClient.SqlParameter("CtrName", nameCrt),

                           new System.Data.SqlClient.SqlParameter("FormName", this.Name.ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                //có dữ liệu cho dùng chung
                if (ds.Tables[1].Rows.Count == 0)
                {
                    //không dùng riêng
                    return ds.Tables[0].Rows[0][lang].ToString().Trim();

                }
                else
                {
                    // có dùng riêng 
                    return ds.Tables[1].Rows[0][lang].ToString().Trim();
                }
            }
            else
            {
                return "";
            }

        }
    }
}
