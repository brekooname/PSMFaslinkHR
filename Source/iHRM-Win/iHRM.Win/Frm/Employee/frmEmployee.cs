using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Helper;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Win.Frm.Report;
using iHRM.Win.Frm.QuetThe;
using DevExpress.Skins;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Win.ExtClass;
using iHRM.Common.Code;
using iHRM.Core.FileDB;
using iHRM.Win.Frm.XtraReport_Template;
using iHRM.Win.Frm.LogAction;
using System.Data.SqlClient;
using System.Reflection;


namespace iHRM.Win.Frm.Employee
{
    public partial class frmEmployee : frmBase
    {
        global::iHRM.Core.Business.Logic.Employee.Emp logic = new global::iHRM.Core.Business.Logic.Employee.Emp();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        List<ActionClass> _lActionClass = new List<ActionClass>();

        DataTable dtData = new DataTable();

        DataTable dataBH = new DataTable();

        DataRow CRow;

        dlgEmployee dlgEditor;

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            TranslateForm();
            if (LoginHelper.user.idKhoiPB != null)
            {
                chonPhongBan1.SelectedValue = LoginHelper.user.idKhoiPB.ToString();
            }

            btnFind_Click(null, null);

            btnThemNV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);

            toolXoa.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);

            toolExcel.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);

            toolStripIn.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);

            toolStripButBaoTangBH.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);

            toolStripButBaoGiamBH.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);

            toolStripInThe.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);

            toolInHD.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);

            toolStripInHoSo.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);

            btnInQuyetDinh.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);

            //dlgEditor = new dlgEmployee();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            dw_it.Caption = "Đang tải dữ liệu nhân viên...";

            dw_it.OnDoing = (s, ev) =>
            {
                logic.VirtualPaging.PageSize = pageNavigator1.PageSize; //Phân trang

                logic.VirtualPaging.Page = pageNavigator1.CurrentPage;

                if (!string.IsNullOrEmpty(chonPhongBan1.SelectedValue))

                    dtData = logic.GetAll(
                        new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text),
                        new System.Data.SqlClient.SqlParameter("phongban", chonPhongBan1.SelectedValue),
                        new System.Data.SqlClient.SqlParameter("includeLeftedEmp", chkLeftDate.Checked),
                        new System.Data.SqlClient.SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                        new System.Data.SqlClient.SqlParameter("denNgay", chonKyLuong1.DenNgay),
                        new System.Data.SqlClient.SqlParameter("CheckAll", checkAllNV.Checked)
                        );

                else
                    dtData = logic.GetAll(
                        new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text),
                        new System.Data.SqlClient.SqlParameter("includeLeftedEmp", chkLeftDate.Checked),
                        new System.Data.SqlClient.SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                        new System.Data.SqlClient.SqlParameter("denNgay", chonKyLuong1.DenNgay),
                        new System.Data.SqlClient.SqlParameter("CheckAll", checkAllNV.Checked)
                       );

                dtData.Columns["hinhthuctraluong"].ReadOnly = false;

                dtData.Columns["idFile"].ReadOnly = false;

                dtData.Columns["dataFile"].ReadOnly = false;

                dtData.Columns["duoiFile"].ReadOnly = false;

                dw_it.bw.ReportProgress(1, dtData);

                dw_it.bw.ReportProgress(2, logic.VirtualPaging.RecordCount);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState; btnFind.Enabled = true;
                }
                else if (data.ProgressPercentage == 2)
                {
                    pageNavigator1.RecordCount = (int)data.UserState;
                }
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void toolExcel_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }


        void ShowEditor() //Show dialogEmployee
        {
            if (dlgEditor == null)
            {
                dlgEditor = new dlgEmployee();

                dlgEditor.Owner = this;

                dlgEditor.OnSave += dlgEditor_OnSave;

                dlgEditor.iRule = iRule.rules;

                dlgEditor._ChkLuong = LoginHelper.user.isAdmin || BitHelper.Has(iRule.customRules ?? 0, 1);
            }

            dlgEditor.Show();
        }

        void dlgEditor_OnSave(object sender, EventArgs e) //Hàm lưu thông tin và thêm nhân viên
        {
            try
            {
                #region  Check nhập thông tin
                if (dlgEditor.MyValue["AppliedDate"] == DBNull.Value)
                {
                    GUIHelper.Notifications("Vui lòng nhập ngày vào làm!", "Không thể lưu", GUIHelper.NotifiType.error);

                    return;
                }

                if (dlgEditor.MyValue["Birthday"] == DBNull.Value)
                {
                    GUIHelper.Notifications("Vui lòng nhập ngày sinh!", "Không thể lưu", GUIHelper.NotifiType.error);

                    return;
                }

                if (dlgEditor.MyValue["SexID"] == DBNull.Value)
                {
                    GUIHelper.Notifications("Vui lòng nhập giới tính!", "Không thể lưu", GUIHelper.NotifiType.error);

                    return;
                }

                if (dlgEditor.MyValue["BHXH_RaceID"] == DBNull.Value)
                {
                    GUIHelper.Notifications("Vui lòng nhập dân tộc!", "Không thể lưu", GUIHelper.NotifiType.error);

                    return;
                }

                if (dlgEditor.MyValue["NationalityID"] == DBNull.Value)
                {
                    GUIHelper.Notifications("Vui lòng nhập quốc tịch!", "Không thể lưu", GUIHelper.NotifiType.error);

                    return;
                }

                if (dlgEditor.MyValue["EducationID"] == DBNull.Value)
                {
                    GUIHelper.Notifications("Vui lòng nhập trình độ học vấn!", "Không thể lưu", GUIHelper.NotifiType.error);

                    return;
                }

                //DateTime _BirthdayBD = DateTime.Parse(dlgEditor.MyValue["Birthday"].ToString());

                //DateTime _AppliedDateBD = DateTime.Parse(dlgEditor.MyValue["AppliedDate"].ToString());


                //if (_BirthdayBD.AddYears(18) >= _AppliedDateBD)
                //{
                //    GUIHelper.Notifications("Nhân viên này chưa đủ 18 tuổi.", "Không thể lưu", GUIHelper.NotifiType.none);

                //    return;
                //}
                #endregion

                db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

                dcDatabaseMCCDataContext dbMCC = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);

                _lActionClass.Clear();

                tblEmployee emp_new;

               int maChamCong = 0;
                if (dlgEditor.CustomFormAction == 0)
                {
                    emp_new = new tblEmployee();

                    emp_new.EmployeeID = dlgEditor.MyValue["EmployeeID"] as string;

                    emp_new.EmployeeCode = dlgEditor.MyValue["EmployeeID"] as string;

                     maChamCong = LoginHelper.Context.getNumberEmpID(emp_new.EmployeeID);
                }
                else
                {
                    emp_new = db.tblEmployees.Where(p => p.EmployeeID == dlgEditor.myID.ToString()).Single();

                    emp_new.EmployeeID = dlgEditor.myID.ToString();

                    emp_new.statePushServer = "edited";

                    maChamCong = LoginHelper.Context.getNumberEmpID(emp_new.EmployeeID);
                }

                // Thông tin chung:
                emp_new.OldEmployeeID = dlgEditor.MyValue["OldEmployeeID"] as string;

                emp_new.NameSearch = ConvertUnicode.RemoveUnicode(dlgEditor.MyValue["EmployeeName"] as string).ToUpper();

                emp_new.FirstName = dlgEditor.MyValue["FirstName"] as string;

                emp_new.LastName = dlgEditor.MyValue["LastName"] as string;

                emp_new.Birthday = dlgEditor.MyValue["Birthday"] as DateTime?;

                if ((dlgEditor.MyValue["LayNamSinh"] as bool?) == null)
                {
                    emp_new.LayNamSinh = false;
                }
                else
                    emp_new.LayNamSinh = Convert.ToBoolean(dlgEditor.MyValue["LayNamSinh"]);

                emp_new.EmployeeName = dlgEditor.MyValue["EmployeeName"] as string;

                emp_new.MaritalStatusID = dlgEditor.MyValue["MaritalStatusID"] as string;

                if (!string.IsNullOrEmpty(emp_new.MaritalStatusID))
                {
                    var q = db.tblRef_MaritalStatus.Where(p => p.MaritalStatusID == emp_new.MaritalStatusID);

                    if (q.Count() > 0)
                    {
                        emp_new.MaritalStatusName = q.First().MaritalStatusName;
                    }
                }

                emp_new.SexID = dlgEditor.MyValue["SexID"] as string;

                emp_new.Phone = dlgEditor.MyValue["Phone"] as string;

                emp_new.CardID = dlgEditor.MyValue["CardID"] as string;

                emp_new.AppliedDate = dlgEditor.MyValue["AppliedDate"] as DateTime?;

                emp_new.SubmitDate = dlgEditor.MyValue["SubmitDate"] as DateTime?;

                emp_new.ContractDate = dlgEditor.MyValue["ContractDate"] as DateTime?;

                emp_new.NationalityID = dlgEditor.MyValue["NationalityID"] as string;

                emp_new.mailCongTy = dlgEditor.MyValue["mailCongTy"] as string;

                emp_new.mailNgoai = dlgEditor.MyValue["mailNgoai"] as string;

                emp_new.dis = dlgEditor.MyValue["dis"] as string;

                if (!string.IsNullOrEmpty(emp_new.NationalityID))
                {
                    var q = db.tblRef_Nationalities.Where(p => p.NationalityID == emp_new.NationalityID);

                    if (q.Count() > 0)
                    {
                        emp_new.NationalityName = q.First().NationalityName;

                        emp_new.NationalityName_VIE = q.First().NationalityName_VIE;
                    }
                }

                // Vào đoàn
                emp_new.TradeUnionDate = dlgEditor.MyValue["TradeUnionDate"] as DateTime?;

                emp_new.SoQuyetDinh = dlgEditor.MyValue["SoQuyetDinh"] as string;

                emp_new.EducationID = dlgEditor.MyValue["EducationID"] as string;

                if (!string.IsNullOrEmpty(emp_new.EducationID))
                {
                    var q = db.tblRef_Educations.Where(p => p.EducationID == emp_new.EducationID);

                    if (q.Count() > 0)
                    {
                        emp_new.EducationType = q.First().EducationType;
                    }
                }
                if (dlgEditor.MyValue["InGroup1"] == null || dlgEditor.MyValue["InGroup1"].ToString() == "" || dlgEditor.MyValue["InGroup1"].ToString() == "0")
                {
                    emp_new.InGroup1 = null;
                }
                else
                {
                    emp_new.InGroup1 = Convert.ToInt16(dlgEditor.MyValue["InGroup1"]);
                }

                // Start CMND:
                emp_new.IDCard = dlgEditor.MyValue["IDCard"] as string;

                emp_new.IssuePlaceID = dlgEditor.MyValue["IssuePlaceID"] as string;

                if (!string.IsNullOrEmpty(emp_new.IssuePlaceID))
                {
                    var q = db.tblRef_Cities.Where(p => p.CityID == emp_new.IssuePlaceID);

                    if (q.Count() > 0)
                    {
                        emp_new.IssuePlace = q.First().CityName;
                    }
                }

                emp_new.Address = dlgEditor.MyValue["Address"] as string;

                emp_new.IssueDate = dlgEditor.MyValue["IssueDate"] as DateTime?;

                emp_new.NativeCountryID = dlgEditor.MyValue["NativeCountryID"] as string;

                if (!string.IsNullOrEmpty(emp_new.NativeCountryID))
                {
                    var q = db.tblRef_Cities.Where(p => p.CityID == emp_new.NativeCountryID);

                    if (q.Count() > 0)
                    {
                        emp_new.NativeCountry = q.First().CityName;
                    }
                }

                emp_new.PermanentAddress = dlgEditor.MyValue["PermanentAddress"] as string;

                emp_new.CompanyName = dlgEditor.MyValue["CompanyName"] as string;

                // Start BH
                emp_new.BHXH_NoiSinhTo = dlgEditor.MyValue["BHXH_NoiSinhTo"] as string;

                emp_new.BHXH_NoiSinhXa = dlgEditor.MyValue["BHXH_NoiSinhXa"] as string;

                emp_new.BHXH_DiaChiTo = dlgEditor.MyValue["BHXH_DiaChiTo"] as string;

                emp_new.BHXH_DiaChiXa = dlgEditor.MyValue["BHXH_DiaChiXa"] as string;

                emp_new.BHXH_NoiCapXa = dlgEditor.MyValue["BHXH_NoiCapXa"] as string;

                emp_new.BHXH_QueQuanXa = dlgEditor.MyValue["BHXH_QueQuanXa"] as string;

                emp_new.BHXH_RaceID = dlgEditor.MyValue["BHXH_RaceID"] as string;

                // Start Tài Khoản Ngân Hàng
                emp_new.BankAccount = dlgEditor.MyValue["BankAccount"] as string;

                emp_new.BankNameAcount = dlgEditor.MyValue["BankNameAcount"] as string;

                emp_new.BankID = dlgEditor.MyValue["BankID"] as string;

                //Bảo hiểm xã hội
                emp_new.SI = dlgEditor.MyValue["SI"] as bool?;

                emp_new.SINo = dlgEditor.MyValue["SINo"] as string;

                emp_new.SIDate = dlgEditor.MyValue["SIDate"] as DateTime?;

                // Bảo hiểm y tế 
                emp_new.HI = dlgEditor.MyValue["HI"] as bool?;

                emp_new.HINo = dlgEditor.MyValue["HINo"] as string;

                emp_new.HIDate = dlgEditor.MyValue["HIDate"] as DateTime?;

                emp_new.HIIssueAt = dlgEditor.MyValue["HIIssueAt"] as string;

                emp_new.HIFrom_MY = dlgEditor.MyValue["HIFrom_MY"] as DateTime?;

                if (!string.IsNullOrEmpty(emp_new.BankID))
                {
                    var a = db.tblRef_Banks.Where(p => p.BankID == emp_new.BankID).ToList();

                    if (a.Count > 0)
                        emp_new.BankName = a.First().BankName;
                    else
                        emp_new.BankName = null;
                }

                // Lương
                emp_new.AnnualLeave = dlgEditor.MyValue["AnnualLeave"] as double?;

                // Thuế
                emp_new.IncomeTax = dlgEditor.MyValue["IncomeTax"] as bool?;

                emp_new.IncomeTaxNumber = dlgEditor.MyValue["IncomeTaxNumber"] as string;

                emp_new.IncomeTaxDate = dlgEditor.MyValue["IncomeTaxDate"] as DateTime?;

                // Bảo hiểm sổ lao động và nghỉ việc. 
                if (dlgEditor.MyValue["LeftDate"] as DateTime? == null)
                {
                    emp_new.idxLeftDate = null;

                    emp_new.ReasonForLeft = null;
                }
                else
                {
                    if (emp_new.LeftDate == null)
                    {
                        var maxIdxEmp = db.tblEmployees.Where(p => p.LeftDate != null
                                                            && p.idxLeftDate > 0
                                                            && p.LeftDate.Value.Year == (dlgEditor.MyValue["LeftDate"] as DateTime?)
                                                            .Value.Year).OrderByDescending(p => p.idxLeftDate)
                                                            .FirstOrDefault();
                        int idx = 1;

                        if (maxIdxEmp != null)
                        {
                            idx = maxIdxEmp.idxLeftDate.Value + 1;
                        }
                        emp_new.idxLeftDate = idx;

                        emp_new.ReasonForLeft = "QĐTV-T" + ((dlgEditor.MyValue["LeftDate"] as DateTime?).Value.Month.ToString("00")) + "." + emp_new.idxLeftDate.Value.ToString("000");
                    }
                }

                emp_new.LeftDate = dlgEditor.MyValue["LeftDate"] as DateTime?;

                emp_new.LeftTypeID = dlgEditor.MyValue["LeftTypeID"] as string;

                emp_new.LeftTypeName = dlgEditor.MyValue["LeftTypeName"] as string;

                emp_new.FinalPaymentDate = dlgEditor.MyValue["FinalPaymentDate"] as DateTime?;

                emp_new.LeftDateReg = dlgEditor.MyValue["LeftDateReg"] as DateTime?;

                if ((dlgEditor.MyValue["IsNotOT"] as bool?) == null)
                {
                    emp_new.IsNotOT = false;
                }
                else emp_new.IsNotOT = Convert.ToBoolean(dlgEditor.MyValue["IsNotOT"]);


                if (dlgEditor.MyValue["idCaLamMacDinh"].ToString() != string.Empty)
                {
                    emp_new.idCaLamMacDinh = Guid.Parse(dlgEditor.MyValue["idCaLamMacDinh"].ToString());
                }
                else
                {
                    emp_new.idCaLamMacDinh = null;
                }

                emp_new.hinhthuctraluong = dlgEditor.MyValue["hinhthuctraluong"].ToString();

                FileStorageHelper fg = new FileStorageHelper();

                if (dlgEditor.CustomFormAction == 0)
                {
                    var aa = db.tblEmployees.Where(p => p.EmployeeID == dlgEditor.MyValue["EmployeeID"].ToString()).ToList();

                    if (dlgEditor.MyValue["dataFile"] == DBNull.Value)
                    {
                        if (dlgEditor.MyValue["idFile"] != DBNull.Value)
                        {
                            fg.DeleteFileByIDDBFiles(Guid.Parse(dlgEditor.MyValue["idFile"].ToString()));

                            emp_new.idFile = null;
                        }
                    }

                    if (dlgEditor.MyValue["dataFile"] != DBNull.Value)
                    {
                        fg.InsertOrUpdateDBFiles(Guid.Parse(dlgEditor.MyValue["idFile"].ToString())
                                                            , dlgEditor.MyValue["dataFile"] as byte[]
                                                            , dlgEditor.MyValue["duoiFile"].ToString());

                        emp_new.idFile = Guid.Parse(dlgEditor.MyValue["idFile"].ToString());
                    }
                    if (aa.Count == 0)
                    {
                        //String _ContractID = string.Format("{0}-{1:00}{2:0000}-HĐLĐ", emp_new.EmployeeID, _AppliedDateBD.Month.ToString("00"), _AppliedDateBD.Year.ToString());

                        //String _ContractTypeName = db.tblRef_ContractTypes.Where(p => p.ContractTypeID == "1").SingleOrDefault().ContractTypeName;

                        //emp_new.ContractDate = _AppliedDateBD;

                        //emp_new.ContractID = _ContractID;

                        //emp_new.ContractTypeID = "1";

                        //emp_new.ContractTypeName = _ContractTypeName;

                        //emp_new.BasicSalary = 0;

                        db.tblEmployees.InsertOnSubmit(emp_new);

                        db.SubmitChanges();

                        dlgEditor.visibleTab(true);

                        //#region: Insert HĐLĐ 1 tháng
                        ////Tự động thêm HĐ 1 tháng cho nhân viên

                        //tblEmpContract _empCT = new tblEmpContract();

                        //_empCT.id = Guid.NewGuid();

                        //_empCT.EmployeeID = emp_new.EmployeeID;

                        //_empCT.BeginDate = _AppliedDateBD;

                        //_empCT.EndDate = new DateTime(_AppliedDateBD.Year, _AppliedDateBD.Month, _empCT.BeginDate.Day).AddMonths(1).AddDays(-1);

                        //_empCT.ContractTypeID = "1";

                        //_empCT.Notes = "PM tạo mới khi khởi tạo nhân viên.";

                        //_empCT.ContractID = _ContractID;

                        //db.tblEmpContracts.InsertOnSubmit(_empCT);

                        ////cập nhập thông tin lương cơ bản
                        //tblEmpSalary _luongcoban = new tblEmpSalary();

                        //_luongcoban.id = Guid.NewGuid();

                        //_luongcoban.EmployeeID = emp_new.EmployeeID;

                        //_luongcoban.DateChange = _AppliedDateBD;

                        //_luongcoban.BasicSalary = 0;

                        //_luongcoban.BasicSalary_Ins = 0;

                        //_luongcoban.PosID = "10";

                        //_luongcoban.status = 0;

                        //_luongcoban.ContractCode = _ContractID;

                        //_luongcoban.Notes = "PM tạo mới khi khởi tạo nhân viên.";

                        //db.tblEmpSalaries.InsertOnSubmit(_luongcoban);
                        //#endregion

                        //db.SubmitChanges();

                        _lActionClass.Add(new ActionClass("Thêm dữ liệu", dlgEditor.MyValue["EmployeeID"].ToString(), "", "Thêm mới nhân viên "
                                            + ", Mã NV: " + (dlgEditor.MyValue["EmployeeID"].ToString() != null ? dlgEditor.MyValue["EmployeeID"].ToString() : "")
                                            + ", Họ: " + (dlgEditor.MyValue["FirstName"].ToString() != null ? dlgEditor.MyValue["FirstName"].ToString() : "")
                                            + ", tên : " + (dlgEditor.MyValue["LastName"].ToString() != null ? dlgEditor.MyValue["LastName"].ToString() : "")
                                            + ", tên NV : " + (dlgEditor.MyValue["EmployeeName"].ToString() != null ? dlgEditor.MyValue["EmployeeName"].ToString() : "")

                                            + ", giới tính : " + (dlgEditor.MyValue["SexID"].ToString() != null ? dlgEditor.MyValue["SexID"].ToString() : "")
                                            + ", CMND : " + (dlgEditor.MyValue["IDCard"].ToString() != null ? dlgEditor.MyValue["IDCard"].ToString() : "")
                                            + ", nơi cấp CMND : " + (dlgEditor.MyValue["IssuePlace"].ToString() != null ? dlgEditor.MyValue["IssuePlace"].ToString() : "")
                                            + ", ngày cấp CMND : " + (dlgEditor.MyValue["IssueDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["IssueDate"])) : "")

                                            + ", địa chỉ : " + (dlgEditor.MyValue["NativeCountry"].ToString() != null ? dlgEditor.MyValue["NativeCountry"].ToString() : "")
                                            + ", quê quán : " + (dlgEditor.MyValue["Address"].ToString() != null ? dlgEditor.MyValue["Address"].ToString() : "")
                                            + ", địa chỉ thường trú : " + (dlgEditor.MyValue["PermanentAddress"].ToString() != null ? dlgEditor.MyValue["PermanentAddress"].ToString() : "")

                                            + ", sđt : " + (dlgEditor.MyValue["Phone"].ToString() != null ? dlgEditor.MyValue["Phone"].ToString() : "")
                                            + ", tình trạng hôn nhân : " + (dlgEditor.MyValue["MaritalStatusName"].ToString() != null ? dlgEditor.MyValue["MaritalStatusName"].ToString() : "")

                                            + ", mã loại NV : " + (dlgEditor.MyValue["EmpTypeID"].ToString() != null ? dlgEditor.MyValue["EmpTypeID"].ToString() : "")
                                            + ", tên loại NV : " + (dlgEditor.MyValue["EmpTypeName"].ToString() != null ? dlgEditor.MyValue["EmpTypeName"].ToString() : "")

                                            //+ ", loại hợp đồng : " + _ContractTypeName 
                                            //+ ", mã hợp đồng : " + _ContractID

                                            + ", mã phòng ban : " + (dlgEditor.MyValue["DepID_Final"].ToString() != null ? dlgEditor.MyValue["DepID_Final"].ToString() : "")
                                            + ", phòng ban : " + (dlgEditor.MyValue["DepName"].ToString() != null ? dlgEditor.MyValue["DepName"].ToString() : "")

                                            + ", mã số thuế : " + (dlgEditor.MyValue["IncomeTaxNumber"].ToString() != null ? dlgEditor.MyValue["IncomeTaxNumber"].ToString() : "")
                                            + ", ngày số thuế : " + (dlgEditor.MyValue["IncomeTaxDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["IncomeTaxDate"])) : "")

                                            + ", số sổ BH : " + (dlgEditor.MyValue["SINo"].ToString() != null ? dlgEditor.MyValue["SINo"].ToString() : "")
                                            + ", ngày sổ BH : " + (dlgEditor.MyValue["SIDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["SIDate"])) : "")

                                            + ", stk : " + (dlgEditor.MyValue["BankAccount"].ToString() != null ? dlgEditor.MyValue["BankAccount"].ToString() : "")
                                            + ", ngân hàng : " + (dlgEditor.MyValue["BankName"].ToString() != null ? dlgEditor.MyValue["BankName"].ToString() : "")

                                            + ", emai công ty : " + (dlgEditor.MyValue["mailCongTy"].ToString() != null ? dlgEditor.MyValue["mailCongTy"].ToString() : "")
                                            + ", email ngoài : " + (dlgEditor.MyValue["mailNgoai"].ToString() != null ? dlgEditor.MyValue["mailNgoai"].ToString() : "")

                                            + ", ngày vào làm : " + (dlgEditor.MyValue["AppliedDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["AppliedDate"])) : "")
                                            + ", ngày nghỉ việc : " + (dlgEditor.MyValue["LeftDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["LeftDate"])) : "")

                                            + ", không OT : " + (dlgEditor.MyValue["IsNotOT"].ToString() != null ? dlgEditor.MyValue["IsNotOT"].ToString() : "")

                                            + ", trình độ : " + (dlgEditor.MyValue["EducationType"].ToString() != null ? dlgEditor.MyValue["EducationType"].ToString() : "")

                                            + ", ca làm mặc định : " + (dlgEditor.MyValue["idCaLamMacDinh"].ToString() != null ? dlgEditor.MyValue["idCaLamMacDinh"].ToString() : "")

                                            , "tblEmployee"));

                        LogAction.LogAction.PushLog(_lActionClass);

                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    }
                    else
                    {
                        db.SubmitChanges();

                        _lActionClass.Add(new ActionClass("Sửa dữ liệu", dlgEditor.MyValue["EmployeeID"].ToString(), "", "Cập nhật nhân viên "
                            + ", Mã NV: " + (dlgEditor.MyValue["EmployeeID"].ToString() != null ? dlgEditor.MyValue["EmployeeID"].ToString() : "")
                            + ", Họ: " + (dlgEditor.MyValue["FirstName"].ToString() != null ? dlgEditor.MyValue["FirstName"].ToString() : "")
                            + ", tên : " + (dlgEditor.MyValue["LastName"].ToString() != null ? dlgEditor.MyValue["LastName"].ToString() : "")
                            + ", tên NV : " + (dlgEditor.MyValue["EmployeeName"].ToString() != null ? dlgEditor.MyValue["EmployeeName"].ToString() : "")

                            + ", giới tính : " + (dlgEditor.MyValue["SexID"].ToString() != null ? dlgEditor.MyValue["SexID"].ToString() : "")
                            + ", CMND : " + (dlgEditor.MyValue["IDCard"].ToString() != null ? dlgEditor.MyValue["IDCard"].ToString() : "")
                            + ", nơi cấp CMND : " + (dlgEditor.MyValue["IssuePlace"].ToString() != null ? dlgEditor.MyValue["IssuePlace"].ToString() : "")
                            + ", ngày cấp CMND : " + (dlgEditor.MyValue["IssueDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["IssueDate"])) : "")

                            + ", địa chỉ : " + (dlgEditor.MyValue["NativeCountry"].ToString() != null ? dlgEditor.MyValue["NativeCountry"].ToString() : "")
                            + ", quê quán : " + (dlgEditor.MyValue["Address"].ToString() != null ? dlgEditor.MyValue["Address"].ToString() : "")
                            + ", địa chỉ thường trú : " + (dlgEditor.MyValue["PermanentAddress"].ToString() != null ? dlgEditor.MyValue["PermanentAddress"].ToString() : "")

                            + ", sđt : " + (dlgEditor.MyValue["Phone"].ToString() != null ? dlgEditor.MyValue["Phone"].ToString() : "")
                            + ", tình trạng hôn nhân : " + (dlgEditor.MyValue["MaritalStatusName"].ToString() != null ? dlgEditor.MyValue["MaritalStatusName"].ToString() : "")

                            + ", mã loại NV : " + (dlgEditor.MyValue["EmpTypeID"].ToString() != null ? dlgEditor.MyValue["EmpTypeID"].ToString() : "")
                            + ", tên loại NV : " + (dlgEditor.MyValue["EmpTypeName"].ToString() != null ? dlgEditor.MyValue["EmpTypeName"].ToString() : "")

                            + ", loại hợp đồng : " + (dlgEditor.MyValue["ContractTypeName"].ToString() != null ? dlgEditor.MyValue["ContractTypeName"].ToString() : "")
                            + ", mã hợp đồng : " + (dlgEditor.MyValue["ContractID"].ToString() != null ? dlgEditor.MyValue["ContractID"].ToString() : "")

                            + ", mã phòng ban : " + (dlgEditor.MyValue["DepID_Final"].ToString() != null ? dlgEditor.MyValue["DepID_Final"].ToString() : "")
                            + ", phòng ban : " + (dlgEditor.MyValue["DepName"].ToString() != null ? dlgEditor.MyValue["DepName"].ToString() : "")

                            + ", mã số thuế : " + (dlgEditor.MyValue["IncomeTaxNumber"].ToString() != null ? dlgEditor.MyValue["IncomeTaxNumber"].ToString() : "")
                            + ", ngày số thuế : " + (dlgEditor.MyValue["IncomeTaxDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["IncomeTaxDate"])) : "")

                            + ", số sổ BH : " + (dlgEditor.MyValue["SINo"].ToString() != null ? dlgEditor.MyValue["SINo"].ToString() : "")
                            + ", ngày sổ BH : " + (dlgEditor.MyValue["SIDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["SIDate"])) : "")

                            + ", stk : " + (dlgEditor.MyValue["BankAccount"].ToString() != null ? dlgEditor.MyValue["BankAccount"].ToString() : "")
                            + ", ngân hàng : " + (dlgEditor.MyValue["BankName"].ToString() != null ? dlgEditor.MyValue["BankName"].ToString() : "")

                            + ", emai công ty : " + (dlgEditor.MyValue["mailCongTy"].ToString() != null ? dlgEditor.MyValue["mailCongTy"].ToString() : "")
                            + ", email ngoài : " + (dlgEditor.MyValue["mailNgoai"].ToString() != null ? dlgEditor.MyValue["mailNgoai"].ToString() : "")

                            + ", ngày vào làm : " + (dlgEditor.MyValue["AppliedDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["AppliedDate"])) : "")
                            + ", ngày nghỉ việc : " + (dlgEditor.MyValue["LeftDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["LeftDate"])) : "")

                            + ", không OT : " + (dlgEditor.MyValue["IsNotOT"].ToString() != null ? dlgEditor.MyValue["IsNotOT"].ToString() : "")

                            + ", trình độ : " + (dlgEditor.MyValue["EducationType"].ToString() != null ? dlgEditor.MyValue["EducationType"].ToString() : "")

                            + ", ca làm mặc định : " + (dlgEditor.MyValue["idCaLamMacDinh"].ToString() != null ? dlgEditor.MyValue["idCaLamMacDinh"].ToString() : "")

                            , "tblEmployee"));

                        LogAction.LogAction.PushLog(_lActionClass);

                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                    }
                }
                else
                {
                    if (dlgEditor.MyValue["dataFile"] == DBNull.Value)
                    {
                        if (dlgEditor.MyValue["idFile"] != DBNull.Value)
                        {
                            fg.DeleteFileByIDDBFiles(Guid.Parse(dlgEditor.MyValue["idFile"].ToString()));

                            emp_new.idFile = null;
                        }
                    }

                    if (dlgEditor.MyValue["dataFile"] != DBNull.Value)
                    {
                        fg.InsertOrUpdateDBFiles(Guid.Parse(dlgEditor.MyValue["idFile"].ToString()), dlgEditor.MyValue["dataFile"] as byte[], dlgEditor.MyValue["duoiFile"].ToString());

                        emp_new.idFile = Guid.Parse(dlgEditor.MyValue["idFile"].ToString());
                    }

                    // Sửa thì chuyển trạng thái thành edited

                    db.SubmitChanges();

                    _lActionClass.Add(new ActionClass("Sửa dữ liệu", dlgEditor.MyValue["EmployeeID"].ToString(), "", "Cập nhật nhân viên "
                             + ", Mã NV: " + (dlgEditor.MyValue["EmployeeID"].ToString() != null ? dlgEditor.MyValue["EmployeeID"].ToString() : "")
                             + ", Họ: " + (dlgEditor.MyValue["FirstName"].ToString() != null ? dlgEditor.MyValue["FirstName"].ToString() : "")
                             + ", tên : " + (dlgEditor.MyValue["LastName"].ToString() != null ? dlgEditor.MyValue["LastName"].ToString() : "")
                             + ", tên NV : " + (dlgEditor.MyValue["EmployeeName"].ToString() != null ? dlgEditor.MyValue["EmployeeName"].ToString() : "")

                             + ", giới tính : " + (dlgEditor.MyValue["SexID"].ToString() != null ? dlgEditor.MyValue["SexID"].ToString() : "")
                             + ", CMND : " + (dlgEditor.MyValue["IDCard"].ToString() != null ? dlgEditor.MyValue["IDCard"].ToString() : "")
                             + ", nơi cấp CMND : " + (dlgEditor.MyValue["IssuePlace"].ToString() != null ? dlgEditor.MyValue["IssuePlace"].ToString() : "")
                             + ", ngày cấp CMND : " + (dlgEditor.MyValue["IssueDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["IssueDate"])) : "")

                             + ", địa chỉ : " + (dlgEditor.MyValue["NativeCountry"].ToString() != null ? dlgEditor.MyValue["NativeCountry"].ToString() : "")
                             + ", quê quán : " + (dlgEditor.MyValue["Address"].ToString() != null ? dlgEditor.MyValue["Address"].ToString() : "")
                             + ", địa chỉ thường trú : " + (dlgEditor.MyValue["PermanentAddress"].ToString() != null ? dlgEditor.MyValue["PermanentAddress"].ToString() : "")

                             + ", sđt : " + (dlgEditor.MyValue["Phone"].ToString() != null ? dlgEditor.MyValue["Phone"].ToString() : "")
                             + ", tình trạng hôn nhân : " + (dlgEditor.MyValue["MaritalStatusName"].ToString() != null ? dlgEditor.MyValue["MaritalStatusName"].ToString() : "")

                             + ", mã loại NV : " + (dlgEditor.MyValue["EmpTypeID"].ToString() != null ? dlgEditor.MyValue["EmpTypeID"].ToString() : "")
                             + ", tên loại NV : " + (dlgEditor.MyValue["EmpTypeName"].ToString() != null ? dlgEditor.MyValue["EmpTypeName"].ToString() : "")

                             + ", loại hợp đồng : " + (dlgEditor.MyValue["ContractTypeName"].ToString() != null ? dlgEditor.MyValue["ContractTypeName"].ToString() : "")
                             + ", mã hợp đồng : " + (dlgEditor.MyValue["ContractID"].ToString() != null ? dlgEditor.MyValue["ContractID"].ToString() : "")

                             + ", mã phòng ban : " + (dlgEditor.MyValue["DepID_Final"].ToString() != null ? dlgEditor.MyValue["DepID_Final"].ToString() : "")
                             + ", phòng ban : " + (dlgEditor.MyValue["DepName"].ToString() != null ? dlgEditor.MyValue["DepName"].ToString() : "")

                             + ", mã số thuế : " + (dlgEditor.MyValue["IncomeTaxNumber"].ToString() != null ? dlgEditor.MyValue["IncomeTaxNumber"].ToString() : "")
                             + ", ngày số thuế : " + (dlgEditor.MyValue["IncomeTaxDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["IncomeTaxDate"])) : "")

                             + ", số sổ BH : " + (dlgEditor.MyValue["SINo"].ToString() != null ? dlgEditor.MyValue["SINo"].ToString() : "")
                             + ", ngày sổ BH : " + (dlgEditor.MyValue["SIDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["SIDate"])) : "")

                             + ", stk : " + (dlgEditor.MyValue["BankAccount"].ToString() != null ? dlgEditor.MyValue["BankAccount"].ToString() : "")
                             + ", ngân hàng : " + (dlgEditor.MyValue["BankName"].ToString() != null ? dlgEditor.MyValue["BankName"].ToString() : "")

                             + ", emai công ty : " + (dlgEditor.MyValue["mailCongTy"].ToString() != null ? dlgEditor.MyValue["mailCongTy"].ToString() : "")
                             + ", email ngoài : " + (dlgEditor.MyValue["mailNgoai"].ToString() != null ? dlgEditor.MyValue["mailNgoai"].ToString() : "")

                             + ", ngày vào làm : " + (dlgEditor.MyValue["AppliedDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["AppliedDate"])) : "")
                             + ", ngày nghỉ việc : " + (dlgEditor.MyValue["LeftDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(dlgEditor.MyValue["LeftDate"])) : "")

                             + ", không OT : " + (dlgEditor.MyValue["IsNotOT"].ToString() != null ? dlgEditor.MyValue["IsNotOT"].ToString() : "")

                             + ", trình độ : " + (dlgEditor.MyValue["EducationType"].ToString() != null ? dlgEditor.MyValue["EducationType"].ToString() : "")

                             + ", ca làm mặc định : " + (dlgEditor.MyValue["idCaLamMacDinh"].ToString() != null ? dlgEditor.MyValue["idCaLamMacDinh"].ToString() : "")

                             , "tblEmployee"));

                    LogAction.LogAction.PushLog(_lActionClass);

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }

                Provider.ExecNoneQuery("p_updateThongTinLoaiNV", new System.Data.SqlClient.SqlParameter("empID", emp_new.EmployeeID));

                Provider.ExecNoneQuery("p_updateThongTinLuong_Vitri", new System.Data.SqlClient.SqlParameter("empID", emp_new.EmployeeID));

                Provider.ExecNoneQuery("p_updateThongTinHopDong", new System.Data.SqlClient.SqlParameter("empID", emp_new.EmployeeID));

                // Update thông tin vào db máy chấm công.
                var nvCC = dbMCC.tbNhanViens.Where(p => p.maChamCong == maChamCong).FirstOrDefault();
                if (nvCC != null)
                {
                    nvCC.loaiNhanVien = "0";
                    nvCC.tenChamCong = ConvertUnicode.RemoveUnicode(emp_new.EmployeeName);
                    nvCC.maThesHRM = nvCC.maThe = emp_new.CardID;
                    nvCC.trangThai = "Edited";
                }
                else
                {
                    nvCC = new tbNhanVien();
                    nvCC.maChamCong = maChamCong;
                    nvCC.loaiNhanVien = "0";
                    nvCC.maNV = emp_new.EmployeeID;
                    nvCC.tenChamCong = ConvertUnicode.RemoveUnicode(emp_new.EmployeeName);
                    nvCC.maThesHRM = nvCC.maThe = emp_new.CardID;
                    nvCC.trangThai = "No push";
                    dbMCC.tbNhanViens.InsertOnSubmit(nvCC);
                }
                dbMCC.SubmitChanges();

            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        private void btnThemNV_Click_Click(object sender, EventArgs e)
        {
            ShowEditor();

            dlgEditor.CustomFormAction = 0;

            var r = dtData.NewRow();

            r["EmployeeID"] = LoginHelper.Context.getEmployeeID(); //Thêm dlg khi bấm add.

            dlgEditor.MyValue = r;
        }
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (grv.FocusedRowHandle != -1)
            {
                CRow = grv.GetFocusedDataRow();

                ShowEditor();

                dlgEditor.CustomFormAction = 1;

                dlgEditor.MyValue = CRow;
            }
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            CRow = grv.GetFocusedDataRow();
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void txtSearchKey_Leave(object sender, EventArgs e)
        {
            btnFind_Click(sender, e);
        }

        private void toolStripInThe_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("the").ShowDialog();
        }

        private void toolStripInHoSo_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("hoso").ShowDialog();
        }

        private void itemQDThuHoi_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("thuhoi").ShowDialog();
        }

        private void toolInHD_Click(object sender, EventArgs e)
        {
            new frmInHopDong().ShowDialog();
        }

        private void toolStripButInHopDongBH_Click(object sender, EventArgs e)
        {
            new frmInHopDong_Fake().ShowDialog();
        }


        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "leftdate").ToString()))
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("thucanhcao").ShowDialog();
        }

        private void itemCamKetThue_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("camketthue").ShowDialog();
        }

        private void toolStripImXacNhanCongTac_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("xacnhancongtac").ShowDialog();
        }

        private void toolStripGiayTo_Click(object sender, EventArgs e)
        {
            new InGiayTo().ShowDialog();
        }

        private void btnInQuyetDinh_Click(object sender, EventArgs e)
        {
            //new InTheNhanVien("quyetdinhthoiviec").ShowDialog();

            new InQuyetDinhThoiViec().ShowDialog();
        }

        private void toolStripIn_Click(object sender, EventArgs e)
        {
            grv.OptionsPrint.UsePrintStyles = false;

            ShowPreview(grd);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmDangKyCaLam_Load(null, null);
        }

        private void grv_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            if (grv.IsFilterRow(e.RowHandle))

                e.RowHeight = 45;
        }

        private void toolStripInNhatKy_Click(object sender, EventArgs e)
        {
            new InTheNhanVien("NhatKiThuViec").ShowDialog();

            //var rp = new rep_NhatKyThuViec();

            //ReportViewer rv = new ReportViewer();

            //rv.ViewReport(rp);
        }

        private void txtSearchKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }

        private void toolStripButBaoTangBH_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save

            sd.Filter = "Excel 2007|*.xls";

            if (sd.ShowDialog() != DialogResult.OK)

                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))

                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);

                return;
            }
            //---------------- Gọi store BH---------------------

            dataBH = Provider.ExecuteDataTableReader("p_BaoCao_getDataReportBaoTangBH",
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
                );

            //---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới

            ge.OnDoing += (bw) =>
            {
                bw.ReportProgress(-1, "Xuất excel báo tăng bảo hiểm"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (dataBH == null || dataBH.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu

                    return;
                }
                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description

                ExcelExportHelper ex = new ExcelExportHelper("BHXH/TangLaoDongV2_TT595.xls"); // Tạo excel export helper + đường dẫn template

                ex.FillDataTable_XuatBH(dataBH); // Fill BC_FillData

                ex.RendAndFlush("TangLaoDongV2_TT595.xls", sd.FileName);

                bw.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
                }
                else if (ps == 2)
                {
                    // Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.

                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);

                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName,

                            UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }

        private void toolStripButBaoGiamBH_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save

            sd.Filter = "Excel 2007|*.xls";

            if (sd.ShowDialog() != DialogResult.OK)

                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))

                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);

                return;
            }
            //---------------- Gọi store BH---------------------

            dataBH = Provider.ExecuteDataTableReader("p_BaoCao_getDataReportBaoGiamBH",
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
                );

            //---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới

            ge.OnDoing += (bw) =>
            {
                bw.ReportProgress(-1, "Xuất excel báo tăng bảo hiểm"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (dataBH == null || dataBH.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu

                    return;
                }

                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

                ExcelExportHelper ex = new ExcelExportHelper("BHXH/GiamLaoDongV2_TT595.xls"); // Tạo excel export helper + đường dẫn template

                ex.FillDataTable_XuatBH(dataBH); // Fill BC_FillData

                ex.RendAndFlush("GiamLaoDongV2_TT595.xls", sd.FileName);

                bw.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
                }
                else if (ps == 2)
                {
                    // Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.

                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);

                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName,

                            UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }

        private void toolExcelHoSoNhanVien_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save

            sd.Filter = "Excel 2007|*.xls";

            if (sd.ShowDialog() != DialogResult.OK)

                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))

                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);

                return;
            }
            //---------------- Gọi store BH---------------------

            dtData = Provider.ExecuteDataTableReader("p_BaoCao_GetNV_HoSoNhanVien",
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
                );

            //---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới

            ge.OnDoing += (bw) =>
            {
                bw.ReportProgress(-1, "Xuất excel hồ sơ nhân viên"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (dtData == null || dtData.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu

                    return;
                }
                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description

                ExcelExportHelper ex = new ExcelExportHelper("Report/ReportHoSoNhanVien.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("A4", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);
                ex.SetNamedRangeValue("Ngay", "Ngày tạo: " + DateTime.Now.ToString("dd/MM/yyyy"));


                ex.FillDataTable(dtData); // Fill BC_FillData

                ex.RendAndFlush("HoSoNhanVien.xls", sd.FileName);

                bw.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
                }
                else if (ps == 2)
                {
                    // Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.

                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);

                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName,

                            UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }

        private void toolExcelNhanVienNghiViec_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save

            sd.Filter = "Excel 2007|*.xls";

            if (sd.ShowDialog() != DialogResult.OK)

                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))

                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);

                return;
            }
            //---------------- Gọi store BH---------------------

            dtData = Provider.ExecuteDataTableReader("p_BaoCao_GetNV_NhanVienNghiViec",
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
                );

            //---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới

            ge.OnDoing += (bw) =>
            {
                bw.ReportProgress(-1, "Xuất excel hồ sơ nhân viên"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (dtData == null || dtData.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu

                    return;
                }
                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description

                ExcelExportHelper ex = new ExcelExportHelper("Report/ReportNhanVienNghiViec.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("A4", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);
                ex.SetNamedRangeValue("Ngay", "Ngày tạo: " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.FillDataTable(dtData); // Fill BC_FillData

                ex.RendAndFlush("HoSoNhanVien.xls", sd.FileName);

                bw.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
                }
                else if (ps == 2)
                {
                    // Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.

                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);

                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName,

                            UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }

        private void toolExcelHDLD_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save

            sd.Filter = "Excel 2007|*.xls";

            if (sd.ShowDialog() != DialogResult.OK)

                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))

                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);

                return;
            }
            //---------------- Gọi store BH---------------------

            dtData = Provider.ExecuteDataTableReader("p_BaoCao_GetNV_HopDongLaoDong",
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
                );

            //---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới

            ge.OnDoing += (bw) =>
            {
                bw.ReportProgress(-1, "Xuất excel hồ sơ nhân viên"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (dtData == null || dtData.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu

                    return;
                }
                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description

                ExcelExportHelper ex = new ExcelExportHelper("Report/ReportHopDongLaoDong.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("A4", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);
                ex.SetNamedRangeValue("Ngay", "Ngày tạo: " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.FillDataTable(dtData); // Fill BC_FillData

                ex.RendAndFlush("HoSoNhanVien.xls", sd.FileName);

                bw.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
                }
                else if (ps == 2)
                {
                    // Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.

                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);

                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName,

                            UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                try
                {
                    GridControl grid = sender as GridControl;
                    GridView view = grd.FocusedView as GridView;
                    Clipboard.SetText(view.GetFocusedDisplayText());
                    e.Handled = true;
                }
                catch (Exception ex)
                {
                    GUIHelper.MessageError(ex.Message, this.Text);

                    return;
                }
            }
        }

        private void toolInPhuLuc_Click(object sender, EventArgs e)
        {
            new frmInPhuLuc().ShowDialog();
        }

        private void toolInPhuLucBH_Click(object sender, EventArgs e)
        {
            new frmInPhuLuc_Fake().ShowDialog();
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

        private void Employee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmDangKyCaLam_Load(null, null);
            }
        }

        private void toolXoa_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));

            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }
            else
            {
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa nhân viên đã chọn " + drs.First()["EmployeeID"]))
                {
                    _lActionClass.Clear();

                    db = new dcDatabaseDataContext(Provider.ConnectionString);

                    var lst = db.tblEmployees.Where(i => i.EmployeeID == drs.First()["EmployeeID"].ToString());

                    if (lst == null || lst.Count() == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                        return;
                    }
                    try
                    {
                        _lActionClass.Add(new ActionClass("Xóa dữ liệu", drs.First()["EmployeeID"].ToString(), "", "Xóa nhân viên "
                            + ", Mã NV: " + (drs.First()["EmployeeID"].ToString() != null ? drs.First()["EmployeeID"].ToString() : "")
                            + ", Họ: " + (drs.First()["FirstName"].ToString() != null ? drs.First()["FirstName"].ToString() : "")
                            + ", tên : " + (drs.First()["LastName"].ToString() != null ? drs.First()["LastName"].ToString() : "")
                            + ", tên NV : " + (drs.First()["EmployeeName"].ToString() != null ? drs.First()["EmployeeName"].ToString() : "")

                            + ", giới tính : " + (drs.First()["SexID"].ToString() != null ? drs.First()["SexID"].ToString() : "")
                            + ", CMND : " + (drs.First()["IDCard"].ToString() != null ? drs.First()["IDCard"].ToString() : "")
                            + ", nơi cấp CMND : " + (drs.First()["IssuePlace"].ToString() != null ? drs.First()["IssuePlace"].ToString() : "")
                            + ", ngày cấp CMND : " + (drs.First()["IssueDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(drs.First()["IssueDate"])) : "")

                            + ", địa chỉ : " + (drs.First()["NativeCountry"].ToString() != null ? drs.First()["NativeCountry"].ToString() : "")
                            + ", quê quán : " + (drs.First()["Address"].ToString() != null ? drs.First()["Address"].ToString() : "")
                            + ", địa chỉ thường trú : " + (drs.First()["PermanentAddress"].ToString() != null ? drs.First()["PermanentAddress"].ToString() : "")

                            + ", sđt : " + (drs.First()["Phone"].ToString() != null ? drs.First()["Phone"].ToString() : "")
                            + ", tình trạng hôn nhân : " + (drs.First()["MaritalStatusName"].ToString() != null ? drs.First()["MaritalStatusName"].ToString() : "")

                            + ", mã loại NV : " + (drs.First()["EmpTypeID"].ToString() != null ? drs.First()["EmpTypeID"].ToString() : "")
                            + ", tên loại NV : " + (drs.First()["EmpTypeName"].ToString() != null ? drs.First()["EmpTypeName"].ToString() : "")

                            + ", loại hợp đồng : " + (drs.First()["ContractTypeName"].ToString() != null ? drs.First()["ContractTypeName"].ToString() : "")
                            + ", mã hợp đồng : " + (drs.First()["ContractID"].ToString() != null ? drs.First()["ContractID"].ToString() : "")

                            + ", mã phòng ban : " + (drs.First()["DepID_Final"].ToString() != null ? drs.First()["DepID_Final"].ToString() : "")
                            + ", phòng ban : " + (drs.First()["DepName"].ToString() != null ? drs.First()["DepName"].ToString() : "")

                            + ", mã số thuế : " + (drs.First()["IncomeTaxNumber"].ToString() != null ? drs.First()["IncomeTaxNumber"].ToString() : "")
                            + ", ngày số thuế : " + (drs.First()["IncomeTaxDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(drs.First()["IncomeTaxDate"])) : "")

                            + ", số sổ BH : " + (drs.First()["SINo"].ToString() != null ? drs.First()["SINo"].ToString() : "")
                            + ", ngày sổ BH : " + (drs.First()["SIDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(drs.First()["SIDate"])) : "")

                            + ", stk : " + (drs.First()["BankAccount"].ToString() != null ? drs.First()["BankAccount"].ToString() : "")
                            + ", ngân hàng : " + (drs.First()["BankName"].ToString() != null ? drs.First()["BankName"].ToString() : "")

                            + ", emai công ty : " + (drs.First()["mailCongTy"].ToString() != null ? drs.First()["mailCongTy"].ToString() : "")
                            + ", email ngoài : " + (drs.First()["mailNgoai"].ToString() != null ? drs.First()["mailNgoai"].ToString() : "")

                            + ", ngày vào làm : " + (drs.First()["AppliedDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(drs.First()["AppliedDate"])) : "")
                            + ", ngày nghỉ việc : " + (drs.First()["LeftDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(drs.First()["LeftDate"])) : "")

                            + ", không OT : " + (drs.First()["IsNotOT"].ToString() != null ? drs.First()["IsNotOT"].ToString() : "")

                            + ", trình độ : " + (drs.First()["EducationType"].ToString() != null ? drs.First()["EducationType"].ToString() : "")

                            + ", ca làm mặc định : " + (drs.First()["idCaLamMacDinh"].ToString() != null ? drs.First()["idCaLamMacDinh"].ToString() : "")

                            , "tblEmployee"));

                        Provider.ExecNoneQuery("p_DeleteEmployee",
                            new System.Data.SqlClient.SqlParameter("empID", drs.First()["EmployeeID"].ToString()));

                        db.tblEmployees.DeleteAllOnSubmit(lst); //Xóa dữ liệu

                        db.SubmitChanges(); //Lưu vào database

                        LogAction.LogAction.PushLog(_lActionClass); //Lưu lịch sử người dùng

                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);

                        grv.DeleteSelectedRows(); //Cập nhật lại Grid View
                    }
                    catch (Exception ex)
                    {
                        win_globall.ExecCatch(ex);
                    }
                }
            }
        }

    }
}
