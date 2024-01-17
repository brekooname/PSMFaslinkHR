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
using iHRM.Win.ExtClass;
using DevExpress.XtraEditors;
using iHRM.Core.FileDB;
using System.Data.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class dlgUngVienSoBo : dlgBase
    {
        string _empID = "";
        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
        /// 
        public int CustomFormAction = -1;
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public dlgUngVienSoBo()
        {
            InitializeComponent();
            dateEditNgayNopHS.EditValue = DateTime.Now;
            dlgData.IdColumnName = "MaUVSB";
            dlgData.CaptionColumnName = "HoVaTen";
            dlgData.FormCaption = "Thông tin ứng viên sơ bộ ";
            AddControlBinding();
            
        }

        protected override void FormGetData()
        {
            base.FormGetData();
            if(dateGio.Enabled)
            {
                this.MyValue["Gio"] = dateGio.EditValue;
            }
            if (rdKQ.SelectedIndex == 1 || rdKQ.SelectedIndex == 0)
                this.MyValue["isKQ"] = rdKQ.SelectedIndex;
            if(groupControl4.Enabled)
            {
                if(this.MyValue["isKQ"] != DBNull.Value)
                {
                    this.MyValue["ngayPhanHoi"] = DateTime.Now;
                }
            }
        }
        private void dlgEmployee_Load(object sender, EventArgs e)
        {
            LoadPreData();
            txtHovaTen.Focus();
            //chkLaUngVien.Enabled = chkThuMoi.Enabled = false;
            txtMaUVSB.Enabled = false;
        }
        public void visibleTab(bool isVisible)
        {
            //tabQuanHeGD.PageVisible = isVisible;
            //tabGiaoDucDaoTao.PageVisible = isVisible;
            //tabKyNang.PageVisible = isVisible;
            //tabKinhNghiemLamViec.PageVisible = isVisible;
        }
        private void LoadPreData()
        {
            //cboNgoaiNgu.Properties.DataSource = db.tblRef_Languages;
            repositoryItemLookUpLoaiHoSo.DataSource = db.tblRef_CurriculumVitaes;
            cboTrinhDoChuyenMon.Properties.DataSource = db.tblRef_Qualifications;
            cboTrinhDoVanHoa.Properties.DataSource = db.tblRef_Educations;
            cboViTriUngTuyen.Properties.DataSource = db.tblRef_EmployeeTypes;
            checkedComboBoxNgoaiNgu.Properties.DataSource = db.tblRef_Languages.Select(p => p.LangName);

            lookupQuocTich.Properties.DataSource = db.tblRef_Nationalities;


            

        }
        public void SetTabControl(int values)
        {
            if (values == 1)
            {
                tabFilesLienQuan.PageVisible = true;
            }
            else
            {
                tabFilesLienQuan.PageVisible = false;
            }
        }
        private class Sex
        {
            public string SexName { get; set; }
            public string SexID { get; set; }
        }
        protected override void FormSetData()
        {
            base.FormSetData();
            if (this.MyValue["isKQ"] != DBNull.Value)
            {
                rdKQ.SelectedIndex = Convert.ToInt32(this.MyValue["isKQ"].ToString());
                //groupControl1.Enabled = false;
                //groupControl4.Enabled = false;

            }
            else
            {
                rdKQ.SelectedIndex = -1;
                //groupControl1.Enabled = true;
                //groupControl4.Enabled = true;
            }
            if (this.MyValue["NgayPV"].ToString() != string.Empty)
            {
                dateGio.Enabled = true;
                dateGio.EditValue = this.MyValue["Gio"];
            }
            else
            {
                dateGio.Enabled = false;
            }
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
            dlgData.CB.Add(new ControlBinding("MaUVSB", txtMaUVSB, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("NgayNopHoSo", dateEditNgayNopHS, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("ViTriUngTuyen", cboViTriUngTuyen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("HoVaTen", txtHovaTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("KinhNghiem", txtKinhNghiem, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("TrinhDoVanHoa", cboTrinhDoVanHoa, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("NationalityID", lookupQuocTich, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("TenTruong", txtHocOTruong, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("TrinhDoChuyenMon", cboTrinhDoChuyenMon, ControlBinding_DataType.String));
            //dlgData.CB.Add(new ControlBinding("isKQ", rdKQ, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("LyDo", memoEditLyDo, ControlBinding_DataType.String));

            //Start thông tin ứng viên
            dlgData.CB.Add(new ControlBinding("NgoaiNgu", checkedComboBoxNgoaiNgu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("LuongDeXua", txtLuongDeXuat, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding("NgayPV", dateEditNgayPhongVan, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("ThuMoiPV", chkThuMoi, ControlBinding_DataType.Bool));
            //dlgData.CB.Add(new ControlBinding("LaUngVien", chkLaUngVien, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("DienThoai", txtDienThoai, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("NamSinh", dateEditNamSinh, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("Email", txtEmail, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("Nguon", txtNguonTuyendung, ControlBinding_DataType.String));
            //dlgData.CB.Add(new ControlBinding("Gio", dateGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding("GhiChu", txtGhiChu, ControlBinding_DataType.String));
           
        }
        private void xtraTabControlUngVien_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            string namePage = e.Page.Name;
            switch (namePage)
            {
                case "tabFilesLienQuan":
                    menuRefresh_Files_Click(null, null);
                    break;
                default: break;
            }
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
                //r.Table.Rows.Remove(r);
            }
        }
        private void txtTen_Leave(object sender, EventArgs e)
        {
            Regex emailRegex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            if (!emailRegex.IsMatch(txtEmail.Text))
            {
                errorProvider1.SetError(this.txtEmail, "Có lỗi");
                txtEmail.Text = string.Empty;
                txtEmail.Focus();
            }
            else
                errorProvider1.Clear();
        }

        private void menuRefresh_Files_Click(object sender, EventArgs e)
        {
            var a = Provider.ExecuteDataTable("p_tblUVSB_FilesLienQuan_GetAll", new System.Data.SqlClient.SqlParameter("idUVSB", _empID));
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
                Provider.UpdateData(dt, "tblUVSB_FilesLienQuan");
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
                dr["idUVSB"] = _empID;
            }
        }

        private void dateEditNgayPhongVan_EditValueChanged(object sender, EventArgs e)
        {
            dateGio.Enabled = true;
        }

        private void rdKQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdKQ.SelectedIndex==1)
            {
                memoEditLyDo.Enabled = true;
            }
            else
                memoEditLyDo.Enabled = false;
        }

    }
}