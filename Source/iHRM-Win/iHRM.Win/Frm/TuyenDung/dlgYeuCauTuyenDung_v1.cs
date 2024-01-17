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
using iHRM.Core.FileDB;
using System.Reflection;


namespace iHRM.Win.Frm.TuyenDung
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class dlgYeuCauTuyenDung_v1 : dlgCustomBase
    {
        //Khởi tạo//
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        public int _flag = 0;

        private List<Sex> _arrSex;

        public DataRow _CRow;

        String _FilesChoised = "";

        private String _idFile = "";

        private Binary _data;

        private String _duoiFile = "";

        private int _flagFile = 0;

        //---//

        public dlgYeuCauTuyenDung_v1()
        {
            InitializeComponent();

            _flag = 0;
        }

        public void InitLookUp()
        {
            var _table_NV = _db.tblEmployees;

            var _table_NgoaiNgu = _db.tblRef_Languages;

            var _table_TrinhDo = _db.tblRef_Educations;

            var _table_DotTD = _db.tbDotTuyenDungs;

            var _table_PosID = _db.tblRef_Positions;

            //var _table_PosID = _db.

            lkNVYeuCau.Properties.DataSource = _table_NV;

            lkDotTD.Properties.DataSource = _table_DotTD;

            lkNgoaiNgu.Properties.DataSource = _table_NgoaiNgu;

            lkNgoaiNgu.EditValue = "Tiếng Anh";

            lkTrinhDo.Properties.DataSource = _table_TrinhDo;

            lkTrinhDo.EditValue = "12/12";

            lkPosID.Properties.DataSource = _table_PosID;

            //lkPosID

            //// Giới tính
            //_arrSex = new List<Sex>();

            //_arrSex.Add(new Sex { SexName = "Nam", SexID = "Nam" });

            //_arrSex.Add(new Sex { SexName = "Nữ", SexID = "Nữ" });

            //_arrSex.Add(new Sex { SexName = "Khác", SexID = "Khác" });

            //txtGioiTinh.Properties.DataSource = _arrSex;

            //txtGioiTinh.EditValue = "Nam";
        }

        private void GetFile()
        {
            var _isFile = DbHelper.DrGet(_CRow, "idFile") != null ? DbHelper.DrGet(_CRow, "idFile") : "";

            if(!String.IsNullOrEmpty(_isFile.ToString()))
            {
                _idFile = _isFile.ToString();

                var _tbFile = _dbFiles.tbFiles.Where(i => i.id == Guid.Parse(_idFile)).SingleOrDefault();

                btnFile.Text = _tbFile.tenFile;

                _FilesChoised = _tbFile.tenFile;

                var _indexData = _tbFile.dataFile;

                _data = _indexData;

                _duoiFile = _tbFile.duoiFile;
            }

        }

        private bool Delete_File()
        {
            if (btnFile.Text == "" && _idFile != "")
            {
                var _tbFile = _dbFiles.tbFiles.Where(i => i.id == Guid.Parse(_idFile)).SingleOrDefault();

                _dbFiles.tbFiles.DeleteOnSubmit(_tbFile);

                _dbFiles.SubmitChanges();

                return true;
            }

            return false;
        }

        public void InitUpdate()
        {
            //Đổ dữ liệu vào Edit Control//

            var _idDotTD = DbHelper.DrGet(_CRow, "idDotTD") != null ? DbHelper.DrGet(_CRow, "idDotTD") : "";

            var _nguoiYeuCau = DbHelper.DrGet(_CRow, "nguoiYeuCau") != null ? DbHelper.DrGet(_CRow, "nguoiYeuCau") : "";

            var _ngayYeuCau = DbHelper.DrGet(_CRow, "ngayYeuCau") != null ? DbHelper.DrGet(_CRow, "ngayYeuCau") : "";

            var _ngayCanNhanSu = DbHelper.DrGet(_CRow, "ngayCanNhanSu") != null ? DbHelper.DrGet(_CRow, "ngayCanNhanSu") : "";

            var _soLuong = DbHelper.DrGet(_CRow, "soLuong") != null ? DbHelper.DrGet(_CRow, "soLuong") : "";

            var _gioiTinh = DbHelper.DrGet(_CRow, "gioiTinh") != null ? DbHelper.DrGet(_CRow, "gioiTinh") : "";

            var _trinhdo = DbHelper.DrGet(_CRow, "trinhdo") != null ? DbHelper.DrGet(_CRow, "trinhdo") : "";

            var _ngoaiNgu = DbHelper.DrGet(_CRow, "ngoaiNgu") != null ? DbHelper.DrGet(_CRow, "ngoaiNgu") : "";

            var _lydoTuyenDung = DbHelper.DrGet(_CRow, "lydoTuyenDung") != null ? DbHelper.DrGet(_CRow, "lydoTuyenDung") : "";

            var _noiDung = DbHelper.DrGet(_CRow, "noiDung") != null ? DbHelper.DrGet(_CRow, "noiDung") : "";

            var _yeuCauKhac = DbHelper.DrGet(_CRow, "yeuCauKhac") != null ? DbHelper.DrGet(_CRow, "yeuCauKhac") : "";

            var _SoYeuCau = DbHelper.DrGet(_CRow, "SoYeuCau") != null ? DbHelper.DrGet(_CRow, "SoYeuCau") : "";

            var _PosID = DbHelper.DrGet(_CRow, "PosID") != null ? DbHelper.DrGet(_CRow, "PosID") : "";

            lkDotTD.EditValue = _idDotTD;

            lkNVYeuCau.EditValue = _nguoiYeuCau;

            dateNgayYeuCau.DateTime = DateTime.Parse(_ngayYeuCau.ToString()).Date;

            dateNgayCanNguoi.DateTime = DateTime.Parse(_ngayCanNhanSu.ToString()).Date;

            spSoLuong.Value = int.Parse(_soLuong.ToString());

            txtGioiTinh.Text = _gioiTinh as String;

            lkTrinhDo.EditValue = _trinhdo;

            lkNgoaiNgu.EditValue = _ngoaiNgu;

            txtLyDo.Text = _lydoTuyenDung as String;

            txtNoiDung.Text = _noiDung as String;

            txtYeuCauKhac.Text = _yeuCauKhac as String;

            txtSoYeuCau.Text = _SoYeuCau as String;

            lkPosID.EditValue = _PosID;

            //---//
        }

        public void SetSYC()
        {
            var _soYeuCau = _db.tbYeuCauTuyenDung_v1s.OrderByDescending(p => p.SoYeuCau).FirstOrDefault();

            int _soYeuCau_Last = 0;

            if (_soYeuCau != null)
            {
                _soYeuCau_Last = int.Parse(_soYeuCau.SoYeuCau.Substring(3, 3).ToString().Trim()) + 1;
            }
            else
                _soYeuCau_Last = _soYeuCau_Last + 1;

            txtSoYeuCau.Text = String.Format("HG-{1:000}/YCTD/{0:0000}", DateTime.Now.ToString("yyMM"), _soYeuCau_Last);
        }

        public bool CheckNull(DevExpress.XtraEditors.BaseEdit _control)
        {
            if (_control.EditValue == null || String.IsNullOrEmpty(_control.ToString())) return true;

            return false;
        }

        public bool Check()
        {
            if (CheckNull(lkNVYeuCau))
            {
                GUIHelper.MessageBox("Vui lòng chọn người yêu cầu!");

                return true;
            }

            if (CheckNull(lkDotTD))
            {
                GUIHelper.MessageBox("Vui lòng chọn đợt tuyển dụng!");

                return true;
            }

            //if (CheckNull(txtGioiTinh))
            //{
            //    GUIHelper.MessageBox("Vui lòng chọn giới tính!");

            //    return true;
            //}

            if (CheckNull(lkPosID))
            {
                GUIHelper.MessageBox("Vui lòng chọn vị trí cần tuyển!");

                return true;
            }

            if (CheckNull(dateNgayYeuCau) || CheckNull(dateNgayCanNguoi))
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày!");

                return true;
            }

            if (CheckNull(spSoLuong))
            {
                return true;
            }

            if (int.Parse(spSoLuong.Value.ToString()) < 1)
            {
                GUIHelper.MessageBox("Số lượng không nhỏ hơn 1. Vui lòng chọn lại!");

                return true;
            }

            return false;
        }

        private void dlgYeuCauTuyenDung_v1_Load(object sender, EventArgs e)
        {
            TranslateForm();

            dateNgayYeuCau.DateTime = dateNgayCanNguoi.DateTime = DateTime.Now.Date;

            InitLookUp();

            if (_flag == 0) //Load Dialog thêm//
            {
                SetSYC();

                btnSave.Visible = true;

                btnUpdate.Visible = false;
            }
            else //Load Dialog cập nhật//
            {
                btnSave.Visible = false;

                btnUpdate.Visible = true;

                InitUpdate();

                GetFile();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check()) return;

            _listActionClass.Clear();

            //Xử lý file//
            if (btnFile.Text == null || String.IsNullOrWhiteSpace(btnFile.Text))
            {
                _FilesChoised = "";
            }
            else
            {
                _FilesChoised = btnFile.Text as String;
            }

            bool _isChoiseFile = _FilesChoised == "" ? false : true;

            byte[] _bytes = null;

            Binary _datafileChoised = null;

            String _duoiFile = "";

            try
            {
                if (_isChoiseFile)
                {
                    _bytes = System.IO.File.ReadAllBytes(_FilesChoised);

                    _datafileChoised = new Binary(_bytes);

                    _duoiFile = Path.GetExtension(_FilesChoised);
                }
            }
            catch (Exception)
            {
                GUIHelper.MessageError("File đính kèm không hợp lệ.");

                return;
            }

            //---//

            ///
            if (DateTime.Compare(dateNgayCanNguoi.DateTime.Date, dateNgayYeuCau.DateTime.Date) < 0)
            {
                GUIHelper.MessageBox("Ngày cần người không nhỏ hơn ngày yêu cầu. Vui lòng chọn lại!");

                return;
            }

            //Đổ dữ liệu vào//
            tbYeuCauTuyenDung_v1 _tbYCTD = new tbYeuCauTuyenDung_v1();

            _tbYCTD.idDotTD = int.Parse(lkDotTD.EditValue.ToString());

            _tbYCTD.nguoiYeuCau = lkNVYeuCau.EditValue as String;

            _tbYCTD.ngayYeuCau = dateNgayYeuCau.DateTime.Date as DateTime?;

            _tbYCTD.ngayCanNhanSu = dateNgayCanNguoi.DateTime.Date as DateTime?;

            _tbYCTD.soLuong = int.Parse(spSoLuong.Text);

            _tbYCTD.gioiTinh = txtGioiTinh.Text as String;

            _tbYCTD.trinhdo = lkTrinhDo.EditValue as String;

            _tbYCTD.ngoaiNgu = lkNgoaiNgu.EditValue as String;

            _tbYCTD.lydoTuyenDung = txtLyDo.Text;

            _tbYCTD.noiDung = txtNoiDung.Text;

            _tbYCTD.yeuCauKhac = txtYeuCauKhac.Text;

            _tbYCTD.SoYeuCau = txtSoYeuCau.Text;

            _tbYCTD.PosID = lkPosID.EditValue.ToString();

            _tbYCTD.chucvuYeuCau = lkPosID.Properties.GetDisplayText(lkPosID.EditValue);

            var _index = _db.tblEmployees.Where(i => i.EmployeeID == lkNVYeuCau.EditValue).SingleOrDefault();

            if (_index != null)
            {
                if (_index.DepID_Final == null)
                {
                    GUIHelper.MessageBox("Nhân viên yêu cầu tuyển dụng chưa có thông tin phòng ban. Không thể thêm mới!");

                    return;
                }
                else

                    _tbYCTD.donViYeuCau = _index.DepID_Final != null ? _index.DepID_Final.ToString() : _index.DepID.ToString();
            }
            else
            {
                _tbYCTD.donViYeuCau = "1";
            }
            //---//

            try
            {
                var check = _db.tbYeuCauTuyenDung_v1s.Where(x => x.SoYeuCau == txtSoYeuCau.Text.ToString()).SingleOrDefault();

                if (check != null)
                {
                    GUIHelper.MessageBox("Số yêu cầu đã tồn tại. Không thể thêm mới!");

                    return;
                }

                //Thêm File//

                Guid _idFile = _tbYCTD.idFile != null ? Guid.Parse(_tbYCTD.idFile.ToString()) : Guid.NewGuid();

                if (_isChoiseFile)
                {
                    _tbYCTD.idFile = _idFile.ToString();
                }

                if (_isChoiseFile) // Nếu chọn file đính kèm
                {
                    tbFile _newFile = new tbFile();

                    _newFile.id = _idFile;

                    _newFile.dataFile = _datafileChoised;

                    _newFile.duoiFile = _duoiFile;

                    _newFile.tenFile = _FilesChoised;

                    _dbFiles.tbFiles.InsertOnSubmit(_newFile);

                    _dbFiles.SubmitChanges();
                }

                //---//

                _listActionClass.Add(new ActionClass("Thêm dữ liệu " + _tbYCTD.SoYeuCau.ToString()
                            , _tbYCTD.nguoiYeuCau
                            , ""
                            , "Thêm yêu cầu tuyển dụng SYC: " + _tbYCTD.SoYeuCau.ToString() + " ngày: " + _tbYCTD.ngayYeuCau
                            , "tbYeuCauTuyenDung_v1"));//Lưu lịch sử

                LogAction.LogAction.PushLog(_listActionClass);

                _db.tbYeuCauTuyenDung_v1s.InsertOnSubmit(_tbYCTD);

                _db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                this.Close();
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

            //Xử lý file//

            if ((btnFile.Text == "" || String.IsNullOrWhiteSpace(btnFile.Text)) && _flagFile == 1)
            {
                _FilesChoised = "";
            }
            else
            {
                _FilesChoised = btnFile.Text as String;
            }

            bool _isChoiseFile = _FilesChoised == "" ? false : true;

            byte[] _bytes = null;

            Binary _datafileChoised = null;

            String _duoiFile = "";

            try
            {
                if (_isChoiseFile)
                {
                    _bytes = System.IO.File.ReadAllBytes(_FilesChoised);

                    _datafileChoised = new Binary(_bytes);

                    _duoiFile = Path.GetExtension(_FilesChoised);
                }
            }
            catch (Exception)
            {
                GUIHelper.MessageError("File đính kèm không hợp lệ.");

                return;
            }

            //---//

            ///
            if (DateTime.Compare(dateNgayCanNguoi.DateTime.Date, dateNgayYeuCau.DateTime.Date) < 0)
            {
                GUIHelper.MessageBox("Ngày cần người không nhỏ hơn ngày yêu cầu. Vui lòng chọn lại!");

                return;
            }

            //Đổ dữ liệu vào//
            tbYeuCauTuyenDung_v1 _tbYCTD = new tbYeuCauTuyenDung_v1();

            _tbYCTD = _db.tbYeuCauTuyenDung_v1s.Where(x => x.SoYeuCau == txtSoYeuCau.Text).SingleOrDefault();

            _tbYCTD.idDotTD = int.Parse(lkDotTD.EditValue.ToString());

            _tbYCTD.nguoiYeuCau = lkNVYeuCau.EditValue as String;

            _tbYCTD.ngayYeuCau = dateNgayYeuCau.DateTime.Date as DateTime?;

            _tbYCTD.ngayCanNhanSu = dateNgayCanNguoi.DateTime.Date as DateTime?;

            _tbYCTD.soLuong = int.Parse(spSoLuong.Text);

            _tbYCTD.gioiTinh = txtGioiTinh.Text as String;

            _tbYCTD.trinhdo = lkTrinhDo.EditValue as String;

            _tbYCTD.ngoaiNgu = lkNgoaiNgu.EditValue as String;

            _tbYCTD.lydoTuyenDung = txtLyDo.Text;

            _tbYCTD.noiDung = txtNoiDung.Text;

            _tbYCTD.yeuCauKhac = txtYeuCauKhac.Text;

            _tbYCTD.SoYeuCau = txtSoYeuCau.Text;

            _tbYCTD.PosID = lkPosID.EditValue.ToString();

            _tbYCTD.chucvuYeuCau = lkPosID.Properties.GetDisplayText(lkPosID.EditValue);

            var _index = _db.tblEmployees.Where(i => i.EmployeeID == lkNVYeuCau.EditValue).SingleOrDefault();

            if(_index != null)
            {
                _tbYCTD.donViYeuCau = _index.DepID_Final != null ? _index.DepID_Final.ToString() : _index.DepID.ToString();
            }
            else
            {
                _tbYCTD.donViYeuCau = "1";
            }
            //---//

            try
            {
                //Cập nhật file//

                Guid _idFile = _tbYCTD.idFile != null ? Guid.Parse(_tbYCTD.idFile.ToString()) : Guid.NewGuid();

                if (_isChoiseFile)
                {
                    _tbYCTD.idFile = _idFile.ToString();
                }

                #region Add file to other database
                if (_isChoiseFile) // Nếu chọn file đính kèm
                {

                    if (_tbYCTD.idFile != null)
                    {
                        var _f1 = _dbFiles.tbFiles.Where(p => p.id == Guid.Parse(_tbYCTD.idFile.ToString())).FirstOrDefault();

                        if (_f1 != null)
                        {
                            _f1.dataFile = _datafileChoised;

                            _f1.duoiFile = _duoiFile;
                        }
                        else
                        {
                            tbFile _newFile = new tbFile();

                            _newFile.id = _idFile;

                            _newFile.dataFile = _datafileChoised;

                            _newFile.duoiFile = _duoiFile;

                            _dbFiles.tbFiles.InsertOnSubmit(_newFile);
                        }
                    }
                    else
                    {
                        tbFile _newFile = new tbFile();

                        _newFile.id = _idFile;

                        _newFile.dataFile = _datafileChoised;

                        _newFile.duoiFile = _duoiFile;

                        _newFile.tenFile = _FilesChoised;

                        _dbFiles.tbFiles.InsertOnSubmit(_newFile);
                    }

                    _dbFiles.SubmitChanges();
                }
                #endregion

                if (Delete_File() == true)
                {
                    _tbYCTD.idFile = null;
                }
                //---//

                _listActionClass.Add(new ActionClass("Cập nhật dữ liệu " + _tbYCTD.SoYeuCau.ToString()
                            , _tbYCTD.nguoiYeuCau
                            , ""
                            , "Cập nhật yêu cầu tuyển dụng SYC: " + _tbYCTD.SoYeuCau.ToString() +" ngày: "+_tbYCTD.ngayYeuCau
                            , "tbYeuCauTuyenDung_v1"));//Lưu lịch sử

                LogAction.LogAction.PushLog(_listActionClass);

                _db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);

                this.Close();
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private class Sex
        {
            public string SexName { get; set; }
            public string SexID { get; set; }
        }

        private void btnFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) //Chọn file
            {
                OpenFileDialog _od = new OpenFileDialog();

                String _filterFile = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                _filterFile += "|Word files (*.doc, *.docx)|*.doc; *.docx; ";

                _filterFile += "|Pdf files (*.pdf)|*.pdf; ";

                _filterFile += "|All files (*.*)|*.*;";

                _od.Filter = _filterFile;

                _od.Multiselect = false;

                if (_od.ShowDialog() == DialogResult.OK)
                {
                    _FilesChoised = _od.FileNames[0];

                    btnFile.Text = string.Format(_FilesChoised);

                    byte[] _bytes = System.IO.File.ReadAllBytes(_FilesChoised);

                    _data = _bytes;

                    _duoiFile = Path.GetExtension(_FilesChoised);

                    _flagFile = 1;
                }
            }
            else //Hủy file
            {
                btnFile.Text = "";

                _FilesChoised = "";

                _data = null;

                _duoiFile = "";
            }
        }

        private void lkNVYeuCau_EditValueChanged(object sender, EventArgs e)
        {
            tblEmployee _emp = new tblEmployee();

            if (lkNVYeuCau.EditValue != null || lkNVYeuCau.EditValue.ToString() == "")
            {
                _emp = _db.tblEmployees.Where(x => x.EmployeeID == lkNVYeuCau.EditValue.ToString()).SingleOrDefault();
            }

            if (_emp != null)
            {
                txtBoPhan.Text = _emp.DepName_Final;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FileStorageHelper _fh = new FileStorageHelper();

            if (_data != null && _data.ToString() != "")
            {
                _fh.DownLoadAndShowFILE(_data, _duoiFile);
            }
            else
            {
                GUIHelper.Notifications("Không tìm thấy file.", "Xem file", GUIHelper.NotifiType.error);
            }
        }

        private void dlgYeuCauTuyenDung_v1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgYeuCauTuyenDung_v1_Load(null, null);
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

        private IEnumerable<DevExpress.XtraLayout.LayoutItem> EnumerateLayoutControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraLayout.LayoutItem).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraLayout.LayoutItem)field.GetValue(this)
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
            var _LayoutControl = EnumerateLayoutControl();
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
            foreach (DevExpress.XtraLayout.LayoutItem s in _LayoutControl)
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