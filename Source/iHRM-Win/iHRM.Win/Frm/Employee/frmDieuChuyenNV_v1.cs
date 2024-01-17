using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Frm.XtraReportTemplate;
using DevExpress.XtraGrid;
using System.Reflection;

namespace iHRM.Win.Frm.Employee
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class frmDieuChuyenNV_v1 : frmBase
    {
        //Khai báo biến// //1380, 541
        DataTable _dt;

        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        //String _FilesChoised = "";

        dlgDieuChuyenNV _dlgEditor;

        DataRow _CRow;

        DataTable _dtData = new DataTable();
        //---//

        public frmDieuChuyenNV_v1()
        {
            InitializeComponent();
        }


        private void frmDieuChuyenNV_v1_Load(object sender, EventArgs e)
        {
            TranslateForm();

            btnSearch_Click(null, null);

            var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name"
                                                        , new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));

            repNhanvien.DataSource = dtnv;
            repNhanvien.DisplayMember = "EmployeeName";
            repNhanvien.ValueMember = "EmployeeCode";

            var dtpb = _db.tblRef_Departments;

            repPhongBan.DataSource = dtpb;
            repPhongBan.DisplayMember = "DepName";
            repPhongBan.ValueMember = "DepID";

            repQLDuyet.DataSource = _db.w5sysUsers;

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

            _listActionClass.Clear();
        }

        #region: Grid Control

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            _CRow = grv.GetFocusedDataRow();
        }

        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 &&
                grv.GetRowCellValue(e.RowHandle, "isAcceptBP") != null &&
                !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()))
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
            if (e.RowHandle >= 0 &&
                grv.GetRowCellValue(e.RowHandle, "ngay") != null &&
                string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()) &&
                string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isHetHan").ToString()))
            {
                TimeSpan date = Convert.ToDateTime(DateTime.Now) - Convert.ToDateTime(grv.GetRowCellValue(e.RowHandle, "ngay").ToString());
                if (date.Days >= 5 && (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin))
                {
                    e.Appearance.ForeColor = Color.MediumBlue;
                }
            }
        }

        private void grv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column == colisAccept && e.CellValue != null)
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

        private void grv_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column == colXemFile && grv.GetFocusedDataRow() != null)
            {
                FileStorageHelper _fh = new FileStorageHelper();

                var _a = grv.GetFocusedRowCellValue(colDataFile);

                var _duoiFile = grv.GetFocusedRowCellValue(colduoiFile).ToString();

                if (_a != null && _a.ToString() != "")
                {
                    Binary dataFile = new Binary(_a as byte[]);

                    _fh.DownLoadAndShowFILE(_a as byte[], _duoiFile);
                }
                else
                {
                    GUIHelper.Notifications("Không tìm thấy file.", "Xem file", GUIHelper.NotifiType.error);
                }
            }
        }
        #endregion

        #region: Button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmDieuChuyenNV_v1_Load(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;

            _dt = new DataTable();

            bool? isAccept = null;

            if (rdAccept.SelectedIndex == 1)
            {
                isAccept = true;
            }
            if (rdAccept.SelectedIndex == 2)
            {
                isAccept = false;
            }

            _dt = Provider.ExecuteDataTable("p_getDieuChuyen_byStrEmp_v1",
                                        new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                                        new SqlParameter("denNgay", chonKyLuong1.DenNgay_End),
                                        new SqlParameter("isAccept", isAccept),
                                        Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS.GetValue())
            );

            _dt.Columns.Add("idFileDelete");

            grd.DataSource = _dt;

            btnSearch.Enabled = true;

            _listActionClass.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grv.GetFocusedDataRow() != null) //Kiểm tra Focused có dữ liệu
            {
                int[] rc = grv.GetSelectedRows(); //Lấy dữ liệu trong lưới

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        if (r["isAccept"] != DBNull.Value || r["isAcceptBP"] != DBNull.Value) return; //Không sửa đơn đã duyệt hoặc chốt

                        if (grv.FocusedRowHandle != -1)
                        {

                            if (_dlgEditor != null)
                            {
                                _CRow = grv.GetFocusedDataRow();

                                _dlgEditor._flag = 1;

                                _dlgEditor._CRow = _CRow;

                                _dlgEditor.ShowDialog();
                            }
                            else
                            {
                                _dlgEditor = new dlgDieuChuyenNV();

                                _CRow = grv.GetFocusedDataRow();

                                _dlgEditor._flag = 1;

                                _dlgEditor._CRow = _CRow;

                                _dlgEditor.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _dlgEditor = new dlgDieuChuyenNV();

            _dlgEditor._flag = 0;

            _dlgEditor.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));

            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }
            else
            {
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa điều chuyển " + drs.First()["SoQD"].ToString() + "."))
                {
                    _listActionClass.Clear();

                    _db = new dcDatabaseDataContext(Provider.ConnectionString);

                    tbDieuChuyen_v1 list = _db.tbDieuChuyen_v1s.Where(i => i.SoQD == drs.First()["SoQD"].ToString()).SingleOrDefault();

                    if (list == null)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }

                    if (list.isAcceptBP != null || !String.IsNullOrEmpty(list.isAcceptBP.ToString()))
                    {
                        GUIHelper.MessageError("Đơn đã được duyệt không thể xóa.");
                        return;
                    }

                    if (list.isAccept != null || !String.IsNullOrEmpty(list.isAccept.ToString()))
                    {
                        GUIHelper.MessageError("Đơn đã được chốt không thể xóa.");
                        return;
                    }

                    if (LoginHelper.user.idKhoiPB != null
                        &&
                        !AllLogic.checkEmployeeIDInDep(list.EmployeeID.ToString(), LoginHelper.user.idKhoiPB.Value))
                    {
                        return;
                    }

                    try
                    {
                        _listActionClass.Add(new ActionClass("Xóa dữ liệu" + " điều chuyển theo số quyết định " + drs.First()["SoQD"].ToString()
                            , drs.First()["EmployeeID"].ToString() 
                            , ""
                            , "Ngày: " + DateTime.Now.Date
                            , "tbDieuChuyen_v1"));

                        _db.tbDieuChuyen_v1s.DeleteOnSubmit(list); //Xóa dữ liệu

                        _db.SubmitChanges(); //Lưu vào database

                        LogAction.LogAction.PushLog(_listActionClass); //Lưu lịch sử người dùng

                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess); //Thông báo xóa thành công

                        grv.DeleteSelectedRows(); //Cập nhật lại Grid View
                    }
                    catch (Exception ex)
                    {
                        win_globall.ExecCatch(ex);
                    }
                }
            }
        }
        #endregion

        #region: toolStrip2
        private void toolStripGoDuyet_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ bỏ đăng ký đang chọn?"
                                    , "Khóa đăng ký"
                                    , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        if (LoginHelper.user.idKhoiPB != null &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
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

                        _listActionClass.Add(new ActionClass("Gỡ duyệt"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Gỡ duyệt điều chuyển nhân viên Ngày: " + DateTime.Now.Date
                                                            , "tbDieuChuyen_v1"));
                    }
                }
            }
        }

        private void toolStripNotAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu đang chọn?"
                                    , "Không duyệt tất cả các yêu cầu đang chọn"
                                    , MessageBoxButtons.OKCancel);

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
                        if (r["userAcceptBP"] != DBNull.Value)
                        {
                            if ((Convert.ToDouble(r["userAcceptBP"].ToString()) != LoginHelper.user.id))
                            {
                                continue;
                            }
                        }

                        if (LoginHelper.user.idKhoiPB != null &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
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

                        _listActionClass.Add(new ActionClass("Không duyệt"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Không duyệt điều chuyển nhân viên Ngày: " + DateTime.Now.Date
                                                            , "tbDieuChuyen_v1"));
                    }
                }
            }
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?"
                                    , "Duyệt tất cả các yêu cầu đang chọn"
                                    , MessageBoxButtons.OKCancel);

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
                        if (r["userAcceptBP"] != DBNull.Value)
                        {
                            if ((Convert.ToDouble(r["userAcceptBP"].ToString()) != LoginHelper.user.id))
                            {
                                continue;
                            }
                        }

                        if (LoginHelper.user.idKhoiPB != null &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
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

                        _listActionClass.Add(new ActionClass("Duyệt"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Duyệt điều chuyển nhân viên Ngày: " + DateTime.Now.Date
                                                            , "tbDieuChuyen_v1"));
                    }
                }
            }
        }

        private void toolStripAcceptAll_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu?"
                                    , "Duyệt tất cả các yêu cầu"
                                    , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                QuetThe.dlgLyDoDuyet frm = new QuetThe.dlgLyDoDuyet(true);
                frm.ShowDialog();

                for (int i = 0; i < grv.DataRowCount; i++)
                {
                    var r = grv.GetDataRow(i);
                    if (r != null)
                    {
                        if (LoginHelper.user.idKhoiPB != null &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
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

                        _listActionClass.Add(new ActionClass("Duyệt tất cả"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Duyệt tất cả điều chuyển nhân viên Ngày: " + DateTime.Now.Date
                                                            , "tbDieuChuyen_v1"));
                    }
                }

            }
        }

        private void toolStripGoDuyetChotCong_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ duyệt chốt công đăng ký đang chọn?"
                                    , "Gỡ duyệt chốt công đăng ký"
                                    , MessageBoxButtons.OKCancel);

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

                        _listActionClass.Add(new ActionClass("Gỡ duyệt"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Gỡ duyệt chốt công đăng ký điều chuyển nhân viên Ngày: " + DateTime.Now.Date
                                                            , "tbDieuChuyen_v1"));
                    }
                }
            }
        }

        private void toolStripNotAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu đang chọn?"
                                    , "Không duyệt yêu cầu tăng ca"
                                    , MessageBoxButtons.OKCancel);

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
                        if (r["userAccept"] != DBNull.Value)
                        {
                            if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                            {
                                continue;
                            }
                        }

                        if (LoginHelper.user.idKhoiPB != null &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
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

                        _listActionClass.Add(new ActionClass("Không duyệt chốt điều chuyển"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Không duyệt chốt điều chuyển nhân viên Ngày: " + DateTime.Now.Date
                                                            , "tbDieuChuyen_v1"));
                    }
                }
            }
        }

        private void toolStripAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?"
                                    , "Duyệt yêu cầu"
                                    , MessageBoxButtons.OKCancel);

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
                        if (r["userAccept"] != DBNull.Value)
                        {
                            if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                            {
                                continue;
                            }
                        }

                        if (LoginHelper.user.idKhoiPB != null &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
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

                        _listActionClass.Add(new ActionClass("Duyệt chốt điều chuyển"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Duyệt chốt điều chuyển nhân viên Ngày: " + DateTime.Now.Date
                                                            , "tbDieuChuyen_v1"));
                    }
                }
            }
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            if (_dt.GetChanges() == null || (_dt.GetChanges() != null && _dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }

            dcDatabaseFilesDataContext dbFile = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

            var count = _dt.GetChanges().Rows.Count;

            string mnv = string.Empty;

            long idUserRequests = 0;

            DateTime NgayHieuLuc = DateTime.Now;

            List<tbDieuChuyen_v1> lst = new List<tbDieuChuyen_v1>();

            try
            {
                foreach (DataRow dr in _dt.GetChanges().Rows)
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

                        idUserRequests = long.Parse(dr["idUserRequest"].ToString());

                        if (dr.RowState == DataRowState.Added)
                        {
                            _listActionClass.Add(new ActionClass("Thêm dữ liệu"
                                                                , dr["EmployeeID"].ToString()
                                                                , ""
                                                                , "Thêm dữ liệu điều chuyển nhân viên " + dr["EmployeeID"].ToString() + " Ngày: " + DateTime.Now.Date
                                                                , "tbDieuChuyen_v1"));
                        }
                    }
                    else
                    {
                        var empID = (string)dr["EmployeeID", DataRowVersion.Original];

                        _listActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                            , empID
                                                            , ""
                                                            , "Xóa dữ liệu điều chuyển nhân viên " + empID + " Ngày: " + DateTime.Now.Date
                                                            , "tbDieuChuyen_v1"));
                    }
                    Provider.UpdateData(_dt, "tbDieuChuyen_v1"); _listActionClass.Clear();
                }

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Provider.ExecuteNonQuery("AutoDieuChuyenNV");
            }
            catch (Exception)
            { }
        }
        #endregion

        private void btnIn_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));


            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }

            try
            {
                foreach (var item in drs)
                {
                    var a = Provider.ExecuteDataTableReader("p_export_DieuChuyenNV"
                                                            , new System.Data.SqlClient.SqlParameter("@empID", item["EmployeeID"].ToString())
                                                            , new System.Data.SqlClient.SqlParameter("@soQD", item["SoQD"].ToString()));

                    var rp = new rep_DonXinDieuChuyen();

                    rp.DataBindings(a);

                    ReportViewer rv = new ReportViewer();

                    rv.ViewReport(rp);
                }
            }
            catch(Exception ex)
            {
                win_globall.ExecCatch(ex);
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

        private void frmDieuChuyenNV_v1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmDieuChuyenNV_v1_Load(null, null);
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

        private IEnumerable<DevExpress.XtraEditors.CheckEdit> EnumerateCheckEditControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.CheckEdit).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.CheckEdit)field.GetValue(this)
                   where component != null
                   select component;
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
        public void TranslateForm()
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
            var _CheckEdit = EnumerateCheckEditControl();
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
            foreach (DevExpress.XtraEditors.CheckEdit s in _CheckEdit)
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

        private void frmDieuChuyenNV_v1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_dt.GetChanges() == null || (_dt.GetChanges() != null && _dt.GetChanges().Rows.Count == 0))
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