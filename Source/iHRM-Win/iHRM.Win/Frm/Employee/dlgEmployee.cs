using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using iHRM.Win.Cls;
using DevExpress.XtraEditors;
using System.IO;
using System.Drawing;

using iHRM.Core.FileDB;
using System.Data.Linq;
using iHRM.Common.Code;
using iHRM.Win.Frm.LogAction;

using System.Data.SqlClient;
using System.Reflection;
using System.Drawing.Imaging;


namespace iHRM.Win.Frm.Employee
{
    public partial class dlgEmployee : dlgBase
    {
        string _empID = "";

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        //DataTable dtEmployee;

        List<Sex> arrSex = new List<Sex>();

        List<DIS> arrDis = new List<DIS>();

        List<Company> arrComp = new List<Company>();

        List<RelationStatus> arrRela = new List<RelationStatus>();

        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
        /// 
        public int CustomFormAction = -1;

        public bool isUpdatedFile = false;

        public int _Flash = 0;

        public bool _ChkLuong = false;

        List<ActionClass> _lActionClass = new List<ActionClass>();
        
        public dlgEmployee()
        {
            InitializeComponent();

            dlgData.IdColumnName = TableConst.tblEmployee.EmployeeID;

            dlgData.CaptionColumnName = TableConst.tblEmployee.EmployeeName;

            dlgData.FormCaption = "Thông tin nhân viên ";
            
            AddControlBinding();
        }

        public dlgEmployee(int Flash)
        {
            InitializeComponent();

            dlgData.IdColumnName = TableConst.tblEmployee.EmployeeID;

            dlgData.CaptionColumnName = TableConst.tblEmployee.EmployeeName;

            dlgData.FormCaption = "Thông tin nhân viên ";

            AddControlBinding();
            
            this._Flash = Flash;

        }
        
        private void dlgEmployee_Load(object sender, EventArgs e)
        {
            TranslateForm();

            LoadPreData();

            tabPhuCap.PageVisible = LoginHelper.user.isAdmin || _ChkLuong;
            tabLuongCoBan.PageVisible = LoginHelper.user.isAdmin || _ChkLuong; 
        }

        private void LoadPreData()
        {
            lookupTinhTrangGD.Properties.DataSource = db.tblRef_MaritalStatus;

            lookupNganHang.Properties.DataSource = db.tblRef_Banks;

            tblEmp_Group1 a = new tblEmp_Group1() { id = 0, gName = "" };

            var lstGroup = db.tblEmp_Group1s.ToList();

            lstGroup.Add(a);

            lookupNhom.Properties.DataSource = lstGroup;

            repLoaiNV.DataSource = db.tblRef_EmployeeTypes;

            lookupContract.DataSource = db.tblRef_ContractTypes;

            TreeListLookUpPB_PB.DataSource = db.tblRef_Departments;

            lookupChucDanh.DataSource = db.tblRef_Positions;

            lookupTrinhDoHocVan.Properties.DataSource = db.tblRef_Educations;

            lookupQuocTich.Properties.DataSource = db.tblRef_Nationalities;

            repAllowance.DataSource = db.tblRef_Allowances;

            lookupLyDoNghiViec.Properties.DataSource = db.tblRef_LeftTypes;

            searchLookUpBHXH_RaceID.Properties.DataSource = db.tblRef_Races;

            searchLookUpBHXH_DiaChiXa.Properties.DataSource = db.tblRef_Wards;

            searchLookUpBHXH_QueQuanXa.Properties.DataSource = db.tblRef_Wards;

            searchLookUpBHXH_NoiCapXa.Properties.DataSource = db.tblRef_Wards;

            searchLookUpNoiCap.Properties.DataSource = db.tblRef_Cities;

            searchLookUpQueQuan.Properties.DataSource = db.tblRef_Cities;

            slk_BHXH_NoiSinhXa.Properties.DataSource = db.tblRef_Wards;

            repLine.DataSource = db.tblRef_Lines;

            repSection.DataSource = db.tblRef_Sections;

            repTeam.DataSource = db.tblRef_Teams;

            repPart.DataSource = db.tblRef_Parts;

            var cl = db.tbCaLamViecs.ToList();

            cbCaLam.Properties.DataSource = cl;

            cbCaLam.EditValue = cl.Where(p => p.caDem.Value).First().id;

            // Lookup DIS

            arrDis = new List<DIS>();

            arrDis.Add(new DIS { DisName = "Direct", dis = "Direct" });

            arrDis.Add(new DIS { DisName = "Indirect", dis = "Indirect" });

            arrDis.Add(new DIS { DisName = "Staff", dis = "Staff" });

            lookupDIS.Properties.DataSource = arrDis;

            // Lookup Company

            arrComp = new List<Company>();

            arrComp.Add(new Company { CompanyName = "YS2" });

            arrComp.Add(new Company { CompanyName = "YS3" });

            lookupCongTy.Properties.DataSource = arrComp;

            // Giới tính

            arrSex = new List<Sex>();

            arrSex.Add(new Sex { SexName = "Nam", SexID = "Nam" });

            arrSex.Add(new Sex { SexName = "Nữ", SexID = "Nữ" });

            lookupGioitinh.Properties.DataSource = arrSex;

            repositoryItemLookUpLoaiHoSo.DataSource = db.tblRef_CurriculumVitaes;

            repositoryItemLookUpNgonNgu.DataSource = db.tblRef_Languages;

            repositoryItemLookUpEditPhanMem.DataSource = db.tblRef_TinHocs;

            repositoryItemLookUpEditGioiThieuNV.DataSource = Provider.ExecuteDataTableReader_SQL(
                string.Format(@"SELECT  AppliedDate AS Date
		                                , EmployeeID AS EmployeeID_New
		                                , DepName_Final
                                        , EmployeeName

                                FROM dbo.tblEmployee

                                WHERE EmployeeID <> '{0}'"
                , _empID));

            lookupEmpTypeCodeID.Properties.DataSource = Provider.ExecuteDataTableReader_SQL(
               string.Format(@"SELECT  * FROM dbo.tblRef_EmployeeCodeType"));

            repLoaiQuanHe.DataSource = db.tblRef_Relations;
            // Lookup Company

            arrRela = new List<RelationStatus>();

            arrRela.Add(new RelationStatus { RelationStatusName = "Bình thường" });
            arrRela.Add(new RelationStatus { RelationStatusName = "Đau ốm" });
            arrRela.Add(new RelationStatus { RelationStatusName = "Tử tuất" });
            arrRela.Add(new RelationStatus { RelationStatusName = "Khác" });

            repRelationStatus.DataSource = arrRela;

        }

        public void visibleTab(bool isVisible)
        {
            tabBaoHiemSLD.PageVisible = isVisible;

            tabThongTinKhac.PageVisible = isVisible;

            tabLichSu.PageVisible = isVisible;

            if(isVisible == true)
            {
                if (MyValue["SexID"] != null)
                {
                    if (MyValue["SexID"].ToString() == "Nữ")
                    {
                        tabThaiSan.PageVisible = isVisible;
                    }
                    else
                    {
                        tabThaiSan.PageVisible = !isVisible;
                    }
                }
            }
        }

        protected override void FormGetData()
        {
            base.FormGetData();

            MyValue["hinhthuctraluong"] = chkTraLuongQuaNH.Checked ? "1" : "0";

            if (MyValue["idFile"] != DBNull.Value)
            {
                MyValue["idFile"] = MyValue["idFile"];
            }
            else
            {
                MyValue["idFile"] = DBNull.Value;
            }
        }

        protected override void FormSetData()
        {
            base.FormSetData();

            _empID = myID as string;

            if (MyValue["hinhthuctraluong"] != DBNull.Value && MyValue["hinhthuctraluong"].ToString() == "1")
            {
                chkTraLuongQuaNH.Checked = true;
            }
            else
            {
                chkTraLuongQuaNH.Checked = false;
            }
            if (MyValue["dataFile"] != DBNull.Value)
            {
                pictureEditIcon.EditValue = MyValue["dataFile"] as byte[];
            }
            else
            {
                pictureEditIcon.EditValue = null;
            }

            menuRefresh_LoaiNV_Click(null, null);

            tabControlThongTinKhac.SelectedTabPage = tabLoaiNV;

            DataTable data = new DataTable();

            data = Provider.ExecuteDataTableReader("p_BaoCao_GettbLogs_tblEmployee",
                    new SqlParameter("EmployeeID", MyValue["EmployeeID"].ToString()),
                    new SqlParameter("tuNgay", null),
                    new SqlParameter("denNgay", null)
                 );

            if (data.Rows.Count > 0)
            {
                grd_LichSu.DataSource = data;
            }
            else
            {
                grd_LichSu.DataSource = null;
            }

            txtMaNV.Size = new System.Drawing.Size(160, 22);
            txtMaNV.Location = new Point(93, 6);

            lookupEmpTypeCodeID.Visible = false;

            if (CustomFormAction == 0) //Nếu là button Bao Hiểm Xã Hội và Thông Tin Khác không hiển thị
            {
                visibleTab(false);
                lookupEmpTypeCodeID.Visible = true;

                txtMaNV.Size = new System.Drawing.Size(99, 22);
                txtMaNV.Location = new Point(154, 6);

                lookupEmpTypeCodeID.Size = new System.Drawing.Size(58, 22);
                lookupEmpTypeCodeID.Location = new Point(93, 6);
            }
            else
            {
                visibleTab(true);
                lookupEmpTypeCodeID.Visible = false;

                txtMaNV.Size = new System.Drawing.Size(160, 22);
                txtMaNV.Location = new Point(93, 6);

                if (_Flash == 1)
                {
                    visibleTab(false);
                    panelControl1.Enabled = false;
                    buttonPanel1.Visible = false;
                    groupCMND.Enabled = false;
                    groupNganHang.Enabled = false;
                    groupLuong.Enabled = false;
                }
            }
            //dtEmployee = Provider.ExecuteDataTableReader_SQL("SELECT * FROM tblEmployee WHERE EmployeeID ='" + _empID + "'");
        }

        private void GetAllDataInTaBle_ByEmpID(string EmpID, string TableName, GridControl grc)
        {
            grc.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM {0} WHERE EmployeeID = '{1}'", TableName, EmpID));
        }

        private void groupControl3_MouseHover(object sender, EventArgs e)
        {
            txtLuong.Visible = true;

            txtPhuCap.Visible = true;
        }

        private void groupControl3_MouseLeave(object sender, EventArgs e)
        {
            txtLuong.Visible = false;

            txtPhuCap.Visible = false;
        }

        public void AddControlBinding()
        {
            //Start thông tin cơ bản
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.EmployeeID, txtMaNV, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.OldEmployeeID, txtMaNVCu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.FirstName, txtHo, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LastName, txtTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.EmployeeName, txtHoTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.MaritalStatusID, lookupTinhTrangGD, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.Birthday, dateNgaySinh, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("LayNamSinh", chkLayNamSinh, ControlBinding_DataType.Bool));// lấy năm sinh xuất ra báo cáo Trọng 19/09/2017
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.SexID, lookupGioitinh, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.Phone, txtSDT, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.CardID, txtSoThe, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.AppliedDate, dateNgayVaoLam, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.SubmitDate, dateNgayNopHoSo, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.ContractDate, dateNgayKyHopDong, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.InGroup1, lookupNhom, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.EducationID, lookupTrinhDoHocVan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.NationalityID, lookupQuocTich, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("TradeUnionDate", dateNgayVaoDoan, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("SoQuyetDinh", txtSoQD, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.mailCongTy, txtMailCongTy, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.mailNgoai, txtMailNgoai, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.dis, lookupDIS, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.CompanyName, lookupCongTy, ControlBinding_DataType.String));
            // Start CMND:
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.IDCard, txtSoCMND, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("IssuePlaceID", searchLookUpNoiCap, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("NativeCountryID", searchLookUpQueQuan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.IssueDate, dateNgayCap, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.Address, txtDiaChi, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.PermanentAddress, txtDiaChiThuongTru, ControlBinding_DataType.String));

            // Start Tài Khoản Ngân Hàng
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.BankAccount, txtSoTaiKhoan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.BankNameAcount, txtTenTaiKhoan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.BankID, lookupNganHang, ControlBinding_DataType.String));

            //Lương 
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.BasicSalary, txtLuong, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.RegularAllowance, txtPhuCap, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.AnnualLeave, txtSoNgayNghi, ControlBinding_DataType.Float));

            //Thôi việc
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LeftDate, dateNgayNghiViec, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LeftTypeID, lookupLyDoNghiViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.FinalPaymentDate, dateNgayTraLuongCuoi, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.ReasonForLeft, txtQuyetDinhSo, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LeftDateReg, dateNgayNopDon, ControlBinding_DataType.DateTime));
            //dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.LeftTypeID, chkDaThoiViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.IsNotOT, chkIsNotOT, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.idCaLamMacDinh, cbCaLam, ControlBinding_DataType.Guid));

            //Bảo hiểm xã hội
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.SI, chkDaCapSoBH, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.SINo, txtSoBH, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.SIDate, dateNgayCapBH, ControlBinding_DataType.DateTime));

            dlgData.CB.Add(new ControlBinding("BHXH_NoiSinhTo", txt_BHXH_NoiSinhTo, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BHXH_NoiSinhXa", slk_BHXH_NoiSinhXa, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BHXH_DiaChiTo", txt_BHXH_DiaChiTo, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BHXH_DiaChiXa", searchLookUpBHXH_DiaChiXa, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BHXH_RaceID", searchLookUpBHXH_RaceID, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding("BHXH_NoiCapXa", searchLookUpBHXH_NoiCapXa, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BHXH_QueQuanXa", searchLookUpBHXH_QueQuanXa, ControlBinding_DataType.String));
            // Bảo hiểm y tế 
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.HI, chkDaCapTheBHYT, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.HINo, txtSoBHYT, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.HIDate, dateNgayKyBHYT, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.HIIssueAt, txtNoiDKyKCBBD, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding(TableConst.tblEmployee.HIFrom_MY, dateNgayBatDauTheBHYT, ControlBinding_DataType.DateTime));
            // Mã số thuế
            dlgData.CB.Add(new ControlBinding("IncomeTax", chkDaCapMST, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("IncomeTaxNumber", txtMST, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("IncomeTaxDate", dateNgayCapMST, ControlBinding_DataType.DateTime));
        }

        #region menuDelete
        private void menuDelete_LoaiNV_Click(object sender, EventArgs e)
        {
            deleteRecord(grvLoaiNV);
            //menuSave_LoaiNV_Click(null, null);
        }
        private void menuDelete_PB_Click(object sender, EventArgs e)
        {
            deleteRecord(grvPhongBan);
            //menuSave_PB_Click(null, null);
        }
        private void menuDelete_LuongCB_Click(object sender, EventArgs e)
        {
            deleteRecord(grvLuongCB);
            //menuSave_LuongCB_Click(null, null);
        }
        private void menuDelete_PhuCapHT_Click(object sender, EventArgs e)
        {
            deleteRecord(grvPhuCapHangThang);
            //menuSave_PhuCapHT_Click(null, null);
        }
        private void menuDelete_HopDong_Click(object sender, EventArgs e)
        {
            deleteRecord(grvHopDong);
            //menuSave_HopDong_Click(null, null);
        }
        private void menuDelete_ConTho_Click(object sender, EventArgs e)
        {
            deleteRecord(grvConTho);
            //menuSave_ConTho_Click(null, null);
        }
        private void menuDelete_GioiThieu_Click(object sender, EventArgs e)
        {
            deleteRecord(grvGioiThieu);
            //menuSave_GioiThieu_Click(null, null);
        }
        private void menuDelete_KNNgoaiNgu_Click(object sender, EventArgs e)
        {
            deleteRecord(grvKNNgoaiNgu);
        }
        private void menuDelete_KNMayTinh_Click(object sender, EventArgs e)
        {
            deleteRecord(grvKNMayTinh);
        }
        private void menuDelete_Files_Click(object sender, EventArgs e)
        {
            deleteRecord(grvFilesLienQuan);
        }

        private void menuDelete_ThaiSan_Click(object sender, EventArgs e)
        {
            deleteRecord(grvThaiSan);
        }

        private void menuDelete_QuanHe_Click(object sender, EventArgs e)
        {
            deleteRecord(grvQuanHe);
            //menuSave_LuongCB_Click(null, null);
        }

        private void deleteRecord(GridView grv)
        {
            //lay thong tin cac dong dc chon
            int[] idx = grv.GetSelectedRows();//GetSelectedRows tra lai index cua row dc chon

            if (idx.Length == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }

            var rows = idx.Select(i => grv.GetDataRow(i)); // GetDataRow tra lai dataarow cua datatable

            if (GUIHelper.ConfirmBox(string.Format("Bạn muốn xóa {0} bản ghi đã chọn?", rows.Count()), "Xác nhận lại"))
            {
                foreach (DataRow r in rows)

                    r.Delete();
                //r.Table.Rows.Remove(r);
            }
        }
        #endregion

        #region menuFresh
        private void menuRefresh_LoaiNV_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpType", grcLoaiNV); //load du lieu ve dt

            (grcLoaiNV.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_PB_Click(object sender, EventArgs e)
        {
            DataTable dt = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM tblEmpDep WHERE EmployeeID = '{0}'", _empID));
            grcPhongBan.DataSource = dt;

            (grcPhongBan.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_LuongCB_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpSalary", grcLuongCB); //load du lieu ve dt

            repositoryItemLookUpEditContractID.DataSource = db.tblEmpContracts.Where(p => p.EmployeeID == _empID).OrderBy(p => p.BeginDate).OrderBy(p => p.idx).Select(p => new { ContractID = p.ContractID });

            (grcLuongCB.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_PhuCapHT_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpAllowanceFix", grcPhuCapHangThang); //load du lieu ve dt

            (grcPhuCapHangThang.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_HopDong_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpContract", grcHopDong);

            (grcHopDong.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_ConTho_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpChild", grcConTho);

            (grcConTho.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_GioiThieu_Click(object sender, EventArgs e)
        {
            grcGioiThieu.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT gt.*,e.DepName_Final,e.EmployeeName FROM tbGioiThieuCongNhan gt  left join tblEmployee e on gt.EmployeeID_New = e.EmployeeID WHERE gt.EmployeeID = '{0}'", _empID));

            (grcGioiThieu.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_KNNgoaiNgu_Click(object sender, EventArgs e)
        {
            grcKNNgoaiNgu.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * from  tblEmployeeID_KyNangNgoaiNgu WHERE EmployeeID = '{0}' order by idx ", _empID));

            (grcKNNgoaiNgu.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }

        private void menuRefresh_KNMayTinh_Click(object sender, EventArgs e)
        {
            grcKNMayTinh.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * from tblEmployee_KyNangMayTinh WHERE EmployeeID = '{0}' order by idx ", _empID));

            (grcKNMayTinh.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }
        private void menuRefresh_Files_Click(object sender, EventArgs e)
        {
            var a = Provider.ExecuteDataTableReader("p_tblEmpFilesLienQuan_GetbyEmpID", new System.Data.SqlClient.SqlParameter("idEmpID", _empID));

            a.Columns.Add("idFileDelete");

            grcFilesLienQuan.DataSource = a;

            (grcFilesLienQuan.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }

        private void menuRefresh_ThaiSan_Click(object sender, EventArgs e)
        {
            grcThaiSan.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * from tblEmpMaternity WHERE EmployeeID = '{0}' order by Offdays ", _empID));

            (grcThaiSan.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }

        private void menuRefresh_QuanHe_Click(object sender, EventArgs e)
        {
            GetAllDataInTaBle_ByEmpID(_empID, "tblEmpRelation", grcQuanHe);

            (grcQuanHe.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (vua lay ve ko co gi thay doi)
        }

        #endregion

        #region menuSave
        private void menuSave_LoaiNV_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            DataTable dt = (grcLoaiNV.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcLoaiNV.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu", _empID, "", "Thêm dữ liệu loại nhân viên bảng nhân viên ngày: " 
                            + string.Format("{0: dd/MM/yyyy}",Convert.ToDateTime(row["DateChange"])) 
                            + ", mã loại nhân viên: " + row["EmpTypeID"].ToString()  
                            + ", loại nhân viên: " + db.tblRef_EmployeeTypes.Where(p => p.EmpTypeID == row["EmpTypeID"].ToString()).First().EmpTypeName
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpType"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Sửa dữ liệu", _empID, "", "Sửa dữ liệu loại nhân viên bảng nhân viên ngày: " 
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["DateChange"])) 
                            + ", mã loại nhân viên: " + row["EmpTypeID"].ToString() 
                            + ", loại nhân viên: " + db.tblRef_EmployeeTypes.Where(p => p.EmpTypeID == row["EmpTypeID"].ToString()).First().EmpTypeName
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpType"));
                    }
                }
                else
                {
                    var EmpTypeID = row["EmpTypeID", DataRowVersion.Original];

                    var DateChange = row["DateChange", DataRowVersion.Original];

                    var Notes = row["Notes", DataRowVersion.Original];

                    _lActionClass.Add(new ActionClass("Xóa dữ liệu", _empID, "", "Xóa dữ liệu loại nhân viên bảng nhân viên ngày: " 
                        + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime( DateChange)) 
                        + ", mã loại nhân viên: " + EmpTypeID.ToString() 
                        + ", loại nhân viên: " + db.tblRef_EmployeeTypes.Where(p => p.EmpTypeID == EmpTypeID.ToString()).First().EmpTypeName
                        + ", ghi chú: " + Notes.ToString()
                        , "tblEmpType"));
                }
            }

            Provider.UpdateData((grcLoaiNV.DataSource as DataTable), "tblEmpType");

            LogAction.LogAction.PushLog(_lActionClass);

            (grcLoaiNV.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)

            Provider.ExecNoneQuery("p_updateThongTinLoaiNV", new System.Data.SqlClient.SqlParameter("empID", _empID));

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_PB_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            var dt = (grcPhongBan.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }
            foreach (DataRow row in dt.GetChanges().Rows)
            {
                if (!(row.RowState == DataRowState.Deleted))
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        var LineID = row["LineID"].ToString() == "" ? "" : row["LineID"];

                        var LineName = row["LineID"].ToString() == "" ? "" : db.tblRef_Lines.Where(p => p.LineID == LineID.ToString()).First().LineName;

                        var SectionID = row["SectionID"].ToString() == "" ? "" : row["SectionID"];

                        var SectionName = row["SectionID"].ToString() == "" ? "" : db.tblRef_Sections.Where(p => p.SectionID == SectionID.ToString()).First().SectionName;

                        _lActionClass.Add(new ActionClass("Thêm dữ liệu", _empID, "", "Thêm dữ liệu phòng ban bảng nhân viên ngày: " 
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["DateChange"])) 
                            + ", mã phòng ban: " + row["DepID"].ToString()
                            + ", phòng ban: " + db.tblRef_Departments.Where(p => p.DepID == row["DepID"].ToString()).First().DepName
                            + ", mã chuyền: " + LineID.ToString()
                            + ", tên chuyền: " + LineName.ToString()
                            + ", mã công đoạn: " + SectionID.ToString()
                            + ", tên công đoạn: " + SectionName.ToString()
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpDep"));
                    }
                    else
                    {
                        var LineID = row["LineID"].ToString() == "" ? "" : row["LineID"];

                        var LineName = row["LineID"].ToString() == "" ? "" : db.tblRef_Lines.Where(p => p.LineID == LineID.ToString()).First().LineName;

                        var SectionID = row["SectionID"].ToString() == "" ? "" : row["SectionID"];

                        var SectionName = row["SectionID"].ToString() == "" ? "" : db.tblRef_Sections.Where(p => p.SectionID == SectionID.ToString()).First().SectionName;

                        _lActionClass.Add(new ActionClass("Sửa dữ liệu", _empID, "", "Sửa dữ liệu phòng ban bảng nhân viên ngày: " 
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["DateChange"])) 
                            + ", mã phòng ban: " + row["DepID"].ToString() 
                            + ", phòng ban: " + db.tblRef_Departments.Where(p => p.DepID == row["DepID"].ToString()).First().DepName
                            + ", mã chuyền: " + LineID.ToString()
                            + ", tên chuyền: " + LineName.ToString()
                            + ", mã công đoạn: " + SectionID.ToString()
                            + ", tên công đoạn: " + SectionName.ToString()
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpDep"));
                    }
                }
                else
                {
                    var DepID = row["DepID", DataRowVersion.Original];

                    var DateChange = row["DateChange", DataRowVersion.Original];

                    var LineID = row["LineID", DataRowVersion.Original].ToString() == "" ? "" : row["LineID", DataRowVersion.Original];

                    var LineName = row["LineID", DataRowVersion.Original].ToString() == "" ? "" : db.tblRef_Lines.Where(p => p.LineID == LineID.ToString()).First().LineName;

                    var SectionID = row["SectionID", DataRowVersion.Original].ToString() == "" ? "" : row["SectionID", DataRowVersion.Original];

                    var SectionName = row["SectionID", DataRowVersion.Original].ToString() == "" ? "" : db.tblRef_Sections.Where(p => p.SectionID == SectionID.ToString()).First().SectionName;

                    var Notes = row["Notes", DataRowVersion.Original];

                    _lActionClass.Add(new ActionClass("Xóa dữ liệu", _empID, "", "Xóa dữ liệu phòng ban bảng nhân viên ngày: " 
                        + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime( DateChange)) 
                        + ", mã phòng ban: " + DepID.ToString() 
                        + ", phòng ban: " + db.tblRef_Departments.Where(p => p.DepID == DepID.ToString()).First().DepName
                        + ", mã chuyền: " + LineID.ToString()
                        + ", tên chuyền: " + LineName.ToString()
                        + ", mã công đoạn: " + SectionID.ToString()
                        + ", tên công đoạn: " + SectionName.ToString()
                        + ", ghi chú " + Notes.ToString()
                        , "tblEmpDep"));
                }
            }

            Provider.UpdateData(dt, "tblEmpDep");

            (grcPhongBan.DataSource as DataTable).AcceptChanges();

            if (dt.Rows.Count > 0)
            {
                db = new dcDatabaseDataContext(Provider.ConnectionString);

                var empDep = db.tblEmpDeps.Where(p => p.EmployeeID == dt.Rows[0]["EmployeeID"].ToString()).OrderByDescending(p => p.DateChange).First();

                string DepID_Final = empDep.DepID;

                var emp = db.tblEmployees.Where(p => p.EmployeeID == dt.Rows[0]["EmployeeID"].ToString()).First();

                emp.DepID_Final = DepID_Final;

                emp.DepName_Final = db.tblRef_Departments.Where(p => p.DepID == DepID_Final).First().DepName;

                emp.DepName = emp.DepName_Final;

                emp.LineID = empDep.LineID == null ? "" : empDep.LineID;

                emp.LineName = empDep.LineID != null 
                                    ? db.tblRef_Lines.Where(p => p.LineID == empDep.LineID).First().LineName : "";

                emp.SectionID = empDep.SectionID == null ? "" : empDep.SectionID;

                emp.SectionName = empDep.SectionID != null 
                                    ? db.tblRef_Sections.Where(p => p.SectionID == empDep.SectionID).First().SectionName : "";

                _lActionClass.Add(new ActionClass("Cập nhật dữ liệu"
                                                    , _empID
                                                    , ""
                                                    , "Cập nhật phòng ban nhân viên do thay đổi phòng ban: " + emp.DepName_Final + ", mã: " + emp.DepID_Final
                                                    + ", mã chuyền: " + emp.LineID + " - tên chuyền: " + emp.LineName
                                                    + ", mã công đoạn: " + emp.SectionID + " - tên công đoạn: " + emp.SectionName
                                                    , "tblEmployee"));
            }
            else
            {
                var emp = db.tblEmployees.Where(p => p.EmployeeID == _empID).First();

                emp.DepID_Final = null;

                emp.DepName = null;

                emp.DepName_Final = null;

                emp.LineID = null;

                emp.LineName = null;

                emp.SectionID = null;

                emp.SectionName = null;
            }

            db.SubmitChanges();

            LogAction.LogAction.PushLog(_lActionClass);

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_LuongCB_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            var dt = (grcLuongCB.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcLuongCB.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu", _empID, "", "Thêm dữ liệu lương cơ bản bảng nhân viên ngày: " 
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["DateChange"]))
                            + ", mã chức vụ: " + (row["PosID"] != DBNull.Value ? row["PosID"].ToString() : "")
                            + ", chức vụ: " + (row["PosID"] != DBNull.Value ? db.tblRef_Positions.Where(p => p.PosID == row["PosID"].ToString()).First().PosName : "")
                            + ", lương CB: " + (row["BasicSalary"] != DBNull.Value ? row["BasicSalary"].ToString() : "")
                            + ", số HĐ: " + (row["ContractCode"] != DBNull.Value ? row["ContractCode"].ToString() : "")
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpSalary"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Sửa dữ liệu", _empID, "", "Sửa dữ liệu lương cơ bản bảng nhân viên ngày: "
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["DateChange"]))
                            + ", mã chức vụ: " + (row["PosID"] != DBNull.Value ? row["PosID"].ToString() : "")
                            + ", chức vụ: " + (row["PosID"] != DBNull.Value ? db.tblRef_Positions.Where(p => p.PosID == row["PosID"].ToString()).First().PosName : "")
                            + ", lương CB: " + (row["BasicSalary"] != DBNull.Value ? row["BasicSalary"].ToString() : "")
                            + ", số HĐ: " + (row["ContractCode"] != DBNull.Value ? row["ContractCode"].ToString() : "")
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpSalary"));
                    }
                }
                else
                {
                    var DateChange = row["DateChange", DataRowVersion.Original];

                    var PosID = row["PosID", DataRowVersion.Original];

                    var BasicSalary = row["BasicSalary", DataRowVersion.Original];

                    var ContractCode = row["ContractCode", DataRowVersion.Original];

                    var Notes = row["Notes", DataRowVersion.Original];

                    _lActionClass.Add(new ActionClass("Xóa dữ liệu", _empID, "", "Xóa dữ liệu lương cơ bản bảng nhân viên ngày: " 
                        + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(DateChange)) 
                        + ", mã chức vụ: " + PosID.ToString() 
                        + ", chức vụ: " + db.tblRef_Positions.Where(p => p.PosID == PosID).First().PosName
                        + ", lương CB: " + BasicSalary.ToString() 
                        + ", số HĐ: " + ContractCode.ToString() 
                        + ", ghi chú: " + Notes.ToString()
                        , "tblEmpSalary"));
                }
            }

            Provider.UpdateData((grcLuongCB.DataSource as DataTable), "tblEmpSalary");

            LogAction.LogAction.PushLog(_lActionClass);

            (grcLuongCB.DataSource as DataTable).AcceptChanges();

            Provider.ExecNoneQuery("p_updateThongTinLuong_Vitri", new System.Data.SqlClient.SqlParameter("empID", _empID));

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_PhuCapHT_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            var dt = (grcPhuCapHangThang.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcPhuCapHangThang.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu", _empID, "", "Thêm dữ liệu phụ cấp cố định bảng nhân viên ngày: " 
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["DateChange"]))
                            + ", số tiền phụ cấp: " + (row["Amount"] != DBNull.Value ? row["Amount"].ToString() : "")
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpAllowanceFix"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Sửa dữ liệu", _empID, "", "Sửa dữ liệu phụ cấp cố định bảng nhân viên ngày: " 
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["DateChange"]))
                            + ", số tiền phụ cấp: " + (row["Amount"] != DBNull.Value ? row["Amount"].ToString() : "")
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpAllowanceFix"));
                    }
                }
                else
                {
                    var DateChange = row["DateChange", DataRowVersion.Original];
                    var AllowanceID = row["AllowanceID", DataRowVersion.Original];
                    var Amount = row["Amount", DataRowVersion.Original];
                    var Notes = row["Notes", DataRowVersion.Original];

                    _lActionClass.Add(new ActionClass("Xóa dữ liệu", _empID, "", "Xóa dữ liệu phụ cấp cố định bảng nhân viên ngày: " 
                        + string.Format("{0: dd/MM/yyyy}",Convert.ToDateTime( DateChange))  
                        + ", số tiền phụ cấp: " + Amount.ToString() 
                        + ", ghi chú: " + Notes.ToString()
                        , "tblEmpAllowanceFix"));
                }
            }

            Provider.UpdateData((grcPhuCapHangThang.DataSource as DataTable), "tblEmpAllowanceFix");

            LogAction.LogAction.PushLog(_lActionClass);

            (grcPhuCapHangThang.DataSource as DataTable).AcceptChanges();

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_HopDong_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            var dt = (grcHopDong.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcHopDong.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {

                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu", _empID, "", "Thêm dữ liệu hợp đồng bảng nhân viên từ ngày: " 
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["BeginDate"])) 
                            + (row["EndDate"] != DBNull.Value  ? " đến ngày; " + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["EndDate"])) : "")
                            + ", số HĐ; " + row["ContractID"].ToString() 
                            + ", mã loại HĐ: " + row["ContractTypeID"].ToString() 
                            + ", loại HĐ: " + db.tblRef_ContractTypes.Where(p => p.ContractTypeID == row["ContractTypeID"].ToString()).First().ContractTypeName
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpContract"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Sửa dữ liệu", _empID, "", "Sửa dữ liệu hợp đồng bảng nhân viên từ ngày: " 
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["BeginDate"])) 
                            + (row["EndDate"] != DBNull.Value ? " đến ngày: " +  string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["EndDate"])) : "")
                            + ", số HĐ: " + row["ContractID"].ToString() 
                            + ", mã loại HĐ: " + row["ContractTypeID"].ToString() 
                            + ", loại HĐ: " + db.tblRef_ContractTypes.Where(p => p.ContractTypeID == row["ContractTypeID"].ToString()).First().ContractTypeName
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpContract"));
                    }
                }
                else
                {

                    var BeginDate = row["BeginDate", DataRowVersion.Original];

                    var EndDate = row["EndDate", DataRowVersion.Original];

                    var ContractID = row["ContractID", DataRowVersion.Original];

                    var ContractTypeID = row["ContractTypeID", DataRowVersion.Original];

                    var Notes = row["Notes", DataRowVersion.Original];

                    _lActionClass.Add(new ActionClass("Xóa dữ liệu", _empID, "", "Xóa dữ liệu hợp đồng bảng nhân viên từ ngày: " 
                        + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(BeginDate)) 
                        + (EndDate != null ? " đến ngày: " +  string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(EndDate)) : "")
                        + ", số HĐ: " + ContractID.ToString() 
                        + ", mã loại HĐ: " + ContractTypeID.ToString() 
                        + ", loại HĐ: " + db.tblRef_ContractTypes.Where(p => p.ContractTypeID == ContractTypeID.ToString()).First().ContractTypeName
                        + ", ghi chú: " + Notes.ToString()
                        , "tblEmpContract"));
                }
            }

            Provider.UpdateData((grcHopDong.DataSource as DataTable), "tblEmpContract");

            LogAction.LogAction.PushLog(_lActionClass);

            (grcHopDong.DataSource as DataTable).AcceptChanges();

            Provider.ExecNoneQuery("p_updateThongTinHopDong", new System.Data.SqlClient.SqlParameter("empID", _empID));

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_ConTho_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            var dt = (grcConTho.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcConTho.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Thêm dữ liệu con thơ bảng nhân viên"
                                                            , "tblEmpChild"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Sửa dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Thêm dữ liệu con thơ bảng nhân viên"
                                                            , "tblEmpChild"));
                    }
                }
                else
                {
                    _lActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                        , _empID
                                                        , ""
                                                        , "Xóa dữ liệu con thơ bảng nhân viên"
                                                        , "tblEmpChild"));
                }
            }

            Provider.UpdateData((grcConTho.DataSource as DataTable), "tblEmpChild");

            LogAction.LogAction.PushLog(_lActionClass);

            (grcConTho.DataSource as DataTable).AcceptChanges();

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_GioiThieu_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            var dt = (grcGioiThieu.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcGioiThieu.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Thêm dữ liệu giới thiệu công nhân bảng nhân viên"
                                                            , "tbGioiThieuCongNhan"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Sửa dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Thêm dữ liệu giới thiệu công nhân bảng nhân viên"
                                                            , "tbGioiThieuCongNhan"));
                    }
                }
                else
                {
                    _lActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                        , _empID
                                                        , ""
                                                        , "Xóa dữ liệu giới thiệu công nhân bảng nhân viên"
                                                        , "tbGioiThieuCongNhan"));
                }
            }

            Provider.UpdateData((grcGioiThieu.DataSource as DataTable), "tbGioiThieuCongNhan"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)

            LogAction.LogAction.PushLog(_lActionClass); //Lưu lịch sử người dùng

            (grcGioiThieu.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_KNMayTinh_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            var dt = (grcKNMayTinh.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcKNMayTinh.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Thêm dữ liệu kỹ năng máy tính bảng nhân viên"
                                                            , "tblEmployee_KyNangMayTinh"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Sửa dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Thêm dữ liệu kỹ năng máy tính bảng nhân viên"
                                                            , "tblEmployee_KyNangMayTinh"));
                    }
                }
                else
                {
                    _lActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                        , _empID
                                                        , ""
                                                        , "Xóa dữ liệu kỹ năng máy tính bảng nhân viên"
                                                        , "tblEmployee_KyNangMayTinh"));
                }
            }

            Provider.UpdateData((grcKNMayTinh.DataSource as DataTable), "tblEmployee_KyNangMayTinh");

            LogAction.LogAction.PushLog(_lActionClass);

            (grcKNMayTinh.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_KNNgoaiNgu_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            DataTable dt = (grcKNNgoaiNgu.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcKNNgoaiNgu.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Thêm dữ liệu kỹ năng ngoại ngữ bảng nhân viên"
                                                            , "tblEmployeeID_KyNangNgoaiNgu"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Sửa dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Thêm dữ liệu kỹ năng ngoại ngữ bảng nhân viên"
                                                            , "tblEmployeeID_KyNangNgoaiNgu"));
                    }
                }
                else
                {
                    _lActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                        , _empID
                                                        , ""
                                                        , "Xóa dữ liệu kỹ năng ngoại ngữ bảng nhân viên"
                                                        , "tblEmployeeID_KyNangNgoaiNgu"));
                }
            }
            Provider.UpdateData((grcKNNgoaiNgu.DataSource as DataTable), "tblEmployeeID_KyNangNgoaiNgu"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)

            LogAction.LogAction.PushLog(_lActionClass);

            (grcKNNgoaiNgu.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_Files_Click(object sender, EventArgs e)
        {
            DataTable dt = (grcFilesLienQuan.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }

            FileStorageHelper fg = new FileStorageHelper();

            var count = dt.GetChanges().Rows.Count;

            try
            {
                _lActionClass.Clear();

                foreach (DataRow row in (grcFilesLienQuan.DataSource as DataTable).GetChanges().Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (row["idFile"] != DBNull.Value)
                        {
                            fg.InsertOrUpdateDBFiles(Guid.Parse(row["idFile"].ToString()), row["dataFile"] as byte[], row["duoiFile"].ToString());

                            if (row.RowState == DataRowState.Added)
                            {
                                _lActionClass.Add(new ActionClass("Thêm dữ liệu", _empID, "", "Thêm dữ liệu file liên quan bảng nhân viên"
                                    + ", ghi chú: " + (row["ghiChu"] != DBNull.Value ? row["ghiChu"].ToString() : "")
                                   , "tblEmpFilesLienQuan"));
                            }
                            else
                            {
                                _lActionClass.Add(new ActionClass("Sửa dữ liệu", _empID, "", "Sửa dữ liệu file liên quan bảng nhân viên"
                                    + ", ghi chú: " + (row["ghiChu"] != DBNull.Value ? row["ghiChu"].ToString() : "")
                                    , "tblEmpFilesLienQuan"));
                            }
                        }
                        else
                        {
                            if (row["idFileDelete"] != DBNull.Value)
                            {
                                fg.DeleteFileByIDDBFiles(Guid.Parse(row["idFileDelete"].ToString()));

                                var ghiChu = row["ghiChu", DataRowVersion.Original];

                                _lActionClass.Add(new ActionClass("Xóa dữ liệu", _empID, "", "Xóa dữ liệu file liên quan bảng nhân viên"
                                    + ", ghi chú: " + ghiChu.ToString()
                                    , "tblEmpFilesLienQuan"));
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

                        _lActionClass.Add(new ActionClass("Xóa dữ liệu", _empID, "", "Xóa dữ liệu file liên quan bảng nhân viên"
                            + ", ghi chú: " + ghiChu.ToString()
                            , "tblEmpFilesLienQuan"));
                    }
                }

                Provider.UpdateData(dt, "tblEmpFilesLienQuan");

                LogAction.LogAction.PushLog(_lActionClass);

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void menuSave_ThaiSan_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            DataTable dt = (grcThaiSan.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcThaiSan.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Thêm dữ liệu thai sản nhân viên"
                                                            , "tblEmpMaternity"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Sửa dữ liệu"
                                                            , _empID
                                                            , ""
                                                            , "Sửa dữ liệu thai sản nhân viên"
                                                            , "tblEmpMaternity"));
                    }
                }
                else
                {
                    _lActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                        , _empID
                                                        , ""
                                                        , "Xóa dữ liệu thai sản nhân viên"
                                                        , "tblEmpMaternity"));
                }
            }
            Provider.UpdateData((grcThaiSan.DataSource as DataTable), "tblEmpMaternity"); //cap nhat tat ca nhung gi thay doi tren dt toi db (them,sua,xoa)

            LogAction.LogAction.PushLog(_lActionClass);

            (grcThaiSan.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        private void menuSave_QuanHe_Click(object sender, EventArgs e)
        {
            _lActionClass.Clear();

            DataTable dt = (grcQuanHe.DataSource as DataTable);

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }
            foreach (DataRow row in (grcQuanHe.DataSource as DataTable).GetChanges().Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu", _empID, "", "Thêm dữ liệu quan hệ gia đình bảng nhân viên ngày: "
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["RecievedDate"]))
                            + ", mã loại quan hệ gia đình: " + row["RelationID"].ToString()
                            + ", loại quan hệ gia đình: " + db.tblRef_Relations.Where(p => p.RelationID == row["RelationID"].ToString()).First().RelationName
                            + ", tên người quan hệ gia đình: " + row["RelationName"].ToString()
                            + ", năm sinh: " + row["RelationBirthday"].ToString()
                            + ", CMND/CCCD: " + row["RelationIDCard"].ToString()
                            + ", trạng thái: " + row["RelationStatus"].ToString()
                            + ", ngày hết hiệu lực: " +  (row["DeactivateDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["DeactivateDate"])) : "")
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpRelation"));
                    }
                    else
                    {
                        _lActionClass.Add(new ActionClass("Thêm dữ liệu", _empID, "", "Sửa dữ liệu quan hệ gia đình bảng nhân viên ngày: "
                            + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["RecievedDate"]))
                            + ", mã loại quan hệ gia đình: " + row["RelationID"].ToString()
                            + ", loại quan hệ gia đình: " + db.tblRef_Relations.Where(p => p.RelationID == row["RelationID"].ToString()).First().RelationName
                            + ", tên người quan hệ gia đình: " + row["RelationName"].ToString()
                            + ", năm sinh: " + row["RelationBirthday"].ToString()
                            + ", CMND/CCCD: " + row["RelationIDCard"].ToString()
                            + ", trạng thái: " + row["RelationStatus"].ToString()
                            + ", ngày hết hiệu lực: " + (row["DeactivateDate"] != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(row["DeactivateDate"])) : "")
                            + ", ghi chú: " + (row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "")
                            , "tblEmpRelation"));
                    }
                }
                else
                {
                    var RelationID = row["RelationID", DataRowVersion.Original];
                    var RelationName = row["RelationName", DataRowVersion.Original];
                    var RelationBirthday = row["RelationBirthday", DataRowVersion.Original];
                    var RelationIDCard = row["RelationIDCard", DataRowVersion.Original];
                    var RelationStatus = row["RelationStatus", DataRowVersion.Original];
                    var RecievedDate = row["RecievedDate", DataRowVersion.Original];
                    var DeactivateDate = row["DeactivateDate", DataRowVersion.Original];
                    var Notes = row["Notes", DataRowVersion.Original];

                    _lActionClass.Add(new ActionClass("Xóa dữ liệu", _empID, "", "Xóa dữ liệu quan hệ gia đình bảng nhân viên ngày: "
                             + string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(RecievedDate))
                            + ", mã loại quan hệ gia đình: " + RelationID.ToString()
                            + ", loại quan hệ gia đình: " + db.tblRef_Relations.Where(p => p.RelationID == RelationID.ToString()).First().RelationName
                            + ", tên người quan hệ gia đình: " + RelationName.ToString()
                            + ", năm sinh: " + RelationBirthday.ToString()
                            + ", CMND/CCCD: " + RelationIDCard.ToString()
                            + ", trạng thái: " + RelationStatus.ToString()
                            + ", ngày hết hiệu lực: " +  ( DeactivateDate != DBNull.Value ? string.Format("{0: dd/MM/yyyy}", Convert.ToDateTime(DeactivateDate)) : "")
                            + ", ghi chú: " + Notes.ToString()
                        , "tblEmpRelation"));
                }
            }

            Provider.UpdateData((grcQuanHe.DataSource as DataTable), "tblEmpRelation");

            LogAction.LogAction.PushLog(_lActionClass);

            (grcQuanHe.DataSource as DataTable).AcceptChanges(); //xac nhan tat ca thay doi tren dt (lan sau luu ko cap nhat lai nhung dong da cap nhat)

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
        }

        #endregion

        //Load dữ liệu khi chọn tabPage con Thông tin khác
        private void tabControlThongTinKhac_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            string namePage = e.Page.Name;

            switch (namePage)
            {
                case "tabLoaiNV":
                    menuRefresh_LoaiNV_Click(null, null);
                    break;
                case "tabLuongCoBan":
                    menuRefresh_LuongCB_Click(null, null);
                    break;
                case "tabPhuCap":
                    menuRefresh_PhuCapHT_Click(null, null);
                    break;
                case "tabHopDong":
                    menuRefresh_HopDong_Click(null, null);
                    break;
                case "tabPhongBan":
                    menuRefresh_PB_Click(null, null);
                    break;
                case "tabConTho":
                    menuRefresh_ConTho_Click(null, null);
                    break;
                case "tabGioiThieu":
                    menuRefresh_GioiThieu_Click(null, null);
                    break;
                case "tabNgoaiNgu":
                    menuRefresh_KNNgoaiNgu_Click(null, null);
                    break;
                case "tabKyNangTinHoc":
                    menuRefresh_KNMayTinh_Click(null, null);
                    break;
                case "tabFileLienQuan":
                    menuRefresh_Files_Click(null, null);
                    break;
                case "tabThaiSan":
                    menuRefresh_ThaiSan_Click(null, null);
                    break;
                case "tabQuanHe":
                    menuRefresh_QuanHe_Click(null, null);
                    break;
                default: break;
            }
        }

        private void dlgEmployee_FormClosing(object sender, FormClosingEventArgs e) //Clear dữ liệu trong Grid View
        {
            grcLoaiNV.DataSource = null;

            grcPhongBan.DataSource = null;

            grcLuongCB.DataSource = null;

            grcHopDong.DataSource = null;

            grcPhuCapHangThang.DataSource = null;

            grcConTho.DataSource = null;

            grcThaiSan.DataSource = null;

            grcQuanHe.DataSource = null;
        }

        #region Điền tự động thứ tự column GridView
        private void grvLoaiNV_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvPhongBan_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_PB)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvLuongCB_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_Luong)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvPhuCapHangThang_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_PhuCapHT)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvHopDong_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_HD)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvConTho_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_ConTho)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvGioiThieu_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_GioiThieu)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }
        private void grvKNNgoaiNgu_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_KNNgoaiNgu)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvKNMayTinh_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_KNMayTinh)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvThaiSan_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_TS)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvQuanHe_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT_QH)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        #endregion

        #region setID EmpID For event InitNewRow

        private void grvLoaiNV_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvLoaiNV, e.RowHandle, TableConst.tblEmpType.id, TableConst.tblEmpType.EmployeeID);
        }

        private void grvThaiSan_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvThaiSan, e.RowHandle, TableConst.tblEmpType.id, TableConst.tblEmpType.EmployeeID);
        }

        private void grvPhongBan_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvPhongBan, e.RowHandle, TableConst.tblEmpDep.id, TableConst.tblEmpDep.EmployeeID);
        }

        private void grvLuongCB_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvLuongCB, e.RowHandle, TableConst.tblEmpSalary.id, TableConst.tblEmpSalary.EmployeeID);

            DataRow dr = grvLuongCB.GetDataRow(e.RowHandle);

            if (dr != null)
            {
                dr["status"] = 0;
            }
        }

        private void grvPhuCapHangThang_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvPhuCapHangThang, e.RowHandle, TableConst.tblEmpAllowanceFix.id, TableConst.tblEmpAllowanceFix.EmployeeID);
        }

        private void grvHopDong_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvHopDong, e.RowHandle, TableConst.tblEmpAllowanceFix.id, TableConst.tblEmpAllowanceFix.EmployeeID);
        }
        private void grvConTho_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            setID_EmpID_For_InitNewRow(grvConTho, e.RowHandle, TableConst.tblEmpChild.id, TableConst.tblEmpChild.EmployeeID);
        }

        private void grvQuanHe_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvQuanHe.GetDataRow(e.RowHandle);

            if (dr != null)
            {
                dr["id"] = Guid.NewGuid();

                dr["EmployeeID"] = _empID;

            }
        }

        private void grvGioiThieu_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvGioiThieu.GetDataRow(e.RowHandle);

            if (dr != null)
            {
                dr["id"] = Guid.NewGuid();

                dr["EmployeeID"] = _empID;

                dr["Sotien"] = 0;
            }
        }
        private void grvKNMayTinh_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvKNMayTinh.GetDataRow(e.RowHandle);

            if (dr != null)
            {
                dr["EmployeeID"] = _empID;
            }
        }

        private void grvKNNgoaiNgu_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvKNNgoaiNgu.GetDataRow(e.RowHandle);

            if (dr != null)
            {
                dr["EmployeeID"] = _empID;
            }
        }
        private void grvFilesLienQuan_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var dr = grvFilesLienQuan.GetDataRow(e.RowHandle);

            if (dr != null)
            {
                dr["EmployeeID"] = _empID;
            }
        }
        private void setID_EmpID_For_InitNewRow(GridView grv, int rowHandle, string id, string empID)
        {
            var dr = grv.GetDataRow(rowHandle);

            if (dr != null)
            {
                dr[id] = Guid.NewGuid();

                dr[empID] = _empID;
            }
        }
        #endregion

        private void dateNgaySinh_Leave(object sender, EventArgs e)
        {
            if(dateNgayVaoLam.EditValue != null && dateNgaySinh.EditValue != null)
            {
                DateTime _BirthdayBD = DateTime.Parse(dateNgaySinh.EditValue.ToString());

                DateTime _AppliedDateBD = DateTime.Parse(dateNgayVaoLam.EditValue.ToString());

                if (_BirthdayBD.AddYears(18) > _AppliedDateBD)
                {
                    GUIHelper.MessageBox("Nhân viên này chưa đủ 18 tuổi!");
                }
            }
        }

        private void txtHo_Leave(object sender, EventArgs e)
        {
            txtHoTen.Text = string.Format("{0} {1}", txtHo.Text.Trim(), txtTen.Text.Trim());
        }

        private void txtTen_Leave(object sender, EventArgs e)
        {
            txtHoTen.Text = string.Format("{0} {1}", txtHo.Text.Trim(), txtTen.Text.Trim());
        }

        private void txtSoThe_Leave(object sender, EventArgs e)
        {
            //var countEmp = db.tblEmployees.Where(p => p.LeftDate == null && p.CardID == txtSoThe.Text);

            //if (countEmp.Count() > 0)
            //{
            //    GUIHelper.MessageBox("Số thẻ này đã có nhân viên(" + countEmp.First().EmployeeID + ") sử dụng!");
            //}
        }

        private void txtSoCMND_Leave(object sender, EventArgs e)
        {
            var em = db.tblEmployees.Where(i => i.EmployeeID == txtMaNV.Text && i.IDCard == txtSoCMND.Text);

            if (em.Count() > 0)
            {
                return;
            }
            else
            {
                if (CustomFormAction == 0)
                {
                    var emp = db.tblEmployees.Where(p => p.IDCard == txtSoCMND.Text);

                    if (emp.Count() > 0 && emp.First().LeftDate == null)
                    {
                        GUIHelper.MessageBox(string.Format("* Nhân viên {0} đang sử dụng số CMND này", emp.First().EmployeeID));
                    }
                    else if (emp.Count() > 0 && emp.First().LeftDate != null)
                    {
                        GUIHelper.MessageBox(string.Format("* Nhân viên {0} có CMND này đã nghỉ việc ngày {1:dd/MM/yyyy} ", emp.First().EmployeeID, emp.First().LeftDate));
                    }
                }
                if (CustomFormAction == 1)
                {
                    var emp = db.tblEmployees.Where(i => i.IDCard == txtSoCMND.Text && i.LeftDate == null && i.EmployeeID != txtMaNV.Text);

                    if (emp.Count() > 0)
                    {
                        var countEmp = db.tblEmployees.Where(p => p.LeftDate == null && p.CardID == txtSoThe.Text);

                        if (countEmp.Count() > 0)
                        {
                            GUIHelper.MessageBox(string.Format("* Nhân viên {0} đang sử dụng số CMND này", emp.First().EmployeeID));
                        }
                    }
                }
            }
        }

        private void dateNgayVaoLam_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime ngayvao = Convert.ToDateTime(dateNgayVaoLam.Text);
            //    dateNgayNopHoSo.DateTime = ngayvao.Date;
            //    dateNgayKyHopDong.DateTime = ngayvao.Date.AddDays(-1).AddMonths(2);
            //}
            //catch (Exception)
            //{

            //}

            if (dateNgayVaoLam.EditValue != null && dateNgaySinh.EditValue != null)
            {
                DateTime _BirthdayBD = DateTime.Parse(dateNgaySinh.EditValue.ToString());

                DateTime _AppliedDateBD = DateTime.Parse(dateNgayVaoLam.EditValue.ToString());

                if (_BirthdayBD.AddYears(18) > _AppliedDateBD)
                {
                    GUIHelper.MessageBox("Nhân viên này chưa đủ 18 tuổi!");
                }
            }
        }
        #region Set DateEdit null if Blank
        private void setDateNullIfBlank(DateEdit d)
        {
            if (d.Text == "")
            {
                d.EditValue = null;
            }
        }
        private void dateNgayKyHopDong_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayKyHopDong);
        }

        private void dateNgaySinh_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgaySinh);
        }

        private void dateNgayVaoLam_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayVaoLam);
        }

        private void dateNgayNopHoSo_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayNopHoSo);
        }

        private void dateNgayCap_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayCap);
        }

        private void dateNgayNghiViec_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayNghiViec);
        }

        private void dateNgayNopDon_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayNopDon);
        }

        private void dateNgayTraLuongCuoi_EditValueChanged(object sender, EventArgs e)
        {
            setDateNullIfBlank(dateNgayTraLuongCuoi);
        }

        private void lookupEmpTypeCodeID_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookup = sender as LookUpEdit;
            object row = lookup.Properties.GetDataSourceRowByKeyValue(lookup.EditValue);
 
            if (CustomFormAction == 0)
            {
                string EmpTypeCodeName = (row as DataRowView)["EmpTypeCodeName"].ToString();
                txtMaNV.Text = LoginHelper.Context.getEmployeeID(EmpTypeCodeName);
                txtSoThe.Text = txtMaNV.Text.Substring(EmpTypeCodeName.Length, 4);
            }
        }

        #endregion

        private void txtSoBH_Leave(object sender, EventArgs e)
        {
            var a = db.tblEmployees.FirstOrDefault(p => p.EmployeeID != _empID && p.SINo == txtSoBH.Text);

            if (a != null)
            {
                GUIHelper.MessageBox(string.Format("* Nhân viên {0} đang sử dụng số sổ bảo hiểm này", a.EmployeeID));
            }
                    
        }

        private void txtSoBHYT_Leave(object sender, EventArgs e)
        {
            var a = db.tblEmployees.FirstOrDefault(p => p.EmployeeID != _empID && p.HINo == txtSoBHYT.Text);

            if (a != null)
            {
                GUIHelper.MessageBox(string.Format("* Nhân viên {0} đang sử dụng số thẻ bảo hiểm y tế này", a.EmployeeID));
            }
        }

        private void txtMST_Leave(object sender, EventArgs e)
        {
            var a = db.tblEmployees.FirstOrDefault(p => p.EmployeeID != _empID && p.IncomeTaxNumber == txtSoBHYT.Text);

            if (a != null)
            {
                GUIHelper.MessageBox(string.Format("* Nhân viên {0} đang sử dụng mã số thuế này", a.EmployeeID));
            }
        }
        
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();

            string filterFile = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            filterFile += "|All files (*.*)|*.*;";

            od.Filter = filterFile;

            od.Multiselect = false;

            if (od.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes = System.IO.File.ReadAllBytes(od.FileNames[0]);

                MyValue["dataFile"] = bytes;

                MyValue["duoiFile"] = Path.GetExtension(od.FileNames[0]);

                if (MyValue["idFile"] == DBNull.Value)
                {
                    MyValue["idFile"] = Guid.NewGuid();
                }

                pictureEditIcon.EditValue = Image.FromFile(od.FileNames[0]);
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa ảnh?", "Xóa ảnh", MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                MyValue["dataFile"] = DBNull.Value;

                MyValue["duoiFile"] = DBNull.Value;

                string xx = MyValue["idFile"].ToString();

                pictureEditIcon.EditValue = DBNull.Value;
            }

        }

        private void resItemButtonFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            var dr = grvFilesLienQuan.GetFocusedDataRow();
            
            if (e.Button.Index == 0)// Xem file
            {
                if (dr != null && dr["dataFile"] != DBNull.Value)
                {
                    FileStorageHelper fh = new FileStorageHelper();

                    var duoiFile = grvFilesLienQuan.GetFocusedRowCellValue(colDuoiFile).ToString();

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
                    grvFilesLienQuan.AddNewRow();

                    dr = grvFilesLienQuan.GetFocusedDataRow();

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

                        dr["ghiChu"] = Path.GetFileName(od.FileNames[0]).Replace(Path.GetExtension(od.FileNames[0]), "");

                        dr["duoiFile"] = Path.GetExtension(od.FileNames[0]);

                        if (dr["idFile"] == DBNull.Value)
                        {
                            dr["idFile"] = Guid.NewGuid();
                        }
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

                    GUIHelper.Notifications("Đã xóa file đính kèm. Bấm lưu lại để hoàn thành.", "Xóa file đính kèm", GUIHelper.NotifiType.info);
                }
                else
                {
                    GUIHelper.Notifications("Không có dữ liệu để xóa", "Xóa file", GUIHelper.NotifiType.error);
                }
            }
        }

        private void grvHopDong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colTuNgay_HD || e.Column == colLoaiHD_HD)
                {
                    try
                    {
                        getMaHDLD(e);

                        var loaiHD = grvHopDong.GetRowCellValue(e.RowHandle, colLoaiHD_HD).ToString();
                        if (loaiHD.ToString() == "")
                        {
                            GUIHelper.MessageError("Bạn chưa chọn loại hợp đồng!");
                            return;
                        }

                        var NgayHD = grvHopDong.GetRowCellValue(e.RowHandle, colTuNgay_HD).ToString();
                        if (NgayHD.ToString() == "")
                        {
                            GUIHelper.MessageError("Bạn chưa chọn ngày hợp đồng!");
                            return;
                        }
                        var KyHD = db.tblRef_ContractTypes.Where(p => p.ContractTypeID == loaiHD.ToString()).FirstOrDefault();
                        if (KyHD != null)
                        {
                            if (KyHD.isDay != null)
                            {
                                if(KyHD.isDay == true)
                                {
                                    if (KyHD.DayNumber.ToString() != "")
                                    {
                                        DateTime dEnd = Convert.ToDateTime(NgayHD).AddDays(Convert.ToInt32(KyHD.DayNumber));
                                        grvHopDong.SetRowCellValue(e.RowHandle, colDenNgay_HD, dEnd);
                                    }
                                }
                                else
                                {
                                    if (KyHD.MonthNumber.ToString() != "")
                                    {
                                        DateTime dEnd = Convert.ToDateTime(NgayHD).AddMonths(Convert.ToInt32(KyHD.MonthNumber)).AddDays(-1);
                                        grvHopDong.SetRowCellValue(e.RowHandle, colDenNgay_HD, dEnd);
                                    }
                                }
                            }
                        }

                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void getMaHDLD(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var a = grvHopDong.GetRowCellValue(e.RowHandle, colTuNgay_HD);

            var ct = grvHopDong.GetRowCellValue(e.RowHandle, colMaHD_HD);

            var loaiHD = grvHopDong.GetRowCellValue(e.RowHandle, colLoaiHD_HD);

            if (a != null && loaiHD != null)
            {
                int Month = ((DateTime)a).Month;
                int Year = ((DateTime)a).Year;

                dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

                var ec = db.tblEmpContracts.Where(p => p.BeginDate.Year == Year && p.BeginDate.Month == Month && p.ContractTypeID == loaiHD.ToString()).OrderByDescending(p => p.idx).FirstOrDefault();

                var idx_Next = ec == null ? 1 : ((ec.idx == null ? 0 : ec.idx) + 1);

                var KyHD = db.tblRef_ContractTypes.Where(p => p.ContractTypeID == loaiHD.ToString()).FirstOrDefault();

                DataRow r = grvHopDong.GetDataRow(e.RowHandle);

                r["idx"] = idx_Next;

                if (KyHD.isTrail == true )
                {
                    r["ContractID"] = string.Format("HĐTV-{0}-{2:00}{1:00}", txtMaNV.Text.Trim().Substring(2, 8), Month.ToString("00"), Year.ToString().Substring(2, 2));
                }
                else
                {
                    r["ContractID"] = string.Format("HĐLĐ-{0}-{2:00}{1:00}", txtMaNV.Text.Trim().Substring(2, 8), Month.ToString("00"), Year.ToString().Substring(2, 2));
                }

                
            }
        }

        private void repositoryItemLookUpEditGioiThieuNV_EditValueChanged(object sender, EventArgs e)
        {

            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;

            this.grvGioiThieu.SetFocusedRowCellValue(colNgayNhan_GioiThieu
                                            , searchEdit.Properties.View.GetFocusedRowCellValue("Date"));

            this.grvGioiThieu.SetFocusedRowCellValue(colMaNV_GioiThieu
                                            , searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeID_New"));

            this.grvGioiThieu.SetFocusedRowCellValue(colHoTen_GioiThieu
                                            , searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeName"));

            this.grvGioiThieu.SetFocusedRowCellValue(colPhongBan_GioiThieu
                                            , searchEdit.Properties.View.GetFocusedRowCellValue("DepName_Final"));
        }
        private void pictureEditIcon_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Camera.TakePictureDialog dialog = new DevExpress.XtraEditors.Camera.TakePictureDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Image image = dialog.Image;

                using (var stream = new MemoryStream())
                {
                    image.Save(stream, ImageFormat.Jpeg);

                    pictureEditIcon.EditValue = stream.ToArray();


                    byte[] bytes = stream.ToArray();

                    MyValue["dataFile"] = bytes;

                    MyValue["duoiFile"] = ".Jpeg";

                    if (MyValue["idFile"] == DBNull.Value)
                    {
                        MyValue["idFile"] = Guid.NewGuid();
                    }
                }
            }
        }


        private class Company
        {
            public string CompanyName { get; set; }
        }

        private class RelationStatus
        {
            public string RelationStatusName { get; set; }
        }

        private class Sex
        {
            public string SexName { get; set; }
            public string SexID { get; set; }
        }

        private class DIS
        {
            public string DisName { get; set; }
            public string dis { get; set; }
        }

        private void dlgEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgEmployee_Load(null, null);
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

        private IEnumerable<Label> EnumerateLabelControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(Label).IsAssignableFrom(field.FieldType)
                   let component = (Label)field.GetValue(this)
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
            var _SimpleButton = EnumerateSimpleButton();
            var _GroupControl = EnumerateGroupControl();
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
            foreach (Label s in _LableControl)
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

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}