using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class PhanTichBangCong_TamUng : dlgCustomBase
    {
        DataTable dt = new DataTable();
        dsXuLyQuetThe ds = new dsXuLyQuetThe();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        public PhanTichBangCong_TamUng()
        {
            InitializeComponent();
        }

        private void XuLyDuLieu_Load(object sender, EventArgs e)
        {
            this.Form_Title = SelectTranslate("PhanTichBangCong_TamUng_Title", LoginHelper.langTrans);
            this.Text = SelectTranslate("PhanTichBangCong_TamUng_Title", LoginHelper.langTrans);
            this.Form_Description = SelectTranslate("PhanTichBangCong_TamUng_Des", LoginHelper.langTrans);
            
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

            switch (type)
            {

                #region Tính công tạm ứng.
                case 1:// 1: Tính công tạm ứng.

                    if (kq.IsdkLamThemNull())
                    {
                        result = kq.IskqNgayCongNull() ? 0 : kq.kqNgayCong;
                    }

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
                
                #region Sang công tháng nghỉ việc
                if (chk_SanCongThangTamUng.Checked)
                {
                    bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Tính lại ngày công tính lương", DateTime.Now));

                    foreach (DataRow rEmp in dtEmp.Rows)
                    {
                        string empID = rEmp["EmployeeID"].ToString();

                        Provider.ExecNoneQuery("p_tinhCong_SangCongThang_TamUng", new System.Data.SqlClient.SqlParameter("empID", empID), new System.Data.SqlClient.SqlParameter("thangXuLy", thangXuLy));
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
                
                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Reset bảng công tháng: {1:n0} records", DateTime.Now, Provider.ExecNoneQuery("p_tinhCong_ResetBangCongThang_TamUng", new System.Data.SqlClient.SqlParameter("thang", chonKyLuong1.Thang))));
                
                Provider.LoadDataBySql(ds, "tblEmpSalary", "SELECT * FROM tblEmpSalary");
                
                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Dữ liệu thay đổi lương: {1:n0} records", DateTime.Now, ds.tblEmpSalary.Rows.Count));
                               
                int count = 0;
                
                bgw_import.ReportProgress(4, "Đang xử lý dữ liệu");
                
                foreach (DataRow rEmp in dtEmp.Rows)
                {
                    string empID = rEmp["EmployeeID"].ToString();

                    string strAction = "";

                    var _lKQ = ds.tbKetQuaQuetThe.Where(p => p.EmployeeID == empID && p.ngay >= chonKyLuong1.TuNgay && p.ngay <= chonKyLuong1.DenNgay);

                    var bc = ds.tbBangCongThang_TamUng.Where(p => p.EmployeeID == empID && p.thang == thangXuLy).FirstOrDefault();

                    if (bc == null)
                    {
                        bc = ds.tbBangCongThang_TamUng.NewRow() as dsXuLyQuetThe.tbBangCongThang_TamUngRow;

                        bc.thang = thangXuLy;

                        bc.EmployeeID = empID;

                        bc.tongCong_Cu = 0;

                        bc.tongCong_Moi = 0;

                        bc.tongCong_CuMoi = 0;

                        strAction = "addNew";
                    }
                    foreach (var kq in _lKQ)
                    {
                        try
                        {
                            DateTime ngay = kq.ngay;
                            if (isLuongMoi(empID, ngay))
                            {
                                bc.tongCong_Moi += tinhCongTheoLoai(kq, 1);
                            }
                            else
                            {
                                bc.tongCong_Cu += tinhCongTheoLoai(kq, 1);
                            }


                            #region Tính tổng công tạm ứng
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
                        ds.tbBangCongThang_TamUng.AddtbBangCongThang_TamUngRow(bc);
                    }
                }

                bgw_import.ReportProgress(4, "Đang đẩy dữ liệu lên server");

                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Commit database: {1:n0} records", DateTime.Now, ds.tbBangCongThang_TamUng.Rows.Count));

                Provider.UpdateData(ds, "tbBangCongThang_TamUng");

                bgw_import.ReportProgress(2, string.Format("{0:HH:mm:ss}: Phân tích bảng công tạm ứng thành công", DateTime.Now));

                LogAction.LogAction.PushLog("Analyze"
                                            , ""
                                            , ""
                                            , string.Format("Phân tích bảng công tạm ứng tháng {0:dd/MM/yyyy}",thangXuLy)
                                            , "tbBangCongThang_TamUng");

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
