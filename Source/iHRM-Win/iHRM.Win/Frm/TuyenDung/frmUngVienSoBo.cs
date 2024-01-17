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
using iHRM.Win.DungChung;
using System.IO;
using iHRM.Win.Frm.XtraReportTemplate;
using iHRM.Common.Code;
using System.Data.Linq;
namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmUngVienSoBo : frmBase
    {
        global::iHRM.Core.Business.Logic.TuyenDung.UngVienSoBo logic = new global::iHRM.Core.Business.Logic.TuyenDung.UngVienSoBo();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        iHRM.Core.Controller.Report.GetData controller = new Core.Controller.Report.GetData();
        DataTable dtData = new DataTable();
        DataRow CRow;
        dlgUngVienSoBo dlgEditor;

        public static string strFunction = "";
        public frmUngVienSoBo()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            btnThemNV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            toolStripButton1.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);
            toolStripButton2.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            toolStripButton3.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Edit);
            toolStripButton5.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Edit);
            toolStripButton4.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Edit) || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);
            //set ngày tháng tìm kiếm
            if (btnFind.Enabled)
                btnFind_Click(null, null);
            LoadDataLoaiUV();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().ToList();
            foreach (int rowhandler in grv.GetSelectedRows())
            {
                var r = grv.GetDataRow(rowhandler);
            }

            string Key = txtSearchKey.Text;
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu nhân viên...";
            dw_it.OnDoing = (s, ev) =>
            {
                logic.VirtualPaging.PageSize = pageNavigator1.PageSize;
                logic.VirtualPaging.Page = pageNavigator1.CurrentPage;
                //if(chkUngVienPV.Checked)
                //{
                //    dtData = controller.GetDataUngVienPVTrongNgay();
                //}
                //else
                dtData = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", Key), new System.Data.SqlClient.SqlParameter("isPV", chkUngVienPV.Checked.ToString()), new System.Data.SqlClient.SqlParameter("LoaiUV", cboLoaiUV.EditValue));

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
            int[] arrHandle = grv.GetSelectedRows();

            DataTable dt = grd.DataSource as DataTable;
            DataTable dt_tam = dt.Copy();
            dt_tam.Rows.Clear();

            foreach (int rowhandler in arrHandle)
            {
                DataRow r = grv.GetDataRow(rowhandler);
                dt_tam.ImportRow(r);
                //dt_tam.Rows.Add(grv.GetDataRow(rowhandler));

            }

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu..."; //text hiện ở status
            dw_it.OnDoing = (s, ev) => //hàm lấy dữ liệu chạy ngầm
            {
                //var dt = controller.GetDataReportDuLieuChamCong(ucChonDoiTuong_DS1.GetValue(), chonKyLuong1.TuNgay, chonKyLuong1.DenNgay);
                if (dt == null || dt_tam.Rows.Count == 0)
                {
                    dw_it.bw.ReportProgress(-1, "Không có dữ liệu");
                    return;
                }
                //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");


                ExcelExportHelper ex = new ExcelExportHelper("TuyenDung/ReportUVSB.xls");
                ex.WriteToCell("H2", "DANH SÁCH ỨNG VIÊN SƠ BỘ");
                //ex.SetCellBgColor();
                ex.FillDataTable(dt_tam);
                //ex.RendAndFlush("bangphanca" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
                dw_it.bw.ReportProgress(1, ex);
            };
            dw_it.OnProcessing = (ps, data) => //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing
            {
                switch (data.ProgressPercentage)
                {
                    case -1:
                        GUIHelper.Notifications(data.UserState.ToString(), "Xuất excel", GUIHelper.NotifiType.info);
                        break;
                    case 1:
                        var ex = data.UserState as ExcelExportHelper;
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel|*.xlsx";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            ex.Save(saveFileDialog1.FileName);
                        }

                        var a = GUIHelper.Notifications("Xuất dữ liệu bảng công tháng thành công", "Xuất excel", GUIHelper.NotifiType.tick);

                        break;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            else
            {
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa ứng viên sơ bộ đã chọn " + drs.First()["MaUVSB"]))
                {
                    db = new dcDatabaseDataContext(Provider.ConnectionString);
                    var lst = db.tblUngVienSoBos.Where(i => i.id == int.Parse(drs.First()["id"].ToString()));

                    if (lst == null || lst.Count() == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }
                    try
                    {
                        db.tblUngVienSoBos.DeleteAllOnSubmit(lst);
                        db.SubmitChanges();

                        LogAction.LogAction.PushLog("Xóa dữ liệu", drs.First()["MaUVSB"].ToString(), "", "Xóa ứng viên sơ bộ " + drs.First()["MaUVSB"].ToString(), "tblUngVienSoBo");
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                        grv.DeleteSelectedRows();
                    }
                    catch (Exception ex)
                    {
                        win_globall.ExecCatch(ex);
                    }
                }
            }
        }
        void ShowEditor()
        {
            if (dlgEditor == null)
            {
                dlgEditor = new dlgUngVienSoBo();
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
                if (dlgEditor.MyValue["HoVaTen"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Bạn chưa nhập họ tên ứng viên sơ bộ.", "Không thể lưu");
                    return;
                }
                if (dlgEditor.MyValue["NgayNopHoSo"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Bạn chưa nhập ngày nộp hồ sơ.", "Không thể lưu");
                    return;
                }
                if (dlgEditor.MyValue["ViTriUngTuyen"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Bạn chưa nhập vị trí ứng tuyển.", "Không thể lưu");
                    return;
                }
                if (dlgEditor.MyValue["Email"] == DBNull.Value || dlgEditor.MyValue["Email"].ToString()==string.Empty)
                {
                    GUIHelper.MessageError("Email không được rổng.", "Không thể lưu");
                    return;
                }
                #endregion
                db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);


                tblUngVienSoBo uvsb;
                if (dlgEditor.CustomFormAction == 0)//Thêm mới
                {
                    uvsb = new tblUngVienSoBo();
                }
                else
                {
                    uvsb = db.tblUngVienSoBos.FirstOrDefault(p => p.id == int.Parse(dlgEditor.MyValue["id"].ToString()));
                }
                SetDataContextFromDataRow(uvsb, dlgEditor.MyValue);
                if (dlgEditor.CustomFormAction == 0)//Thêm mới
                {
                    db.tblUngVienSoBos.InsertOnSubmit(uvsb);
                    //db.SubmitChanges();
                    //GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    //dlgEditor.visibleTab(true);
                }
                db.SubmitChanges();
                if (dlgEditor.CustomFormAction == 0)
                {
                    LogAction.LogAction.PushLog("Thêm dữ liệu", uvsb.MaUVSB, "", "Thêm mới ứng viên sơ bộ " + uvsb.MaUVSB, "tblUngVienSoBo");
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    dlgEditor.SetTabControl(1);
                }
                else
                {
                    LogAction.LogAction.PushLog("Sửa dữ liệu", uvsb.MaUVSB, "", "Cập nhật ứng viên sơ bộ " + uvsb.MaUVSB, "tblUngVienSoBo");
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
                btnFind_Click(null, null);
               
            }
            catch (Exception ex)
            {
                GUIHelper.MessageBox("Mã ứng viên sơ bộ này đã tồn tài");
            }
        }
        private void btnThemNV_Click_Click(object sender, EventArgs e)
        {
            ShowEditor();
            dlgEditor.CustomFormAction = 0;
            dlgEditor.SetTabControl(0);
            var r = dtData.NewRow();
            r["MaUVSB"] = LoginHelper.Context.getUngVienSoBoID();
            //r["trangThai"] = 0; // Set trạng thái = 0. Chưa được phỏng vấn.
            dlgEditor.MyValue = r;
            //btnFind_Click(null, null);
            
        }
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (grv.FocusedRowHandle != -1)
            {
                CRow = grv.GetFocusedDataRow();
                ShowEditor();
                dlgEditor.CustomFormAction = 1;
                dlgEditor.SetTabControl(1);
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

        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {
            //if (e.RowHandle >= 0 && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "leftdate").ToString()))
            //{
            //    e.Appearance.ForeColor = Color.Red;
            //}
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CRow = grv.GetFocusedDataRow();

            frmSendMail_new frm = new frmSendMail_new(CRow, 1);
            frm.ShowDialog();
           
            //ShowEditor();
            //dlgEditor.CustomFormAction = 1;
            //dlgEditor.MyValue = CRow;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (grv.FocusedRowHandle != -1)
            {
                CRow = grv.GetFocusedDataRow();
                ShowEditor();
                dlgEditor.CustomFormAction = 1;
                dlgEditor.MyValue = CRow;
                btnFind_Click(null, null);
            }
        }

        private void repositoryItemButtonEditLaUngVien_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CRow = grv.GetFocusedDataRow();
            DataTable check_uvsb = Provider.ExecuteDataTable("p_tblUngVienSoBO_Check", new System.Data.SqlClient.SqlParameter("MaUVSB", CRow["MaUVSB"].ToString()));

            if (check_uvsb.Rows.Count > 0)
            {
                GUIHelper.MessageBox("Ứng viên sơ bộ: " + CRow["MaUVSB"].ToString() + " đã thành ứng viên chính thức \n");
                //continue;
            }
            else 
            {
                string mauv=LoginHelper.Context.getUngVienID();
                if(ChuyenUngVien(CRow,mauv))
                {
                    GUIHelper.MessageBox("Ứng viên sơ bộ: " + CRow["MaUVSB"].ToString() + " chuyển thành ứng viên có mã: " + mauv);
                }
                else
                {
                    GUIHelper.MessageBox("Ứng viên sơ bộ: " + CRow["MaUVSB"].ToString() + " chưa đậu hoặc chưa có kết quả");
                }
            }
        }
        public string get_id_string_nn(string text)
        {
            string[] ngoaingu = text.Trim().Split(',');
            string id_nn = string.Empty;
            //dr["LangID"] = GetID_ds(dsDM.Tables[2], "LangName", dr["NgoaiNguName"] as string, "LangID");
            foreach(string nn in ngoaingu)
            {
                DataTable dt = Provider.ExecuteDataTable("tblRef_Language_GetAll");
                id_nn += GetID_ds(dt, "LangName", nn, "LangID")+",";
            }
            id_nn += ")";
            return id_nn.Replace(",)","");
        }
        object GetID_ds(DataTable dt, string textColName, string textValue, string idColName)
        {
            if (!string.IsNullOrWhiteSpace(textValue))
            {
                var r = dt.Select("[" + textColName + "]='" + textValue.Trim() + "'").FirstOrDefault();
                if (r != null)
                    return r[idColName];
            }
            return DBNull.Value;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //xuất phiếu nhân viên tự đánh giá 
            CRow = grv.GetFocusedDataRow();
            #region check thông tin
            if (CRow["HoVaTen"].ToString().Trim() == string.Empty)
            {
                GUIHelper.MessageError("Thiếu thông tin họ và tên.");
                return;
            }
            if (CRow["ViTriUngTuyen"].ToString().Trim() == string.Empty)
            {
                GUIHelper.MessageError("Thiếu thông tin vị trí ứng tuyển.");
                return;
            }
            if (CRow["NgayPV"].ToString().Trim() == string.Empty)
            {
                GUIHelper.MessageError("Thiếu thông tin ngày phỏng vấn.");
                return;
            }
            if (CRow["Gio"].ToString().Trim() == string.Empty)
            {
                GUIHelper.MessageError("Chưa có giờ phỏng vấn.");
                return;
            }
            #endregion
            WordUltil wd = new WordUltil(Path.Combine(win_globall.apppath, @"ExcelTemplate\TuyenDung\thumoiphongvan.dotx"), true);
            #region THÔNG TIN ỨNG VIÊN
            Dictionary<string, string> dic = new Dictionary<string, string>();
            // Xuất các dữ liệu mình chuẩn bị ở Field (ở đây mình lọc lấy dữ liệu ở dạng linq)
            dic.Add("Ngay", DateTime.Now.Day.ToString());
            dic.Add("Thang", DateTime.Now.Month.ToString());
            dic.Add("Nam", DateTime.Now.Year.ToString());
            dic.Add("HoVaTen", CRow["HoVaTen"].ToString().Trim());
            dic.Add("ViTriUngTuyen", CRow["EmpTypeName"].ToString().Trim());
            DateTime ngay_gio = (DateTime)CRow["NgayPV"];
            dic.Add("NgayPV", ngay_gio.Date.ToString("dd/MM/yyyy"));
            TimeSpan gio_phut = (TimeSpan)CRow["Gio"];
            dic.Add("Gio", string.Format("{0:hh}", gio_phut));
            dic.Add("Phut", string.Format("{0:mm}", gio_phut));
            wd.WriteFields(dic);
            #endregion
            //XuatThuMoiPV();
        }
        private class LoaiUngVien
        {
            public string LoaiUngVienName { get; set; }
            public string LoaiUngVienID { get; set; }
        }

        public void LoadDataLoaiUV()
        {
            List<LoaiUngVien> LoaiUV = new List<LoaiUngVien>();
            LoaiUV.Add(new LoaiUngVien { LoaiUngVienName = "Tất cả", LoaiUngVienID = "1" });
            LoaiUV.Add(new LoaiUngVien { LoaiUngVienName = "Ứng viên chính thức", LoaiUngVienID = "2" });
            LoaiUV.Add(new LoaiUngVien { LoaiUngVienName = "Ứng viên sơ bộ", LoaiUngVienID = "3" });
            cboLoaiUV.Properties.DataSource = LoaiUV;
            cboLoaiUV.EditValue = "2";
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                var drs1 = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));
                if (drs1.Count() == 0)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                    return;
                }
                string thongbao = string.Empty;

                var drs = grv.GetSelectedRows();

                if (GUIHelper.ConfirmBox("Bạn có muốn chuyển ứng viên sơ bộ " + drs1.First()["MaUVSB"].ToString() + " qua ứng viên không?."))
                {

                    if (drs.Count() > 0)
                    {
                        foreach (int rowhandler in grv.GetSelectedRows())
                        {
                            DataRow CRow = grv.GetDataRow(rowhandler);
                            DataTable check_uvsb = Provider.ExecuteDataTable("p_tblUngVienSoBO_Check", new System.Data.SqlClient.SqlParameter("MaUVSB", CRow["MaUVSB"].ToString()));

                            if (check_uvsb.Rows.Count > 0)
                            {
                                thongbao += "Ứng viên sơ bộ: " + CRow["MaUVSB"].ToString() + " đã thành ứng viên chính thức \n";
                                //continue;
                            }
                            else
                            {

                                string MaUVSB = "";
                                MaUVSB = CRow["MaUVSB"].ToString();

                                if(MaUVSB == "")
                                {
                                    thongbao += "Không tìm thấy mã UVSB \n";
                                }

                                string mauv = LoginHelper.Context.getUngVienID();
                                if (ChuyenUngVien(CRow, mauv))
                                {
                                    thongbao += "Ứng viên sơ bộ: " + CRow["MaUVSB"].ToString() + " đã chuyển thành ứng viên có mã: " + mauv + "\n";

                                    LogAction.LogAction.PushLog("Chuyển dữ liệu", CRow["MaUVSB"].ToString(), "", "Chuyển ứng viên sơ bộ " + CRow["MaUVSB"].ToString() + " thành " + mauv, "tblUngVienSoBo");
                                }
                                else
                                {
                                    thongbao += "Ứng viên sơ bộ: " + CRow["MaUVSB"].ToString() + " không đậu\n";
                                }
                            }
                        }
                    }
                    if (thongbao != string.Empty)
                        GUIHelper.MessageBox(thongbao);
                }
            }
            catch { }
        }
        public bool ChuyenUngVien(DataRow CRow,string mauv)
        {
            try
            {
                //kiểm tra bảng ứng viên đã có ứng viên sơ bộ này chưa
                if (CRow["KQ"] != DBNull.Value)
                {

                    if (CRow["KQ"].ToString().Trim()=="0")
                    {
                        return false;
                    }
                }
                else
                    return false;
                // chuyển ứng viên sơ bộ này thành ứng viên chính thức
                #region Chuyển ứng viên sơ bộ thành ứng viên chính thức.
                //tạo số chứng từ tự sinh với ngày tạo ứng viên

                string sochungtu = LoginHelper.Context.getUngVienSCT();
                DataTable dt_uv = Provider.ExecuteDataTable("p_InsertUV",
                    new System.Data.SqlClient.SqlParameter("EmployeeID"                 , mauv                                  ),
                    new System.Data.SqlClient.SqlParameter("SubmitDate"                 , (DateTime)CRow["NgayNopHoSo"]         ),
                    new System.Data.SqlClient.SqlParameter("Email"                      , CRow["Email"] as string               ),
                    new System.Data.SqlClient.SqlParameter("Phone"                      , CRow["DienThoai"] as string           ),
                    new System.Data.SqlClient.SqlParameter("QualificationID"            , CRow["TrinhDoChuyenMon"] as string    ),
                    new System.Data.SqlClient.SqlParameter("EducationID"                , CRow["TrinhDoVanHoa"] as string       ),
                    new System.Data.SqlClient.SqlParameter("IdViTriDuTuyen1"            , CRow["ViTriUngTuyen"] as string       ),
                    new System.Data.SqlClient.SqlParameter("EmployeeName"               , CRow["HoVaTen"] as string             ),
                    new System.Data.SqlClient.SqlParameter("Birthday"                   , (DateTime)CRow["NamSinh"]             ),
                    new System.Data.SqlClient.SqlParameter("EmployeeCode"               , mauv                                  ),
                    new System.Data.SqlClient.SqlParameter("idUVSB"                     , CRow["MaUVSB"] as string              ),
                    new System.Data.SqlClient.SqlParameter("ThuNhapChapNhanDuoc"        ,CRow["LuongDeXua"] as string),
                    new System.Data.SqlClient.SqlParameter("soChungTu"                  , sochungtu                             ));
                if(int.Parse(dt_uv.Rows[0][0].ToString())==1)
                {
                    foreach (string nn in get_id_string_nn(CRow["NgoaiNgu"].ToString()).Split(','))
                    {
                        if (nn == string.Empty)
                            continue;
                        //lấy được từng cái id
                        tblUV_KyNangNgoaiNgu knnn = new tblUV_KyNangNgoaiNgu();
                        knnn.idUV = mauv;
                        knnn.ngonNgu = nn;
                        db.tblUV_KyNangNgoaiNgus.InsertOnSubmit(knnn);
                        db.SubmitChanges();
                    }
                    //get file liên quan của ứng viên sơ bộ
                    DataTable dt_file = Provider.ExecuteDataTable("p_tblUngVienSoBO_GetFile", new System.Data.SqlClient.SqlParameter("MaUVSB", CRow["MaUVSB"].ToString()));
                    foreach (DataRow r in dt_file.Rows)
                    {
                        //LẤY IDFILE CỦA FILE LIÊN QUAN CỦA THÈN ỨNG VIÊN SƠ BỘ
                        tblUVSB_FilesLienQuan file_UVSB = db.tblUVSB_FilesLienQuans.First(p => p.id == int.Parse(r["id"].ToString().Trim()));
                        tblUV_FilesLienQuan file_UV = new tblUV_FilesLienQuan();
                        file_UV.idUV = mauv;
                        file_UV.idFile = file_UVSB.idFile;
                        file_UV.ghiChu = file_UVSB.ghiChu;
                        file_UV.CurriculumVitaeCode = file_UVSB.CurriculumVitaeCode;
                        db.tblUV_FilesLienQuans.InsertOnSubmit(file_UV);
                        db.SubmitChanges();
                    }
                }
                return true;
                #endregion
            }
            catch
            {
                return false;
            }
        }

        private void grv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column == colStype && e.CellValue != null)
            {
                if (e.CellValue.ToString() == "Đạt")
                {
                    e.Appearance.BackColor = Color.MediumSpringGreen;
                }
                if (e.CellValue.ToString() == "Không đạt")
                {
                    e.Appearance.BackColor = Color.MediumVioletRed;
                }
            }
        }
        public string getHTML(DataTable dt)
        {
            StringBuilder myBuilder = new StringBuilder();

            myBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            myBuilder.Append("style='border: solid 1px Silver; font-size: x-small;'>");

            myBuilder.Append("<tr align='left' valign='top'>");
            foreach (DataColumn myColumn in dt.Columns)
            {
                myBuilder.Append("<td align='left' valign='top'>");
                myBuilder.Append(myColumn.ColumnName);
                myBuilder.Append("</td>");
            }
            myBuilder.Append("</tr>");

            foreach (DataRow myRow in dt.Rows)
            {
                myBuilder.Append("<tr align='left' valign='top'>");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    myBuilder.Append("<td align='left' valign='top'>");
                    myBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    myBuilder.Append("</td>");
                }
                myBuilder.Append("</tr>");
            }
            myBuilder.Append("</table>");

            return myBuilder.ToString();
        }
        private void toolStripButtonMailQL_Click(object sender, EventArgs e)
        {
            ListBox l = new ListBox();
            DataTable tbsend = new DataTable();
            tbsend.Columns.Add("MaUVSB");
            tbsend.Columns.Add("Họ và tên");
            tbsend.Columns.Add("Năm sinh");
            tbsend.Columns.Add("vị trí tuyển dụng");
            tbsend.Columns.Add("Trình độ văn hóa");
            tbsend.Columns.Add("Ngoại ngữ");
            tbsend.Columns.Add("Tên trường");
            tbsend.Columns.Add("Trình độ chuyên môn");
            tbsend.Columns.Add("Kinh nghiệm");
            tbsend.Columns.Add("Lương đề xuất");
            tbsend.Columns.Add("Ghi chú");
            //

            int[] ListChose = grv.GetSelectedRows();
            for (int i = ListChose.Count(); i > 0; i--)
            {
                var r = grv.GetDataRow(ListChose[i - 1]);

                DataTable tam = new DataTable();
                tam = Provider.ExecuteDataTable("p_FileLienQuan_UVSB", new System.Data.SqlClient.SqlParameter("IDUV", r["MaUVSB"].ToString()));
                if (tam.Rows.Count > 0)
                {
                    tbsend.Rows.Add(r["MaUVSB"], r["HoVaTen"], String.Format("{0:MM/dd/yyyy}", r["NamSinh"]), r["EmpTypeName"], r["EducationType"], r["NgoaiNgu"], r["TenTruong"], r["QualificationName"], r["KinhNghiem"], String.Format("{0:0,0 vnđ}", r["LuongDeXua"]), r["GhiChu"]);
                    foreach (DataRow dr in tam.Rows)
                    {
                        string duoifile = dr["duoiFile"].ToString();
                        Binary dataFile = new Binary(dr["dataFile"] as byte[]);
                        string tempFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"ExcelTemplate\$Temporary\" + Guid.NewGuid() + duoifile);
                        System.IO.File.WriteAllBytes(tempFilePath, dataFile.ToArray());
                        l.Items.Add(tempFilePath.ToString());
                    }
                }
            }

            CRow = grv.GetFocusedDataRow();

            frmSendMail_new frm = new frmSendMail_new(CRow, 3, tbsend, l);
            frm.ShowDialog();
            //update lại nngayf


        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmSendMail_new frm = new frmSendMail_new();
            frm.ShowDialog();
        }


        private void txtSearchKey_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }

    }
}
