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

namespace iHRM.Win.Frm.TuyenDung
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class frmDanhGiaNhanSu_v1 : frmBase
    {
        //Khai báo biến//
        private int _thuViec = 1;

        public String thuViec { get { return _thuViec.ToString(); } set { _thuViec = int.Parse(value); } }

        LogicBase _logic = new LogicBase();

        DataTable _dt = new DataTable();

        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        //String _FilesChoised = "";

        DataRow _CRow;

        List<PhamVi> _arr = new List<PhamVi>();

        DataTable _dtData = new DataTable();
        //---//

        public frmDanhGiaNhanSu_v1()
        {
            InitializeComponent();
        }

        private void InitLookUp(int _thuViec)
        {
            if (_thuViec == 1)
            {
                lkLoaiHD.Properties.DataSource = _db.tblRef_ContractTypes.Where(i => i.ContractTypeID == "2").ToList();

                lkLoaiHD.EditValue = "2";
            }
            else

                lkLoaiHD.Properties.DataSource = _db.tblRef_ContractTypes.Where(i => i.ContractTypeID != "2").ToList();

            _arr.Add(new PhamVi { PhamViID = "TT", PhamViName = "Tổ trưởng" });

            _arr.Add(new PhamVi { PhamViID = "QL", PhamViName = "Quản lý" });

            _arr.Add(new PhamVi { PhamViID = "XT", PhamViName = "Xưởng trưởng" });

            _arr.Add(new PhamVi { PhamViID = "KHAC", PhamViName = "Khác" });

            lkPhamVi.Properties.DataSource = _arr;

            lkPhamVi.EditValue = "TT";
        }

        private void frmDanhGiaNhanSu_v1_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);

            InitLookUp(_thuViec);

            repItemQLDuyet.DataSource = _db.w5sysUsers;

            if (LoginHelper.user.isAcceptBP == true || LoginHelper.user.isAdmin)
            {
                toolStripAccept.Visible = true;
                toolStripNotAccept.Visible = true;
            }
            else
            {
                toolStripAccept.Visible = false;
                toolStripNotAccept.Visible = false;
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _CRow = grv.GetFocusedDataRow();

            if (_CRow != null) //Kiểm tra Focused có dữ liệu
            {
                int[] rc = grv.GetSelectedRows(); //Lấy dữ liệu trong lưới

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        

                        if (grv.FocusedRowHandle != -1)
                        {
                            String _user = "";

                            if (ckbAll.Checked || r["isAccept"] != DBNull.Value) _user = ""; //Phạm vi đánh giá 

                            else 
                                _user = lkPhamVi.EditValue as String;

                            if(r["soDanhGia"] != DBNull.Value)
                            {
                                dlgDanhGiaNhanSu_v1 _dlg = new dlgDanhGiaNhanSu_v1();

                                _dlg._CRow = _CRow;

                                _dlg._flag = 1;

                                _dlg._user = _user;

                                _dlg._idNV = r["idNV"] as String;

                                _dlg.ShowDialog();
                            }
                            else
                            {
                                dlgDanhGiaNhanSu_v1 _dlg = new dlgDanhGiaNhanSu_v1();

                                _dlg._CRow = _CRow;

                                _dlg._flag = 0;

                                _dlg._user = _user;

                                _dlg._idNV = r["idNV"] as String;

                                _dlg.ShowDialog();
                            }
                            
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item _dw_it = new mainBase.Dowork_Item();

            String _table_name = "p_GetDanhGiaNhanSu_byWhere";

            _dw_it.Caption = "Đang tải dữ liệu nhân viên...";

            _dw_it.OnDoing = (s, ev) =>
            {
                int isAll = 0;

                if (ckbAll.Checked)
                {
                    isAll = 1;
                }

                if (ckbDDG.Checked)
                {
                    isAll = 1;
                }

                _logic.VirtualPaging.PageSize = pageNavigator1.PageSize;

                _logic.VirtualPaging.Page = pageNavigator1.CurrentPage;

                SqlParameter[] _par = {
                                new SqlParameter("@SearchKey", txtSearch.Text),

                                new SqlParameter("@tuNgay", chonKyLuong1.TuNgay),

                                new SqlParameter("@denNgay", chonKyLuong1.DenNgay_End),

                                new SqlParameter("@idPB", chonPhongBan.SelectedValue),

                                new SqlParameter("@PhamVi", lkPhamVi.EditValue),

                                new SqlParameter("@LoaiHD", lkLoaiHD.EditValue),

                                new SqlParameter("@isall", isAll)
                                };

                _dt = _logic.GetAllDep(_table_name, _par);

                _dw_it.bw.ReportProgress(1, _dt);

                _dw_it.bw.ReportProgress(2, _logic.VirtualPaging.RecordCount);
            };

            _dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState; btnSearch.Enabled = true;
                }
                else if (data.ProgressPercentage == 2)
                {
                    pageNavigator1.RecordCount = (int)data.UserState;
                }
            };

            main.Instance.DoworkItem_Reg(_dw_it);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //frmDanhGiaNhanSu_v1_Load(null, null);
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            _CRow = grv.GetFocusedDataRow();
        }

        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "isAccept") != null
                && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAccept").ToString()))
            {

                if (grv.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "True")
                {
                    e.Appearance.ForeColor = Color.Green;
                }

                else if (grv.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "False")
                {
                    e.Appearance.ForeColor = Color.Red;
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

                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }

                        if (r["isKyHopDong"] == DBNull.Value )
                        {
                            GUIHelper.MessageBox("Vui lòng chọn quyết định cuối cùng để duyệt!");

                            continue;
                        }

                        r["isAccept"] = true;

                        r["userAccept"] = LoginHelper.user.id;

                        _listActionClass.Add(new ActionClass("Duyệt đánh giá nhân viên SDG: " + r["soDanhGia"].ToString()
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Duyệt đánh giá nhân viên ngày: " + DateTime.Now.Date
                                                            , "tbDanhGiaNhanSu"));
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

                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }

                        if (r["isKyHopDong"] == DBNull.Value)
                        {
                            GUIHelper.MessageBox("Vui lòng chọn quyết định cuối cùng để duyệt!");

                            continue;
                        }

                        r["isAccept"] = false;

                        r["userAccept"] = LoginHelper.user.id;

                        _listActionClass.Add(new ActionClass("Không duyệt đánh giá nhân viên SDG: " + r["soDanhGia"].ToString()
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Không duyệt đánh giá nhân viên ngày: " + DateTime.Now.Date
                                                            , "tbDanhGiaNhanSu"));
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

            var count = _dt.GetChanges().Rows.Count;

            try
            {
                _listActionClass.Add(new ActionClass("Sửa dữ liệu" 
                                            , ""
                                            , ""
                                            , string.Format("Cập nhật đánh giá nhân sự") + LoginHelper.user.id + " - Ngày: " + DateTime.Now.Date
                                            , "tbDanhGiaNhanSu"));

                Provider.UpdateData(_dt, "tbDanhGiaNhanSu");

                LogAction.LogAction.PushLog(_listActionClass);

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private class PhamVi
        {
            public string PhamViID { get; set; }
            public string PhamViName { get; set; }
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));

            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }

            foreach (var item in drs)
            {
                var a = Provider.ExecuteDataTableReader("p_export_DanhGiaNhanVien"
                                                        , new System.Data.SqlClient.SqlParameter("idDG", item["id"].ToString()));

                var rp = new rep_DanhGiaNV(0);

                rp.DataBindings(a);

                ReportViewer rv = new ReportViewer();

                rv.ViewReport(rp);
            }
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}