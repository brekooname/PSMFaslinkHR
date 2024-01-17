using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgDieuChinhCongTacDaiHan : frmBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
        string FilesChoised = "";
        public dlgDieuChinhCongTacDaiHan()
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

        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var a = grv.GetFocusedDataRow();
            if (a != null)
            {
                txtMaNV_DK.Text = a["EmployeeID"] as string;
                txtTenNV_DK.Text = a["EmployeeName"] as string;
                txtTuNgay_DK.EditValue = a["FromDate"] as DateTime?;
                txtDenNgay_DK.EditValue = a["ToDate"] as DateTime?;
                txtLyDo_DK.Text = a["LyDo"] as string;
                txtGhiCHu_DK.Text = a["Notes"] as string;

                txtTuNgay.EditValue = a["FromDate"] as DateTime?;
                txtDenNgay.EditValue = a["ToDate"] as DateTime?;
            }
            else
            {
                txtMaNV_DK.Text = "";
                txtTenNV_DK.Text = "";
                txtTuNgay_DK.EditValue = null;
                txtDenNgay_DK.EditValue = null;
                txtLyDo_DK.Text = "";
                txtGhiCHu_DK.Text = "";
            }
        }

        private void grv_DataSourceChanged(object sender, EventArgs e)
        {
            grv_FocusedRowChanged(null, null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu đăng ký công tác dài hạn...";
            dw_it.OnDoing = (s, ev) =>
            {
                dt = Provider.ExecuteDataTable(
                    "p_chamcong_GetData_DangKyCongTacDaiHan_DC",
                    Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS2.GetValue()),
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                    new SqlParameter("isAccept", true)
                );
                dw_it.bw.ReportProgress(1, dt);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = data.UserState;
                dt.AcceptChanges();
                btnFind.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
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

            DateTime tuNgay = txtTuNgay.DateTime;
            DateTime denNgay = txtDenNgay.DateTime;

            var count_day = (denNgay - tuNgay).TotalDays;
            if (count_day < 0)
            {
                MessageBox.Show("Từ ngày nhỏ hơn đến ngày!\n");
                return;
            }

            if (txtLyDo.Text == "")
            {
                if (txtLyDo.Enabled)
                {
                    MessageBox.Show("Bạn chưa nhập số QĐ để đăng ký", "Đăng ký công tác", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            btnSave.Enabled = false;
            string empID = txtMaNV_DK.Text;
            var nv = db.tblEmployees.SingleOrDefault(p => p.EmployeeID == txtMaNV_DK.Text);
            if (nv == null)
            {
                GUIHelper.Notifications(string.Format("Mã nhân viên không đúng! ({0})", empID), "Đăng ký điều chỉnh công tác", GUIHelper.NotifiType.error);
                return;
            }
            if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(empID, LoginHelper.user.idKhoiPB.Value))
            {
                GUIHelper.Notifications(string.Format("Mã nhân viên ({0}) không thuộc phòng ban của bạn để đăng ký.", empID), "Đăng ký điều chỉnh công tác", GUIHelper.NotifiType.error);
                return;
            }
            //if (IsLock.IsLock.Check_IsLock("tblDieuChinhCongTacDaiHan", denNgay))
            //{
            //    GUIHelper.MessageBox("Ngày nảy đã chốt công vui lòng không chỉnh sửa!");
            //    return;
            //}

            if (IsLock.IsLock.Check_IsLock_Type("tblDieuChinhCongTacDaiHan", denNgay,1))
            {
                GUIHelper.MessageBox("Ngày nảy đã chốt công vui lòng không chỉnh sửa!");
                return;
            }

            if (IsLock.IsLock.Check_IsLock_Type("tblDieuChinhCongTacDaiHan", denNgay, 2))
            {
                GUIHelper.MessageBox("Ngày nảy đã chốt đăng ký mới vui lòng không chỉnh sửa!");
                return;
            }

            var empLeft = db.tblEmployees.Where(p => p.EmployeeID == empID).FirstOrDefault();
            if (empLeft != null && (empLeft.LeftDate == null || (empLeft.LeftDate != null && empLeft.LeftDate.Value > tuNgay)))
            {
                try
                {
                    var a = db.tblDieuChinhCongTacDaiHans.Where(p => p.idDangKyCongTac == DbHelper.DrGetGuid(grv.GetFocusedDataRow(), "id").Value).FirstOrDefault();
                    if (a!= null)
                    {
                        GUIHelper.Notifications(string.Format("Mã nhân viên ({0}) đã đăng ký điều chỉnh. Không thể điều chỉnh thêm.", empID), "Đăng ký điều chỉnh công tác", GUIHelper.NotifiType.error);
                        return;
                    }

                    tblDieuChinhCongTacDaiHan vm2 = new tblDieuChinhCongTacDaiHan();
                    vm2.id = Guid.NewGuid();
                    vm2.EmployeeID = txtMaNV_DK.Text;
                    vm2.RegistedDate = DateTime.Now;
                    vm2.idDangKyCongTac = DbHelper.DrGetGuid(grv.GetFocusedDataRow(), "id").Value;
                    vm2.FromDate = tuNgay;
                    vm2.LyDo = txtLyDo.Text;
                    vm2.Notes = txtGhiCHu.Text;
                    int phamvi = 1;
                    if(cboPhamVi.SelectedIndex==1)
                    {
                        phamvi = 2;
                    }
                    vm2.isTrongNuoc = phamvi;
                    vm2.ToDate = denNgay;
                    vm2.Days = Ham.DemNgayCong(tuNgay, denNgay);
                    vm2.idUserRequest = LoginHelper.user.id;
                    Guid idFile = vm2.idFile != null ? vm2.idFile.Value : Guid.NewGuid();
                    if (isChoiseFile)
                    {
                        vm2.idFile = idFile;
                    }
                    db.tblDieuChinhCongTacDaiHans.InsertOnSubmit(vm2);
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
                    LogAction.LogAction.PushLog("Đăng ký", empID, "", string.Format("Đăng ký điều chỉnh công tác từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}",txtTuNgay.DateTime,txtDenNgay.DateTime), "tblDieuChinhCongTacDaiHan");
                    GUIHelper.Notifications("Đăng ký điều chỉnh thành công  nhân viên " + empID, "Đăng ký điều chỉnh công tác", GUIHelper.NotifiType.tick);
                    mnv += empID + "=2" + ",";

                    #region gởi mail
                    try
                    {
                        string NoiDung = string.Empty;
                        string TieuDe = "[THUANHAI - iHRM] - Đăng kí điều chỉnh công tác ";
                        tblDangKyCongTacDaiHan dcctdh = db.tblDangKyCongTacDaiHans.Where(p => p.id == vm2.idDangKyCongTac).FirstOrDefault();
                        if (dcctdh == null)
                            return;
                        tblDieuChinhCongTacDaiHan dkdcctdh = db.tblDieuChinhCongTacDaiHans.Where(p => p.id == vm2.id).FirstOrDefault();
                        if (dkdcctdh == null)
                            return;
                        tblEmployee employee = db.tblEmployees.Where(p => p.EmployeeID == dcctdh.EmployeeID).FirstOrDefault();
                        if (employee == null)
                            return;
                        //tblEmployee employee = db.tblEmployees.First(p => p.EmployeeID == dcctdh.EmployeeID);
                        TieuDe += employee.EmployeeName + ",";
                        NoiDung += "==========//==========" + "\n";
                        NoiDung += "Mã Nhân viên: " + employee.EmployeeID + "\n";
                        NoiDung += "Tên nhân viên: " + employee.EmployeeName + "\n";
                        NoiDung += "Chức vụ: " + employee.EmpTypeName + "\n";
                        NoiDung += "Phòng ban: " + employee.DepName_Final + "\n";
                        NoiDung += "Nội dung: Đăng ký điều chỉnh công tác" + "\n";
                        NoiDung += "Trạng thái: Đăng ký" + "\n";
                        NoiDung += "Thời gian đăng kí: Từ ngày " + string.Format("{0: dd/MM/yyyy}", dcctdh.FromDate) + " Đến ngày " + string.Format("{0: dd/MM/yyyy}", dcctdh.ToDate) + "\n";
                        NoiDung += "Thời gian điều chỉnh: Từ ngày " + string.Format("{0: dd/MM/yyyy}", dkdcctdh.FromDate) + " Đến ngày " + string.Format("{0: dd/MM/yyyy}", dkdcctdh.ToDate) + "\n";
                        w5sysUser u = db.w5sysUsers.Where(p => p.id == LoginHelper.user.id).FirstOrDefault();
                        NoiDung += "iHRM - PSM Toàn Cầu" + "\n";
                        NoiDung += "==========//==========" + "\n";
                        if (u != null)
                        {
                            iHRM.Win.DungChung.Ham.SendMail(TieuDe, NoiDung, u.loginID);
                        }
                        
                    }
                    catch { }
                    #endregion

                }
                catch (Exception ex)
                {
                    GUIHelper.Notifications("Đăng ký điều chỉnh lỗi nhân viên " + empID, "Đăng ký điều chỉnh công tác", GUIHelper.NotifiType.error);
                }
            };
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
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
    }
}
