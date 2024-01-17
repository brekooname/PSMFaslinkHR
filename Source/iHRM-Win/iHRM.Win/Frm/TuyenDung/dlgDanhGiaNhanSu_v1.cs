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

namespace iHRM.Win.Frm.TuyenDung
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class dlgDanhGiaNhanSu_v1 : dlgCustomBase
    {
        //Khởi tạo//
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        List<BangDiem> _arr = new List<BangDiem>();

        public String _idNV = "";

        public int _flag = 0;

        public String _user = "";

        public DataRow _CRow;

        private String _sdg = "";

        String _FilesChoised = "";

        private String _idFiles = "";

        private Binary _data;

        private String _duoiFile = "";

        private int _flagFile = 0;
        //---//

        public dlgDanhGiaNhanSu_v1()
        {
            InitializeComponent();
        }

        private void InitGrd()
        {
            _arr.Add(new BangDiem() { MucDiem = "5", MoTa = "Xuất sắc" });

            _arr.Add(new BangDiem() { MucDiem = "4.5", MoTa = "Trung bình giỏi" });

            _arr.Add(new BangDiem() { MucDiem = "4", MoTa = "Giỏi" });

            _arr.Add(new BangDiem() { MucDiem = "3.5", MoTa = "Trung bình khá" });

            _arr.Add(new BangDiem() { MucDiem = "3", MoTa = "Trung bình" });

            _arr.Add(new BangDiem() { MucDiem = "2.5", MoTa = "Trung bình yếu" });

            _arr.Add(new BangDiem() { MucDiem = "2", MoTa = "Yếu" });

            _arr.Add(new BangDiem() { MucDiem = "1", MoTa = "Rất yếu" });

            grdDiem.DataSource = _arr;

            if(_flag == 1)
            {
                var _idDG = DbHelper.DrGet(_CRow, "idDG") != null ? DbHelper.DrGet(_CRow, "idDG") : "";

                DataTable _table_rat = new DataTable();

                _table_rat = Provider.ExecuteDataTableReader("p_tbDanhGiaNhanSu_GetRating"
                                                            , new SqlParameter("@idDG", _idDG));

                grdDanhGia.DataSource = _table_rat;
            }
            else
            {
                DataTable _tb = new DataTable();

                CacheDataTable.ResetCacheOnTable("tblRef_Rating");

                _tb = CacheDataTable.GetCacheDataTable("tblRef_Rating");

                _tb.Columns.Add("diemToTruong");

                _tb.Columns.Add("diemQuanLy");

                _tb.Columns.Add("diemXuongTruong");

                _tb.Columns.Add("diemKhac");

                _tb.Columns.Add("idDanhGia");

                _tb.Columns.Add("maDanhGia");

                grdDanhGia.DataSource = _tb;
            }

            lkToTruong.Properties.DataSource = _db.tblEmployees;

            lkQuanLy.Properties.DataSource = _db.tblEmployees;

            lkXuongTruong.Properties.DataSource = _db.tblEmployees;

            lkKhac.Properties.DataSource = _db.tblEmployees;
        }

        private void SetDGNS()
        {
            var _soDanhGia = _db.tbDanhGiaNhanSus.OrderByDescending(p => p.soDanhGia).FirstOrDefault();

            int _soDanhGia_Last = 0;

            if (_soDanhGia != null)
            {
                _soDanhGia_Last = int.Parse(_soDanhGia.soDanhGia.Substring(3, 3).ToString().Trim()) + 1;
            }
            else
                _soDanhGia_Last = _soDanhGia_Last + 1;

            txtSoDanhGia.Text = String.Format("SW-{0:000}/DGNS/{1:0000}", _soDanhGia_Last, DateTime.Now.ToString("yyMM"));
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

                txtMaNV.Text = _EmployeeID as String;

                txtHoTen.Text = _EmployeeName as String;

                txtChucVu.Text = _PosName as String;

                txtBoPhan.Text = _DepName as String;

                if (_AppliedDate != "")
                
                    dateNgayVaoLam.DateTime = DateTime.Parse(_AppliedDate.ToString()).Date;

                if (_ngayDanhGia != "")

                    dateNgayDanhGia.DateTime = DateTime.Parse(_ngayDanhGia.ToString()).Date;

                else

                    dateNgayDanhGia.DateTime = DateTime.Now.Date;

                txtMucLuong.Text = _BasicSalary == "" ? "0" : Convert.ToDecimal(_BasicSalary).ToString("#,#");

                if (_isKyHopDong != "")
                {
                    bool _check = bool.Parse(_isKyHopDong.ToString());

                    if (!_check)
                    {
                        ckbKyHD.SetItemChecked(1, true);
                        ckbKyHD.SetItemChecked(0, false);
                    }
                    else
                    {
                        ckbKyHD.SetItemChecked(0, true);
                        ckbKyHD.SetItemChecked(1, false);
                    }
                }
            }
            catch(Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void Load_User(String _us)
        {
            var _colKhac = grvDanhGia.Columns.ColumnByName("colKhac");

            var _colXT = grvDanhGia.Columns.ColumnByName("colXT");

            var _colQL = grvDanhGia.Columns.ColumnByName("colQL");

            var _colTT = grvDanhGia.Columns.ColumnByName("colTT");

            switch(_us)
            {
                case "TT":
                    lkToTruong.Enabled = true;

                    lkQuanLy.Enabled = false;

                    lkXuongTruong.Enabled = false;

                    lkKhac.Enabled = false;

                    colTT.OptionsColumn.AllowEdit = true;

                    txtYKien.Text = DbHelper.DrGet(_CRow, "ghiChuToTruong") != null ? DbHelper.DrGet(_CRow, "ghiChuToTruong").ToString() : "";

                    ; break;

                case "QL":
                    lkToTruong.Enabled = false;

                    lkQuanLy.Enabled = true;

                    lkXuongTruong.Enabled = false;

                    lkKhac.Enabled = false;

                    _colQL.OptionsColumn.AllowEdit = true;

                    txtYKien.Text = DbHelper.DrGet(_CRow, "ghiChuQuanLy") != null ? DbHelper.DrGet(_CRow, "ghiChuQuanLy").ToString() : "";

                    ; break;

                case "XT":
                    lkToTruong.Enabled = false;

                    lkQuanLy.Enabled = false;

                    lkXuongTruong.Enabled = true;

                    lkKhac.Enabled = false;

                    _colXT.OptionsColumn.AllowEdit = true;

                    txtYKien.Text = DbHelper.DrGet(_CRow, "ghiChuXuongTruong") != null ? DbHelper.DrGet(_CRow, "ghiChuXuongTruong").ToString() : "";

                    ; break;

                case "KHAC":
                    lkToTruong.Enabled = false;

                    lkQuanLy.Enabled = false;

                    lkXuongTruong.Enabled = false;

                    lkKhac.Enabled = true;

                    _colKhac.OptionsColumn.AllowEdit = true;

                    _colXT.OptionsColumn.AllowEdit = false;

                    _colQL.OptionsColumn.AllowEdit = false;

                    colTT.OptionsColumn.AllowEdit = false;

                    txtYKien.Text = DbHelper.DrGet(_CRow, "ghiChuKhac") != null ? DbHelper.DrGet(_CRow, "ghiChuKhac").ToString() : "";

                    ; break;

                default:
                    lkToTruong.Enabled = false;

                    lkQuanLy.Enabled = false;

                    lkXuongTruong.Enabled = false;

                    lkKhac.Enabled = false;

                    ; break;
            }
        }

        private bool CheckNull(DevExpress.XtraEditors.BaseEdit _control)
        {
            if (_control.EditValue == null || String.IsNullOrEmpty(_control.ToString())) return true;

            return false;
        }

        private bool Check()
        {
            if(CheckNull(dateNgayDanhGia))
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày đánh giá!");

                return true;
            }

            switch (_user)
            {
                case "TT":
                    if (CheckNull(lkToTruong))
                    {
                        GUIHelper.MessageBox("Vui lòng chọn người đánh giá!");

                        return true;
                    }

                    ; break;

                case "QL":
                    if (CheckNull(lkQuanLy))
                    {
                        GUIHelper.MessageBox("Vui lòng chọn người đánh giá!");

                        return true;
                    }

                    ; break;

                case "XT":
                    if (CheckNull(lkXuongTruong))
                    {
                        GUIHelper.MessageBox("Vui lòng chọn người đánh giá!");

                        return true;
                    }

                    ; break;

                case "KHAC":
                    if (CheckNull(lkKhac))
                    {
                        GUIHelper.MessageBox("Vui lòng chọn người đánh giá!");

                        return true;
                    }

                    //if (CheckNull(lkToTruong))
                    //{
                    //    GUIHelper.MessageBox("Vui lòng chọn người đánh giá!");

                    //    return true;
                    //}

                    //if (CheckNull(lkQuanLy))
                    //{
                    //    GUIHelper.MessageBox("Vui lòng chọn người đánh giá!");

                    //    return true;
                    //}

                    //if (CheckNull(lkXuongTruong))
                    //{
                    //    GUIHelper.MessageBox("Vui lòng chọn người đánh giá!");

                    //    return true;
                    //}

                    ; break;

                default:
                    return false;

            }

            return false;
        }

        private void dlgDanhGiaNhanSu_v1_Load(object sender, EventArgs e)
        {
            dateNgayDanhGia.DateTime = DateTime.Now.Date;

            InitGrd();

            Load_Data(_flag);

            Load_User(_user);

            if (_user == "") btnSave.Visible = false;

            else btnSave.Visible = true;

            if (_flag == 0)
            {
                SetDGNS();
            }
            else
            {
                tbDanhGiaNhanSu _tbdgns = new tbDanhGiaNhanSu();

                _tbdgns = _db.tbDanhGiaNhanSus.Where(i => i.soDanhGia == _sdg && i.idNV == _idNV).SingleOrDefault();

                if(_tbdgns != null)
                {
                    if(_tbdgns.isToTruong != null)
                    {
                        lkToTruong.EditValue = _tbdgns.idToTruong;
                    }

                    if (_tbdgns.isQuanLy != null)
                    {
                        lkQuanLy.EditValue = _tbdgns.idQuanLy;
                    }

                    if (_tbdgns.isXuongTruong != null)
                    {
                        lkXuongTruong.EditValue = _tbdgns.idXuongTruong;
                    }

                    if (_tbdgns.isKhac != null)
                    {
                        lkKhac.EditValue = _tbdgns.idKhac;
                    }
                }

                GetFile();
            }
        }

        private void dlgDanhGiaNhanSu_v1_FormClosing(object sender, FormClosingEventArgs e)
        {
            grdDanhGia.DataSource = null;

            grdDiem.DataSource = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _listActionClass.Clear();

            if (Check()) return;

            if(_flag == 0)//Tạo mới đánh giá
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

                if (ckbKyHD.Items[1].CheckState != CheckState.Checked && ckbKyHD.Items[0].CheckState != CheckState.Checked) //Xét ký hợp đồng
                {
                    _tbDGNS.isKyHopDong = null;
                }
                else
                {
                    //if (ckbKyHD.Items[0].CheckState == CheckState.Checked)

                    //    _tbDGNS.isKyHopDong = true;

                    //if (ckbKyHD.Items[1].CheckState == CheckState.Checked)

                    //    _tbDGNS.isKyHopDong = false;
                }

                try
                {
                    var _check = _db.tbDanhGiaNhanSus.Where(x => x.soDanhGia == txtSoDanhGia.Text && x.ngayDanhGia == dateNgayDanhGia.DateTime).SingleOrDefault();

                    if(_check != null)
                    {
                        GUIHelper.MessageBox("Nhân viên đã được đánh giá. Không thể đánh giá!");

                        return;
                    }

                    switch (_user)
                    {
                        case "TT":
                            _tbDGNS.diemToTruong = 0;

                            foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                            {
                                if (_dr["diemToTruong"] == null || String.IsNullOrEmpty(_dr["diemToTruong"] as String))
                                    
                                    _dr["diemToTruong"] = 0;

                                if (_tbDGNS.diemToTruong == null || String.IsNullOrEmpty(_tbDGNS.diemToTruong.ToString()))

                                    _tbDGNS.diemToTruong = 0;

                                _tbDGNS.diemToTruong += float.Parse(_dr["diemToTruong"] as String);
                            }

                            _tbDGNS.isToTruong = true;

                            _tbDGNS.idToTruong = lkToTruong.EditValue as String;

                            _tbDGNS.ghiChuToTruong = txtYKien.Text;

                            ; break;

                        case "QL":
                            _tbDGNS.diemQuanLy = 0;

                            foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                            {
                                if (_dr["diemQuanLy"] == null || String.IsNullOrEmpty(_dr["diemQuanLy"] as String))

                                    _dr["diemQuanLy"] = 0;

                                if (_tbDGNS.diemQuanLy == null || String.IsNullOrEmpty(_tbDGNS.diemQuanLy.ToString()))

                                    _tbDGNS.diemQuanLy = 0;

                                _tbDGNS.diemQuanLy += float.Parse(_dr["diemQuanLy"] as String);
                            }

                            _tbDGNS.isQuanLy = true;

                            _tbDGNS.idQuanLy = lkQuanLy.EditValue as String;

                            _tbDGNS.ghiChuQuanLy = txtYKien.Text;

                            ; break;

                        case "XT":
                            _tbDGNS.diemXuongTruong = 0;

                            foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                            {
                                if (_dr["diemXuongTruong"] == null || String.IsNullOrEmpty(_dr["diemXuongTruong"] as String))

                                    _dr["diemXuongTruong"] = 0;

                                if (_tbDGNS.diemXuongTruong == null || String.IsNullOrEmpty(_tbDGNS.diemXuongTruong.ToString()))

                                    _tbDGNS.diemXuongTruong = 0;

                                _tbDGNS.diemXuongTruong += float.Parse(_dr["diemXuongTruong"] as String);
                            }

                            _tbDGNS.isXuongTruong = true;

                            _tbDGNS.idXuongTruong = lkXuongTruong.EditValue as String;

                            _tbDGNS.ghiChuXuongTruong = txtYKien.Text;

                            ; break;

                        case "KHAC":
                            _tbDGNS.diemKhac = 0;

                            foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                            {
                                if (_dr["diemKhac"] == null || String.IsNullOrEmpty(_dr["diemKhac"] as String))

                                    _dr["diemKhac"] = 0;

                                if (_tbDGNS.diemKhac == null || String.IsNullOrEmpty(_tbDGNS.diemKhac.ToString()))

                                    _tbDGNS.diemKhac = 0;

                                _tbDGNS.diemKhac += float.Parse(_dr["diemKhac"] as String);
                            }

                            _tbDGNS.isKhac = true;

                            _tbDGNS.idKhac = lkKhac.EditValue as String;

                            _tbDGNS.ghiChuKhac = txtYKien.Text;

                            ; break;

                        default: break;
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

                    //_listActionClass.Add(new ActionClass("Thêm đánh giá " + _tbDGNS.soDanhGia.ToString()
                    //            , _tbDGNS.idNV.ToString()
                    //            , ""
                    //            , "Thêm đánh giá nhân viên " 
                    //                + _tbDGNS.idNV.ToString() + " tình trang HĐ "
                    //                + (_tbDGNS.isKyHopDong == null ? "Trống" : (_tbDGNS.isKyHopDong == true ? "Ký HĐ" : "Không ký HĐ"))
                    //            , "tbDanhGiaNhanSu")); //Lưu lịch sử

                    LogAction.LogAction.PushLog(_listActionClass);

                    _db.tbDanhGiaNhanSus.InsertOnSubmit(_tbDGNS);

                    _db.SubmitChanges();

                    var _table_DG = _db.tbDanhGiaNhanSus.OrderByDescending(p => p.id).FirstOrDefault();

                    int _i = 1;

                    foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                    {
                        _dr["maDanhGia"] = _i;

                        _dr["idDanhGia"] = _table_DG.id;

                        _i++;
                    }

                    foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                    {
                        tbDanhGiaNhanSu_ChiTiet _tbDGNS_CT = new tbDanhGiaNhanSu_ChiTiet();

                        _tbDGNS_CT.idDanhGia = int.Parse(_dr["idDanhGia"] as String);

                        _tbDGNS_CT.maDanhGia = _dr["maDanhGia"] as String;

                        _tbDGNS_CT.diemToTruong = _dr["diemToTruong"] as String;

                        _tbDGNS_CT.diemQuanLy = _dr["diemQuanLy"] as String;

                        _tbDGNS_CT.diemXuongTruong = _dr["diemXuongTruong"] as String;

                        _tbDGNS_CT.diemKhac = _dr["diemKhac"] as String;

                        _db.tbDanhGiaNhanSu_ChiTiets.InsertOnSubmit(_tbDGNS_CT);

                        _db.SubmitChanges();
                    }

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                    _flag = 1;

                    this.Close();
                }
                catch(Exception ex)
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

                if (ckbKyHD.Items[1].CheckState != CheckState.Checked && ckbKyHD.Items[0].CheckState != CheckState.Checked) //Xét ký hợp đồng
                {
                    _tbDGNS.isKyHopDong = null;
                }
                else
                {
                    //if (ckbKyHD.Items[0].CheckState == CheckState.Checked)

                    //    _tbDGNS.isKyHopDong = true;

                    //if (ckbKyHD.Items[1].CheckState == CheckState.Checked)

                    //    _tbDGNS.isKyHopDong = false;
                }

                try
                {
                    //_listActionClass.Add(new ActionClass("Cập nhật đánh giá " + _tbDGNS.soDanhGia.ToString()
                    //            , _tbDGNS.idNV.ToString()
                    //            , ""
                    //            , "Cập nhật đánh giá nhân viên "
                    //                + _tbDGNS.idNV.ToString() + " tình trang HĐ "
                    //                + (_tbDGNS.isKyHopDong == null ? "Trống" : (_tbDGNS.isKyHopDong == true ? "Ký HĐ" : "Không ký HĐ"))
                    //            , "tbDanhGiaNhanSu")); //Lưu lịch sử

                    LogAction.LogAction.PushLog(_listActionClass);

                    switch (_user)
                    {
                        case "TT":
                            _tbDGNS.diemToTruong = 0;

                            foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                            {
                                if (_dr["diemToTruong"] == null || String.IsNullOrEmpty(_dr["diemToTruong"] as String))

                                    _dr["diemToTruong"] = 0;

                                if (_tbDGNS.diemToTruong == null || String.IsNullOrEmpty(_tbDGNS.diemToTruong.ToString()))

                                    _tbDGNS.diemToTruong = 0;

                                _tbDGNS.diemToTruong += float.Parse(_dr["diemToTruong"] as String);
                            }

                            _tbDGNS.isToTruong = true;

                            _tbDGNS.idToTruong = lkToTruong.EditValue as String;

                            _tbDGNS.ghiChuToTruong = txtYKien.Text;

                            ; break;

                        case "QL":
                            _tbDGNS.diemQuanLy = 0;

                            foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                            {
                                if (_dr["diemQuanLy"] == null || String.IsNullOrEmpty(_dr["diemQuanLy"] as String))

                                    _dr["diemQuanLy"] = 0;

                                if (_tbDGNS.diemQuanLy == null || String.IsNullOrEmpty(_tbDGNS.diemQuanLy.ToString()))

                                    _tbDGNS.diemQuanLy = 0;

                                _tbDGNS.diemQuanLy += float.Parse(_dr["diemQuanLy"] as String);
                            }

                            _tbDGNS.isQuanLy = true;

                            _tbDGNS.idQuanLy = lkQuanLy.EditValue as String;

                            _tbDGNS.ghiChuQuanLy = txtYKien.Text;

                            ; break;

                        case "XT":
                            _tbDGNS.diemXuongTruong = 0;

                            foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                            {
                                if (_dr["diemXuongTruong"] == null || String.IsNullOrEmpty(_dr["diemXuongTruong"] as String))

                                    _dr["diemXuongTruong"] = 0;

                                if (_tbDGNS.diemXuongTruong == null || String.IsNullOrEmpty(_tbDGNS.diemXuongTruong.ToString()))

                                    _tbDGNS.diemXuongTruong = 0;

                                _tbDGNS.diemXuongTruong += float.Parse(_dr["diemXuongTruong"] as String);
                            }

                            _tbDGNS.isXuongTruong = true;

                            _tbDGNS.idXuongTruong = lkXuongTruong.EditValue as String;

                            _tbDGNS.ghiChuXuongTruong = txtYKien.Text;

                            ; break;

                        case "KHAC":
                            foreach (DataRow _dr in (grdDanhGia.DataSource as DataTable).Rows)
                            {
                                if (_dr["diemKhac"] == null || String.IsNullOrEmpty(_dr["diemKhac"] as String))

                                    _dr["diemKhac"] = 0;

                                if (_tbDGNS.diemKhac == null || String.IsNullOrEmpty(_tbDGNS.diemKhac.ToString()))

                                    _tbDGNS.diemKhac = 0;

                                _tbDGNS.diemKhac += float.Parse(_dr["diemKhac"] as String);
                            }

                            _tbDGNS.isKhac = true;

                            _tbDGNS.idKhac = lkKhac.EditValue as String;

                            _tbDGNS.ghiChuKhac = txtYKien.Text;

                            ; break;

                        default: break;
                    }
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

                    _db.SubmitChanges();

                    Provider.UpdateData((grdDanhGia.DataSource as DataTable), "tbDanhGiaNhanSu_ChiTiet");

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);

                    this.Close();
                }
                catch(Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
        }

        private void btnChonFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        private void grvDanhGia_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grvDanhGia_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            String _str = grvDanhGia.FocusedColumn.FieldName;

            Double _index = 0;

            switch(_str)
            {
                case "diemToTruong": 
                case "diemQuanLy": 
                case "diemXuongTruong":
                case "diemKhac":

                    if (!Double.TryParse(e.Value as String, out _index))
                    {
                        e.Valid = false;

                        e.ErrorText = "Kiểu dữ liệu không đúng!";
                    }
                    else
                    {
                        switch (e.Value as String)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "2.5":
                            case "3.5":
                            case "4.5": break;

                            default:

                                e.Valid = false;

                                e.ErrorText = "Điểm nhập không đúng!";

                                break;
                        }
                    }

                    break;

                default: break;
            }
        }

        private class BangDiem
        {
            public string MucDiem { get; set; }
            public string MoTa { get; set; }
        }

        private void ckbKyHD_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < ckbKyHD.Items.Count; ++ix)
                if (ix != e.Index) ckbKyHD.SetItemChecked(ix, false);
        }
    }
}