using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgDangKyCongTacDaiHan : dlgCustomBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
        string FilesChoised = "";

        public dlgDangKyCongTacDaiHan()
        {
            InitializeComponent();
        }
        private void dlgDangKyCaLam_Load(object sender, EventArgs e)
        {
            txtTuNgay.DateTime = txtDenNgay.DateTime = DateTime.Now.Date;
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
        }
        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
        private void txtTuNgay_Leave(object sender, EventArgs e)
        {
            txtDenNgay.DateTime = txtTuNgay.DateTime;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isChoiseFile = FilesChoised == "" ? false : true;
            int success = 0;
            byte[] bytes = null;
            Binary datafileChoised = null;
            string mnv = string.Empty;
            string duoiFile = "";
            try
            {
                if (isChoiseFile)
                {
                    bytes = System.IO.File.ReadAllBytes(FilesChoised);
                    datafileChoised = new Binary(bytes);
                    duoiFile = Path.GetExtension(FilesChoised);
                }
            }
            catch (Exception)
            {
                GUIHelper.MessageError("File đính kèm không hợp lệ.");
                return;
            }


            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            var dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            List<string> _lEmp = ucChonDoiTuong_DS1.GetValue();
            DateTime tuNgay = txtTuNgay.DateTime;
            DateTime denNgay = txtDenNgay.DateTime;

            var count_day = (denNgay - tuNgay).TotalDays;
            if (count_day < 0)
            {
                MessageBox.Show("Từ ngày nhỏ hơn đến ngày!\n");
                return;
            }


            if (txtLyDo.Text == "" )
            {
                if(txtLyDo.Enabled)
                {
                 MessageBox.Show("Bạn chưa nhập số QĐ để đăng ký", "Đăng ký công tác", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            }
            int count = 0;
            btnSave.Enabled = false;
            dw_it.OnDoing = (s, ev) =>
            {
                dw_it.bw.ReportProgress(1, "Đang đăng ký...");
                dw_it.bw.ReportProgress(0, _lEmp.Count);
                foreach (string empID in _lEmp)
                {
                    count++;
                    dw_it.bw.ReportProgress(1, "Đang đăng ký nhân viên " + empID);
                    dw_it.bw.ReportProgress(3, count);
                    var nv = db.tblEmployees.SingleOrDefault(p => p.EmployeeID == empID);
                    if (nv == null)
                    {
                        dw_it.bw.ReportProgress(2, string.Format("Mã nhân viên không đúng! ({0})", empID));
                        continue;
                    }
                    if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(empID, LoginHelper.user.idKhoiPB.Value))
                    {
                        dw_it.bw.ReportProgress(2, string.Format("Mã nhân viên ({0}) không thuộc phòng ban của bạn để đăng ký.", empID));
                        continue;
                    }
                    //if (IsLock.IsLock.Check_IsLock("tblDangKyCongTacDaiHan", tuNgay))
                    //{
                    //    dw_it.bw.ReportProgress(2, "Dữ liệu đã chốt công không thể thao tác.");
                    //    continue;
                    //}

                    if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", tuNgay,1))
                    {
                        dw_it.bw.ReportProgress(2, "Dữ liệu đã chốt công không thể thao tác.");
                        continue;
                    }
                    if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", tuNgay, 2))
                    {
                        dw_it.bw.ReportProgress(2, "Dữ liệu đã chốt đăng ký mới không thể thao tác.");
                        continue;
                    }

                    var empLeft = db.tblEmployees.Where(p => p.EmployeeID == empID).FirstOrDefault();
                    if (empLeft != null && (empLeft.LeftDate == null || (empLeft.LeftDate != null && empLeft.LeftDate.Value > tuNgay)))
                    {

                        try
                        {
                            tblDangKyCongTacDaiHan vm2 = new tblDangKyCongTacDaiHan();
                            vm2.id = Guid.NewGuid();
                            vm2.EmployeeID = empID;
                            vm2.FromDate = tuNgay;
                            vm2.LyDo = txtLyDo.Text;
                            vm2.isQD = cmbLoaiCT.SelectedIndex + 1;
                            vm2.Notes = txtGhiCHu.Text;
                            vm2.ToDate = denNgay;
                            int phamvi = 1;
                            if(cboPhamVi.SelectedIndex==1)
                            {
                                phamvi = 2;
                            }
                            vm2.isTrongNuoc = phamvi;
                            vm2.RegistedDate = DateTime.Now;
                            vm2.Days = Ham.DemNgayCong(tuNgay, denNgay);
                            vm2.idUserRequest = LoginHelper.user.id;
                            Guid idFile = vm2.idFile != null ? vm2.idFile.Value : Guid.NewGuid();
                            if (isChoiseFile)
                            {
                                vm2.idFile = idFile;
                            }
                            db.tblDangKyCongTacDaiHans.InsertOnSubmit(vm2);
                            db.SubmitChanges();
                            if (isChoiseFile) // Nếu chọn file đính kèm
                            {
                                tbFile newFile = new tbFile();
                                newFile.id = idFile;
                                newFile.dataFile = datafileChoised;
                                newFile.duoiFile = duoiFile;
                                dbFiles.tbFiles.InsertOnSubmit(newFile);
                                dbFiles.SubmitChanges();
                            }
                            success++;
                            dw_it.bw.ReportProgress(2, "\n"+"Đăng ký công tác thành công nhân viên " + empID + "\r\n");
                            mnv += empID + "=2" + ",";
                        }
                        catch (Exception ex)
                        {
                            dw_it.bw.ReportProgress(2, "Đăng ký công tác lỗi đăng ký nhân viên " + empID + "\n");
                        }
                    }
                }
                LogAction.LogAction.PushLog("Đăng ký", string.Join(",", _lEmp), "", string.Format("Đăng ký công tác dài hạn từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", txtTuNgay.DateTime, txtDenNgay.DateTime), "tbKetQuaQuetThe");
                #region gởi mail
                //try
                //{

                //    if (mnv != string.Empty)
                //    {
                //        mnv += ")";
                //        mnv = mnv.Replace(",)", "");
                //        string[] mnv_tam = mnv.Split(',');
                //        string NoiDung = string.Empty;
                //        string TieuDe = string.Empty;
                //        TieuDe = "[THUANHAI - iHRM] - Đăng kí công tác - ";
                //        foreach (string chuoi in mnv_tam)
                //        {


                //            tblDangKyCongTacDaiHan dcctdh = db.tblDangKyCongTacDaiHans.Where(p => p.EmployeeID == chuoi.Split('=')[0].ToString().Trim()).FirstOrDefault();
                //            if (dcctdh == null)
                //                continue;

                //            string h = chuoi;
                //            tblEmployee employee = db.tblEmployees.Where(p => p.EmployeeID == chuoi.Split('=')[0].ToString()).FirstOrDefault();
                //            if (employee == null)
                //                continue;
                //            //tblEmployee employee = db.tblEmployees.First(p => p.EmployeeID == dcctdh.EmployeeID);
                //            TieuDe += employee.EmployeeName + ",";
                //            NoiDung += "==========//==========" + "\n";
                //            NoiDung += "Mã Nhân viên: " + employee.EmployeeID + "\n";
                //            NoiDung += "Tên nhân viên: " + employee.EmployeeName + "\n";
                //            NoiDung += "Chức vụ: " + employee.EmpTypeName + "\n";
                //            NoiDung += "Phòng ban: " + employee.DepName_Final + "\n";
                //            NoiDung += "Nội dung: Đăng ký công tác" + "\n";
                //            NoiDung += "Trạng thái: Đăng ký" + "\n";
                //            NoiDung += "Thời gian: Từ ngày " + string.Format("{0: dd/MM/yyyy}", tuNgay) + " Đến ngày " + string.Format("{0: dd/MM/yyyy}", denNgay) + "\n";

                //        }
                //        //tblDangKyCongTacDaiHan dcctdh = db.tblDangKyCongTacDaiHans.Where(p => p.EmployeeID == chuoi.Split('=')[0].ToString().Trim()).FirstOrDefault();
                //        //if (dcctdh == null)
                //        w5sysUser u = db.w5sysUsers.Where(p => p.id == LoginHelper.user.id).FirstOrDefault();
                //        NoiDung += "iHRM - PSM Toàn Cầu" + "\n";
                //        NoiDung += "==========//==========" + "\n";
                //        TieuDe += ")";
                //        TieuDe = TieuDe.Replace(",)", "");
                //        if (u != null)
                //        {
                //            iHRM.Win.DungChung.Ham.SendMail(TieuDe, NoiDung, u.loginID);
                //        }
                //    }

                //}
                //catch { }
                #endregion
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 0)
                {
                    ucProgress1.start(0, (int)data.UserState);
                }
                else if (data.ProgressPercentage == 1)
                {
                    ucProgress1.Status = data.UserState.ToString();
                }
                else if (data.ProgressPercentage == 2)
                {
                    ucProgress1.Message = ucProgress1.Message + "\n" + data.UserState;
                }
                else if (data.ProgressPercentage == 3)
                {
                    ucProgress1.CurrentValue = (int)data.UserState;
                }
            };
            dw_it.OnCompleting = (ps, obj) =>
            {
                if (success > 0)
                {
                    ucProgress1.Status = "Đăng ký công tác thành công " + success + " records";
                }
                else
                {
                    ucProgress1.Status = "Không có nhân viên nào được đăng ký";
                }
                btnSave.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void btnFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) //Chọn file
            {
                OpenFileDialog od = new OpenFileDialog();
                string filterFile = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                filterFile += "|Word files (*.doc, *.docx)|*.doc; *.docx; ";
                filterFile += "|Pdf files (*.pdf)|*.pdf; ";
                filterFile += "|All files (*.*)|*.*;";
                od.Filter = filterFile;
                od.Multiselect = false;
                if (od.ShowDialog() == DialogResult.OK)
                {
                    FilesChoised = od.FileNames[0];
                    btnFile.Text = string.Format(FilesChoised);
                }
            }
            else //Hủy file
            {
                btnFile.Text = "";
                FilesChoised = "";
            }
        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoaiCT.SelectedIndex == 1)
            {
                txtLyDo.Enabled = false;
                txtLyDo.Text = string.Empty;
            }
            else
            {
                txtLyDo.Enabled = true;
            }
        }
    }
}
