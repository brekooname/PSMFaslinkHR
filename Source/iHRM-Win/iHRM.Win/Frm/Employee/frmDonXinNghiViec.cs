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
    public partial class frmDonXinNghiViec : frmBase
    {
        //Khai báo biến//
        DataTable dt;

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        dlgDonXinNghi dlgEditor_v4;

        DataRow _CRow;

        DataTable dtData = new DataTable();
        //---//

        public frmDonXinNghiViec()
        {
            InitializeComponent();
        }


        private void frmDonXinNghiViec_v3_Load(object sender, EventArgs e)
        {
            TranslateForm();
            btnSearch_Click(null, null);

            //var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name"
            //                            , new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));

            //repNhanvien.DataSource = dtnv;
            //repNhanvien.DisplayMember = "EmployeeName";
            //repNhanvien.ValueMember = "EmployeeCode";

            //var dtpb = db.tblRef_Departments;

            //repPhongBan.DataSource = dtpb;
            //repPhongBan.DisplayMember = "DepName";
            //repPhongBan.ValueMember = "DepID";

            repQLDuyet.DataSource = db.w5sysUsers;

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

        #region: Xử lý Grid View
        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            _CRow = grv.GetFocusedDataRow();
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
            }
        }

        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {

            if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "isAcceptBP") != null
                && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()))
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


            if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "ngay") != null
                && string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()))
            {
                TimeSpan date = Convert.ToDateTime(DateTime.Now) - Convert.ToDateTime(grv.GetRowCellValue(e.RowHandle, "ngay").ToString());

                if (date.Days >= 5 && (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin))
                {
                    e.Appearance.ForeColor = Color.MediumBlue;
                }
            }
        }

        private void grv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void grv_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grv.GetDataRow(e.RowHandle);

            if (dr != null)
            {
                dr["DateRequest"] = DateTime.Now;

                dr["idUserRequest"] = LoginHelper.user.id;

            }
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
        #endregion

        #region: Lưu
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

            DateTime NgayHieuLuc = DateTime.Now;

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

                        if (dr.RowState == DataRowState.Added)
                        {
                            _listActionClass.Add(new ActionClass("Thêm dữ liệu " + dr["EmployeeID"].ToString()
                                , dr["EmployeeID"].ToString()
                                , ""
                                , "Thêm dữ liệu duyệt ngày: " + DateTime.Now.Date
                                , "tbDonXinNghiViec"));
                        }
                    }
                    else
                    {
                        var empID = (string)dr["EmployeeID", DataRowVersion.Original];

                        _listActionClass.Add(new ActionClass("Xóa dữ liệu"
                            , empID
                            , ""
                            , "Xóa dữ liệu nhân viên nghỉ ngày: " + DateTime.Now.Date
                            , "tbDonXinNghiViec"));
                    }

                    Provider.UpdateData(dt, "tbDonXinNghiViec");

                    _listActionClass.Clear();

                    GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
                }

            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }
        #endregion

        #region: Xóa
        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các yêu cầu đang chọn?"
                , "Xóa tất cả các yêu cầu đang chọn"
                , MessageBoxButtons.OKCancel);

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

                        if (LoginHelper.user.idKhoiPB != null
                            &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            isOK = false;
                        }

                        if (!isOK)
                        {
                            GUIHelper.Notifications("Không thể xóa vì bản ghi này đã được duyệt hoặc không thuộc phòng ban của bạn."
                                , "Xóa tất cả các yêu cầu đang chọn"
                                , GUIHelper.NotifiType.error);
                        }
                        else
                        {
                            grv.DeleteRow(rc[i - 1]);
                        }
                    }
                }
            }
        }
        #endregion

        #region: Duyệt chốt
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

                        if (LoginHelper.user.idKhoiPB != null
                            &&
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

                        r["isAccept"] = true;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;

                        _listActionClass.Add(new ActionClass("Duyệt chốt nghỉ " + r["ngayNghiViec"].ToString()
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Duyệt chốt nhân viên nghỉ ngày: " + DateTime.Now.Date
                            , "tbDonXinNghiViec"));
                    }
                }
            }
        }
        #endregion

        #region: Không duyệt chốt
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

                        if (LoginHelper.user.idKhoiPB != null
                            &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }

                        if ((r["isAcceptBP"] as bool? != true))
                        {
                            continue;
                        }

                        r["isAccept"] = false;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;
                        _listActionClass.Add(new ActionClass("Không duyệt chốt điều chuyển " + r["ngayNghiViec"].ToString()
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Không duyệt chốt đơn xin nghỉ ngày: " + DateTime.Now.Date
                            , "tbDonXinNghiViec"));
                    }
                }
            }
        }
        #endregion

        #region: Gỡ duyệt chốt
        private void toolStripGoDuyetChotCong_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ duyệt chốt đăng ký đang chọn?"
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

                        if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                        {
                            continue;
                        }

                        r["isAccept"] = DBNull.Value;
                        r["userAccept"] = DBNull.Value;
                        r["ngayAccept"] = DBNull.Value;
                        r["ghiChuAccept"] = DBNull.Value;

                        _listActionClass.Add(new ActionClass("Gỡ duyệt " + r["ngayNghiViec"].ToString()
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Gỡ duyệt chốt nhân viên xin nghỉ ngày: " + DateTime.Now.Date
                            , "tbDonXinNghiViec"));
                    }
                }
            }
        }
        #endregion

        #region: Duyệt tất cả
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
                        if (LoginHelper.user.idKhoiPB != null
                            &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }

                        if (r["isAccept"] != DBNull.Value)
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

                        _listActionClass.Add(new ActionClass("Duyệt tất cả " + r["ngayNghiViec"].ToString()
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Duyệt tất cả nhân viên xin nghỉ ngày: " + DateTime.Now.Date
                            , "tbDonXinNghiViec"));
                    }
                }
            }
        }
        #endregion

        #region: Duyệt
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

                        if (LoginHelper.user.idKhoiPB != null
                            &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }

                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAcceptBP"] = true;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;

                        _listActionClass.Add(new ActionClass("Duyệt " + r["ngayNghiViec"].ToString()
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Duyệt điều chuyển nhân viên ngày: " + DateTime.Now.Date 
                            , "tbDonXinNghiViec"));
                    }
                }
            }
        }
        #endregion

        #region: Không duyệt
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

                        if (LoginHelper.user.idKhoiPB != null
                            &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }

                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAcceptBP"] = false;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;

                        _listActionClass.Add(new ActionClass("Không duyệt " + r["ngayNghiViec"].ToString()
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Không duyệt đơn xin nghỉ ngày: " + DateTime.Now.Date
                            , "tbDonXinNghiViec"));
                    }
                }
            }
        }
        #endregion

        #region: Gỡ duyệt
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
                        if (LoginHelper.user.idKhoiPB != null
                            &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }

                        if ((r["isAccept"] != DBNull.Value))
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

                        _listActionClass.Add(new ActionClass("Gỡ duyệt " + r["ngayNghiViec"].ToString()
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Gỡ duyệt đơn xin nghỉ ngày: " + DateTime.Now.Date
                            , "tbDonXinNghiViec"));
                    }
                }
            }
        }
        #endregion

        #region: Excel
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            grv.OptionsPrint.UsePrintStyles = false;
            ShowPreview(grd);
        }
        #endregion

        #region: Xem File
        private void grv_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column == colXemFile && grv.GetFocusedDataRow() != null)
            {
                FileStorageHelper _fh = new FileStorageHelper();

                var _a = grv.GetFocusedRowCellValue(coldataFile);

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

        #region: Button Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmDonXinNghiViec_v3_Load(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;

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

            dt = Provider.ExecuteDataTable("p_getDonXinNghiViec_byStrEmp",
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay_End),
                    new SqlParameter("isAccept", isAccept),
                    Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS.GetValue())
            );

            dt.Columns.Add("idFileDelete");

            grd.DataSource = dt;

            btnSearch.Enabled = true;

            _listActionClass.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //ShowDialog();

            //dlgEditor.MyValue = dt.NewRow();

            //dlgEditor.CustomFormAction = 0;

            dlgEditor_v4 = new dlgDonXinNghi();

            dlgEditor_v4._flag = 0;

            dlgEditor_v4.ShowDialog();
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

                            if (dlgEditor_v4 != null)
                            {
                                _CRow = grv.GetFocusedDataRow();

                                dlgEditor_v4.lkpEmployeeID.ReadOnly = true;

                                dlgEditor_v4._flag = 1;

                                dlgEditor_v4._CRow = _CRow;

                                dlgEditor_v4.ShowDialog();
                            }
                            else
                            {
                                dlgEditor_v4 = new dlgDonXinNghi();

                                _CRow = grv.GetFocusedDataRow();

                                dlgEditor_v4.lkpEmployeeID.ReadOnly = true;

                                dlgEditor_v4._flag = 1;

                                dlgEditor_v4._CRow = _CRow;

                                dlgEditor_v4.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void toolDctay_Click(object sender, EventArgs e)
        {
            try
            {
                Provider.ExecuteNonQuery("AutoNghiViec");
            }
            catch (Exception)
            { }
        }
        #endregion

        #region: Event xóa
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
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa đơn nghỉ việc " + drs.First()["EmployeeName"].ToString() + "."))
                {
                    _listActionClass.Clear();

                    db = new dcDatabaseDataContext(Provider.ConnectionString);
                    tbDonXinNghiViec list = db.tbDonXinNghiViecs.Where(i => i.EmployeeID == drs.First()["EmployeeID"].ToString()).SingleOrDefault();

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
                        _listActionClass.Add(new ActionClass("Xóa dữ liệu " + drs.First()["ngayNghiViec"].ToString()
                            , drs.First()["EmployeeID"].ToString()
                            , ""
                            , "Xóa đơn xin nghỉ ngày: " + DateTime.Now.Date
                            , "tbDonXinNghiViec"));

                        db.tbDonXinNghiViecs.DeleteOnSubmit(list); //Xóa dữ liệu

                        db.SubmitChanges(); //Lưu vào database

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
                    var a = Provider.ExecuteDataTableReader("p_export_DonXinNghiViec_001"
                                                            , new System.Data.SqlClient.SqlParameter("@empID", item["EmployeeID"].ToString())
                                                            , new System.Data.SqlClient.SqlParameter("@ngayNghi", DateTime.Parse(item["ngayNghiViec"].ToString())));

                    string strFile = Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\" + "HR_DONXINNGHIVIEC.docx");
                    var rp = new rep_DXN(strFile);

                    rp.bindData(a);

                    ReportViewer rv = new ReportViewer();

                    rv.ViewReport(rp);
                }
                //foreach (var item in drs)
                //{
                //    var a = Provider.ExecuteDataTableReader("p_export_DonXinNghiViec"
                //                                            , new System.Data.SqlClient.SqlParameter("@empID", item["EmployeeID"].ToString())
                //                                            , new System.Data.SqlClient.SqlParameter("@ngayNghi", DateTime.Parse(item["ngayNghiViec"].ToString())));

                //    var rp = new rep_DonXinNghiViec();

                //    rp.DataBindings(a);

                //    ReportViewer rv = new ReportViewer();

                //    rv.ViewReport(rp);
                //}
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void btnInQD_Click(object sender, EventArgs e)
        {

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

        private void frmDonXinNghiViec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmDonXinNghiViec_v3_Load(null, null);
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

        private void frmDonXinNghiViec_FormClosing(object sender, FormClosingEventArgs e)
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