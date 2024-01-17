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

namespace iHRM.Win.Frm.Employee
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class dlgDonXinNghi : dlgCustomBase
    {
        //Khởi tạo//
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        DateTime _ngayNghi = DateTime.Now;

        public int _flag = 0;

        public DataRow _CRow;

        String _FilesChoised = "";

        private String _idFile = "";

        private Binary _data;

        private String _duoiFile = "";

        private int _flagFile = 0;
        //---//

        public dlgDonXinNghi()
        {
            InitializeComponent();
        }

        private void setDateNullIfBlank(DateEdit d)
        {
            if (d.Text == "")
            {
                d.EditValue = null;
            }
        }

        private void GetFile()
        {
            var _isFile = DbHelper.DrGet(_CRow, "idFile") != null ? DbHelper.DrGet(_CRow, "idFile") : "";

            if (!String.IsNullOrEmpty(_isFile.ToString()))
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

                if (_tbFile != null)
                {
                    _dbFiles.tbFiles.DeleteOnSubmit(_tbFile);

                    _dbFiles.SubmitChanges();
                }

                return true;
            }

            return false;
        }

        public void InitLookUp()
        {
            //Load dữ liệu cho Search LookUp//
            //Start//

            var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));

            lkpEmployeeID.Properties.DataSource = dtnv;
            lkpEmployeeID.Properties.DisplayMember = "EmployeeName";
            lkpEmployeeID.Properties.ValueMember = "EmployeeCode";


            lkNVBanGiao.Properties.DataSource = dtnv;
            lkNVBanGiao.Properties.DisplayMember = "EmployeeName";
            lkNVBanGiao.Properties.ValueMember = "EmployeeCode";

            lkLoaiNghi.Properties.DataSource = _db.tblRef_LeftTypes;
            //End//
        }

        private void dlgDonXinNghi_v4_Load(object sender, EventArgs e)
        {
            TranslateForm();

            if (_flag == 0) //Load Dialog thêm//
            {
                dateNghi.DateTime = dateNopDon.DateTime = DateTime.Now.Date;

                btnSave.Visible = true;

                btnUpdate.Visible = false;

                InitLookUp();
            }
            else //Load Dialog cập nhật//
            {
                dateNghi.DateTime = dateNopDon.DateTime = DateTime.Now.Date;

                btnSave.Visible = false;

                btnUpdate.Visible = true;

                GetFile();

                InitLookUp();

                //Đổ dữ liệu vào Edit Control//

                var _EmployeeID = DbHelper.DrGet(_CRow, "EmployeeID") != null ? DbHelper.DrGet(_CRow, "EmployeeID") : "";

                var _idNVBanGiao = DbHelper.DrGet(_CRow, "idNVBanGiao") != null ? DbHelper.DrGet(_CRow, "idNVBanGiao") : "";

                var _ngayNghiViec = DbHelper.DrGet(_CRow, "ngayNghiViec") != null ? DbHelper.DrGet(_CRow, "ngayNghiViec") : "";

                var _ngayNopDon = DbHelper.DrGet(_CRow, "ngayNopDon") != null ? DbHelper.DrGet(_CRow, "ngayNopDon") : "";

                var _lyDoNghi = DbHelper.DrGet(_CRow, "lyDoNghi") != null ? DbHelper.DrGet(_CRow, "lyDoNghi") : "";

                var _noiDungBanGiao = DbHelper.DrGet(_CRow, "noiDungBanGiao") != null ? DbHelper.DrGet(_CRow, "noiDungBanGiao") : "";

                var _ghiChu = DbHelper.DrGet(_CRow, "ghiChu") != null ? DbHelper.DrGet(_CRow, "ghiChu") : "";

                var _LeftTypeID = DbHelper.DrGet(_CRow, "LeftTypeID") != null ? DbHelper.DrGet(_CRow, "LeftTypeID") : "";

                lkpEmployeeID.EditValue = _EmployeeID;

                lkNVBanGiao.EditValue = _idNVBanGiao;

                _ngayNghi = dateNghi.DateTime = DateTime.Parse(_ngayNghiViec.ToString()).Date;

                dateNopDon.DateTime = DateTime.Parse(_ngayNopDon.ToString()).Date;

                txtLyDo.Text = _lyDoNghi as String;

                txtCongViec.Text = _noiDungBanGiao as String;

                txtGhiChu.Text = _ghiChu as String;

                lkLoaiNghi.EditValue = _LeftTypeID;

                //---//

            }
        }

        #region: Event thêm đơn xin nghỉ việc
        private void btnSave_Click(object sender, EventArgs e)
        {
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

            //Đổ dữ liệu vào//

            tbDonXinNghiViec _tbDXN = new tbDonXinNghiViec();

            int _check = _db.tbDonXinNghiViecs.Where(x => x.EmployeeID == lkpEmployeeID.EditValue).Count();

            _tbDXN.lyDoNghi = txtLyDo.Text;

            _tbDXN.noiDungBanGiao = txtCongViec.Text;

            _tbDXN.ghiChu = txtGhiChu.Text;

            _tbDXN.ngayNghiViec = dateNghi.DateTime;

            _tbDXN.ngayNopDon = dateNopDon.DateTime;

            _tbDXN.EmployeeID = lkpEmployeeID.EditValue as String;

            _tbDXN.idNVBanGiao = lkNVBanGiao.EditValue as String;

            _tbDXN.LeftTypeID = lkLoaiNghi.EditValue as String;

            _tbDXN.idUserRequest = LoginHelper.user.id;

            //---//

            //Xét điều kiện - Start//

            if (_tbDXN.ngayNghiViec == null || _tbDXN.ngayNghiViec.ToString() == "")
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày!");

                return;
            }

            //Check thông tin nhân viên//

            var _check_Nv = _db.tblEmployees.Where(x => x.EmployeeID == lkpEmployeeID.EditValue);

            var _check_NvT = _db.tblEmployees.Where(x => x.EmployeeID == lkNVBanGiao.EditValue);

            //Check ngày//

            DateTime _ngaynghi = _tbDXN.ngayNghiViec.Date;

            DateTime _ngaynopdon = _tbDXN.ngayNopDon.Value;

            //if (DateTime.Compare(_ngaynghi, _ngaynopdon) < 0)
            //{
            //    GUIHelper.MessageBox("Ngày nghỉ không nhỏ hơn ngày nộp đơn. Vui lòng chọn lại!");

            //    return;
            //}

            if (lkpEmployeeID.EditValue == null
                ||
                lkpEmployeeID.EditValue.ToString() == "")
            {
                GUIHelper.MessageBox("Vui lòng chọn nhân viên!");

                return;
            }

            if (lkLoaiNghi.EditValue == null
                ||
                lkLoaiNghi.EditValue.ToString() == "")
            {
                GUIHelper.MessageBox("Vui lòng chọn loại nghỉ!");

                return;
            }

            if (dateNghi == null || dateNghi.ToString() == "")
            {
                GUIHelper.MessageBox("Vui lòng nhập ngày!");

                return;
            }

            if (String.Equals(lkpEmployeeID.EditValue, lkNVBanGiao.EditValue))
            {
                GUIHelper.MessageBox("Nhân viên nghỉ và nhân viên bàn giao trùng. Vui lòng kiểm tra lại!");

                return;
            }

            if (_check_Nv == null || _check_Nv.ToString() == "")
            {
                GUIHelper.MessageBox("Mã nhân viên nghỉ không đúng. Vui lòng kiểm tra lại!");

                return;
            }

            if (_check_NvT == null || _check_NvT.ToString() == "")
            {
                GUIHelper.MessageBox("Mã nhân viên thay không đúng. Vui lòng kiểm tra lại!");

                return;
            }

            //Check Nhân viên đã xin nghỉ chưa//

            if (_check > 0)
            {
                GUIHelper.MessageBox("Nhân viên đã xin nghỉ. Không thể thêm!");

                return;
            }

            //Xét điều kiện - End//

            //////////////////////

            //Thêm đơn xin nghỉ//

            mainBase.Dowork_Item _dw_it = new mainBase.Dowork_Item();

            int success = 0;

            _dw_it.OnDoing = (s, ev) =>
            {
                try
                {
                    _dw_it.bw.ReportProgress(1, "Đang đăng ký...");

                    _dw_it.bw.ReportProgress(0, 1);

                    //Thêm File//

                    Guid _idFile = _tbDXN.idFile != null ? _tbDXN.idFile.Value : Guid.NewGuid();

                    if (_isChoiseFile)
                    {
                        _tbDXN.idFile = _idFile;
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

                    _listActionClass.Add(new ActionClass("Thêm dữ liệu nhân viên " + _tbDXN.EmployeeID + " ngày nghỉ việc " + _tbDXN.ngayNghiViec
                                , _tbDXN.EmployeeID
                                , ""
                                , "Thêm đơn xin nghỉ việc ngày: " +DateTime.Now.Date
                                , "tbDonXinNghiViec")); //Lưu lịch sử

                    LogAction.LogAction.PushLog(_listActionClass);

                    _db.tbDonXinNghiViecs.InsertOnSubmit(_tbDXN);

                    _db.SubmitChanges();

                    success++;

                    GUIHelper.MessageBox("Thêm thành công đăng ký nghỉ việc nhân viên: " + _check_Nv.SingleOrDefault().EmployeeName + " - " + _tbDXN.EmployeeID + '\r' + '\n');
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            };

            _dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 0)
                {
                    ucProgress1.start(0, (int)data.UserState);
                }
                else if (data.ProgressPercentage == 1)
                {
                    ucProgress1.Status = data.UserState.ToString();
                }
                else if (data.ProgressPercentage == 2)
                {
                    ucProgress1.Message = ucProgress1.Message + "\n" + data.UserState;
                }
                else if (data.ProgressPercentage == 3)
                {
                    ucProgress1.CurrentValue = (int)data.UserState;
                }
            };

            _dw_it.OnCompleting = (ps, obj) =>
            {
                if (success > 0)
                {
                    ucProgress1.Status = "Đăng ký xin nghỉ việc thành công " + success + " records";
                }
                else
                {
                    ucProgress1.Status = "Không có nhân viên nào được đăng ký";
                }

                btnSave.Enabled = true;

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
            };

            main.Instance.DoworkItem_Reg(_dw_it);

            this.Close();

            //---//
        }
        #endregion

        #region: Event cập nhật đơn xin nghỉ việc
        private void btnUpdate_Click(object sender, EventArgs e)
        {
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

            //Đổ dữ liệu vào//

            tbDonXinNghiViec _tbDXN = new tbDonXinNghiViec();

            _tbDXN = _db.tbDonXinNghiViecs.Where(x => x.EmployeeID == lkpEmployeeID.EditValue
                                                        && x.ngayNghiViec == _ngayNghi).SingleOrDefault();

            _tbDXN.lyDoNghi = txtLyDo.Text;

            _tbDXN.noiDungBanGiao = txtCongViec.Text;

            _tbDXN.ghiChu = txtGhiChu.Text;

            _tbDXN.ngayNghiViec = dateNghi.DateTime;

            _tbDXN.ngayNopDon = dateNopDon.DateTime;

            _tbDXN.EmployeeID = lkpEmployeeID.EditValue as String;

            _tbDXN.idNVBanGiao = lkNVBanGiao.EditValue as String;

            _tbDXN.LeftTypeID = lkLoaiNghi.EditValue as String;


            if (Delete_File() == true)
            {
                _tbDXN.idFile = null;
            }

            //---//

            //Xét điều kiện - Start//

            if (_tbDXN.ngayNghiViec == null || _tbDXN.ngayNghiViec.ToString() == "")
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày!");

                return;
            }

            //Check thông tin nhân viên//

            var _check_Nv = _db.tblEmployees.Where(x => x.EmployeeID == lkpEmployeeID.EditValue);

            var _check_NvT = _db.tblEmployees.Where(x => x.EmployeeID == lkNVBanGiao.EditValue);

            //Check ngày//

            DateTime _ngaynghi = _tbDXN.ngayNghiViec.Date;

            DateTime _ngaynopdon = _tbDXN.ngayNopDon.Value;

            //if (DateTime.Compare(_ngaynghi, _ngaynopdon) < 0)
            //{
            //    GUIHelper.MessageBox("Ngày nghỉ không nhỏ hơn ngày nộp đơn. Vui lòng chọn lại!");

            //    return;
            //}

            if (lkpEmployeeID.EditValue == null
                ||
                lkpEmployeeID.EditValue.ToString() == "")
            {
                GUIHelper.MessageBox("Vui lòng chọn nhân viên!");

                return;
            }

            if (lkLoaiNghi.EditValue == null
                ||
                lkLoaiNghi.EditValue.ToString() == "")
            {
                GUIHelper.MessageBox("Vui lòng chọn loại nghỉ!");

                return;
            }

            if (dateNghi == null || dateNghi.ToString() == "")
            {
                GUIHelper.MessageBox("Vui lòng nhập ngày!");

                return;
            }

            if (String.Equals(lkpEmployeeID.EditValue, lkNVBanGiao.EditValue))
            {
                GUIHelper.MessageBox("Nhân viên nghỉ và nhân viên bàn giao trùng. Vui lòng kiểm tra lại!");

                return;
            }

            if (_check_Nv == null || _check_Nv.ToString() == "")
            {
                GUIHelper.MessageBox("Mã nhân viên nghỉ không đúng. Vui lòng kiểm tra lại!");

                return;
            }

            if (_check_NvT == null || _check_NvT.ToString() == "")
            {
                GUIHelper.MessageBox("Mã nhân viên thay không đúng. Vui lòng kiểm tra lại!");

                return;
            }

            //Xét điều kiện - End//

            //////////////////////

            //Cập nhật đơn xin nghỉ//

            mainBase.Dowork_Item _dw_it = new mainBase.Dowork_Item();

            int success = 0;

            _dw_it.OnDoing = (s, ev) =>
            {
                try
                {
                    _dw_it.bw.ReportProgress(1, "Đang đăng ký...");

                    _dw_it.bw.ReportProgress(0, 1);

                    //Cập nhật file//

                    Guid _idFile = _tbDXN.idFile != null ? _tbDXN.idFile.Value : Guid.NewGuid();

                    if (_isChoiseFile)
                    {
                        _tbDXN.idFile = _idFile;
                    }

                    #region Add file to other database
                    if (_isChoiseFile) // Nếu chọn file đính kèm
                    {

                        if (_tbDXN.idFile != null)
                        {
                            var _f1 = _dbFiles.tbFiles.Where(p => p.id == _tbDXN.idFile.Value).FirstOrDefault();

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

                                _newFile.tenFile = _FilesChoised;

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

                    //---//

                    _listActionClass.Add(new ActionClass("Cập nhật dữ liệu nhân viên " + _tbDXN.EmployeeID + " ngày nghỉ việc " + _tbDXN.ngayNghiViec
                                , _tbDXN.EmployeeID
                                , ""
                                , "Cập nhật đơn xin nghỉ việc ngày: " + DateTime.Now.Date
                                , "tbDonXinNghiViec"));//Lưu lịch sử

                    LogAction.LogAction.PushLog(_listActionClass);

                    _db.SubmitChanges();

                    success++;

                    GUIHelper.MessageBox("Cập nhật thành công đăng ký nghỉ việc nhân viên: " + _check_Nv.SingleOrDefault().EmployeeName + " - " + _tbDXN.EmployeeID + '\r' + '\n');
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            };

            _dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 0)
                {
                    ucProgress1.start(0, (int)data.UserState);
                }
                else if (data.ProgressPercentage == 1)
                {
                    ucProgress1.Status = data.UserState.ToString();
                }
                else if (data.ProgressPercentage == 2)
                {
                    ucProgress1.Message = ucProgress1.Message + "\n" + data.UserState;
                }
                else if (data.ProgressPercentage == 3)
                {
                    ucProgress1.CurrentValue = (int)data.UserState;
                }
            };

            _dw_it.OnCompleting = (ps, obj) =>
            {
                if (success > 0)
                {
                    ucProgress1.Status = "Cập nhật thông tin xin nghỉ việc thành công " + success + " records";
                }
                else
                {
                    ucProgress1.Status = "Không có nhân viên nào được đăng ký";
                }

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
            };

            main.Instance.DoworkItem_Reg(_dw_it);

            this.Close();

            //---//
        }
        #endregion

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

        private void lkNVNghi_Leave(object sender, EventArgs e)
        {
            if (lkpEmployeeID.EditValue == null || lkpEmployeeID.EditValue == "")
            {
                lkpEmployeeID.Properties.NullText = "Chọn nhân viên ";
            }
        }

        private void lkNVBanGiao_Leave(object sender, EventArgs e)
        {
            if (lkNVBanGiao.EditValue == null || lkNVBanGiao.EditValue == "")
            {
                lkNVBanGiao.Properties.NullText = "Chọn nhân viên ";
            }
        }

        private void dateNghi_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNghi);//Set null khi control = ""
        }

        private void dateNopDon_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNopDon);//Set null khi control = ""
        }

        private void lkLoaiNghi_Leave(object sender, EventArgs e)
        {
            if (lkLoaiNghi.EditValue == null)
            {
                lkLoaiNghi.Properties.NullText = "Chọn loại nghỉ ";
            }
        }

        private void txtLyDo_Enter(object sender, EventArgs e)
        {
            if (txtLyDo.Text == null)
            {
                txtLyDo.Text = "";
            }
        }

        private void txtCongViec_Leave(object sender, EventArgs e)
        {
            if (txtCongViec.Text == null)
            {
                txtCongViec.Text = "";
            }
        }

        private void lkNVNghi_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpEmployeeID.EditValue != null)
            {
                tblEmployee _Employee = _db.tblEmployees.Where(x => x.EmployeeID == lkpEmployeeID.EditValue).SingleOrDefault();

                txtPBNghi.Text = _Employee != null ? _Employee.DepName : "";
            }
            else
            {
                txtPBNghi.Text = "";
            }
        }

        private void lkNVBanGiao_EditValueChanged(object sender, EventArgs e)
        {
            if (lkNVBanGiao.EditValue != null)
            {
                tblEmployee _Employee = _db.tblEmployees.Where(x => x.EmployeeID == lkNVBanGiao.EditValue).SingleOrDefault();

                txtPBThay.Text = _Employee != null ? _Employee.DepName : "";
            }
            else
            {
                txtPBThay.Text = "";
            }
        }

        private void dlgDonXinNghi_v4_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Refesh Control//

            dateNghi.DateTime = dateNopDon.DateTime = DateTime.Now.Date;

            txtCongViec.Text = "";

            txtLyDo.Text = "";

            btnFile.Text = "";

            //---//
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

        private void dlgDonXinNghi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgDonXinNghi_v4_Load(null, null);
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
            var _LayoutItem = EnumerateLayoutItem();
            var _SimpleButton = EnumerateSimpleButton();
            var _LableControl = EnumerateLabelControl();
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