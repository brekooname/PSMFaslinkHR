using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Frm.XtraReportTemplate;
using iHRM.Common.Code;
using DevExpress.XtraGrid;
using System.Reflection;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmDanhGiaNhanSu_v2 : frmBase
    {
        //Khai báo biến//
        private int _thuViec = 1;

        public String thuViec { get { return _thuViec.ToString(); } set { _thuViec = int.Parse(value); } }

        LogicBase _logic = new LogicBase();

        DataTable _dt = new DataTable();

        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        DataRow _CRow;

        DataTable _dtData = new DataTable();
        //---//

        public frmDanhGiaNhanSu_v2()
        {
            InitializeComponent();
        }

        private void InitLookUp(int _thuViec)
        {
            if (_thuViec == 1) //HĐ thử việc
            {
                lkLoaiHD.Properties.DataSource = _db.tblRef_ContractTypes.Where(i => i.isTrail == true).ToList();

                lkLoaiHD.EditValue = "1";
            }
            else

                lkLoaiHD.Properties.DataSource = _db.tblRef_ContractTypes.Where(i => i.isTrail == false).ToList();
        }

        private void frmDanhGiaNhanSu_v2_Load(object sender, EventArgs e)
        {
            TranslateForm();

            btnSearch_Click(null, null);

            InitLookUp(_thuViec);

            repItemQLDuyet.DataSource = _db.w5sysUsers;

            if (LoginHelper.user.isAcceptBP == true || LoginHelper.user.isAdmin)
            {
                toolStripAccept.Visible = true;
                toolStripNotAccept.Visible = true;
            }
            else
            {
                toolStripAccept.Visible = false;
                toolStripNotAccept.Visible = false;
            }

            _listActionClass.Clear();
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        #region: Gridview Control
        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "isAccept") != null
                && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAccept").ToString()))
            {

                if (grv.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "True")
                {
                    e.Appearance.ForeColor = Color.Green;
                }

                else if (grv.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "False")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void grv_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column == colXemFile && grv.GetFocusedDataRow() != null)
            {
                FileStorageHelper _fh = new FileStorageHelper();

                var _a = grv.GetFocusedRowCellValue(colDataFile);

                var _duoiFile = grv.GetFocusedRowCellValue(colduoiFile).ToString();

                if (_a != null && _a.ToString() != "")
                {
                    Binary dataFile = new Binary(_a as byte[]);

                    _fh.DownLoadAndShowFILE(_a as byte[], _duoiFile);
                }
                else
                {
                    GUIHelper.Notifications("Không tìm thấy file.", "Xem file", GUIHelper.NotifiType.error);
                }
            }
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            _CRow = grv.GetFocusedDataRow();
        }
        #endregion

        #region: Button Click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item _dw_it = new mainBase.Dowork_Item();

            String _table_name = "p_GetDanhGiaNhanSu_byWhere_v1";

            _dw_it.Caption = "Đang tải dữ liệu nhân viên...";

            _dw_it.OnDoing = (s, ev) =>
            {
                _logic.VirtualPaging.PageSize = pageNavigator1.PageSize;

                _logic.VirtualPaging.Page = pageNavigator1.CurrentPage;

                SqlParameter[] _par = { new SqlParameter("@SearchKey", txtSearch.Text),

                                        new SqlParameter("@tuNgay", chonKyLuong1.TuNgay),

                                        new SqlParameter("@denNgay", chonKyLuong1.DenNgay_End),

                                        new SqlParameter("@idPB", chonPhongBan.SelectedValue),

                                        new SqlParameter("@LoaiHD", lkLoaiHD.EditValue),
                                        };

                _dt = _logic.GetAllDep(_table_name, _par);

                _dw_it.bw.ReportProgress(1, _dt);

                _dw_it.bw.ReportProgress(2, _logic.VirtualPaging.RecordCount);
            };

            _dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState; btnSearch.Enabled = true;
                }
                else if (data.ProgressPercentage == 2)
                {
                    pageNavigator1.RecordCount = (int)data.UserState;
                }
            };

            _listActionClass.Clear();

            main.Instance.DoworkItem_Reg(_dw_it);
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            _CRow = grv.GetFocusedDataRow();

            if (_CRow != null) //Kiểm tra Focused có dữ liệu
            {
                if (grv.FocusedRowHandle != -1)
                {

                    if (_CRow["soDanhGia"] != DBNull.Value)
                    {
                        dlgDanhGiaNhanSu_v2 _dlg = new dlgDanhGiaNhanSu_v2();

                        _dlg._CRow = _CRow;

                        _dlg._flag = 1; //Cập nhật

                        _dlg._thuViec = _thuViec; //Xét trường hợp load form

                        _dlg._idNV = _CRow["EmployeeID"] as String;

                        _dlg.iRule = LoginHelper.user.isAdmin || BitHelper.Has(iRule.customRules ?? 0, 32);

                        _dlg.ShowDialog();
                    }
                    else
                    {
                        dlgDanhGiaNhanSu_v2 _dlg = new dlgDanhGiaNhanSu_v2();

                        _dlg._CRow = _CRow;

                        _dlg._flag = 0; //Thêm đánh giá

                        _dlg._thuViec = _thuViec; //Xét trường hợp load form

                        _dlg._idNV = _CRow["EmployeeID"] as String;

                        _dlg.ShowDialog();
                    }

                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));

            List<string> _lEmpID = new List<string>();

            _lEmpID = getEmpID();

            if (_lEmpID.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }

            var a = Provider.ExecuteDataTableReader("p_export_DanhGiaNhanVien_byEmp_1"
                                                        , Provider.CreateParameter_StringList("dtEmpID", _lEmpID)
                                                        , new SqlParameter("ContractTypeID", lkLoaiHD.EditValue.ToString()));

            var rp = new rep_DanhGiaNV(1);//In nếu không có thông tin phiếu đánh giá

            rp.DataBindings(a);

            ReportViewer rv = new ReportViewer();

            rv.ViewReport(rp);

            //foreach (var item in drs)
            //{
            //    if (item["id"].ToString() != "")
            //    {
            //        var a = Provider.ExecuteDataTableReader("p_export_DanhGiaNhanVien"
            //                                            , new System.Data.SqlClient.SqlParameter("idDG", item["id"].ToString())
            //                                            , new System.Data.SqlClient.SqlParameter("ContractTypeID", lkLoaiHD.EditValue.ToString()));

            //        var rp = new rep_DanhGiaNV(0); //In nếu có thông tin phiếu đánh giá

            //        rp.DataBindings(a);

            //        ReportViewer rv = new ReportViewer();

            //        rv.ViewReport(rp);
            //    }
            //    else
            //    {
            //        var a = Provider.ExecuteDataTableReader("p_export_DanhGiaNhanVien_byEmp"
            //                                            , new System.Data.SqlClient.SqlParameter("empID", item["EmployeeID"].ToString())
            //                                            , new System.Data.SqlClient.SqlParameter("ContractTypeID", lkLoaiHD.EditValue.ToString()));

            //        var rp = new rep_DanhGiaNV(1);//In nếu không có thông tin phiếu đánh giá

            //        rp.DataBindings(a);

            //        ReportViewer rv = new ReportViewer();

            //        rv.ViewReport(rp);
            //    }
            //}
        }
        #endregion

        #region: Xử lý duyệt
        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            if (_dt.GetChanges() == null || (_dt.GetChanges() != null && _dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }

            var count = _dt.GetChanges().Rows.Count;

            try
            {
                foreach (DataRow _dr in _dt.GetChanges().Rows)
                {
                    if (_dr["isAccept"].ToString() != "")
                    {
                        int _id = (int)_dr["id"];

                        String _empID = (String)_dr["idNV"];

                        String a = _dr["isAccept"].ToString();

                        bool _isAccept = (bool)_dr["isAccept"];

                        Guid _idFile = new Guid();

                        int _isKyHopDong = (int)_dr["isKyHopDong"];

                        if (_isKyHopDong != 2)
                        {
                            try
                            {
                                _idFile = Guid.Parse(_dr["idFile"].ToString());

                                var _file = _db.tblEmpFilesLienQuans.Where(p => p.idFile == _idFile).FirstOrDefault();

                                if (_file == null)
                                {
                                    tblEmpFilesLienQuan _empFile = new tblEmpFilesLienQuan();

                                    _empFile.ghiChu = "PM chuyển từ đánh giá nhân viên.";

                                    _empFile.EmployeeID = _empID;

                                    _empFile.idFile = _idFile;

                                    _db.tblEmpFilesLienQuans.InsertOnSubmit(_empFile);
                                }
                            }
                            catch { }
                        }
                        #region: Thong bỏ tự động ký HĐ tiếp theo :'209-09-25'
                        //if (_isAccept == true)
                        //{
                        //    var _emp = _db.tblEmployees.Where(p => p.EmployeeID == _empID).FirstOrDefault();
                        //    if (_thuViec == 1) //HĐ thử việc
                        //    {
                        //        var _typeContract = _db.tblEmpContracts.Where(p => p.EmployeeID == _empID
                        //                                && p.ContractTypeID == _emp.ContractTypeID).OrderByDescending(p => p.BeginDate).FirstOrDefault();

                        //        switch (_isKyHopDong)
                        //        {
                        //            case 0: //Không ký HĐ
                        //                _emp.LeftDate = DateTime.Parse(_typeContract.EndDate.ToString()).AddDays(1);

                        //                _emp.LeftTypeID = "Ex";

                        //                var _leftType = _db.tblRef_LeftTypes.Where(p => p.LeftTypeID == "Ex").SingleOrDefault();

                        //                if (_leftType.LeftTypeID.ToString() != null)

                        //                    _emp.LeftTypeName = _leftType.LeftTypeName;

                        //                _listActionClass.Add(new ActionClass("Lưu tự động ký HĐ"
                        //                            , _empID
                        //                            , ""
                        //                            , "Không ký hợp đồng nhân viên thử việc - Ngày kết thúc: " + String.Format("{0: dd/MM/yyyy}", _emp.LeftDate)
                        //                            , "tbDanhGiaNhanSu"));
                        //                break;

                        //            case 1:
                        //                DateTime _ngayBD = (DateTime)_dr["ngayKyHD"];

                        //                //update lại thông tin hợp đồng 1 năm trong bảng Employee
                        //                tblEmpContract _empCT = new tblEmpContract();

                        //                _empCT.id = Guid.NewGuid();

                        //                _empCT.EmployeeID = _empID;

                        //                _empCT.BeginDate = _ngayBD;

                        //                _empCT.EndDate = new DateTime(_empCT.BeginDate.Year + 1, _empCT.BeginDate.Month, _empCT.BeginDate.Day).AddDays(-1);

                        //                _empCT.ContractTypeID = "7";

                        //                _empCT.Notes = "PM tự động nhập từ đánh giá nhân viên";

                        //                int year = _empCT.BeginDate.Year;

                        //                var ec = _db.tblEmpContracts.Where(p => p.BeginDate.Year == year).OrderByDescending(p => p.idx).FirstOrDefault();

                        //                var idx_Next = ec == null ? 1 : ec.idx + 1;

                        //                //273/HĐLĐ-2017 ContractID
                        //                _empCT.idx = idx_Next;

                        //                _empCT.ContractID = string.Format("{0}-{1:00}{2:0000}-HĐLĐ", _empID, _ngayBD.Month.ToString("00"), _ngayBD.Year.ToString());

                        //                _db.tblEmpContracts.InsertOnSubmit(_empCT);

                        //                //update lại thông tin ContractDate trong bảng nhân viên
                        //                var _ContractTypeName = _db.tblRef_ContractTypes.Where(p => p.ContractTypeID == _empCT.ContractTypeID).SingleOrDefault().ContractTypeName;

                        //                if (_emp.ContractDate == null)
                        //                {
                        //                    _emp.ContractDate = _ngayBD;
                        //                }

                        //                _emp.ContractID = _empCT.ContractID;

                        //                _emp.ContractTypeID = "7";

                        //                _emp.ContractTypeName = _ContractTypeName;

                        //                _emp.BasicSalary = 0;

                        //                //cập nhập thông tin lương cơ bản
                        //                tblEmpSalary _luongcoban = new tblEmpSalary();

                        //                _luongcoban.id = Guid.NewGuid();

                        //                _luongcoban.EmployeeID = _empID;

                        //                _luongcoban.DateChange = _ngayBD;

                        //                _luongcoban.BasicSalary = 0;

                        //                _luongcoban.BasicSalary_Ins = 0;

                        //                _luongcoban.status = 0;

                        //                _luongcoban.ContractCode = _emp.ContractID;

                        //                _luongcoban.Notes = "PM tự động nhập từ đánh giá nhân viên";

                        //                _db.tblEmpSalaries.InsertOnSubmit(_luongcoban);

                        //                _listActionClass.Add(new ActionClass("Lưu tự động ký HĐ"
                        //                            , _empID
                        //                            , ""
                        //                            , "Ký hợp đồng nhân viên thử việc - Ngày ký: " + String.Format("{0: dd/MM/yyyy}", _ngayBD)
                        //                            , "tbDanhGiaNhanSu"));

                        //                break;

                        //            case 2: //Gia hạn thời gian thêm 1 tháng. 
                        //                DateTime _endDate = new DateTime();

                        //                _endDate = (DateTime)_typeContract.EndDate;

                        //                //update lại thông tin hợp đồng 1 năm trong bảng Employee
                        //                tblEmpContract _empCTGH = new tblEmpContract();

                        //                _empCTGH.id = Guid.NewGuid();

                        //                _empCTGH.EmployeeID = _empID;

                        //                _empCTGH.BeginDate = _endDate.AddDays(1);

                        //                _empCTGH.EndDate = _empCTGH.BeginDate.AddMonths(1).AddDays(-1);

                        //                _empCTGH.ContractTypeID = "1";

                        //                _empCTGH.Notes = "- Gia hạn HĐ thêm 1 tháng.";

                        //                int yearGH = _empCTGH.BeginDate.Year;

                        //                var ecGH = _db.tblEmpContracts.Where(p => p.BeginDate.Year == yearGH).OrderByDescending(p => p.idx).FirstOrDefault();

                        //                var idx_NextGH = ecGH == null ? 1 : ecGH.idx + 1;

                        //                //273/HĐLĐ-2017 ContractID
                        //                _empCTGH.idx = idx_NextGH;

                        //                _empCTGH.ContractID = string.Format("{0}-{1:00}{2:0000}-HĐLĐ", _empID, _empCTGH.BeginDate.Month.ToString("00"), _endDate.Year.ToString());

                        //                _db.tblEmpContracts.InsertOnSubmit(_empCTGH);

                        //                //update lại thông tin ContractDate trong bảng nhân viên
                        //                //_emp.ContractID = _empCTGH.ContractID;

                        //                _emp.ContractTypeID = "1";

                        //                _emp.BasicSalary = 0;

                        //                //cập nhập thông tin lương cơ bản
                        //                tblEmpSalary _luongcobanGH = new tblEmpSalary();

                        //                _luongcobanGH.id = Guid.NewGuid();

                        //                _luongcobanGH.EmployeeID = _empID;

                        //                _luongcobanGH.DateChange = _endDate;

                        //                _luongcobanGH.BasicSalary = 0;

                        //                _luongcobanGH.BasicSalary_Ins = 0;

                        //                _luongcobanGH.status = 0;

                        //                _luongcobanGH.ContractCode = _empCTGH.ContractID;

                        //                _luongcobanGH.Notes = "PM tự động nhập từ đánh giá nhân viên";

                        //                _db.tblEmpSalaries.InsertOnSubmit(_luongcobanGH);

                        //                _listActionClass.Add(new ActionClass("Lưu tự động ký HĐ"
                        //                            , _empID
                        //                            , ""
                        //                            , "Gia hạn thời gian thử việc - Ngày kết thúc: " + String.Format("{0: dd/MM/yyyy}", _endDate.AddMonths(1).AddDays(-1))
                        //                            , "tbDanhGiaNhanSu"));
                        //                break;
                        //        }


                        //    }
                        //    else //HĐ bình thường
                        //    {
                        //        var _typeContract = _db.tblEmpContracts.Where(p => p.EmployeeID == _empID
                        //                                            && p.ContractTypeID == _emp.ContractTypeID
                        //                                            && p.ContractID == _emp.ContractID).SingleOrDefault();

                        //        switch (_isKyHopDong)
                        //        {
                        //            case 0: //Không ký HĐ
                        //                _emp.LeftDate = DateTime.Parse(_typeContract.EndDate.ToString()).AddDays(1);

                        //                _emp.LeftTypeID = "Ex";

                        //                var _leftType = _db.tblRef_LeftTypes.Where(p => p.LeftTypeID == "Ex").SingleOrDefault();

                        //                if (_leftType.LeftTypeID.ToString() != null)

                        //                    _emp.LeftTypeName = _leftType.LeftTypeName;

                        //                _listActionClass.Add(new ActionClass("Lưu tự động ký HĐ"
                        //                            , _empID
                        //                            , ""
                        //                            , "Không ký hợp đồng nhân viên - Ngày kết thúc: " + String.Format("{0: dd/MM/yyyy}", _emp.LeftDate)
                        //                            , "tbDanhGiaNhanSu"));
                        //                break;

                        //            case 1:
                        //                DateTime _ngayBD = (DateTime)_dr["ngayKyHD"];

                        //                //update lại thông tin hợp đồng trong bảng Employee
                        //                tblEmpContract _empCT = new tblEmpContract();

                        //                _empCT.id = Guid.NewGuid();

                        //                _empCT.EmployeeID = _empID;

                        //                _empCT.BeginDate = _ngayBD;

                        //                _empCT.EndDate = new DateTime(_empCT.BeginDate.Year + 1, _empCT.BeginDate.Month, _empCT.BeginDate.Day).AddDays(-1);

                        //                switch (_emp.ContractTypeID)
                        //                {
                        //                    case "7": //Ký tiếp HĐ 3 năm.

                        //                        _empCT.ContractTypeID = "9";

                        //                        break;

                        //                    case "9": //Ký tiếp HĐ không thời hạn.

                        //                        _empCT.ContractTypeID = "10";

                        //                        break;
                        //                }

                        //                _empCT.Notes = "PM tự động nhập từ đánh giá nhân viên";

                        //                int year = _empCT.BeginDate.Year;

                        //                var ec = _db.tblEmpContracts.Where(p => p.BeginDate.Year == year).OrderByDescending(p => p.idx).FirstOrDefault();

                        //                var idx_Next = ec == null ? 1 : ec.idx + 1;

                        //                //273/HĐLĐ-2017 ContractID
                        //                _empCT.idx = idx_Next;

                        //                _empCT.ContractID = string.Format("{0}-{1:00}{2:0000}-HĐLĐ", _empID, _ngayBD.Month.ToString("00"), _ngayBD.Year.ToString());

                        //                _db.tblEmpContracts.InsertOnSubmit(_empCT);

                        //                //update lại thông tin ContractDate trong bảng nhân viên
                        //                var _ContractTypeName = _db.tblRef_ContractTypes.Where(p => p.ContractTypeID == _empCT.ContractTypeID).SingleOrDefault().ContractTypeName;

                        //                if (_emp.ContractDate == null)
                        //                {
                        //                    _emp.ContractDate = _ngayBD;
                        //                }

                        //                _emp.ContractID = _empCT.ContractID;

                        //                _emp.ContractTypeID = _empCT.ContractTypeID;

                        //                _emp.ContractTypeName = _ContractTypeName;

                        //                _emp.BasicSalary = 0;

                        //                //cập nhập thông tin lương cơ bản
                        //                tblEmpSalary _luongcoban;

                        //                _luongcoban = new tblEmpSalary();

                        //                _luongcoban.id = Guid.NewGuid();

                        //                _luongcoban.EmployeeID = _empID;

                        //                _luongcoban.DateChange = _ngayBD;

                        //                _luongcoban.BasicSalary = 0;

                        //                _luongcoban.BasicSalary_Ins = 0;

                        //                _luongcoban.status = 0;

                        //                _luongcoban.ContractCode = _empCT.ContractID;

                        //                _luongcoban.Notes = "PM tự động nhập từ đánh giá nhân viên";

                        //                _db.tblEmpSalaries.InsertOnSubmit(_luongcoban);

                        //                _listActionClass.Add(new ActionClass("Lưu tự động ký HĐ"
                        //                            , _empID
                        //                            , ""
                        //                            , "Ký hợp đồng nhân viên - Ngày ký: " + String.Format("{0: dd/MM/yyyy}", _ngayBD)
                        //                            , "tbDanhGiaNhanSu"));
                        //                break;
                        //        }


                        //    }

                        //    _db.SubmitChanges();
                        //}
                        //else
                        //{
                        //    //var _emp = _db.tblEmployees.Where(p => p.EmployeeID == _empID).FirstOrDefault();

                        //    //if(_thuViec == 1) //Thử việc
                        //    //{
                        //    //    var _typeContract = _db.tblEmpContracts.Where(p => p.EmployeeID == _empID
                        //    //                            && p.ContractTypeID == _emp.ContractTypeID).OrderByDescending(p => p.BeginDate).FirstOrDefault();

                        //    //    _emp.LeftDate = DateTime.Parse(_typeContract.EndDate.ToString()).AddDays(1);

                        //    //    _emp.LeftTypeID = "Ex";

                        //    //    var _leftType = _db.tblRef_LeftTypes.Where(p => p.LeftTypeID == "Ex").SingleOrDefault();

                        //    //    if (_leftType.LeftTypeID.ToString() != null)

                        //    //        _emp.LeftTypeName = _leftType.LeftTypeName;

                        //    //    _listActionClass.Add(new ActionClass("Lưu tự động ký HĐ"
                        //    //                , _empID
                        //    //                , ""
                        //    //                , "Không ký hợp đồng nhân viên thử việc - Ngày kết thúc: " + String.Format("{0: dd/MM/yyyy}", _emp.LeftDate)
                        //    //                , "tbDanhGiaNhanSu"));
                        //    //}
                        //    //else
                        //    //{
                        //    //    var _typeContract = _db.tblEmpContracts.Where(p => p.EmployeeID == _empID
                        //    //                                && p.ContractTypeID == _emp.ContractTypeID
                        //    //                                && p.ContractID == _emp.ContractID).SingleOrDefault();

                        //    //    _emp.LeftDate = DateTime.Parse(_typeContract.EndDate.ToString()).AddDays(1);

                        //    //    _emp.LeftTypeID = "Ex";

                        //    //    var _leftType = _db.tblRef_LeftTypes.Where(p => p.LeftTypeID == "Ex").SingleOrDefault();

                        //    //    if (_leftType.LeftTypeID.ToString() != null)

                        //    //        _emp.LeftTypeName = _leftType.LeftTypeName;

                        //    //    _listActionClass.Add(new ActionClass("Lưu tự động ký HĐ"
                        //    //                , _empID
                        //    //                , ""
                        //    //                , "Không ký hợp đồng nhân viên thử việc - Ngày kết thúc: " + String.Format("{0: dd/MM/yyyy}", _emp.LeftDate)
                        //    //                , "tbDanhGiaNhanSu"));
                        //    //}
                        //}
                        #endregion
                    }
                }
                _db.SubmitChanges();
                Provider.UpdateData(_dt, "tbDanhGiaNhanSu");

                LogAction.LogAction.PushLog(_listActionClass);

                _listActionClass.Clear();

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception ex)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu đang chọn?"
                                    , "Duyệt tất cả các yêu cầu đang chọn"
                                    , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        if (r["userAccept"] != DBNull.Value)
                        {
                            if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                            {
                                continue;
                            }
                        }

                        if (LoginHelper.user.idKhoiPB != null &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }

                        //if (r["isAccept"] != DBNull.Value)
                        //{
                        //    continue;
                        //}

                        if (r["isKyHopDong"] == DBNull.Value)
                        {
                            GUIHelper.MessageBox("Nhân viên \'" + r["EmployeeName"].ToString() + "\' chưa chốt đánh giá." + "\r\n" + " Vui lòng chọn quyết định cuối cùng để duyệt!");

                            continue;
                        }
                        else
                        {
                            int _isKyHopDong = (int)r["isKyHopDong"];

                            if (_isKyHopDong != 2)

                                if (r["idFile"] == DBNull.Value)
                                {
                                    GUIHelper.MessageBox("Vui lòng nhập file đính kèm!");

                                    continue;
                                }
                        }

                        r["isAccept"] = 1;

                        r["userAccept"] = LoginHelper.user.id;

                        _listActionClass.Add(new ActionClass("Duyệt đánh giá nhân viên"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Duyệt đánh giá nhân viên  SDG: " + r["soDanhGia"].ToString()
                                                            , "tbDanhGiaNhanSu"));
                    }
                }
            }
        }

        private void toolStripNotAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu đang chọn?"
                                    , "Không duyệt tất cả các yêu cầu đang chọn"
                                    , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        if (r["userAccept"] != DBNull.Value)
                        {
                            if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                            {
                                continue;
                            }
                        }

                        if (LoginHelper.user.idKhoiPB != null &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }


                        //if (r["isAccept"] != DBNull.Value)
                        //{
                        //    continue;
                        //}

                        if (r["isKyHopDong"] == DBNull.Value)
                        {
                            GUIHelper.MessageBox("Nhân viên \'" + r["EmployeeName"].ToString() + "\' chưa chốt đánh giá." + "\r\n" + " Vui lòng chọn quyết định cuối cùng để duyệt!");

                            continue;
                        }
                        else
                        {
                            int _isKyHopDong = (int)r["isKyHopDong"];

                            if (_isKyHopDong != 2)

                                if (r["idFile"] == DBNull.Value)
                                {
                                    GUIHelper.MessageBox("Vui lòng nhập file đính kèm!");

                                    continue;
                                }
                        }

                        r["isAccept"] = 0;

                        r["userAccept"] = LoginHelper.user.id;

                        _listActionClass.Add(new ActionClass("Không duyệt đánh giá nhân viên"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Không duyệt đánh giá nhân viên  SDG: " + r["soDanhGia"].ToString()
                                                            , "tbDanhGiaNhanSu"));
                    }
                }
            }
        }
        #endregion
        private List<String> getEmpID()
        {
            List<String> _lEmpID = new List<String>();

            List<DataRow> _list_dr = grv.GetSelectedRows().Select(x => grv.GetDataRow(x) as DataRow).ToList();

            foreach (DataRow _dr in _list_dr)
            {
                _lEmpID.Add(_dr["EmployeeID"].ToString());
            }

            return _lEmpID;
        }

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grd.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void frmDanhGiaNhanSu_v2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmDanhGiaNhanSu_v2_Load(null, null);
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