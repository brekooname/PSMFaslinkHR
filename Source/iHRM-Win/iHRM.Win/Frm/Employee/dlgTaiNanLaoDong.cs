using System.Windows.Forms;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using iHRM.Core.FileDB;
using System.Reflection;


namespace iHRM.Win.Frm.Employee
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class dlgTaiNanLaoDong : dlgCustomBase
    {
        //Khởi tạo//
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        //String _FilesChoised = "";

        public int _flag = 0;

        public DataRow _CRow;

        List<MucDo> _md;

        public int _idBC = 0;

        //---//

        public dlgTaiNanLaoDong()
        {
            InitializeComponent();

            _flag = 0;
        }

        private void dlgTaiNanLaoDong_Load(object sender, EventArgs e)
        {
            TranslateForm();

            dateNgayBaoCao.DateTime = dateNgayTaiNan.DateTime = DateTime.Now.Date;

            InitLookUp();

            //InitGrd();

            if (_flag == 0) //Load Dialog thêm//
            {
                STN();

                btnSave.Visible = true;

                btnUpdate.Visible = false;

                PageEnabled(false);

                //VisibleBtn(false);
            }
            else //Load Dialog cập nhật//
            {
                btnSave.Visible = false;

                btnUpdate.Visible = true;

                InitUpdate();

                //VisibleBtn(true);
            }
        }

        #region: Hàm

        public void InitGrd()
        {
            //DataTable _table_grdFile = new DataTable();

            //DataTable _table_grdNV = new DataTable();

            //_table_grdFile.Columns.Add(new DataColumn("idBC", typeof(int)));

            //_table_grdFile.Columns.Add(new DataColumn("ghiChu", typeof(string)));

            //_table_grdFile.Columns.Add(new DataColumn("idFile", typeof(Guid)));

            //_table_grdFile.Columns.Add(new DataColumn("idFileDelete", typeof(Guid)));

            //_table_grdFile.Columns.Add(new DataColumn("dataFile", typeof(byte[])));

            //_table_grdFile.Columns.Add(new DataColumn("duoiFile", typeof(string)));

            //grdFile.DataSource = _table_grdFile;

            //grdNV.DataSource = _table_grdNV;
        }

        public void InitLookUp()
        {
            var _table_nv = _db.tblEmployees;

            lkNVBaoCao.Properties.DataSource = _table_nv;

            repNhanvien.DataSource = _table_nv;

            _md = new List<MucDo>();

            _md.Add(new MucDo { MucDoName = "1", MucDoID = "1" });

            _md.Add(new MucDo { MucDoName = "2", MucDoID = "2" });

            _md.Add(new MucDo { MucDoName = "3", MucDoID = "3" });

            _md.Add(new MucDo { MucDoName = "4", MucDoID = "4" });

            _md.Add(new MucDo { MucDoName = "5", MucDoID = "5" });

            lkMucDo.Properties.DataSource = _md;

            lkMucDo.EditValue = "1";
        }

        public void InitUpdate()
        {
            //Đổ dữ liệu vào Edit Control//

            var _soTiepNhan = DbHelper.DrGet(_CRow, "soTiepNhan") != null ? DbHelper.DrGet(_CRow, "soTiepNhan") : "";

            var _idNVBaoCao = DbHelper.DrGet(_CRow, "idNVBaoCao") != null ? DbHelper.DrGet(_CRow, "idNVBaoCao") : "";

            var _quyTrinhXayRaTaiNan = DbHelper.DrGet(_CRow, "quyTrinhXayRaTaiNan") != null ? DbHelper.DrGet(_CRow, "quyTrinhXayRaTaiNan") : "";

            var _khiNao = DbHelper.DrGet(_CRow, "khiNao") != null ? DbHelper.DrGet(_CRow, "khiNao") : "";

            var _viecGi = DbHelper.DrGet(_CRow, "viecGi") != null ? DbHelper.DrGet(_CRow, "viecGi") : "";

            var _nhuTheNao = DbHelper.DrGet(_CRow, "nhuTheNao") != null ? DbHelper.DrGet(_CRow, "nhuTheNao") : "";

            var _taiSao = DbHelper.DrGet(_CRow, "taiSao") != null ? DbHelper.DrGet(_CRow, "taiSao") : "";

            var _daLamGi = DbHelper.DrGet(_CRow, "daLamGi") != null ? DbHelper.DrGet(_CRow, "daLamGi") : "";

            var _mucDo = DbHelper.DrGet(_CRow, "mucDo") != null ? DbHelper.DrGet(_CRow, "mucDo") : "";

            var _bienPhapKhacPhuc = DbHelper.DrGet(_CRow, "bienPhapKhacPhuc") != null ? DbHelper.DrGet(_CRow, "bienPhapKhacPhuc") : "";

            var _ngayBaoCaoTaiNan = DbHelper.DrGet(_CRow, "ngayBaoCaoTaiNan") != null ? DbHelper.DrGet(_CRow, "ngayBaoCaoTaiNan") : "";

            var _diaDiem = DbHelper.DrGet(_CRow, "diaDiem") != null ? DbHelper.DrGet(_CRow, "diaDiem") : "";

            ///

            txtSoTiepNhan.Text = _soTiepNhan as String;

            lkNVBaoCao.EditValue = _idNVBaoCao;

            txtQuyTrinh.Text = _quyTrinhXayRaTaiNan as String;

            dateNgayTaiNan.DateTime = DateTime.Parse(_khiNao.ToString()).Date;

            txtViecGi.Text = _viecGi as String;

            txtNhuTheNao.Text = _nhuTheNao as String;

            txtTaiSao.Text = _taiSao as String;

            txtDaLamGi.Text = _daLamGi as String;

            lkMucDo.EditValue = _mucDo;

            txtKhacPhuc.Text = _bienPhapKhacPhuc as String;

            dateNgayBaoCao.DateTime = DateTime.Parse(_ngayBaoCaoTaiNan.ToString()).Date;

            txtDiaDiem.Text = _diaDiem as String;

            //---//
        }

        public void STN()
        {
            var _soTiepNhan = _db.tbBaoCaoTaiNanLaoDongs.OrderByDescending(x => x.soTiepNhan).FirstOrDefault();

            int _soTiepNhan_Last = 0;

            if (_soTiepNhan != null)
            {
                _soTiepNhan_Last = int.Parse(_soTiepNhan.soTiepNhan.Substring(3, 3).ToString().Trim()) + 1;
            }
            else
                _soTiepNhan_Last = _soTiepNhan_Last + 1;

            txtSoTiepNhan.Text = String.Format("HG-{1:000}/TBTN/{0:0000}", DateTime.Now.ToString("yyMM"), _soTiepNhan_Last);
        }

        private void GetAllDataInTaBle_ByID(string id, string idBC, string TableName, GridControl grd)
        {
            DataTable _index = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", TableName, idBC, id));

            grd.DataSource = _index;

            (grd.DataSource as DataTable).AcceptChanges();
        }

        public bool CheckNull(DevExpress.XtraEditors.BaseEdit _control)
        {
            if (_control.EditValue == null || String.IsNullOrEmpty(_control.ToString())) return true;

            return false;
        }

        public bool Check()
        {
            if (CheckNull(lkNVBaoCao))
            {
                GUIHelper.MessageBox("Vui lòng chọn người báo cáo!");

                return true;
            }

            if (CheckNull(lkMucDo))
            {
                GUIHelper.MessageBox("Vui lòng chọn mức độ!");

                return true;
            }

            return false;
        }

        public void VisibleBtn(bool _index)
        {
            btnSaveFile.Visible = _index;

            btnSaveNV.Visible = _index;
        }

        public void PageEnabled(bool _index)
        {
            xtraDanhSachNguoiBiTN.PageVisible = _index;

            xtraFile.PageVisible = _index;
        }

        #endregion
        
        #region: Xử lý khác

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            string namePage = e.Page.Name;

            switch(namePage)
            {
                case "xtraDanhSachNguoiBiTN": btnRefreshNV_Click(null, null); break;

                case "xtraFile": btnRefeshFile_Click(null, null); break;

                default: break;
            }
        }

        private void lkNVBaoCao_EditValueChanged(object sender, EventArgs e)
        {
            tblEmployee _emp = new tblEmployee();

            if (lkNVBaoCao.EditValue != null || lkNVBaoCao.EditValue.ToString() == "")
            {
                _emp = _db.tblEmployees.Where(x => x.EmployeeID == lkNVBaoCao.EditValue.ToString()).SingleOrDefault();
            }

            if (_emp != null)
            {
                txtChucVu.Text = _emp.PosName;
            }
        }

        #endregion

        #region: Button Click

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check()) return;

            _listActionClass.Clear();

            //Đổ dữ liệu vào//
            tbBaoCaoTaiNanLaoDong _tbTNLD = new tbBaoCaoTaiNanLaoDong();

            _tbTNLD.soTiepNhan = txtSoTiepNhan.Text as String;

            _tbTNLD.idNVBaoCao = lkNVBaoCao.EditValue as String;

            _tbTNLD.quyTrinhXayRaTaiNan = txtQuyTrinh.Text as String;

            _tbTNLD.khiNao = dateNgayTaiNan.DateTime as DateTime?;

            _tbTNLD.viecGi = txtViecGi.Text as String;

            _tbTNLD.nhuTheNao = txtNhuTheNao.Text as String;

            _tbTNLD.taiSao = txtTaiSao.Text as String;

            _tbTNLD.daLamGi = txtDaLamGi.Text as String;

            _tbTNLD.mucDo = lkMucDo.EditValue as String;

            _tbTNLD.bienPhapKhacPhuc = txtKhacPhuc.Text as String;

            _tbTNLD.ngayBaoCaoTaiNan = dateNgayBaoCao.DateTime as DateTime?;

            _tbTNLD.diaDiem = txtDiaDiem.Text as String;
            //---//

            ///
            if (DateTime.Compare(dateNgayBaoCao.DateTime.Date, dateNgayTaiNan.DateTime.Date) < 0)
            {
                GUIHelper.MessageBox("Ngày báo cáo không nhỏ hơn ngày tai nạn. Vui lòng chọn lại!");

                return;
            }

            try
            {
                var check = _db.tbBaoCaoTaiNanLaoDongs.Where(x => x.soTiepNhan == _tbTNLD.soTiepNhan.ToString()).FirstOrDefault();

                if (check != null)
                {
                    GUIHelper.MessageBox("Số tiếp nhận đã tồn tại. Không thể thêm mới!");

                    return;
                }

                _listActionClass.Add(new ActionClass("Thêm dữ liệu"
                            , _tbTNLD.soTiepNhan.ToString()
                            , ""
                            , ""
                            , "tbBaoCaoTaiNanLaoDong")); //Lưu lịch sử

                LogAction.LogAction.PushLog(_listActionClass);

                _db.tbBaoCaoTaiNanLaoDongs.InsertOnSubmit(_tbTNLD);

                _db.SubmitChanges();

                PageEnabled(true); //Cho thêm nhân viên khi tạo mới.

                var _tb = _db.tbBaoCaoTaiNanLaoDongs.OrderByDescending(x => x.id).FirstOrDefault();

                _idBC = int.Parse(_tb.id.ToString());

                btnUpdate.Visible = true;

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Check()) return;

            _listActionClass.Clear();

            //Đổ dữ liệu vào//
            tbBaoCaoTaiNanLaoDong _tbTNLD = new tbBaoCaoTaiNanLaoDong();

            _tbTNLD = _db.tbBaoCaoTaiNanLaoDongs.Where(x => x.soTiepNhan == txtSoTiepNhan.Text).FirstOrDefault();

            _tbTNLD.soTiepNhan = txtSoTiepNhan.Text as String;

            _tbTNLD.idNVBaoCao = lkNVBaoCao.EditValue as String;

            _tbTNLD.quyTrinhXayRaTaiNan = txtQuyTrinh.Text as String;

            _tbTNLD.khiNao = dateNgayTaiNan.DateTime as DateTime?;

            _tbTNLD.viecGi = txtViecGi.Text as String;

            _tbTNLD.nhuTheNao = txtNhuTheNao.Text as String;

            _tbTNLD.taiSao = txtTaiSao.Text as String;

            _tbTNLD.daLamGi = txtDaLamGi.Text as String;

            _tbTNLD.mucDo = lkMucDo.EditValue as String;

            _tbTNLD.bienPhapKhacPhuc = txtKhacPhuc.Text as String;

            _tbTNLD.ngayBaoCaoTaiNan = dateNgayBaoCao.DateTime as DateTime?;

            _tbTNLD.diaDiem = txtDiaDiem.Text as String;
            //---//

            ///
            if (DateTime.Compare(dateNgayBaoCao.DateTime.Date, dateNgayTaiNan.DateTime.Date) < 0)
            {
                GUIHelper.MessageBox("Ngày báo cáo không nhỏ hơn ngày tai nạn. Vui lòng chọn lại!");

                return;
            }

            try
            {
                _listActionClass.Add(new ActionClass("Cập nhật dữ liệu"
                            , _tbTNLD.soTiepNhan.ToString()
                            , ""
                            , ""
                            , "tbBaoCaoTaiNanLaoDong"));//Lưu lịch sử

                LogAction.LogAction.PushLog(_listActionClass);

                _db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        #endregion

        #region: GrdNV

        private void grvNV_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (_idBC != 0)
            {
                var dr = grvNV.GetDataRow(e.RowHandle);

                if (dr != null)
                {
                    dr["idBaoCaoTaiNanLD"] = _idBC;

                    dr["isAccept"] = DBNull.Value;

                    dr["userAccept"] = DBNull.Value;
                }
            }
        }

        private void repNhanvien_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;

            this.grvNV.SetFocusedRowCellValue(colEmployeeID
                                            , searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeID"));

            this.grvNV.SetFocusedRowCellValue(colEmployeeName
                                            , searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeName"));

            this.grvNV.SetFocusedRowCellValue(colDepName_Final
                                            , searchEdit.Properties.View.GetFocusedRowCellValue("DepName_Final"));

            this.grvNV.SetFocusedRowCellValue(colPosName
                                            , searchEdit.Properties.View.GetFocusedRowCellValue("PosName"));
        }

        #endregion

        #region: GrdFile

        private void grvFile_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (_idBC != 0)
            {
                var dr = grvFile.GetDataRow(e.RowHandle);

                if (dr != null)
                {
                    dr["idBC"] = _idBC;
                }
            }
        }

        private void resItemButtonFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = (grdFile.FocusedView as GridView).GetFocusedDataRow();

            //if (dr == null) return;

            if (e.Button.Index == 0)// Xem file
            {
                if (dr != null && dr["dataFile"] != DBNull.Value)
                {
                    FileStorageHelper fh = new FileStorageHelper();

                    var duoiFile = grvFile.GetFocusedRowCellValue(colDuoiFile).ToString();

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
                    grvFile.AddNewRow();

                    dr = grvFile.GetFocusedDataRow();

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

                        if (dr["idFile"] == DBNull.Value)
                        {
                            dr["idFile"] = Guid.NewGuid();
                        }

                        dr["dataFile"] = bytes;

                        dr["ghiChu"] = Path.GetFileName(od.FileNames[0]).Replace(Path.GetExtension(od.FileNames[0]), "");

                        dr["duoiFile"] = Path.GetExtension(od.FileNames[0]);
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

                    dr["ghiChu"] = DBNull.Value;

                    GUIHelper.Notifications("Đã xóa file đính kèm. Bấm lưu lại để hoàn thành.", "Xóa file đính kèm", GUIHelper.NotifiType.info);
                }
                else
                {
                    GUIHelper.Notifications("Không có dữ liệu để xóa", "Xóa file", GUIHelper.NotifiType.error);
                }
            }

            grdFile.Refresh();
        }

        #endregion

        #region: ToolStrip GrdFile

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            int[] idx = grvFile.GetSelectedRows();//GetSelectedRows tra lai index cua row dc chon

            if (idx.Length == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }

            var rows = idx.Select(i => grvFile.GetDataRow(i)); // GetDataRow tra lai dataarow cua datatable

            if (GUIHelper.ConfirmBox(string.Format("Bạn muốn xóa {0} bản ghi đã chọn?", rows.Count()), "Xác nhận lại"))
            {
                foreach (DataRow r in rows)

                    r.Delete();
            }

            grvFile.RefreshData();
        }

        private void btnRefeshFile_Click(object sender, EventArgs e)
        {
            DataTable _index = Provider.ExecuteDataTableReader("p_tbBaoCaoTaiNanLaoDong_FilesLienQuan_GetAll"
                                                    , new System.Data.SqlClient.SqlParameter("@idBC", _idBC));

            _index.Columns.Add("idFileDelete");

            grdFile.DataSource = _index;

            (grdFile.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (_idBC == 0) return;

            DataTable dt = (grdFile.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }

            FileStorageHelper fg = new FileStorageHelper();

            var count = dt.GetChanges().Rows.Count;

            try
            {
                _listActionClass.Clear();

                foreach (DataRow row in (grdFile.DataSource as DataTable).GetChanges().Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (row["idFile"] != DBNull.Value)
                        {
                            fg.InsertOrUpdateDBFiles(Guid.Parse(row["idFile"].ToString())
                                                                , row["dataFile"] as byte[]
                                                                , row["duoiFile"].ToString());

                            if (row.RowState == DataRowState.Added)
                            {
                                _listActionClass.Add(new ActionClass("Thêm dữ liệu"
                                                                    , txtSoTiepNhan.Text
                                                                    , ""
                                                                    , "Thêm dữ liệu file liên quan bảng tai nạn lao động"
                                                                    + ", ghi chú: " + (row["ghiChu"] != DBNull.Value ? row["ghiChu"].ToString() : "")
                                                                    , "tbBaoCaoTaiNanLaoDong_FilesLienQuan"));
                            }
                            else
                            {
                                _listActionClass.Add(new ActionClass("Sửa dữ liệu"
                                                                    , txtSoTiepNhan.Text
                                                                    , ""
                                                                    , "Sửa dữ liệu file liên quan bảng tai nạn lao động"
                                                                    + ", ghi chú: " + (row["ghiChu"] != DBNull.Value ? row["ghiChu"].ToString() : "")
                                                                    , "tbBaoCaoTaiNanLaoDong_FilesLienQuan"));
                            }
                        }
                        else
                        {
                            if (row["idFileDelete"] != DBNull.Value)
                            {
                                fg.DeleteFileByIDDBFiles(Guid.Parse(row["idFileDelete"].ToString()));

                                var ghiChu = row["ghiChu", DataRowVersion.Original];

                                _listActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                                    , txtSoTiepNhan.Text
                                                                    , ""
                                                                    , "Xóa dữ liệu file liên quan bảng tai nạn lao động"
                                                                    + ", ghi chú: " + ghiChu.ToString()
                                                                    , "tbBaoCaoTaiNanLaoDong_FilesLienQuan"));
                            }
                        }

                    }
                    else
                    {
                        var idFile = row["idFile", DataRowVersion.Original];

                        if (idFile != DBNull.Value)
                        {
                            fg.DeleteFileByIDDBFiles(Guid.Parse(idFile.ToString()));
                        }
                        var ghiChu = row["ghiChu", DataRowVersion.Original];

                        _listActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                            , txtSoTiepNhan.Text
                                                            , ""
                                                            , "Xóa dữ liệu file liên quan bảng tai nạn lao động"
                                                            + ", ghi chú: " + ghiChu.ToString()
                                                            , "tbBaoCaoTaiNanLaoDong_FilesLienQuan"));
                    }
                }
                Provider.UpdateData(dt, "tbBaoCaoTaiNanLaoDong_FilesLienQuan");

                LogAction.LogAction.PushLog(_listActionClass);

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        #endregion

        #region: ToolStrip GrdNV

        private void btnRefreshNV_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByID(_idBC.ToString(), "idBaoCaoTaiNanLD", "tbBaoCaoTaiNanLaoDong_DSNguoiBiTaiNan", grdNV); //load du lieu ve dt

        }

        private void btnSaveNV_Click(object sender, EventArgs e)
        {
            if (_idBC == 0) return;

            _listActionClass.Clear();

            DataTable dt = (grdNV.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grdNV.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _listActionClass.Add(new ActionClass("Thêm dữ liệu"
                                                            , txtSoTiepNhan.Text
                                                            , ""
                                                            , "Thêm dữ liệu loại nhân viên bảng tai nạn lao động ngày: "
                                                            + string.Format("{0: dd/MM/yyyy}", DateTime.Now.Date)
                                                            , "tbBaoCaoTaiNanLaoDong_DSNguoiBiTaiNan"));
                    }
                    else
                    {
                        _listActionClass.Add(new ActionClass("Sửa dữ liệu"
                                                            , txtSoTiepNhan.Text
                                                            , ""
                                                            , "Sửa dữ liệu loại nhân viên bảng tai nạn lao động ngày: "
                                                            + string.Format("{0: dd/MM/yyyy}", DateTime.Now.Date)
                                                            , "tbBaoCaoTaiNanLaoDong_DSNguoiBiTaiNan"));
                    }
                }
                else
                {
                    _listActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                        , txtSoTiepNhan.Text
                                                        , ""
                                                        , "Xóa dữ liệu loại nhân viên bảng tai nạn lao động ngày: "
                                                        + string.Format("{0: dd/MM/yyyy}", DateTime.Now.Date)
                                                        , "tbBaoCaoTaiNanLaoDong_DSNguoiBiTaiNan"));
                }
            }

            Provider.UpdateData((grdNV.DataSource as DataTable), "tbBaoCaoTaiNanLaoDong_DSNguoiBiTaiNan");

            LogAction.LogAction.PushLog(_listActionClass);

            (grdNV.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            int[] idx = grvNV.GetSelectedRows();//GetSelectedRows tra lai index cua row dc chon

            if (idx.Length == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }

            var rows = idx.Select(i => grvNV.GetDataRow(i)); // GetDataRow tra lai dataarow cua datatable

            if (GUIHelper.ConfirmBox(string.Format("Bạn muốn xóa {0} bản ghi đã chọn?", rows.Count()), "Xác nhận lại"))
            {
                foreach (DataRow r in rows)

                    r.Delete();
            }

            grvNV.RefreshData();
        }

        #endregion

        #region: Không dùng

        //private void grvNVTaiNan_InitNewRow(object sender, InitNewRowEventArgs e)
        //{
        //    var dr = grvNVTaiNan.GetDataRow(e.RowHandle);

        //    if (dr != null)
        //    {
        //        dr["id"] = Guid.NewGuid();
        //    }
        //}

        //private void grvNVTaiNan_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        //{
        //    if (e.IsGetData)
        //    {
        //        tblEmployee _emp = new tblEmployee();

        //        if (e.Column == colEmployeeName)

        //            _emp = _db.tblEmployees.Where(x => x.EmployeeID == e.Value.ToString()).SingleOrDefault();

        //        if (e.Column == colEmployeeID)

        //            e.Value = _emp.EmployeeID;

        //        if (e.Column == colDepName_Final)

        //            e.Value = _emp.DepName_Final;

        //        if (e.Column == colEmpTypeName)

        //            e.Value = _emp.EmpTypeName;

        //        if (e.Column == colSTT)

        //            e.Value = e.ListSourceRowIndex + 1;
        //    }
        //}

        #endregion

        private class MucDo
        {
            public string MucDoID { get; set; }
            public string MucDoName { get; set; }
        }

        private void dlgTaiNanLaoDong_FormClosing(object sender, FormClosingEventArgs e)
        {
            grdFile.DataSource = null;

            grdNV.DataSource = null;
        }

        private void grvNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grdNV.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void grvFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grdFile.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void dlgTaiNanLaoDong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgTaiNanLaoDong_Load(null, null);
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
        private IEnumerable<DevExpress.XtraLayout.LayoutItem> EnumerateLayoutItem()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraLayout.LayoutItem).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraLayout.LayoutItem)field.GetValue(this)
                   where component != null
                   select component;
        }

        private IEnumerable<DevExpress.XtraTab.XtraTabPage> EnumerateXtraTabPage()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraTab.XtraTabPage).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraTab.XtraTabPage)field.GetValue(this)
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
            var _LayoutItem = EnumerateLayoutItem();
            var _SimpleButton = EnumerateSimpleButton();
            var _XtraTabPage = EnumerateXtraTabPage();
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
            foreach (DevExpress.XtraLayout.LayoutItem s in _LayoutItem)
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
            foreach (DevExpress.XtraTab.XtraTabPage s in _XtraTabPage)
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
            //rdAccept.Properties.Items[0].Description = SelectTranslate("rdAcceptTatca", langTrans);
            //rdAccept.Properties.Items[1].Description = SelectTranslate("rdAcceptDaDuyet", langTrans);
            //rdAccept.Properties.Items[2].Description = SelectTranslate("rdAcceptKhongDuyet", langTrans);

            #endregion
        }

        #endregion
    }
}