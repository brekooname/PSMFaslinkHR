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
using System.Reflection;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgDangKyVangMat : dlgCustomBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        public int coHuongLuong = 0;

        string FilesChoised = "";

        public dlgDangKyVangMat()
        {
            InitializeComponent();
        }

        private void dlgDangKyCaLam_Load(object sender, EventArgs e)
        {
            txtTuNgay.DateTime = txtDenNgay.DateTime = DateTime.Now.Date;

            var db = new dcDatabaseDataContext(Provider.ConnectionString);

            if (coHuongLuong == 1)
            {
                txtLyDo.Properties.DataSource = db.tblRef_LeaveTypes.Where(p => p.SalaryRate > 0);

                this.Form_Title =  SelectTranslate("dlgDangKyVangMat_coluong", LoginHelper.langTrans);
            }
            if (coHuongLuong == 0)
            {
                txtLyDo.Properties.DataSource = db.tblRef_LeaveTypes.Where(p => p.SalaryRate == 0 || p.SalaryRate == null);

                this.Form_Title =  SelectTranslate("dlgDangKyVangMat_khongluong", LoginHelper.langTrans);
            }
            this.Form_Description = SelectTranslate("DangKyVangMat_des", LoginHelper.langTrans); 
            TranslateForm();
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
                MessageBox.Show("Từ ngày nhỏ hơn đến ngày!\r\n");

                return;
            }

            int caXinNghi = cmbXinNghi.SelectedIndex + 1;

            if (txtLyDo.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn lý do để đăng ký", "Đăng ký vắng mặt"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);

                return;
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
                        dw_it.bw.ReportProgress(2, string.Format("Mã nhân viên không đúng! ({0}) \r\n", empID));

                        continue;
                    }
                    if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(empID, LoginHelper.user.idKhoiPB.Value))
                    {
                        dw_it.bw.ReportProgress(2, string.Format("Mã nhân viên ({0}) không thuộc phòng ban của bạn để đăng ký.\r\n", empID));

                        continue;
                    }

                    //if (IsLock.IsLock.Check_IsLock("tblEmpDayOff", tuNgay))
                    //{
                    //    dw_it.bw.ReportProgress(2, "Dữ liệu đã chốt công không thể thao tác.");
                    //    continue;
                    //}

                    if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", tuNgay, 1))
                    {
                        dw_it.bw.ReportProgress(2, "Dữ liệu đã chốt công không thể thao tác.\r\n");

                        continue;
                    }

                    if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", tuNgay, 2))
                    {
                        dw_it.bw.ReportProgress(2, "Dữ liệu đã chốt đăng ký mới không thể thao tác.\r\n");

                        continue;
                    }

                    var empLeft = db.tblEmployees.Where(p => p.EmployeeID == empID).FirstOrDefault();

                    if (empLeft != null 
                        && (empLeft.LeftDate == null || (empLeft.LeftDate != null && empLeft.LeftDate.Value > tuNgay)))
                    {
                        var vm = db.tblEmpDayOffs.Where(p => p.EmployeeID == empID && p.FromDate == tuNgay).FirstOrDefault();

                        if (vm != null)
                        {
                            if (vm.isAccept != null)
                            {
                                dw_it.bw.ReportProgress(2, string.Format("Đăng ký vắng mặt ngày {0:dd/MM/yyyy} nhân viên {1} đã được duyệt. Không thể đăng ký đè!\r\n", tuNgay, empID));

                                continue;
                            }
                            if (vm.isAcceptBP != null)
                            {
                                dw_it.bw.ReportProgress(2, string.Format("Đăng ký vắng mặt ngày {0:dd/MM/yyyy} nhân viên {1} đã được duyệt. Không thể đăng ký đè!\r\n", tuNgay, empID));

                                continue;
                            }
                            try
                            {
                                vm.EmployeeID = empID;

                                vm.FromDate = tuNgay;

                                vm.LeaveID = txtLyDo.EditValue.ToString();

                                vm.PerTimeID = caXinNghi;

                                vm.RegistedDate = DateTime.Now;

                                vm.Notes = txtGhiCHu.Text;

                                vm.ToDate = denNgay;

                                vm.Days = Ham.DemNgayCong(tuNgay, denNgay) * (caXinNghi == 3 ? 1 : 0.5);

                                vm.idUserRequest = LoginHelper.user.id;

                                Guid idFile = vm.idFile != null ? vm.idFile.Value : Guid.NewGuid();

                                if (isChoiseFile)
                                {
                                    vm.idFile = idFile;
                                }

                                db.SubmitChanges();

                                #region Add file to other database
                                if (isChoiseFile) // Nếu chọn file đính kèm
                                {

                                    if (vm.idFile != null)
                                    {
                                        var f1 = dbFiles.tbFiles.Where(p => p.id == vm.idFile.Value).FirstOrDefault();

                                        if (f1 != null)
                                        {
                                            f1.dataFile = datafileChoised;

                                            f1.duoiFile = duoiFile;
                                        }
                                        else
                                        {
                                            tbFile newFile = new tbFile();

                                            newFile.id = idFile;

                                            newFile.dataFile = datafileChoised;

                                            newFile.duoiFile = duoiFile;

                                            dbFiles.tbFiles.InsertOnSubmit(newFile);
                                        }
                                    }
                                    else
                                    {
                                        tbFile newFile = new tbFile();

                                        newFile.id = idFile;

                                        newFile.dataFile = datafileChoised;

                                        newFile.duoiFile = duoiFile;

                                        dbFiles.tbFiles.InsertOnSubmit(newFile);
                                    }

                                    dbFiles.SubmitChanges();
                                }
                                #endregion

                                success++;

                                dw_it.bw.ReportProgress(2, "Cập nhật thành công đăng ký vắng mặt nhân viên " + empID + "\r\n");

                                mnv += empID + "=2" + ",";
                            }
                            catch (Exception)
                            {
                                dw_it.bw.ReportProgress(2, "Cập nhật lỗi đăng ký vắng mặt nhân viên " + empID + "\r\n");
                            }
                        }
                        else
                        {
                            try
                            {
                                tblEmpDayOff vm2 = new tblEmpDayOff();

                                vm2.EmployeeID = empID;

                                vm2.FromDate = tuNgay;

                                vm2.LeaveID = txtLyDo.EditValue.ToString();

                                vm2.PerTimeID = caXinNghi;

                                vm2.RegistedDate = DateTime.Now;

                                vm2.Notes = txtGhiCHu.Text;

                                vm2.ToDate = denNgay;

                                vm2.Days = Ham.DemNgayCong(tuNgay, denNgay) * (caXinNghi == 3 ? 1 : 0.5);

                                vm2.idUserRequest = LoginHelper.user.id;

                                Guid idFile = vm2.idFile != null ? vm2.idFile.Value : Guid.NewGuid();

                                if (isChoiseFile)
                                {
                                    vm2.idFile = idFile;
                                }

                                db.tblEmpDayOffs.InsertOnSubmit(vm2);

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

                                LogAction.LogAction.PushLog("Đăng ký"
                                                            , string.Join(",", _lEmp)
                                                            , ""
                                                            , string.Format("Đăng ký vắng mặt từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}"
                                                                            , txtTuNgay.DateTime
                                                                            , txtDenNgay.DateTime)
                                                            , "tblEmpDayOff");

                                dw_it.bw.ReportProgress(2, "Đăng ký vắng mặt thành công nhân viên " + empID + "\r\n");

                                mnv += empID + "=2" + ",";
                            }
                            catch (Exception)
                            {
                                dw_it.bw.ReportProgress(2, "Đăng ký vắng mặt lỗi đăng ký nhân viên " + empID + "\r\n");
                            }
                        }
                    }

                }

                #region gởi mail: Thong đóng gửi mail '31-01-2019'
                //try
                //{

                //    if (mnv != string.Empty)
                //    {
                //        mnv += ")";

                //        mnv = mnv.Replace(",)", "");

                //        string[] mnv_tam = mnv.Split(',');

                //        string NoiDung = string.Empty;

                //        string TieuDe = string.Empty;

                //        if (coHuongLuong == 1)
                //            TieuDe = "[THUANHAI - iHRM] - Đăng kí vắng mặt có lương - ";
                //        else
                //            TieuDe = "[THUANHAI - iHRM] - Đăng kí vắng mặt không lương - ";

                //        foreach (string chuoi in mnv_tam)
                //        {


                //            tblEmpDayOff dkvm = db.tblEmpDayOffs.Where(p => p.EmployeeID == chuoi.Split('=')[0].ToString().Trim()).FirstOrDefault();

                //            if (dkvm == null)
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

                //            NoiDung += "Xin nghỉ: " + cmbXinNghi.Text + "\n";

                //            NoiDung += "Lý do: " + txtLyDo.Text + "\n";

                //            if (coHuongLuong == 1)
                //                NoiDung += "Nội dung: Đăng ký vắng mặt có lương" + "\n";
                //            else
                //                NoiDung += "Nội dung: Đăng ký vắng mặt không lương" + "\n";

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
                    ucProgress1.Status = "Đăng ký vắng mặt thành công " + success + " records";
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



        #region Translate language
        public static List<string> listCtr = new List<string>();
        public static Dictionary<string, string> myData = new Dictionary<string, string>();

        private IEnumerable<DevExpress.XtraGrid.Columns.GridColumn> EnumerateGridColumn()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraGrid.Columns.GridColumn).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraGrid.Columns.GridColumn)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<DevExpress.XtraEditors.SimpleButton> EnumerateSimpleButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.SimpleButton).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.SimpleButton)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<ToolStripButton> EnumerateToolStripButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(ToolStripButton).IsAssignableFrom(field.FieldType)
                   let component = (ToolStripButton)field.GetValue(this)
                   where component != null
                   select component;
        }

        private IEnumerable<DevExpress.XtraEditors.LabelControl> EnumerateLabelControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.LabelControl).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.LabelControl)field.GetValue(this)
                   where component != null
                   select component;
        }

        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new System.Data.SqlClient.SqlParameter("CtrName", nameCrt),

                           new System.Data.SqlClient.SqlParameter("FormName", this.Name.ToString()+(coHuongLuong == 0 ? "_khongluong" : "_coluong")));
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
        public void TranslateForm()
        {
            myData.Clear();
            listCtr.Clear();
            string langTrans = LoginHelper.langTrans;
            //string formText = SelectTranslate(this.Name + (coHuongLuong == 0 ? "_khongluong" : "_coluong"), langTrans);
            //if (formText != "")
            //{
            //    this.Text = formText;
            //}
            #region Khai báo list loai control trong form
            var _GridColumn = EnumerateGridColumn();
            var _ToolStripButton = EnumerateToolStripButton();
            var _LableControl = EnumerateLabelControl();
            var _SimpleButton = EnumerateSimpleButton();
            #endregion

            #region Dịch form
            foreach (DevExpress.XtraGrid.Columns.GridColumn s in _GridColumn)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Caption);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Caption = trans;
                }
            }
            foreach (ToolStripButton s in _ToolStripButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.SimpleButton s in _SimpleButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.LabelControl s in _LableControl)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            //this.Text = SelectTranslate("dlgDangKyVangMat", langTrans) + " " + SelectTranslate("frmDangKyVangMat" + (coHuongLuong == 0 ? "_khongluong" : "_coluong"), langTrans);
            myData.Add(this.Name + (coHuongLuong == 0 ? "_khongluong" : "_coluong"), this.Form_Title);
            listCtr.Add(this.Name + (coHuongLuong == 0 ? "_khongluong" : "_coluong"));
            // dịch radiogrop duyệt 
            //rdAccept.Properties.Items[0].Description = SelectTranslate("rdAcceptTatca", langTrans);
            //rdAccept.Properties.Items[1].Description = SelectTranslate("rdAcceptDaDuyet", langTrans);
            //rdAccept.Properties.Items[2].Description = SelectTranslate("rdAcceptKhongDuyet", langTrans);
            //cmbXinNghi.Properties.Items[0] = SelectTranslate("DangKyVangMat_sang", langTrans);
            //cmbXinNghi.Properties.Items[1] = SelectTranslate("DangKyVangMat_chieu", langTrans);
            //cmbXinNghi.Properties.Items[2] = SelectTranslate("DangKyVangMat_cangay", langTrans);
          

            #endregion
        }

        #endregion

        private void dlgDangKyVangMat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name + (coHuongLuong == 0 ? "_khongluong" : "_coluong");
                frm.ShowDialog();
                dlgDangKyCaLam_Load(null, null);
            }
        }
    }
}
