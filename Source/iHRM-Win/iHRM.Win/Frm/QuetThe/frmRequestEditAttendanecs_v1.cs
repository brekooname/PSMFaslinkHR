using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
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
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.FileDB;
using DevExpress.XtraEditors;
using System.Reflection;
using iHRM.Win.Frm.LogAction;
using System.Collections.Generic;
using DevExpress.XtraGrid;

namespace iHRM.Win.Frm.QuetThe
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class frmRequestEditAttendanecs_v1 : frmBase
    {
        DataTable dt = new DataTable();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        List<ActionClass> _lActionClass = new List<ActionClass>();

        bool isDuyet = false;

        public frmRequestEditAttendanecs_v1()
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

                        _lActionClass.Add(new ActionClass("Cập nhật"
                                                            , dr["EmployeeID"].ToString()
                                                            , ""
                                                            , "Chọn file mới"
                                                            , "tbRequestOverTime")); // Chưa đổi tên
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

            dt = Provider.ExecuteDataTable("p_getRequestEditAttendane",
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

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            frmRequestEditAttendanecs_v1_Load(null, null);
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

        private void frmRequestEditAttendanecs_v1_Load(object sender, EventArgs e)
        {
            TranlateForm();
            var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name"
                                                        , new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));

            repNhanVien.DataSource = dtnv;

            repNhanVien.DisplayMember = "EmployeeName";

            repNhanVien.ValueMember = "EmployeeCode";

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

                toolStripGoDuyetChotCong.Visible = true;

                rdAccept.Visible = true;
            }
            else
            {
                toolStripAccept_DA.Visible = false;

                toolStripNotAccept_DA.Visible = false;

                toolStripGoDuyetChotCong.Visible = false;

                rdAccept.Visible = false;
            }

            _lActionClass.Clear();
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?", "Duyệt yêu cầu sửa công", MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);

                frm.ShowDialog();

                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);

                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}

                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                            continue;
                        }


                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");

                            continue;
                        }

                        if (LoginHelper.user.idKhoiPB != null 
                            && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }

                        if (AllLogic.checkDkSuaCong(r["EmployeeID"].ToString(), Convert.ToDateTime(r["ngay"]), 2))
                        {
                            GUIHelper.MessageError(r["EmployeeID"].ToString() + " một ngày chỉ được phép sửa công một lần.\n" + string.Format(" Ngày {0:dd/MM/yyyy}", r["ngay"]));

                            continue;
                        }

                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }

                        //if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        //{
                        //    continue;
                        //}

                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAcceptBP"] = true;

                        r["userAcceptBP"] = LoginHelper.user.id;

                        r["ngayAcceptBP"] = DateTime.Now;

                        r["ghiChuAcceptBP"] = frm.reason;

                        _lActionClass.Add(new ActionClass("Duyệt chốt công"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Duyệt yêu cầu sửa công"
                                                            , "tbRequestEditAttendane"));
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
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu đang chọn?", "Không duyệt yêu cầu sửa công", MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(false);

                frm.ShowDialog();

                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");
                            continue;
                        }
                        if (AllLogic.checkDkSuaCong(r["EmployeeID"].ToString(), Convert.ToDateTime(r["ngay"]), 2))
                        {
                            GUIHelper.MessageError(r["EmployeeID"].ToString() + " một ngày chỉ được phép sửa công một lần.\n" + string.Format(" Ngày {0:dd/MM/yyyy}", r["ngay"]));
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
                        //if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        //{
                        //    continue;
                        //}
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        r["isAcceptBP"] = false;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Không duyệt", r["EmployeeID"].ToString(), "", "Không duyệt yêu cầu sửa công", "tbRequestEditAttendane"));
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
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu?", "Duyệt yêu cầu sửa công", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);
                frm.ShowDialog();
                for (int i = 0; i < grv.DataRowCount; i++)
                {
                    var r = grv.GetDataRow(i);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if (AllLogic.checkDkSuaCong(r["EmployeeID"].ToString(), Convert.ToDateTime(r["ngay"]), 2))
                        {
                            GUIHelper.MessageError(r["EmployeeID"].ToString() + " một ngày chỉ được phép sửa công một lần.\n" + string.Format(" Ngày {0:dd/MM/yyyy}", r["ngay"]));
                            continue;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        //if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        //{
                        //    continue;
                        //}
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
                            _lActionClass.Add(new ActionClass("Duyệt tất cả", r["EmployeeID"].ToString(), "", "Duyệt tất cả yêu cầu sửa công", "tbRequestEditAttendane"));
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
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các yêu cầu đang chọn?", "Xóa yêu cầu sửa công", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();
                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        var isOK = true;
                        if (IsLock.IsLock.Check_IsLock("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString())))
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
            }
        }

        private void grv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = grv.GetDataRow(e.RowHandle);
            if (r != null && r.RowState != DataRowState.Unchanged)
            {
                if (r["EmployeeID"] == DBNull.Value || r["EmployeeID"].ToString() == "")
                {
                    e.ErrorText = "Bạn cần phải nhập mã nhân viên.\n";
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
                if (r["ngay"] == DBNull.Value || r["ngay"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập ngày.");
                    e.Valid = false;
                    return;
                }
                if (r["gioVao_Request"] == DBNull.Value || r["gioVao_Request"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập giờ vào yêu cầu.\n");
                    e.Valid = false;
                    return;
                }
                if (r["gioRa_Request"] == DBNull.Value || r["gioRa_Request"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập ra yêu cầu.\n");
                    e.Valid = false;
                    return;
                }
                //if (IsLock.IsLock.Check_IsLock("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString())))
                //{
                //    e.ErrorText = ("Dữ liệu đã chốt công khổng thể thao tác!\n");
                //    e.Valid = false;
                //    return;
                //}
                if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()),1))
                {
                    e.ErrorText = ("Dữ liệu đã chốt công khổng thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
                if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()), 2))
                {
                    e.ErrorText = ("Dữ liệu đã chốt đăng ký mới không thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
            }
            if (r != null && r.RowState == DataRowState.Unchanged)
            {

                var ngay = (DateTime)r["ngay", DataRowVersion.Original];

                if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()), 1))
                {
                    e.ErrorText = ("Dữ liệu đã chốt công khổng thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
                if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()), 2))
                {
                    e.ErrorText = ("Dữ liệu đã chốt đăng ký mới không thể thao tác!\n");
                    e.Valid = false;
                    return;
                }

                if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", ngay, 1))
                {
                    e.ErrorText = ("Dữ liệu đã chốt công khổng thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
                if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", ngay, 2))
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
            //if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "ngay") != null && string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()) && string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isHetHan").ToString()))
            //{
            //    TimeSpan date = Convert.ToDateTime(DateTime.Now) - Convert.ToDateTime(grv.GetRowCellValue(e.RowHandle, "ngay").ToString());
            //    //if (date.Days >= 5 && (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin))
            //    //{
            //    //    e.Appearance.ForeColor = Color.MediumBlue;
            //    //}
            //}
        }

        private void toolStripAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?", "Duyệt yêu cầu sửa công", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);
                frm.ShowDialog();

                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if (AllLogic.checkDkSuaCong(r["EmployeeID"].ToString(), Convert.ToDateTime(r["ngay"]), 2))
                        {
                            GUIHelper.MessageError(r["EmployeeID"].ToString() + " một ngày chỉ được phép sửa công một lần.\n" + string.Format(" Ngày {0:dd/MM/yyyy}", r["ngay"]));
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
                        _lActionClass.Add(new ActionClass("Duyệt chốt công", r["EmployeeID"].ToString(), "", "Duyệt chốt công yêu cầu sửa công", "tbRequestEditAttendane"));
                        isDuyet = true;
                    }
                }
            }
        }

        private void toolStripNotAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu đang chọn?", "Không duyệt yêu cầu sửa công", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(false);
                frm.ShowDialog();

                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (AllLogic.checkDkSuaCong(r["EmployeeID"].ToString(), Convert.ToDateTime(r["ngay"]), 2))
                        {
                            GUIHelper.MessageError(r["EmployeeID"].ToString() + " một ngày chỉ được phép sửa công một lần.\n" + string.Format(" Ngày {0:dd/MM/yyyy}", r["ngay"]));
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
                        _lActionClass.Add(new ActionClass("Không duyệt chốt công", r["EmployeeID"].ToString(), "", "Không duyệt chốt công yêu cầu sửa công", "tbRequestEditAttendane"));
                        isDuyet = true;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmRequestEditAttendanecs_v1_Load(null, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            grv.OptionsPrint.UsePrintStyles = false;
            ShowPreview(grd);
            //ExportGrid(grd);
        }
        private void grv_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
        }

        private void toolStripButton_KhoaHan_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn khóa đăng ký đang chọn?", "Khóa đăng ký", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()),1))
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
                        _lActionClass.Add(new ActionClass("Khóa hạn", r["EmployeeID"].ToString(), "", "Khóa hạn yêu cầu sửa công", "tbRequestEditAttendane"));
                        isDuyet = true;
                    }
                }
            }
        }

        private void repNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            this.grv.SetFocusedRowCellValue(colDepName_Final, searchEdit.Properties.View.GetFocusedRowCellValue("DepName_Final"));
            this.grv.SetFocusedRowCellValue(colMaNV, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeCode"));
            this.grv.SetFocusedRowCellValue(colEmployeeName, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeName"));
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ bỏ đăng ký đang chọn?", "Khóa đăng ký", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");
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
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            //r["isHetHan"] = DBNull.Value;

                            //r["isGoBo"] = true;
                            //r["userGoBo"] = LoginHelper.user.id;
                            //r["ngayGoBo"] = DateTime.Now;
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
                        _lActionClass.Add(new ActionClass("Gỡ duyệt", r["EmployeeID"].ToString(), "", "Gỡ duyệt yêu cầu sửa công", "tbRequestEditAttendane"));
                        isDuyet = true;
                    }
                }
            }
        }

        private void toolStripGoDuyetChotCong_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ bỏ duyệt chốt công đăng ký đang chọn?", "Gỡ duyệt chốt công đăng ký", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(r["ngay"].ToString()), 1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
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

                        _lActionClass.Add(new ActionClass("Gỡ duyệt", r["EmployeeID"].ToString(), "", "Gỡ duyệt chốt công yêu cầu sửa công", "tbRequestEditAttendane"));
                        isDuyet = true;
                    }
                }
            }
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

            DateTime ngay = DateTime.Now;

            DateTime ngayYeuCau = DateTime.Now;

            List<tbRequestEditAttendane> lst = new List<tbRequestEditAttendane>();

            try
            {
                foreach (DataRow dr in dt.GetChanges().Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if (dr["gioVao_Request"] == DBNull.Value || dr["gioVao_Request"].ToString() == "")
                        {
                            GUIHelper.MessageError("Bạn cần phải nhập giờ vào yêu cầu.\n");

                            return;
                        }

                        if (dr["gioRa_Request"] == DBNull.Value || dr["gioRa_Request"].ToString() == "")
                        {
                            GUIHelper.MessageError("Bạn cần phải nhập ra yêu cầu.\n");

                            return;
                        }

                        if (dr.RowState == DataRowState.Added)
                        {
                            if (AllLogic.checkDkSuaCong(dr["EmployeeID"].ToString(), Convert.ToDateTime(dr["ngay"]), 1))
                            {
                                GUIHelper.MessageError(dr["EmployeeID"].ToString() + " một ngày chỉ được phép sửa công một lần.\n" + string.Format(" Ngày {0:dd/MM/yyyy}", dr["ngay"]));

                                return;
                            }
                        }

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

                        #region: Đăng ký tăng ca (tạm thời không dùng) '15-01-2019'
                        //if (dr["isAccept"] != null && dr["isAccept"].ToString() != "")
                        //{
                        //    if (dr["isAccept"] as bool? == true)
                        //    {
                        //        DataTable _tb = new DataTable();

                        //        _tb = Provider.ExecuteDataTable("p_GetCaLam"
                        //                                        , new SqlParameter("@empID", dr["EmployeeID"])
                        //                                        , new SqlParameter("@ngay", dr["ngay"])
                        //                                        , new SqlParameter("@tuNgay", chonKyLuong1.TuNgay)
                        //                                        , new SqlParameter("@denNgay", chonKyLuong1.DenNgay));

                        //        if (_tb.Rows.Count == 0)
                        //        {
                        //            GUIHelper.MessageBox("Nhân viên '"+ dr["EmployeeName"]
                        //                + "' chưa được đăng ký ca làm ngày '" + dr["ngay"]
                        //                + "'. Vui lòng đăng ký ca làm cho nhân viên!");

                        //            return;
                        //        }
                        //        else
                        //        {
                        //            DataRow _row = _tb.Rows[0];

                        //            bool _check = true;

                        //            String _gioRa_Request = dr["gioRa_Request"].ToString();

                        //            String _CaChieu_DenGio = _row.Field<TimeSpan>("caChieu_denGio").ToString();

                        //            String _CaSang_TuGio = _row.Field<TimeSpan>("caSang_tuGio").ToString();

                        //            TimeSpan _time_gioRa_Request = TimeSpan.Parse(_gioRa_Request);

                        //            TimeSpan _time_CaChieu_DenGio = TimeSpan.Parse(_CaChieu_DenGio);

                        //            TimeSpan _time_CaSang_TuGio = TimeSpan.Parse(_CaSang_TuGio);

                        //            if (TimeSpan.Compare(_time_gioRa_Request, _time_CaChieu_DenGio) == 0)
                        //            {
                        //                _check = false;
                        //            }
                        //            else if (TimeSpan.Compare(_time_gioRa_Request, _time_CaChieu_DenGio) > 0)
                        //            {
                        //                _check = true;
                        //            }
                        //            else if (TimeSpan.Compare(_time_gioRa_Request, _time_CaChieu_DenGio) < 0)
                        //            {
                        //                if(_time_gioRa_Request.Add(new TimeSpan(12,0,0)).Days != 0)
                        //                {
                        //                    _check = false;
                        //                }
                        //                else
                        //                {
                        //                    if(TimeSpan.Compare(_time_gioRa_Request, _time_CaSang_TuGio) < 0)
                        //                    {
                        //                        _check = true;

                        //                        _time_gioRa_Request = _time_CaSang_TuGio;
                        //                    }
                        //                    else
                        //                    {
                        //                        _check = false;
                        //                    }
                        //                }
                        //            }

                        //            if (_check)
                        //            {
                        //                tbRequestOverTime _tb_DKLT = db.tbRequestOverTimes.Where(x => x.EmployeeID == dr["EmployeeID"].ToString()
                        //                                                        && (DateTime.Compare(x.ngay.Date, DateTime.Parse(dr["ngay"].ToString()).Date) == 0)
                        //                                                        ).SingleOrDefault();

                        //                if(_tb_DKLT != null)
                        //                {
                        //                    tbRequestOverTime _tb_DKLT_insert = _tb_DKLT;

                        //                    db.tbRequestOverTimes.DeleteOnSubmit(_tb_DKLT);

                        //                    _tb_DKLT_insert.EmployeeID = dr["EmployeeID"] as String;

                        //                    _tb_DKLT_insert.ngay = DateTime.Parse(dr["ngay"].ToString()).Date;

                        //                    _tb_DKLT_insert.tuGio = _time_CaChieu_DenGio;

                        //                    _tb_DKLT_insert.denGio = _time_gioRa_Request;

                        //                    _tb_DKLT.isAcceptBP = true;

                        //                    _tb_DKLT.ngayAcceptBP = DateTime.Now;

                        //                    _tb_DKLT.userAcceptBP = LoginHelper.user.id;

                        //                    _tb_DKLT.ghiChuAcceptBP = dr["ghiChuAcceptBP"] as String;

                        //                    _tb_DKLT.isAccept = true;

                        //                    _tb_DKLT.ngayAccept = DateTime.Now;

                        //                    _tb_DKLT.userAccept = LoginHelper.user.id;

                        //                    _tb_DKLT.ghiChuAccept = dr["ghiChuAccept"] as String;

                        //                    _lActionClass.Add(new ActionClass("Sửa dữ liệu"
                        //                                                        , dr["EmployeeID"].ToString()
                        //                                                        , ""
                        //                                                        , "Sửa dữ liệu yêu cầu tăng ca từ "
                        //                                                                    + _time_CaChieu_DenGio
                        //                                                                    + " đến " + _time_gioRa_Request
                        //                                                                    + " ngày " + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dr["ngay"]))
                        //                                                        , "tbRequestOverTime"));

                        //                    db.tbRequestOverTimes.InsertOnSubmit(_tb_DKLT_insert);
                        //                }
                        //                else
                        //                {
                        //                    _tb_DKLT = new tbRequestOverTime();

                        //                    _tb_DKLT.EmployeeID = dr["EmployeeID"] as String;

                        //                    _tb_DKLT.ngay = DateTime.Parse(dr["ngay"].ToString()).Date;

                        //                    _tb_DKLT.ngayYeuCau = DateTime.Now;

                        //                    _tb_DKLT.tuGio = _time_CaChieu_DenGio;

                        //                    _tb_DKLT.denGio = _time_gioRa_Request;

                        //                    _tb_DKLT.loaiDangKy = "Trong kế hoạch";

                        //                    _tb_DKLT.ghiChu = dr["ghiChu"] as String;

                        //                    _tb_DKLT.isAcceptBP = true;

                        //                    _tb_DKLT.ngayAcceptBP = DateTime.Now;

                        //                    _tb_DKLT.userAcceptBP = LoginHelper.user.id;

                        //                    _tb_DKLT.ghiChuAcceptBP = dr["ghiChuAcceptBP"] as String;

                        //                    _tb_DKLT.isAccept = true;

                        //                    _tb_DKLT.ngayAccept = DateTime.Now;

                        //                    _tb_DKLT.userAccept = LoginHelper.user.id;

                        //                    _tb_DKLT.ghiChuAccept = dr["ghiChuAccept"] as String;

                        //                    _lActionClass.Add(new ActionClass("Thêm dữ liệu"
                        //                                                        , dr["EmployeeID"].ToString()
                        //                                                        , ""
                        //                                                        , "Thêm dữ liệu yêu cầu tăng ca từ "
                        //                                                                    + _time_CaChieu_DenGio
                        //                                                                    + " đến " + _time_gioRa_Request
                        //                                                                    + " ngày " + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dr["ngay"]))
                        //                                                        , "tbRequestOverTime"));

                        //                    db.tbRequestOverTimes.InsertOnSubmit(_tb_DKLT);
                        //                }

                        //                db.SubmitChanges();
                                        
                        //            }
                        //        }
                        //    }
                        //    else if (dr["isAccept"] as bool? == false)
                        //    {
                        //        tbRequestOverTime _tb_DKLT = db.tbRequestOverTimes.Where(x => x.EmployeeID == dr["EmployeeID"].ToString()
                        //                                                        && (DateTime.Compare(x.ngay.Date, DateTime.Parse(dr["ngay"].ToString()).Date) == 0)
                        //                                                        ).SingleOrDefault();

                        //        if (_tb_DKLT != null)
                        //        {
                        //            _tb_DKLT.isAccept = dr["isAccept"] as bool?;

                        //            _tb_DKLT.ngayAccept = DateTime.Now;

                        //            _tb_DKLT.userAccept = LoginHelper.user.id;

                        //            _tb_DKLT.ghiChuAccept = dr["ghiChuAccept"] as String;

                        //            _lActionClass.Add(new ActionClass("Sửa dữ liệu"
                        //                                                , dr["EmployeeID"].ToString()
                        //                                                , ""
                        //                                                , "Sửa dữ liệu tăng ca ngày: "
                        //                                                    + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dr["ngay"]))
                        //                                                , "tbRequestOverTime"));

                        //            db.SubmitChanges();
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    tbRequestOverTime _tb_DKLT = db.tbRequestOverTimes.Where(x => x.EmployeeID == dr["EmployeeID"].ToString()
                        //                                                        && (DateTime.Compare(x.ngay.Date, DateTime.Parse(dr["ngay"].ToString()).Date) == 0)
                        //                                                        ).SingleOrDefault();
                        //    if (_tb_DKLT != null)
                        //    {
                        //        db.tbRequestOverTimes.DeleteOnSubmit(_tb_DKLT);

                        //        _lActionClass.Add(new ActionClass("Xóa dữ liệu"
                        //                                                , dr["EmployeeID"].ToString()
                        //                                                , ""
                        //                                                , "Xóa dữ liệu tăng ca ngày: "
                        //                                                    + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dr["ngay"]))
                        //                                                , "tbRequestOverTime"));

                        //        db.SubmitChanges();
                        //    }
                        //}
                        #endregion 

                        dbFile.SubmitChanges();

                        if (dr.RowState == DataRowState.Added)
                        {
                            _lActionClass.Add(new ActionClass("Thêm dữ liệu", dr["EmployeeID"].ToString(), "", "Thêm dữ liệu yêu cầu sửa công từ "
                                + dr["gioVao_Old"].ToString() + " - " + dr["gioRa_Old"].ToString()
                                + " thành " + dr["gioVao_Request"].ToString() + " - " + dr["gioRa_Request"].ToString()
                                + string.Format(" Ngày {0:dd/MM/yyyy}", dr["ngay"]), "tbRequestEditAttendane"));
                        }

                        if (dr.RowState == DataRowState.Modified && isDuyet == false)
                        {
                            _lActionClass.Add(new ActionClass("Sửa dữ liệu", dr["EmployeeID"].ToString(), "", "Sửa dữ liệu yêu cầu sửa công từ "
                                + dr["gioVao_Old"].ToString() + " - " + dr["gioRa_Old"].ToString()
                                + " thành " + dr["gioVao_Request"].ToString() + " - " + dr["gioRa_Request"].ToString()
                                + string.Format(" Ngày {0:dd/MM/yyyy}", dr["ngay"]), "tbRequestEditAttendane"));

                            isDuyet = false;
                        }
                    }
                    else
                    {
                        var empID = (string)dr["EmployeeID", DataRowVersion.Original];

                        _lActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                            , empID
                                                            , ""
                                                            , "Xóa dữ liệu yêu cầu sửa công NV " + empID
                                                            , "tbRequestEditAttendane"));
                    }
                }

                Provider.UpdateData(dt, "tbRequestEditAttendane");

                LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception ex)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record." + ex.Message, "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void toolStripThem_Click(object sender, EventArgs e)
        {
            dlgRequestEditAttendanecs_v1 _dlg = new dlgRequestEditAttendanecs_v1();

            _dlg.ShowDialog();
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

        #region  Dịch form
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
        private IEnumerable<SimpleButton> EnumerateSimpleButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(SimpleButton).IsAssignableFrom(field.FieldType)
                   let component = (SimpleButton)field.GetValue(this)
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

        private IEnumerable<Control> EnumerateLabelControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(LabelControl).IsAssignableFrom(field.FieldType)
                   let component = (LabelControl)field.GetValue(this)
                   where component != null
                   select component;
        }

        public string SelectTranslate(string nameCrt, string lang )
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new SqlParameter("CtrName", nameCrt),

                           new SqlParameter("FormName", this.Name.ToString()));
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
        public void TranlateForm()
        {
            myData.Clear();
            listCtr.Clear();
            string langTrans = LoginHelper.langTrans;
            string formText = SelectTranslate(this.Name, langTrans);
            if (formText != "")
            {
                this.Text = formText;
            }
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
            foreach (SimpleButton s in _SimpleButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (LabelControl s in _LableControl)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            myData.Add(this.Name, this.Text);
            listCtr.Add(this.Name);
            // dịch radiogrop duyệt 
            rdAccept.Properties.Items[0].Description = SelectTranslate("rdAcceptTatca", langTrans);
            rdAccept.Properties.Items[1].Description = SelectTranslate("rdAcceptDaDuyet", langTrans);
            rdAccept.Properties.Items[2].Description = SelectTranslate("rdAcceptKhongDuyet", langTrans);

            #endregion
        }

        #endregion

        private void frmRequestEditAttendanecs_v1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
              
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmRequestEditAttendanecs_v1_Load(null, null);
                

            }
        }

        private void frmRequestEditAttendanecs_v1_FormClosing(object sender, FormClosingEventArgs e)
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