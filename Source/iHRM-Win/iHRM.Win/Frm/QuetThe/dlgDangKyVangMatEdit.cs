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
using iHRM.Core.FileDB;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgDangKyVangMatEdit : dlgCustomBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);
        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
      
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        List<ActionClass> _listActionClass = new List<ActionClass>();

        string FilesChoised = "";

        public int coHuongLuong = 0;

        public  string manv = null;

        public  DateTime ngaydk;

        String _FilesChoised = "";

        public Guid _idFiles;

        private Binary _data = null;

        private String _duoiFile = "";

        private int _flagFile = 0;

        public dlgDangKyVangMatEdit()
        {
            InitializeComponent();          
        }

        private void Load_Data()
        {
            var _data = db.tblEmpDayOffs.Where(p => p.EmployeeID == manv && p.FromDate == ngaydk.Date).SingleOrDefault();

            var _emp = db.tblEmployees.Where(p => p.EmployeeID == manv).SingleOrDefault();

            if(_data != null)
            {
                txtMaNV.Text = _data.EmployeeID;

                txtTenNV.Text = _emp.EmployeeName;

                txtBP.Text = _emp.DepName_Final;

                txtChucVu.Text = _emp.PosName;

                dateTuNgay.EditValue = _data.FromDate;

                dateDenNgay.EditValue = _data.ToDate;

                txtLyDo.EditValue = _data.LeaveID;

                txtGhiChu.Text = _data.Notes;

                cmbXinNghi.SelectedIndex = (int)_data.PerTimeID - 1;
            }
        }

        private bool Delete_File()
        {
            if (btnFile.Text == "" && _idFiles != null)
            {
                var _tbFile = _dbFiles.tbFiles.Where(i => i.id == _idFiles).SingleOrDefault();

                if (_tbFile != null)
                {
                    _dbFiles.tbFiles.DeleteOnSubmit(_tbFile);

                    _dbFiles.SubmitChanges();
                }

                return true;
            }

            return false;
        }

        private void GetFile()
        {
            var _tbFile = _dbFiles.tbFiles.Where(i => i.id == _idFiles).SingleOrDefault();

            if (_tbFile != null)
            {
                _FilesChoised = _tbFile.tenFile;

                btnFile.Text = string.Format(_FilesChoised);

                var _indexData = _tbFile.dataFile;

                _data = _indexData;

                _duoiFile = _tbFile.duoiFile;
            }

        }

        private void dlgDangKyVangMatEdit_Load(object sender, EventArgs e)
        {
            if (coHuongLuong == 1)
            {
                txtLyDo.Properties.DataSource = db.tblRef_LeaveTypes.Where(p => p.SalaryRate > 0);

                this.Form_Title = "Cập nhật vắng mặt có lương";
            }
            if (coHuongLuong == 0)
            {
                txtLyDo.Properties.DataSource = db.tblRef_LeaveTypes.Where(p => p.SalaryRate == 0 || p.SalaryRate == null);

                this.Form_Title = "Cập nhật vắng mặt không lương";
            }

            Load_Data();

            GetFile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _listActionClass.Clear();

            DateTime tuNgay = dateTuNgay.DateTime;

            DateTime denNgay = dateDenNgay.DateTime;

            var count_day = (denNgay - tuNgay).TotalDays;

            if (count_day < 0)
            {
                GUIHelper.MessageBox("Từ ngày nhỏ hơn đến ngày!\r\n");

                return;
            }
            
            if(txtLyDo.EditValue == null)
            {
                GUIHelper.MessageBox("Vui lòng chọn lý do nghỉ!\r\n");

                return;
            }

            var _tbOff = db.tblEmpDayOffs.Where(p => p.EmployeeID == manv && p.FromDate == ngaydk.Date).SingleOrDefault();

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

            //byte[] _bytes = null;

            Binary _datafileChoised = null;

            String _duoiFile = "";

            try
            {
                if (_isChoiseFile)
                {
                    _datafileChoised = _data;

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
                _tbOff.idFile = null;
            }

            //Cập nhật file//

            Guid _idFile = _tbOff.idFile != null ? (Guid)_tbOff.idFile : Guid.NewGuid();

            if (_isChoiseFile)
            {
                _tbOff.idFile = _idFile;
            }

            #region Add file to other database
            if (_isChoiseFile) // Nếu chọn file đính kèm
            {

                if (_tbOff.idFile != null)
                {
                    var _f1 = _dbFiles.tbFiles.Where(p => p.id == _tbOff.idFile).FirstOrDefault();

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

            _tbOff.ToDate = dateDenNgay.DateTime.Date;

            _tbOff.Notes = txtGhiChu.Text;

            _tbOff.LeaveID = txtLyDo.EditValue as String;

            _tbOff.PerTimeID = cmbXinNghi.SelectedIndex + 1;

            _tbOff.Days = Ham.DemNgayCong(tuNgay, denNgay) * ((cmbXinNghi.SelectedIndex + 1) == 3 ? 1 : 0.5);

            db.SubmitChanges();

            LogAction.LogAction.PushLog("Cập nhật vắng mặt"
                            , _tbOff.EmployeeID
                            , ""
                            , string.Format("Cập nhật vắng mặt từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}"
                                            , dateTuNgay.DateTime.Date
                                            , dateDenNgay.DateTime.Date)
                            , "tblEmpDayOff");

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
                    _FilesChoised = od.FileNames[0];

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

        private void linkXemFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

    }
}
