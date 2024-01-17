using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Core.Controller;
using System.Data.Linq;
using System.Data;

namespace iHRM.Win.ExtClass.QuetThe_Fake
{
    public class XuLyDuLieu : LogicBase
    {
        public LogicProgress lp = new LogicProgress();
        public w5sysUser UserDoing;
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public XuLyDuLieu(w5sysUser uLogged)
        {
            UserDoing = uLogged;
        }

        public void doAnalyza(DateTime tuNgay, DateTime denNgay, List<string> _lEmpID, bool isXuLyDuLieuGoc, w5sysUser Userdoing, int soTiengOTCat)
        {
            string emp = "";

            dsXuLyQuetThe ds = new dsXuLyQuetThe();

            dsXuLyQuetThe ds_Old = new dsXuLyQuetThe();
            try
            {
                db = new dcDatabaseDataContext(Provider.ConnectionString);
                //reg progress...
                lp.SetTitle("Đang lấy dữ liệu..");
                lp.OutMessage("Lấy dữ liệu ----------------------------------------------------------------------------------");


                #region get data
                Provider.LoadData(ds, ds.tbCaLamViec.TableName);
                lp.OutMessage("Ca làm việc: " + ds.tbCaLamViec.Rows.Count);
                Provider.LoadData(ds, ds.tbNgayNghiPhepNam.TableName);
                lp.OutMessage("Ngày nghỉ phép năm: " + ds.tbNgayNghiPhepNam.Rows.Count);
                Provider.LoadDataByProc(ds, ds.tblEmpDayOff.TableName, "p_getAllDangKyVangMat", new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(denNgay)));
                lp.OutMessage("Đăng ký vắng mặt được duyệt chốt công: " + ds.tblEmpDayOff.Rows.Count);
                Provider.LoadDataByProc(ds, ds.tblEmp7hours.TableName, "p_GetAllEmp7hours", new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(denNgay)));
                lp.OutMessage("Danh sách làm 7 tiếng: " + ds.tblEmp7hours.Rows.Count);
                Provider.LoadDataByProc(ds, ds.tblRef_EmployeeType.TableName, "p_GetAlltblRef_EmployeeType");
                lp.OutMessage("Danh sách loại nhân viên: " + ds.tblRef_EmployeeType.Rows.Count);
                Provider.LoadDataByProc(ds, ds.tblEmpType.TableName, "p_GetAlltblEmpType", Provider.CreateParameter_StringList("dtEmpID", _lEmpID));
                lp.OutMessage("Dữ liệu thay đổi loại nhân viên: " + ds.tblEmpType.Rows.Count);

                Provider.LoadDataByProc(ds, ds.tbDangKyCaLam.TableName, "p_getDangKyCaLam_ByStrEmp_Fake", new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(denNgay)), Provider.CreateParameter_StringArray("dtEmpID", _lEmpID.ToArray()));
                lp.OutMessage("Đăng ký ca làm, làm thêm: " + ds.tbDangKyCaLam.Count);

                // Lấy tất cả kqqt có OT lớn hơn số tiếng cài đặt.
                Provider.LoadDataByProc(ds, ds.tbKetQuaQuetThe_Fake.TableName, "p_duLieuQuetThe_GetAllKetQuaQuetThe_Fake_TinhCong_ByStrEmp",
                    new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay)),
                    new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(denNgay)),
                    new SqlParameter("soTiengOTCat", soTiengOTCat),
                    Provider.CreateParameter_StringArray("dtEmpID", _lEmpID.ToArray()));

                lp.OutMessage(Lng.QuetThe_AnalyzeData.msg_kqqt + ds.tbKetQuaQuetThe_Fake.Count);

                Provider.LoadData(ds, ds.tblRef_LeaveType.TableName);
                lp.OutMessage("Danh sách các loại vắng mặt: " + ds.tblRef_LeaveType.Rows.Count);

                Provider.LoadDataByProc(ds, ds.tbDuLieuQuetThe.TableName, "p_duLieuQuetThe_GetAllDuLieuQuetThe_ByStrEmp", new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(denNgay.AddDays(1))), Provider.CreateParameter_StringArray("dtEmpID", _lEmpID.ToArray()));
                lp.OutMessage("Dữ liệu quẹt thẻ: " + ds.tbDuLieuQuetThe.Count);

                Provider.LoadDataByProc(ds, ds.tbRequestEditAttendane.TableName, "p_GetAlltbRequestEditAttendane_ByStrEmp", new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(denNgay.AddDays(1))), Provider.CreateParameter_StringArray("dtEmpID", _lEmpID.ToArray()));
                lp.OutMessage("Dữ liệu sửa công được duyệt chốt công: " + ds.tbRequestEditAttendane.Count);

                Provider.LoadDataByProc(ds, ds.tbRequestOverTime.TableName, "p_GetAlltbRequestOvertime_ByStrEmp", new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(denNgay.AddDays(1))), Provider.CreateParameter_StringArray("dtEmpID", _lEmpID.ToArray()));
                lp.OutMessage("Dữ liệu tăng ca quẹt thẻ: " + ds.tbRequestOverTime.Count);

                Provider.LoadDataByProc(ds, ds.tbRequestOutInShift.TableName, "p_GetAlltbRequestOutInShift_ByStrEmp", new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(denNgay.AddDays(1))), Provider.CreateParameter_StringArray("dtEmpID", _lEmpID.ToArray()));
                lp.OutMessage("Dữ liệu ra vào giữa ca: " + ds.tbRequestOutInShift.Count);

                #endregion
                string s = "";
                lp.MaxValue = _lEmpID.Count;
                lp.CurrentValue = 0;
                var dtEmployee = (from e1 in _lEmpID
                                  join e2 in db.tblEmployees on e1 equals e2.EmployeeID
                                  select new EmpQuetThe
                                  {
                                      EmployeeID = e2.EmployeeID,
                                      EmployeeName = e2.EmployeeName,
                                      CardID = e2.CardID,
                                      AppliedDate = e2.AppliedDate,
                                      idCaLamMacDinh = e2.idCaLamMacDinh,
                                      IsNotOT = e2.IsNotOT,
                                      LeftDate = e2.LeftDate
                                  }).ToList();
                var dtEmp7hours = db.tblEmp7hours.Where(p => p.BeginDate <= tuNgay).ToList();
                foreach (string item in dtEmployee.Select(p => p.EmployeeID))
                {
                    emp = item;
                    s = CheckQT(item, dtEmployee, dtEmp7hours, ds, ds_Old, tuNgay, denNgay, Userdoing, soTiengOTCat);
                    if (s != "")
                        lp.OutMessage("\n>> " + s);
                    lp.CurrentValue += 1;
                }
                if (ds.tbKetQuaQuetThe_Fake.GetChanges() == null)
                {
                    lp.OutMessage("\n>> " + Lng.QuetThe_AnalyzeData.msg_1);
                }
                else
                {
                    var rowEffected = Provider.ExecNoneQuery("p_DeleteDataPrepareForCommitKQQT_Fake"
                                            , Provider.CreateParameter_StringList("dtEmpID", _lEmpID)
                                            , new SqlParameter("tuNgay", tuNgay)
                                            , new SqlParameter("denNgay", denNgay),
                                            new SqlParameter("soTiengOTCat", soTiengOTCat));
                    lp.OutMessage(string.Format("\n>> Refresh data kết quả quẹt thẻ ({0:n0})", rowEffected));

                    var rowEffected_Auto = Provider.ExecNoneQuery("p_DeleteDataPrepareForCommitKQQT_Fake_Auto"
                                           , Provider.CreateParameter_StringList("dtEmpID", _lEmpID)
                                           , new SqlParameter("tuNgay", tuNgay)
                                           , new SqlParameter("denNgay", denNgay),
                                           new SqlParameter("soTiengOTCat", soTiengOTCat));
                    lp.OutMessage(string.Format("\n>> Refresh data kết quả quẹt thẻ Auto ({0:n0})", rowEffected_Auto));

                    SqlParameter pa = new SqlParameter("dt_tbKetQuaQuetThe_Fake", SqlDbType.Structured);
                    pa.TypeName = "dt_tbKetQuaQuetThe_Fake";
                    pa.Value = ds.tbKetQuaQuetThe_Fake;
                    Provider.ExecuteNonQuery("p_updatetbKetQuaQuetThe_Fake", pa);

                    lp.OutMessage("\n>> " + Lng.QuetThe_AnalyzeData.msg_2 + ds.tbKetQuaQuetThe_Fake.Rows.Count + ") " + Lng.QuetThe_AnalyzeData.msg_3);
                }
                lp.OutMessage("\nXử lý hoàn thành!");
            }
            catch (Exception ex)
            {
                lp.OutMessage(ex.Message + emp);
            }
        }

        public string CheckQT(string empID, List<EmpQuetThe> dtEmployee, List<tblEmp7hour> dtEmp7hours, dsXuLyQuetThe ds, dsXuLyQuetThe ds_Old, DateTime tuNgay, DateTime denNgay, w5sysUser Userdoing, int soTiengOTCat)
        {
            int _checkQT = 0; //Không có dữ liệu trong kết quả quẹt thẻ.

            var e = dtEmployee.Where(p => p.EmployeeID == empID).FirstOrDefault();
            if (e == null)
            {
                return "Mã nhân viên " + empID + " không đúng!";
            }
            if (e.AppliedDate != null && e.AppliedDate.Value > tuNgay)
            {
                tuNgay = e.AppliedDate.Value;
            }
            if (e.LeftDate != null && e.LeftDate.Value <= denNgay)
            {
                denNgay = e.LeftDate.Value.AddDays(-1);
            }
            bool isNotOT = e.IsNotOT;
            var duLieuQuet = ds.tbDuLieuQuetThe.Where(p => p.maNV == empID);
            for (DateTime iNg = tuNgay.AddDays(-1); iNg < denNgay; )
            {
                iNg = iNg.AddDays(1);
                dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq;

                var kqRegisted = ds.tbKetQuaQuetThe_Fake.Where(p => p.ngay == iNg && p.EmployeeID == empID).FirstOrDefault();

                bool laLeTet = false;

                bool isKhongCanQuetThe = false;

                bool isCaDemTrongNgay = false;

                laLeTet = (ds.tbNgayNghiPhepNam.FirstOrDefault(i =>
                                                    i.ngay == iNg.Day && i.thang == iNg.Month &&
                                                    (i["nam"] == DBNull.Value || i.nam == 0 || i.nam == iNg.Year)) != null);
                var dkCaLam = ds.tbDangKyCaLam.Where(p => p.ngay == iNg && p.EmployeeID == empID).FirstOrDefault();

                if (kqRegisted != null) // Neu da dang ky ca lam
                {
                    kq = kqRegisted;

                    _checkQT = 1;

                    setDefaultValueColumn_F1(kq);

                    if (!kqRegisted.IsdkLamThemNull())
                    {
                        kq.dkLamThem = kqRegisted.dkLamThem;
                    }
                }
                else
                {
                    _checkQT = 0;

                    kq = ds.tbKetQuaQuetThe_Fake.NewtbKetQuaQuetThe_FakeRow();

                    if (dkCaLam == null) // Nếu không đăng ký ca làm.-> Phần mềm tự động đăng ký 
                    {
                        if (e.idCaLamMacDinh == null && !laLeTet)
                        {
                            continue;
                        }
                        if (iNg.DayOfWeek == DayOfWeek.Sunday && !laLeTet) // Không tự tạo ca làm vào ngày chủ nhật
                        {
                            continue;
                        }
                        if (e.idCaLamMacDinh != null)
                        {
                            kq.idCaLam = e.idCaLamMacDinh.Value; /// set ca lam mac dinh o day
                        }
                        if (laLeTet)
                        {
                            kq.idCaLam = Guid.Parse("5C90A2D2-17CF-4AA5-A303-5B5A68AF1CF6");
                            kq.dkLamThem = 3;
                            kq.isAutomatic = true;
                        }
                    }

                    kq.id = Guid.NewGuid();

                    kq.EmployeeID = e.EmployeeID;

                    kq.ngay = iNg;

                    setDefaultValueColumn(kq); // Phải set vì có 1 số cột không được null nên sẽ không thể add row vào bảng được.

                    ds.tbKetQuaQuetThe_Fake.AddtbKetQuaQuetThe_FakeRow(kq);
                }

                    if (laLeTet && (kq.IsdkLamThemNull()))
                    {
                        kq.dkLamThem = 3;

                        kq.isAutomatic = true;
                    }

                    if (laLeTet)
                    {
                        kq.tt_leTet = true;
                    }

                    if (!kq.IsisAutomaticNull() && kq.isAutomatic && kq.tt_leTet == true) // A Trọng sửa kq.dkLamThem == 3 thành kq.tt_leTet == true 28/02/2018
                    {
                        // Nếu tự động đăng ký là lễ tết thì k cho set giờ vào giờ ra để k tính tăng ca.
                    }
                    else
                    {
                        var calam = ds.tbCaLamViec.SingleOrDefault(i => i.id == kq.idCaLam);
                        if (!calam.IsisKhongCanQuetTheNull() && calam.isKhongCanQuetThe)
                        {
                            isKhongCanQuetThe = true;
                        }
                        if (isKhongCanQuetThe && kq.IsdkLamThemNull())
                        {
                            kq.tgQuetDen = calam.tuGio;
                            if (!calam.IsT7LamSangNull() && calam.T7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday)
                            {
                                kq.tgQuetVe = calam.caSang_denGio;
                            }
                            else
                            {
                                if (calam.tuGio.Add(calam.denGio).Days >= 1)
                                {
                                    kq.tgQuetVe = calam.tuGio.Add(calam.denGio).Add(new TimeSpan(-1, 0, 0, 0));
                                }
                                else
                                {
                                    kq.tgQuetVe = calam.tuGio.Add(calam.denGio);
                                }
                            }
                        }
                        else
                        {
                            var kqRequest = ds.tbRequestEditAttendane.Where(p => p.EmployeeID == kq.EmployeeID && p.ngay == kq.ngay && p.isAccept).FirstOrDefault();

                            if (kqRequest != null && !kqRequest.IsisCaDemTrongNgayNull())
                            {
                                isCaDemTrongNgay = kqRequest.isCaDemTrongNgay;
                            }

                            #region check vào
                            DateTime tgQuetVao = kq.ngay.Add(calam.tuGio);
                            DateTime tgQuetTruoc_Vao = tgQuetVao.AddMinutes(-1 * calam.tgQuetTruoc_Vao);
                            DateTime tgQuetSau_Vao = tgQuetVao.AddMinutes(calam.tgQuetSau_Vao);

                            if (!kq.IsisDkTuGioDenGioNull() && kq.isDkTuGioDenGio) //Đáp ứng cho các ca làm đăng ký từ giờ đến giờ. Trước và sau 240ph. A trọng yêu cầu 29/11/2017
                            {
                                tgQuetVao = kq.ngay.Add(kq.CaSang_TuGio);
                                tgQuetTruoc_Vao = tgQuetVao.AddMinutes(-1 * 240);
                                tgQuetSau_Vao = tgQuetVao.AddMinutes(240);
                            }

                            var dr = ds.tbDuLieuQuetThe.Where(i => i.thoigian >= tgQuetTruoc_Vao && i.thoigian <= tgQuetSau_Vao && i.maNV == kq.EmployeeID)
                            .OrderBy(i => i.thoigian)
                            .FirstOrDefault();

                              if(_checkQT == 0)
                              {
                                  if (dr == null) //ko co quyet tay luc den trong khoang tg cho phep
                                  {
                                      kq["tgQuetDen_old"] = DBNull.Value;
                                  }
                                  else
                                  {
                                      kq.tgQuetDen_old = dr.thoigian.TimeOfDay;
                                  }
                                  if (kqRequest != null)
                                  {
                                      kq["tgQuetDen"] = kqRequest.gioVao_Request;
                                  }
                                  else
                                  {
                                      if (kq.IsmodifyDateNull() || kq.IsmodifyByNull() || kq.IstgQuetDenNull())// Nếu k phải sửa bằng tay trên form bảng công thì mới lấy dữ liệu quẹt thẻ
                                          kq["tgQuetDen"] = kq["tgQuetDen_old"];
                                  }
                              }


                            
                            #endregion

                            #region Check ra
                            DateTime tgQuetRa = kq.ngay.Add(calam.tuGio).Add(calam.denGio);
                            DateTime tgQuetTruoc_Ra = tgQuetRa.AddMinutes(-1 * calam.tgQuetTruoc_Ra);
                            DateTime tgQuetSau_Ra = tgQuetRa.AddMinutes(calam.tgQuetSau_Ra);

                            if (!kq.IsisDkTuGioDenGioNull() && kq.isDkTuGioDenGio) //Đáp ứng cho các ca làm đăng ký từ giờ đến giờ. Trước và sau 240ph. A trọng yêu cầu 29/11/2017
                            {
                                tgQuetRa = kq.ngay.Add(kq.CaChieu_DenGio);
                                tgQuetTruoc_Ra = tgQuetRa.AddMinutes(-1 * 240);
                                tgQuetSau_Ra = tgQuetRa.AddMinutes(420);
                            }

                            bool isT7LamSang = calam.IsT7LamSangNull() ? false : calam.T7LamSang;
                            //if (isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday) //Set lại thời gian nhận vân tay Jun 2019/01/10 11:29 AM
                            //{
                            //    tgQuetTruoc_Ra = kq.ngay.Add(calam.caSang_denGio).AddMinutes(-1 * calam.tgQuetTruoc_Ra);
                            //    tgQuetSau_Ra = kq.ngay.Add(calam.caSang_denGio).AddMinutes(calam.tgQuetSau_Ra);
                            //}
                            var dr2 = ds.tbDuLieuQuetThe
                                   .Where(i => i.thoigian >= tgQuetTruoc_Ra && i.thoigian <= tgQuetSau_Ra && i.maNV == kq.EmployeeID)
                                   .OrderByDescending(i => i.thoigian)
                                   .FirstOrDefault();
                            if (!calam.caDem) // Chỉ lấy vân tay trong ngày nếu không phải là ca đêm
                            {
                                var tGianCuoiNgay = new DateTime(kq.ngay.Year, kq.ngay.Month, kq.ngay.Day, 23, 59, 59);
                                dr2 = ds.tbDuLieuQuetThe
                                   .Where(i => i.thoigian >= tgQuetTruoc_Ra && i.thoigian <= tGianCuoiNgay && i.maNV == kq.EmployeeID)
                                   .OrderByDescending(i => i.thoigian)
                                   .FirstOrDefault();
                            }

                            if (_checkQT == 0)
                            {
                                if (dr2 == null) //ko co quet tay luc ve trong khoang tg cho phep
                                {
                                    kq["tgQuetVe_old"] = DBNull.Value;
                                }
                                else
                                {
                                    kq.tgQuetVe_old = dr2.thoigian.TimeOfDay;

                                    if (dr != null && dr2.thoigian.Day == dr.thoigian.Day && calam.caDem)
                                    {
                                        isCaDemTrongNgay = true;
                                    }
                                }
                                if (kqRequest != null)
                                {
                                    kq["tgQuetVe"] = kqRequest.gioRa_Request;
                                }
                                else
                                {
                                    if (kq.IsmodifyDateNull() || kq.IsmodifyByNull() || kq.IstgQuetVeNull())
                                    {
                                        if (!kq.IstgQuetVe_oldNull() && !kq.IstgQuetDenNull() && kq.tgQuetVe_old == kq.tgQuetDen) // Nếu thời gian về = tg đến. Nếu tgQuẹt > giờ về ca sáng => In else Out.
                                        {
                                            if (kq.tgQuetDen > calam.caSang_denGio)// Cho tg Đến = null => Báo In
                                            {
                                                kq["tgQuetDen"] = DBNull.Value;
                                            }
                                            else //Cho tg Về = null => Báo out
                                                kq["tgQuetVe_old"] = DBNull.Value;
                                        }
                                        kq["tgQuetVe"] = kq["tgQuetVe_old"];
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                
                try
                {
                    double soTiengTCTN = 0;
                    //lấy số tiếng tăng ca theo ca làm việc
                    var ca = ds.tbCaLamViec.SingleOrDefault(i => i.id == kq.idCaLam);
                    if (ca != null && ca.soTiengTangCaTrachNhiem != null && ca.soTiengTangCaTrachNhiem != 0)
                    {
                        soTiengTCTN = ca.soTiengTangCaTrachNhiem;

                    }
                    // Lấy số tiếng tăng ca trách nhiệm theo loại nhân viên.
                    //var a = (from et in ds.tblEmpType.Where(p => p.EmployeeID == empID && p.DateChange <= kq.ngay)
                    //         join ret in ds.tblRef_EmployeeType on et.EmpTypeID equals ret.EmpTypeID
                    //         select ret).FirstOrDefault();                    

                    //if (a != null && !a.IssoTiengTCTNNull())
                    //{
                    //    //soTiengTCTN = a.soTiengTCTN;

                    //}

                    kq = QuetThe.AnalyzeDataQuetThe(ds, kq, isNotOT, tuNgay, false, db, isCaDemTrongNgay, _checkQT, soTiengTCTN, soTiengOTCat);
                    kq.analyzeBy = Userdoing.id;
                }
                catch (Exception ex)
                {
                    return string.Format("Emp [{0}] Date {1:dd/MM/yyyy} Analyze fail: {2}", kq.EmployeeID, kq.ngay, ex.Message);
                }
            }
            return "";
        }

        public void setDefaultValueColumn(dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq)
        {
            kq["tgQuetDen"] = DBNull.Value;
            kq["tgQuetVe"] = DBNull.Value;
            kq.daysOfNghiCoLuong = 0;
            kq["dkLamThem"] = DBNull.Value;
            kq["idFileDkLamThem"] = DBNull.Value;

            kq.tt_error = 0;
            kq.tgTinhTangCa = 0;
            kq.tt_chuNhat = false;
            kq.soGioCongTC = 0;
            kq.OTMore4h = 0;
            kq.OTMore8h = 0;
            kq.NightOTLess24 = 0;
            kq.kqNgayCong = 1;
            kq.status = 1;
            kq.PerTimeID = 0;
            kq.LeaveID = null;
            kq.WorkingHours = kq.NightDay = kq.NightOT = kq.NormalDay = kq.NormalOT = 0;
            kq.NightOISDay = kq.NormalOISDay = 0;
            kq.NightOTBeforeShift = kq.NightOTInShift = kq.NormalOTBeforeShift = kq.NormalOTInShift = 0;
            kq.tt_coQuetTay = kq.tt_nghiPhep = kq.tt_diMuonVeSom = kq.tt_ok = 0;
            kq.tt_leTet = false;
            kq.tgTinhTangCa = 0;
            kq.tt_nghiPhep_Alias = "";
            kq.tgTinhTangCa = 0;
            kq.tgVeSom = kq.tgDiMuon = 0;
            kq["idCongTacDaiHan"] = DBNull.Value;
            kq["isTangCaQua24h"] = DBNull.Value;

            kq.isPhepTreSom = false;
        }

        public void setDefaultValueColumn_F1(dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq)
        {
            //kq["tgQuetDen"] = DBNull.Value;
            //kq["tgQuetVe"] = DBNull.Value;
            kq.daysOfNghiCoLuong = 0;
            kq["dkLamThem"] = DBNull.Value;
            kq["idFileDkLamThem"] = DBNull.Value;

            kq.tt_error = 0;
            //kq.tgTinhTangCa = 0;
            kq.tt_chuNhat = false;
            kq.soGioCongTC = 0;
            kq.OTMore4h = 0;
            kq.OTMore8h = 0;
            kq.NightOTLess24 = 0;
            kq.kqNgayCong = 1;
            kq.status = 1;
            kq.PerTimeID = 0;
            kq.LeaveID = null;
            kq.WorkingHours = kq.NightDay = kq.NightOT = kq.NormalDay = kq.NormalOT = 0;
            //kq.NightOTBeforeShift = kq.NightOTInShift = kq.NormalOTBeforeShift = kq.NormalOTInShift = 0;
            kq.tt_coQuetTay = kq.tt_nghiPhep = kq.tt_diMuonVeSom = kq.tt_ok = 0;
            kq.tt_leTet = false;
            kq.tt_nghiPhep_Alias = "";
            kq.tgVeSom = kq.tgDiMuon = 0;
            //kq["idCongTacDaiHan"] = DBNull.Value;
            //kq["isTangCaQua24h"] = DBNull.Value;
        }
    }

    public static class QuetThe
    {
        public static dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow AnalyzeDataQuetThe(dsXuLyQuetThe ds, dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, bool isNotOT, DateTime tuNgay, bool isKhongCanQuetThe, dcDatabaseDataContext db, bool isCaDemTrongNgay, int checkQT, double soTiengTCTN = 0, int soTiengOTCat = 0)
        {
            String _codeEmp = kq.EmployeeID.Substring(0, 4);

            var calam = ds.tbCaLamViec.SingleOrDefault(i => i.id == kq.idCaLam);

            var calamAudit = calam;

            int _checkCatQuetDen = 0; //Chưa cắt OT

            int _checkCatQuetVe = 0;

            int _checkCatOT = 0;

            int _checkCatCaDem = 0;

            bool isT7LamSang = calam.IsT7LamSangNull() ? false : calam.T7LamSang;
            if (!kq.IsisDkTuGioDenGioNull() && kq.isDkTuGioDenGio)
            {
                calam.caDem = kq.isCaDem;
                calam.caSang_tuGio = kq.CaSang_TuGio;
                calam.caSang_denGio = kq.CaSang_DenGio;
                calam.caChieu_tuGio = kq.CaChieu_TuGio;
                calam.caChieu_denGio = kq.CaChieu_DenGio;
                calam.tuGio = kq.CaSang_TuGio;

                if (calam.caDem)
                {
                    calam.isTruTangCa = true;
                    calam.soTiengTangCa = 4;
                    calam.soTiengTruTangCa = 1;
                }
                else
                {
                    calam.isTruTangCa = true;
                    calam.soTiengTangCa = 3;
                    calam.soTiengTruTangCa = 0.5;
                }
            }
            else
            {
                kq.SoTiengTinhCa = calam.soTiengTinhCa;
            }
            double tongphutT7 = 0; //phước add 29/03/2019
            TimeSpan calam_tuGio_4check = calam.caSang_tuGio, calam_denGio_4check = calam.caChieu_denGio;
            double soTiengTinhCa_4Calc = kq.SoTiengTinhCa;
            if (isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday)
            {
                //phước fix ca làm t7 tới 15h00
                calam_denGio_4check = calam.caSang_denGio;
                tongphutT7 = (calam.caSang_denGio - calam.caSang_tuGio).TotalMinutes;
            }
            kq.is7Hours = false;
            var emp7Hours = ds.tblEmp7hours.Where(p => p.EmployeeID == kq.EmployeeID && p.BeginDate <= kq.ngay && p.EndDate >= kq.ngay).OrderByDescending(p => p.BeginDate).FirstOrDefault();
            if (emp7Hours != null)
            {
                if (emp7Hours.isLate)
                {
                    calam_tuGio_4check = calam_tuGio_4check.Add(new TimeSpan(1, 0, 0));
                }
                else
                {
                    calam_denGio_4check = calam_denGio_4check.Add(new TimeSpan(-1, 0, 0));
                }
                soTiengTinhCa_4Calc = soTiengTinhCa_4Calc - 1;
                kq.is7Hours = true;
            }

            #region Set thời gian quẹt thẻ

            if (checkQT == 1)
            {
                double tgTangCa = 0;
                double tgTangCa1 = 0;
                double clCalam = (calam.soTiengTinhCa - 8);

                #region Set lại tgTinhTangCa
                double tgTangCaSauCa = 0;

                tgTangCaSauCa = kq.tgTinhTangCa - (kq.NightOTBeforeShift + kq.NormalOTBeforeShift + kq.NightOTInShift + kq.NormalOTInShift);

                if (kq.tgTinhTangCa > tgTangCaSauCa && tgTangCaSauCa > 0)
                {
                    kq.tgTinhTangCa = tgTangCaSauCa;
                    kq.NightOTBeforeShift = kq.NormalOTBeforeShift = kq.NightOTInShift = kq.NormalOTInShift = 0;
                }

                if (emp7Hours != null)
                {
                    kq.tgTinhTangCa = 0;
                    kq.NightOTBeforeShift = kq.NormalOTBeforeShift = kq.NightOTInShift = kq.NormalOTInShift = 0;
                }
                #endregion

                #region Set lại cadem

                if (calamAudit.isCaLamAudit)
                   {
                       kq.idCaLam = calam.idCaLamAudit;
                       //Chạy lại ca làm Audit
                       calam = ds.tbCaLamViec.SingleOrDefault(i => i.id == kq.idCaLam);
                        isT7LamSang = calam.IsT7LamSangNull() ? false : calam.T7LamSang;
                       if (!kq.IsisDkTuGioDenGioNull() && kq.isDkTuGioDenGio)
                       {
                           calam.caDem = kq.isCaDem;
                           calam.caSang_tuGio = kq.CaSang_TuGio;
                           calam.caSang_denGio = kq.CaSang_DenGio;
                           calam.caChieu_tuGio = kq.CaChieu_TuGio;
                           calam.caChieu_denGio = kq.CaChieu_DenGio;
                           calam.tuGio = kq.CaSang_TuGio;

                           if (calam.caDem)
                           {
                               calam.isTruTangCa = true;
                               calam.soTiengTangCa = 4;
                               calam.soTiengTruTangCa = 1;
                           }
                           else
                           {
                               calam.isTruTangCa = true;
                               calam.soTiengTangCa = 3;
                               calam.soTiengTruTangCa = 0.5;
                           }
                       }
                       else
                       {
                           kq.SoTiengTinhCa = calam.soTiengTinhCa;
                       }
                        tongphutT7 = 0;
                        calam_tuGio_4check = calam.caSang_tuGio;
                        calam_denGio_4check = calam.caChieu_denGio;
                        soTiengTinhCa_4Calc = kq.SoTiengTinhCa;
                       if (isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday)
                       {
                           calam_denGio_4check = calam.caSang_denGio;
                           tongphutT7 = (calam.caSang_denGio - calam.caSang_tuGio).TotalMinutes;
                       }
                       kq.is7Hours = false;
                        emp7Hours = ds.tblEmp7hours.Where(p => p.EmployeeID == kq.EmployeeID && p.BeginDate <= kq.ngay && p.EndDate >= kq.ngay).OrderByDescending(p => p.BeginDate).FirstOrDefault();
                       if (emp7Hours != null)
                       {
                           if (emp7Hours.isLate)
                           {
                               calam_tuGio_4check = calam_tuGio_4check.Add(new TimeSpan(1, 0, 0));
                           }
                           else
                           {
                               calam_denGio_4check = calam_denGio_4check.Add(new TimeSpan(-1, 0, 0));
                           }
                           soTiengTinhCa_4Calc = soTiengTinhCa_4Calc - 1;
                           kq.is7Hours = true;
                       }

                       if(kq.kqNgayCong >= 1)
                       {
                           kq.tgQuetDen = new TimeSpan(calam_tuGio_4check.Hours, calam_tuGio_4check.Add(new TimeSpan(0, (-1)*(new Random()).Next(0, 14), 0)).Minutes, (new Random()).Next(1, 59));
                           kq.tgQuetVe = new TimeSpan(calam_denGio_4check.Hours, calam_denGio_4check.Add(new TimeSpan(0, (new Random()).Next(0, 14), 0)).Minutes, (new Random()).Next(1, 59));
                       }
                       else if (kq.kqNgayCong > 0 && kq.kqNgayCong < 1 )
                       {
                           double tglamviec = 0;
                           tglamviec = kq.SoTiengTinhCa - kq.WorkingHours;
                           kq.tgQuetDen = new TimeSpan(calam_tuGio_4check.Hours, calam_tuGio_4check.Add(new TimeSpan(0, (-1) * (new Random()).Next(0, 14), 0)).Minutes, (new Random()).Next(1, 59));
                           kq.tgQuetVe = new TimeSpan(calam_denGio_4check.Hours, calam_denGio_4check.Add(new TimeSpan(0, (new Random()).Next(0, 14), 0)).Minutes, (new Random()).Next(1, 59));
                           kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan(0, (int)(tglamviec * 60) * (-1), 0));
                       }

                       if (calamAudit.caLamAuditKhongTangCa)
                       {
                           _checkCatCaDem = 1;
                           kq.tgTinhTangCa = 0;
                           kq.NormalOT = kq.NightOT = kq.NightOTBeforeShift = kq.NightOTInShift = kq.NormalOTBeforeShift = kq.NormalOTInShift = 0;
                       }

                       kq.tgQuetDen_old = kq.tgQuetDen;
                       kq.tgQuetVe_old = kq.tgQuetVe;

                   }
                
                #endregion

                if ((kq.SoTiengTinhCa + kq.tgTinhTangCa) > (8 + soTiengOTCat))
                {
                    tgTangCa1 = (kq.SoTiengTinhCa + kq.tgTinhTangCa) - (8 + soTiengOTCat);
                    tgTangCa = (kq.SoTiengTinhCa + kq.tgTinhTangCa) - (8 + tgTangCa1);

                }
                if (soTiengOTCat == 0)
                {
                    tgTangCa = tgTangCa1;
                }

                if (tgTangCa > 0)
                {
                    _checkCatOT = 1;

                    if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // nếu là dk làm thêm thì không quá 12h/ngay
                    {
                        if (kq.SoTiengTinhCa > 12)
                        {
                            if ((new Random()).Next(1, 5) % 2 == 0) // làm lẻ tg quét vân tay vào
                            {
                                if (calam_tuGio_4check.Hours - 1 > 0) // tránh th là dk làm thêm 0h or 1h sáng
                                {
                                    kq.tgQuetDen = new TimeSpan(calam_tuGio_4check.Hours - 1, calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(0, 59), 0)).Minutes, (new Random()).Next(1, 59));
                                    kq.tgQuetVe = new TimeSpan(calam_tuGio_4check.Add(new TimeSpan(12, 0, 0)).Hours, calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(0, 60));
                                    _checkCatQuetDen = 1; //Đã cắt OT
                                    _checkCatQuetVe = 1;
                                }
                                else
                                {
                                    kq.tgQuetDen = new TimeSpan(calam_tuGio_4check.Hours, calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(1, 59));
                                    kq.tgQuetVe = new TimeSpan(calam_tuGio_4check.Add(new TimeSpan(12, 0, 0)).Hours, calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(0, 60));
                                    _checkCatQuetDen = 1; //Đã cắt OT
                                    _checkCatQuetVe = 1;
                                }

                            }
                            else
                            {
                                kq.tgQuetDen = new TimeSpan(calam_tuGio_4check.Hours, calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(1, 59));
                                kq.tgQuetVe = new TimeSpan(calam_tuGio_4check.Add(new TimeSpan(12, 0, 0)).Hours, calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(0, 60));
                                _checkCatQuetDen = 1; //Đã cắt OT
                                _checkCatQuetVe = 1;
                            }
                        }
                        else
                        {
                            if ((new Random()).Next(1, 5) % 2 == 0) // làm lẻ tg quét vân tay vào
                            {
                                if (calam_tuGio_4check.Hours - 1 > 0) // tránh th là dk làm thêm 0h or 1h sáng
                                {
                                    kq.tgQuetDen = new TimeSpan(calam_tuGio_4check.Hours - 1, calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(0, 59), 0)).Minutes, (new Random()).Next(1, 59));
                                    kq.tgQuetVe = new TimeSpan(calam_denGio_4check.Hours, calam_denGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(0, 60));
                                    _checkCatQuetDen = 1; //Đã cắt OT
                                    _checkCatQuetVe = 1;
                                }
                                else
                                {
                                    kq.tgQuetDen = new TimeSpan(calam_tuGio_4check.Hours, calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(1, 59));
                                    kq.tgQuetVe = new TimeSpan(calam_denGio_4check.Hours, calam_denGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(0, 60));
                                    _checkCatQuetDen = 1; //Đã cắt OT
                                    _checkCatQuetVe = 1;
                                }

                            }
                            else
                            {
                                kq.tgQuetDen = new TimeSpan(calam_tuGio_4check.Hours, calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(1, 59));
                                kq.tgQuetVe = new TimeSpan(calam_denGio_4check.Hours, calam_denGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), 0)).Minutes, (new Random()).Next(0, 60));
                                _checkCatQuetDen = 1; //Đã cắt OT
                                _checkCatQuetVe = 1;
                            }

                        }
                    }
                    else
                    {
                        // không cần làm lẻ vì lấy giờ vào thực tế để tính
                        if (calam.caDem)
                        {
                            if (!kq.IstgQuetDenNull())
                            {

                                TimeSpan _tgQuetDen = new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0);

                                TimeSpan _mTgQuetDen = calam_tuGio_4check - _tgQuetDen;

                                if (_mTgQuetDen.TotalMinutes > 0 && _mTgQuetDen.TotalMinutes < 15)
                                {
                                    if ((new Random()).Next(1, 5) != 1) // làm lẻ tg quét vân tay vào
                                    {
                                        kq.tgQuetDen = calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(-14, 0), (new Random()).Next(0, 60)));
                                    }
                                    else
                                    {
                                        kq.tgQuetDen = calam_tuGio_4check;
                                    }
                                    _checkCatQuetDen = 1; //Đã cắt OT
                                }
                                else if (_mTgQuetDen.TotalMinutes >= 15)
                                {
                                    kq.tgQuetDen = new TimeSpan(calam_tuGio_4check.Hours, calam_tuGio_4check.Add(new TimeSpan(0, -(new Random()).Next(0, 15), 0)).Minutes, (new Random()).Next(0, 60));
                                    _checkCatQuetDen = 1; //Đã cắt OT
                                }
                                else
                                {
                                    kq.tgQuetDen = new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, kq.tgQuetDen.Seconds);
                                }
                            }
                            if (!kq.IstgQuetVeNull())
                            {
                                kq.tgQuetVe = new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, kq.tgQuetVe.Seconds);
                                _checkCatQuetVe = 1;
                            }
                        }
                        else
                        {
                            if (!kq.IstgQuetDenNull())
                            {
                                kq.tgQuetDen = new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, kq.tgQuetDen.Seconds);
                            }
                            if (!kq.IstgQuetVeNull())
                            {
                                kq.tgQuetVe = new TimeSpan(calam_denGio_4check.Hours, calam_denGio_4check.Add(new TimeSpan(0, (new Random()).Next(0, 15), 0)).Minutes, (new Random()).Next(0, 60));
                                _checkCatQuetVe = 1;
                            }
                        }
                    }

                    if (tgTangCa > 0 && !kq.IstgQuetVeNull() && calam.kqNgayCong == 1)
                    {
                        var sole = tgTangCa - (int)tgTangCa;
                        if (kq.SoTiengTinhCa > ((8 + soTiengOTCat))) // Trường hợp ca làm đã có số giờ quá số tiếng cần cắt
                        {
                            var soTiengCanTru = (int)(kq.SoTiengTinhCa - ((8 + soTiengOTCat)));
                            var sole_soTiengCanTru = kq.SoTiengTinhCa - (8 + soTiengOTCat) - soTiengCanTru;

                            if (soTiengCanTru >= soTiengOTCat)
                            {
                                soTiengCanTru = soTiengOTCat;
                                sole_soTiengCanTru = 0;
                            }

                            if (soTiengCanTru == 0 && sole_soTiengCanTru > 0) // Jun add cho Th 1.76 giảm còn 0 lẻ 0.76 làm tròn lên 1 2019/08/21 02:17 PM
                            {
                                soTiengCanTru = 1;
                                sole_soTiengCanTru = 0;
                            }

                            kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan(0, (int)(sole_soTiengCanTru * 60) * (-1), 0));
                            kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan((int)soTiengCanTru * (-1), 0, 0));
                            _checkCatQuetVe = 1;
                        }
                        else
                        {
                            var soTiengCanTru = (int)((kq.SoTiengTinhCa + kq.tgTinhTangCa) - (8 + soTiengOTCat));
                            var sole_soTiengCanTru = (kq.SoTiengTinhCa + kq.tgTinhTangCa) - (8 + soTiengOTCat) - soTiengCanTru;
                            var soTiengCanTru_Le = (kq.SoTiengTinhCa * 60 + kq.tgTinhTangCa * 60) - (8 * 60 + soTiengOTCat * 60);

                            //TimeSpan _22h = new TimeSpan(22, 0, 0);

                            //if (soTiengCanTru >= soTiengOTCat)
                            //{
                            //    soTiengCanTru = soTiengOTCat;
                            //    sole_soTiengCanTru = 0;
                            //}


                            //if (soTiengCanTru == 0 && sole_soTiengCanTru > 0) // Jun add cho Th 1.76 giảm còn 0 lẻ 0.76 làm tròn lên 1 2019/08/21 02:17 PM
                            //{
                            //    soTiengCanTru = 1;
                            //    sole_soTiengCanTru = 0;
                            //}

                            //kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan(0, (int)(sole_soTiengCanTru * 60), 0));
                            //kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan((int)soTiengCanTru, 0, 0));
                            //_checkCatQuetVe = 1;


                            if (((kq.tgTinhTangCa * 60) - (soTiengCanTru_Le)) > (soTiengOTCat * 60))
                            {
                                soTiengCanTru_Le = (kq.tgTinhTangCa * 60) - (soTiengOTCat * 60);
                            }
                            if ((soTiengOTCat * 60) == 0)
                            {
                                soTiengCanTru_Le = (kq.tgTinhTangCa * 60);
                            }
                            if (!calam.caDem)
                            {
                                kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan(0, (int)((kq.tgTinhTangCa * 60) - (soTiengCanTru_Le)), 0));
                                _checkCatQuetVe = 1;
                            }
                            else
                            {
                                if (!isCaDemTrongNgay)
                                {
									kq.tgQuetVe = calam_denGio_4check.Add(new TimeSpan(0, (int)((kq.tgTinhTangCa * 60) - (soTiengCanTru_Le)), 0));
                                    kq.tgQuetVe= kq.tgQuetVe.Add(new TimeSpan(0,(new Random()).Next(1, 14), (new Random()).Next(0, 60)));
									
                                    _checkCatQuetVe = 1;
                                }
                            }
                        }
                        //kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan((int)tgTangCa, 0, 0));
                        //kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan(0, (int)(sole * 60), 0));
                        // Tránh trường hợp bị lỗi. day = 1. sẽ không thể commit được
                        if (kq.tgQuetVe.Days != 0)
                        {
                            if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // nếu là dk làm thêm thì không quá 12h/ngay
                            {
                                if (calam_tuGio_4check.Add(new TimeSpan(12, 0, 0)).Days != 0)
                                {
                                    kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan(-1 * kq.tgQuetVe.Days, 0, 0, 0));
                                    kq.tgQuetVe = new TimeSpan(23, (new Random()).Next(46, 59), (new Random()).Next(0, 60));
                                    _checkCatQuetVe = 1;
                                }
                                else
                                {
                                    kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan(-1 * kq.tgQuetVe.Days, 0, 0, 0));
                                    kq.tgQuetVe = new TimeSpan(calam_tuGio_4check.Add(new TimeSpan(12, 0, 0)).Hours, (new Random()).Next(1, 14), (new Random()).Next(0, 60));
                                    _checkCatQuetVe = 1;
                                }

                            }
                            else
                            {
                                if (calam_denGio_4check.Add(new TimeSpan(4, 0, 0)).Days != 0)
                                {
                                    kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan(-1 * kq.tgQuetVe.Days, 0, 0, 0));
                                    kq.tgQuetVe = new TimeSpan(23, (new Random()).Next(46, 59), (new Random()).Next(0, 60));
                                    _checkCatQuetVe = 1;
                                }
                                else
                                {
                                    kq.tgQuetVe = kq.tgQuetVe.Add(new TimeSpan(-1 * kq.tgQuetVe.Days, 0, 0, 0));
                                    kq.tgQuetVe = new TimeSpan(calam_denGio_4check.Add(new TimeSpan(4, 0, 0)).Hours, (new Random()).Next(1, 14), (new Random()).Next(0, 60));
                                    _checkCatQuetVe = 1;
                                }

                            }
                        }
                    }
                    kq.modifyBy = 1;
                    kq.modifyDate = DateTime.Now;
                }
            }
            if (checkQT == 1 && soTiengOTCat < 9999)
            {
                if (calam.caDem)
                {
                    if (!kq.IstgQuetVeNull() && _checkCatQuetVe == 0) //Thông cắt thời gian quẹt về không quá 15 phút. 2019-08-14 4:17:49 AM 
                    {
                        if (kq.tgTinhTangCa > 0)
                        {
                            int TongPhutTC = (int)(kq.tgTinhTangCa * 60);
                            TimeSpan _mTgQuetVe = kq.tgQuetVe - calam_denGio_4check.Add(new TimeSpan(0, TongPhutTC, 0));
                            if (_mTgQuetVe.TotalMinutes >= 15)
                            {
                                kq.tgQuetVe = calam_denGio_4check.Add(new TimeSpan(0, TongPhutTC + (new Random()).Next(1, 14), (new Random()).Next(0, 60)));
                            }
                        }
                        else
                        {
                            TimeSpan _mTgQuetVe = kq.tgQuetVe - calam_denGio_4check;
                            if (_mTgQuetVe.TotalMinutes >= 15)
                            {
                                kq.tgQuetVe = calam_denGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), (new Random()).Next(0, 60)));
                            }
                        }   
                    }
                }
                else
                {
                    if (!kq.IstgQuetDenNull() && _checkCatQuetDen == 0) //Thông cắt thời gian quẹt đến không quá 15 phút. 2019-08-14 4:17:49 AM 
                    {
                        TimeSpan _tgQuetDen = new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0);

                        TimeSpan _mTgQuetDen = calam_tuGio_4check - _tgQuetDen;

                        if (_mTgQuetDen.TotalMinutes >= 15)
                        {
                            if ((new Random()).Next(1, 5) != 1) // làm lẻ tg quét vân tay vào
                            {
                                kq.tgQuetDen = calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(-14, 0), (new Random()).Next(0, 60)));

                            }
                            else
                            {
                                kq.tgQuetDen = calam_tuGio_4check;
                            }
                        }
                    }
                }

                if (kq.tgTinhTangCa == 0 && soTiengOTCat < 9999)	
                {
                    if (!kq.IstgQuetVeNull() && _checkCatQuetVe == 0) //Thông cắt thời gian quẹt về không quá 15 phút. 2019-08-14 4:17:49 AM 
                    {
                        TimeSpan _mTgQuetVe = kq.tgQuetVe - calam_denGio_4check;

                        if (_mTgQuetVe.TotalMinutes >= 15)
                        {
                            kq.tgQuetVe = calam_denGio_4check.Add(new TimeSpan(0, (new Random()).Next(1, 14), (new Random()).Next(0, 60)));
                        }
                    }

                    if (!kq.IstgQuetDenNull() && _checkCatQuetDen == 0) //Thông cắt thời gian quẹt đến không quá 15 phút. 2019-08-14 4:17:49 AM 
                    {
                        TimeSpan _tgQuetDen = new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0);

                        TimeSpan _mTgQuetDen = calam_tuGio_4check - _tgQuetDen;

                        if (_mTgQuetDen.TotalMinutes >= 15)
                        {
                            if ((new Random()).Next(1, 5) != 1) // làm lẻ tg quét vân tay vào
                            {
                                kq.tgQuetDen = calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(-14, 0), (new Random()).Next(0, 60)));

                            }
                            else
                            {
                                kq.tgQuetDen = calam_tuGio_4check;
                            }
                        }
                    }
                }

                if (kq.tgTinhTangCa > 0 && soTiengOTCat < 9999)
                {
                    int TongPhutTC = (int)(kq.tgTinhTangCa * 60);

                    if (!kq.IstgQuetVeNull() && _checkCatQuetVe == 0)
                    {
                        TimeSpan _mTgQuetVe = kq.tgQuetVe - calam_denGio_4check.Add(new TimeSpan(0, TongPhutTC, 0));

                        if (_mTgQuetVe.TotalMinutes >= 15)
                        {
                            kq.tgQuetVe = calam_denGio_4check.Add(new TimeSpan(0, TongPhutTC + (new Random()).Next(1, 14), (new Random()).Next(0, 60)));
                        }
                    }

                    if (!kq.IstgQuetDenNull() && _checkCatQuetDen == 0)
                    {
                        TimeSpan _tgQuetDen = new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0);

                        TimeSpan _mTgQuetDen = calam_tuGio_4check - _tgQuetDen;

                        if (_mTgQuetDen.TotalMinutes >= 15)
                        {
                            if ((new Random()).Next(1, 5) != 1)
                            {
                                kq.tgQuetDen = calam_tuGio_4check.Add(new TimeSpan(0, (new Random()).Next(-14, 0), (new Random()).Next(0, 60)));
                            }
                            else
                            {
                                kq.tgQuetDen = calam_tuGio_4check;
                            }
                        }
                    }
                }

                kq.modifyBy = 1;
                kq.modifyDate = DateTime.Now;
            }
            #endregion

            var vm = ds.tblEmpDayOff.Where(p => p.FromDate <= kq.ngay.Date && p.ToDate >= kq.ngay.Date && p.EmployeeID == kq.EmployeeID).FirstOrDefault();

            double totalMinutes = soTiengTinhCa_4Calc * 60;
            if (isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday && vm != null)
            {
                vm.PerTimeID = 3;
            }
            double DeductTime = 0;
            TimeSpan? tgQuetDen_kq = null;
            TimeSpan? tgQuetVe_kq = null;

            #region check lễ tết
            bool laNgayPhepNam = false;
            if (vm != null && (vm.LeaveID == "NKT" || vm.LeaveID == "NCO" || vm.LeaveID == "NST" || vm.LeaveID == "NDS"))// Jun sửa lại nghỉ có bảo hiểm 2019/01/10 11:44 AM 
            {
                laNgayPhepNam = false;
            }
            else
            {
                laNgayPhepNam = (!kq.IsdkLamThemNull() && kq.tt_leTet == true); // A trong sửa dklamthem = 3 thành kq.tt_leTet == true 28/02/2018
            }
            #endregion

            #region check Chủ nhật
            if (kq.ngay.DayOfWeek == DayOfWeek.Sunday) // A Trọng add them xet ngay chủ nhật tt_chuNhat để xét báo cáo. 2019/04/08 01:22 PM
            {
                kq.tt_chuNhat = true;
            }
            else
            {
                kq.tt_chuNhat = false;
            }
            #endregion

            if (!kq.IstgQuetDenNull())
            {
                tgQuetDen_kq = kq.tgQuetDen;
            }
            if (!kq.IstgQuetVeNull())
            {
                tgQuetVe_kq = kq.tgQuetVe;
            }

            #region Set lại giờ ra vào nếu đăng ký isTinhCong = true.
            bool isNghiPhepTinhCong = false;
            if (vm != null)
            {
                TimeSpan CL_caSangTuGio, CL_caSangDenGio, CL_caChieuTuGio, CL_caChieuDenGio;
                CL_caSangTuGio = calam.caSang_tuGio;
                CL_caSangDenGio = calam.caSang_denGio;
                CL_caChieuTuGio = calam.caChieu_tuGio;
                CL_caChieuDenGio = calam.caChieu_denGio;

                var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                if (leaveType != null && !leaveType.IsisTinhCongNull() && leaveType.isTinhCong && kq.IsdkLamThemNull())
                {
                    if (vm.PerTimeID == 1)
                    {
                        kq.tgQuetDen = calam.caSang_tuGio;

                        if (CL_caSangDenGio < CL_caSangTuGio)
                        {
                            CL_caSangDenGio = CL_caSangDenGio.Add(new TimeSpan(1, 0, 0, 0));
                        }
                        if (!kq.IstgQuetVeNull())
                        {
                            if (kq.tgQuetVe > CL_caSangTuGio && kq.tgQuetVe < CL_caSangDenGio)
                            {
                                kq.tgQuetVe = calam.caSang_denGio;
                            }
                        }
                        else
                        {
                            kq.tgQuetVe = calam.caSang_denGio;
                        }
                    }
                    else if (vm.PerTimeID == 2)
                    {
                        kq.tgQuetVe = calam.caChieu_denGio;

                        if (CL_caChieuDenGio < CL_caChieuTuGio)
                        {
                            CL_caChieuDenGio = CL_caChieuDenGio.Add(new TimeSpan(1, 0, 0, 0));
                        }
                        if (!kq.IstgQuetDenNull())
                        {
                            if (kq.tgQuetDen > CL_caChieuTuGio && kq.tgQuetDen < CL_caChieuDenGio)
                            {
                                kq.tgQuetDen = calam.caChieu_denGio;
                            }
                        }
                        else
                        {
                            kq.tgQuetDen = calam.caChieu_tuGio;
                        }
                    }
                    else
                    {
                        kq["tgQuetDen"] = calam.caSang_tuGio;
                        kq["tgQuetVe"] = calam.caChieu_denGio;
                        if (isKhongCanQuetThe)
                        {
                            tgQuetVe_kq = null;
                            tgQuetDen_kq = null;
                        }
                    }
                    isNghiPhepTinhCong = true;
                }
            }
            #endregion

            #region Nếu là ca đêm
            if (calam.caDem)
            {
                #region check nghỉ phép
                int nghiCaNgay = 10;
                double tongPhepDenHienTai = 0;
                tongPhepDenHienTai = getTongPhepDenHienTai(db, ds, tuNgay, new DateTime(kq.ngay.Year, 12, 31), kq.EmployeeID);
                if (vm != null && kq.IsdkLamThemNull())//&&!kq.tt_chuNhat
                {
                    double soPhepDK = vm.PerTimeID == 3 ? 1 : 0.5;

                    if (tongPhepDenHienTai < soPhepDK && vm.LeaveID == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam]) // Nếu đăng ký là phép năm và không đủ phép -> Chuyển sang KL. --- Thong Lieu cập nhật 04-01-2018
                    {
                        vm.LeaveID = "P";
                    }

                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (vm.PerTimeID != 3)
                    {
                        if (leaveType != null && (leaveType.IsisTinhCongNull() || !leaveType.isTinhCong) && leaveType.SalaryRate > 0)
                        {
                            kq.daysOfNghiCoLuong = 0.5;
                        }
                        if (vm.PerTimeID == 2)
                        {
                            kq.tt_nghiPhep = 1;
                            kq.tgTinhTangCa = 0;
                            nghiCaNgay = vm.PerTimeID;
                        }
                        else if (vm.PerTimeID == 1)
                        {
                            kq.tt_nghiPhep = 1;
                            nghiCaNgay = vm.PerTimeID;
                        }
                    }
                    else
                    {
                        if (leaveType != null && (leaveType.IsisTinhCongNull() || !leaveType.isTinhCong) && leaveType.SalaryRate > 0)
                        {
                            kq.daysOfNghiCoLuong = 1;
                        }
                        kq.tt_nghiPhep = 1;
                        kq.kqNgayCong = 0;
                        nghiCaNgay = vm.PerTimeID;
                        kq.tgTinhTangCa = 0;
                        if (isKhongCanQuetThe)
                        {
                            tgQuetVe_kq = null;
                            tgQuetDen_kq = null;
                        }
                    }
                }

                if (nghiCaNgay != 10 && kq.IsdkLamThemNull())
                {
                    kq.PerTimeID = vm.PerTimeID;
                    kq.LeaveID = vm.LeaveID;
                    kq.tt_nghiPhep_Alias = vm.LeaveID;
                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (leaveType != null && leaveType.isTinhCong == true)
                    {
                        kq.tt_nghiPhep = 0;
                    }
                }



                #endregion

                #region check vào
                if (kq["tgQuetDen"] != DBNull.Value)
                {
                    kq.tgDiMuon = (int)(new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0) - calam.tuGio).TotalMinutes;
                }
                #endregion

                #region check ra

                kq.tgTinhTangCa = 0;
                double NightOT = 0, NormalOT = 0, NightOTLess24 = 0;
                int CountOTMore4h = 0;
                if (kq["tgQuetVe"] != DBNull.Value)
                {
                    tgQuetVe_kq = kq.tgQuetVe;
                    if (kq.tgQuetVe > calam.tuGio) // Nếu về lúc tối . calam.TuGio là đúng.
                    {
                        if (isCaDemTrongNgay)
                        {
                            kq.tgVeSom = (int)(new TimeSpan(24, 0, 0) - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes + (int)(calam_denGio_4check - new TimeSpan(0, 0, 0)).TotalMinutes;
                        }
                        else
                        {
                            if (isCaDemTrongNgay)
                            {
                                kq.tgVeSom = (int)(new TimeSpan(24, 0, 0) - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes + (int)(calam_denGio_4check - new TimeSpan(0, 0, 0)).TotalMinutes;
                            }
                            else
                            {
                                kq.tgVeSom = (int)((new TimeSpan(0, calam_denGio_4check.Hours, calam_denGio_4check.Minutes, calam_denGio_4check.Seconds)) - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes;
                            }
                        }
                    }
                    else // Nếu về lúc đêm hoặc sáng hsau.
                    {
                        kq.tgVeSom = (int)((new TimeSpan(0, calam_denGio_4check.Hours, calam_denGio_4check.Minutes, calam_denGio_4check.Seconds)) - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes;
                    }
                }
                #endregion

                #region Tăng ca

                if (!kq.IstgQuetVeNull() && !kq.IstgQuetDenNull() && !isNotOT && _checkCatCaDem == 0)
                { // Check xem tăng ca đã được accept chưa.
                    TimeSpan? tgcheckhomsau = new TimeSpan(calam.caChieu_denGio.Hours, calam.caChieu_denGio.Minutes + calam.tgQuetSau_Ra, calam.caChieu_denGio.Milliseconds);
                    TimeSpan? tgchecktruoc = new TimeSpan(calam.caSang_tuGio.Hours, calam.caSang_tuGio.Minutes - calam.tgQuetTruoc_Vao, calam.caSang_tuGio.Milliseconds);
                    DateTime ngaymai = kq.ngay.AddDays(1);
                    DateTime ngaynay = kq.ngay;
                    var ot = ds.tbRequestOverTime.Where(p => p.EmployeeID == kq.EmployeeID && p.ngay == kq.ngay && p.isAccept); // Phước add 06/03/2019

                    if (ot == null)
                    {
                        kq.tgTinhTangCa = 0;
                    }
                    else
                    {

                        //phước add thêm =2019-01-08 
                        int tgChoPhepTC = 0;
                        DateTime ngaytangca = kq.ngay;
                        DateTime ngaytangcaden = kq.ngay.AddDays(1);
                        foreach (var dr in ot)
                        {
                            //duyệt danh sách các đăng ký của nhân viên đó trong ngày đó
                            TimeSpan timeTuGio = dr.tuGio;
                            TimeSpan timeDenGio = dr.denGio;//thoigian dang ky
                            TimeSpan timeQuetDen = kq.tgQuetDen;
                            TimeSpan timeQuetVe = kq.tgQuetVe;
                            TimeSpan timeCalamTuGio = calam.caSang_tuGio;
                            TimeSpan timeCalamDenGio = calam.caChieu_denGio;
                            DateTime ngayDK = dr.ngay;

                            if (_checkCatOT == 1)
                            {
                                TimeSpan _mTgTangCa = timeDenGio - timeTuGio;

                                if (_mTgTangCa.TotalHours > soTiengOTCat)
                                {
                                    timeDenGio = timeTuGio.Add(new TimeSpan(0, soTiengOTCat * 60, 0));
                                }
                            }

                            #region Đăng ký tăng sau ca làm
                            //đang ký tăng ca sau giờ làm
                            if (timeTuGio <= tgcheckhomsau && timeTuGio >= timeCalamDenGio && timeTuGio < kq.tgQuetVe && emp7Hours == null)//&& ngayDK.Date == ngaymai
                            {
                                TimeSpan tgBatDauTinhTC = timeTuGio;

                                if (timeDenGio > kq.tgQuetVe) // Jun sửa lại 2019/01/10 3:13 PM
                                {
                                    timeDenGio = kq.tgQuetVe;
                                }
                                if (timeTuGio >= kq.tgQuetVe)
                                {
                                    timeTuGio = timeDenGio = kq.tgQuetVe;
                                }

                                if (tgBatDauTinhTC >= timeDenGio)
                                {
                                    tgChoPhepTC += (int)(tgBatDauTinhTC.Add(new TimeSpan(24, 0, 0)) - timeDenGio).TotalMinutes;
                                }
                                else
                                {
                                    tgChoPhepTC += (int)(timeDenGio - tgBatDauTinhTC).TotalMinutes;
                                }

                                if (_checkCatOT == 1)
                                {
                                    timeDenGio = RoundDown(DateTime.Parse(timeDenGio.ToString()), TimeSpan.FromMinutes(15));
                                }

                                GetOTHours(kq, timeTuGio, timeDenGio, ref NightOT, ref NormalOT, ref NightOTLess24, ref CountOTMore4h);
                                kq.OTMore4h += CountOTMore4h;

                                if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm.
                                {
                                    int CountOTMore8h = 0;

                                    if (_checkCatOT == 1)
                                    {
                                        timeDenGio = RoundDown(DateTime.Parse(timeDenGio.ToString()), TimeSpan.FromMinutes(15));
                                    }
                                    GetOTHours(kq, timeTuGio, timeDenGio, ref CountOTMore8h);
                                    kq.OTMore8h = kq.OTMore8h + CountOTMore8h;
                                }
                            }
                            #endregion

                        }

                        kq.tgTinhTangCa -= soTiengTCTN;

                        if (kq.tgTinhTangCa <= 0)
                            kq.tgTinhTangCa = 0;


                        kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, (float)tgChoPhepTC / 60);



                    }

                    // tăng ca theo ca đêm
                    if (calam.soTiengTinhTangCa > 0 && emp7Hours == null && !isCaDemTrongNgay)
                    {
                        int SoPhutTC = Convert.ToInt32(Convert.ToDouble(calam.soTiengTinhTangCa) * 60);

                        TimeSpan timeTuGio = calam.caChieu_denGio;
                        TimeSpan timeDenGio = new TimeSpan(timeTuGio.Hours, timeTuGio.Minutes + SoPhutTC, timeTuGio.Seconds); // add thêm soTiengTinhTangCa                   

                        TimeSpan timeCalamTuGio = calam.caSang_tuGio;
                        TimeSpan timeCalamDenGio = calam.caChieu_denGio;
                        DateTime ngayDK = kq.ngay;
                        int tgChoPhepTC = 0;

                        if (!kq.IstgQuetDenNull() && !kq.IstgQuetVeNull() && kq.tgQuetVe > timeTuGio)
                        {
                            if (timeTuGio >= timeDenGio)
                            {
                                tgChoPhepTC += (int)(timeTuGio.Add(new TimeSpan(24, 0, 0)) - timeDenGio).TotalMinutes;
                            }
                            else
                            {
                                if (timeDenGio > kq.tgQuetVe)
                                {
                                    timeDenGio = kq.tgQuetVe;
                                }

                                tgChoPhepTC += (int)(timeDenGio - timeTuGio).TotalMinutes;
                            }
                            if (_checkCatOT == 1)
                            {
                                timeDenGio = RoundDown(DateTime.Parse(timeDenGio.ToString()), TimeSpan.FromMinutes(15));
                            }
                            GetOTHours(kq, timeTuGio, timeDenGio, ref NightOT, ref NormalOT, ref NightOTLess24, ref CountOTMore4h);
                            kq.OTMore4h += CountOTMore4h;

                        }

                        if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm.
                        {
                            int CountOTMore8h = 0;
                            if (_checkCatOT == 1)
                            {
                                timeDenGio = RoundDown(DateTime.Parse(timeDenGio.ToString()), TimeSpan.FromMinutes(15));
                            }
                            GetOTHours(kq, timeTuGio, timeDenGio, ref CountOTMore8h);
                            kq.OTMore8h = kq.OTMore8h + CountOTMore8h;
                        }

                        kq.tgTinhTangCa -= soTiengTCTN;

                        if (kq.tgTinhTangCa <= 0)
                            kq.tgTinhTangCa = 0;
                        kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, (float)tgChoPhepTC / 60);
                    }
                }
                #endregion

                #region Ra vào giữa ca
                // Nếu có đăng ký ra vào giữa ca
                double NormalOIS = 0;
                double NightOIS = 0;
                var rqRequestOutInShift = ds.tbRequestOutInShift.Where(p => p.EmployeeID == kq.EmployeeID && p.ngay == kq.ngay && p.isAccept);
                if (rqRequestOutInShift.Count() > 0)
                {
                    foreach (var item in rqRequestOutInShift)
                    {
                        GetOISHours(kq, item.tuGio, item.denGio, ref NormalOIS, ref NightOIS);
                    }
                }

                kq.NormalOISDay = roundSQL(NormalOIS / 60, 2, false);
                kq.NightOISDay = roundSQL(NightOIS / 60, 2, false);

                #endregion

                #region check có đi làm (quẹt tay) hay ko
                kq.tt_coQuetTay = (kq["tgQuetDen"] != DBNull.Value ? 1 : 0) + (kq["tgQuetVe"] != DBNull.Value ? 2 : 0);
                #endregion

                #region check di muon ve som
                if (kq.tt_coQuetTay == 3)
                {
                    kq.tt_ok = 1;
                    if (kq.tgDiMuon > 0)
                    {
                        kq.tt_diMuonVeSom = 1;
                        if (kq.tgDiMuon > 0)
                        {
                            DeductTime += kq.tgDiMuon;
                        }
                    }
                    if (kq.tgVeSom > 0)
                    {
                        kq.tt_diMuonVeSom += 2;
                        if (kq.tgVeSom > 0)
                        {
                            DeductTime += kq.tgVeSom;
                        }
                    }
                    kq.WorkingHours = roundSQL((totalMinutes - DeductTime) / 60, 2, true) > 0 ? roundSQL((totalMinutes - DeductTime) / 60, 2, true) : 0;
                    kq.kqNgayCong = roundSQL(kq.WorkingHours * 60 / totalMinutes, 2, false);

                    kq.kqNgayCong = Math.Max(kq.kqNgayCong, 0);
                    if (kq.kqNgayCong == 0)
                    {
                        kq.tgTinhTangCa = 0;
                    }
                }
                else
                {
                    kq.tt_ok = 0;
                    kq.kqNgayCong = 0;
                    kq.tgTinhTangCa = 0;
                }
                if ((kq.tt_coQuetTay != 3 || kq.kqNgayCong == 0) && !laNgayPhepNam)// Những trường hợp công = 0 thì cho KP để tính lương. A trọng yêu cầu
                {
                    if (nghiCaNgay == 10) // Nếu băng 10 thì nghĩa là không đăng ký phép.
                    {
                        kq.tt_nghiPhep_Alias = kq.LeaveID = "KP";
                        kq.tt_nghiPhep = 0;
                        kq.PerTimeID = 3;
                    }
                    kq.tgTinhTangCa = 0;
                }

                tinhLaiTgDiMuonVeSom(ds, kq, calam);
                if (tgQuetDen_kq != null)
                {
                    kq.tgQuetDen = tgQuetDen_kq.Value;
                }
                if (tgQuetVe_kq != null)
                {
                    kq.tgQuetVe = tgQuetVe_kq.Value;
                }
                #endregion

                if (vm != null && kq.tt_leTet)
                {
                    var bh = db.tblRef_LeaveTypes.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (bh.IsInsurance == true)
                    {
                        kq.PerTimeID = vm.PerTimeID;
                        kq.LeaveID = vm.LeaveID;
                        kq.tt_nghiPhep_Alias = vm.LeaveID;
                        kq.tt_nghiPhep = 1;

                        kq.tt_leTet = false;
                        kq["dkLamThem"] = DBNull.Value;
                        kq["isAutomatic"] = DBNull.Value;
                    }
                }
                //Ca ngày : 06:00 - 22:00.
                //Ca đêm: 22:01 - 05:59
                #region update NightOT, NormalOT, tgTinhTangCa
                kq.NightOT = roundSQL(NightOT, 2, false);
                kq.NightOTLess24 = NightOTLess24;
                kq.NormalOT = roundSQL(NormalOT, 2, false);
                kq.tgTinhTangCa = kq.NightOT + kq.NormalOT;
                #region update NightDay , NightOT cũ
                double NightDay = 0;

                // NightDay
                if (!kq.IskqNgayCongNull() && kq.kqNgayCong > 0 && (kq.tgQuetVe >= new TimeSpan(22, 0, 0) || kq.tgQuetVe < new TimeSpan(22, 0, 0)))
                {
                    TimeSpan tgQuetDen = new TimeSpan();
                    TimeSpan tgQuetVe = new TimeSpan();
                    if (kq.tgQuetDen <= new TimeSpan(22, 0, 0) && kq.tgQuetDen >= new TimeSpan(17, 0, 0))
                    {
                        // Vì ca làm bắt đầu có thể lớn hơn 22h. Không thể set cứng là 22h được. Tính nightDay sẽ lớn hơn. Sửa ngày 11/02.
                        if (calam.caSang_tuGio > new TimeSpan(22, 0, 0))
                        {
                            tgQuetDen = calam.caSang_tuGio;
                        }
                        else
                        {
                            tgQuetDen = new TimeSpan(22, 0, 0);
                        }
                    }
                    else
                    {
                        if (calam.caSang_tuGio >= new TimeSpan(22, 0, 0))
                        {
                            if (kq.tgQuetDen <= calam.caSang_tuGio)
                            {
                                tgQuetDen = calam.caSang_tuGio;
                            }
                            else
                            {
                                tgQuetDen = kq.tgQuetDen;
                            }
                        }
                        else
                        {
                            tgQuetDen = kq.tgQuetDen;
                        }
                    }

                    if (kq.tgQuetVe >= new TimeSpan(22, 0, 0))
                    {
                        tgQuetVe = kq.tgQuetVe;
                    }
                    else
                    {
                        if (kq.tgQuetVe >= new TimeSpan(6, 0, 0) && !isCaDemTrongNgay)
                        {
                            tgQuetVe = new TimeSpan(6, 0, 0);
                        }
                        else
                        {
                            tgQuetVe = kq.tgQuetVe;
                        }
                    }
                    //Tính toán
                    if (tgQuetVe <= new TimeSpan(24, 0, 0) && tgQuetVe >= new TimeSpan(10, 0, 0))
                    {
                        if (tgQuetVe < new TimeSpan(22, 0, 0) && isCaDemTrongNgay)
                        {
                            NightDay += 0;
                        }
                        else
                        {
                            NightDay += (tgQuetVe - tgQuetDen).TotalMinutes / (kq.SoTiengTinhCa * 60);
                        }

                    }
                    else
                    {
                        if (tgQuetDen <= new TimeSpan(24, 0, 0) && tgQuetDen >= new TimeSpan(10, 0, 0))
                        {
                            if (tgQuetDen < calam.caSang_tuGio)
                            {
                                tgQuetDen = new TimeSpan(22, 0, 0);
                            }
                            if (tgQuetVe > calam.caChieu_denGio)
                            {
                                tgQuetVe = calam.caChieu_denGio;
                            }
                            NightDay += (tgQuetVe.Add(new TimeSpan(24, 0, 0)) - tgQuetDen).TotalMinutes / (kq.SoTiengTinhCa * 60);
                        }
                        else
                        {
                            if (kq.idCaLam == Guid.Parse("BE478C1D-7450-44AB-9EA3-F537122A913C") && tgQuetVe > calam.caChieu_denGio)// Xử lý trường hợp ca làm 2h sáng. nhưng lại quẹt 4h sáng.
                            {
                                tgQuetVe = calam.caChieu_denGio;
                            }
                            if (tgQuetVe < tgQuetDen) // Xử lý trường hợp làm từ 9h sáng đến 4h sáng hsau.
                            {
                                if (tgQuetDen <= new TimeSpan(22, 0, 0))
                                {
                                    tgQuetDen = new TimeSpan(22, 0, 0);
                                }
                                if (tgQuetVe >= new TimeSpan(6, 0, 0))
                                {
                                    tgQuetVe = new TimeSpan(6, 0, 0).Add(new TimeSpan(24, 0, 0));
                                }
                                else
                                {
                                    tgQuetVe = tgQuetVe.Add(new TimeSpan(24, 0, 0));
                                }
                            }
                            NightDay += (tgQuetVe - tgQuetDen).TotalMinutes / (kq.SoTiengTinhCa * 60);
                        }
                    }
                }
                kq.NightDay = NightDay;
                kq.NormalDay = 0;
                kq.NormalDay = kq.kqNgayCong - kq.NightDay;
                #endregion
                #endregion

                #region check error
                kq.tt_error = 0;

                #endregion

                kq.statePushServer = "edited";
                kq.analyzeDate = DateTime.Now;
                //kq.analyzeBy = UserDoing.id;
            }
            #endregion

            #region Nếu là ca ngày
            else // Nếu là ca ngày, sáng, chiều, hành chính.
            {
                #region check nghỉ phép
                int nghiCaNgay = 10;
                double tongPhepDenHienTai = 0;
                tongPhepDenHienTai = getTongPhepDenHienTai(db, ds, tuNgay, new DateTime(kq.ngay.Year, 12, 31), kq.EmployeeID);
                if (vm != null && kq.IsdkLamThemNull())//&&!kq.tt_chuNhat
                {
                    double soPhepDK = vm.PerTimeID == 3 ? 1 : 0.5;
                    if ((tongPhepDenHienTai < soPhepDK && vm.LeaveID == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam])) // Nếu đăng ký là phép năm và không đủ phép -> Chuyển sang KL.
                    {
                        vm.LeaveID = "P";
                    }
                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (vm.PerTimeID != 3)
                    {
                        if (leaveType != null && (leaveType.IsisTinhCongNull() || !leaveType.isTinhCong) && leaveType.SalaryRate > 0)
                        {
                            kq.daysOfNghiCoLuong = 0.5;
                        }
                        if (vm.PerTimeID == 2)
                        {
                            kq.tt_nghiPhep = 1;
                            kq.tgTinhTangCa = 0;
                            nghiCaNgay = vm.PerTimeID;
                        }
                        else if (vm.PerTimeID == 1)
                        {
                            kq.tt_nghiPhep = 1;
                            nghiCaNgay = vm.PerTimeID;
                        }
                    }
                    else
                    {
                        if (leaveType != null && (leaveType.IsisTinhCongNull() || !leaveType.isTinhCong) && leaveType.SalaryRate > 0)
                        {
                            kq.daysOfNghiCoLuong = 1;
                        }
                        kq.tt_nghiPhep = 1;
                        kq.kqNgayCong = 0;
                        nghiCaNgay = vm.PerTimeID;
                        kq.tgTinhTangCa = 0;
                        if (isKhongCanQuetThe)
                        {
                            tgQuetVe_kq = null;
                            tgQuetDen_kq = null;
                        }
                    }
                }

                if (nghiCaNgay != 10 && kq.IsdkLamThemNull())
                {
                    kq.PerTimeID = vm.PerTimeID;
                    kq.LeaveID = vm.LeaveID;
                    kq.tt_nghiPhep_Alias = vm.LeaveID;
                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (leaveType != null && leaveType.isTinhCong == true)
                    {
                        kq.tt_nghiPhep = 0;
                    }
                }



                #endregion

                #region check vào
                #region tính tg đi muộn dựa vào tgQuetDen và ca xin nghỉ
                if (kq["tgQuetDen"] != DBNull.Value)
                {
                    kq.tgDiMuon = (int)(new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0) - calam_tuGio_4check).TotalMinutes;

                    if (kq.tgQuetDen > calam.caSang_denGio) //kiểm tra muộn qua h nghỉ trưa thì trừ
                        kq.tgDiMuon -= (int)(Math.Min(kq.tgQuetDen.TotalMinutes, calam.caChieu_tuGio.TotalMinutes) - calam.caSang_denGio.TotalMinutes);
                }
                #endregion
                #endregion

                #region check ra
                kq.tgTinhTangCa = 0;
                double NightOT = 0, NormalOT = 0, NightOTLess24 = 0;
                int CountOTMore4h = 0;
                if (kq["tgQuetVe"] != DBNull.Value)
                {
                    if (new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0) > calam_tuGio_4check)
                    {
                        kq.tgVeSom = (int)(calam_denGio_4check - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes;
                    }
                    else
                    {
                        kq.tgVeSom = (int)(calam_denGio_4check - calam_tuGio_4check).TotalMinutes;
                    }
                    if (kq.ngay.DayOfWeek == DayOfWeek.Saturday && !calam.IsT7LamSangNull() && calam.T7LamSang)
                    {
                        // Khong lam gi ca.
                    }
                    else
                    {
                        if (kq.tgQuetVe < calam.caChieu_tuGio) //kiểm tra sớm trước h nghỉ trưa thì trừ
                            kq.tgVeSom -= (int)(calam.caChieu_tuGio.TotalMinutes - Math.Max(kq.tgQuetVe.TotalMinutes, calam.caSang_denGio.TotalMinutes));
                    }
                }
                #endregion

                setTGQuetDuaVaoVangMat(kq, calam, calam_denGio_4check, isNghiPhepTinhCong);

                #region Tăng ca
                //&& !(isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday)
                if (!kq.IstgQuetVeNull() && !kq.IstgQuetDenNull() && !isNotOT && _checkCatCaDem == 0) // T7 làm sáng không có tăng ca. // add thêm  kq.tgVeSom <= -15  ====> !kq.IstgQuetDenNull()
                {
                    // tăng ca nhiều lần
                    var ot = ds.tbRequestOverTime.Where(p => p.EmployeeID == kq.EmployeeID && p.ngay == kq.ngay && p.isAccept);
                    if (ot == null)
                    {
                        kq.tgTinhTangCa = 0;
                    }
                    else
                    {
                        //phước add thêm =2019-01-08 
                        int tgChoPhepTC = 0;

                        foreach (var dr in ot)
                        {
                            TimeSpan timeTuGio = dr.tuGio;
                            TimeSpan timeDenGio = dr.denGio;

                            if (_checkCatOT == 1)
                            {
                                TimeSpan _mTgTangCa = timeDenGio - timeTuGio;

                                if (_mTgTangCa.TotalHours > soTiengOTCat)
                                {
                                    timeDenGio = timeTuGio.Add(new TimeSpan(0, soTiengOTCat * 60, 0));
                                }
                            }

                            #region Tăng ca sau ca làm

                            if (timeTuGio >= calam_denGio_4check && emp7Hours == null) //đăng ký tăng ca sau ca làm
                            {

                                TimeSpan tgBatDauTinhTC = timeTuGio;      // này là thời gian ca làm                   

                                if (timeDenGio > kq.tgQuetVe)
                                {
                                    timeDenGio = kq.tgQuetVe;
                                }
                                if (timeTuGio >= kq.tgQuetVe)
                                {
                                    timeTuGio = timeDenGio = kq.tgQuetVe;
                                }
                                if (tgBatDauTinhTC >= timeDenGio)
                                {
                                    tgChoPhepTC += (int)(tgBatDauTinhTC.Add(new TimeSpan(24, 0, 0)) - timeDenGio).TotalMinutes;
                                }
                                else
                                {
                                    tgChoPhepTC += (int)(timeDenGio - tgBatDauTinhTC).TotalMinutes;
                                }

                                if (_checkCatOT == 1)
                                {
                                    timeDenGio = RoundDown(DateTime.Parse(timeDenGio.ToString()), TimeSpan.FromMinutes(15));
                                }
                                GetOTHours(kq, timeTuGio, timeDenGio, ref NightOT, ref NormalOT, ref NightOTLess24, ref CountOTMore4h);
                                kq.OTMore4h += CountOTMore4h;

                                if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm.
                                {
                                    int CountOTMore8h = 0;
                                    if (_checkCatOT == 1)
                                    {
                                        timeDenGio = RoundDown(DateTime.Parse(timeDenGio.ToString()), TimeSpan.FromMinutes(15));
                                    }
                                    GetOTHours(kq, timeTuGio, timeDenGio, ref CountOTMore8h);
                                    kq.OTMore8h = kq.OTMore8h + CountOTMore8h;
                                }
                            }
                            #endregion
                        }

                        kq.tgTinhTangCa -= soTiengTCTN;

                        if (kq.tgTinhTangCa <= 0)
                            kq.tgTinhTangCa = 0;
                        kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, (float)tgChoPhepTC / 60);
                    }

                }

                //tăng ca theo ca ngày
                if (calam.soTiengTinhTangCa > 0 && emp7Hours == null && _checkCatCaDem == 0)
                {

                    int SoPhutTC = Convert.ToInt32(Convert.ToDouble(calam.soTiengTinhTangCa) * 60);

                    TimeSpan timeTuGio = calam.caChieu_denGio;
                    TimeSpan timeDenGio = new TimeSpan(timeTuGio.Hours, timeTuGio.Minutes + SoPhutTC, timeTuGio.Seconds); // add thêm soTiengTinhTangCa                   

                    TimeSpan timeCalamTuGio = calam.caSang_tuGio;
                    TimeSpan timeCalamDenGio = calam.caChieu_denGio;
                    DateTime ngayDK = kq.ngay;
                    int tgChoPhepTC = 0;
                    if (!kq.IstgQuetDenNull() && !kq.IstgQuetVeNull() && kq.tgQuetVe > timeTuGio)
                    {
                        if (timeTuGio >= timeDenGio)
                        {
                            tgChoPhepTC += (int)(timeTuGio.Add(new TimeSpan(24, 0, 0)) - timeDenGio).TotalMinutes;
                        }
                        else
                        {
                            if (timeDenGio > kq.tgQuetVe)
                            {
                                timeDenGio = kq.tgQuetVe;
                            }
                            tgChoPhepTC += (int)(timeDenGio - timeTuGio).TotalMinutes;
                        }
                        if (_checkCatOT == 1)
                        {
                            timeDenGio = RoundDown(DateTime.Parse(timeDenGio.ToString()), TimeSpan.FromMinutes(15));
                        }
                        GetOTHours(kq, timeTuGio, timeDenGio, ref NightOT, ref NormalOT, ref NightOTLess24, ref CountOTMore4h);
                        kq.OTMore4h += CountOTMore4h;
                    }
                    if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm.
                    {
                        int CountOTMore8h = 0;
                        if (_checkCatOT == 1)
                        {
                            timeDenGio = RoundDown(DateTime.Parse(timeDenGio.ToString()), TimeSpan.FromMinutes(15));
                        }
                        GetOTHours(kq, timeTuGio, timeDenGio, ref CountOTMore8h);
                        kq.OTMore8h = kq.OTMore8h + CountOTMore8h;
                    }
                    kq.tgTinhTangCa -= soTiengTCTN;

                    if (kq.tgTinhTangCa <= 0)
                        kq.tgTinhTangCa = 0;
                    kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, (float)tgChoPhepTC / 60);
                }
                #endregion

                #region Ra vào giữa ca
                // Nếu có đăng ký ra vào giữa ca
                double NormalOIS = 0;
                double NightOIS = 0;
                var rqRequestOutInShift = ds.tbRequestOutInShift.Where(p => p.EmployeeID == kq.EmployeeID && p.ngay == kq.ngay && p.isAccept);
                if (rqRequestOutInShift.Count() > 0)
                {
                    foreach (var item in rqRequestOutInShift)
                    {
                        GetOISHours(kq, item.tuGio, item.denGio, ref NormalOIS, ref NightOIS);
                    }
                }

                kq.NormalOISDay = roundSQL(NormalOIS / 60, 2, false);
                kq.NightOISDay = roundSQL(NightOIS / 60, 2, false);

                #endregion

                #region check có đi làm (quẹt tay) hay ko
                kq.tt_coQuetTay = (kq["tgQuetDen"] != DBNull.Value ? 1 : 0) + (kq["tgQuetVe"] != DBNull.Value ? 2 : 0);
                #endregion

                #region check di muon ve som và tính kqNgayCong
                if (kq.tt_coQuetTay == 3)
                {
                    kq.tt_ok = 1;
                    if (kq.tgDiMuon > 0)
                    {
                        kq.tt_diMuonVeSom = 1;
                        if (kq.tgDiMuon > 0)
                        {
                            DeductTime += kq.tgDiMuon;
                        }
                    }
                    if (kq.tgVeSom > 0)
                    {
                        kq.tt_diMuonVeSom += 2;
                        if (kq.tgVeSom > 0)
                        {
                            DeductTime += kq.tgVeSom;
                        }
                    }
                    if (isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday) // là t7 làm sáng
                    {
                        // tính lại công này thứ 7
                        kq.WorkingHours = roundSQL((tongphutT7 - DeductTime) / 60, 2, true) > 0 ? roundSQL((tongphutT7 - DeductTime) / 60, 2, true) : 0;
                        kq.kqNgayCong = roundSQL(kq.WorkingHours * 60 / totalMinutes, 2, false);

                    }
                    else
                    {
                        kq.WorkingHours = roundSQL((totalMinutes - DeductTime) / 60, 2, true) > 0 ? roundSQL((totalMinutes - DeductTime) / 60, 2, true) : 0;
                        kq.kqNgayCong = roundSQL(kq.WorkingHours * 60 / totalMinutes, 2, false);
                    }

                    kq.kqNgayCong = Math.Max(kq.kqNgayCong, 0);
                    if (kq.kqNgayCong == 0)
                    {
                        kq.tgTinhTangCa = 0;
                    }
                }
                else
                {
                    kq.tt_ok = 0;
                    kq.kqNgayCong = 0;
                    kq.tgTinhTangCa = 0;
                }
                #endregion

                if ((kq.tt_coQuetTay != 3 || kq.kqNgayCong == 0) && !laNgayPhepNam) // Những trường hợp công = 0 thì cho KP để tính lương. A trọng yêu cầu
                {
                    if (nghiCaNgay == 10) // Nếu băng 10 thì nghĩa là không đăng ký phép.
                    {
                        kq.tt_nghiPhep_Alias = kq.LeaveID = "KP";
                        kq.tt_nghiPhep = 0;
                        kq.PerTimeID = 3;
                    }
                    kq.tgTinhTangCa = 0;
                }

                tinhLaiTgDiMuonVeSom(ds, kq, calam);
                if (tgQuetDen_kq != null)
                {
                    kq.tgQuetDen = tgQuetDen_kq.Value;
                }
                if (tgQuetVe_kq != null)
                {
                    kq.tgQuetVe = tgQuetVe_kq.Value;
                }
                if (vm != null && kq.tt_leTet)
                {
                    var bh = db.tblRef_LeaveTypes.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (bh.IsInsurance == true)
                    {
                        kq.PerTimeID = vm.PerTimeID;
                        kq.LeaveID = vm.LeaveID;
                        kq.tt_nghiPhep_Alias = vm.LeaveID;
                        kq.tt_nghiPhep = 1;

                        kq.tt_leTet = false;
                        kq["dkLamThem"] = DBNull.Value;
                        kq["isAutomatic"] = DBNull.Value;
                    }
                }
                //Ca ngày : 06:00 - 22:00.
                //Ca đêm: 22:01 - 05:59
                #region update NightOT, NormalOT, tgTinhTangCa
                kq.NightOT = roundSQL(NightOT, 2, false);
                kq.NormalOT = roundSQL(NormalOT, 2, false);
                kq.NightOTLess24 = NightOTLess24;
                kq.tgTinhTangCa = kq.NightOT + kq.NormalOT;

                //Phước fix ngày 29-10-2018 note: code cũ bị thiếu
                #region update NightDay , NormalDay

                double NightDay = 0;
                if (!kq.IskqNgayCongNull() && kq.kqNgayCong > 0 && (kq.tgQuetVe >= new TimeSpan(22, 0, 0) || kq.tgQuetVe <= new TimeSpan(24, 0, 0)))
                {
                    //gán lại thời gian quẹt thẻ ra vào
                    TimeSpan tgQuetDen = new TimeSpan();
                    TimeSpan tgQuetVe = new TimeSpan();
                    if (kq.tgQuetDen <= new TimeSpan(22, 0, 0) && kq.tgQuetDen >= new TimeSpan(17, 0, 0))
                    {
                        // Vì ca làm bắt đầu có thể lớn hơn 22h. Không thể set cứng là 22h được. Tính nightDay sẽ lớn hơn. Sửa ngày 11/02.
                        if (calam.caSang_tuGio > new TimeSpan(22, 0, 0))
                        {
                            tgQuetDen = calam.caSang_tuGio;
                        }
                        else
                        {
                            tgQuetDen = new TimeSpan(22, 0, 0);
                        }
                    }
                    else
                    {
                        tgQuetDen = kq.tgQuetDen;
                    }

                    if (kq.tgQuetVe >= new TimeSpan(22, 0, 0))
                    {
                        tgQuetVe = kq.tgQuetVe;
                    }
                    else
                    {
                        tgQuetVe = new TimeSpan(22, 0, 0);
                    }
                    //Tính toán
                    if (tgQuetVe <= new TimeSpan(22, 0, 0))
                    {
                        //với thời gian quẹt về từ 10h-22h thì làm thêm đêm bằng 0
                        NightDay = 0;
                    }
                    else
                    {
                        // thời gian quẹt về từ 22h-24h là tính tăng ca
                        if (tgQuetVe <= new TimeSpan(24, 0, 0) && tgQuetVe >= new TimeSpan(22, 0, 0))
                        {
                            if (calam.caChieu_denGio > new TimeSpan(22, 0, 0))
                            {
                                if (tgQuetVe < calam.caChieu_denGio)
                                {
                                    NightDay += (tgQuetVe - new TimeSpan(22, 0, 0)).TotalMinutes / (kq.SoTiengTinhCa * 60);
                                }
                                else
                                {
                                    NightDay += (calam.caChieu_denGio - new TimeSpan(22, 0, 0)).TotalMinutes / (kq.SoTiengTinhCa * 60);
                                }
                            }
                            else
                            {
                                NightDay = 0;
                            }
                        }
                    }
                }
                kq.NightDay = NightDay;
                kq.NormalDay = 0;
                kq.NormalDay = kq.kqNgayCong - kq.NightDay;
                #endregion



                #region update NightDay , NightOT, NormalDay, NormalOT cũ
                //kq.NormalDay = 0;
                //kq.NormalOT = 0;
                //kq.WorkingHours = kq.kqNgayCong * 8;
                //kq.NormalOT = kq.tgTinhTangCa - kq.NightOT;
                #endregion
                #endregion

                #region check error
                kq.tt_error = 0;
                //if (vm != null && kq.tt_coQuetTay == 3)
                //{
                //    if ((kq.tgQuetDen <= vm.tuGio && vm.tuGio < kq.tgQuetVe) || (kq.tgQuetDen < vm.denGio && vm.denGio <= kq.tgQuetVe))
                //    {
                //        kq.tt_error = 1;
                //    }
                //}
                #endregion

                kq.statePushServer = "edited";
                kq.analyzeDate = DateTime.Now;
            }
            #endregion

            if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm. 
            {
                kq.OTMore8h = kq.OTMore8h + (int)((kq.kqNgayCong * kq.SoTiengTinhCa) / 8);
                kq.OTMore4h += (int)((kq.kqNgayCong * kq.SoTiengTinhCa) / 4);

            }
            if (!kq.IsdkLamThemNull() && (kq.dkLamThem == 0 || kq.dkLamThem == 1) && isNotOT && !kq.tt_leTet)
            {
                kq.NightOT = kq.NormalOT = kq.NightOTLess24 = kq.NightDay = kq.NormalDay = kq.tgTinhTangCa = 0;
                kq.OTMore4h = kq.OTMore8h = 0;
                kq.kqNgayCong = 0;
                kq.LeaveID = null;
                kq["PerTimeID"] = DBNull.Value;
                kq.tt_nghiPhep = 0;
                kq.tt_nghiPhep_Alias = "";
            }
            if (isNotOT && !kq.tt_leTet)
            {
                kq.NightOT = kq.NormalOT = kq.NightOTLess24 = kq.OTMore4h = kq.OTMore8h = 0;
                kq.NormalOTBeforeShift = kq.NormalOTInShift = kq.NightOTBeforeShift = kq.NightOTInShift = kq.tgTinhTangCa = 0;
            }

            if (vm != null && kq.IsdkLamThemNull()) // A Trọng add vào ngày 30/05/2018 để set tgDiMuon, tgVeSom = 0 nếu là dk nghỉ cả ngày.
            {
                if (kq.PerTimeID == 3 && kq.kqNgayCong == 0)
                {
                    kq.tgDiMuon = 0;
                    kq.tgVeSom = 0;
                }
            }

            if (calam.isTruTangCa)
            {
                if (kq.tgTinhTangCa >= calam.soTiengTangCa)
                {
                    kq.tgTinhTangCa = kq.tgTinhTangCa - calam.soTiengTruTangCa;

                    if (kq.NormalOT >= calam.soTiengTruTangCa)
                    {
                        kq.NormalOT = kq.NormalOT - calam.soTiengTruTangCa;
                    }
                    else if (kq.NightOT >= calam.soTiengTruTangCa)
                    {
                        kq.NightOT = kq.NightOT - calam.soTiengTruTangCa;
                    }
                }
            }

            if (kq.NormalOT > 0 && calam.caDem == true)
            {
                kq.NightOT = kq.NightOT + kq.NormalOT;
                kq.NormalOT = 0;
            }

            if (kq.NormalOISDay > 0 || kq.NightOISDay > 0)
            {
                kq.WorkingHours = kq.WorkingHours - kq.NormalOISDay - kq.NightOISDay;

                kq.NormalDay = kq.NormalDay - (kq.NormalOISDay / kq.SoTiengTinhCa);
                kq.NightDay = kq.NightDay - (kq.NightOISDay / kq.SoTiengTinhCa);
                kq.kqNgayCong = kq.kqNgayCong - (kq.NormalOISDay / kq.SoTiengTinhCa) - (kq.NightOISDay / kq.SoTiengTinhCa);
            }

            kq.kqNgayCong = kq.kqNgayCong * (calam.IskqNgayCongNull() ? 1 : calam.kqNgayCong);
            return kq;
        }

        public static dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow AnalyzeDataQuetThe_dlgXL(dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, bool isNotOT, DateTime tuNgay, bool isKhongCanQuetThe, dcDatabaseDataContext db, bool isCaDemTrongNgay, String empID, double soTiengTCTN = 0, int soTiengOTCat = 0)
        {
            dsXuLyQuetThe ds = new dsXuLyQuetThe();
            #region get data

            Provider.LoadData(ds, ds.tbCaLamViec.TableName);

            Provider.LoadData(ds, ds.tbNgayNghiPhepNam.TableName);

            Provider.LoadDataByProc(ds
                                    , ds.tblEmpDayOff.TableName
                                    , "p_getAllDangKyVangMat"
                                    , new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay))
                                    , new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(tuNgay.AddDays(1))));

            Provider.LoadDataByProc(ds
                                    , ds.tblEmp7hours.TableName
                                    , "p_GetAllEmp7hours", new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay))
                                    , new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(tuNgay)));

            Provider.LoadDataByProc(ds
                                    , ds.tblRef_EmployeeType.TableName
                                    , "p_GetAlltblRef_EmployeeType");

            Provider.LoadDataByProc(ds
                                    , ds.tblEmpType.TableName
                                    , "p_GetAlltblEmpType"
                                    , Provider.CreateParameter_StringList("dtEmpID", empID));

            Provider.LoadDataByProc(ds
                                    , ds.tbDangKyCaLam.TableName
                                    , "p_getDangKyCaLam_ByStrEmp_Fake"
                                    , new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay))
                                    , new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(tuNgay))
                                    , Provider.CreateParameter_StringList("dtEmpID", empID));

            Provider.LoadData(ds, ds.tblRef_LeaveType.TableName);

            Provider.LoadDataByProc(ds
                                    , ds.tbDuLieuQuetThe.TableName
                                    , "p_duLieuQuetThe_GetAllDuLieuQuetThe_ByStrEmp"
                                    , new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay))
                                    , new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(tuNgay.AddDays(1)))
                                    , Provider.CreateParameter_StringList("dtEmpID", empID));


            Provider.LoadDataByProc(ds
                                    , ds.tbRequestEditAttendane.TableName
                                    , "p_GetAlltbRequestEditAttendane_ByStrEmp"
                                    , new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay))
                                    , new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(tuNgay.AddDays(1)))
                                    , Provider.CreateParameter_StringList("dtEmpID", empID));


            Provider.LoadDataByProc(ds
                                    , ds.tbRequestOverTime.TableName
                                    , "p_GetAlltbRequestOvertime_ByStrEmp"
                                    , new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay))
                                    , new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(tuNgay.AddDays(1)))
                                    , Provider.CreateParameter_StringList("dtEmpID", empID));

            Provider.LoadDataByProc(ds
                                    , ds.tbRequestOutInShift.TableName
                                    , "p_GetAlltbRequestOutInShift_ByStrEmp"
                                    , new SqlParameter("tuNgay", Common.DungChung.Ham.GetTuNgay(tuNgay))
                                    , new SqlParameter("denNgay", Common.DungChung.Ham.GetDenNgay(tuNgay.AddDays(1)))
                                    , Provider.CreateParameter_StringList("dtEmpID", empID));

            #endregion

            var calam = ds.tbCaLamViec.SingleOrDefault(i => i.id == kq.idCaLam);

            bool isT7LamSang = calam.IsT7LamSangNull() ? false : calam.T7LamSang;
            if (!kq.IsisDkTuGioDenGioNull() && kq.isDkTuGioDenGio)
            {
                calam.caDem = kq.isCaDem;
                calam.caSang_tuGio = kq.CaSang_TuGio;
                calam.caSang_denGio = kq.CaSang_DenGio;
                calam.caChieu_tuGio = kq.CaChieu_TuGio;
                calam.caChieu_denGio = kq.CaChieu_DenGio;
                calam.tuGio = kq.CaSang_TuGio;
            }
            else
            {
                kq.SoTiengTinhCa = calam.soTiengTinhCa;
            }
            double tongphutT7 = 0; //phước add 29/03/2019
            TimeSpan calam_tuGio_4check = calam.caSang_tuGio, calam_denGio_4check = calam.caChieu_denGio;
            double soTiengTinhCa_4Calc = kq.SoTiengTinhCa;
            if (isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday)
            {
                //phước fix ca làm t7 tới 15h00
                calam_denGio_4check = calam.caSang_denGio;
                tongphutT7 = (calam.caSang_denGio - calam.caSang_tuGio).TotalMinutes;
            }
            kq.is7Hours = false;
            var emp7Hours = ds.tblEmp7hours.Where(p => p.EmployeeID == kq.EmployeeID && p.BeginDate <= kq.ngay && p.EndDate >= kq.ngay).OrderByDescending(p => p.BeginDate).FirstOrDefault();
            if (emp7Hours != null)
            {
                if (emp7Hours.isLate)
                {
                    calam_tuGio_4check = calam_tuGio_4check.Add(new TimeSpan(1, 0, 0));
                }
                else
                {
                    calam_denGio_4check = calam_denGio_4check.Add(new TimeSpan(-1, 0, 0));
                }
                soTiengTinhCa_4Calc = soTiengTinhCa_4Calc - 1;
                kq.is7Hours = true;
            }

            var vm = ds.tblEmpDayOff.Where(p => p.FromDate <= kq.ngay.Date && p.ToDate >= kq.ngay.Date && p.EmployeeID == kq.EmployeeID).FirstOrDefault();

            double totalMinutes = soTiengTinhCa_4Calc * 60;
            if (isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday && vm != null)
            {
                vm.PerTimeID = 3;
            }
            double DeductTime = 0;
            TimeSpan? tgQuetDen_kq = null;
            TimeSpan? tgQuetVe_kq = null;

            #region check lễ tết
            bool laNgayPhepNam = false;
            if (vm != null && (vm.LeaveID == "NKT" || vm.LeaveID == "NCO" || vm.LeaveID == "NST" || vm.LeaveID == "NDS"))// Jun sửa lại nghỉ có bảo hiểm 2019/01/10 11:44 AM 
            {
                laNgayPhepNam = false;
            }
            else
            {
                laNgayPhepNam = (!kq.IsdkLamThemNull() && kq.tt_leTet == true); // A trong sửa dklamthem = 3 thành kq.tt_leTet == true 28/02/2018
            }
            #endregion

            #region check Chủ nhật
            if (kq.ngay.DayOfWeek == DayOfWeek.Sunday) // A Trọng add them xet ngay chủ nhật tt_chuNhat để xét báo cáo. 2019/04/08 01:22 PM
            {
                kq.tt_chuNhat = true;
            }
            else
            {
                kq.tt_chuNhat = false;
            }
            #endregion

            if (!kq.IstgQuetDenNull())
            {
                tgQuetDen_kq = kq.tgQuetDen;
            }
            if (!kq.IstgQuetVeNull())
            {
                tgQuetVe_kq = kq.tgQuetVe;
            }

            #region Set lại giờ ra vào nếu đăng ký isTinhCong = true.
            bool isNghiPhepTinhCong = false;
            if (vm != null)
            {
                TimeSpan CL_caSangTuGio, CL_caSangDenGio, CL_caChieuTuGio, CL_caChieuDenGio;
                CL_caSangTuGio = calam.caSang_tuGio;
                CL_caSangDenGio = calam.caSang_denGio;
                CL_caChieuTuGio = calam.caChieu_tuGio;
                CL_caChieuDenGio = calam.caChieu_denGio;

                var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                if (leaveType != null && !leaveType.IsisTinhCongNull() && leaveType.isTinhCong && kq.IsdkLamThemNull())
                {
                    if (vm.PerTimeID == 1)
                    {
                        kq.tgQuetDen = calam.caSang_tuGio;

                        if (CL_caSangDenGio < CL_caSangTuGio)
                        {
                            CL_caSangDenGio = CL_caSangDenGio.Add(new TimeSpan(1, 0, 0, 0));
                        }
                        if (!kq.IstgQuetVeNull())
                        {
                            if (kq.tgQuetVe > CL_caSangTuGio && kq.tgQuetVe < CL_caSangDenGio)
                            {
                                kq.tgQuetVe = calam.caSang_denGio;
                            }
                        }
                        else
                        {
                            kq.tgQuetVe = calam.caSang_denGio;
                        }
                    }
                    else if (vm.PerTimeID == 2)
                    {
                        kq.tgQuetVe = calam.caChieu_denGio;

                        if (CL_caChieuDenGio < CL_caChieuTuGio)
                        {
                            CL_caChieuDenGio = CL_caChieuDenGio.Add(new TimeSpan(1, 0, 0, 0));
                        }
                        if (!kq.IstgQuetDenNull())
                        {
                            if (kq.tgQuetDen > CL_caChieuTuGio && kq.tgQuetDen < CL_caChieuDenGio)
                            {
                                kq.tgQuetDen = calam.caChieu_denGio;
                            }
                        }
                        else
                        {
                            kq.tgQuetDen = calam.caChieu_tuGio;
                        }
                    }
                    else
                    {
                        kq["tgQuetDen"] = calam.caSang_tuGio;
                        kq["tgQuetVe"] = calam.caChieu_denGio;
                        if (isKhongCanQuetThe)
                        {
                            tgQuetVe_kq = null;
                            tgQuetDen_kq = null;
                        }
                    }
                    isNghiPhepTinhCong = true;
                }
            }
            #endregion

            #region Nếu là ca đêm
            if (calam.caDem)
            {
                #region check nghỉ phép
                int nghiCaNgay = 10;
                double tongPhepDenHienTai = 0;
                tongPhepDenHienTai = getTongPhepDenHienTai(db, ds, tuNgay, new DateTime(kq.ngay.Year, 12, 31), kq.EmployeeID);
                if (vm != null && kq.IsdkLamThemNull())//&&!kq.tt_chuNhat
                {
                    double soPhepDK = vm.PerTimeID == 3 ? 1 : 0.5;

                    if (tongPhepDenHienTai < soPhepDK && vm.LeaveID == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam]) // Nếu đăng ký là phép năm và không đủ phép -> Chuyển sang KL. --- Thong Lieu cập nhật 04-01-2018
                    {
                        vm.LeaveID = "P";
                    }

                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (vm.PerTimeID != 3)
                    {
                        if (leaveType != null && (leaveType.IsisTinhCongNull() || !leaveType.isTinhCong) && leaveType.SalaryRate > 0)
                        {
                            kq.daysOfNghiCoLuong = 0.5;
                        }
                        if (vm.PerTimeID == 2)
                        {
                            kq.tt_nghiPhep = 1;
                            kq.tgTinhTangCa = 0;
                            nghiCaNgay = vm.PerTimeID;
                        }
                        else if (vm.PerTimeID == 1)
                        {
                            kq.tt_nghiPhep = 1;
                            nghiCaNgay = vm.PerTimeID;
                        }
                    }
                    else
                    {
                        if (leaveType != null && (leaveType.IsisTinhCongNull() || !leaveType.isTinhCong) && leaveType.SalaryRate > 0)
                        {
                            kq.daysOfNghiCoLuong = 1;
                        }
                        kq.tt_nghiPhep = 1;
                        kq.kqNgayCong = 0;
                        nghiCaNgay = vm.PerTimeID;
                        kq.tgTinhTangCa = 0;
                        if (isKhongCanQuetThe)
                        {
                            tgQuetVe_kq = null;
                            tgQuetDen_kq = null;
                        }
                    }
                }

                if (nghiCaNgay != 10 && kq.IsdkLamThemNull())
                {
                    kq.PerTimeID = vm.PerTimeID;
                    kq.LeaveID = vm.LeaveID;
                    kq.tt_nghiPhep_Alias = vm.LeaveID;
                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (leaveType != null && leaveType.isTinhCong == true)
                    {
                        kq.tt_nghiPhep = 0;
                    }
                }



                #endregion

                #region check vào
                if (kq["tgQuetDen"] != DBNull.Value)
                {
                    kq.tgDiMuon = (int)(new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0) - calam.tuGio).TotalMinutes;
                }
                #endregion

                #region check ra

                kq.tgTinhTangCa = 0;
                double NightOT = 0, NormalOT = 0, NightOTLess24 = 0;
                int CountOTMore4h = 0;
                if (kq["tgQuetVe"] != DBNull.Value)
                {
                    tgQuetVe_kq = kq.tgQuetVe;
                    if (kq.tgQuetVe > calam.tuGio) // Nếu về lúc tối . calam.TuGio là đúng.
                    {
                        if (isCaDemTrongNgay)
                        {
                            kq.tgVeSom = (int)(new TimeSpan(24, 0, 0) - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes + (int)(calam_denGio_4check - new TimeSpan(0, 0, 0)).TotalMinutes;
                        }
                        else
                        {
                            if (isCaDemTrongNgay)
                            {
                                kq.tgVeSom = (int)(new TimeSpan(24, 0, 0) - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes + (int)(calam_denGio_4check - new TimeSpan(0, 0, 0)).TotalMinutes;
                            }
                            else
                            {
                                kq.tgVeSom = (int)((new TimeSpan(0, calam_denGio_4check.Hours, calam_denGio_4check.Minutes, calam_denGio_4check.Seconds)) - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes;
                            }
                        }
                    }
                    else // Nếu về lúc đêm hoặc sáng hsau.
                    {
                        kq.tgVeSom = (int)((new TimeSpan(0, calam_denGio_4check.Hours, calam_denGio_4check.Minutes, calam_denGio_4check.Seconds)) - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes;
                    }
                }
                #endregion

                #region Tăng ca

                if (!kq.IstgQuetVeNull() && !kq.IstgQuetDenNull() && !isNotOT)
                { // Check xem tăng ca đã được accept chưa.
                    TimeSpan? tgcheckhomsau = new TimeSpan(calam.caChieu_denGio.Hours, calam.caChieu_denGio.Minutes + calam.tgQuetSau_Ra, calam.caChieu_denGio.Milliseconds);
                    TimeSpan? tgchecktruoc = new TimeSpan(calam.caSang_tuGio.Hours, calam.caSang_tuGio.Minutes - calam.tgQuetTruoc_Vao, calam.caSang_tuGio.Milliseconds);
                    DateTime ngaymai = kq.ngay.AddDays(1);
                    DateTime ngaynay = kq.ngay;
                    var ot = ds.tbRequestOverTime.Where(p => p.EmployeeID == kq.EmployeeID && p.ngay == kq.ngay && p.isAccept); // Phước add 06/03/2019

                    if (ot == null)
                    {
                        kq.tgTinhTangCa = 0;
                    }
                    else
                    {

                        //phước add thêm =2019-01-08 
                        int tgChoPhepTC = 0;
                        DateTime ngaytangca = kq.ngay;
                        DateTime ngaytangcaden = kq.ngay.AddDays(1);
                        foreach (var dr in ot)
                        {
                            //duyệt danh sách các đăng ký của nhân viên đó trong ngày đó
                            TimeSpan timeTuGio = dr.tuGio;
                            TimeSpan timeDenGio = dr.denGio;//thoigian dang ky
                            TimeSpan timeQuetDen = kq.tgQuetDen;
                            TimeSpan timeQuetVe = kq.tgQuetVe;
                            TimeSpan timeCalamTuGio = calam.caSang_tuGio;
                            TimeSpan timeCalamDenGio = calam.caChieu_denGio;
                            DateTime ngayDK = dr.ngay;

                            if (timeTuGio >= tgchecktruoc && timeTuGio <= timeCalamTuGio)
                            {
                                GetOTHoursBeforeAndInShiftRequestOT(calam, kq, dr);
                            }

                            if (timeTuGio <= new TimeSpan(24, 0, 0) && calam.caSang_denGio <= timeTuGio && calam.caSang_denGio > timeCalamTuGio)
                            {

                                GetOTHoursBeforeAndInShiftRequestOT(calam, kq, dr);
                            }
                            if (timeTuGio >= new TimeSpan(0, 0, 0) && timeTuGio < timeCalamDenGio)
                            {
                                GetOTHoursBeforeAndInShiftRequestOT(calam, kq, dr);
                            }

                            #region Đăng ký tăng sau ca làm
                            //đang ký tăng ca sau giờ làm
                            if (timeTuGio <= tgcheckhomsau && timeTuGio >= timeCalamDenGio && timeTuGio < kq.tgQuetVe)//&& ngayDK.Date == ngaymai
                            {
                                TimeSpan tgBatDauTinhTC = timeTuGio;

                                if (timeDenGio > kq.tgQuetVe) // Jun sửa lại 2019/01/10 3:13 PM
                                {
                                    timeDenGio = kq.tgQuetVe;
                                }
                                if (timeTuGio >= kq.tgQuetVe)
                                {
                                    timeTuGio = timeDenGio = kq.tgQuetVe;
                                }

                                if (tgBatDauTinhTC >= timeDenGio)
                                {
                                    tgChoPhepTC += (int)(tgBatDauTinhTC.Add(new TimeSpan(24, 0, 0)) - timeDenGio).TotalMinutes;
                                }
                                else
                                {
                                    tgChoPhepTC += (int)(timeDenGio - tgBatDauTinhTC).TotalMinutes;
                                }

        
                                GetOTHours(kq, timeTuGio, timeDenGio, ref NightOT, ref NormalOT, ref NightOTLess24, ref CountOTMore4h);
                                kq.OTMore4h += CountOTMore4h;

                                if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm.
                                {
                                    int CountOTMore8h = 0;
                                    GetOTHours(kq, timeTuGio, timeDenGio, ref CountOTMore8h);
                                    kq.OTMore8h = kq.OTMore8h + CountOTMore8h;
                                }
                            }
                            #endregion

                        }

                        kq.tgTinhTangCa -= soTiengTCTN;

                        if (kq.tgTinhTangCa <= 0)
                            kq.tgTinhTangCa = 0;


                        kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, (float)tgChoPhepTC / 60);



                    }

                    // tăng ca theo ca đêm
                    if (calam.soTiengTinhTangCa > 0 && emp7Hours == null && !isCaDemTrongNgay)
                    {
                        int SoPhutTC = Convert.ToInt32(Convert.ToDouble(calam.soTiengTinhTangCa) * 60);

                        TimeSpan timeTuGio = calam.caChieu_denGio;
                        TimeSpan timeDenGio = new TimeSpan(timeTuGio.Hours, timeTuGio.Minutes + SoPhutTC, timeTuGio.Seconds); // add thêm soTiengTinhTangCa                   

                        TimeSpan timeCalamTuGio = calam.caSang_tuGio;
                        TimeSpan timeCalamDenGio = calam.caChieu_denGio;
                        DateTime ngayDK = kq.ngay;
                        int tgChoPhepTC = 0;

                        if (!kq.IstgQuetDenNull() && !kq.IstgQuetVeNull() && kq.tgQuetVe > timeTuGio)
                        {
                            if (timeTuGio >= timeDenGio)
                            {
                                tgChoPhepTC += (int)(timeTuGio.Add(new TimeSpan(24, 0, 0)) - timeDenGio).TotalMinutes;
                            }
                            else
                            {
                                if (timeDenGio > kq.tgQuetVe)
                                {
                                    timeDenGio = kq.tgQuetVe;
                                }

                                tgChoPhepTC += (int)(timeDenGio - timeTuGio).TotalMinutes;
                            }
                            GetOTHours(kq, timeTuGio, timeDenGio, ref NightOT, ref NormalOT, ref NightOTLess24, ref CountOTMore4h);
                            kq.OTMore4h += CountOTMore4h;

                        }

                        if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm.
                        {
                            int CountOTMore8h = 0;
                            GetOTHours(kq, timeTuGio, timeDenGio, ref CountOTMore8h);
                            kq.OTMore8h = kq.OTMore8h + CountOTMore8h;
                        }

                        kq.tgTinhTangCa -= soTiengTCTN;

                        if (kq.tgTinhTangCa <= 0)
                            kq.tgTinhTangCa = 0;
                        kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, (float)tgChoPhepTC / 60);
                    }




                }
                #endregion

                #region Ra vào giữa ca
                // Nếu có đăng ký ra vào giữa ca
                double NormalOIS = 0;
                double NightOIS = 0;
                var rqRequestOutInShift = ds.tbRequestOutInShift.Where(p => p.EmployeeID == kq.EmployeeID && p.ngay == kq.ngay && p.isAccept);
                if (rqRequestOutInShift.Count() > 0)
                {
                    foreach (var item in rqRequestOutInShift)
                    {
                        GetOISHours(kq, item.tuGio, item.denGio, ref NormalOIS, ref NightOIS);
                    }
                }

                kq.NormalOISDay = roundSQL(NormalOIS / 60, 2, false);
                kq.NightOISDay = roundSQL(NightOIS / 60, 2, false);

                #endregion

                #region check có đi làm (quẹt tay) hay ko
                kq.tt_coQuetTay = (kq["tgQuetDen"] != DBNull.Value ? 1 : 0) + (kq["tgQuetVe"] != DBNull.Value ? 2 : 0);
                #endregion

                #region check di muon ve som
                if (kq.tt_coQuetTay == 3)
                {
                    kq.tt_ok = 1;
                    if (kq.tgDiMuon > 0)
                    {
                        kq.tt_diMuonVeSom = 1;
                        if (kq.tgDiMuon > 0)
                        {
                            DeductTime += kq.tgDiMuon;
                        }
                    }
                    if (kq.tgVeSom > 0)
                    {
                        kq.tt_diMuonVeSom += 2;
                        if (kq.tgVeSom > 0)
                        {
                            DeductTime += kq.tgVeSom;
                        }
                    }
                    kq.WorkingHours = roundSQL((totalMinutes - DeductTime) / 60, 2, true) > 0 ? roundSQL((totalMinutes - DeductTime) / 60, 2, true) : 0;
                    kq.kqNgayCong = roundSQL(kq.WorkingHours * 60 / totalMinutes, 2, false);

                    kq.kqNgayCong = Math.Max(kq.kqNgayCong, 0);
                    if (kq.kqNgayCong == 0)
                    {
                        kq.tgTinhTangCa = 0;
                    }
                }
                else
                {
                    kq.tt_ok = 0;
                    kq.kqNgayCong = 0;
                    kq.tgTinhTangCa = 0;
                }
                if ((kq.tt_coQuetTay != 3 || kq.kqNgayCong == 0) && !laNgayPhepNam)// Những trường hợp công = 0 thì cho KP để tính lương. A trọng yêu cầu
                {
                    if (nghiCaNgay == 10) // Nếu băng 10 thì nghĩa là không đăng ký phép.
                    {
                        kq.tt_nghiPhep_Alias = kq.LeaveID = "KP";
                        kq.tt_nghiPhep = 0;
                        kq.PerTimeID = 3;
                    }
                    kq.tgTinhTangCa = 0;
                }

                tinhLaiTgDiMuonVeSom(ds, kq, calam);
                if (tgQuetDen_kq != null)
                {
                    kq.tgQuetDen = tgQuetDen_kq.Value;
                }
                if (tgQuetVe_kq != null)
                {
                    kq.tgQuetVe = tgQuetVe_kq.Value;
                }
                #endregion

                if (vm != null && kq.tt_leTet)
                {
                    var bh = db.tblRef_LeaveTypes.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (bh.IsInsurance == true)
                    {
                        kq.PerTimeID = vm.PerTimeID;
                        kq.LeaveID = vm.LeaveID;
                        kq.tt_nghiPhep_Alias = vm.LeaveID;
                        kq.tt_nghiPhep = 1;

                        kq.tt_leTet = false;
                        kq["dkLamThem"] = DBNull.Value;
                        kq["isAutomatic"] = DBNull.Value;
                    }
                }
                //Ca ngày : 06:00 - 22:00.
                //Ca đêm: 22:01 - 05:59
                #region update NightOT, NormalOT, tgTinhTangCa
                kq.NightOT = roundSQL(NightOT, 2, false);
                kq.NightOTLess24 = NightOTLess24;
                kq.NormalOT = roundSQL(NormalOT, 2, false);
                kq.tgTinhTangCa = kq.NightOT + kq.NormalOT;
                #region update NightDay , NightOT cũ
                double NightDay = 0;

                // NightDay
                if (!kq.IskqNgayCongNull() && kq.kqNgayCong > 0 && (kq.tgQuetVe >= new TimeSpan(22, 0, 0) || kq.tgQuetVe < new TimeSpan(22, 0, 0)))
                {
                    TimeSpan tgQuetDen = new TimeSpan();
                    TimeSpan tgQuetVe = new TimeSpan();
                    if (kq.tgQuetDen <= new TimeSpan(22, 0, 0) && kq.tgQuetDen >= new TimeSpan(17, 0, 0))
                    {
                        // Vì ca làm bắt đầu có thể lớn hơn 22h. Không thể set cứng là 22h được. Tính nightDay sẽ lớn hơn. Sửa ngày 11/02.
                        if (calam.caSang_tuGio > new TimeSpan(22, 0, 0))
                        {
                            tgQuetDen = calam.caSang_tuGio;
                        }
                        else
                        {
                            tgQuetDen = new TimeSpan(22, 0, 0);
                        }
                    }
                    else
                    {
                        if (calam.caSang_tuGio >= new TimeSpan(22, 0, 0))
                        {
                            if (kq.tgQuetDen <= calam.caSang_tuGio)
                            {
                                tgQuetDen = calam.caSang_tuGio;
                            }
                            else
                            {
                                tgQuetDen = kq.tgQuetDen;
                            }
                        }
                        else
                        {
                            tgQuetDen = kq.tgQuetDen;
                        }
                    }

                    if (kq.tgQuetVe >= new TimeSpan(22, 0, 0))
                    {
                        tgQuetVe = kq.tgQuetVe;
                    }
                    else
                    {
                        if (kq.tgQuetVe >= new TimeSpan(6, 0, 0) && !isCaDemTrongNgay)
                        {
                            tgQuetVe = new TimeSpan(6, 0, 0);
                        }
                        else
                        {
                            tgQuetVe = kq.tgQuetVe;
                        }
                    }
                    //Tính toán
                    if (tgQuetVe <= new TimeSpan(24, 0, 0) && tgQuetVe >= new TimeSpan(10, 0, 0))
                    {
                        if (tgQuetVe < new TimeSpan(22, 0, 0) && isCaDemTrongNgay)
                        {
                            NightDay += 0;
                        }
                        else
                        {
                            NightDay += (tgQuetVe - tgQuetDen).TotalMinutes / (kq.SoTiengTinhCa * 60);
                        }

                    }
                    else
                    {
                        if (tgQuetDen <= new TimeSpan(24, 0, 0) && tgQuetDen >= new TimeSpan(10, 0, 0))
                        {
                            if (tgQuetDen < calam.caSang_tuGio)
                            {
                                tgQuetDen = new TimeSpan(22, 0, 0);
                            }
                            if (tgQuetVe > calam.caChieu_denGio)
                            {
                                tgQuetVe = calam.caChieu_denGio;
                            }
                            NightDay += (tgQuetVe.Add(new TimeSpan(24, 0, 0)) - tgQuetDen).TotalMinutes / (kq.SoTiengTinhCa * 60);
                        }
                        else
                        {
                            if (kq.idCaLam == Guid.Parse("BE478C1D-7450-44AB-9EA3-F537122A913C") && tgQuetVe > calam.caChieu_denGio)// Xử lý trường hợp ca làm 2h sáng. nhưng lại quẹt 4h sáng.
                            {
                                tgQuetVe = calam.caChieu_denGio;
                            }
                            if (tgQuetVe < tgQuetDen) // Xử lý trường hợp làm từ 9h sáng đến 4h sáng hsau.
                            {
                                if (tgQuetDen <= new TimeSpan(22, 0, 0))
                                {
                                    tgQuetDen = new TimeSpan(22, 0, 0);
                                }
                                if (tgQuetVe >= new TimeSpan(6, 0, 0))
                                {
                                    tgQuetVe = new TimeSpan(6, 0, 0).Add(new TimeSpan(24, 0, 0));
                                }
                                else
                                {
                                    tgQuetVe = tgQuetVe.Add(new TimeSpan(24, 0, 0));
                                }
                            }
                            NightDay += (tgQuetVe - tgQuetDen).TotalMinutes / (kq.SoTiengTinhCa * 60);
                        }
                    }
                }
                kq.NightDay = NightDay;
                kq.NormalDay = 0;
                kq.NormalDay = kq.kqNgayCong - kq.NightDay;
                #endregion
                #endregion

                #region check error
                kq.tt_error = 0;

                #endregion

                kq.statePushServer = "edited";
                kq.analyzeDate = DateTime.Now;
                //kq.analyzeBy = UserDoing.id;
            }
            #endregion

            #region Nếu là ca ngày
            else // Nếu là ca ngày, sáng, chiều, hành chính.
            {
                #region check nghỉ phép
                int nghiCaNgay = 10;
                double tongPhepDenHienTai = 0;
                tongPhepDenHienTai = getTongPhepDenHienTai(db, ds, tuNgay, new DateTime(kq.ngay.Year, 12, 31), kq.EmployeeID);
                if (vm != null && kq.IsdkLamThemNull())//&&!kq.tt_chuNhat
                {
                    double soPhepDK = vm.PerTimeID == 3 ? 1 : 0.5;
                    if ((tongPhepDenHienTai < soPhepDK && vm.LeaveID == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam])) // Nếu đăng ký là phép năm và không đủ phép -> Chuyển sang KL.
                    {
                        vm.LeaveID = "P";
                    }
                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (vm.PerTimeID != 3)
                    {
                        if (leaveType != null && (leaveType.IsisTinhCongNull() || !leaveType.isTinhCong) && leaveType.SalaryRate > 0)
                        {
                            kq.daysOfNghiCoLuong = 0.5;
                        }
                        if (vm.PerTimeID == 2)
                        {
                            kq.tt_nghiPhep = 1;
                            kq.tgTinhTangCa = 0;
                            nghiCaNgay = vm.PerTimeID;
                        }
                        else if (vm.PerTimeID == 1)
                        {
                            kq.tt_nghiPhep = 1;
                            nghiCaNgay = vm.PerTimeID;
                        }
                    }
                    else
                    {
                        if (leaveType != null && (leaveType.IsisTinhCongNull() || !leaveType.isTinhCong) && leaveType.SalaryRate > 0)
                        {
                            kq.daysOfNghiCoLuong = 1;
                        }
                        kq.tt_nghiPhep = 1;
                        kq.kqNgayCong = 0;
                        nghiCaNgay = vm.PerTimeID;
                        kq.tgTinhTangCa = 0;
                        if (isKhongCanQuetThe)
                        {
                            tgQuetVe_kq = null;
                            tgQuetDen_kq = null;
                        }
                    }
                }

                if (nghiCaNgay != 10 && kq.IsdkLamThemNull())
                {
                    kq.PerTimeID = vm.PerTimeID;
                    kq.LeaveID = vm.LeaveID;
                    kq.tt_nghiPhep_Alias = vm.LeaveID;
                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (leaveType != null && leaveType.isTinhCong == true)
                    {
                        kq.tt_nghiPhep = 0;
                    }
                }



                #endregion

                #region check vào
                #region tính tg đi muộn dựa vào tgQuetDen và ca xin nghỉ
                if (kq["tgQuetDen"] != DBNull.Value)
                {
                    kq.tgDiMuon = (int)(new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0) - calam_tuGio_4check).TotalMinutes;

                    if (kq.tgQuetDen > calam.caSang_denGio) //kiểm tra muộn qua h nghỉ trưa thì trừ
                        kq.tgDiMuon -= (int)(Math.Min(kq.tgQuetDen.TotalMinutes, calam.caChieu_tuGio.TotalMinutes) - calam.caSang_denGio.TotalMinutes);
                }
                #endregion
                #endregion

                #region check ra
                kq.tgTinhTangCa = 0;
                double NightOT = 0, NormalOT = 0, NightOTLess24 = 0;
                int CountOTMore4h = 0;
                if (kq["tgQuetVe"] != DBNull.Value)
                {
                    if (new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0) > calam_tuGio_4check)
                    {
                        kq.tgVeSom = (int)(calam_denGio_4check - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes;
                    }
                    else
                    {
                        kq.tgVeSom = (int)(calam_denGio_4check - calam_tuGio_4check).TotalMinutes;
                    }
                    if (kq.ngay.DayOfWeek == DayOfWeek.Saturday && !calam.IsT7LamSangNull() && calam.T7LamSang)
                    {
                        // Khong lam gi ca.
                    }
                    else
                    {
                        if (kq.tgQuetVe < calam.caChieu_tuGio) //kiểm tra sớm trước h nghỉ trưa thì trừ
                            kq.tgVeSom -= (int)(calam.caChieu_tuGio.TotalMinutes - Math.Max(kq.tgQuetVe.TotalMinutes, calam.caSang_denGio.TotalMinutes));
                    }
                }
                #endregion

                setTGQuetDuaVaoVangMat(kq, calam, calam_denGio_4check, isNghiPhepTinhCong);

                #region Tăng ca
                //&& !(isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday)
                if (!kq.IstgQuetVeNull() && !kq.IstgQuetDenNull() && !isNotOT) // T7 làm sáng không có tăng ca. // add thêm  kq.tgVeSom <= -15  ====> !kq.IstgQuetDenNull()
                {
                    // tăng ca nhiều lần
                    var ot = ds.tbRequestOverTime.Where(p => p.EmployeeID == kq.EmployeeID && p.ngay == kq.ngay && p.isAccept);

                    if (ot == null)
                    {
                        kq.tgTinhTangCa = 0;
                    }
                    else
                    {
                        int tgChoPhepTC = 0;

                        foreach (var dr in ot)
                        {
                            TimeSpan timeTuGio = dr.tuGio;
                            TimeSpan timeDenGio = dr.denGio;

                            if (timeDenGio <= calam.caSang_tuGio) // đăng ký tăng ca trước
                            {
                                GetOTHoursBeforeAndInShiftRequestOT(calam, kq, dr);
                            }
                            if (calam.caSang_denGio <= timeTuGio && calam.caChieu_tuGio >= timeDenGio)//đang ký tăng ca giữa giờ
                            {
                                GetOTHoursBeforeAndInShiftRequestOT(calam, kq, dr);
                            }

                            #region Tăng ca sau ca làm

                            if (timeTuGio >= calam_denGio_4check && emp7Hours == null) //đăng ký tăng ca sau ca làm
                            {

                                TimeSpan tgBatDauTinhTC = timeTuGio;      // này là thời gian ca làm                   

                                if (timeDenGio > kq.tgQuetVe)
                                {
                                    timeDenGio = kq.tgQuetVe;
                                }
                                if (timeTuGio >= kq.tgQuetVe)
                                {
                                    timeTuGio = timeDenGio = kq.tgQuetVe;
                                }
                                if (tgBatDauTinhTC >= timeDenGio)
                                {
                                    tgChoPhepTC += (int)(tgBatDauTinhTC.Add(new TimeSpan(24, 0, 0)) - timeDenGio).TotalMinutes;
                                }
                                else
                                {
                                    tgChoPhepTC += (int)(timeDenGio - tgBatDauTinhTC).TotalMinutes;
                                }

                                GetOTHours(kq, timeTuGio, timeDenGio, ref NightOT, ref NormalOT, ref NightOTLess24, ref CountOTMore4h);
                                kq.OTMore4h += CountOTMore4h;

                                if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm.
                                {
                                    int CountOTMore8h = 0;

                                    GetOTHours(kq, timeTuGio, timeDenGio, ref CountOTMore8h);
                                    kq.OTMore8h = kq.OTMore8h + CountOTMore8h;
                                }
                            }
                            #endregion
                        }

                        kq.tgTinhTangCa -= soTiengTCTN;

                        if (kq.tgTinhTangCa <= 0)
                            kq.tgTinhTangCa = 0;
                        kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, (float)tgChoPhepTC / 60);
                    }

                }

                //tăng ca theo ca ngày
                if (calam.soTiengTinhTangCa > 0 && emp7Hours == null)
                {

                    int SoPhutTC = Convert.ToInt32(Convert.ToDouble(calam.soTiengTinhTangCa) * 60);

                    TimeSpan timeTuGio = calam.caChieu_denGio;
                    TimeSpan timeDenGio = new TimeSpan(timeTuGio.Hours, timeTuGio.Minutes + SoPhutTC, timeTuGio.Seconds); // add thêm soTiengTinhTangCa                   

                    TimeSpan timeCalamTuGio = calam.caSang_tuGio;
                    TimeSpan timeCalamDenGio = calam.caChieu_denGio;
                    DateTime ngayDK = kq.ngay;
                    int tgChoPhepTC = 0;
                    if (!kq.IstgQuetDenNull() && !kq.IstgQuetVeNull() && kq.tgQuetVe > timeTuGio)
                    {
                        if (timeTuGio >= timeDenGio)
                        {
                            tgChoPhepTC += (int)(timeTuGio.Add(new TimeSpan(24, 0, 0)) - timeDenGio).TotalMinutes;
                        }
                        else
                        {
                            if (timeDenGio > kq.tgQuetVe)
                            {
                                timeDenGio = kq.tgQuetVe;
                            }
                            tgChoPhepTC += (int)(timeDenGio - timeTuGio).TotalMinutes;
                        }

                        GetOTHours(kq, timeTuGio, timeDenGio, ref NightOT, ref NormalOT, ref NightOTLess24, ref CountOTMore4h);
                        kq.OTMore4h += CountOTMore4h;
                    }
                    if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm.
                    {
                        int CountOTMore8h = 0;

                        GetOTHours(kq, timeTuGio, timeDenGio, ref CountOTMore8h);
                        kq.OTMore8h = kq.OTMore8h + CountOTMore8h;
                    }
                    kq.tgTinhTangCa -= soTiengTCTN;

                    if (kq.tgTinhTangCa <= 0)
                        kq.tgTinhTangCa = 0;
                    kq.tgTinhTangCa = Math.Min(kq.tgTinhTangCa, (float)tgChoPhepTC / 60);
                }

                #endregion

                #region Ra vào giữa ca
                // Nếu có đăng ký ra vào giữa ca
                double NormalOIS = 0;
                double NightOIS = 0;
                var rqRequestOutInShift = ds.tbRequestOutInShift.Where(p => p.EmployeeID == kq.EmployeeID && p.ngay == kq.ngay && p.isAccept);
                if (rqRequestOutInShift.Count() > 0)
                {
                    foreach (var item in rqRequestOutInShift)
                    {
                        GetOISHours(kq, item.tuGio, item.denGio, ref NormalOIS, ref NightOIS);
                    }
                }

                kq.NormalOISDay = roundSQL(NormalOIS / 60, 2, false);
                kq.NightOISDay = roundSQL(NightOIS / 60, 2, false);

                #endregion

                #region check có đi làm (quẹt tay) hay ko
                kq.tt_coQuetTay = (kq["tgQuetDen"] != DBNull.Value ? 1 : 0) + (kq["tgQuetVe"] != DBNull.Value ? 2 : 0);
                #endregion

                #region check di muon ve som và tính kqNgayCong
                if (kq.tt_coQuetTay == 3)
                {
                    kq.tt_ok = 1;
                    if (kq.tgDiMuon > 0)
                    {
                        kq.tt_diMuonVeSom = 1;
                        if (kq.tgDiMuon > 0)
                        {
                            DeductTime += kq.tgDiMuon;
                        }
                    }
                    if (kq.tgVeSom > 0)
                    {
                        kq.tt_diMuonVeSom += 2;
                        if (kq.tgVeSom > 0)
                        {
                            DeductTime += kq.tgVeSom;
                        }
                    }
                    if (isT7LamSang && kq.ngay.DayOfWeek == DayOfWeek.Saturday) // là t7 làm sáng
                    {
                        // tính lại công này thứ 7
                        kq.WorkingHours = roundSQL((tongphutT7 - DeductTime) / 60, 2, true) > 0 ? roundSQL((tongphutT7 - DeductTime) / 60, 2, true) : 0;
                        //kq.kqNgayCong = roundSQL(kq.WorkingHours * 60 / totalMinutes, 2, false);
                        kq.kqNgayCong = (kq.WorkingHours * 60) / totalMinutes;

                    }
                    else
                    {
                        kq.WorkingHours = roundSQL((totalMinutes - DeductTime) / 60, 2, true) > 0 ? roundSQL((totalMinutes - DeductTime) / 60, 2, true) : 0;
                        kq.kqNgayCong = roundSQL(kq.WorkingHours * 60 / totalMinutes, 2, false);
                    }

                    kq.kqNgayCong = Math.Max(kq.kqNgayCong, 0);
                    if (kq.kqNgayCong == 0)
                    {
                        kq.tgTinhTangCa = 0;
                    }
                }
                else
                {
                    kq.tt_ok = 0;
                    kq.kqNgayCong = 0;
                    kq.tgTinhTangCa = 0;
                }
                #endregion

                if ((kq.tt_coQuetTay != 3 || kq.kqNgayCong == 0) && !laNgayPhepNam) // Những trường hợp công = 0 thì cho KP để tính lương. A trọng yêu cầu
                {
                    if (nghiCaNgay == 10) // Nếu băng 10 thì nghĩa là không đăng ký phép.
                    {
                        kq.tt_nghiPhep_Alias = kq.LeaveID = "KP";
                        kq.tt_nghiPhep = 0;
                        kq.PerTimeID = 3;
                    }
                    kq.tgTinhTangCa = 0;
                }

                tinhLaiTgDiMuonVeSom(ds, kq, calam);
                if (tgQuetDen_kq != null)
                {
                    kq.tgQuetDen = tgQuetDen_kq.Value;
                }
                if (tgQuetVe_kq != null)
                {
                    kq.tgQuetVe = tgQuetVe_kq.Value;
                }
                if (vm != null && kq.tt_leTet)
                {
                    var bh = db.tblRef_LeaveTypes.Where(p => p.LeaveID == vm.LeaveID).FirstOrDefault();
                    if (bh.IsInsurance == true)
                    {
                        kq.PerTimeID = vm.PerTimeID;
                        kq.LeaveID = vm.LeaveID;
                        kq.tt_nghiPhep_Alias = vm.LeaveID;
                        kq.tt_nghiPhep = 1;

                        kq.tt_leTet = false;
                        kq["dkLamThem"] = DBNull.Value;
                        kq["isAutomatic"] = DBNull.Value;
                    }
                }
                //Ca ngày : 06:00 - 22:00.
                //Ca đêm: 22:01 - 05:59
                #region update NightOT, NormalOT, tgTinhTangCa
                kq.NightOT = roundSQL(NightOT, 2, false);
                kq.NormalOT = roundSQL(NormalOT, 2, false);
                kq.NightOTLess24 = NightOTLess24;
                kq.tgTinhTangCa = kq.NightOT + kq.NormalOT;

                //Phước fix ngày 29-10-2018 note: code cũ bị thiếu
                #region update NightDay , NormalDay

                double NightDay = 0;
                if (!kq.IskqNgayCongNull() && kq.kqNgayCong > 0 && (kq.tgQuetVe >= new TimeSpan(22, 0, 0) || kq.tgQuetVe <= new TimeSpan(24, 0, 0)))
                {
                    //gán lại thời gian quẹt thẻ ra vào
                    TimeSpan tgQuetDen = new TimeSpan();
                    TimeSpan tgQuetVe = new TimeSpan();
                    if (kq.tgQuetDen <= new TimeSpan(22, 0, 0) && kq.tgQuetDen >= new TimeSpan(17, 0, 0))
                    {
                        // Vì ca làm bắt đầu có thể lớn hơn 22h. Không thể set cứng là 22h được. Tính nightDay sẽ lớn hơn. Sửa ngày 11/02.
                        if (calam.caSang_tuGio > new TimeSpan(22, 0, 0))
                        {
                            tgQuetDen = calam.caSang_tuGio;
                        }
                        else
                        {
                            tgQuetDen = new TimeSpan(22, 0, 0);
                        }
                    }
                    else
                    {
                        tgQuetDen = kq.tgQuetDen;
                    }

                    if (kq.tgQuetVe >= new TimeSpan(22, 0, 0))
                    {
                        tgQuetVe = kq.tgQuetVe;
                    }
                    else
                    {
                        tgQuetVe = new TimeSpan(22, 0, 0);
                    }
                    //Tính toán
                    if (tgQuetVe <= new TimeSpan(22, 0, 0))
                    {
                        //với thời gian quẹt về từ 10h-22h thì làm thêm đêm bằng 0
                        NightDay = 0;
                    }
                    else
                    {
                        // thời gian quẹt về từ 22h-24h là tính tăng ca
                        if (tgQuetVe <= new TimeSpan(24, 0, 0) && tgQuetVe >= new TimeSpan(22, 0, 0))
                        {
                            if (calam.caChieu_denGio > new TimeSpan(22, 0, 0))
                            {
                                if (tgQuetVe < calam.caChieu_denGio)
                                {
                                    NightDay += (tgQuetVe - new TimeSpan(22, 0, 0)).TotalMinutes / (kq.SoTiengTinhCa * 60);
                                }
                                else
                                {
                                    NightDay += (calam.caChieu_denGio - new TimeSpan(22, 0, 0)).TotalMinutes / (kq.SoTiengTinhCa * 60);
                                }
                            }
                            else
                            {
                                NightDay = 0;
                            }
                        }
                    }
                }
                kq.NightDay = NightDay;
                kq.NormalDay = 0;
                kq.NormalDay = kq.kqNgayCong - kq.NightDay;
                #endregion



                #region update NightDay , NightOT, NormalDay, NormalOT cũ
                //kq.NormalDay = 0;
                //kq.NormalOT = 0;
                //kq.WorkingHours = kq.kqNgayCong * 8;
                //kq.NormalOT = kq.tgTinhTangCa - kq.NightOT;
                #endregion
                #endregion

                #region check error
                kq.tt_error = 0;
                //if (vm != null && kq.tt_coQuetTay == 3)
                //{
                //    if ((kq.tgQuetDen <= vm.tuGio && vm.tuGio < kq.tgQuetVe) || (kq.tgQuetDen < vm.denGio && vm.denGio <= kq.tgQuetVe))
                //    {
                //        kq.tt_error = 1;
                //    }
                //}
                #endregion

                kq.statePushServer = "edited";
                kq.analyzeDate = DateTime.Now;
            }
            #endregion

            if (!kq.IsdkLamThemNull() && !kq.IstgQuetDenNull() && !kq.IstgQuetVeNull()) // Nếu là đăng ký làm thêm. 
            {
                kq.OTMore8h = kq.OTMore8h + (int)((kq.kqNgayCong * kq.SoTiengTinhCa) / 8);
                kq.OTMore4h += (int)((kq.kqNgayCong * kq.SoTiengTinhCa) / 4);

            }
            if (!kq.IsdkLamThemNull() && (kq.dkLamThem == 0 || kq.dkLamThem == 1) && isNotOT && !kq.tt_leTet)
            {
                kq.NightOT = kq.NormalOT = kq.NightOTLess24 = kq.NightDay = kq.NormalDay = kq.tgTinhTangCa = 0;
                kq.OTMore4h = kq.OTMore8h = 0;
                kq.kqNgayCong = 0;
                kq.LeaveID = null;
                kq["PerTimeID"] = DBNull.Value;
                kq.tt_nghiPhep = 0;
                kq.tt_nghiPhep_Alias = "";
            }
            if (isNotOT && !kq.tt_leTet)
            {
                kq.NightOT = kq.NormalOT = kq.NightOTLess24 = kq.OTMore4h = kq.OTMore8h = 0;
                kq.NormalOTBeforeShift = kq.NormalOTInShift = kq.NightOTBeforeShift = kq.NightOTInShift = kq.tgTinhTangCa = 0;
            }

            if (vm != null && kq.IsdkLamThemNull()) // A Trọng add vào ngày 30/05/2018 để set tgDiMuon, tgVeSom = 0 nếu là dk nghỉ cả ngày.
            {
                if (kq.PerTimeID == 3 && kq.kqNgayCong == 0)
                {
                    kq.tgDiMuon = 0;
                    kq.tgVeSom = 0;
                }
            }

            kq.kqNgayCong = kq.kqNgayCong * (calam.IskqNgayCongNull() ? 1 : calam.kqNgayCong);

            return kq;
        }

        public static void GetOTHoursBeforeAndInShift(dsXuLyQuetThe.tbCaLamViecRow calam, dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, dsXuLyQuetThe.tbRequestOverTime_KhongQuetRow item)
        {
            double NightOTBeforeShift = 0, NightOTInShift = 0, NormalOTBeforeShift = 0, NormalOTInShift = 0;
            TimeSpan caSang_TuGio = calam.caSang_tuGio;
            TimeSpan caChieu_denGio = calam.caChieu_denGio;
            if (caSang_TuGio > caChieu_denGio)
            {
                caChieu_denGio = caChieu_denGio.Add(new TimeSpan(24, 0, 0, 0));
            }
            if (item.tuGio < caSang_TuGio)
            {
                GetOTHours(kq, item.tuGio, item.denGio, ref NightOTBeforeShift, ref NormalOTBeforeShift);
            }
            else
            {
                if (caSang_TuGio <= item.tuGio && item.tuGio < caChieu_denGio)// Trước là  && item.tuGio <= caChieu_denGio
                {
                    GetOTHours(kq, item.tuGio, item.denGio, ref NightOTInShift, ref NormalOTInShift);
                }

            }

            kq.NightOTBeforeShift += NightOTBeforeShift;
            kq.NightOTInShift += NightOTInShift;
            kq.NormalOTBeforeShift += NormalOTBeforeShift;
            kq.NormalOTInShift += NormalOTInShift;
        }

        public static void GetOTHoursBeforeAndInShiftRequestOT(dsXuLyQuetThe.tbCaLamViecRow calam, dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, dsXuLyQuetThe.tbRequestOverTimeRow item)
        {
            double NightOTBeforeShift = 0, NightOTInShift = 0, NormalOTBeforeShift = 0, NormalOTInShift = 0;
            TimeSpan caSang_TuGio = calam.caSang_tuGio;
            TimeSpan caChieu_denGio = calam.caChieu_denGio;
            TimeSpan timeTuGio = item.tuGio;
            TimeSpan timeDenGio = item.denGio;

            TimeSpan? tgchecktruoc = new TimeSpan(calam.caSang_tuGio.Hours, calam.caSang_tuGio.Minutes - calam.tgQuetTruoc_Vao, calam.caSang_tuGio.Milliseconds);
            if (timeTuGio >= tgchecktruoc && timeTuGio <= calam.caSang_tuGio)
            {
                if (timeTuGio < kq.tgQuetDen)//tgQuetDen
                {
                    //timeTuGio = kq.tgQuetDen;
                }
                else
                {
                    GetOTHours(kq, timeTuGio, timeDenGio, ref NightOTBeforeShift, ref NormalOTBeforeShift);
                }
            }
            if (calam.caSang_tuGio < timeTuGio && timeTuGio <= new TimeSpan(24, 0, 0) && calam.caSang_denGio > calam.caSang_tuGio)
            {
                if (calam.caSang_tuGio > timeTuGio)
                {
                    GetOTHours(kq, timeTuGio, timeDenGio, ref NightOTInShift, ref NormalOTInShift);
                }
            }
            if (timeTuGio >= new TimeSpan(0, 0, 0) && timeTuGio < calam.caChieu_denGio && calam.caChieu_tuGio < calam.caChieu_denGio)
            {
                GetOTHours(kq, timeTuGio, timeDenGio, ref NightOTInShift, ref NormalOTInShift);
            }

            kq.NightOTBeforeShift += NightOTBeforeShift;
            kq.NightOTInShift += NightOTInShift;
            kq.NormalOTBeforeShift += NormalOTBeforeShift;
            kq.NormalOTInShift += NormalOTInShift;
        }

        public static void setTGQuetDuaVaoVangMat(dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, dsXuLyQuetThe.tbCaLamViecRow calam, TimeSpan calam_denGio_4check, bool isNghiPhepTinhCong = true)
        {
            if (!kq.IsPerTimeIDNull() && !isNghiPhepTinhCong)
            {
                if (kq.PerTimeID == 1)
                {
                    if (!kq.IstgQuetDenNull())
                    {
                        int soPhut = 0;
                        if (calam.caSang_denGio > calam.caSang_tuGio)
                        {
                            soPhut = (int)(calam.caSang_denGio - calam.caSang_tuGio).TotalMinutes;
                        }
                        else
                        {
                            soPhut = (int)(calam.caSang_denGio.Add(new TimeSpan(1, 0, 0, 0)) - calam.caSang_tuGio).TotalMinutes;
                        }
                        if (!kq.IstgDiMuonNull() && kq.tgDiMuon < soPhut)
                        {
                            kq.tgQuetDen = calam.caChieu_tuGio;
                            if (!calam.IscaDemNull() && calam.caDem)
                            {
                                //Tính lại tgDiMuon theo tgQuetDen mới.
                                if (kq.tgQuetDen > new TimeSpan(17, 0, 0))
                                {
                                    kq.tgDiMuon = (int)(new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0) - calam.tuGio).TotalMinutes;
                                }
                                else // Nếu đến lúc đêm hoặc sáng hsau.
                                {
                                    kq.tgDiMuon = (int)(new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0).Add(new TimeSpan(1, 0, 0, 0)) - calam.tuGio).TotalMinutes;
                                }
                            }
                            else
                            {
                                kq.tgDiMuon = (int)(new TimeSpan(kq.tgQuetDen.Hours, kq.tgQuetDen.Minutes, 0) - calam.tuGio).TotalMinutes;
                                if (kq.tgQuetDen > calam.caSang_denGio) //kiểm tra muộn qua h nghỉ trưa thì trừ
                                    kq.tgDiMuon -= (int)(Math.Min(kq.tgQuetDen.TotalMinutes, calam.caChieu_tuGio.TotalMinutes) - calam.caSang_denGio.TotalMinutes);
                            }
                        }
                    }
                }
                else if (kq.PerTimeID == 2)
                {
                    if (!kq.IstgQuetVeNull())
                    {
                        int soPhut = 0;
                        if (calam.caChieu_denGio > calam.caChieu_tuGio)
                        {
                            soPhut = (int)(calam.caChieu_denGio - calam.caChieu_tuGio).TotalMinutes;
                        }
                        else
                        {
                            soPhut = (int)(calam.caChieu_denGio.Add(new TimeSpan(1, 0, 0, 0)) - calam.caChieu_tuGio).TotalMinutes;
                        }
                        if (!kq.IstgVeSomNull() && kq.tgVeSom <= soPhut)
                        {
                            kq.tgQuetVe = calam.caChieu_tuGio;
                            //Tính lại tgVeSom theo tgQuetVe mới.
                            #region tính tg về sớm dựa vào tgQuetVe
                            if (!calam.IscaDemNull() && calam.caDem)
                            {
                                if (kq.tgQuetVe > calam.tuGio) // Nếu về lúc tối . calam.TuGio là đúng.
                                {
                                    kq.tgVeSom = (int)(calam_denGio_4check - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes;
                                }
                                else // Nếu về lúc đêm hoặc sáng hsau.
                                {
                                    kq.tgVeSom = (int)((new TimeSpan(0, calam_denGio_4check.Hours, calam_denGio_4check.Minutes, calam_denGio_4check.Seconds)) - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes;
                                }
                            }
                            else
                            {
                                kq.tgVeSom = (int)(calam_denGio_4check - new TimeSpan(kq.tgQuetVe.Hours, kq.tgQuetVe.Minutes, 0)).TotalMinutes;
                                if (kq.tgQuetVe < calam.caChieu_tuGio) //kiểm tra sớm trước h nghỉ trưa thì trừ
                                    kq.tgVeSom -= (int)(calam.caChieu_tuGio.TotalMinutes - Math.Max(kq.tgQuetVe.TotalMinutes, calam.caSang_denGio.TotalMinutes));
                            }

                            #endregion
                        }
                    }
                }
                else if (kq.PerTimeID == 3)
                {
                    kq["tgQuetDen"] = kq["tgQuetVe"] = DBNull.Value;
                }
            }
        }

        public static void tinhLaiTgDiMuonVeSom(dsXuLyQuetThe ds, dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, dsXuLyQuetThe.tbCaLamViecRow calam)
        {
            if (kq.IsLeaveIDNull())
            {
                return;
            }
            var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == kq.LeaveID).FirstOrDefault();
            if (leaveType != null && !leaveType.IsisTinhCongNull() && leaveType.isTinhCong)
            {
                return;
            }
            if (kq.PerTimeID == 1)
            {
                if (calam.caSang_tuGio > calam.caSang_denGio)
                {
                    kq.tgDiMuon -= (int)(calam.caSang_denGio.Add(new TimeSpan(24, 0, 0)) - calam.caSang_tuGio).TotalMinutes;
                }
                else
                {
                    kq.tgDiMuon -= (int)(calam.caSang_denGio - calam.caSang_tuGio).TotalMinutes;
                }
            }
            else if (kq.PerTimeID == 2)
            {
                if (calam.caChieu_tuGio > calam.caChieu_denGio)
                {
                    kq.tgVeSom -= (int)(calam.caChieu_denGio.Add(new TimeSpan(24, 0, 0)) - calam.caChieu_tuGio).TotalMinutes;
                }
                else
                {
                    kq.tgVeSom -= (int)(calam.caChieu_denGio - calam.caChieu_tuGio).TotalMinutes;
                }
            }
            if (kq.PerTimeID == 3) // nghỉ cả ngày
            {
                kq.tgVeSom = 0;
                kq.tgVeSom = 0;
            }
        }

        public static double getTongPhepDenHienTai(dcDatabaseDataContext db, dsXuLyQuetThe ds, DateTime tuNgay, DateTime ngayXuLy, string EmployeeID)
        {
            var ct = db.tblEmployees.Where(p => p.EmployeeID == EmployeeID).FirstOrDefault();
            int ngaycuoithang = new DateTime(ngayXuLy.Year, ngayXuLy.Month, 1).AddMonths(1).AddDays(-1).Day;

            if (ct != null)
            {
                //tạo hàm kiểm tra loại nhân viên và get tổng phép năm 
                var tongPhepDK = db.tbKetQuaQuetThes
                                .Where(p => p.ngay.Value >= ct.AppliedDate && p.ngay.Value.Year == ngayXuLy.Year && p.ngay < tuNgay && p.EmployeeID == EmployeeID && p.daysOfNghiCoLuong > 0 && p.tt_nghiPhep_Alias == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam])
                                .GroupBy(p => p.EmployeeID)
                                .Select(p => new
                                {
                                    tongPhep = p.Sum(p2 => p2.daysOfNghiCoLuong.Value)
                                }).FirstOrDefault();

                var tongPhepXL = ds.tbKetQuaQuetThe.Where(p => p.ngay.Year == ngayXuLy.Year && p.ngay <= ngayXuLy && p.EmployeeID == EmployeeID && p.daysOfNghiCoLuong > 0 && p.tt_nghiPhep_Alias == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam])
                                .GroupBy(p => p.EmployeeID)
                                .Select(p => new
                                {
                                    tongPhep = p.Sum(p2 => p2.daysOfNghiCoLuong)
                                }).FirstOrDefault();

                double tongPhepDKTrongNamTruocExpired = 0;

                if (ct.AnnualLeave_ExpireDate != null)
                {
                    var abc = db.tbKetQuaQuetThes
                                .Where(p => p.ngay.Value >= ct.AppliedDate && p.ngay.Value.Year == ngayXuLy.Year && p.EmployeeID == EmployeeID && p.daysOfNghiCoLuong > 0 && p.tt_nghiPhep_Alias == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam] && p.ngay <= (new DateTime(ct.AnnualLeave_ExpireDate.Value.Year, ct.AnnualLeave_ExpireDate.Value.Month, ct.AnnualLeave_ExpireDate.Value.Day)))
                                .GroupBy(p => p.EmployeeID)
                                .Select(p => new
                                {
                                    tongPhep = p.Sum(p2 => p2.daysOfNghiCoLuong.Value)
                                }).FirstOrDefault();
                    if (abc != null)
                    {
                        tongPhepDKTrongNamTruocExpired = abc.tongPhep;
                    }
                }
                // Nếu nhân viên nào có tổng phép còn lại đến cuối năm thì sử dụng. Nếu ai không có nghĩa là nhân viên mới. Phải dựa vào phần mềm tự tính phép còn lại.
                double tongPhepCo = ct.AnnualLeave_Remain == null ? getTongPhepCo(db, ngayXuLy, EmployeeID) : ct.AnnualLeave_Remain.Value;
                if (tongPhepCo > 0)
                {
                    tongPhepCo -= tongPhepDK != null ? tongPhepDK.tongPhep : 0;
                    tongPhepCo -= tongPhepXL != null ? tongPhepXL.tongPhep : 0;

                }
                // Thêm đoạn này do khi hết hạn AnnualLeave_ExpireDate thì xử lý đoạn này để phép không bị âm
                if (ct.AnnualLeave_OldYear != null && (new DateTime(ct.AnnualLeave_ExpireDate.Value.Year, ct.AnnualLeave_ExpireDate.Value.Month, ct.AnnualLeave_ExpireDate.Value.Day))
                            <= (new DateTime(ct.AnnualLeave_ExpireDate.Value.Year, ngayXuLy.Month, ngayXuLy.Day)))
                {
                    var tongTatCaPhepDK = (tongPhepDK != null ? tongPhepDK.tongPhep : 0) + (tongPhepXL != null ? tongPhepXL.tongPhep : 0);
                    var tongPhepDKSauExpired = ct.AnnualLeave_OldYear.Value - tongTatCaPhepDK;
                    tongPhepCo += tongPhepDKSauExpired <= 0 ? (ct.AnnualLeave_OldYear.Value > tongPhepDKTrongNamTruocExpired ? tongPhepDKTrongNamTruocExpired : ct.AnnualLeave_OldYear.Value) : (tongPhepDKTrongNamTruocExpired);
                }
                return tongPhepCo;
            }
            else
                return 0;
        }

        public static double getTongPhepCo(dcDatabaseDataContext db, DateTime ngayXuLy, string EmployeeID)
        {
            //AnnualLeave
            var ct = db.tblEmployees.Where(p => p.EmployeeID == EmployeeID).FirstOrDefault();
            int ngaycuoithang = new DateTime(ngayXuLy.Year, ngayXuLy.Month, 1).AddMonths(1).AddDays(-1).Day;

            double tongPhepCo = 0;
            //double PhepnamDocHai = 0;
            double PhepnamThamNien = 0;
            double SoNamLamViec = 0;
            double ngayphepchucvu = 0;

            DateTime _namtieptheo = new DateTime(ngayXuLy.AddYears(1).Year, 1, 1);

            //get ngay phep chuẩn theo chức vụ
            //if (ct.DepID_Final == null)
            //{
            //    PhepnamDocHai = 0;
            //}
            //else
            //{
            //    PhepnamDocHai = Convert.ToInt32(db.tblRef_Departments.Where(p => p.DepID == ct.DepID_Final).FirstOrDefault().LoaiCT);
            //}

            //get ngay phep chuẩn theo chức vụ
            if (ct.PosID == null || ct.PosID.ToString() == "")
            {
                ngayphepchucvu = 12;
            }
            else
            {
                if (db.tblRef_Positions.Where(p => p.PosID == ct.PosID).FirstOrDefault().AnnualLeave == null ||
                    db.tblRef_Positions.Where(p => p.PosID == ct.PosID).FirstOrDefault().AnnualLeave.ToString() == "")
                {
                    ngayphepchucvu = 12;
                }
                else
                {
                    ngayphepchucvu = Convert.ToInt32(db.tblRef_Positions.Where(p => p.PosID == ct.PosID).FirstOrDefault().AnnualLeave);
                }
            }

            // Tính phép năm thâm niên
            if (ct.AppliedDate != null)
            {
                var _index = ngayXuLy.Year - ct.AppliedDate.Value.Year; //Thong Lieu thêm ngày '31-07-2019 11:02:00.000'

                if (ct.AppliedDate.Value.Date > ngayXuLy.AddYears(-_index)) _index--;

                SoNamLamViec = _index;
                //SoNamLamViec = (System.Data.Linq.SqlClient.SqlMethods.DateDiffDay(ct.AppliedDate.Value, ngayXuLy)) / 365;

                if (SoNamLamViec >= 1 && SoNamLamViec < 5)
                    PhepnamThamNien = 0;
                else if (SoNamLamViec >= 5 && SoNamLamViec < 10)
                    PhepnamThamNien = 1;
                else if (SoNamLamViec >= 10 && SoNamLamViec < 15)
                    PhepnamThamNien = 2;
                else if (SoNamLamViec >= 15 && SoNamLamViec < 20)
                    PhepnamThamNien = 3;
                else if (SoNamLamViec >= 20)
                    PhepnamThamNien = 4;
                else
                    PhepnamThamNien = 0;
            }

            //thời gian vào làm việc (AppliedDate)và thời gian ký hợp đồng (ContractDate) Exp: 09/2016
            if (ct != null && ct.ContractDate != null && ct.AppliedDate != null)
            {
                TimeSpan _songay = _namtieptheo - DateTime.Parse(ct.AppliedDate.ToString());
                Double _dk = 0;

                _dk = _songay.Days / 30.0;

                _dk = _dk / 12;

                if (_dk >= 1)
                {
                    tongPhepCo += PhepnamThamNien;
                    tongPhepCo += ngayphepchucvu;
                }
                else
                {
                    tongPhepCo += Math.Round(((PhepnamThamNien + ngayphepchucvu) / 12) * (_songay.Days / 30.0));
                }
                // Cộng thêm phép năm của năm trước.
                if (ct.AnnualLeave_OldYear != null)
                {
                    if (ct.AnnualLeave_ExpireDate != null)
                    {
                        if ((new DateTime(ct.AnnualLeave_ExpireDate.Value.Year, ct.AnnualLeave_ExpireDate.Value.Month, ct.AnnualLeave_ExpireDate.Value.Day))
                            >= (new DateTime(ct.AnnualLeave_ExpireDate.Value.Year, ngayXuLy.Month, ngayXuLy.Day)))
                        {
                            tongPhepCo += ct.AnnualLeave_OldYear.Value;
                        }
                    }
                    else
                    {
                        tongPhepCo += ct.AnnualLeave_OldYear.Value;
                    }
                }
                return tongPhepCo;
            }
            else
            {
                //nếu ngày ký hợp đồng bằng null
                if (ct.AppliedDate != null)
                {
                    TimeSpan _songay = _namtieptheo - DateTime.Parse(ct.AppliedDate.ToString());
                    Double _dk = _songay.Days / 30;

                    if (_dk >= 1)
                    {
                        tongPhepCo += PhepnamThamNien;
                        tongPhepCo += ngayphepchucvu;
                    }
                    else
                    {
                        tongPhepCo += Math.Round(((PhepnamThamNien + ngayphepchucvu) / 12) * _dk);
                    }
                }
                else
                {
                    tongPhepCo = 0;
                }

                return tongPhepCo;

            }
        }

        /// <summary>
        /// Hàm round này sẽ giống vs SQL. VD: A =  0.7550
        /// SQL: Round(A,2) = 0.76.
        /// .Net: Round(A,2) = 0.75.
        /// </summary>
        /// <param name="number">Số cần round</param>
        /// <param name="digit">Số thập phân sau dấu phẩy cần dữ lại</param>
        /// <returns></returns>
        public static double roundSQL(double number, int digit, bool isWorkingHours)
        {
            return Math.Round(number, digit, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Hàm làm tròn giờ
        /// </summary>
        /// <param name="number">Số cần round</param>
        /// <param name="digit">Số thập phân sau dấu phẩy cần dữ lại</param>
        /// <returns></returns>
        //var dt1 = RoundUp(DateTime.Parse("2011-08-11 16:59"), TimeSpan.FromMinutes(15));
        // dt1 == {11/08/2011 17:00:00}                                                                                                                                                                                                                 

        //var dt2 = RoundUp(DateTime.Parse("2011-08-11 17:00"), TimeSpan.FromMinutes(15));
        // dt2 == {11/08/2011 17:00:00}

        //var dt3 = RoundUp(DateTime.Parse("2011-08-11 17:01"), TimeSpan.FromMinutes(15));
        // dt3 == {11/08/2011 17:15:00}
        public static TimeSpan RoundDown(DateTime dt, TimeSpan d)
        {
            return (new DateTime(dt.Ticks - dt.Ticks % d.Ticks, dt.Kind)).TimeOfDay;
        }

        public static void GetOTHours(dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, TimeSpan tuGio, TimeSpan denGio, ref double NightOT, ref double NormalOT, ref double NightOTLess24, ref int CountOTMore4h)
        {
            double totalOT = 0;
            bool isTangCaToiDenSang = false;
            TimeSpan startNight = new TimeSpan(22, 0, 0);
            TimeSpan endNight = new TimeSpan(6, 0, 0);

            if (denGio < tuGio)
            {
                kq.isTangCaQua24h = true;
                endNight = endNight.Add(new TimeSpan(24, 0, 0));
                denGio = denGio.Add(new TimeSpan(24, 0, 0));
                isTangCaToiDenSang = true;
                NightOTLess24 = 1;
            }

            for (TimeSpan i_tuGio = tuGio.Add(new TimeSpan(0, 15, 0)); i_tuGio <= denGio.Add(new TimeSpan(0, 2, 0)); i_tuGio = i_tuGio.Add(new TimeSpan(0, 15, 0)))
            {
                // Nếu 5h30 sáng. tuGio + 30ph = 6h. 30ph đó là đêm nên cần i_tuGio > startNight.
                if ((isTangCaToiDenSang && i_tuGio > startNight && i_tuGio <= endNight) || (!isTangCaToiDenSang && (i_tuGio <= endNight || i_tuGio > startNight)))
                {
                    NightOT += 0.25;
                    if (i_tuGio > new TimeSpan(22, 0, 0) && i_tuGio <= new TimeSpan(24, 0, 0))
                    {
                        NightOTLess24 += 0.25;
                    }
                }
                else
                    NormalOT += 0.25;
                totalOT += 0.25;
            }
            CountOTMore4h = (int)totalOT / 4;
        }

        public static void GetOTHours(dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, TimeSpan tuGio, TimeSpan denGio, ref double NightOT, ref double NormalOT)
        {
            double totalOT = 0;
            TimeSpan startNight = new TimeSpan(22, 0, 0);
            TimeSpan endNight = new TimeSpan(6, 0, 0);
            bool isTangCaToiDenSang = false;
            if (denGio < tuGio)
            {
                kq.isTangCaQua24h = true;
                endNight = endNight.Add(new TimeSpan(24, 0, 0));
                denGio = denGio.Add(new TimeSpan(24, 0, 0));
                isTangCaToiDenSang = true;
            }
            for (TimeSpan i_tuGio = tuGio.Add(new TimeSpan(0, 15, 0)); i_tuGio <= denGio.Add(new TimeSpan(0, 2, 0)); i_tuGio = i_tuGio.Add(new TimeSpan(0, 15, 0)))
            {
                // Nếu 5h30 sáng. tuGio + 30ph = 6h. 30ph đó là đêm nên cần i_tuGio > startNight.
                if ((isTangCaToiDenSang && i_tuGio > startNight && i_tuGio <= endNight) || (!isTangCaToiDenSang && (i_tuGio <= endNight || i_tuGio > startNight)))
                {
                    NightOT += 0.25;
                }
                else
                    NormalOT += 0.25;
                totalOT += 0.25;
            }
        }

        public static void GetOTHours(dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, TimeSpan tuGio, TimeSpan denGio, ref int CountOTMore8h)
        {
            if (tuGio == null || denGio == null)
            {
                return;
            }
            double totalOT = 0;
            TimeSpan startNight = new TimeSpan(22, 0, 0);
            TimeSpan endNight = new TimeSpan(6, 0, 0);
            if (denGio < tuGio)
            {
                kq.isTangCaQua24h = true;
                endNight = endNight.Add(new TimeSpan(24, 0, 0));
                denGio = denGio.Add(new TimeSpan(24, 0, 0));
            }
            for (TimeSpan i_tuGio = tuGio.Add(new TimeSpan(0, 15, 0)); i_tuGio <= denGio.Add(new TimeSpan(0, 2, 0)); i_tuGio = i_tuGio.Add(new TimeSpan(0, 15, 0)))
            {
                totalOT += 0.25;
            }
            CountOTMore8h = (int)totalOT / 8;
        }

        public static void GetOISHours(dsXuLyQuetThe.tbKetQuaQuetThe_FakeRow kq, TimeSpan tuGio, TimeSpan denGio, ref double NormalOIS, ref double NightOIS)
        {
            double totalOT = 0;
            TimeSpan startNight = new TimeSpan(22, 0, 0);
            TimeSpan endNight = new TimeSpan(6, 0, 0);
            bool isTangCaToiDenSang = false;
            if (denGio < tuGio)
            {
                endNight = endNight.Add(new TimeSpan(24, 0, 0));
                denGio = denGio.Add(new TimeSpan(24, 0, 0));
                isTangCaToiDenSang = true;
            }
            for (TimeSpan i_tuGio = tuGio.Add(new TimeSpan(0, 1, 0)); i_tuGio <= denGio; )
            {
                if ((isTangCaToiDenSang && i_tuGio > startNight && i_tuGio <= endNight) || (!isTangCaToiDenSang && (i_tuGio <= endNight || i_tuGio > startNight)))
                {
                    NightOIS += 1;
                }
                else
                {
                    NormalOIS += 1;
                }
                totalOT += 1;
                i_tuGio = i_tuGio.Add(new TimeSpan(0, 1, 0));
            }
        }
    }

    public class EmpQuetThe
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public bool IsNotOT { get; set; }
        public string CardID { get; set; }
        public string DepID { get; set; }
        public string DepID_Final { get; set; }
        public string DepName { get; set; }
        public string DepName_Final { get; set; }
        public string EmpTypeID { get; set; }
        public Guid? idCaLamMacDinh { get; set; }
        public DateTime? LeftDate { get; set; }
        public DateTime? AppliedDate { get; set; }
    }

}
