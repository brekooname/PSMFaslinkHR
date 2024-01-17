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
using System.Collections.Generic;
using iHRM.Win.Frm.LogAction;
using DevExpress.XtraGrid;
using System.Reflection;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class frmRequestOutInShift : frmBase
    {
        DataTable dt = new DataTable();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        List<ActionClass> _lActionClass = new List<ActionClass>();

        dlgRequestOutInShift dlgDKRaVao;

        bool isDuyet = false;

        public frmRequestOutInShift()
        {
            InitializeComponent();
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

            dt = Provider.ExecuteDataTable("p_getRequestOutInShift",
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmRequestOutInShift_Load(null, null);
        }
        //Test dữ liệu


        private void frmRequestOutInShift_Load(object sender, EventArgs e)
        {
            //GetListControllInForm();
            TranslateForm();
            string sss = LoginHelper.langTrans;
            var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));

            repNhanvien.DataSource = dtnv;

            repNhanvien.DisplayMember = "EmployeeName";

            repNhanvien.ValueMember = "EmployeeCode";

            repQLDuyet.DataSource = db.w5sysUsers;

            repLoaiRaNgoai.DataSource = db.tblRef_OutInShiftTypes;

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

            try
            {
                foreach (DataRow dr in dt.GetChanges().Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                    {
                        var empID = (string)dr["EmployeeID", DataRowVersion.Original];
                        var tuGio = (TimeSpan)dr["tuGio", DataRowVersion.Original];
                        var denGio = (TimeSpan)dr["denGio", DataRowVersion.Original];
                        var Ngay = (DateTime)dr["ngay", DataRowVersion.Original];

                        _lActionClass.Add(new ActionClass("Xóa dữ liệu"
                            , empID
                            , ""
                            , "Xóa dữ liệu yêu cầu ra vào từ "
                            + tuGio.ToString() + " đến "
                            + denGio.ToString() + " ngày "
                            + string.Format("{0: dd/MM/yyyy}", Ngay), "tbRequestOutInShift"));
                    }
                }

                Provider.UpdateData(dt, "tbRequestOutInShift");

                LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception ex)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record." + ex.Message, "Lưu dữ liệu", GUIHelper.NotifiType.error);
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
            if (e.Column == colisHetHan && e.CellValue != null)
            {
                if (e.CellValue.ToString() == "Hết hạn")
                {
                    e.Appearance.BackColor = Color.NavajoWhite;
                }
            }
        }

        private void grv_RowStyle(object sender, RowStyleEventArgs e)
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
            //    if (date.Days >= 5 && (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin))
            //    {
            //        e.Appearance.ForeColor = Color.MediumBlue;
            //    }
            //}
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
                        if (IsLock.IsLock.Check_IsLock("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString())))
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

        private void toolStripAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?", "Duyệt yêu cầu ra vào", MessageBoxButtons.OKCancel);
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
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 1))
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
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            continue;
                        }

                        r["isAccept"] = true;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Duyệt chốt công"
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Duyệt chốt yêu cầu ra vào "
                            + r["tuGio"].ToString() + " đến "
                            + r["denGio"].ToString() + " ngày "
                            + r["ngay"].ToString()
                            , "tbRequestOutInShift"));

                    }
                }
            }
        }

        private void toolStripNotAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu đang chọn?", "Không duyệt yêu cầu ra vào", MessageBoxButtons.OKCancel);
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
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 1))
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
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            continue;
                        }

                        r["isAccept"] = false;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Không duyệt chốt công"
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Không duyệt chốt yêu cầu ra vào "
                            + r["tuGio"].ToString() + " đến "
                            + r["denGio"].ToString() + " ngày "
                            + string.Format("{0: dd/MM/yyyy}", DateTime.Parse(r["ngay"].ToString()))
                            , "tbRequestOutInShift"));

                    }
                }
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
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 1))
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

                        _lActionClass.Add(new ActionClass("Gỡ duyệt"
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Gỡ duyệt chốt công dữ liệu yêu cầu ra vào "
                            + r["tuGio"].ToString() + " đến "
                            + r["denGio"].ToString() + " ngày "
                            + string.Format("{0: dd/MM/yyyy}", DateTime.Parse(r["ngay"].ToString()))
                            , "tbRequestOutInShift"));

                    }
                }
            }
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
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công không thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 3))
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
                        //if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        //{
                        //    continue;
                        //}
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        //if (r["loaiDangKy"].ToString() == "Ngoài kế hoạch" && r["dataFile"] == DBNull.Value && !LoginHelper.user.isAdmin)
                        //{
                        //    GUIHelper.MessageBox("Không được duyệt loại đăng ký Ngoài kế hoạch mà không có văn bản.", "Đính kèm văn bản");
                        //    continue;
                        //}
                        if (r["isAcceptBP"] == DBNull.Value)
                        {
                            r["isAcceptBP"] = true;
                            r["userAcceptBP"] = LoginHelper.user.id;
                            r["ngayAcceptBP"] = DateTime.Now;
                            r["ghiChuAcceptBP"] = frm.reason;
                            _lActionClass.Add(new ActionClass("Duyệt tất cả"
                                , r["EmployeeID"].ToString()
                                , ""
                                , "Duyệt tất cả yêu cầu ra vào "
                                + r["tuGio"].ToString() + " đến "
                                + r["denGio"].ToString() + " ngày "
                                + string.Format("{0: dd/MM/yyyy}", DateTime.Parse(r["ngay"].ToString()))
                                , "tbRequestOutInShift"));

                        }
                    }
                }

            }
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
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công không thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 3))
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
                        //if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        //{
                        //    continue;
                        //}
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        //if (r["loaiDangKy"].ToString() == "Ngoài kế hoạch" && r["dataFile"] == DBNull.Value && !LoginHelper.user.isAdmin)
                        //{
                        //    GUIHelper.MessageBox("Không được duyệt loại đăng ký Ngoài kế hoạch mà không có văn bản.", "Đính kèm văn bản");
                        //    continue;
                        //}

                        r["isAcceptBP"] = true;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Duyệt"
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Duyệt yêu cầu ra vào "
                            + r["tuGio"].ToString() + " đến "
                            + r["denGio"].ToString() + " ngày "
                            + string.Format("{0: dd/MM/yyyy}", DateTime.Parse(r["ngay"].ToString()))
                            , "tbRequestOutInShift"));

                    }
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
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");
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
                        //if (r["loaiDangKy"].ToString() == "Ngoài kế hoạch" && r["dataFile"] == DBNull.Value && !LoginHelper.user.isAdmin)
                        //{
                        //    GUIHelper.MessageBox("Không được duyệt loại đăng ký Ngoài kế hoạch mà không có văn bản.", "Đính kèm văn bản");
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
                        _lActionClass.Add(new ActionClass("Không duyệt"
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Không duyệt yêu cầu ra vào "
                            + r["tuGio"].ToString() + " đến "
                            + r["denGio"].ToString() + " ngày "
                            + string.Format("{0: dd/MM/yyyy}", DateTime.Parse(r["ngay"].ToString()))
                            , "tbRequestOutInShift"));

                    }
                }
            }
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
                        //if (IsLock.IsLock.Check_IsLock("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công không thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", Convert.ToDateTime(r["ngay"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt không thể thao tác!");
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
                        _lActionClass.Add(new ActionClass("Gỡ duyệt"
                            , r["EmployeeID"].ToString()
                            , ""
                            , "Gỡ duyệt chốt công dữ liệu yêu cầu ra vào "
                            + r["tuGio"].ToString() + " đến "
                            + r["denGio"].ToString() + " ngày "
                            + string.Format("{0: dd/MM/yyyy}", DateTime.Parse(r["ngay"].ToString()))
                            , "tbRequestOutInShift"));

                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);

            //SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save

            //sd.Filter = "Excel 2007|*.xls";

            //if (sd.ShowDialog() != DialogResult.OK)

            //    return;

            //try
            //{
            //    if (System.IO.File.Exists(sd.FileName))

            //        System.IO.File.Delete(sd.FileName);
            //}
            //catch (Exception ex)
            //{
            //    GUIHelper.MessageError(ex.Message, this.Text);

            //    return;
            //}
            ////---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

            //ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới

            //ge.OnDoing += (bw) =>
            //{
            //    //bw.ReportProgress(-1, "Xuất excel báo cáo ra vào trong tháng"); // Set caption

            //    //#region get data

            //    //bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

            //    ////Lấy dữ liệu

            //    //if (dt == null || dt.Rows.Count == 0)
            //    //{
            //    //    bw.ReportProgress(1); // Nếu không có dữ liệu
            //    //    return;
            //    //}


            //    //#endregion

            //    //#region export
            //    //bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

            //    //ExcelExportHelper ex = new ExcelExportHelper("Report/SW_HR_BAOCAOTANGCA_002.xlsx"); // Tạo excel export helper + đường dẫn template

            //    //ex.WriteToCell("I5", chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " - " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));

            //    //ex.WriteToCell("E5", ucChonDoiTuong_DS2.getKhoiPBDisPlay());

            //    //ex.FillDataTable(dt); // Fill BC_FillData

            //    //ex.RendAndFlush("BaoCaoDangKyTangCa_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);

            //    //bw.ReportProgress(2);
            //    //#endregion
            //};

            //ge.OnReport += (ps, obj) =>
            //{
            //    if (ps == 1)
            //    {
            //        GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
            //    }
            //    else if (ps == 2)
            //    {// Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.
            //        var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);
            //        c.AlertClick += (s1, e1) =>
            //        {
            //            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            //            {
            //                FileName = sd.FileName,
            //                UseShellExecute = true
            //            });
            //        };
            //    }
            //};

            //ge.Show(this);
        }

        private void toolStripThem_Click(object sender, EventArgs e)
        {
            if (dlgDKRaVao != null)
            {
                dlgDKRaVao.ShowDialog();
            }
            else
            {
                dlgDKRaVao = new dlgRequestOutInShift();

                dlgDKRaVao.ShowDialog();
            }
        }

        private void grv_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column == colXemFile && grv.GetFocusedDataRow() != null)
            {
                FileStorageHelper _fh = new FileStorageHelper();

                var _a = grv.GetFocusedRowCellValue(colDataFile);

                var _duoiFile = grv.GetFocusedRowCellValue(colDuoiFile).ToString();

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

        private void frmRequestOverTime_v1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmRequestOutInShift_Load(null, null);
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
            myData.Add(this.Name, this.Text);
            listCtr.Add(this.Name);
            // dịch radiogrop duyệt 
            rdAccept.Properties.Items[0].Description = SelectTranslate("rdAcceptTatca", langTrans);
            rdAccept.Properties.Items[1].Description = SelectTranslate("rdAcceptDaDuyet", langTrans);
            rdAccept.Properties.Items[2].Description = SelectTranslate("rdAcceptKhongDuyet", langTrans);

            #endregion
        }

        #endregion

        private void frmRequestOutInShift_FormClosing(object sender, FormClosingEventArgs e)
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