using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business.Helper;
using iHRM.Win.Frm.XtraReportTemplate;
using iHRM.Common.Code;
using System.Windows.Forms;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmChuyenUVSangNV : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        DataTable dtData = new DataTable();
        DataRow CRow;
        dlgDanhGiaUngVien dlgEditor;
        public frmChuyenUVSangNV()
        {
            InitializeComponent();
        }
        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            toolStripChuyen.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            toolStripChuyen.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Edit);
            toolStripButton2.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            toolStripBtnHDThuViec.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);

            if (btnFind.Enabled)
            {
                btnFind_Click(null, null);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            if (chkGDDaDuyet.Checked)
            {
                toolStripBtnHDThuViec.Visible = true;
                toolStripChuyen.Visible = true;
            }
            else
            {
                toolStripBtnHDThuViec.Visible = true;
                toolStripChuyen.Visible = false;
            }
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ...";
            dw_it.OnDoing = (s, ev) =>
            {
                dtData = Provider.ExecuteDataTableReader("p_getUVChuyenSangNV",
                                new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text),
                                new System.Data.SqlClient.SqlParameter("isGDDaDuyet", chkGDDaDuyet.Checked)
                                );

                dw_it.bw.ReportProgress(1, dtData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grcDanhGiaUV.DataSource = data.UserState;
                    btnFind.Enabled = true;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grcDanhGiaUV);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var drs = grvDanhGiaUV.GetSelectedRows().Select(i => grvDanhGiaUV.GetDataRow(i));
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            else
            {
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa đánh giá ứng viên đã chọn."))
                {
                    db = new dcDatabaseDataContext(Provider.ConnectionString);
                    foreach (DataRow r in drs)
                    {
                        if (r["id"] != null)
                        {
                            var a = db.tblUV_DanhGias.Where(i => i.id.ToString() == r["id"].ToString()).FirstOrDefault();
                            if (a != null)
                            {
                                db.tblUV_DanhGias.DeleteOnSubmit(a);
                            }
                        }
                    }
                    try
                    {
                        db.SubmitChanges();
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                        grvDanhGiaUV.DeleteSelectedRows();
                    }
                    catch (Exception ex)
                    {
                        win_globall.ExecCatch(ex);
                    }
                    var lst = db.tblUV_DanhGias.Where(i => drs.Select(j => j["id"] as string).Equals(i.id.ToString()));
                }
            }
        }
        void ShowEditor()
        {
            if (dlgEditor == null)
            {
                dlgEditor = new dlgDanhGiaUngVien();
                dlgEditor.Owner = this;
                dlgEditor.OnSave += dlgEditor_OnSave;
            }
            DataRow r = grvDanhGiaUV.GetFocusedDataRow();
            dlgEditor._idYCTD_UV = Convert.ToInt32(r["idycuv"]);
            dlgEditor.loadPredata();
            dlgEditor.Show();
        }

        void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                #region  Check nhập thông tin
                if (dlgEditor.MyValue["ketQuaVong1"] == DBNull.Value || Convert.ToInt16(dlgEditor.MyValue["ketQuaVong1"]) < 0)
                {
                    GUIHelper.MessageError("Bạn chưa nhập kết quả sơ vấn.", "Không thể lưu");
                    return;
                }
                //if (dlgEditor.MyValue["ketQuaVong2"] != DBNull.Value)
                //{
                //    GUIHelper.MessageError("Bạn không thể nhập kết quả vòng 2 khi chưa nhập kết quả sơ vấn.", "Không thể lưu");
                //    return;
                //}
                //if (dlgEditor.MyValue["ketQuaPheDuyet"] != DBNull.Value)
                //{
                //    GUIHelper.MessageError("Bạn không thể nhập kết quả phê duyệt khi chưa nhập kết quả sơ vấn.", "Không thể lưu");
                //    return;
                //}
                #endregion
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn lưu đánh giá ứng viên đã chọn."))
                {
                    db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
                    tblUV_DanhGia dg;
                    if (dlgEditor.CustomFormAction == 0)//Thêm mới
                    {
                        dg = new tblUV_DanhGia();
                    }
                    else
                    {
                        dg = db.tblUV_DanhGias.FirstOrDefault(p => p.id == Convert.ToInt32(dlgEditor.MyValue["id"]));
                    }
                    SetDataContextFromDataRow(dg, dlgEditor.MyValue);

                    if (dlgEditor.CustomFormAction == 0)//Thêm mới
                    {
                        db.tblUV_DanhGias.InsertOnSubmit(dg);
                        db.SubmitChanges();
                        dlgEditor._idDG = db.tblUV_DanhGias.OrderByDescending(p => p.id).First().id;
                        dlgEditor.MyValue["id"] = dlgEditor._idDG;
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                        LoadVisibleAndEnableTabPageDanhGia();
                    }
                    else
                    {
                        db.SubmitChanges();
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                    }
                    btnFind_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        public void LoadVisibleAndEnableTabPageDanhGia()
        {
            bool isVisibleTab1 = false, isVisibleTab2 = false, isVisibleTab3 = false;
            bool isReadOnlyTab1 = false, isReadOnlyTab2 = false, isReadOnlyTab3 = false;
            if (dlgEditor.MyValue != null)
            {
                if (dlgEditor.MyValue["ketQuaVong1"] != DBNull.Value && Convert.ToInt16(dlgEditor.MyValue["ketQuaVong1"]) >= 0)
                {
                    isReadOnlyTab1 = true;
                    if (dlgEditor.MyValue["ketQuaVong2"] != DBNull.Value && Convert.ToInt16(dlgEditor.MyValue["ketQuaVong2"]) >= 0)
                    {
                        isReadOnlyTab2 = true;
                        isVisibleTab1 = true;
                        isVisibleTab2 = true;
                        isVisibleTab3 = true;
                    }
                    else
                    {
                        isVisibleTab1 = true;
                        isVisibleTab2 = true;
                    }
                }
                else
                {
                    isVisibleTab1 = true;
                }
            }
            if (isVisibleTab3 && LoginHelper.user.isAcceptBP != null && LoginHelper.user.isAcceptBP.Value)
            {
                isVisibleTab3 = true;
            }
            else
            {
                isVisibleTab3 = false;
            }
            dlgEditor.setVisibleTabPage(isVisibleTab1, isVisibleTab2, isVisibleTab3);
            dlgEditor.setEnableTabPage(isReadOnlyTab1, isReadOnlyTab2);
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            CRow = grvDanhGiaUV.GetFocusedDataRow();
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void toolStripChuyen_Click(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            try
            {
                var _lIdx = grvDanhGiaUV.GetSelectedRows();
                foreach (var idx in _lIdx)
                {
                    DataRow dr = grvDanhGiaUV.GetDataRow(idx);
                    if (dr != null && dr["EmployeeID"] != DBNull.Value)
                    {
                        string idUV = dr["EmployeeID"].ToString();
                        var uv = db.tblUngViens.Where(p => p.EmployeeID == idUV).FirstOrDefault();
                        if (uv == null)
                        {
                            GUIHelper.MessageError("Không tồn tại ứng viên " + idUV, "Chuyển ứng viên thành nhân viên");
                            continue;
                        }
                        var dg = db.tblUV_DanhGias.Where(p => p.id == DbHelper.DrGetInt(dr, "id")).FirstOrDefault();
                        if (dg == null)
                        {
                            GUIHelper.MessageError("Không tồn tại đánh giá " + dg.id, "Chuyển ứng viên thành nhân viên");
                            continue;
                        }
                        var emp = db.tblEmployees.Where(p => p.idUV == idUV).FirstOrDefault();
                        if (emp == null)
                        {
                            emp = new tblEmployee();
                            emp.EmployeeID = emp.EmployeeCode = LoginHelper.Context.getEmployeeID();
                            emp.idUV = idUV;
                            db.tblEmployees.InsertOnSubmit(emp);
                            db.SubmitChanges();
                        }
                        emp = db.tblEmployees.Where(p => p.idUV == idUV).FirstOrDefault();
                        emp.OldEmployeeID = null;
                        emp.FirstName = uv.FirstName;
                        emp.LastName = uv.LastName;
                        emp.Birthday = uv.Birthday;
                        emp.EmployeeName = uv.EmployeeName;
                        emp.NameSearch = ConvertUnicode.RemoveUnicode(emp.EmployeeName).ToUpper();

                        emp.MaritalStatusID = uv.MaritalStatusID;
                        emp.MaritalStatusName = uv.MaritalStatusName;
                        emp.SexID = uv.SexID;
                        emp.Phone = uv.Phone;

                        emp.AppliedDate = dg.ngayNhanViec;//ngayNhanViec là ngày vào làm.
                        emp.SubmitDate = uv.SubmitDate;
                        //emp.ContractDate = null;
                        emp.NationalityID = uv.NationalityID;
                        emp.NationalityName = uv.NationalityName;
                        emp.NationalityName_VIE = uv.NationalityName_VIE;
                        // Start CMND:
                        emp.IDCard = uv.IDCard;
                        emp.IssuePlace = uv.IssuePlace;
                        emp.Address = uv.Address;
                        emp.IssueDate = uv.IssueDate;
                        emp.NativeCountry = uv.NativeCountry;
                        emp.PermanentAddress = uv.PermanentAddress;
                        emp.mailNgoai = uv.Email;

                        emp.hinhthuctraluong = "0";

                        //lấy tất cả thông tin của ứng viên
                        var UngVien = db.tblUngViens.Where(p => p.EmployeeID == idUV).FirstOrDefault();
                        if (UngVien != null)
                        {
                            //trình độ học vấn
                            var ungviensobo = db.tblUngVienSoBos.Where(p => p.MaUVSB == UngVien.idUVSB).FirstOrDefault();
                            if (ungviensobo != null)
                            {
                                emp.EducationID = ungviensobo.TrinhDoVanHoa;

                                if (!string.IsNullOrEmpty(emp.EducationID))
                                {
                                    var q = db.tblRef_Educations.Where(p => p.EducationID == emp.EducationID);
                                    if (q.Count() > 0)
                                    {
                                        emp.EducationType = q.First().EducationType;
                                    }
                                }

                                var Nationality = db.tblRef_Nationalities.Where(p => p.NationalityID == ungviensobo.NationalityID).FirstOrDefault();

                                if(Nationality != null)
                                {
                                    emp.NationalityID = ungviensobo.NationalityID;
                                    emp.NationalityName = Nationality.NationalityName;
                                    emp.NationalityName_VIE = Nationality.NationalityName_VIE;
                                }
                            }
                        }
                        Provider.ExecNoneQuery("p_ChuyenUVSangNV_xoaDuLieu", new System.Data.SqlClient.SqlParameter("EmployeeID", emp.EmployeeID));

                        emp = db.tblEmployees.Where(p => p.idUV == idUV).FirstOrDefault();
                        var knnn = db.tblUV_KyNangNgoaiNgus.Where(p => p.idUV == idUV);
                        foreach (var i_nn in knnn)
                        {
                            tblEmployeeID_KyNangNgoaiNgu empNN = new tblEmployeeID_KyNangNgoaiNgu();
                            empNN.EmployeeID = emp.EmployeeID;
                            empNN.nghe = i_nn.nghe;
                            empNN.noi = i_nn.noi;
                            empNN.doc = i_nn.doc;
                            empNN.viet = i_nn.viet;
                            empNN.ngonNgu = i_nn.ngonNgu;
                            db.tblEmployeeID_KyNangNgoaiNgus.InsertOnSubmit(empNN);
                        }
                        var knmt = db.tblUV_KyNangMayTinhs.Where(p => p.idUV == idUV);
                        foreach (var i_mm in knmt)
                        {
                            tblEmployee_KyNangMayTinh empNN = new tblEmployee_KyNangMayTinh();
                            empNN.EmployeeID = emp.EmployeeID;
                            empNN.tenPhanMem = i_mm.tenPhanMem;
                            empNN.suDungCoBan = i_mm.suDungCoBan;
                            empNN.thanhThao = i_mm.thanhThao;
                            empNN.bietSoQua = i_mm.bietSoQua;
                            db.tblEmployee_KyNangMayTinhs.InsertOnSubmit(empNN);
                        }
                        if (dg.viTriTuyenDung != null) // Vị trí:viTriTuyenDung
                        {
                            tblEmpType empType = new tblEmpType();
                            empType.id = Guid.NewGuid();
                            empType.EmployeeID = emp.EmployeeID;
                            empType.DateChange = emp.AppliedDate.Value;
                            empType.EmpTypeID = dg.viTriTuyenDung;

                            db.tblEmpTypes.InsertOnSubmit(empType);
                        }
                        if (dg.donViQuanLy != null) // Phòng ban:donViQuanLy
                        {
                            tblEmpDep empDep = new tblEmpDep();
                            empDep.id = Guid.NewGuid();
                            empDep.DateChange = emp.AppliedDate.Value;
                            empDep.EmployeeID = emp.EmployeeID;
                            empDep.DepID = dg.donViQuanLy;

                            db.tblEmpDeps.InsertOnSubmit(empDep);

                            //Update thông tin phòng ban Empoyee
                            emp.DepID_Final = dg.donViQuanLy;
                            emp.DepName_Final = db.tblRef_Departments.Where(p => p.DepID == dg.donViQuanLy).First().DepName;
                            emp.DepName = emp.DepName_Final;
                        }
                        // Nhập hợp đồng vào đây
                        if (dg.luongThuViec != null && dg.thoiGianThuViec != null) // Lương thử việc
                        {
                            tblEmpContract empCT = new tblEmpContract();

                            empCT.id = Guid.NewGuid();

                            empCT.EmployeeID = emp.EmployeeID;
                            empCT.BeginDate = emp.AppliedDate.Value;
                            empCT.EndDate = emp.AppliedDate.Value.AddMonths(dg.thoiGianThuViec.Value).AddDays(-1);
                            empCT.ContractTypeID = "2";
                            int year = emp.AppliedDate.Value.Year;
                            var ec = db.tblEmpContracts.Where(p => p.BeginDate.Year == year && p.ContractTypeID == "2").OrderByDescending(p => p.idx).FirstOrDefault();
                            var idx_Next = ec == null ? 1 : ec.idx + 1;
                            //273/HĐLĐ-2017 ContractID
                            empCT.idx = idx_Next;
                            //empCT.ContractID = string.Format("{0:000}/HĐLĐ-{1:0000}", idx_Next, year);
                            empCT.ContractID = string.Format("TD/D.01/{0}-{1:0000}", year.ToString().Substring(2, 2), idx_Next);
                            db.tblEmpContracts.InsertOnSubmit(empCT);

                            if (dg.luongThuViec != null) // Lương thử việc
                            {
                                tblEmpSalary empSal = new tblEmpSalary();
                                empSal.id = Guid.NewGuid();
                                empSal.EmployeeID = emp.EmployeeID;
                                empSal.DateChange = emp.AppliedDate.Value;
                                empSal.PosID = dg.chucVuTuyenDung;
                                empSal.BasicSalary = dg.luongBaoHiem;
                                empSal.ContractCode = empCT.ContractID;

                                db.tblEmpSalaries.InsertOnSubmit(empSal);
                            }
                        }
                        var UV_file = db.tblUV_FilesLienQuans.Where(p => p.idUV == idUV);
                        foreach (var item in UV_file)
                        {
                            tblEmpFilesLienQuan empFile = new tblEmpFilesLienQuan();
                            empFile.id = item.id;
                            empFile.ghiChu = item.ghiChu;
                            empFile.EmployeeID = emp.EmployeeID;
                            empFile.idFile = item.idFile;

                            db.tblEmpFilesLienQuans.InsertOnSubmit(empFile);
                        }

                        if (dr["idFile"] != DBNull.Value)
                        {
                            tblEmpFilesLienQuan empFile = new tblEmpFilesLienQuan();
                            empFile.id = (int)dr["id"];
                            empFile.ghiChu = "PM Chuyển từ đánh giá ứng viên";
                            empFile.EmployeeID = emp.EmployeeID;
                            empFile.idFile = (Guid)dr["idFile"];

                            db.tblEmpFilesLienQuans.InsertOnSubmit(empFile);
                        }

                        db.SubmitChanges();

                        Provider.ExecNoneQuery("p_updateThongTinLuong_Vitri", new System.Data.SqlClient.SqlParameter("empID", emp.EmployeeID));
                        Provider.ExecNoneQuery("p_updateThongTinHopDong", new System.Data.SqlClient.SqlParameter("empID", emp.EmployeeID));
                        Provider.ExecNoneQuery("p_updateThongTinLoaiNV", new System.Data.SqlClient.SqlParameter("empID", emp.EmployeeID));

                        LogAction.LogAction.PushLog("Thêm dữ liệu", emp.EmployeeID, "", string.Format("Chuyển ứng viên {0} thành nhân viên {1}", emp.EmployeeID, idUV), "tblEmployee");
                        GUIHelper.Notifications("Chuyển dữ liệu thành công ứng viên " + idUV, "Chuyển ứng viên thành nhân viên", GUIHelper.NotifiType.tick);
                    }
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
            btnFind_Click(null, null);
        }

        private void toolStripBtnHDThuViec_Click(object sender, EventArgs e)
        {
            var _lIdx = grvDanhGiaUV.GetSelectedRows();
            string Emp = string.Empty;
            foreach (var idx in _lIdx)
            {
                DataRow CRow = grvDanhGiaUV.GetDataRow(idx);
                Emp += CRow["EmployeeID"] as string;
            }

            //CRow = grvDanhGiaUV.GetFocusedDataRow();
            DataTable dt = Provider.ExecuteDataTable("p_HDThuViec_GetAll", new System.Data.SqlClient.SqlParameter("EmployeeID", Emp));

            if (dt.Rows.Count > 0)
            {
                var rp = new rep_phieu_HDTV();
                rp.DataBindings(dt);
                ReportViewer rv = new ReportViewer();
                rv.ViewReport(rp);
            }
        }

        private void repositoryItemButtonEditSenMail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CRow = grvDanhGiaUV.GetFocusedDataRow();

            DataTable check_uvsb = Provider.ExecuteDataTable("p_tblUngVien_GetMail", new System.Data.SqlClient.SqlParameter("EmployeeID", CRow["EmployeeID"] as string));
            if (check_uvsb.Rows.Count > 0)
            {
                frmSendMail_new frm = new frmSendMail_new(check_uvsb.Rows[0], 2);
                frm.ShowDialog();
            }

        }

        private void txtSearchKey_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }
    }
}
