using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using iHRM.Win.Cls;
using DevExpress.XtraEditors;
using iHRM.Core.FileDB;
using System.Data.Linq;
using System.IO;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class dlgUngVien : dlgBase
    {
        string _empID = "";
        List<Sex> arrSex = new List<Sex>();

        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
        public int CustomFormAction = -1;
        public dlgUngVien()
        {
            InitializeComponent();
            dlgData.IdColumnName = "EmployeeID";
            dlgData.CaptionColumnName = "EmployeeName";
            dlgData.FormCaption = "Thông tin ứng viên ";
            AddControlBinding();

        }
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        private void dlgEmployee_Load(object sender, EventArgs e)
        {
            LoadPreData();
        }
        public void visibleTab(bool isVisible)
        {
            tabQuanHeGD.PageVisible = isVisible;
            tabGiaoDucDaoTao.PageVisible = isVisible;
            tabKyNang.PageVisible = isVisible;
            tabKinhNghiemLamViec.PageVisible = isVisible;
        }
        private void LoadPreData()
        {
            lookupTinhTrangGD.Properties.DataSource = db.tblRef_MaritalStatus;
            resLookupQuanHeGD.DataSource = db.tblRef_Relations;
            repositoryItemLookUpLoaiHoSo.DataSource = db.tblRef_CurriculumVitaes;
            // Giới tính
            arrSex = new List<Sex>();
            arrSex.Add(new Sex { SexName = "Nam", SexID = "Nam" });
            arrSex.Add(new Sex { SexName = "Nữ", SexID = "Nữ" });
            arrSex.Add(new Sex { SexName = "Khác", SexID = "Khác" });
            lookupGioitinh.Properties.DataSource = arrSex;
            repositoryItemLookUpNgonNgu.DataSource = db.tblRef_Languages;
            repositoryItemLookUpPhanMem.DataSource = db.tblRef_TinHocs;
            lookupViTriTD_1.Properties.DataSource = db.tblRef_EmployeeTypes;
            lookupViTriTD_2.Properties.DataSource = db.tblRef_EmployeeTypes;
            repositoryItemSearchLookUpEditVanHoa.DataSource = db.tblRef_Educations;
        }
        private class Sex
        {
            public string SexName { get; set; }
            public string SexID { get; set; }
        }
        protected override void FormSetData()
        {
            base.FormSetData();
            _empID = myID as string;
            xtraTabControlUngVien.SelectedTabPage = tabThongTinUV;
            if (CustomFormAction == 0)
            {
                visibleTab(false);
            }
            else
            {
                visibleTab(true);
            }
        }

        public void AddControlBinding()
        {
            //Start thông tin dự tuyển
            dlgData.CB.Add(new ControlBinding("EmployeeID", txtMaNV, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SubmitDate", dateNgayNopHoSo, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("IdViTriDuTuyen1", lookupViTriTD_1, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("IdViTriDuTuyen2", lookupViTriTD_2, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("NgayCoTheBatDauLamViec", dateNgayBDLamViec, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("ThuNhapChapNhanDuoc", txtLuongChapNhanDuoc, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding("ThuNhapMongMuon", txtLuongMongMuon, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding("soChungTu", txtSoChungTu, ControlBinding_DataType.String));

            //Start thông tin ứng viên
            dlgData.CB.Add(new ControlBinding("FirstName", txtHo, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("LastName", txtTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("EmployeeName", txtHoTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("Birthday", dateNgaySinh, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("MaritalStatusID", lookupTinhTrangGD, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("SexID", lookupGioitinh, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ChieuCao", txtChieuCao, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("CanNang", txtCanNang, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SoCon", txtSoCon, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding("Phone", txtSDT, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("PhoneNhaRieng", txtNhaRieng, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("Email", txtEmail, ControlBinding_DataType.String));
            // Start CMND:
            dlgData.CB.Add(new ControlBinding("IDCard", txtSoCMND, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("IssuePlace", txtNoiCap, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("Address", txtQueQuan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("IssueDate", dateNgayCap, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("NativeCountry", txtDiaChi, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("PermanentAddress", txtDiaChiThuongTru, ControlBinding_DataType.String));

            // Người báo tin khẩn cấp
            dlgData.CB.Add(new ControlBinding("HoTenNguoiBaoTin", txtHoTenNguoiBaoTin, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("QuanHeNguoiBaoTin", txtQuanHeNguoiBaoTin, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("PhoneNguoiBaoTin", txtDienThoaiNguoiBaoTin, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("DiaChiNguoiBaoTin", txtDiaChiNguoiBaoTin, ControlBinding_DataType.String));

            // Các thông tin khác
            dlgData.CB.Add(new ControlBinding("SoThichCaNhan", memoSoThichCaNhan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("DiemManh", memoDiemManh, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("DiemYeu", memoDiemYeu, ControlBinding_DataType.String));
        }
        private void xtraTabControlUngVien_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            string namePage = e.Page.Name;
            switch (namePage)
            {
                case "tabQuanHeGD":
                    menuRefresh_QHGD_Click(null, null);
                    break;
                case "tabGiaoDucDaoTao":
                    menuRefresh_GDPT_Click(null, null);
                    menuRefresh_GDDH_Click(null, null);
                    menuRefresh_ChungChi_Click(null, null);
                    break;
                case "tabKyNang":
                    menuRefresh_KNMayTinh_Click(null, null);
                    menuRefresh_KNNgoaiNgu_Click(null, null);
                    break;
                case "tabKinhNghiemLamViec":
                    menuRefresh_KNLamViec_Click(null, null);
                    break;
                case "tabFilesLienQuan":
                    menuRefresh_Files_Click(null, null);
                    break;
                default: break;
            }
        }
        #region Set DateEdit null if Blank
        private void setDateNullIfBlank(DateEdit d)
        {
            if (d.Text == "")
            {
                d.EditValue = null;
            }
        }
        private void dateNgaySinh_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgaySinh);
        }

        private void dateNgayNopHoSo_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayNopHoSo);
        }

        private void dateNgayCap_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayCap);
        }
        #endregion

        #region Menu Refresh
        /// <summary>
        /// Lấy dữ liệu bảng dựa vào EmployeeID và addStrWhere
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="TableName"> Tên bảng</param>
        /// <param name="grc"></param>
        /// <param name="addStrWhere">Có thêm " AND " đằng trước</param>
        private void GetAllDataInTaBle_ByEmpID(string EmpID, string TableName, GridControl grc, string addStrWhere = "")
        {
            grc.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM {0} WHERE idUV = '{1}' {2} ORDER BY idx", TableName, EmpID, addStrWhere));
            (grc.DataSource as DataTable).AcceptChanges();
        }
        private void menuRefresh_QHGD_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblUV_QuanHeGiaDinh", grcQHGD);
        }
        private void menuRefresh_GDPT_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblUV_GiaoDuc", grcGDPT, " AND loaiGD ='GDPT'");
        }
        private void menuRefresh_GDDH_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblUV_GiaoDuc", grcGDDH, " AND loaiGD ='GDDH'");
        }
        private void menuRefresh_ChungChi_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblUV_ChungChi", grcChungChi);
        }
        private void menuRefresh_KNNgoaiNgu_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblUV_KyNangNgoaiNgu", grcKNNgoaiNgu);
        }
        private void menuRefresh_KNMayTinh_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblUV_KyNangMayTinh", grcKNMayTinh);
        }
        private void menuRefresh_KNLamViec_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblUV_KinhNghiemLamViec", grcKNLV);
        }
        #endregion

        #region Menu Delete
        private void deleteRecord(GridView grv)
        {
            //lay thong tin cac dong dc chon
            int[] idx = grv.GetSelectedRows();//GetSelectedRows tra lai index cua row dc chon
            if (idx.Length == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            var rows = idx.Select(i => grv.GetDataRow(i)); // GetDataRow tra lai dataarow cua datatable
            if (GUIHelper.ConfirmBox(string.Format("Bạn muốn xóa {0} bản ghi đã chọn?", rows.Count()), "Xác nhận lại"))
            {
                foreach (DataRow r in rows)
                    r.Delete();
                //r.Table.Rows.Remove(r);
            }
        }
        private void menuDelete_QHGD_Click(object sender, EventArgs e)
        {
            deleteRecord(grvQHGD);
        }
        private void menuDelete_KNMayTinh_Click(object sender, EventArgs e)
        {
            deleteRecord(grvKNMayTinh);
        }
        private void menuDelete_GDPT_Click(object sender, EventArgs e)
        {
            deleteRecord(grvGDPT);
        }
        private void menuDelete_GDDH_Click(object sender, EventArgs e)
        {
            deleteRecord(grvGDDH);
        }
        private void menuDelete_ChungChi_Click(object sender, EventArgs e)
        {
            deleteRecord(grvChungChi);
        }
        private void menuDelete_KNNgoaiNgu_Click(object sender, EventArgs e)
        {
            deleteRecord(grvKNNgoaiNgu);
        }
        private void menuDelete_KNLamViec_Click(object sender, EventArgs e)
        {
            deleteRecord(grvKNLV);
        }
        #endregion

        #region Menu Save
        private void menuSave_QHGD_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcQHGD.DataSource as DataTable), "tblUV_QuanHeGiaDinh"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)
            (grcQHGD.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
        private void menuSave_GDPT_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcGDPT.DataSource as DataTable), "tblUV_GiaoDuc"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)
            (grcGDPT.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
        private void menuSave_GDDH_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcGDDH.DataSource as DataTable), "tblUV_GiaoDuc"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)
            (grcGDDH.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
        private void menuSave_ChungChi_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcChungChi.DataSource as DataTable), "tblUV_ChungChi"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)
            (grcChungChi.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
        private void menuSave_KNNgoaiNgu_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcKNNgoaiNgu.DataSource as DataTable), "tblUV_KyNangNgoaiNgu"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)
            (grcKNNgoaiNgu.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
        private void menuSave_KNMayTinh_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcKNMayTinh.DataSource as DataTable), "tblUV_KyNangMayTinh"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)
            (grcKNMayTinh.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
        private void menuSave_KNLamViec_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcKNLV.DataSource as DataTable), "tblUV_KinhNghiemLamViec"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)
            (grcKNLV.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
        #endregion

        #region Init new row gridview

        private void grvKyNang_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvKNNgoaiNgu.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["idUV"] = _empID;
            }
        }
        private void grvKNMayTinh_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvKNMayTinh.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["idUV"] = _empID;
            }
        }
        private void grvKNLV_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvKNLV.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["idUV"] = _empID;
            }
        }
        private void grvGDPT_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvGDPT.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["idUV"] = _empID;
                dr["loaiGD"] = "GDPT";
            }
        }
        private void grvGDDH_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvGDDH.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["idUV"] = _empID;
                dr["loaiGD"] = "GDDH";
            }
        }
        private void grvChungChi_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvChungChi.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["idUV"] = _empID;
            }
        }
        private void grvQHGD_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvQHGD.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["idUV"] = _empID;
            }
        }
        #endregion

        #region CustomUnboundColumnData Event
        private void grvQHGD_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_QHGD)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvGDPT_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_GDPT)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvGDDH_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_GDDH)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvChungChi_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_ChungChi)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvKyNang_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_KNNgoaiNgu)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvKNMayTinh_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_KNMayTinh)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvKNLV_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_KNLamViec)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        #endregion

        private void lookupTinhTrangGD_EditValueChanged(object sender, EventArgs e)
        {
            var a = lookupTinhTrangGD.EditValue;
            if (a != null && Convert.ToInt16(a) == 2)
            {
                txtSoCon.EditValue = null;
                txtSoCon.Enabled = false;
            }
            else
            {
                txtSoCon.Enabled = true;
            }
        }
        #region Validate    
        private void grvGDPT_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = (e.Row as DataRowView).Row;
            if (r != null)
            {
                if (r["tuNgay"] == DBNull.Value || r["denNgay"] == DBNull.Value)
                {
                    e.ErrorText = "Bạn chưa nhập từ ngày hoặc đến ngày";
                    e.Valid = false;
                    return;
                }
                else
                {
                    if (Convert.ToDateTime(r["tuNgay"].ToString()) > Convert.ToDateTime(r["denNgay"].ToString()))
                    {
                        e.ErrorText = "Từ ngày không thể nhỏ hơn đến ngày";
                        e.Valid = false;
                        return;
                    }
                }
            }
        }

        private void grvGDDH_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = (e.Row as DataRowView).Row;
            if (r != null)
            {
                if (r["tuNgay"] == DBNull.Value || r["denNgay"] == DBNull.Value)
                {
                    e.ErrorText = "Bạn chưa nhập từ ngày hoặc đến ngày";
                    e.Valid = false;
                    return;
                }
                else
                {
                    if (Convert.ToDateTime(r["tuNgay"].ToString())> Convert.ToDateTime(r["denNgay"].ToString()))
                    {
                        e.ErrorText = "Từ ngày không thể nhỏ hơn đến ngày";
                        e.Valid = false;
                        return;
                    }
                }
            }
        }

        private void grvChungChi_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = (e.Row as DataRowView).Row;
            if (r != null)
            {
                if (r["tuNgay"] == DBNull.Value || r["denNgay"] == DBNull.Value)
                {
                    e.ErrorText = "Bạn chưa nhập từ ngày hoặc đến ngày";
                    e.Valid = false;
                    return;
                }
                else
                {
                    if (Convert.ToDateTime(r["tuNgay"].ToString()) > Convert.ToDateTime(r["denNgay"].ToString()))
                    {
                        e.ErrorText = "Từ ngày không thể nhỏ hơn đến ngày";
                        e.Valid = false;
                        return;
                    }
                }
                if (r["tenKhoaDaoTao"] == DBNull.Value)
                {
                    e.ErrorText = "Bạn chưa nhập tên khóa đào tạo";
                    e.Valid = false;
                    return;
                }
            }
        }
        #endregion

        private void dateNgayNopHoSo_EditValueChanged_1(object sender, EventArgs e)
        {
            if (dateNgayNopHoSo.Text == "")
            {
                dateNgayNopHoSo.EditValue = null;
            }
        }

        private void dateNgayBDLamViec_EditValueChanged(object sender, EventArgs e)
        {
            if (dateNgayBDLamViec.Text == "")
            {
                dateNgayBDLamViec.EditValue = null;
            }
        }

        private void txtHo_Leave(object sender, EventArgs e)
        {
            txtHoTen.Text = txtHo.Text + " " + txtTen.Text; 
        }

        private void txtTen_Leave(object sender, EventArgs e)
        {
            txtHoTen.Text = txtHo.Text + " " + txtTen.Text;
        }

        private void menuRefresh_Files_Click(object sender, EventArgs e)
        {
            var a = Provider.ExecuteDataTable("p_tblUV_FilesLienQuan_GetAll", new System.Data.SqlClient.SqlParameter("idUV", _empID));
            a.Columns.Add("idFileDelete");
            grcFilesLienQuan.DataSource = a;
            (grcFilesLienQuan.DataSource as DataTable).AcceptChanges();
        }

        private void menuDelete_Files_Click(object sender, EventArgs e)
        {
            deleteRecord(grvFilesLienQuan);
        }

        private void menuSave_Files_Click(object sender, EventArgs e)
        {
            DataTable dt = (grcFilesLienQuan.DataSource as DataTable);
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }
            FileStorageHelper fg = new FileStorageHelper();
            var count = dt.GetChanges().Rows.Count;
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
                                fg.DeleteFileByIDDBFiles(Guid.Parse(dr["idFileDelete"].ToString()));
                            }
                        }
                        else
                        {
                            fg.InsertOrUpdateDBFiles(Guid.Parse(dr["idFile"].ToString()), dr["dataFile"] as byte[],dr["duoiFile"].ToString());
                        }
                    }
                }
                Provider.UpdateData(dt, "tblUV_FilesLienQuan");
                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception ex)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void resItemButtonFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dr = grvFilesLienQuan.GetFocusedDataRow();
            if (e.Button.Index == 0)// Xem file
            {
                if (dr != null && dr["dataFile"] != DBNull.Value)
                {
                    FileStorageHelper fh = new FileStorageHelper();

                    var duoiFile = grvFilesLienQuan.GetFocusedRowCellValue(colDuoiFile).ToString();
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
                        if (dr["ghiChu"] == DBNull.Value || String.IsNullOrEmpty(dr["ghiChu"].ToString()))
                        {
                            dr["ghiChu"] = Path.GetFileName(od.FileNames[0]).Replace(Path.GetExtension(od.FileNames[0]), "");
                        }
                        if (dr["idFile"] == DBNull.Value)
                        {
                            dr["idFile"] = Guid.NewGuid();
                        }
                    }
                }
                else
                {
                    grvFilesLienQuan.AddNewRow();
                    dr = grvFilesLienQuan.GetFocusedDataRow();
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
                        dr["ghiChu"] = Path.GetFileName(od.FileNames[0]).Replace(Path.GetExtension(od.FileNames[0]),"");
                        dr["duoiFile"] = Path.GetExtension(od.FileNames[0]);
                        if (dr["idFile"] == DBNull.Value)
                        {
                            dr["idFile"] = Guid.NewGuid();
                        }
                    }
                    //GUIHelper.Notifications("Không có dữ liệu để chọn. Bạn phải nhập Ghi chú trước.", "Chọn file", GUIHelper.NotifiType.error);
                }
            }
            else if (e.Button.Index == 2) // Xóa file
            {
                if (dr != null)
                {
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

        private void grvFilesLienQuan_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvFilesLienQuan.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["idUV"] = _empID;
            }
        }

        private void txtChieuCao_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}