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
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using iHRM.Common.Code;
using System.Reflection;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class dlgDanhGiaNhanSu_v2 : dlgCustomBase
    {
        //Khởi tạo//
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        public String _idNV = "";

        public int _flag = 0;

        public String _user = "";

        public DataRow _CRow;

        public int _thuViec = 0;

        public bool iRule = false;

        private String _sdg = "";

        String _FilesChoised = "";

        private String _idFiles = "";

        private Binary _data;

        private String _duoiFile = "";

        private int _flagFile = 0;
        //---//

        public dlgDanhGiaNhanSu_v2()
        {
            InitializeComponent();
        }

        private void SetDGNS()
        {
            var _soDanhGia = _db.tbDanhGiaNhanSus.OrderByDescending(p => p.soDanhGia).FirstOrDefault();

            int _soDanhGia_Last = 0;

            if (_soDanhGia != null)
            {
                _soDanhGia_Last = int.Parse(_soDanhGia.soDanhGia.Substring(6, 4).ToString().Trim()) + 1;
            }
            else
                _soDanhGia_Last = _soDanhGia_Last + 1;

            txtSoDanhGia.Text = String.Format("DGNV{1:00}{0:0000}", _soDanhGia_Last, DateTime.Now.ToString("yy"));
        }

        private void GetFile()
        {
            var _isFile = DbHelper.DrGet(_CRow, "idFile") != null ? DbHelper.DrGet(_CRow, "idFile") : "";

            if (!String.IsNullOrEmpty(_isFile.ToString()))
            {
                _idFiles = _isFile.ToString();

                var _tbFile = _dbFiles.tbFiles.Where(i => i.id == Guid.Parse(_idFiles)).SingleOrDefault();

                btnChonFile.Text = _tbFile.tenFile;

                _FilesChoised = _tbFile.tenFile;

                var _indexData = _tbFile.dataFile;

                _data = _indexData;

                _duoiFile = _tbFile.duoiFile;
            }

        }

        private bool Delete_File()
        {
            if (btnChonFile.Text == "" && _idFiles != "")
            {
                var _tbFile = _dbFiles.tbFiles.Where(i => i.id == Guid.Parse(_idFiles)).SingleOrDefault();

                if (_tbFile != null)
                {
                    _dbFiles.tbFiles.DeleteOnSubmit(_tbFile);

                    _dbFiles.SubmitChanges();
                }

                return true;
            }

            return false;
        }


        private void InitGrd()
        {
            lkToTruong.Properties.DataSource = _db.tblEmployees;

            lkQuanLy.Properties.DataSource = _db.tblEmployees;

            lkXuongTruong.Properties.DataSource = _db.tblEmployees;

            lkKhac.Properties.DataSource = _db.tblEmployees;
        }


        private void Load_Data(int flag)
        {
            try
            {
                if (flag != 0)
                {
                    var _soDanhGia = DbHelper.DrGet(_CRow, "soDanhGia") != null ? DbHelper.DrGet(_CRow, "soDanhGia") : "";

                    txtSoDanhGia.Text = _soDanhGia as String;

                    _sdg = _soDanhGia as String;
                }

                var _EmployeeID = DbHelper.DrGet(_CRow, "EmployeeID") != null ? DbHelper.DrGet(_CRow, "EmployeeID") : "";

                var _EmployeeName = DbHelper.DrGet(_CRow, "EmployeeName") != null ? DbHelper.DrGet(_CRow, "EmployeeName") : "";

                var _PosName = DbHelper.DrGet(_CRow, "PosName") != null ? DbHelper.DrGet(_CRow, "PosName") : "";

                var _DepName = DbHelper.DrGet(_CRow, "DepName") != null ? DbHelper.DrGet(_CRow, "DepName") : "";

                var _AppliedDate = DbHelper.DrGet(_CRow, "AppliedDate") != null ? DbHelper.DrGet(_CRow, "AppliedDate") : "";

                var _BasicSalary = DbHelper.DrGet(_CRow, "BasicSalary") != null ? DbHelper.DrGet(_CRow, "BasicSalary") : "";

                var _isKyHopDong = DbHelper.DrGet(_CRow, "isKyHopDong") != null ? DbHelper.DrGet(_CRow, "isKyHopDong") : "";

                var _ngayDanhGia = DbHelper.DrGet(_CRow, "ngayDanhGia") != null ? DbHelper.DrGet(_CRow, "ngayDanhGia") : "";

                var _ngayKyHD = DbHelper.DrGet(_CRow, "ngayKyHD") != null ? DbHelper.DrGet(_CRow, "ngayKyHD") : "";

                var _diemToTruong = DbHelper.DrGet(_CRow, "diemToTruong") != null ? DbHelper.DrGet(_CRow, "diemToTruong") : "";

                var _diemQuanLy = DbHelper.DrGet(_CRow, "diemQuanLy") != null ? DbHelper.DrGet(_CRow, "diemQuanLy") : "";

                var _diemXuongTruong = DbHelper.DrGet(_CRow, "diemXuongTruong") != null ? DbHelper.DrGet(_CRow, "diemXuongTruong") : "";

                var _diemKhac = DbHelper.DrGet(_CRow, "diemKhac") != null ? DbHelper.DrGet(_CRow, "diemKhac") : "";

                var _ghiChuToTruong = DbHelper.DrGet(_CRow, "ghiChuToTruong") != null ? DbHelper.DrGet(_CRow, "ghiChuToTruong") : "";

                var _ghiChuQuanLy = DbHelper.DrGet(_CRow, "ghiChuQuanLy") != null ? DbHelper.DrGet(_CRow, "ghiChuQuanLy") : "";

                var _ghiChuXuongTruong = DbHelper.DrGet(_CRow, "ghiChuXuongTruong") != null ? DbHelper.DrGet(_CRow, "ghiChuXuongTruong") : "";

                var _ghiChuKhac = DbHelper.DrGet(_CRow, "ghiChuKhac") != null ? DbHelper.DrGet(_CRow, "ghiChuKhac") : "";

                txtMaNV.Text = _EmployeeID as String;

                txtHoTen.Text = _EmployeeName as String;

                txtChucVu.Text = _PosName as String;

                txtBoPhan.Text = _DepName as String;

                txtYKienTT.Text = _ghiChuToTruong as String;

                txtYKienQL.Text = _ghiChuQuanLy as String;

                txtYKienXT.Text = _ghiChuXuongTruong as String;

                txtYKienKhac.Text = _ghiChuKhac as String;

                if (_AppliedDate != "")

                    dateNgayVaoLam.DateTime = DateTime.Parse(_AppliedDate.ToString()).Date;

                if (_ngayDanhGia != "")

                    dateNgayDanhGia.DateTime = DateTime.Parse(_ngayDanhGia.ToString()).Date;

                else

                    dateNgayDanhGia.DateTime = DateTime.Now.Date;

                if (_ngayKyHD != "")

                    dateNgayKyHD.DateTime = DateTime.Parse(_ngayDanhGia.ToString()).Date;

                else

                    dateNgayKyHD.EditValue = "";

                txtMucLuong.Text = _BasicSalary == "" ? "0" : Convert.ToDecimal(_BasicSalary).ToString("#,#");

                if (_diemToTruong != "")

                    txtDiemTT.Text = Convert.ToDecimal(_diemToTruong).ToString();

                if (_diemQuanLy != "")

                    txtDiemQL.Text = Convert.ToDecimal(_diemQuanLy).ToString();;

                if (_diemXuongTruong != "")

                    txtDiemXT.Text = Convert.ToDecimal(_diemXuongTruong).ToString();;

                if (_diemKhac != "")

                    txtDiemKhac.Text = Convert.ToDecimal(_diemKhac).ToString();;

                if (_isKyHopDong != "")
                {
                    int _check = int.Parse(_isKyHopDong.ToString());

                    switch(_check)
                    {
                        case 0: rdKyHD.SelectedIndex = 0;
                            break;

                        case 1: rdKyHD.SelectedIndex = 1;
                            break;

                        case 2: rdKyHD.SelectedIndex = 2;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private bool CheckNull(DevExpress.XtraEditors.BaseEdit _control)
        {
            if (_control.EditValue == null || String.IsNullOrEmpty(_control.ToString())) return true;

            return false;
        }

        private bool Check()
        {
            if (CheckNull(dateNgayDanhGia))
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày đánh giá!");

                return true;
            }

            if (CheckNull(lkKhac) && CheckNull(lkQuanLy) && CheckNull(lkToTruong) && CheckNull(lkXuongTruong))
            {
                GUIHelper.MessageBox("Vui lòng chọn người đánh giá!");

                return true;
            }

            return false;
        }

        private void dlgDanhGiaNhanSu_v2_Load(object sender, EventArgs e)
        {
            TranslateForm();

            dateNgayDanhGia.DateTime = DateTime.Now.Date;

            rdKyHD.Properties.Items[2].Enabled = iRule;

            InitGrd();

            Load_Data(_flag);

            if(_thuViec == 0)
            {
                rdKyHD.Properties.Items[2].Enabled = false; //Load radiogroup đánh giá nhân viên chính thức
            }
            else
            {
                rdKyHD.Properties.Items[2].Enabled = true; //Load radiogroup đánh giá nhân viên thử việc
            }

            if (_flag == 0)
            {
                SetDGNS();
            }
            else
            {
                tbDanhGiaNhanSu _tbdgns = new tbDanhGiaNhanSu();

                _tbdgns = _db.tbDanhGiaNhanSus.Where(i => i.soDanhGia == _sdg && i.idNV == _idNV).SingleOrDefault();

                lkToTruong.EditValue = _tbdgns.idToTruong;

                lkQuanLy.EditValue = _tbdgns.idQuanLy;

                lkXuongTruong.EditValue = _tbdgns.idXuongTruong;

                lkKhac.EditValue = _tbdgns.idKhac;

                GetFile();
            }
        }

        private void btnChonFile_ButtonClick(object sender, ButtonPressedEventArgs e)
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

                    btnChonFile.Text = string.Format(_FilesChoised);

                    byte[] _bytes = System.IO.File.ReadAllBytes(_FilesChoised);

                    _data = _bytes;

                    _duoiFile = Path.GetExtension(_FilesChoised);

                    _flagFile = 1;
                }
            }
            else //Hủy file
            {
                btnChonFile.Text = "";

                _FilesChoised = "";

                _data = null;

                _duoiFile = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _listActionClass.Clear();

            if (Check()) return;

            if (_flag == 0)//Tạo mới đánh giá
            {
                if ((btnChonFile.Text == "" || String.IsNullOrWhiteSpace(btnChonFile.Text)) && _flagFile == 1)
                {
                    _FilesChoised = "";
                }
                else
                {
                    _FilesChoised = btnChonFile.Text as String;
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

                tbDanhGiaNhanSu _tbDGNS = new tbDanhGiaNhanSu();

                _tbDGNS.idNV = txtMaNV.Text;

                _tbDGNS.ngayDanhGia = dateNgayDanhGia.DateTime;

                _tbDGNS.soDanhGia = txtSoDanhGia.Text;

                _tbDGNS.soHD = DbHelper.DrGet(_CRow, "ContractID") != null ? DbHelper.DrGet(_CRow, "ContractID").ToString() : "";

                _tbDGNS.idToTruong = lkToTruong.EditValue as String;

                _tbDGNS.idQuanLy = lkQuanLy.EditValue as String;

                _tbDGNS.idXuongTruong = lkXuongTruong.EditValue as String;

                _tbDGNS.idKhac = lkKhac.EditValue as String;

                if (txtDiemTT.Text != "")
                {
                    _tbDGNS.diemToTruong = Double.Parse(txtDiemTT.Text.ToString());
                }

                if (txtDiemQL.Text != "")
                {
                    _tbDGNS.diemQuanLy = Double.Parse(txtDiemQL.Text.ToString());
                }

                if (txtDiemXT.Text != "")
                {
                    _tbDGNS.diemXuongTruong = Double.Parse(txtDiemXT.Text.ToString());
                }

                if (txtDiemKhac.Text != "")
                {
                    _tbDGNS.diemKhac = Double.Parse(txtDiemKhac.Text.ToString());
                }

                _tbDGNS.ghiChuToTruong = txtYKienTT.Text as String;

                _tbDGNS.ghiChuQuanLy = txtYKienQL.Text as String;

                _tbDGNS.ghiChuXuongTruong = txtYKienXT.Text as String;

                _tbDGNS.ghiChuKhac = txtYKienKhac.Text as String;

                try
                {
                    var _check = _db.tbDanhGiaNhanSus.Where(x => x.soDanhGia == txtSoDanhGia.Text && x.ngayDanhGia == dateNgayDanhGia.DateTime).SingleOrDefault();

                    if (_check != null)
                    {
                        GUIHelper.MessageBox("Nhân viên đã được đánh giá. Không thể đánh giá!");

                        return;
                    }

                    if(rdKyHD.SelectedIndex == 1)
                    {
                        if (dateNgayKyHD.EditValue == "")
                        {
                            GUIHelper.MessageBox("Vui lòng chọn ngày ký HĐ!");

                            return;
                        }
                        else
                        {
                            _tbDGNS.ngayKyHD = dateNgayKyHD.DateTime.Date;
                        }
                    }
                    else
                    {
                        _tbDGNS.ngayKyHD = null;
                    }

                    if (rdKyHD.SelectedIndex >= 0)
                    {
                        _tbDGNS.isKyHopDong = int.Parse(rdKyHD.EditValue.ToString());
                    }

                    //Thêm File//

                    String _idFile = _tbDGNS.idFile != null ? _tbDGNS.idFile : Guid.NewGuid().ToString();

                    if (_isChoiseFile)
                    {
                        _tbDGNS.idFile = _idFile;
                    }

                    if (_isChoiseFile) // Nếu chọn file đính kèm
                    {
                        tbFile _newFile = new tbFile();

                        _newFile.id = Guid.Parse(_idFile);

                        _newFile.dataFile = _datafileChoised;

                        _newFile.duoiFile = _duoiFile;

                        _newFile.tenFile = _FilesChoised;

                        _dbFiles.tbFiles.InsertOnSubmit(_newFile);

                        _dbFiles.SubmitChanges();
                    }

                    //---//

                    _listActionClass.Add(new ActionClass("Thêm đánh giá " + _tbDGNS.soDanhGia.ToString()
                                , _tbDGNS.idNV.ToString()
                                , ""
                                , "Thêm đánh giá nhân viên - Ngày: " + DateTime.Now.Date + " - "
                                    + _tbDGNS.idNV.ToString() + " tình trang HĐ "
                                    + (_tbDGNS.isKyHopDong == null ? "Trống" : 
                                            (_tbDGNS.isKyHopDong == 1 ? "Ký HĐ" : (_tbDGNS.isKyHopDong == 0 ? "Không Ký HĐ" : "Gia hạn thử việc")))
                                , "tbDanhGiaNhanSu")); //Lưu lịch sử

                    LogAction.LogAction.PushLog(_listActionClass);

                    _db.tbDanhGiaNhanSus.InsertOnSubmit(_tbDGNS);

                    _db.SubmitChanges();

                    var _table_DG = _db.tbDanhGiaNhanSus.OrderByDescending(p => p.id).FirstOrDefault();

                    int _i = 1;
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                    _flag = 1;

                    this.Close();
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
            else //Thay đổi đánh giá
            {
                tbDanhGiaNhanSu _tbDGNS = new tbDanhGiaNhanSu();

                _tbDGNS = _db.tbDanhGiaNhanSus.Where(x => x.soDanhGia == txtSoDanhGia.Text.ToString()).SingleOrDefault();

                _tbDGNS.idNV = txtMaNV.Text;

                _tbDGNS.ngayDanhGia = dateNgayDanhGia.DateTime;

                _tbDGNS.soDanhGia = txtSoDanhGia.Text;

                _tbDGNS.soHD = DbHelper.DrGet(_CRow, "ContractID") != null ? DbHelper.DrGet(_CRow, "ContractID").ToString() : "";

                _tbDGNS.idToTruong = lkToTruong.EditValue as String;

                _tbDGNS.idQuanLy = lkQuanLy.EditValue as String;

                _tbDGNS.idXuongTruong = lkXuongTruong.EditValue as String;

                _tbDGNS.idKhac = lkKhac.EditValue as String;

                if (txtDiemTT.Text != "")
                {
                    _tbDGNS.diemToTruong = Double.Parse(txtDiemTT.Text.ToString());
                }

                if (txtDiemQL.Text != "")
                {
                    _tbDGNS.diemQuanLy = Double.Parse(txtDiemQL.Text.ToString());
                }

                if (txtDiemXT.Text != "")
                {
                    _tbDGNS.diemXuongTruong = Double.Parse(txtDiemXT.Text.ToString());
                }

                if (txtDiemKhac.Text != "")
                {
                    _tbDGNS.diemKhac = Double.Parse(txtDiemKhac.Text.ToString());
                }

                _tbDGNS.ghiChuToTruong = txtYKienTT.Text as String;

                _tbDGNS.ghiChuQuanLy = txtYKienQL.Text as String;

                _tbDGNS.ghiChuXuongTruong = txtYKienXT.Text as String;

                _tbDGNS.ghiChuKhac = txtYKienKhac.Text as String;

                //Xử lý file//

                if ((btnChonFile.Text == "" || String.IsNullOrWhiteSpace(btnChonFile.Text)) && _flagFile == 1)
                {
                    _FilesChoised = "";
                }
                else
                {
                    _FilesChoised = btnChonFile.Text as String;
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

                if (Delete_File() == true)
                {
                    _tbDGNS.idFile = null;
                }

                try
                {
                    _listActionClass.Add(new ActionClass("Cập nhật đánh giá " + _tbDGNS.soDanhGia.ToString()
                                , _tbDGNS.idNV.ToString()
                                , ""
                                , "Cập nhật đánh giá nhân viên - Ngày: " + DateTime.Now.Date + " - "
                                    + _tbDGNS.idNV.ToString() + " tình trang HĐ "
                                    + (_tbDGNS.isKyHopDong == null ? "Trống" :
                                            (_tbDGNS.isKyHopDong == 1 ? "Ký HĐ" : (_tbDGNS.isKyHopDong == 0 ? "Không Ký HĐ" : "Gia hạn thử việc")))
                                , "tbDanhGiaNhanSu")); //Lưu lịch sử

                    LogAction.LogAction.PushLog(_listActionClass);

                    //Cập nhật file//
                    String _idFile = _tbDGNS.idFile != null ? _tbDGNS.idFile : Guid.NewGuid().ToString();

                    if (_isChoiseFile)
                    {
                        _tbDGNS.idFile = _idFile;
                    }

                    #region Add file to other database
                    if (_isChoiseFile) // Nếu chọn file đính kèm
                    {

                        if (_tbDGNS.idFile != null)
                        {
                            var _f1 = _dbFiles.tbFiles.Where(p => p.id == Guid.Parse(_tbDGNS.idFile)).FirstOrDefault();

                            if (_f1 != null)
                            {
                                _f1.dataFile = _datafileChoised;

                                _f1.duoiFile = _duoiFile;
                            }
                            else
                            {
                                tbFile _newFile = new tbFile();

                                _newFile.id = Guid.Parse(_idFile);

                                _newFile.dataFile = _datafileChoised;

                                _newFile.duoiFile = _duoiFile;

                                _newFile.tenFile = _FilesChoised;

                                _dbFiles.tbFiles.InsertOnSubmit(_newFile);
                            }
                        }
                        else
                        {
                            tbFile _newFile = new tbFile();

                            _newFile.id = Guid.Parse(_idFile);

                            _newFile.dataFile = _datafileChoised;

                            _newFile.duoiFile = _duoiFile;

                            _newFile.tenFile = _FilesChoised;

                            _dbFiles.tbFiles.InsertOnSubmit(_newFile);
                        }

                        _dbFiles.SubmitChanges();
                    }
                    #endregion

                    //---//

                    if (rdKyHD.SelectedIndex == 1)
                    {
                        if (dateNgayKyHD.EditValue == "")
                        {
                            GUIHelper.MessageBox("Vui lòng chọn ngày ký HĐ!");

                            return;
                        }
                        else
                        {
                            _tbDGNS.ngayKyHD = dateNgayKyHD.DateTime.Date;
                        }
                    }
                    else
                    {
                        _tbDGNS.ngayKyHD = null;
                    }

                    if (rdKyHD.SelectedIndex >= 0)
                    {
                        _tbDGNS.isKyHopDong = int.Parse(rdKyHD.EditValue.ToString());
                    }

                    _db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);

                    this.Close();
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
        }

        private void dlgDanhGiaNhanSu_v2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgDanhGiaNhanSu_v2_Load(null, null);
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

        private IEnumerable<DevExpress.XtraEditors.GroupControl> EnumerateGroupControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.GroupControl).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.GroupControl)field.GetValue(this)
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
            var _GroupControl = EnumerateGroupControl();
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
            foreach (DevExpress.XtraEditors.GroupControl s in _GroupControl)
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