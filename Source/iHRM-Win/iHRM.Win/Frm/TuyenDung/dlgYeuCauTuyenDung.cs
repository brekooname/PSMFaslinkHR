using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class dlgYeuCauTuyenDung : dlgBase
    {
        dcDatabaseDataContext db;
        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
        public int CustomFormAction = -1;
        public int _idYCTD = 0;
        public string duoiFile = "";
        public byte[] dataFile;
        public bool isChangedFile = false;
        public dlgYeuCauTuyenDung()
        {
            InitializeComponent();
            dlgData.IdColumnName = "id";
            dlgData.CaptionColumnName = "tenDotTD";
            dlgData.FormCaption = "Thông tin yêu cầu tuyển dụng";

            AddBinddingControl();

        }
        public void setSelectedTab() {
            xtraTabKeHoachTD.SelectedTabPage = tabThongTinTD;
        }

        public void setDisplayForForm(string _isTaoVongPV = "0")
        {
            if (_isTaoVongPV == "0")
            {
                pnThongtinYCTD.Enabled = true;
                tabCacVongPV.PageVisible = false;
                tabHoiDongPV.PageVisible = false;
                dlgData.FormCaption = "Yêu cầu tuyển dụng";
            }
            else
            {
                setReadOnly(groupControlThongTinYCTD, true);
                setReadOnly(groupControlNDYC, true);
                chonPhongBan1.Enabled = false;
                //pnThongtinYCTD.Enabled = false;
                tabCacVongPV.PageVisible = true;
                btnExportWord.Visible = false;
                tabHoiDongPV.PageVisible = true;
                dlgData.FormCaption = "Thông tin yêu cầu tuyển dụng";
            }
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
                //else if (item is MemoEdit)
                //{
                //    ((MemoEdit)item).ReadOnly = isReadOnly;
                //}
                else if (item is ComboBoxEdit)
                {
                    ((ComboBoxEdit)item).ReadOnly = isReadOnly;
                }
            }
        }
        private void setEnable(Control ctr, bool isEnable)
        {
            foreach (Control item in ctr.Controls)
            {
                item.Enabled = isEnable;
                //if (item is ButtonEdit)
                //{
                //    ((ButtonEdit)item).Enabled = isEnable;
                //}
                //else if (item is TextEdit)
                //{
                //    ((TextEdit)item).Enabled = isEnable;
                //}
                //else if (item is DateEdit)
                //{
                //    ((DateEdit)item).Enabled = isEnable;
                //}
                //else if (item is LookUpEdit)
                //{
                //    ((LookUpEdit)item).Enabled = isEnable;
                //}
                //else if (item is ComboBoxEdit)
                //{
                //    ((ComboBoxEdit)item).Enabled = isEnable;
                //}
            }
        }

        private void dlgTuyenDung_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            loadPredata();

        }
        private void AddBinddingControl()
        {
            dlgData.CB.Add(new ControlBinding("soChungTu", txtSoChungTu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("idDotTD", lookupDotTuyenDung, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("PosID", lookupViTriTD, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("nguoiYeuCau", searchLookUpNguoiYC, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("lyDoTuyenDung", cmbLyDoTD, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("dinhBien", cmbDinhBien, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("mucLuongDuKienTu", txtMucLuongDuKienTu, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding("mucLuongDuKienDen", txtMucLuongDuKienDen, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding("soLuong", txtSoLuong, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("tinhTrangHonNhan", cmbTinhTrangHonNhan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("yeuCauKhac", memoYeuCaukhac, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("gioiTinh", cmbGioiTinh, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("EducationID", lookUpTDHocVan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("QualificationID", lookUpTDChuyenMon, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ngoaiNgu", checkedComboBoxNgoaiNgu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("viTinh", checkedComboBoxViTinh, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("diCongTac", cmbDiCongTac, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("lamViec", cmbCaLamViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("DistrictID", lookUpHuyen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("CityID", lookUpTinh, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding("noiDungCongViec", memoNoiDungCViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("kyNangYeuCauKhac", memoKyNangYC, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding("ngayCanNhanSu", dateNgayCanNS, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("ngayYeuCau", dateNgayYC, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("ngayGiamDocKy", dateNgayGDKy, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("ngayPhanHoiPNS", dateNgayPhanHoiNS, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("isAccept", chkIsAccept, ControlBinding_DataType.Bool));
        }
        private void loadPredata()
        {
            lookupViTriTD.Properties.DataSource = db.tblRef_EmployeeTypes;
            lookupDotTuyenDung.Properties.DataSource = db.tbDotTuyenDungs.Where(p => p.trangThaiThucHien != 2); // Lấy đợt tuyển dụng đang lên kế hoạch hoặc đang thực hiện.
            lookUpTDHocVan.Properties.DataSource = db.tblRef_Educations;
            lookUpTDChuyenMon.Properties.DataSource = db.tblRef_Qualifications;
            var a = db.tblEmployees.Select(p => new { EmployeeID = p.EmployeeID, EmployeeName = p.EmployeeName, DepName_Final = p.DepName_Final, PosName = p.PosName });
            searchLookUpNguoiYC.Properties.DataSource = a;
            repositoryItemSearchLookUpEdit1.DataSource = a;
            resItemLookupCacVongTD.DataSource = resItemLookupCacVongTD_HoiDongTD.DataSource = db.tblRef_CacVongTuyenDungs;
            checkedComboBoxViTinh.Properties.DataSource = db.tblRef_TinHocs.Select(p => p.Name);
            checkedComboBoxNgoaiNgu.Properties.DataSource = db.tblRef_Languages.Select(p => p.LangName);
            lookUpTinh.Properties.DataSource = db.tblRef_Cities.OrderBy(p => p.CityName);
            lookUpHuyen.Properties.DataSource = db.tblRef_Districts.OrderBy(p => p.DistrictName);


            //thông tin nhân viên đăng kí người phụ thuộc
            var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", 1));
            repositoryItemSearchLookUpEditMaNV.DataSource = dtnv;
        }
        protected override void FormGetData()
        {
            base.FormGetData();
            if (chonPhongBan1.SelectedValue != null)
            {
                this.MyValue["donViYeuCau"] = chonPhongBan1.SelectedValue;
            }
            this.MyValue["doTuoi"] = txtDoTuoiTu.Text.Trim() + "-" + txtDoTuoiDen.Text.Trim();
            this.MyValue["kinhNghiem"] = txtKinhNghiemTu.Text.Trim() + "-" + txtKinhNghiemDen.Text.Trim();
            this.MyValue["tenFile"] = btnFile.Text;
        }
        protected override void FormSetData()
        {
            base.FormSetData();
            #region đợt tuyển dụng này đã kết thúc
            if (this.MyValue["idDotTD"] != DBNull.Value)
            {
                var dtd = db.tbDotTuyenDungs.Where(p => p.id == int.Parse(this.MyValue["idDotTD"].ToString())).FirstOrDefault();
                if(dtd!=null && dtd.trangThaiThucHien==2)
                {
                    setEnable(groupControlThongTinYCTD, false);
                    lbXemFile.Enabled = true;
                    groupControlNDYC.Enabled = false;
                }
                else
                {
                    groupControlThongTinYCTD.Enabled = true;
                    groupControlNDYC.Enabled = true;
                }
            }
            else
            {
                groupControlThongTinYCTD.Enabled = true;
                groupControlNDYC.Enabled = true;
            }
            #endregion
            if (this.MyValue["donViYeuCau"] != DBNull.Value)
            {
                chonPhongBan1.SelectedValue = this.MyValue["donViYeuCau"].ToString();
            }
            else
                chonPhongBan1.SelectedValue = null;
            if (this.MyValue["doTuoi"] != DBNull.Value)
            {
                txtDoTuoiTu.Text = this.MyValue["doTuoi"].ToString().Split('-')[0];
                txtDoTuoiDen.Text = this.MyValue["doTuoi"].ToString().Split('-')[1];
            }
            else
            {
                txtDoTuoiTu.Text = "";
                txtDoTuoiDen.Text = "";
            }
            if (this.MyValue["kinhNghiem"] != DBNull.Value)
            {
                txtKinhNghiemTu.Text = this.MyValue["kinhNghiem"].ToString().Split('-')[0];
                txtKinhNghiemDen.Text = this.MyValue["kinhNghiem"].ToString().Split('-')[1];
            }
            else
            {
                txtKinhNghiemTu.Text = "";
                txtKinhNghiemDen.Text = "";
            }
            if (this.MyValue["duoiFile"] != DBNull.Value)
            {
                lbDuoiFile.Text = this.MyValue["duoiFile"] as string;
            }
            //if (DbHelper.DrGetBoolean(this.MyValue,"isAccept") == true)
            //{
            //    btnExportWord.Visible = true;
            //}
            //else
            //{
            //    btnExportWord.Visible = false;
            //}
            dateNgayYC.EditValue = DateTime.Now.ToString("dd/MM/yyyy");
            if (this.MyValue["tenFile"] != DBNull.Value)
            {
                btnFile.Text = this.MyValue["tenFile"] as string;
            }
            else
            {
                btnFile.Text = "";
            }

        }
        private void toolStripDeleteVongPV_Click(object sender, EventArgs e)
        {
            deleteRecord(grvVongTD);
            toolStripSaveVongPV_Click(null, null);
        }

        private void toolStripRefreshVongPV_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_idYCTD, "tblYeuCauTD_VongTuyenDung", grcVongTD);
            (grcVongTD.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void GetAllDataInTaBle_ByEmpID(int idYCTD, string TableName, GridControl grc)
        {
            grc.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM {0} WHERE idYeuCauTD = '{1}' order by idx", TableName, idYCTD));
        }
        private void toolStripSaveVongPV_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcVongTD.DataSource as DataTable), "tblYeuCauTD_VongTuyenDung");
            (grcVongTD.DataSource as DataTable).AcceptChanges();
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }
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
            }
        }
        private void xtraTabKeHoachTD_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string namePage = e.Page.Name;
            switch (namePage)
            {
                case "tabCacVongPV":
                    toolStripRefreshVongPV_Click(null, null);
                    break;
                case "tabHoiDongPV":
                    GetAllDataInTaBle_ByEmpID(_idYCTD, "tblYeuCauTD_VongTuyenDung", grcHoiDongPV_VongTD);
                    break;
                default: break;
            }
        }

        private void toolStripRefreshHoiDongPV_Click(object sender, EventArgs e)
        {
            var r = grvHoiDongPV_VongTD.GetFocusedDataRow();
            if (r != null && r["id"] != DBNull.Value)
            {
                grcHoiDongPV.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM tblYeuCauTD_VongTD_HoiDongPV WHERE idYeuCauTD_VongTD = '{0}'", r["id"]));
                (grcHoiDongPV.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
            }
            else
            {
                grcHoiDongPV.DataSource = null;
            }
        }

        private void toolStripDeleteHoiDongPV_Click(object sender, EventArgs e)
        {
            deleteRecord(grvHoiDongPV);
            toolStripSaveVongPV_Click(null, null);
        }

        private void toolStripSaveHoiDongPV_Click(object sender, EventArgs e)
        {
            Provider.UpdateData((grcHoiDongPV.DataSource as DataTable), "tblYeuCauTD_VongTD_HoiDongPV");
            (grcHoiDongPV.DataSource as DataTable).AcceptChanges();
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
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

        //private void grvHoiDongPV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    if (e.Column == grTenNV)
        //    {
        //        string empID = e.Value.ToString();
        //        var emp = db.tblEmployees.FirstOrDefault(p => p.EmployeeID == empID);
        //        DataRow r = grvHoiDongPV.GetDataRow(e.RowHandle);
        //        if (emp != null && r != null)
        //        {
        //            r["EmployeeName"] = emp.EmployeeName;
        //            r["PosName"] = emp.PosName;
        //            r["DepName_Final"] = emp.DepName_Final;
        //        }
        //    }

        //}

        private void grvVongTD_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow r = grvVongTD.GetFocusedDataRow();
            r["idYeuCauTD"] = _idYCTD;
        }

        private void grvHoiDongPV_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var r2 = grvHoiDongPV_VongTD.GetFocusedDataRow();
            if (r2 != null && r2["id"] != DBNull.Value)
            {
                DataRow r = grvHoiDongPV.GetFocusedDataRow();
                r["idYeuCauTD_VongTD"] = r2["id"];
            }
            else
            {
                GUIHelper.Notifications("Bạn chưa chọn vòng tuyển dụng để thêm hội đồng TD.", "Thêm hội đồng tuyển dụng", GUIHelper.NotifiType.error);
                grvHoiDongPV.CancelUpdateCurrentRow();
            }
        }

        private void grvHoiDongPV_VongTD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            toolStripRefreshHoiDongPV_Click(null, null);
        }

        private void grvHoiDongPV_VongTD_DataSourceChanged(object sender, EventArgs e)
        {
            grvHoiDongPV_VongTD_FocusedRowChanged(null, null);
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpTinh.EditValue == null)
            {
                lookUpHuyen.EditValue = null;
                lookUpHuyen.Properties.DataSource = null;
            }
            else
            {
                lookUpHuyen.Properties.DataSource = db.tblRef_Districts.Where(p => p.CityID == lookUpTinh.EditValue.ToString());
            }
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            var rp = new rep_phieu_YCTD();
            var a = Provider.ExecuteDataTableReader("p_export_tbYeuCauTuyenDung_byID", new System.Data.SqlClient.SqlParameter("idYCTD", _idYCTD));
            rp.DataBindings(a);
            ReportViewer rv = new ReportViewer();
            rv.ViewReport(rp);
        }

        private void grcHoiDongPV_Click(object sender, EventArgs e)
        {

        }

        private void grvHoiDongPV_VongTD_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
        }

        private void grvVongTD_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == gridColumn5)
                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void repositoryItemSearchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            this.grvHoiDongPV.SetFocusedRowCellValue(grMaNV, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeID"));
        }

        private void repositoryItemSearchLookUpEditMaNV_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            this.grvHoiDongPV.SetFocusedRowCellValue(grMaNV, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeID"));
            this.grvHoiDongPV.SetFocusedRowCellValue(grPhongBan, searchEdit.Properties.View.GetFocusedRowCellValue("DepName_Final"));
            this.grvHoiDongPV.SetFocusedRowCellValue(grViTri, searchEdit.Properties.View.GetFocusedRowCellValue("PosName"));
        }
    }
}
