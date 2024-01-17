using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Helper;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Win.DungChung;
using System.IO;
using System.Collections.Generic;
using iHRM.Common.Code;
using System.Windows.Forms;
namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmUngVien : frmBase
    {
        global::iHRM.Core.Business.Logic.TuyenDung.UngVien logic = new global::iHRM.Core.Business.Logic.TuyenDung.UngVien();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        DataTable dtData = new DataTable();
        DataRow CRow;
        dlgUngVien dlgEditor;
        public static string strFunction = "";
        public frmUngVien()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            btnThemNV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            toolStripButton1.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);
            toolStripButton2.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            toolStripButton3.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            toolStripButton3.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Edit);
            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);
            //set lại ngày tháng tìm kiếm
            if (btnFind.Enabled)
            {
                btnFind_Click(null, null);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s, ev) =>
            {
                logic.VirtualPaging.PageSize = pageNavigator1.PageSize;
                logic.VirtualPaging.Page = pageNavigator1.CurrentPage;
                dtData = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text)
                    
                    );

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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var dr = grv.GetFocusedDataRow();
            if (dr == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            else
            {
                if (dr["EmployeeID"] != DBNull.Value)
                {
                    string idUV = dr["EmployeeID"].ToString();
                    if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa nhân viên đã chọn " + idUV))
                    {
                        db = new dcDatabaseDataContext(Provider.ConnectionString);
                        var a = from y_uv in db.tblYeuCauTD_UngViens.Where(p => p.idUV == idUV)
                                join dg in db.tblUV_DanhGias on y_uv.id equals dg.idYCTD_UV
                                select dg;
                        if (a.Count() > 0)
                        {
                            GUIHelper.MessageError("Ứng viên đã được đánh giá.", "Xóa ứng viên");
                            return;
                        }
                        if (db.tblEmployees.Where(p => p.idUV == idUV).Count() > 0)
                        {
                            GUIHelper.MessageError("Ứng viên đã được chuyển sang nhân viên.", "Xóa ứng viên");
                            return;
                        }
                        try
                        {
                            Provider.ExecNoneQuery("p_tblUV_xoaUV", new System.Data.SqlClient.SqlParameter("EmployeeID", idUV));

                            LogAction.LogAction.PushLog("Xóa dữ liệu", idUV , "","Xóa ứng viên " + idUV, "tblUngVien");
                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                            btnFind_Click(null, null);
                        }
                        catch (Exception ex)
                        {
                            win_globall.ExecCatch(ex);
                        }
                    }
                }
                else
                {
                    GUIHelper.MessageError("Mã nhân viên không tồn tại.", "Xóa ứng viên");

                    return;
                }
            }
        }
        void ShowEditor()
        {
            if (dlgEditor == null)
            {
                dlgEditor = new dlgUngVien();
                dlgEditor.Owner = this;
                dlgEditor.OnSave += dlgEditor_OnSave;
            }
            dlgEditor.Show();
        }

        void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                #region  Check nhập thông tin
                if (dlgEditor.MyValue["EmployeeName"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Bạn chưa nhập họ tên ứng viên.", "Không thể lưu");
                    return;
                }
                if (dlgEditor.MyValue["SubmitDate"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Bạn chưa nhập ngày nộp hồ sơ.", "Không thể lưu");
                    return;
                }
                #endregion

                db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
                tblUngVien emp_new;
                if (dlgEditor.CustomFormAction == 0)
                {
                    emp_new = new tblUngVien();
                    emp_new.EmployeeID = dlgEditor.MyValue["EmployeeID"] as string;
                    emp_new.EmployeeCode = dlgEditor.MyValue["EmployeeID"] as string;
                }
                else
                {
                    emp_new = db.tblUngViens.Where(p => p.EmployeeID == dlgEditor.myID.ToString()).Single();
                    emp_new.EmployeeID = dlgEditor.myID.ToString();
                }
                if (dlgEditor.MyValue["IdViTriDuTuyen1"] != DBNull.Value)
                {
                    dlgEditor.MyValue["ViTriDuTuyen1"] = db.tblRef_EmployeeTypes.FirstOrDefault(p => p.EmpTypeID == (dlgEditor.MyValue["IdViTriDuTuyen1"] as string)).EmpTypeName;
                }
                if (dlgEditor.MyValue["IdViTriDuTuyen2"] != DBNull.Value)
                {
                    dlgEditor.MyValue["ViTriDuTuyen2"] = db.tblRef_EmployeeTypes.FirstOrDefault(p => p.EmpTypeID == (dlgEditor.MyValue["IdViTriDuTuyen2"] as string)).EmpTypeName;
                }
                // Thông tin chung:
                SetDataContextFromDataRow(emp_new, dlgEditor.MyValue);

                emp_new.NameSearch = ConvertUnicode.RemoveUnicode(dlgEditor.MyValue["EmployeeName"] as string).ToUpper();
                emp_new.MaritalStatusID = dlgEditor.MyValue["MaritalStatusID"] as string;
                if (!string.IsNullOrEmpty(emp_new.MaritalStatusID))
                {
                    var q = db.tblRef_MaritalStatus.Where(p => p.MaritalStatusID == emp_new.MaritalStatusID);
                    if (q.Count() > 0)
                    {
                        emp_new.MaritalStatusName = q.First().MaritalStatusName;
                    }
                }
                if (!string.IsNullOrEmpty(emp_new.NationalityID))
                {
                    var q = db.tblRef_Nationalities.Where(p => p.NationalityID == emp_new.NationalityID);
                    if (q.Count() > 0)
                    {
                        emp_new.NationalityName = q.First().NationalityName;
                        emp_new.NationalityName_VIE = q.First().NationalityName_VIE;
                    }
                }
                if (dlgEditor.CustomFormAction == 0)
                {
                    var aa = db.tblUngViens.Where(p => p.EmployeeID == dlgEditor.MyValue["EmployeeID"].ToString()).ToList();
                    if (aa.Count == 0)
                    {
                        db.tblUngViens.InsertOnSubmit(emp_new);
                        db.SubmitChanges();

                        LogAction.LogAction.PushLog("Thêm dữ liệu", emp_new.EmployeeID, "", "Thêm mới ứng viên " + emp_new.EmployeeID, "tblUngVien");
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                        dlgEditor.visibleTab(true);
                    }
                    else
                    {
                        db.SubmitChanges();
                        LogAction.LogAction.PushLog("Sửa dữ liệu", emp_new.EmployeeID, "", "Cập nhật ứng viên " + emp_new.EmployeeID, "tblUngVien");
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                    }
                }
                else
                {
                    // Sửa thì chuyển trạng thái thành edited
                    db.SubmitChanges();
                    LogAction.LogAction.PushLog("Sửa dữ liệu", emp_new.EmployeeID, "", "Cập nhật ứng viên " + emp_new.EmployeeID, "tblUngVien");
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
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
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            ShowEditor();
            dlgEditor.CustomFormAction = 0;
            var r = dtData.NewRow();
            r["soChungTu"] = LoginHelper.Context.getUngVienSCT();
            r["EmployeeID"] = LoginHelper.Context.getUngVienID(); // Thêm dlg khi bấm add.
            r["CreatedDate"] = DateTime.Now; // Thêm dlg khi bấm add.

            r["trangThai"] = 0; // Set trạng thái = 0. Chưa được phỏng vấn.
            dlgEditor.MyValue = r;
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CRow = grv.GetFocusedDataRow();
            
            //lấy được mã ứng viên
            DataSet dsDM = Provider.ExecuteDataSetReader("p_Emp_getAllDM_UV", new System.Data.SqlClient.SqlParameter("EmployeeID", CRow["EmployeeID"] as string));
            if(dsDM.Tables[0].Rows.Count <=0 )
            {
                GUIHelper.MessageBox("Thông tin ứng viên không phù hợp.");
                return;
            }
            WordUltil wd = new WordUltil(Path.Combine(win_globall.apppath, @"ExcelTemplate\TuyenDung\phieuThongTinUngVien.dotx"), true);


            #region THÔNG TIN ỨNG VIÊN
            Dictionary<string, string> dic = new Dictionary<string, string>();
            // Xuất các dữ liệu mình chuẩn bị ở Field (ở đây mình lọc lấy dữ liệu ở dạng linq)
            dic.Add("EmployeeID", dsDM.Tables[0].Rows[0]["EmployeeID"] as string);

            dic.Add("MaHS", dsDM.Tables[0].Rows[0]["EmployeeID"] as string);
            dic.Add("idYCTD", dsDM.Tables[0].Rows[0]["idYCTD"] as string);
            dic.Add("VTTD1", dsDM.Tables[0].Rows[0]["VTTD1"] as string);
            dic.Add("VTTD2", dsDM.Tables[0].Rows[0]["VTTD2"] as string);
            try
            {
                dic.Add("ThuNhapChapNhanDuoc", string.Format("{0:0,0}", int.Parse(dsDM.Tables[0].Rows[0]["ThuNhapChapNhanDuoc"].ToString())));
                dic.Add("ThuNhapMongMuon", string.Format("{0:0,0}", int.Parse(dsDM.Tables[0].Rows[0]["ThuNhapMongMuon"].ToString())));
            }
            catch
            {
                dic.Add("ThuNhapChapNhanDuoc", string.Format("{0:0,0}", dsDM.Tables[0].Rows[0]["ThuNhapChapNhanDuoc"].ToString()));
                dic.Add("ThuNhapMongMuon", string.Format("{0:0,0}", dsDM.Tables[0].Rows[0]["ThuNhapMongMuon"].ToString()));
            }
            dic.Add("NgayCoTheBatDauLamViec", dsDM.Tables[0].Rows[0]["NgayCoTheBatDauLamViec"] as string);
            dic.Add("EmployeeName", dsDM.Tables[0].Rows[0]["EmployeeName"] as string);
            dic.Add("soChungTu", dsDM.Tables[0].Rows[0]["soChungTu"] as string);
            dic.Add("Birthday", dsDM.Tables[0].Rows[0]["Birthday"] as string);
            dic.Add("Address", dsDM.Tables[0].Rows[0]["Address"] as string);
            dic.Add("IDCard", dsDM.Tables[0].Rows[0]["IDCard"] as string);
            dic.Add("IssueDate", dsDM.Tables[0].Rows[0]["IssueDate"] as string);
            dic.Add("IssuePlace", dsDM.Tables[0].Rows[0]["IssuePlace"] as string);
            dic.Add("SexID", dsDM.Tables[0].Rows[0]["SexID"] as string);
            dic.Add("ChieuCao", dsDM.Tables[0].Rows[0]["ChieuCao"] as string);
            dic.Add("CanNang", dsDM.Tables[0].Rows[0]["CanNang"] as string);
            dic.Add("MaritalStatusName", dsDM.Tables[0].Rows[0]["MaritalStatusName"] as string);
            dic.Add("SoCon", dsDM.Tables[0].Rows[0]["SoCon"] as string);
            dic.Add("Phone", dsDM.Tables[0].Rows[0]["Phone"] as string);
            dic.Add("PhoneNhaRieng", dsDM.Tables[0].Rows[0]["PhoneNhaRieng"] as string);
            dic.Add("Email", dsDM.Tables[0].Rows[0]["Email"] as string);
            dic.Add("PermanentAddress", dsDM.Tables[0].Rows[0]["PermanentAddress"] as string);
            dic.Add("NativeCountry", dsDM.Tables[0].Rows[0]["NativeCountry"] as string);
            dic.Add("HoTenNguoiBaoTin", dsDM.Tables[0].Rows[0]["HoTenNguoiBaoTin"] as string);
            dic.Add("QuanHeNguoiBaoTin", dsDM.Tables[0].Rows[0]["QuanHeNguoiBaoTin"] as string);
            dic.Add("PhoneNguoiBaoTin", dsDM.Tables[0].Rows[0]["PhoneNguoiBaoTin"] as string);
            dic.Add("DiaChiNguoiBaoTin", dsDM.Tables[0].Rows[0]["DiaChiNguoiBaoTin"] as string);

            dic.Add("SoThichCaNhan", dsDM.Tables[0].Rows[0]["SoThichCaNhan"] as string);
            dic.Add("DiemManh", dsDM.Tables[0].Rows[0]["DiemManh"] as string);
            dic.Add("DiemYeu", dsDM.Tables[0].Rows[0]["DiemYeu"] as string);
            dic.Add("Ngay", DateTime.Now.Day.ToString());
            dic.Add("Thang", DateTime.Now.Month.ToString());
            dic.Add("Nam", DateTime.Now.Year.ToString());
            wd.WriteFields(dic);
            #endregion
            //THÔNG TIN QUAN HỆ GIA ĐÌNH
            wd.WriteTable(dsDM.Tables[1], 3); 
            //THÔNG TIN GIÁO DỤC PHỔ THÔNG
            wd.WriteTable(dsDM.Tables[2], 5);
            //THÔNG TIN GIÁO DỤC ĐẠI HỌC
            wd.WriteTable(dsDM.Tables[3], 6);
            //THÔNG TIN CHƯƠNG TRÌNH ĐÀO TẠO CẤP TÍN CHỈ
            wd.WriteTable(dsDM.Tables[4], 7);
            //THÔNG TIN NGÔN NGỮ
            wd.WriteTable(dsDM.Tables[5], 8);
            //THÔNG TIN TIN HỌC
            wd.WriteTable(dsDM.Tables[6], 9);
            //THÔNG TIN KINH NGHIỆP LÀM VIỆC
            wd.WriteTable(dsDM.Tables[7], 10);
        }

        private void txtSearchKey_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }

       
    }
}
