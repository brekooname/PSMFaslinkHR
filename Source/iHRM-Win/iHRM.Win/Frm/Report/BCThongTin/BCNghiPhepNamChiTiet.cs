using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.i_Report;
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

namespace iHRM.Win.Frm.Report
{
    public partial class BCNghiPhepNamChiTiet : frmBase
    {
        public BCNghiPhepNamChiTiet()
        {
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        DataTable data = new DataTable();
        private void btnFind_Click(object sender, EventArgs e)
        {
          
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ...";
            dw_it.OnDoing = (s, ev) =>
            {
                dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
                data = new DataTable();
                data = Provider.ExecuteDataTableReader("p_getBaoCaoPhepNamChiTiet",
                    new SqlParameter("date", dateThoiDiem.DateTime),
                    Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue())
                    );
                data.Columns.Add("tongPhepCoTrongNam", typeof(double));
                data.Columns.Add("tongPhepConLaiDenThangHienTai", typeof(double));
                data.Columns.Add("phepNamConLai", typeof(double));
                data.Columns.Add("soTienPhaiTra", typeof(double));
                double tongPhepCoTrongNam = 0, tongPhepConLaiDenThangHienTai = 0;

                DateTime _ngayCuoiCung = new DateTime(dateThoiDiem.DateTime.Year, dateThoiDiem.DateTime.Month, 1).AddMonths(1).AddDays(-1);

                foreach (DataRow r in data.Rows)
                {
                    tongPhepCoTrongNam = getTongPhepCo(db, new DateTime(dateThoiDiem.DateTime.Year, 12, 31), r["EmployeeID"].ToString());
                    r["tongPhepCoTrongNam"] = tongPhepCoTrongNam + Convert.ToDouble(r["phepNamNamTruoc"].ToString());
                    r["phepNamConLai"] = Convert.ToDouble(r["tongPhepCoTrongNam"].ToString()) - Convert.ToDouble(r["tongPhepNghi"].ToString());
                    tongPhepConLaiDenThangHienTai = getTongPhepDenHienTai(db, _ngayCuoiCung, r["EmployeeID"].ToString());
                    
                    r["tongPhepConLaiDenThangHienTai"] = tongPhepConLaiDenThangHienTai;
                    
                    //if ( Convert.ToDouble(r["phepNamConLai"].ToString()) > 0 && r["luongCoBan"].ToString().Trim() != "")
                    //{
                    //    if (r["PosName"].ToString().Trim().Equals("Worker"))
                    //    {
                    //          double tien = Math.Round(Convert.ToDouble(r["luongCoBan"].ToString().Trim()) / 26,0);                                

                    //            r["soTienPhaiTra"] = Convert.ToDouble(r["phepNamConLai"].ToString()) * tien;
                    //    }
                    //    else
                    //    {
                    //        if(!r["PosName"].ToString().Trim().Equals(""))
                    //        {
                    //             double tien = Math.Round(Convert.ToDouble(r["luongCoBan"].ToString().Trim()) / 25.25,0);                                

                    //            r["soTienPhaiTra"] = Convert.ToDouble(r["phepNamConLai"].ToString()) * tien;
                    //        }
                    //        else
                    //        {
                    //           r["soTienPhaiTra"]=0;
                    //        }
                          
                    //    }
                    //}
                }
                //gridColumn4.Caption = "Số phép được nghỉ đến thời điểm " + dateThoiDiem.DateTime.ToString("MM/yyyy");
                //DataTable dtData = new DataTable();
                //dtData = data.Copy();
                dw_it.bw.ReportProgress(1, data);
             
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState;
                    btnFind.Enabled = true;
                }
              
            };
            main.Instance.DoworkItem_Reg(dw_it);
           // grd.DataSource = data;
           
        }
        private double getTongPhepDenHienTai(dcDatabaseDataContext db, DateTime ngayXuLy, string EmployeeID)
        {
            var ct = db.tblEmployees.Where(p => p.EmployeeID == EmployeeID).FirstOrDefault();
            if (ct != null)
            {
                var tongPhepDK = db.tbKetQuaQuetThes
                                .Where(p => p.ngay.Value >= ct.ContractDate && p.ngay.Value.Year == ngayXuLy.Year && p.EmployeeID == EmployeeID && p.daysOfNghiCoLuong > 0 && p.tt_nghiPhep_Alias == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam])
                                .GroupBy(p => p.EmployeeID)
                                .Select(p => new
                                {
                                    tongPhep = p.Sum(p2 => p2.daysOfNghiCoLuong.Value)
                                }).FirstOrDefault();
                double tongPhepDKTrongNamTruocExpired = 0;
                if (ct.AnnualLeave_ExpireDate != null)
                {
                    var abc = db.tbKetQuaQuetThes
                                .Where(p => p.ngay.Value >= ct.ContractDate && p.ngay.Value.Year == ngayXuLy.Year && p.EmployeeID == EmployeeID && p.daysOfNghiCoLuong > 0 && p.tt_nghiPhep_Alias == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam] && p.ngay <= (new DateTime(ct.AnnualLeave_ExpireDate.Value.Year, ct.AnnualLeave_ExpireDate.Value.Month, ct.AnnualLeave_ExpireDate.Value.Day)))
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
                var tongPhepDK_NamTruoc = db.tbKetQuaQuetThes
                                .Where(p => p.ngay.Value >= ct.ContractDate && p.ngay >= (new DateTime(ngayXuLy.Year - 1, 12, 31)) && p.ngay < (new DateTime(ngayXuLy.Year, 1, 1)) && p.EmployeeID == EmployeeID && p.daysOfNghiCoLuong > 0 && p.tt_nghiPhep_Alias == Enums.LyDoNghi_CodeAlias[(int)Enums.eLyDoNghi.NghiPhepNam])
                                .GroupBy(p => p.EmployeeID)
                                .Select(p => new
                                {
                                    tongPhep = p.Sum(p2 => p2.daysOfNghiCoLuong.Value)
                                }).FirstOrDefault();
                // Nếu nhân viên nào có tổng phép còn lại đến cuối năm thì sử dụng. Nếu ai không có nghĩa là nhân viên mới. Phải dựa vào phần mềm tự tính phép còn lại.
                double tongPhepCo = ct.AnnualLeave_Remain == null ? getTongPhepCo(db, ngayXuLy, EmployeeID) : ct.AnnualLeave_Remain.Value;
                if (tongPhepCo > 0)
                {
                    tongPhepCo -= tongPhepDK != null ? tongPhepDK.tongPhep : 0;
                    tongPhepCo -= tongPhepDK_NamTruoc != null ? tongPhepDK_NamTruoc.tongPhep : 0;
                }
                // Thêm đoạn này do khi hết hạn AnnualLeave_ExpireDate thì xử lý đoạn này để phép không bị âm
                if (ct.AnnualLeave_OldYear != null && (new DateTime(ct.AnnualLeave_ExpireDate.Value.Year, ct.AnnualLeave_ExpireDate.Value.Month, ct.AnnualLeave_ExpireDate.Value.Day))
                            <= (new DateTime(ct.AnnualLeave_ExpireDate.Value.Year, ngayXuLy.Month, ngayXuLy.Day)))
                {
                    var tongTatCaPhepDK = (tongPhepDK != null ? tongPhepDK.tongPhep : 0) + (tongPhepDK_NamTruoc != null ? tongPhepDK_NamTruoc.tongPhep : 0);
                    var tongPhepDKSauExpired = ct.AnnualLeave_OldYear.Value - tongTatCaPhepDK;
                    //tongPhepCo += tongPhepDKSauExpired < 0 ? ct.AnnualLeave_OldYear.Value : (tongTatCaPhepDK);
                    tongPhepCo += tongPhepDKSauExpired <= 0 ? (ct.AnnualLeave_OldYear.Value > tongPhepDKTrongNamTruocExpired + (tongPhepDK_NamTruoc != null ? tongPhepDK_NamTruoc.tongPhep : 0) ? tongPhepDKTrongNamTruocExpired + (tongPhepDK_NamTruoc != null ? tongPhepDK_NamTruoc.tongPhep : 0) : ct.AnnualLeave_OldYear.Value) : (tongPhepDKTrongNamTruocExpired + (tongPhepDK_NamTruoc != null ? tongPhepDK_NamTruoc.tongPhep : 0));
                }
                return tongPhepCo;
            }
            else
                return 0;
        }
        private double getTongPhepCo(dcDatabaseDataContext db, DateTime ngayXuLy, string EmployeeID)
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

                    if(_dk >= 1)
                    {
                        tongPhepCo += PhepnamThamNien;
                        tongPhepCo += ngayphepchucvu;
                    }
                    else
                    {
                        tongPhepCo += Math.Round(((PhepnamThamNien + ngayphepchucvu) / 12) * _dk);
                    }

                    //if (ct.AppliedDate.Value.Year == ngayXuLy.Year)//năm vào làm bằng với năm sử lý
                    //{
                    //    tongPhepCo = ngayXuLy.Month - ct.AppliedDate.Value.Month;
                    //}
                    //else if (ct.AppliedDate.Value.Year <= ngayXuLy.Year)
                    //{
                    //    tongPhepCo = ngayXuLy.Month;
                    //}
                    //else
                    //{
                    //    tongPhepCo = 0;
                    //}
                    //if (ct.AppliedDate.Value.Day <= 15 && tongPhepCo > 0) // Nếu vào trước ngày 15 sẽ thêm 1 phép.
                    //{
                    //    tongPhepCo += 1;
                    //    tongPhepCo += PhepnamThamNien;
                    //    tongPhepCo += ngayphepchucvu;
                    //}
                }
                else
                {
                    tongPhepCo = 0;
                }

                return tongPhepCo;

            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save
            sd.Filter = "Excel 2007|*.xls";
            if (sd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))
                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);
                return;
            }
            //---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới
            ge.OnDoing += (bw) =>
            {
                bw.ReportProgress(-1, "Xuất excel dữ liệu nghỉ phép năm"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (data == null || data.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu
                    return;
                }


                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

                ExcelExportHelper ex = new ExcelExportHelper("Report/BaoCaoNghiPhepNam.xls"); // Tạo excel export helper + đường dẫn template
                ex.SetNamedRangeValue("Ngay", "Ngày tạo: " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);

                ex.FillDataTable(data); // Fill BC_FillData
                ex.RendAndFlush("BaoCaoNghiPhepNam_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
                bw.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
                }
                else if (ps == 2)
                {// Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.
                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);
                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName,
                            UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            dateThoiDiem.DateTime = DateTime.Now;
        }

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grd.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            string temp = "";          
            temp = "Report\\BCNghiPhepNam.xls";        
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Excel 2007|*.xls";
            if (sd.ShowDialog() != DialogResult.OK)
                return;

            var ex = new ExcelExportHelper(temp);
            ex.SetNamedRangeValue("thang", "Tháng " + string.Format("{0:MM-yyyy}", dateThoiDiem.DateTime));
            ex.SetNamedRangeValue("ngay", string.Format("{0:dd}/{0:MM}/{0:yyyy}", DateTime.Today));
            ex.SetNamedRangeValue("user", LoginHelper.user.caption.ToString());
            ex.FillDataTable_DSNL(data);
            ex.RendAndFlush("ANNUAL_LEAVE" , sd.FileName);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = sd.FileName,
                UseShellExecute = true
            });

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            backgroundWorker1.CancelAsync();
        }

        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {

         
            
        }

        private void grv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column == gridColumn4 && e.CellValue != null)
            {
                if (Convert.ToInt32(e.CellValue.ToString()) < 0)
                {
                    e.Appearance.ForeColor = Color.Red;
                }

            }
            
        }
    }
}
