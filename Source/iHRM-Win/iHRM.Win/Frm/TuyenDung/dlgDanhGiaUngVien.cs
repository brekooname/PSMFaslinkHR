using DevExpress.XtraEditors;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using iHRM.Win.Frm.XtraReportTemplate;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class dlgDanhGiaUngVien : dlgBase
    {
        dcDatabaseDataContext db;
        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
        public int CustomFormAction = -1;
        public int _idDG = 0;
        public int _idYCTD_UV = 0;
        public string duoiFile = "";
        public byte[] dataFile;
        public bool isChangedFile = false;
        public dlgDanhGiaUngVien()
        {
            InitializeComponent();
            //dlgData.IdColumnName = "id";
            //dlgData.CaptionColumnName = "tenDotTD";
            dlgData.FormCaption = "Đánh giá ứng viên ";

            //#region
            //if (LoginHelper.user.isAcceptBP == true || LoginHelper.user.isAdmin || LoginHelper.user.isAcceptable == true)
            //{
            //    chkGDPheDuyet.Visible = true;
            //    labelControl1.Visible = true;
            //}
            //else
            //{
            //    chkGDPheDuyet.Visible = false;
            //    labelControl1.Visible = false;
            //}
            //#endregion

        }
        public void setVisibleTabPage(bool isVisibleTab1, bool isVisibleTab2, bool isVisibleTab3)
        {
            xtraTabPhanGhiNhan.PageVisible = isVisibleTab1;
            xtraTabPVChuyenMon.PageVisible = isVisibleTab2;
            xtraTabPheDuyetGD.PageVisible = isVisibleTab3;
        }
        public void setEnableTabPage(bool isEnableTab1, bool isEnableTab2)
        {
            setReadOnly(groupControl2, isEnableTab1);
            setReadOnly(groupControl3, isEnableTab1);
            setReadOnly(groupControl4, isEnableTab1);

            setReadOnly(groupControl5, isEnableTab2);
            setReadOnly(groupControl6, isEnableTab2);
        }
        private void setReadOnly(Control ctr, bool isReadOnly)
        {
            foreach (Control item in ctr.Controls)
            {

                if (item is ButtonEdit)
                {
                    ((ButtonEdit)item).Enabled = !isReadOnly;
                }
                else if (item is TextEdit)
                {
                    ((TextEdit)item).ReadOnly = isReadOnly;
                }
                else if (item is DateEdit)
                {
                    ((DateEdit)item).ReadOnly = isReadOnly;
                }
                else if (item is LookUpEdit)
                {
                    ((LookUpEdit)item).ReadOnly = isReadOnly;
                }
                else if (item is MemoEdit)
                {
                    ((MemoEdit)item).ReadOnly = isReadOnly;
                }
                else if (item is RadioGroup)
                {
                    ((RadioGroup)item).ReadOnly = isReadOnly;
                }
                else if (item is ComboBoxEdit)
                {
                    ((ComboBoxEdit)item).ReadOnly = isReadOnly;
                }
            }
        }
        private void dlgTuyenDung_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            AddBinddingControl();

            //if (this.MyValue["ketQuaVong1"].ToString() == string.Empty)
            //{
            //    xtraTabPVChuyenMon.PageVisible = false;
            //    xtraTabPheDuyetGD.PageVisible = false;
            //}
            //if (this.MyValue["ketQuaVong2"].ToString() == string.Empty)
            //{
            //    //xtraTabPVChuyenMon.PageVisible = false;
            //    xtraTabPheDuyetGD.PageVisible = false;
            //}
        }
        private void AddBinddingControl()
        {
            //dlgData.CB.Add(new ControlBinding("gioiTinh", rdNamNu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("soChungTu", txtSoChungTu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("doTuoi", rdDoTuoi, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("trinhDoHocVan", rdTrinhDoHocVan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("kienThucChuyenMon", rdKienThucChuyenMon, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("kinhNghiemCongViec", rdKinhNghiemCongViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("mucTieuCongViec", rdMucTieuCongViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("dienMaoTacPhong", memoDienMaoTacPhong, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("giongNoi", memoGiongNoi, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("thaiDoTinhCach", memoThaiDoTinhCach, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("trinhBayDienDat", memoTrinhBay, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("xuLyTinhHuong", memoXuLyTinhHuong, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("khaNangLanhDao", memoKhaNangLanhDao, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("khaNangNgoaiNgu", memoKhaNangNgoaiNgu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("khaNangTinHoc", memoKhaNangTinHoc, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("khaNangKhac", memoKhaNangKhac, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ketLuanSoVan", rdKetLuanSoVan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("viTriPhuHop", txtViTriPhuHop, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ngayKetLuanSoVan", dateKetLuanVongSoVan, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("idNhanVienKetLuanSoVan", lookUpNhanVienDG_SoVan, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding("kienThucCongViec", memoKienThucCongViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("kyNangNgheNghiep", memoKyNangNgheNghiep, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("kinhNghiemLienQuan", memoKinhNghiemLienQuan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ghiNhanKhac", memoGhiNhanKhac, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("danhGiaChuyenMon", memoKetLuanChuyenMon, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ketLuanChuyenMon", rdKetLuanChuyenMon, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ketQuaKienThucCV", rdKienThucCongViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ngayKetLuanChuyenMon", dateKetLuanChuyenMon, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("idNhanVienKetLuanChuyenMon", lookUpNhanVienDG_ChuyenMon, ControlBinding_DataType.String));


            dlgData.CB.Add(new ControlBinding("viTriTuyenDung", lookupViTriTD, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("chucVuTuyenDung", lookupChucVu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ngayNhanViec", dateNgayNhanViec, ControlBinding_DataType.DateTime));
           
            dlgData.CB.Add(new ControlBinding("cheDoKhac", memoCheDoKhac, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding("KNCM", searchLookUpKNCM, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ngayPheDuyet", datePheDuyet, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("idNhanVienPheDuyet", lookUpNhanVienPheDuyet, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("lyDoPheDuyet", memoLyDoPheDuyet, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("isAcceptGD", chkGDPheDuyet, ControlBinding_DataType.Bool));


            dlgData.CB.Add(new ControlBinding("luongChinhThuc", txtLuongChinhThuc, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("luongThuViec", txtLuongThuViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("luongBaoHiem", txtLuongBaoHiem, ControlBinding_DataType.String));
        }
        public void loadPredata()
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            var a = from yc_uv in db.tblYeuCauTD_UngViens.Where(p => p.id == _idYCTD_UV)
                    join vtd in db.tblYeuCauTD_VongTuyenDungs on yc_uv.idYCTD equals vtd.idYeuCauTD
                    join vtd_hd in db.tblYeuCauTD_VongTD_HoiDongPVs on vtd.id equals vtd_hd.idYeuCauTD_VongTD
                    select vtd_hd;
            DataTable dt = Provider.ExecuteDataTable("p_tblEmployee_getNV_PB",
                    new System.Data.SqlClient.SqlParameter("idPB", LoginHelper.user.idKhoiPB));
            lookUpNhanVienDG_SoVan.Properties.DataSource = lookUpNhanVienDG_ChuyenMon.Properties.DataSource = a;
            lookUpNhanVienPheDuyet.Properties.DataSource = dt;
            lookupViTriTD.Properties.DataSource = db.tblRef_EmployeeTypes;
            //txtViTriPhuHop.Properties.DataSource = db.tblRef_EmployeeTypes;
            lookupChucVu.Properties.DataSource = db.tblRef_Positions;
            searchLookUpKNCM.Properties.DataSource = db.tblRef_KNCMs;
        }

        private void rdKetLuanSoVan_EditValueChanged(object sender, EventArgs e)
        {
            if (rdKetLuanSoVan.SelectedIndex == 2)
            {
                txtViTriPhuHop.Enabled = true;
            }
            else
            {
                txtViTriPhuHop.Enabled = false;
                txtViTriPhuHop.EditValue = null;
            }
        }
        protected override void FormGetData()
        {
            base.FormGetData();
            this.MyValue["ketQuaVong1"] = rdKetLuanSoVan.SelectedIndex;
            this.MyValue["ketQuaVong2"] = rdKetLuanChuyenMon.SelectedIndex;
            if (chonPhongBan1.SelectedValue == null)
                this.MyValue["donViQuanLy"] = DBNull.Value;
            else
                this.MyValue["donViQuanLy"] = chonPhongBan1.SelectedValue;
            this.MyValue["ketQuaKyNangNN"] = rdKyNangNgheNghiep.SelectedIndex;
            this.MyValue["ketQuaPheDuyet"] = rdKetQuaPheDuyet.SelectedIndex;
            if (cbThoiGianThuViec.SelectedIndex >= 0) // Select 0. giá trị =1 . Select 1. giá trị = 2
                this.MyValue["thoiGianThuViec"] = int.Parse(cbThoiGianThuViec.EditValue.ToString());
            else
                this.MyValue["thoiGianThuViec"] = DBNull.Value;
            #region Kiểm tra thông tin tab đánh giá chuyên môn
            if (xtraTabPhanGhiNhan.PageVisible && xtraTabPVChuyenMon.PageVisible && !xtraTabPheDuyetGD.PageVisible)
            {
                if (memoKienThucCongViec.Text == string.Empty)
                {
                    this.MyValue["gioiTinh"] = "1";
                    this.memoKienThucCongViec.Focus();

                }
                else
                {
                    if (rdKienThucCongViec.SelectedIndex == -1)
                    {
                        this.MyValue["gioiTinh"] = "2";
                    }
                    else
                    {
                        if (memoKyNangNgheNghiep.Text == string.Empty)
                        {
                            this.MyValue["gioiTinh"] = "3";
                            memoKyNangNgheNghiep.Focus();
                        }
                        else
                        {
                            if (rdKyNangNgheNghiep.SelectedIndex == -1)
                            {
                                this.MyValue["gioiTinh"] = "4";
                            }
                            else
                            {
                                if (memoKetLuanChuyenMon.Text == string.Empty && memoKetLuanChuyenMon.Enabled)
                                {
                                    this.MyValue["gioiTinh"] = "5";
                                    memoKetLuanChuyenMon.Focus();
                                }
                                else
                                {
                                    if (rdKetLuanChuyenMon.SelectedIndex == -1)
                                    {
                                        this.MyValue["gioiTinh"] = "6";
                                    }
                                    else
                                        this.MyValue["gioiTinh"] = "7";
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region kiểm tra thông tin tab phê duyệt trưởng bộ phận
            if (xtraTabPhanGhiNhan.PageVisible && xtraTabPVChuyenMon.PageVisible && xtraTabPheDuyetGD.PageVisible)
            {
                if (lookupViTriTD.EditValue == null)
                {
                    this.MyValue["gioiTinh"] = "8";
                    lookupViTriTD.Focus();
                }
                else
                {
                    if (lookupChucVu.EditValue == null)
                    {
                        this.MyValue["gioiTinh"] = "9";
                        lookupChucVu.Focus();
                    }
                    else
                    {
                        if (chonPhongBan1.SelectedValue == null)
                        {
                            this.MyValue["gioiTinh"] = "10";
                            chonPhongBan1.Focus();
                        }
                        else
                        {
                            if (dateNgayNhanViec.DateTime.Year == 1)
                            {
                                this.MyValue["gioiTinh"] = "11";
                                dateNgayNhanViec.Focus();
                            }
                            else
                            {
                                if (cbThoiGianThuViec.Text == string.Empty)
                                {
                                    this.MyValue["gioiTinh"] = "12";
                                    cbThoiGianThuViec.Focus();
                                }
                                else
                                {
                                    if (txtLuongChinhThuc.Text == string.Empty)
                                    {
                                        this.MyValue["gioiTinh"] = "13";
                                        txtLuongChinhThuc.Focus();
                                    }
                                    else
                                    {
                                        if (txtLuongThuViec.Text == string.Empty)
                                        {
                                            this.MyValue["gioiTinh"] = "14";
                                            txtLuongThuViec.Focus();
                                        }
                                        else
                                        {
                                            if (txtLuongBaoHiem.Text == string.Empty)
                                            {
                                                this.MyValue["gioiTinh"] = "15";
                                                txtLuongBaoHiem.Focus();
                                            }
                                            else
                                            {
                                                if (memoLyDoPheDuyet.Text == string.Empty && memoLyDoPheDuyet.Enabled)
                                                {
                                                    this.MyValue["gioiTinh"] = "16";
                                                    memoLyDoPheDuyet.Focus();
                                                }
                                                else
                                                {
                                                    if (rdKetQuaPheDuyet.SelectedIndex == -1)
                                                    {
                                                        this.MyValue["gioiTinh"] = "17";
                                                    }
                                                    else
                                                    {
                                                        if (searchLookUpKNCM.Text == string.Empty)
                                                        {
                                                            this.MyValue["gioiTinh"] = "19";
                                                            searchLookUpKNCM.Focus();
                                                        }
                                                        else
                                                        {
                                                            this.MyValue["gioiTinh"] = "18";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            if (txtPhanTramKNCM.Text == "" )
            {
                this.MyValue["PhanTramNgoai"] = DBNull.Value;
            }
            else
            {
                this.MyValue["PhanTramNgoai"] = txtPhanTramKNCM.Text;
            }
            this.MyValue["tenFile"] = btnFile.Text;
        }
        protected override void FormSetData()
        {
            base.FormSetData();
            if (this.MyValue["donViQuanLy"] != DBNull.Value)
            {
                chonPhongBan1.SelectedValue = this.MyValue["donViQuanLy"].ToString();
            }
            else
                chonPhongBan1.SelectedValue = null;

            if (this.MyValue["ketQuaKienThucCV"] != DBNull.Value)
            {
                rdKienThucCongViec.SelectedIndex = Convert.ToInt32(this.MyValue["ketQuaKienThucCV"].ToString());
            }
            else
            {
                rdKienThucCongViec.SelectedIndex = -1;
            }
            if (this.MyValue["ketQuaKyNangNN"] != DBNull.Value)
            {
                rdKyNangNgheNghiep.SelectedIndex = Convert.ToInt32(this.MyValue["ketQuaKyNangNN"].ToString());
            }
            else
            {
                rdKienThucCongViec.SelectedIndex = -1;
            }

            if (this.MyValue["ketQuaPheDuyet"] != DBNull.Value)
            {
                rdKetQuaPheDuyet.SelectedIndex = Convert.ToInt32(this.MyValue["ketQuaPheDuyet"].ToString());
            }
            else
            {
                rdKetQuaPheDuyet.SelectedIndex = -1;
            }

            if (this.MyValue["ketQuaVong2"] != DBNull.Value)
            {
                rdKetLuanChuyenMon.SelectedIndex = Convert.ToInt32(this.MyValue["ketQuaVong2"].ToString());
            }
            else
            {
                rdKetLuanChuyenMon.SelectedIndex = -1;
            }

            if (this.MyValue["thoiGianThuViec"] != DBNull.Value)
            {
                cbThoiGianThuViec.SelectedIndex = Convert.ToInt32(this.MyValue["thoiGianThuViec"].ToString()) - 1; // Select 0. giá trị =1 . Select 1. giá trị = 2
            }
            else
            {
                cbThoiGianThuViec.SelectedIndex = -1;
            }
            if (this.MyValue["PhanTramNgoai"] != DBNull.Value)
            {
                txtPhanTramKNCM.Text = this.MyValue["PhanTramNgoai"].ToString();
            }
            else
            {
                txtPhanTramKNCM.Text = "";
            }
            //Display file
            if (this.MyValue["duoiFile"] != DBNull.Value)
            {
                lbDuoiFile.Text = this.MyValue["duoiFile"] as string;
            }
            if (this.MyValue["tenFile"] != DBNull.Value)
            {
                btnFile.Text = this.MyValue["tenFile"] as string;
            }
            else
            {
                btnFile.Text = "";
            }

            if (this.MyValue["luongChinhThuc"] != DBNull.Value)
            {
                txtLuongChinhThuc.Text = this.MyValue["luongChinhThuc"].ToString();
            }
            if (this.MyValue["luongThuViec"] != DBNull.Value)
            {
                txtLuongThuViec.Text = this.MyValue["luongThuViec"].ToString();
            }
            if (this.MyValue["luongBaoHiem"] != DBNull.Value)
            {
                txtLuongBaoHiem.Text = this.MyValue["luongBaoHiem"].ToString();
            }
        }

        private void btnXuatDanhGia_Click(object sender, EventArgs e)
        {
            var rp = new rep_phieu_DanhGiaUV();
            var a = Provider.ExecuteDataTableReader("p_export_tblUV_DanhGia_byID", new System.Data.SqlClient.SqlParameter("idDG", this.MyValue["id"]));
            rp.DataBindings(a);
            ReportViewer rv = new ReportViewer();
            rv.ViewReport(rp);
        }

        private void rdKetLuanSoVan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdKetLuanSoVan.SelectedIndex == 2)
            {
                txtViTriPhuHop.Visible = true;
                //load tất cả những yêu cầu nà
                DataTable vitrikhac = Provider.ExecuteDataTable("p_getAll_ViTriKhac");
                //var yctd=db.tbYeuCauTuyenDungs.Where(p=>p.ngayYeuCau )
                txtViTriPhuHop.Properties.DataSource = vitrikhac;

            }
        }

        private void TinhLuong()
        {
            try
            {
                bool isok = false;
                //if (lookupChucVu.EditValue != null)
                //{
                //    isok = true;
                //}
                //if (chonPhongBan1.SelectedValue != null)
                //{
                //    isok = true;
                //}
                //if (searchLookUpKNCM.EditValue != null)
                //{
                //    isok = true;
                //}
                if (lookupChucVu.EditValue != null && chonPhongBan1.SelectedValue != null  )
                {
                    isok = true;
                }
                if (isok)
                {
                    DataTable dt = Provider.ExecuteDataTableReader("p_TD_TinhLuong",
                        new System.Data.SqlClient.SqlParameter("idChucVu", lookupChucVu.EditValue),
                        new System.Data.SqlClient.SqlParameter("idPhongBan", LoginHelper.Context.getKhoi(chonPhongBan1.SelectedValue)),
                        new System.Data.SqlClient.SqlParameter("idKNCM", searchLookUpKNCM.EditValue),
                        new System.Data.SqlClient.SqlParameter("PTKNCM", txtPhanTramKNCM.Text)
                        );

                    if (dt.Rows.Count > 0)
                    {
                        foreach(DataRow r in dt.Rows )
                        {
                            txtLuongChinhThuc.Text = r["LuongChinh"].ToString();
                            txtLuongThuViec.Text = r["LuongTV"].ToString();
                            txtLuongBaoHiem.Text = r["LuongBH"].ToString();
                        }
                    }
                    else
                    {
                        txtLuongChinhThuc.Text = "0";
                        txtLuongBaoHiem.Text = "0";
                        txtLuongThuViec.Text = "0";
                    }

                }
                else
                {
                    txtLuongChinhThuc.Text = "0";
                    txtLuongBaoHiem.Text = "0";
                    txtLuongThuViec.Text = "0";
                }
            }
            catch { }
        }

        private void txtViTriPhuHop_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void txtViTriPhuHop_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpKNCM_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;

                if (searchEdit.Properties.View.GetFocusedRowCellValue("isPhanTram") != null)
                {
                    string isPT = searchEdit.Properties.View.GetFocusedRowCellValue("isPhanTram").ToString();
                    if (isPT == "True")
                    {
                        txtPhanTramKNCM.Enabled = true;
                        txtPhanTramKNCM.Focus();
                    }
                    else
                    {
                        txtPhanTramKNCM.Enabled = false;
                        txtPhanTramKNCM.Text = string.Empty;
                        TinhLuong();
                    }
                }

               
            }
            catch { }
           
        }

        private void txtPhanTramKNCM_ValueChanged(object sender, EventArgs e)
        {
            TinhLuong();
        }

        private void lookupChucVu_EditValueChanged(object sender, EventArgs e)
        {
            LoadKNCM();
            TinhLuong();
        }

        void LoadKNCM()
        {
            //searchLookUpKNCM.Properties.DataSource = null;
            //if (lookupChucVu.EditValue != null && chonPhongBan1.SelectedValue != null)
            //{
            //    searchLookUpKNCM.Properties.DataSource = db.tblRef_KNCMs.Where(p => p.CapBacID == lookupChucVu.EditValue && p.KhoiID == LoginHelper.Context.getKhoi(chonPhongBan1.SelectedValue));
            //    searchLookUpKNCM.Properties.DisplayMember = "TenMuc";
            //    searchLookUpKNCM.Properties.ValueMember = "MucID";
            //}
            //else
            //{
            //    if(lookupChucVu.EditValue != null && chonPhongBan1.SelectedValue == null)
            //    {
            //        searchLookUpKNCM.Properties.DataSource = db.tblRef_KNCMs.Where(p => p.CapBacID == lookupChucVu.EditValue);
            //        searchLookUpKNCM.Properties.DisplayMember = "TenMuc";
            //        searchLookUpKNCM.Properties.ValueMember = "MucID";
            //    }else
            //    {
            //        if(lookupChucVu.EditValue == null && chonPhongBan1.SelectedValue != null)
            //        {
            //            searchLookUpKNCM.Properties.DataSource = db.tblRef_KNCMs.Where(p => p.KhoiID == LoginHelper.Context.getKhoi(chonPhongBan1.SelectedValue));
            //            searchLookUpKNCM.Properties.DisplayMember = "TenMuc";
            //            searchLookUpKNCM.Properties.ValueMember = "MucID";
            //        }
            //        else
            //        {
            //            searchLookUpKNCM.Properties.DataSource = null;
            //            searchLookUpKNCM.Properties.DisplayMember = "TenMuc";
            //            searchLookUpKNCM.Properties.ValueMember = "MucID";
            //        }
            //    }
            //}
            
        }

        private void chonPhongBan1_OnSelected(object sender, EventArgs e)
        {
            LoadKNCM();
            TinhLuong();
        }


      
        private void rdKetLuanChuyenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdKetLuanChuyenMon.SelectedIndex == 1)
            {
                memoKetLuanChuyenMon.Enabled = true;
            }
            else
            {
                memoKetLuanChuyenMon.Enabled = false;
                memoKetLuanChuyenMon.Text = string.Empty;
            }
        }

        private void rdKetQuaPheDuyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdKetQuaPheDuyet.SelectedIndex == 1)
            {
                memoLyDoPheDuyet.Enabled = true;
            }
            else
            {
                memoLyDoPheDuyet.Enabled = false;
                memoLyDoPheDuyet.Text = string.Empty;
            }
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
                    if (this.MyValue["idFile"] == DBNull.Value)
                    {
                        this.MyValue["idFile"] = Guid.NewGuid();
                    }
                    try
                    {
                        this.MyValue["dataFile"] = System.IO.File.ReadAllBytes(od.FileNames[0]);
                        btnFile.Text = od.FileNames[0];
                    }
                    catch (Exception)
                    {
                        isChangedFile = false;
                        throw;
                    }
                    duoiFile = Path.GetExtension(btnFile.Text);
                    lbDuoiFile.Text = duoiFile;
                    this.MyValue["duoiFile"] = duoiFile;
                    isChangedFile = true;
                }
            }
            else //Hủy file
            {
                btnFile.Text = "";
                lbDuoiFile.Text = "";
                this.MyValue["dataFile"] = DBNull.Value;
                this.MyValue["duoiFile"] = DBNull.Value;
                isChangedFile = true;
            }
        }

        private void lbXemFile_MouseClick(object sender, MouseEventArgs e)
        {
            FileStorageHelper fh = new FileStorageHelper();
            if (this.MyValue["dataFile"] != DBNull.Value && this.MyValue["duoiFile"] != DBNull.Value)
            {
                fh.DownLoadAndShowFILE(this.MyValue["dataFile"] as byte[], this.MyValue["duoiFile"].ToString());
            }
            else
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
        }

        private void lookUpNhanVienDG_SoVan_EditValueChanged(object sender, EventArgs e)
        {
            var chucvu = db.tblEmployees.Where(p => p.EmployeeID == lookUpNhanVienDG_SoVan.EditValue).FirstOrDefault();
            if (chucvu != null)
                textEdit2.Text = chucvu.EmpTypeName;
        }

        private void lookUpNhanVienDG_ChuyenMon_EditValueChanged(object sender, EventArgs e)
        {
            var chucvu = db.tblEmployees.Where(p => p.EmployeeID == lookUpNhanVienDG_ChuyenMon.EditValue).FirstOrDefault();
            if (chucvu != null)
                textEdit3.Text = chucvu.EmpTypeName;
        }

        private void lookUpNhanVienPheDuyet_EditValueChanged(object sender, EventArgs e)
        {
            var loainhanvien = db.tblEmployees.Where(p => p.EmployeeID == lookUpNhanVienPheDuyet.EditValue).FirstOrDefault();
            if (loainhanvien != null)
                textEdit5.Text = loainhanvien.EmpTypeName;
        }
    }
}
