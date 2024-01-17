using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using iHRM.Win.DungChung;
using iHRM.Win.ExtClass.Contract;
using iHRM.Win.Frm.XtraReport_Template;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Employee
{
    public partial class InTheNhanVien : frmBase
    {
        private dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        private DataTable Data = new DataTable();

        private string actionPrint = "";

        public InTheNhanVien(string strPrint)
        {
            actionPrint = strPrint;
            InitializeComponent();
            pnBienBanCC.Visible = false;
            rdSite.Visible = false;

            if (strPrint == "the")
            {
                ;
                this.Text = "In thẻ nhân viên";
                btnInThe.Text = "In thẻ";
            }
            if (strPrint == "hoso")
            {
                this.Text = "In hồ sơ nhân viên";
                btnInThe.Text = "In hồ sơ";
            }
            if (strPrint == "thucanhcao")
            {
                ngayViPham.DateTime = ngayLapBB.DateTime = DateTime.Now;
                pnBienBanCC.Visible = true;
                this.Text = "Thư cảnh cáo";
                btnInThe.Text = "In thư cảnh cáo";
            }
            if (strPrint == "NhatKiThuViec")
            {
                groupInHoSo.Text = "In nhật kí thử việc";
                btnInThe.Text = "In nhật kí";
                this.Text = "In nhật kí thử việc";
            }
            if (strPrint == "quyetdinhthoiviec")
            {
                groupInHoSo.Text = "Quyết định thôi việc";
                btnInThe.Text = "In quyết định";
                this.Text = "Quyết định thôi việc";
            }
            if (strPrint == "camketthue")
            {
                groupInHoSo.Text = "Bản cam kết thuế";
                btnInThe.Text = "In cam kết";
                this.Text = "Bản cam kết thuế";
            }
            if (strPrint == "thuhoi")
            {
                groupInHoSo.Text = "Quyết định thu hồi";
                btnInThe.Text = "In quyết định";
                this.Text = "Quyết định thu hồi";
            }
            if (strPrint == "xacnhancongtac")
            {
                rdSite.Visible = true;
                groupInHoSo.Text = "Xác nhận công tác";
                btnInThe.Text = "In xác nhận";
                this.Text = "Xác nhận công tác";
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            // In thẻ : "the". In hồ sơ "hoso"
            List<string> _lEmpID = new List<string>();
            if (memoMaNV.Text != "")
            {
                _lEmpID = memoMaNV.Text.Split(',').ToList();
            }
            else
                _lEmpID = getEmpID();

            if (actionPrint == "NhatKiThuViec")
            {
                try
                {
                    DataTable dt_tam = Provider.ExecuteDataTableReader("p_In_NhatKiThuViec",
                         Provider.CreateParameter_StringList("dtEmpID", _lEmpID));
                    //DataTable dt1 = new DataTable();
                    var rp = new rep_NhatKyThuViec();
                    rp.DataBindings(dt_tam);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
                catch
                { }
            }

            if (actionPrint == "the")
            {
                var dt_In = from emp in _lEmpID
                            join dt in Data.AsEnumerable() on emp.ToString() equals dt["EmployeeID"].ToString()
                            select new
                            {
                                EmployeeID = dt["EmployeeID"],
                                EmployeeName = dt["EmployeeName"].ToString().ToUpper(),
                                EmpTypeName = dt["EmpTypeName"].ToString(),
                                DepName_Final = dt["DepName_Final"].ToString(),
                                LineName = dt["LineName"].ToString(),
                                AppliedDate = dt["AppliedDate"],
                                PosName = dt["PosName"],
                                IDCard = dt["IDCard"].ToString()
                            };

                var data = Provider.ExecuteDataTable("p_getData_InTheNV",
                                                    Provider.CreateParameter_StringList("dtEmpID", _lEmpID));

                var rp = new iHRM.Win.ExtClass.rep_InTheNhanVien_002();

                rp.DataBindings(data);

                ReportViewer rv = new ReportViewer();

                rv.ViewReport(rp);
            }
            if (actionPrint == "thucanhcao")
            {
                var dt_In = from emp in _lEmpID
                            join dt in Data.AsEnumerable() on emp.ToString() equals dt["EmployeeID"].ToString()
                            select dt;
                var rp = new iHRM.Win.ExtClass.Contract.ThuCanhCao();
                rp.paramNgayViPham.Value = ngayViPham.DateTime.ToString("dd/MM/yyyy");
                rp.paramNgayLapBB.Value = ngayLapBB.DateTime.ToString("dd/MM/yyyy");
                rp.BindingData(dt_In.CopyToDataTable());
                ReportViewer rv = new ReportViewer();
                rv.ViewReport(rp);
            }
            if (actionPrint == "quyetdinhthoiviec")
            {
                DataSet data;

                data = Provider.ExecuteDataSet("p_export_QuyetDinhThoiViec",
                        Provider.CreateParameter_StringList("dtEmpID", _lEmpID));

                #region: Word
                if (data.Tables[0].Rows.Count <= 0)
                {
                    GUIHelper.MessageBox("Không tìm thấy nhân viên.");

                    return;
                }

                WordUltil wd = new WordUltil(Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\SW_HR_QDNV.docx"), true);

                Dictionary<string, string> dic = new Dictionary<string, string>();
                // Xuất các dữ liệu mình chuẩn bị ở Field (ở đây mình lọc lấy dữ liệu ở dạng linq)

                int _sumRow = 0;
                string _columnname = "";

                foreach (DataRow _datarow in data.Tables[0].Rows)
                {

                    foreach (DataColumn _datacolumn in data.Tables[0].Columns)
                    {
                        _columnname = _datacolumn.ColumnName;

                        dic.Add(_columnname, data.Tables[0].Rows[_sumRow][_columnname] as string);
                    }

                    _sumRow++;

                }

                //dic.Add("GiamDoc", data.Tables[0].Rows[0]["GiamDoc"] as string);

                //dic.Add("ngay", data.Tables[0].Rows[0]["ngay"] as string);

                //dic.Add("thang", data.Tables[0].Rows[0]["thang"] as string);

                //dic.Add("nam", data.Tables[0].Rows[0]["nam"] as string);

                wd.WriteFields(dic);

                //THÔNG TIN trách nhiệm trong công việc

                int _sumTable = 0;

                foreach (DataTable _table in data.Tables)
                {
                    _sumTable++;
                    wd.WriteTable_QDTV(data.Tables[_sumTable], _sumTable);
                }



                #endregion

                #region: ExtraReport
                //string strFile = Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\SW_HR_QDNV.docx");

                //var rp = new iHRM.Win.ExtClass.Contract.ThuMoiCanhCao(strFile);

                //rp.bindData(data);

                //ReportViewer rv = new ReportViewer();

                //rv.ViewReport(rp);

                #endregion

                #region: Excel
                //SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save

                //sd.Filter = "Excel 2007|*.xls";

                //if (sd.ShowDialog() != DialogResult.OK)

                //    return;

                //try
                //{
                //    if (System.IO.File.Exists(sd.FileName))

                //        System.IO.File.Delete(sd.FileName);
                //}
                //catch (Exception ex)
                //{
                //    GUIHelper.MessageError(ex.Message, this.Text);

                //    return;
                //}
                ////---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

                //ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới

                //ge.OnDoing += (bw) =>
                //{
                //    bw.ReportProgress(-1, "Xuất excel báo cáo tăng ca trong tháng"); // Set caption

                //    #region get data

                //    bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //    //Lấy dữ liệu

                //    if (data == null || data.Rows.Count == 0)
                //    {
                //        bw.ReportProgress(1); // Nếu không có dữ liệu
                //        return;
                //    }

                //    #endregion

                //    #region export
                //    bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

                //    ExcelExportHelper ex = new ExcelExportHelper("Employee/SW_HR_QDNV.xlsx"); // Tạo excel export helper + đường dẫn template

                //    ex.WriteToCell("C4", String.Format("Long An, ngày {0:00} tháng {1:00} năm {2:0000} ", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));

                //    ex.FillDataTable(data); // Fill BC_FillData

                //    ex.RendAndFlush("QuyetDinhThoiViec" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);

                //    bw.ReportProgress(2);
                //    #endregion
                //};

                //ge.OnReport += (ps, obj) =>
                //{
                //    if (ps == 1)
                //    {
                //        GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
                //    }
                //    else if (ps == 2)
                //    {// Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.
                //        var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);
                //        c.AlertClick += (s1, e1) =>
                //        {
                //            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                //            {
                //                FileName = sd.FileName,
                //                UseShellExecute = true
                //            });
                //        };
                //    }
                //};

                //ge.Show(this);
                #endregion

            }
            if (actionPrint == "hoso")
            {
                var dt_In = from emp in _lEmpID
                            join dt in Data.AsEnumerable() on emp.ToString() equals dt["EmployeeID"].ToString()
                            select new
                            {
                                EmployeeID = dt["EmployeeID"],
                                EmployeeName = dt["EmployeeName"],
                                SexID = dt["SexID"],
                                Birthday = dt["Birthday"],
                                NativeCountry = dt["NativeCountry"],
                                IDCard = dt["IDCard"],
                                IssueDate = dt["IssueDate"],
                                IssuePlace = dt["IssuePlace"],
                                PermanentAddress = dt["PermanentAddress"],
                                Address = dt["Address"],
                                Phone = dt["Phone"],
                                MaritalStatusName = dt["MaritalStatusName"],
                                numChild = dt["numChild"],
                                EducationType = dt["EducationType"],
                                SINo = dt["SINo"],
                                SIDate = dt["SIDate"],
                                DepName = dt["DepName"],
                                SectionName = dt["SectionName"],
                                AppliedDate = dt["AppliedDate"],
                                PosName = dt["PosName"],
                                ContractDate = dt["ContractDate"],
                                BasicSalary = dt["BasicSalary"],
                                RegularAllowance = dt["RegularAllowance"]
                            };
                var rp = new rep_ThongTinNhanVien();
                rp.DataBindings(dt_In);
                ReportViewer rv = new ReportViewer();
                rv.ViewReport(rp);
            }
            if (actionPrint == "camketthue")
            {
                try
                {
                    //DataSet dt_tam = Provider.ExecuteDataSet("p_In_CamKet",
                    //     Provider.CreateParameter_StringList("dtEmpID", _lEmpID));

                    //#region: Word
                    //if (dt_tam.Tables[0].Rows.Count <= 0)
                    //{
                    //    GUIHelper.MessageBox("Không tìm thấy nhân viên.");

                    //    return;
                    //}



                    //int _row = 0;

                    //foreach(DataRow _r in dt_tam.Tables[0].Rows)
                    //{
                    //    WordUltil wd = new WordUltil(Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\" + "HR_CAMKETTHUE_001.docx"), true);

                    //    Dictionary<string, string> dic = new Dictionary<string, string>();
                    //    // Xuất các dữ liệu mình chuẩn bị ở Field (ở đây mình lọc lấy dữ liệu ở dạng linq)

                    //    dic.Add("EmployeeName_Hoa", dt_tam.Tables[0].Rows[_row]["EmployeeName_Hoa"] as string);

                    //    dic.Add("EmployeeID", dt_tam.Tables[0].Rows[_row]["EmployeeID"] as string);

                    //    dic.Add("DepName", dt_tam.Tables[0].Rows[_row]["DepName"] as string);

                    //    dic.Add("so13", dt_tam.Tables[0].Rows[_row]["so13"] as string);

                    //    dic.Add("CMND", dt_tam.Tables[0].Rows[_row]["CMND"] as string);

                    //    dic.Add("ngayKy", dt_tam.Tables[0].Rows[_row]["ngayKy"] as string);

                    //    dic.Add("noiCap", dt_tam.Tables[0].Rows[_row]["noiCap"] as string);

                    //    dic.Add("diaChi", dt_tam.Tables[0].Rows[_row]["diaChi"] as string);

                    //    dic.Add("email", dt_tam.Tables[0].Rows[_row]["email"] as string);

                    //    dic.Add("nam", dt_tam.Tables[0].Rows[_row]["nam"] as string);

                    //    wd.WriteFields(dic);

                    //    _row++;
                    //}
                    //#endregion

                    if (_lEmpID.Count == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                        return;
                    }

                    var dt_tam = Provider.ExecuteDataTableReader("p_In_CamKet",
                         Provider.CreateParameter_StringList("dtEmpID", _lEmpID));

                    string strFile = Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\" + "HR_CAMKETTHUE.docx");
                    var rp = new rep_CamKetThue(strFile);
                    rp.bindData(dt_tam);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
                catch
                { }
            }
            if (actionPrint == "thuhoi")
            {
                try
                {
                    //DataSet dt_tam = Provider.ExecuteDataSet("p_In_CamKet",
                    //     Provider.CreateParameter_StringList("dtEmpID", _lEmpID));

                    //#region: Word
                    //if (dt_tam.Tables[0].Rows.Count <= 0)
                    //{
                    //    GUIHelper.MessageBox("Không tìm thấy nhân viên.");

                    //    return;
                    //}



                    //int _row = 0;

                    //foreach(DataRow _r in dt_tam.Tables[0].Rows)
                    //{
                    //    WordUltil wd = new WordUltil(Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\" + "HR_CAMKETTHUE_001.docx"), true);

                    //    Dictionary<string, string> dic = new Dictionary<string, string>();
                    //    // Xuất các dữ liệu mình chuẩn bị ở Field (ở đây mình lọc lấy dữ liệu ở dạng linq)

                    //    dic.Add("EmployeeName_Hoa", dt_tam.Tables[0].Rows[_row]["EmployeeName_Hoa"] as string);

                    //    dic.Add("EmployeeID", dt_tam.Tables[0].Rows[_row]["EmployeeID"] as string);

                    //    dic.Add("DepName", dt_tam.Tables[0].Rows[_row]["DepName"] as string);

                    //    dic.Add("so13", dt_tam.Tables[0].Rows[_row]["so13"] as string);

                    //    dic.Add("CMND", dt_tam.Tables[0].Rows[_row]["CMND"] as string);

                    //    dic.Add("ngayKy", dt_tam.Tables[0].Rows[_row]["ngayKy"] as string);

                    //    dic.Add("noiCap", dt_tam.Tables[0].Rows[_row]["noiCap"] as string);

                    //    dic.Add("diaChi", dt_tam.Tables[0].Rows[_row]["diaChi"] as string);

                    //    dic.Add("email", dt_tam.Tables[0].Rows[_row]["email"] as string);

                    //    dic.Add("nam", dt_tam.Tables[0].Rows[_row]["nam"] as string);

                    //    wd.WriteFields(dic);

                    //    _row++;
                    //}
                    //#endregion

                    if (_lEmpID.Count == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                        return;
                    }

                    var dt_tam = Provider.ExecuteDataTableReader("p_In_ThuHoi",
                         Provider.CreateParameter_StringList("dtEmpID", _lEmpID));

                    string strFile = Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\" + "HR_QDTHUHOI.docx");
                    var rp = new rep_ThuHoi(strFile);
                    rp.bindData(dt_tam);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
                catch
                { }
            }
            if (actionPrint == "xacnhancongtac")
            {
                try
                {
                    if (_lEmpID.Count == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                        return;
                    }

                    var dt_tam = Provider.ExecuteDataTableReader("p_In_XacNhanCongTac",
                         Provider.CreateParameter_StringList("dtEmpID", _lEmpID));
                    string strFile = Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\" + "DH_XACNHANCONGTAC.docx");

                    if (rdSite.SelectedIndex == 0)
                    {
                         strFile = Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\" + "DH_XACNHANCONGTAC.docx");
                    }
                    if (rdSite.SelectedIndex == 1)
                    {
                         strFile = Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\" + "NV_XACNHANCONGTAC.docx");
                    }

                    var rp = new rep_XacNhanCongTac(strFile);
                    rp.bindData(dt_tam);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
                catch
                { }
            }
        }

        private List<string> getEmpID()
        {
            List<string> _lEmpID = new List<string>();
            for (int i = 0; i < grvEmployee.RowCount; i++)
            {
                if (grvEmployee.GetRowCellValue(i, colCheck).ToString() == "True")
                {
                    _lEmpID.Add(grvEmployee.GetRowCellValue(i, colEmpID).ToString());
                }
            }
            return _lEmpID;
        }

        private void InCustomPhieuLuong_Load(object sender, EventArgs e)
        {
            TranslateForm();
            //LoadGrvLayout(grvEmployee);
            List<Employee> _lObject = new List<Employee>();

            if (actionPrint == "NhatKiThuViec")
            {
                Data = Provider.ExecuteDataTableReader("p_getData_NhatKiThuViec");
            }
            if (actionPrint == "quyetdinhthoiviec")
            {
                Data = Provider.ExecuteDataTableReader("p_getData_ThuMoiCanhCao");
            }
            if (actionPrint == "the")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT e.EmployeeID,e.EmployeeName, e.PosName,e.AppliedDate,	IIF( ISNULL(e.LayNamSinh,0) = 0, CONVERT(NVARCHAR(10), e.Birthday, 103),RIGHT(CONVERT(NVARCHAR(10), e.Birthday, 103),4)) as Birthday, e.IDCard, e.DepName,e.LineName,e.TeamName,EmpTypeName"
               + " FROM dbo.tblEmployee e where ISNULL(e.LeftDate,'') = '' "
               );
            }
            if (actionPrint == "thucanhcao")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT e.EmployeeID,e.EmployeeName, e.AppliedDate,e.Birthday, e.IDCard, e.DepName,e.LineName,e.TeamName,EmpTypeName"
               + " FROM dbo.tblEmployee e where ISNULL(e.LeftDate,'') = '' "
               );
            }
            if (actionPrint == "hoso")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(@"SELECT e.EmployeeID
                    ,e.EmployeeName
                    , e.PosName
                    ,e.AppliedDate
                    ,IIF( ISNULL(e.LayNamSinh,0) = 0
                        , CONVERT(NVARCHAR(10), e.Birthday, 103)
                        ,RIGHT(CONVERT(NVARCHAR(10), e.Birthday, 103),4)) as Birthday
                    , e.IDCard
                    , e.DepName
                    , e.SexID
                    , e.IDCard
                    , e.IssueDate
                    , e.IssuePlace
                    , e.PermanentAddress
                    , e.Address
                    , e.Phone
                    , e.MaritalStatusName
                    , e.numChild
                    , e.EducationType
                    , e.SINo
                    , e.SIDate
                    , e.SectionName
                    , e.ContractDate
                    , e.BasicSalary
                    , e.RegularAllowance
                    , e.NativeCountry
                     FROM dbo.tblEmployee e");
            }
            if (actionPrint == "hopdong")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT * FROM dbo.tblEmployee e where ISNULL(e.LeftDate,'') = '' "
                );
                Data.Columns.Add("TuNgay");
                Data.Columns.Add("DenNgay");
                Data.Columns.Add("TgTu");
                Data.Columns.Add("TgDen");
            }
            if (actionPrint == "quyetdinhthoiviec")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT * FROM dbo.tblEmployee e where ISNULL(e.LeftDate,'') <> ''"
                );
                Data.Columns.Add("ngaytheodon");
                Data.Columns.Add("thongtinngay");
                Data.Columns.Add("ngaytheodonYSS");
                Data.Columns.Add("SoQDNV");
            }
            if (actionPrint == "camketthue")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT * FROM dbo.tblEmployee e ORDER BY EmployeeID, AppliedDate"
                );
            }
            if (actionPrint == "thuhoi")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT * FROM dbo.tblEmployee e where e.LeftDate is null"
                );
            }
            if (actionPrint == "xacnhancongtac")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT * FROM dbo.tblEmployee e where e.LeftDate is null"
                );
            }

            foreach (DataRow row in Data.Rows)
            {
                Employee newEmp = new Employee();
                newEmp.chkEmp = false;
                newEmp.EmployeeID = row["EmployeeID"].ToString();
                newEmp.EmployeeName = row["EmployeeName"].ToString();
                newEmp.IDCard = row["IDCard"].ToString();
                newEmp.DepName = row["DepName"].ToString();
                newEmp.AppliedDate = row["AppliedDate"] as DateTime?;
                newEmp.Birthday = row["Birthday"].ToString();
                _lObject.Add(newEmp);
            }
            grcEmployee.DataSource = _lObject;
        }

        private class Employee
        {
            public bool chkEmp { get; set; }
            public string EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public string IDCard { get; set; }
            public string DepName { get; set; }
            public DateTime? AppliedDate { get; set; }
            public String Birthday { get; set; }
        }

        private void grvEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcEmployee.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void InTheNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                InCustomPhieuLuong_Load(null, null);
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

        private IEnumerable<DevExpress.XtraEditors.CheckEdit> EnumerateCheckEditControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.CheckEdit).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.CheckEdit)field.GetValue(this)
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
            var _CheckEdit = EnumerateCheckEditControl();
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
            foreach (DevExpress.XtraEditors.CheckEdit s in _CheckEdit)
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

        private void groupInHoSo_Paint(object sender, PaintEventArgs e)
        {

        }
        //private void InCustomPhieuLuong_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //SaveGrvLayout(grvEmployee);
        //}
    }
}