using DevExpress.XtraGrid.Views.Grid;
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
using iHRM.Win.Frm.LogAction;
using System.Collections.Generic;
using DevExpress.XtraGrid;

namespace iHRM.Win.Frm.Employee
{
    public partial class frmDieuChuyenNV : frmBase
    {
        DataTable dt = new DataTable();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        List<ActionClass> _lActionClass = new List<ActionClass>();
        public frmDieuChuyenNV()
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
            dt = Provider.ExecuteDataTable("p_getDieuChuyen_byStrEmp",
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
            DateTime NgayHieuLuc = DateTime.Now;
            List<tbDieuChuyen> lst = new List<tbDieuChuyen>();
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

                        #region set data send mail
                        try
                        {
                            tbDieuChuyen dc = new tbDieuChuyen();
                            dc.EmployeeID = dr["EmployeeID"].ToString();
                            if (dr["isAcceptBP"].ToString() == string.Empty && dr["isGoBo"].ToString() == string.Empty && dr.RowState == DataRowState.Added) //trạng thái đăn kí
                                dc.ghiChu = "2";
                            if (dr["isAcceptBP"].ToString() == "False" && dr["isAccept"].ToString() == string.Empty)     //trạng thái trưởng bộ phân không duyệt
                                dc.ghiChu = "0";
                            if (dr["isAcceptBP"].ToString() == "True" && dr["isAccept"].ToString() == string.Empty)      // trạng thái trưởng bộ phận duyệt 
                                dc.ghiChu = "1";
                            dc.NgayHieuLuc = Convert.ToDateTime(dr["NgayHieuLuc"]);
                            lst.Add(dc);
                        }
                        catch { }
                        #endregion

                        idUserRequests = long.Parse(dr["idUserRequest"].ToString());
                        if (dr.RowState == DataRowState.Added)
                        {
                            _lActionClass.Add(new ActionClass("Thêm dữ liệu", dr["EmployeeID"].ToString(), "", "Thêm dữ liệu điều chuyển nhân viên " + dr["EmployeeID"].ToString(), "tbDieuChuyen"));
                        }
                    }
                    else
                    {
                        var empID = (string)dr["EmployeeID", DataRowVersion.Original];
                        _lActionClass.Add(new ActionClass("Xóa dữ liệu", empID, "", "Xóa dữ liệu điều chuyển nhân viên " + empID, "tbDieuChuyen"));
                    }
                    Provider.UpdateData(dt, "tbDieuChuyen"); _lActionClass.Clear();
                }

                #region send mail
                try
                {
                    foreach (tbDieuChuyen dc in lst)
                    {
                        //tbDieuChuyen
                        tbDieuChuyen rq = db.tbDieuChuyens.Where(p => p.EmployeeID == dc.EmployeeID && p.NgayHieuLuc == dc.NgayHieuLuc).FirstOrDefault();
                        if (rq == null)
                            continue;
                        w5sysUser u = db.w5sysUsers.Where(p => p.id == rq.idUserRequest).FirstOrDefault();
                        if (u == null)
                            continue;
                        string NoiDung = string.Empty;
                        string TieuDe = "[THUANHAI - iHRM] - Đăng kí điều chuyển nhân viên - ";
                        tblEmployee employee = db.tblEmployees.Where(p => p.EmployeeID == rq.EmployeeID).FirstOrDefault();
                        tblRef_Department dep_Cu = db.tblRef_Departments.Where(p => p.DepID == rq.DepId_Cu).FirstOrDefault();
                        tblRef_Department dep_Moi = db.tblRef_Departments.Where(p => p.DepID == rq.DepId_Moi).FirstOrDefault();

                        if (employee == null)
                            continue;

                        TieuDe += employee.EmployeeName + ",";
                        NoiDung += "==========//==========" + "\n";
                        NoiDung += "Mã Nhân viên: " + employee.EmployeeID + "\n";
                        NoiDung += "Tên nhân viên: " + employee.EmployeeName + "\n";
                        NoiDung += "Chức vụ: " + employee.EmpTypeName + "\n";
                        NoiDung += "Phòng ban: " + employee.DepName_Final + "\n";
                        NoiDung += "Nội dung: Đăng kí điều chuyển nhân viên" + "\n";
                        if (dc.ghiChu == null)
                            continue;
                        if (int.Parse(dc.ghiChu) == 1)
                        {
                            NoiDung += "Trạng thái: Đã duyệt" + "\n";
                        }
                        if (int.Parse(dc.ghiChu) == 0)
                        {
                            NoiDung += "Trạng thái: Không duyệt" + "\n";
                        }
                        if (int.Parse(dc.ghiChu) == 2)
                        {
                            NoiDung += "Trạng thái: Đăng ký" + "\n";
                        }
                        NoiDung += "Thời gian: Ngày có hiệu lực" + string.Format("{0: dd/MM/yyyy}", rq.NgayHieuLuc) + " từ phòng ban " + dep_Cu.DepName + " đến phòng ban " + dep_Moi.DepName + "\n";
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
                catch
                { }
                #endregion

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception ex)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            frmRequestEditAttendanecs_Load(null, null);
        }

        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dr = grv.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["DateRequest"] = DateTime.Now;
                dr["idUserRequest"] = LoginHelper.user.id;
                dr["isTransfer"] = 0;
            }
        }

        private void frmRequestEditAttendanecs_Load(object sender, EventArgs e)
        {
            var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));
            repNhanvien.DataSource = dtnv;
            repNhanvien.DisplayMember = "EmployeeName";
            repNhanvien.ValueMember = "EmployeeCode";

            var dtpb = db.tblRef_Departments;
            repPhongBan.DataSource = dtpb;
            repPhongBan.DisplayMember = "DepName";
            repPhongBan.ValueMember = "DepID";

            repQLDuyet.DataSource = db.w5sysUsers;

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
                rdAccept.Visible = true;
                toolStripButton_KhoaHan.Visible = true;
                toolDctay.Visible = true;
            }
            else
            {
                toolStripAccept_DA.Visible = false;
                toolStripNotAccept_DA.Visible = false;
                rdAccept.Visible = false;
                toolStripButton_KhoaHan.Visible = false;
                toolDctay.Visible = false;
            }
            _lActionClass.Clear();
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?", "Duyệt tất cả các yêu cầu đang chọn", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                QuetThe.dlgLyDoDuyet frm = new QuetThe.dlgLyDoDuyet(true);
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
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        r["isAcceptBP"] = true;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;

                        _lActionClass.Add(new ActionClass("Duyệt", r["EmployeeID"].ToString(), "", "Duyệt điều chuyển nhân viên", "tbDieuChuyen"));
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

                QuetThe.dlgLyDoDuyet frm = new QuetThe.dlgLyDoDuyet(false);
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
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAcceptBP"] = false;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Không duyệt", r["EmployeeID"].ToString(), "", "Không duyệt điều chuyển nhân viên", "tbDieuChuyen"));
                    }
                }
            }
        }

        private void toolStripAcceptAll_Click(object sender, EventArgs e)
        {

            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu?", "Duyệt tất cả các yêu cầu", MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                QuetThe.dlgLyDoDuyet frm = new QuetThe.dlgLyDoDuyet(true);
                frm.ShowDialog();

                for (int i = 0; i < grv.DataRowCount; i++)
                {
                    var r = grv.GetDataRow(i);
                    if (r != null)
                    {
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }

                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["isAcceptBP"] == DBNull.Value)
                        {
                            r["isAcceptBP"] = true;
                            r["userAcceptBP"] = LoginHelper.user.id;
                            r["ngayAcceptBP"] = DateTime.Now;
                            r["ghiChuAcceptBP"] = frm.reason;
                        }
                        _lActionClass.Add(new ActionClass("Duyệt tất cả", r["EmployeeID"].ToString(), "", "Duyệt tất cả điều chuyển nhân viên", "tbDieuChuyen"));
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
                //if (e.Value != null)
                //{
                //    var emp = db.tblEmployees.FirstOrDefault(p => p.EmployeeID == e.Value.ToString());
                //    if (emp != null)
                //    {
                //        grv.SetRowCellValue(e.RowHandle, grColTenNV, emp.EmployeeName);
                //    }
                //}
            }
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các yêu cầu đang chọn?", "Xóa tất cả các yêu cầu đang chọn", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();
                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        var isOK = true;
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
                        e.ErrorText = ("Mã nhân viên bạn nhập không nằm trong phòng ban của bạn.\n");
                        e.Valid = false;
                        return;

                    }
                }
                if (r["NgayHieuLuc"] == DBNull.Value || r["NgayHieuLuc"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập ngày có hiệu lực.\n");
                    e.Valid = false;
                    return;
                }
                if (r["SoQD"] == DBNull.Value || r["SoQD"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập số quyết định.\n");
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

                QuetThe.dlgLyDoDuyet frm = new QuetThe.dlgLyDoDuyet(false);
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
                        if ((r["isAcceptBP"] as bool? != true))
                        {
                            continue;
                        }
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            continue;
                        }

                        r["isAccept"] = false;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Không duyệt chốt điều chuyển", r["EmployeeID"].ToString(), "", "Không duyệt chốt điều chuyển nhân viên", "tbDieuChuyen"));
                    }
                }
            }
        }

        private void toolStripAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?", "Duyệt yêu cầu", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                QuetThe.dlgLyDoDuyet frm = new QuetThe.dlgLyDoDuyet(true);
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
                        if ((r["isAcceptBP"] as bool? != true))
                        {
                            continue;
                        }
                        if ((r["isAccept"] as bool? == true))
                        {
                            continue;
                        }
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            continue;
                        }
                        r["isAccept"] = true;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Duyệt chốt điều chuyển", r["EmployeeID"].ToString(), "", "Duyệt chốt điều chuyển nhân viên", "tbDieuChuyen"));
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
                        _lActionClass.Add(new ActionClass("Khóa hạn", r["EmployeeID"].ToString(), "", "Khóa hạn điều chuyển nhân viên", "tbDieuChuyen"));
                    }
                }
            }
        }

        private void repNhanvien_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            this.grv.SetFocusedRowCellValue(colDepId_Cu, searchEdit.Properties.View.GetFocusedRowCellValue("DepID_Final"));
            this.grv.SetFocusedRowCellValue(colMaNV, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeCode"));
            this.grv.SetFocusedRowCellValue(colEmployeeName, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeName"));
        }

        private void toolStripDoDuyet_Click(object sender, EventArgs e)
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
                        if ((r["isAccept"] != DBNull.Value))
                        {
                            continue;
                        }
                        if ((r["isHetHan"] != DBNull.Value))
                        {
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
                        _lActionClass.Add(new ActionClass("Gỡ duyệt", r["EmployeeID"].ToString(), "", "Gỡ duyệt điều chuyển nhân viên", "tbDieuChuyen"));
                    }
                }
            }
        }

        private void toolDctay_Click(object sender, EventArgs e)
        {
            try
            {
                Provider.ExecuteNonQuery("AutoDieuChuyenNV");
            }
            catch (Exception ex)
            { }
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

                        _lActionClass.Add(new ActionClass("Gỡ duyệt", r["EmployeeID"].ToString(), "", "Gỡ duyệt chốt công đăng ký điều chuyển nhân viên", "tbDieuChuyen"));
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
    }
}
