using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass.QuetThe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe.Tools
{
    public partial class ConfigAttendane_BaoCaoTuan : dlgCustomBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        dsXuLyQuetThe ds;

        List<DateTime> _lNgay = new List<DateTime>();
        public ConfigAttendane_BaoCaoTuan()
        {
            InitializeComponent();
        }
        private void dlgDangKyCaLam_Load(object sender, EventArgs e)
        {
        }
        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Close();
        }
        private void btnCatQua4hTC_Click(object sender, EventArgs e1)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            List<DateTime> _lNgay = new List<DateTime>();
            DateTime tuNgay = chonKyLuong1.TuNgay;
            DateTime denNgay = chonKyLuong1.DenNgay;
            List<string> _lNV = ucChonDoiTuong_DS1.GetValue();

            btnCatQua4hTC.Enabled = false;

            dw_it.OnDoing = (s, ev) =>
            {
                if (_lNV.Count == 0)
                {
                    dw_it.bw.ReportProgress(1, "Chưa chọn nhân viên hoặc phòng ban!");
                    return;
                }
                ds = new dsXuLyQuetThe();
                ds.tbKetQuaQuetThe_Fake.AcceptChanges();
                loadData(ds, dw_it);
                try
                {
                    var kqqtLonHon4h = ds.tbKetQuaQuetThe_Fake.Where(p => p.ngay >= chonKyLuong1.TuNgay && p.ngay <= chonKyLuong1.DenNgay && p.tgTinhTangCa > 4);
                    foreach (var kq in kqqtLonHon4h)
                    {
                        try
                        {
                            while (kq.tgTinhTangCa > 4)
                            {
                                var isNotOT = db.tblEmployees.Where(p => p.EmployeeID == kq.EmployeeID).First().IsNotOT;
                                kq.modifyDate = DateTime.Now;
                                kq.modifyBy = LoginHelper.user.id;
                                TimeSpan tsTgTru = new TimeSpan();
                                double tgTru = kq.tgTinhTangCa - 4;

                                if (tgTru < 1)
                                {
                                    tsTgTru = new TimeSpan(0, (int)((tgTru - ((int)tgTru)) * (-60)), 0);
                                }
                                else
                                    tsTgTru = new TimeSpan((int)tgTru * (-1), (int)((tgTru - ((int)tgTru)) * (-60)), 0);
                                kq.tgQuetVe = kq.tgQuetVe.Add(tsTgTru);
                                //iHRM.Win.ExtClass.QuetThe.QuetThe.SetTimeQT_Fake(ds, kq, isNotOT);
                            }
                        }
                        catch (Exception)
                        {
                            dw_it.bw.ReportProgress(1, string.Format("Xử lý lỗi mã {0}", kq.EmployeeID));
                        }
                        dw_it.bw.ReportProgress(1, string.Format("Xử lý thành công mã {0}", kq.EmployeeID));
                    }

                    CommitData(ds, dw_it);
                }
                catch (Exception ex)
                {
                    dw_it.bw.ReportProgress(1, ex.Message);
                }
            };
            dw_it.OnProcessing = (ps, e) =>
            {
                if (e.ProgressPercentage == 1)
                {
                    ucProgress1.Message = ucProgress1.Message + "\r\n" + e.UserState.ToString();
                }
                else if (e.ProgressPercentage == 3)
                {
                    ucProgress1.start(0, Convert.ToInt32(e.UserState));
                }
                else if (e.ProgressPercentage == 4)
                {
                    ucProgress1.CurrentValue = Convert.ToInt32(e.UserState);
                }
            };
            dw_it.OnCompleting = (ps, obj) =>
            {
                GUIHelper.Notifications("Xử lý cắt tăng ca quá 4h thành công!", "Sửa dữ liệu", GUIHelper.NotifiType.edit);
                btnCatQua4hTC.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it); //reg and run progress
        }

        private void CommitData(dsXuLyQuetThe ds, mainBase.Dowork_Item dw_it)
        {
            if (ds.tbKetQuaQuetThe_Fake.GetChanges() == null)
            {
                dw_it.bw.ReportProgress(1, "\n>> " + Lng.QuetThe_AnalyzeData.msg_1);
            }
            else
            {
                var rowChanged = ds.tbKetQuaQuetThe_Fake.GetChanges().Rows.Count;
                dw_it.bw.ReportProgress(1, "\n>> Commit data to database...");
                Provider.UpdateData(ds, ds.tbKetQuaQuetThe_Fake.TableName);
                dw_it.bw.ReportProgress(1, "\n>> " + Lng.QuetThe_AnalyzeData.msg_2 + rowChanged + ") " + Lng.QuetThe_AnalyzeData.msg_3);
            }
            dw_it.bw.ReportProgress(1, "\nXử lý hoàn thành!");
        }
        private void loadData(dsXuLyQuetThe ds, mainBase.Dowork_Item dw_it)
        {

            List<DateTime> _lNgay = new List<DateTime>();
            DateTime tuNgay = chonKyLuong1.TuNgay;
            DateTime denNgay = chonKyLuong1.DenNgay;
            List<string> _lNV = ucChonDoiTuong_DS1.GetValue();

            dw_it.bw.ReportProgress(1, string.Format("Đang lấy dữ liệu..."));

            #region get data
            //ds.EnforceConstraints = false;
            Provider.LoadData(ds, ds.tbCaLamViec.TableName);
            dw_it.bw.ReportProgress(1, "Ca làm việc: " + ds.tbCaLamViec.Rows.Count);
            Provider.LoadData(ds, ds.tbNgayNghiPhepNam.TableName);
            dw_it.bw.ReportProgress(1, "Ngày nghỉ phép năm: " + ds.tbNgayNghiPhepNam.Rows.Count);
            Provider.LoadDataByProc(ds, ds.tblEmpDayOff.TableName, "p_getAllDangKyVangMat", new SqlParameter("tuNgay", iHRM.Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", iHRM.Common.DungChung.Ham.GetDenNgay(denNgay)));
            dw_it.bw.ReportProgress(1, "Đăng ký vắng mặt: " + ds.tblEmpDayOff.Rows.Count);
            Provider.LoadDataByProc(ds, ds.tblEmp7hours.TableName, "p_GetAllEmp7hours", new SqlParameter("tuNgay", iHRM.Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", iHRM.Common.DungChung.Ham.GetDenNgay(denNgay)));
            dw_it.bw.ReportProgress(1, "Danh sách làm 7 tiếng: " + ds.tblEmp7hours.Rows.Count);
            //strEmp = strEmp.Remove(_lEmpID.Count - 1);

            //Provider.LoadDataByProc(ds, ds.tblRecorder.TableName, "p_duLieuQuetThe_GetAlltblRecorder_ByStrEmp", new SqlParameter("tuNgay", iHRM.iHRM.Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", iHRM.iHRM.Common.DungChung.Ham.GetDenNgay(denNgay)), Provider.CreateParameter_StringList("dtEmpID", _lNV));
            Provider.LoadDataByProc(ds, ds.tbKetQuaQuetThe_Fake.TableName, "p_duLieuQuetThe_GetAllKetQuaQuetThe_Fake_TinhCong_ByStrEmp", new SqlParameter("tuNgay", iHRM.Common.DungChung.Ham.GetTuNgay(tuNgay)), new SqlParameter("denNgay", iHRM.Common.DungChung.Ham.GetDenNgay(denNgay)), Provider.CreateParameter_StringList("dtEmpID", _lNV));
            dw_it.bw.ReportProgress(1, Lng.QuetThe_AnalyzeData.msg_kqqt + ds.tbKetQuaQuetThe.Count);

            Provider.LoadData(ds, ds.tblRef_LeaveType.TableName);
            dw_it.bw.ReportProgress(1, "Danh sách các loại vắng mặt: " + ds.tblRef_LeaveType.Rows.Count);
            #endregion

            dw_it.bw.ReportProgress(3, _lNV.Count);
            dw_it.bw.ReportProgress(4, 0);
        }
        private void btnCatOTThaiSan_Click(object sender, EventArgs e1)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            List<DateTime> _lNgay = new List<DateTime>();
            DateTime tuNgay = chonKyLuong1.TuNgay;
            DateTime denNgay = chonKyLuong1.DenNgay;
            List<string> _lNV = ucChonDoiTuong_DS1.GetValue();
            btnCatQua4hTC.Enabled = false;

            dw_it.OnDoing = (s, ev) =>
            {
                if (_lNV.Count == 0)
                {
                    dw_it.bw.ReportProgress(1, "Chưa chọn nhân viên hoặc phòng ban!");
                    return;
                }
                ds = new dsXuLyQuetThe();
                ds.tbKetQuaQuetThe_Fake.AcceptChanges();
                loadData(ds, dw_it);

                try
                {
                    var kqqtTSOT = ds.tbKetQuaQuetThe_Fake.Where(p => p.ngay >= chonKyLuong1.TuNgay && p.ngay <= chonKyLuong1.DenNgay && p.tgTinhTangCa > 0 && p.is7Hours);
                    foreach (var kq in kqqtTSOT)
                    {
                        try
                        {
                            var isNotOT = db.tblEmployees.Where(p => p.EmployeeID == kq.EmployeeID).First().IsNotOT;
                            kq.modifyDate = DateTime.Now;
                            kq.modifyBy = LoginHelper.user.id;
                            TimeSpan tsTgTru = new TimeSpan();
                            double tgTru = kq.tgTinhTangCa;

                            if (tgTru < 1)
                            {
                                tsTgTru = new TimeSpan(0, (int)((tgTru - ((int)tgTru)) * (-60)), 0);
                            }
                            else
                                tsTgTru = new TimeSpan((int)tgTru * (-1), (int)((tgTru - ((int)tgTru)) * (-60)), 0);
                            kq.tgQuetVe = kq.tgQuetVe.Add(tsTgTru);
                            //iHRM.Win.ExtClass.QuetThe.QuetThe.SetTimeQT_Fake(ds, kq, isNotOT);
                        }
                        catch (Exception)
                        {
                            dw_it.bw.ReportProgress(1, string.Format("Xử lý lỗi mã {0}", kq.EmployeeID));
                        }
                        dw_it.bw.ReportProgress(1, string.Format("Xử lý thành công mã {0}", kq.EmployeeID));
                    }

                    CommitData(ds, dw_it);
                }
                catch (Exception ex)
                {
                    dw_it.bw.ReportProgress(1, ex.Message);
                }
            };
            dw_it.OnProcessing = (ps, e) =>
            {
                if (e.ProgressPercentage == 1)
                {
                    ucProgress1.Message = ucProgress1.Message + "\r\n" + e.UserState.ToString();
                }
                else if (e.ProgressPercentage == 3)
                {
                    ucProgress1.start(0, Convert.ToInt32(e.UserState));
                }
                else if (e.ProgressPercentage == 4)
                {
                    ucProgress1.CurrentValue = Convert.ToInt32(e.UserState);
                }
            };
            dw_it.OnCompleting = (ps, obj) =>
            {
                GUIHelper.Notifications("Xử lý xóa tăng ca thai sản thành công!", "Sửa dữ liệu", GUIHelper.NotifiType.edit);
                btnCatQua4hTC.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it); //reg and run progress
        }
    }
}
