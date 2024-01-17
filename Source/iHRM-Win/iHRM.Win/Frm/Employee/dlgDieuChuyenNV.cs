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
    public partial class dlgDieuChuyenNV : dlgCustomBase
    {
        //Khởi tạo//
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        public int _flag = 0;

        public DataRow _CRow;

        String _FilesChoised = "";

        private String _idFile = "";

        private Binary _data;

        private String _duoiFile = "";

        private int _flagFile = 0;
        //---//
        public dlgDieuChuyenNV()
        {
            InitializeComponent();

            _flag = 0;
        }

        private void dlgDieuChuyenNV_Load(object sender, EventArgs e)
        {
            TranslateForm();

            dateNgayHieuLuc.DateTime = DateTime.Now.Date;

            InitLookUp();

            if (_flag == 0) //Load Dialog thêm//
            {
                btnSave.Visible = true;

                btnUpdate.Visible = false;

                SQD();
            }
            else //Load Dialog cập nhật//
            {
                btnSave.Visible = false;

                btnUpdate.Visible = true;

                GetFile();

                InitUpdate();
                //---//

            }
        }

        public void SQD()
        {
            var _soQuyetDinh = _db.tbDieuChuyen_v1s.OrderByDescending(p => p.SoQD).FirstOrDefault();

            int _soQuyetDinh_Last = 0;

            if (_soQuyetDinh != null)
            {
                _soQuyetDinh_Last = int.Parse(_soQuyetDinh.SoQD.Substring(6, 4).ToString().Trim()) + 1;
            }
            else
                _soQuyetDinh_Last = _soQuyetDinh_Last + 1;

            txtSoQD.Text = String.Format("DCNV{0:00}{1:0000}", DateTime.Now.ToString("yy"), _soQuyetDinh_Last);
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
            if(btnFile.Text == "" && _idFile != "")
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
            var _table_Nv = _db.tblEmployees;

            var _table_Dep = _db.tblRef_Departments;

            lkNV.Properties.DataSource = _table_Nv;

            lkBoPhanChuyen.Properties.DataSource = _table_Dep;
        }

        public void InitUpdate()
        {
            //Đổ dữ liệu vào Edit Control//

            var _EmployeeID = DbHelper.DrGet(_CRow, "EmployeeID") != null ? DbHelper.DrGet(_CRow, "EmployeeID") : "";

            var _NgayHieuLuc = DbHelper.DrGet(_CRow, "NgayHieuLuc") != null ? DbHelper.DrGet(_CRow, "NgayHieuLuc") : "";

            var _DepId_Moi = DbHelper.DrGet(_CRow, "DepId_Moi") != null ? DbHelper.DrGet(_CRow, "DepId_Moi") : "";

            var _SoQD = DbHelper.DrGet(_CRow, "SoQD") != null ? DbHelper.DrGet(_CRow, "SoQD") : "";

            var _ghiChu = DbHelper.DrGet(_CRow, "ghiChu") != null ? DbHelper.DrGet(_CRow, "ghiChu") : "";

            var _lyDo = DbHelper.DrGet(_CRow, "lyDo") != null ? DbHelper.DrGet(_CRow, "lyDo") : "";

            txtSoQD.Text = _SoQD as String;

            lkNV.EditValue = _EmployeeID as String;

            lkBoPhanChuyen.EditValue = _DepId_Moi as String;

            txtGhiChu.Text = _ghiChu as String;

            txtLyDo.Text = _lyDo as String;

            dateNgayHieuLuc.DateTime = DateTime.Parse(_NgayHieuLuc.ToString()).Date;

            //---//
        }

        public bool CheckNull(DevExpress.XtraEditors.BaseEdit _control)
        {
            if (_control.EditValue == null || String.IsNullOrEmpty(_control.ToString())) return true;

            return false;
        }

        public bool Check()
        {
            if (CheckNull(lkNV))
            {
                GUIHelper.MessageBox("Vui lòng chọn nhân viên chuyển!");

                return true;
            }

            if (CheckNull(lkBoPhanChuyen))
            {
                GUIHelper.MessageBox("Vui lòng chọn bộ phận chuyển!");

                return true;
            }

            if (CheckNull(dateNgayHieuLuc))
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày!");

                return true;
            }

            return false;
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

            tbDieuChuyen_v1 _tbDC = new tbDieuChuyen_v1();

            var _depId = _db.tblEmployees.Where(x => x.EmployeeID == lkNV.EditValue.ToString()).SingleOrDefault();

            _tbDC.EmployeeID = lkNV.EditValue as String;

            _tbDC.NgayHieuLuc = dateNgayHieuLuc.DateTime;

            _tbDC.DepId_Cu = _depId.DepID_Final;

            _tbDC.DepId_Moi = lkBoPhanChuyen.EditValue as String;

            _tbDC.SoQD = txtSoQD.Text as String;

            _tbDC.ghiChu = txtGhiChu.Text as String;

            _tbDC.lyDo = txtLyDo.Text as String;

            _tbDC.isTransfer = 0;

            _tbDC.DateRequest = DateTime.Now;

            _tbDC.idUserRequest = LoginHelper.user.id;

            var check = _db.tbDieuChuyen_v1s.Where(x => x.SoQD == txtSoQD.Text || (x.EmployeeID == lkNV.EditValue && x.NgayHieuLuc == dateNgayHieuLuc.DateTime)).SingleOrDefault();

            var _nv = _db.tblEmployees.Where(x => x.EmployeeID == lkNV.EditValue).SingleOrDefault();

            if (check != null)
            {
                GUIHelper.MessageBox("Số quyết định đã tồn tại. Không thể thêm mới!");

                return;
            }

            //Thêm đăng ký điều chuyển nhân viên//

            mainBase.Dowork_Item _dw_it = new mainBase.Dowork_Item();

            int success = 0;

            _dw_it.OnDoing = (s, ev) =>
            {
                try
                {
                    _dw_it.bw.ReportProgress(1, "Đang đăng ký...");

                    _dw_it.bw.ReportProgress(0, 1);

                    //Thêm File//

                    Guid _idFile = _tbDC.idFile != null ? _tbDC.idFile.Value : Guid.NewGuid();

                    if (_isChoiseFile)
                    {
                        _tbDC.idFile = _idFile;
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

                    _listActionClass.Add(new ActionClass("Thêm dữ liệu " + "điều chuyển theo số quyết định " + _tbDC.SoQD.ToString()
                                , _tbDC.EmployeeID 
                                , ""
                                , "Thêm điều chuyển nhân viên ngày: " + DateTime.Now.Date
                                , "tbDieuChuyen_v1")); //Lưu lịch sử

                    LogAction.LogAction.PushLog(_listActionClass);

                    _db.tbDieuChuyen_v1s.InsertOnSubmit(_tbDC);

                    _db.SubmitChanges();

                    success++;

                    _dw_it.bw.ReportProgress(2, "Thêm thành công đăng ký chuyển bộ phận nhân viên: " + _nv.EmployeeName + " - " + _tbDC.SoQD + '\r' + '\n');
                }
                catch (Exception)
                {
                    _dw_it.bw.ReportProgress(2, "Đăng ký chuyển bộ phận lỗi nhân viên " + _nv.EmployeeName);
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
                    ucProgress1.Status = "Đăng ký chuyển bộ phận thành công " + success + " records";
                }
                else
                {
                    ucProgress1.Status = "Không có nhân viên nào được đăng ký";
                }

                btnSave.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(_dw_it);

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

            this.Close();

            //---//
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Check()) return;

            _listActionClass.Clear();

            //Xử lý file//

            if ((btnFile.Text == "" || String.IsNullOrWhiteSpace(btnFile.Text)) && _flagFile != 0)
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

            tbDieuChuyen_v1 _tbDC = new tbDieuChuyen_v1();

            var _depId = _db.tblEmployees.Where(x => x.EmployeeID == lkNV.EditValue.ToString()).SingleOrDefault();

            _tbDC = _db.tbDieuChuyen_v1s.Where(x => x.SoQD == txtSoQD.Text).SingleOrDefault();

            _tbDC.EmployeeID = lkNV.EditValue as String;

            _tbDC.NgayHieuLuc = dateNgayHieuLuc.DateTime;

            _tbDC.DepId_Cu = _depId.DepID_Final;

            _tbDC.DepId_Moi = lkBoPhanChuyen.EditValue as String;

            _tbDC.SoQD = txtSoQD.Text as String;

            _tbDC.ghiChu = txtGhiChu.Text as String;

            _tbDC.lyDo = txtLyDo.Text as String;

            if (Delete_File() == true)
            {
                _tbDC.idFile = null;
            }

            var _nv = _db.tblEmployees.Where(x => x.EmployeeID == lkNV.EditValue).SingleOrDefault();

            //Cập nhật đăng ký điều chuyển nhân viên//

            mainBase.Dowork_Item _dw_it = new mainBase.Dowork_Item();

            int success = 0;

            _dw_it.OnDoing = (s, ev) =>
            {
                try
                {
                    _dw_it.bw.ReportProgress(1, "Đang đăng ký...");

                    _dw_it.bw.ReportProgress(0, 1);

                    //Cập nhật file//

                    Guid _idFile = _tbDC.idFile != null ? _tbDC.idFile.Value : Guid.NewGuid();

                    if (_isChoiseFile)
                    {
                        _tbDC.idFile = _idFile;
                    }

                    #region Add file to other database
                    if (_isChoiseFile) // Nếu chọn file đính kèm
                    {

                        if (_tbDC.idFile != null)
                        {
                            var _f1 = _dbFiles.tbFiles.Where(p => p.id == _tbDC.idFile.Value).FirstOrDefault();

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

                                _newFile.tenFile = _FilesChoised;

                                _newFile.duoiFile = _duoiFile;

                                _dbFiles.tbFiles.InsertOnSubmit(_newFile);
                            }
                        }
                        else
                        {
                            tbFile _newFile = new tbFile();

                            _newFile.id = _idFile;

                            _newFile.dataFile = _datafileChoised;

                            _newFile.tenFile = _FilesChoised;

                            _newFile.duoiFile = _duoiFile;

                            _dbFiles.tbFiles.InsertOnSubmit(_newFile);
                        }

                        _dbFiles.SubmitChanges();
                    }
                    #endregion

                    //---//

                    _listActionClass.Add(new ActionClass("Cập nhật dữ liệu " + "điều chuyển theo số quyết định " + _tbDC.SoQD.ToString()
                                , _tbDC.EmployeeID 
                                , ""
                                , "Cập nhật điều chuyển nhân viên ngày: " + DateTime.Now.Date
                                , "tbDieuChuyen_v1"));//Lưu lịch sử

                    LogAction.LogAction.PushLog(_listActionClass);

                    _db.SubmitChanges();

                    success++;

                    _dw_it.bw.ReportProgress(2, "Cập nhật thành công đăng ký chuyển bộ phận nhân viên: " + _nv.EmployeeName + " - " + _tbDC.SoQD + '\r' + '\n');
                }
                catch (Exception)
                {
                    _dw_it.bw.ReportProgress(2, "Cập nhật chuyển bộ phận lỗi nhân viên: " + _nv.EmployeeName + " - " + _tbDC.SoQD + '\r' + '\n');
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
                    ucProgress1.Status = "Cập nhật thông tin chuyển bộ phận thành công " + success + " records";
                }
                else
                {
                    ucProgress1.Status = "Không có nhân viên nào được đăng ký";
                }
            };

            main.Instance.DoworkItem_Reg(_dw_it);

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);

            this.Close();

            //---//
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

        private void lkNV_EditValueChanged(object sender, EventArgs e)
        {
            tblEmployee _emp = new tblEmployee();

            if(lkNV.EditValue != null || lkNV.EditValue.ToString() == "")
            {
                _emp = _db.tblEmployees.Where(x => x.EmployeeID == lkNV.EditValue.ToString()).SingleOrDefault();
            }
            
            if(_emp != null)
            {
                txtBoPhan.Text = _emp.DepName;

                txtChucVu.Text = _emp.PosName;

                if (_emp.Birthday != null)

                    dateNgaySinh.DateTime = DateTime.Parse(_emp.Birthday.ToString());
            }
        }

        private void ucProgress1_Load(object sender, EventArgs e)
        {

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

        private void dlgDieuChuyenNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgDieuChuyenNV_Load(null, null);
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
            var _LableControl = EnumerateLabelControl();
            var _SimpleButton = EnumerateSimpleButton();
            var _LayoutItem = EnumerateLayoutItem();
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