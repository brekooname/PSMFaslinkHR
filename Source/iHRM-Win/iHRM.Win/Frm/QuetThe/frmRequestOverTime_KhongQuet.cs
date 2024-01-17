﻿using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System.Collections.Generic;
using iHRM.Win.Frm.LogAction;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class frmRequestOverTime_KhongQuet : frmBase
    {
        DataTable dt = new DataTable();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        List<ActionClass> _lActionClass = new List<ActionClass>();
        bool isDuyet = false;
        public frmRequestOverTime_KhongQuet()
        {
            InitializeComponent();
        }
        private void resItemButtonFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dr = grv.GetFocusedDataRow();
            if (e.Button.Index == 0)// Xem file
            {
                if (dr != null && dr["dataFile"] != DBNull.Value)
                {
                    FileStorageHelper fh = new FileStorageHelper();

                    var duoiFile = grv.GetFocusedRowCellValue(colDuoiFile).ToString();
                    Binary dataFile = new Binary(dr["dataFile"] as byte[]);
                    fh.DownLoadAndShowFILE(dataFile, dr["duoiFile"].ToString());
                }
                else
                {
                    GUIHelper.Notifications("Không có dữ liệu để xem", "Mở file", GUIHelper.NotifiType.error);
                }
            }
            else if (e.Button.Index == 1) // Chọn file mới
            {
                if (dr != null)
                {
                    if (dr["isAcceptBP"] != DBNull.Value)
                    {
                        return;
                    }
                    if (dr["isHetHan"] != DBNull.Value)
                    {
                        return;
                    }
                    OpenFileDialog od = new OpenFileDialog();
                    string filterFile = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    filterFile += "|Word files (*.doc, *.docx)|*.doc; *.docx; ";
                    filterFile += "|Pdf files (*.pdf)|*.pdf; ";
                    filterFile += "|All files (*.*)|*.*;";
                    od.Filter = filterFile;
                    od.Multiselect = false;
                    if (od.ShowDialog() == DialogResult.OK)
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(od.FileNames[0]);
                        dr["dataFile"] = bytes;
                        dr["duoiFile"] = Path.GetExtension(od.FileNames[0]);
                        if (dr["idFile"] == DBNull.Value)
                        {
                            dr["idFile"] = Guid.NewGuid();
                        }
                        _lActionClass.Add(new ActionClass("Cập nhật", dr["EmployeeID"].ToString(), "", "Chọn file mới", "tbRequestOverTime_KhongQuet"));
                    }
                }
                else
                {
                    GUIHelper.Notifications("Không có dữ liệu để chọn", "Mở file", GUIHelper.NotifiType.error);
                }


            }
            else if (e.Button.Index == 2) // Xóa file
            {
                if (dr != null)
                {
                    if (dr["isAcceptBP"] != DBNull.Value)
                    {
                        GUIHelper.Notifications("Không thể xóa được file đã duyệt.", "Xóa file đính kèm", GUIHelper.NotifiType.error);
                        return;
                    }
                    if (dr["isHetHan"] != DBNull.Value)
                    {
                        return;
                    }
                    dr["idFileDelete"] = dr["idFile"];
                    dr["dataFile"] = DBNull.Value;
                    dr["idFile"] = DBNull.Value;
                    dr["duoiFile"] = DBNull.Value;
                    _lActionClass.Add(new ActionClass("Xóa", dr["EmployeeID"].ToString(), "", "Xóa file", "tbRequestOverTime_KhongQuet"));
                    GUIHelper.Notifications("Đã xóa file đính kèm. Bấm lưu lại để hoàn thành.", "Xóa file đính kèm", GUIHelper.NotifiType.info);
                }
                else
                {
                    GUIHelper.Notifications("Không có dữ liệu để xóa", "Xóa file", GUIHelper.NotifiType.error);
                }
            }
        }

        private void toolStripSearch_Click(object sender, EventArgs e)
        {
            toolStripSearch.Enabled = false;
            dt = new DataTable();
            bool? isAccept = null;
            if (rdAccept.SelectedIndex == 1)
            {
                isAccept = true;
            }
            if (rdAccept.SelectedIndex == 2)
            {
                isAccept = false;
            }
            dt = Provider.ExecuteDataTable("p_getRequestOverTime_KhongQuet_byStrEmp",
                new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                new SqlParameter("denNgay", chonKyLuong1.DenNgay_End),
                new SqlParameter("isAccept", isAccept),
                Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS2.GetValue())
            );
            dt.Columns.Add("idFileDelete");
            grd.DataSource = dt;
            toolStripSearch.Enabled = true;
            _lActionClass.Clear();
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }
            dcDatabaseFilesDataContext dbFile = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);
            var count = dt.GetChanges().Rows.Count;
            string mnv = string.Empty;
            long idUserRequests = 0;
            DateTime ngay = DateTime.Now;
            DateTime ngayYeuCau = DateTime.Now;
            List<tbRequestOverTime_KhongQuet> lst = new List<tbRequestOverTime_KhongQuet>();
            try
            {
                foreach (DataRow dr in dt.GetChanges().Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if (dr["idFile"] == DBNull.Value)
                        {
                            if (dr["idFileDelete"] != DBNull.Value)
                            {
                                var a = dbFile.tbFiles.Where(p => p.id == Guid.Parse(dr["idFileDelete"].ToString())).FirstOrDefault();
                                if (a != null)
                                {
                                    dbFile.tbFiles.DeleteOnSubmit(a);
                                }
                            }
                        }
                        else
                        {
                            var a = dbFile.tbFiles.Where(p => p.id == Guid.Parse(dr["idFile"].ToString())).FirstOrDefault();
                            if (a == null)
                            {
                                a = new tbFile();
                                a.id = Guid.Parse(dr["idFile"].ToString());
                                dbFile.tbFiles.InsertOnSubmit(a);
                            }
                            if (dr["duoiFile"] == DBNull.Value)
                            {
                                a.duoiFile = null;
                            }
                            else
                                a.duoiFile = dr["duoiFile"].ToString();
                            if (dr["dataFile"] == DBNull.Value)
                            {
                                a.dataFile = null;
                            }
                            else
                                a.dataFile = dr["dataFile"] as byte[];
                        }
                        dbFile.SubmitChanges();
                        #region send mail
                        try
                        {
                            tbRequestOverTime_KhongQuet sc = new tbRequestOverTime_KhongQuet();
                            sc.EmployeeID = dr["EmployeeID"].ToString();
                            if (dr["isAcceptBP"].ToString() == string.Empty && dr["isGoBo"].ToString() == string.Empty && dr.RowState == DataRowState.Added) //trạng thái đăn kí
                                sc.ghiChu = "2";
                            if (dr["isAcceptBP"].ToString() == "False" && dr["isAccept"].ToString() == string.Empty)     //trạng thái trưởng bộ phân không duyệt
                                sc.ghiChu = "0";
                            if (dr["isAcceptBP"].ToString() == "True" && dr["isAccept"].ToString() == string.Empty)      // trạng thái trưởng bộ phận duyệt 
                                sc.ghiChu = "1";
                            sc.ngay = Convert.ToDateTime(dr["ngay"]);
                            sc.ngayYeuCau = Convert.ToDateTime(dr["ngayYeuCau"]);

                            sc.tuGio = (TimeSpan)dr["tuGio"];
                            sc.denGio = (TimeSpan)dr["denGio"];
                            lst.Add(sc);
                        }
                        catch { }
                        #endregion
                        if (dr.RowState == DataRowState.Added)
                        {
                            _lActionClass.Add(new ActionClass("Thêm dữ liệu", dr["EmployeeID"].ToString(), "", "Thêm dữ liệu yêu cầu tăng ca không quẹt từ " + dr["tuGio"].ToString() + " đến " + dr["denGio"].ToString() + " ngày " + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dr["ngay"])), "tbRequestOverTime_KhongQuet"));
                        }
                        if (dr.RowState == DataRowState.Modified && isDuyet == false)
                        {
                            _lActionClass.Add(new ActionClass("Cập nhật dữ liệu", dr["EmployeeID"].ToString(), "", "Cập nhật dữ liệu yêu cầu tăng ca không quẹt từ " + dr["tuGio"].ToString() + " đến " + dr["denGio"].ToString() + " ngày " + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dr["ngay"])), "tbRequestOverTime_KhongQuet"));
                            isDuyet = false;
                        }
                    }
                    else
                    {
                        var empID = (string)dr["EmployeeID", DataRowVersion.Original];
                        var tuGio = (TimeSpan)dr["tuGio", DataRowVersion.Original];
                        var denGio = (TimeSpan)dr["denGio", DataRowVersion.Original];
                        var Ngay = (DateTime)dr["ngay", DataRowVersion.Original];
                        _lActionClass.Add(new ActionClass("Xóa", empID, "", "Xóa dữ liệu yêu cầu tăng ca không quẹt từ " + tuGio.ToString() + " đến " + denGio.ToString() + " ngày " + string.Format("{0: dd/MM/yyyy}", Ngay), "tbRequestOverTime_KhongQuet"));
                    }
                }

                Provider.UpdateData(dt, "tbRequestOverTime_KhongQuet");
                db.SubmitChanges();
                LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();
                #region mail
                try
                {
                    foreach (tbRequestOverTime_KhongQuet l in lst)
                    {

                        //tbRequestEditAttendane
                        tbRequestOverTime_KhongQuet rq = db.tbRequestOverTime_KhongQuets.Where(p => p.EmployeeID == l.EmployeeID && p.ngay == l.ngay && p.ngayYeuCau == l.ngayYeuCau).FirstOrDefault();
                        if (rq == null)
                            continue;
                        w5sysUser u = db.w5sysUsers.Where(p => p.id == rq.idUserRequest).FirstOrDefault();
                        string NoiDung = string.Empty;
                        string TieuDe = "[THUANHAI - iHRM] - Đăng kí tăng ca không quẹt thẻ- ";
                        tblEmployee employee = db.tblEmployees.Where(p => p.EmployeeID == rq.EmployeeID).FirstOrDefault();
                        if (employee == null)
                            continue;
                        //tblEmployee employee = db.tblEmployees.First(p => p.EmployeeID == dcctdh.EmployeeID);
                        TieuDe += employee.EmployeeName + ",";
                        NoiDung += "==========//==========" + "\n";
                        NoiDung += "Mã Nhân viên: " + employee.EmployeeID + "\n";
                        NoiDung += "Tên nhân viên: " + employee.EmployeeName + "\n";
                        NoiDung += "Chức vụ: " + employee.EmpTypeName + "\n";
                        NoiDung += "Phòng ban: " + employee.DepName_Final + "\n";
                        NoiDung += "Nội dung: Đăng ký tăng ca không quẹt thẻ" + "\n";
                        if (l.ghiChu == null)
                            continue;
                        if (int.Parse(l.ghiChu) == 1)
                        {
                            NoiDung += "Trạng thái: Đã duyệt" + "\n";
                        }
                        if (int.Parse(l.ghiChu) == 0)
                        {
                            NoiDung += "Trạng thái: Không duyệt" + "\n";
                        }
                        if (int.Parse(l.ghiChu) == 2)
                        {
                            NoiDung += "Trạng thái: Đăng ký" + "\n";
                        }
                        NoiDung += "Thời gian: Ngày " + string.Format("{0: dd/MM/yyyy}", rq.ngay) + " từ giờ " + string.Format("{0:00}",l.tuGio==null? rq.tuGio.Value.Hours:l.tuGio.Value.Hours) + ":" + string.Format("{0:00}",l.tuGio==null? rq.tuGio.Value.Minutes:l.tuGio.Value.Minutes) + " tới giờ " + string.Format("{0:00}",l.denGio==null? rq.denGio.Value.Hours:l.denGio.Value.Hours) + ":" + string.Format("{0:00}",l.denGio==null? rq.denGio.Value.Minutes:l.denGio.Value.Minutes) + "\n";
                        NoiDung += "iHRM - PSM Toàn Cầu" + "\n";
                        NoiDung += "==========//==========" + "\n";
                        TieuDe += ")";
                        TieuDe = TieuDe.Replace(",)", "");
                        if (u != null)
                        {
                            iHRM.Win.DungChung.Ham.SendMail(TieuDe, NoiDung, u.loginID);
                        }

                    }
                }
                catch { }
                #endregion
                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            toolStripSearch_Click(null, null);
        }

        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dr = grv.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["ngayYeuCau"] = DateTime.Now;
                dr["idUserRequest"] = LoginHelper.user.id;
            }
        }

        private void frmRequestEditAttendanecs_Load(object sender, EventArgs e)
        {
            var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));
            repNhanvien.DataSource = dtnv;
            repNhanvien.DisplayMember = "EmployeeName";
            repNhanvien.ValueMember = "EmployeeCode";

            repUserQL.DataSource = db.w5sysUsers;

            toolStripSearch_Click(null, null);
            if (LoginHelper.user.isAcceptBP == true || LoginHelper.user.isAdmin)
            {
                toolStripAccept.Visible = true;
                toolStripNotAccept.Visible = true;
               
                toolStripAcceptAll.Visible = true;
                toolStripGoDuyet.Visible = true;
                rdAccept.Visible = false;
            }
            else
            {
                toolStripAccept.Visible = false;
                toolStripNotAccept.Visible = false;
                toolStripAcceptAll.Visible = false;
                toolStripGoDuyet.Visible = false;
                rdAccept.Visible = true;
            }
            if (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin)
            {
                toolStripAccept_DA.Visible = true;
                toolStripNotAccept_DA.Visible = true;
                toolStripGoDuyetChotCong.Visible = true;
                rdAccept.Visible = true;
                //toolStripButton_KhoaHan.Visible = true;
            }
            else
            {
                toolStripAccept_DA.Visible = false;
                toolStripNotAccept_DA.Visible = false;
                toolStripGoDuyetChotCong.Visible = false;
                rdAccept.Visible = false;
                //toolStripButton_KhoaHan.Visible = false;
            }
            _lActionClass.Clear();
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?", "Duyệt tất cả các yêu cầu đang chọn", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);
                frm.ShowDialog();
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}

                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công không thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt không thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["loaiDangKy"].ToString() == "Ngoài kế hoạch" && r["dataFile"] == DBNull.Value && !LoginHelper.user.isAdmin)
                        {
                            GUIHelper.MessageBox("Không được duyệt loại đăng ký Ngoài kế hoạch mà không có văn bản.", "Đính kèm văn bản");
                            continue;
                        }

                        r["isAcceptBP"] = true;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Duyệt", r["EmployeeID"].ToString(), "", "Duyệt dữ liệu yêu cầu tăng ca không quẹt thẻ", "tbRequestOverTime_KhongQuet"));
                        isDuyet = true;
                    }
                }
            }
        }
        private void grv_ShowingEditor(object sender, CancelEventArgs e)
        {
            var a = grv.FocusedColumn;
            DataRow r = grv.GetFocusedDataRow();
            if (r != null && (r["isAcceptBP"] != DBNull.Value || r["isHetHan"] != DBNull.Value))
            {
                if (a != grColDinhKem)
                {
                    e.Cancel = true;
                }
            }
        }

        private void toolStripNotAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu đang chọn?", "Không duyệt tất cả các yêu cầu đang chọn", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(false);
                frm.ShowDialog();

                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công không thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt không thể thao tác!");
                            continue;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["loaiDangKy"].ToString() == "Ngoài kế hoạch" && r["dataFile"] == DBNull.Value && !LoginHelper.user.isAdmin)
                        {
                            GUIHelper.MessageBox("Không được duyệt loại đăng ký Ngoài kế hoạch mà không có văn bản đính kèm.", "Đính kèm văn bản");
                            continue;
                        }

                        r["isAcceptBP"] = false;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Không duyệt chốt công", r["EmployeeID"].ToString(), "", "Không duyệt dữ liệu yêu cầu tăng ca không quẹt thẻ", "tbRequestOverTime_KhongQuet"));
                        isDuyet = true;
                    }
                }
            }
        }

        private void grv_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {

        }

        private void toolStripAcceptAll_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu?", "Duyệt tất cả các yêu cầu", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);
                frm.ShowDialog();

                for (int i = 0; i < grv.DataRowCount; i++)
                {
                    var r = grv.GetDataRow(i);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công không thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt không thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["loaiDangKy"].ToString() == "Ngoài kế hoạch" && r["dataFile"] == DBNull.Value && !LoginHelper.user.isAdmin)
                        {
                            GUIHelper.MessageBox("Không được duyệt loại đăng ký Ngoài kế hoạch mà không có văn bản.", "Đính kèm văn bản");
                            continue;
                        }
                        if (r["isAcceptBP"] == DBNull.Value)
                        {
                            r["isAcceptBP"] = true;
                            r["userAcceptBP"] = LoginHelper.user.id;
                            r["ngayAcceptBP"] = DateTime.Now;
                            r["ghiChuAcceptBP"] = frm.reason;
                            _lActionClass.Add(new ActionClass("Duyệt tất cả", r["EmployeeID"].ToString(), "", "Duyệt tất cả dữ liệu yêu cầu tăng ca không quẹt thẻ", "tbRequestOverTime_KhongQuet"));
                            isDuyet = true;
                        }
                    }
                }
            }
        }

        private void grv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colEmpID)
            {
                if (e.Value != null && !AllLogic.checkEmployeeIDInDep(e.Value.ToString(), LoginHelper.user.idKhoiPB))
                {
                    GUIHelper.MessageError("Mã nhân viên bạn vừa nhập không nằm trong phòng ban của bạn. Mời nhập lại");
                }
                if (e.Value != null)
                {
                    var emp = db.tblEmployees.FirstOrDefault(p => p.EmployeeID == e.Value.ToString());
                    if (emp != null)
                    {
                        grv.SetRowCellValue(e.RowHandle, colEmployeeName, emp.EmployeeName);
                    }
                }
            }
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các yêu cầu đang chọn?", "Xóa tất cả các yêu cầu đang chọn", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {

                int[] rc = grv.GetSelectedRows();
                for(int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        var isOK = true;
                        if (IsLock.IsLock.Check_IsLock("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString())))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            isOK = false;
                            continue;
                        }
                      
                        if (r["isAcceptBP"] != DBNull.Value)
                        {
                            isOK = false;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            isOK = false;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            isOK = false;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            isOK = false;
                        }
                        if (!isOK)
                        {
                            GUIHelper.Notifications("Không thể xóa vì bản ghi này đã được duyệt hoặc không thuộc phòng ban của bạn.", "Xóa tất cả các yêu cầu đang chọn", GUIHelper.NotifiType.error);
                        }
                        else
                        {
                            grv.DeleteRow(rc[i - 1]);
                        }
                    }
                }
                //foreach (int rowhandler in grv.GetSelectedRows())
                //{
                //    var r = grv.GetDataRow(rowhandler);
                //    if (r != null)
                //    {
                //        var isOK = true;
                //        if (r["isAcceptBP"] != DBNull.Value)
                //        {
                //            isOK = false;
                //        }
                //        if (r["isAccept"] != DBNull.Value)
                //        {
                //            isOK = false;
                //        }
                //        if (r["isHetHan"] != DBNull.Value)
                //        {
                //            isOK = false;
                //        }
                //        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                //        {
                //            isOK = false;
                //        }
                //        if (!isOK)
                //        {
                //            GUIHelper.Notifications("Không thể xóa vì bản ghi này đã được duyệt hoặc không thuộc phòng ban của bạn.", "Xóa tất cả các yêu cầu đang chọn", GUIHelper.NotifiType.error);
                //        }
                //        else
                //        {
                //            grv.DeleteRow(rowhandler);
                //        }
                //    }
                //}
            }
        }

        private void grv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = grv.GetDataRow(e.RowHandle);
            if (r != null && r.RowState != DataRowState.Unchanged)
            {
                if (r["EmployeeID"] == DBNull.Value || r["EmployeeID"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập mã nhân viên.\n");
                    e.Valid = false;
                    return;
                }
                else
                {
                    if (!AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB))
                    {
                        e.ErrorText = ("Mã nhân viên bạn nhập không nằm trong phòng ban của bạn.");
                        e.Valid = false;
                        return;

                    }
                }
                if (r["ngay"] == DBNull.Value || r["ngay"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập ngày.\n");
                    e.Valid = false;
                    return;
                }
                if (r["tuGio"] == DBNull.Value || r["tuGio"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập Từ Giờ.\n");
                    e.Valid = false;
                    return;
                }
                if (r["denGio"] == DBNull.Value || r["tuGio"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập Đến Giờ.\n");
                    e.Valid = false;
                    return;
                }
                if (r["loaiDangKy"] == DBNull.Value || r["loaiDangKy"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập loại đăng ký.\n");
                    e.Valid = false;
                    return;
                }

                //if (IsLock.IsLock.Check_IsLock("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString())))
                //{
                //    e.ErrorText = ("Dữ liệu đã chốt công khổng thể thao tác!\n");
                //    e.Valid = false;
                //    return;
                //}
                if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()),1))
                {
                    e.ErrorText = ("Dữ liệu đã chốt công không thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
                if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()), 2))
                {
                    e.ErrorText = ("Dữ liệu đã chốt đăng ký mới không thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
            }
            if (r != null && r.RowState == DataRowState.Unchanged)
            {

                var ngay = (DateTime)r["ngay", DataRowVersion.Original];

                if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()), 1))
                {
                    e.ErrorText = ("Dữ liệu đã chốt công khổng thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
                if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()), 2))
                {
                    e.ErrorText = ("Dữ liệu đã chốt đăng ký mới không thể thao tác!\n");
                    e.Valid = false;
                    return;
                }

                if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", ngay, 1))
                {
                    e.ErrorText = ("Dữ liệu đã chốt công khổng thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
                if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", ngay, 2))
                {
                    e.ErrorText = ("Dữ liệu đã chốt đăng ký mới không thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
            }
        }

        private void grv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "isAcceptBP") != null && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()))
            {
                if (grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString() == "True")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else if (grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString() == "False")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
            if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "ngay") != null && string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()) && string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isHetHan").ToString()))
            {
                TimeSpan date = Convert.ToDateTime(DateTime.Now) - Convert.ToDateTime(grv.GetRowCellValue(e.RowHandle, "ngay").ToString());
                if (date.Days >= 5 && (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin))
                {
                    e.Appearance.ForeColor = Color.MediumBlue;
                }
            }
        }

        private void toolStripNotAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu đang chọn?", "Không duyệt yêu cầu tăng ca", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(false);
                frm.ShowDialog();

                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if ((r["isAcceptBP"] as bool? != true))
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAccept"] = false;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Không duyệt chốt công", r["EmployeeID"].ToString(), "", "Không duyệt chốt công dữ liệu yêu cầu tăng ca không quẹt thẻ", "tbRequestOverTime_KhongQuet"));
                        isDuyet = true;
                    }
                }
            }
        }

        private void toolStripAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?", "Duyệt yêu cầu tăng ca", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);
                frm.ShowDialog();

                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if ((r["isAcceptBP"] as bool? != true))
                        {
                            continue;
                        }
                        if ((r["isAccept"] as bool? == true))
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAccept"] = true;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Duyệt chốt công", r["EmployeeID"].ToString(), "", "Duyệt chốt công dữ liệu yêu cầu tăng ca không quẹt thẻ", "tbRequestOverTime_KhongQuet"));
                        isDuyet = true;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmRequestEditAttendanecs_Load(null, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            grv.OptionsPrint.UsePrintStyles = false;
            ShowPreview(grd);
            //ExportGrid(grd);
        }

        private void grv_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column == colAcceptDA && e.CellValue != null)
            {
                if (e.CellValue.ToString() == "Đã duyệt")
                {
                    e.Appearance.BackColor = Color.MediumSpringGreen;
                }
                else if (e.CellValue.ToString() == "Không duyệt")
                {
                    e.Appearance.BackColor = Color.NavajoWhite;
                }
            }
            if (e.Column == colisHetHan && e.CellValue != null)
            {
                if (e.CellValue.ToString() == "Hết hạn")
                {
                    e.Appearance.BackColor = Color.NavajoWhite;
                }
            }
        }

        private void toolStripButton_KhoaHan_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn khóa đăng ký đang chọn?", "Khóa đăng ký", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if ((r["isAccept"] != DBNull.Value))
                        {
                            continue;
                        }
                        if ((r["isAcceptBP"] != DBNull.Value))
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            r["isHetHan"] = DBNull.Value;
                            r["userHetHan"] = LoginHelper.user.id;
                            r["ngayHetHan"] = DateTime.Now;
                        }
                        else
                        {
                            r["isHetHan"] = true;
                            r["userHetHan"] = LoginHelper.user.id;
                            r["ngayHetHan"] = DateTime.Now;
                        }
                        _lActionClass.Add(new ActionClass("Khóa hạn", r["EmployeeID"].ToString(), "", "Khóa hạn dữ liệu yêu cầu tăng ca không quẹt thẻ", "tbRequestOverTime_KhongQuet"));
                        isDuyet = true;
                    }
                }
            }
        }

        private void repNhanvien_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            this.grv.SetFocusedRowCellValue(colDepName_Final, searchEdit.Properties.View.GetFocusedRowCellValue("DepName_Final"));
            this.grv.SetFocusedRowCellValue(colMaNV, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeCode"));
            this.grv.SetFocusedRowCellValue(colEmployeeName, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeName"));
        }

        private void toolStripGoDuyet_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ bỏ đăng ký đang chọn?", "Khóa đăng ký", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOverTime_KhongQuet",Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công không thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt không thể thao tác!");
                            continue;
                        }
                        if ((r["isAccept"] != DBNull.Value))
                        {
                            continue;
                        }
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            //r["isHetHan"] = DBNull.Value;
                            continue;
                        }
                        if ((r["isAcceptBP"] == DBNull.Value))
                        {
                            continue;
                        }
                        if ((Convert.ToDouble(r["userAcceptBP"].ToString()) != LoginHelper.user.id))
                        {
                            continue;
                        }

                        r["isAcceptBP"] = DBNull.Value;
                        r["userAcceptBP"] = DBNull.Value;
                        r["ngayAcceptBP"] = DBNull.Value;
                        r["ghiChuAcceptBP"] = DBNull.Value;

                        r["isGoBo"] = true;
                        r["userGoBo"] = LoginHelper.user.id;
                        r["ngayGoBo"] = DateTime.Now;
                        _lActionClass.Add(new ActionClass("Gỡ duyệt", r["EmployeeID"].ToString(), "", "Gỡ duyệt dữ liệu yêu cầu tăng ca không quẹt thẻ", "tbRequestOverTime_KhongQuet"));
                        isDuyet = true;
                    }
                }
            }
        }

        private void grv_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colNgay && e.Value != null)
                {
                    string MaNV = string.Empty;
                    MaNV = this.grv.GetFocusedRowCellValue(colMaNV).ToString();

                    if (MaNV.Trim() == string.Empty || MaNV.Trim() == null)
                    {
                        GUIHelper.MessageBox("Vui lòng chọn nhân viên trước!\n");
                        return;
                    }
                    DateTime Ngay = DateTime.Now;
                    Ngay = Convert.ToDateTime(e.Value.ToString());

                    var dtnv = Provider.ExecuteDataTableReader("p_gettbCaLamViec",
                                                    new SqlParameter("MaNV", MaNV),
                                                       new SqlParameter("Ngay", Ngay));
                    if (dtnv.Rows.Count < 1)
                    {
                        this.grv.SetFocusedRowCellValue(colTenCaLam, string.Empty);
                    }
                    else
                    {
                        this.grv.SetFocusedRowCellValue(colTenCaLam, dtnv.Rows[0][0].ToString());
                    }
                }
            }
            catch
            {
                this.grv.SetFocusedRowCellValue(colTenCaLam, string.Empty);
            }
        }

        private void toolStripGoDuyetChotCong_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ duyệt chốt công đăng ký đang chọn?", "Gỡ duyệt chốt công đăng ký", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOverTime_KhongQuet", Convert.ToDateTime(r["ngay"].ToString()), 1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công không thể thao tác!");
                            continue;
                        }
                        if ((r["isAccept"] == DBNull.Value))
                        {
                            continue;
                        }
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            continue;
                        }
                      
                        if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                        {
                            continue;
                        }

                        r["isAccept"] = DBNull.Value;
                        r["userAccept"] = DBNull.Value;
                        r["ngayAccept"] = DBNull.Value;
                        r["ghiChuAccept"] = DBNull.Value;
                        _lActionClass.Add(new ActionClass("Gỡ duyệt", r["EmployeeID"].ToString(), "", "Gỡ duyệt chốt công dữ liệu yêu cầu tăng ca không quẹt thẻ", "tbRequestOverTime_KhongQuet"));
                        isDuyet = true;
                    }
                }
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

        private void frmRequestOverTime_KhongQuet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                return;
            }
            else
            {
                var dg = MessageBox.Show("Bạn có muốn lưu dữ liệu đã thao tác!", "Lưu tất cả các yêu cầu", MessageBoxButtons.YesNoCancel);

                if (dg == DialogResult.Yes)
                {
                    toolStripLuu_Click(null, null);
                }
                else if (dg == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
