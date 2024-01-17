using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using iHRM.Common.Code;
using System.Windows.Forms;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmDanhGiaUngVien : frmBase
    {
        global::iHRM.Core.Business.Logic.TuyenDung.DanhGiaUngVien logic = new global::iHRM.Core.Business.Logic.TuyenDung.DanhGiaUngVien();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        DataTable dtData = new DataTable();
        DataRow CRow;
        dlgDanhGiaUngVien dlgEditor;
        bool _isThemDanhGia = false;
        List<PhongVan> arrSex = new List<PhongVan>();
        public frmDanhGiaUngVien()
        {
            InitializeComponent();
            

        }
        private class PhongVan
        {
            public string PhongVanName { get; set; }
            public string PhongVanID { get; set; }
        }
        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            btnThemNV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            toolStripButton1.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);
            toolStripButton2.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);

            lookupDotTuyenDung.Properties.DataSource = db.tbDotTuyenDungs;

            if (btnFind.Enabled)
            {
                btnFind_Click(null, null);
            } 
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ...";
            dw_it.OnDoing = (s, ev) =>
            {
                logic.VirtualPaging.PageSize = pageNavigator1.PageSize;
                logic.VirtualPaging.Page = pageNavigator1.CurrentPage;
                dtData = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text),
                                new System.Data.SqlClient.SqlParameter("idDotTD", lookupDotTuyenDung.EditValue),
                                new System.Data.SqlClient.SqlParameter("idYCTD", lookUpYCTD.EditValue),
                                new System.Data.SqlClient.SqlParameter("phamViDanhGia", cboPhamViPV.EditValue),
                                new System.Data.SqlClient.SqlParameter("isDaDanhGia", chkDaDanhGia.Checked)
                                //new System.Data.SqlClient.SqlParameter("isPhamVi", cboPhamViPV.EditValue)
                                );
                dw_it.bw.ReportProgress(1, dtData);
                dw_it.bw.ReportProgress(2, logic.VirtualPaging.RecordCount);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grcDanhGiaUV.DataSource = data.UserState;
                    btnFind.Enabled = true;
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
            ExportGrid(grcDanhGiaUV);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var drs = grvDanhGiaUV.GetSelectedRows().Select(i => grvDanhGiaUV.GetDataRow(i));
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            else
            {
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa đánh giá ứng viên đã chọn."))
                {
                    db = new dcDatabaseDataContext(Provider.ConnectionString);
                    foreach (DataRow r in drs)
                    {
                        if (r["id"] != null)
                        {
                            var a = db.tblUV_DanhGias.Where(i => i.id.ToString() == r["id"].ToString()).FirstOrDefault();
                            if (a != null)
                            {
                                db.tblUV_DanhGias.DeleteOnSubmit(a);
                            }
                        }
                    }
                    try
                    {
                        db.SubmitChanges();
                        LogAction.LogAction.PushLog("Xóa dữ liệu","", "", string.Format("Xóa đánh giá ứng viên"), "tblUV_DanhGia");
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                        grvDanhGiaUV.DeleteSelectedRows();
                    }
                    catch (Exception ex)
                    {
                        win_globall.ExecCatch(ex);
                    }
                    var lst = db.tblUV_DanhGias.Where(i => drs.Select(j => j["id"] as string).Equals(i.id.ToString()));
                }
            }
        }

        void ShowEditor()
        {
            if (dlgEditor == null)
            {
                dlgEditor = new dlgDanhGiaUngVien();
                dlgEditor.Owner = this;
                dlgEditor.OnSave += dlgEditor_OnSave;
            }
            DataRow r = grvDanhGiaUV.GetFocusedDataRow();
            dlgEditor._idYCTD_UV = Convert.ToInt32(r["idycuv"]);
            dlgEditor.loadPredata();
            dlgEditor.Show();
        }

        void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                #region  Check nhập thông tin tab đánh giá chuyên môn
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "1")
                {
                    GUIHelper.MessageError("Lý do kiến thức công việc chưa nhập.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "2")
                {
                    GUIHelper.MessageError("Chưa chọn kết quả của kiến thức công việc.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "3")
                {
                    GUIHelper.MessageError("Chưa nhập lý do khả năng,kĩ năng kết quả nghề nghiệp.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "4")
                {
                    GUIHelper.MessageError("Chưa chọn kết quả khả năng kĩ năng nghề nghiệp.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "6")
                {
                    GUIHelper.MessageError("Chưa chọn kết quả vòng phỏng vấn chuyên môn.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "5")
                {
                    GUIHelper.MessageError("Chưa nhập lý do của kết quả phỏng vấn chuyên môn.");
                    return;
                }
                if (dlgEditor.MyValue["ketQuaVong1"] == DBNull.Value || Convert.ToInt16(dlgEditor.MyValue["ketQuaVong1"]) < 0)
                {
                    GUIHelper.MessageError("Bạn chưa nhập kết quả sơ vấn.");
                    return;
                }
                #endregion

                #region check thông tin tab phê duyệt của trưởng bộ phận
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "8")
                {
                    GUIHelper.MessageError("Chưa chọn vị trí tuyển dụng.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "9")
                {
                    GUIHelper.MessageError("Chưa chọn chức vụ tuyển dụng.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "10")
                {
                    GUIHelper.MessageError("Chưa chọn phòng ban.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "11")
                {
                    GUIHelper.MessageError("Chưa chọn ngày nhận việc.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "12")
                {
                    GUIHelper.MessageError("Chưa nhập thời gian thử việc.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "13")
                {
                    GUIHelper.MessageError("Chưa nhập mức thu nhập chính thức");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "14")
                {
                    GUIHelper.MessageError("Chưa nhập mức thu nhập thử việc.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "15")
                {
                    GUIHelper.MessageError("Chưa nhập mức lương bảo hiểm.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "16")
                {
                    GUIHelper.MessageError("Chưa nhập lý do chọn kết quả.");
                    return;
                }
                if (dlgEditor.MyValue["gioiTinh"].ToString() == "17")
                {
                    GUIHelper.MessageError("Chưa chọn kết quả phê duyệt.");
                    return;
                }
                //if (dlgEditor.MyValue["gioiTinh"].ToString() == "19")
                //{
                //    GUIHelper.MessageError("Chưa chọn kinh nghiệm chuyên môn.");
                //    return;
                //}

                if (dlgEditor.MyValue["isAcceptGD"] != DBNull.Value && dlgEditor.MyValue["dataFile"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Giám đốc duyệt thì phải đính kèm tập tin.");
                    return;
                }

                #endregion

                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn lưu đánh giá ứng viên đã chọn."))
                {
                    db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
                    tblUV_DanhGia dg;
                    if (dlgEditor.CustomFormAction == 0)//Thêm mới
                    {
                        dg = new tblUV_DanhGia();
                    }
                    else
                    {
                        dg = db.tblUV_DanhGias.FirstOrDefault(p => p.id == Convert.ToInt32(dlgEditor.MyValue["id"]));
                    }

                    SetDataContextFromDataRow(dg, dlgEditor.MyValue);

                    if (dlgEditor.CustomFormAction == 0)//Thêm mới
                    {
                        db.tblUV_DanhGias.InsertOnSubmit(dg);
                        db.SubmitChanges();
                        dlgEditor._idDG = db.tblUV_DanhGias.OrderByDescending(p => p.id).First().id;
                        dlgEditor.MyValue["id"] = dlgEditor._idDG;
                        //xem xét vi trí khác
                        try
                        {
                            if (dlgEditor.MyValue["viTriPhuHop"] != null)
                            {
                                
                                string vitrimoi = dlgEditor.MyValue["viTriPhuHop"] as string;
                                string mauv = dlgEditor.MyValue["idUV"] as string;
                                //tìm ứng vien này đang ở yêu cầu nào
                                tblYeuCauTD_UngVien yctd_uv = db.tblYeuCauTD_UngViens.Where(p => p.idUV == mauv).SingleOrDefault();
                                yctd_uv.idYCTD = int.Parse(vitrimoi);
                                db.SubmitChanges();

                                LogAction.LogAction.PushLog("Thêm dữ liệu", dg.idUV, "", string.Format("Thêm mới đánh giá ứng viên {0}", dg.idUV), "tblUV_DanhGia");
                            }
                        }
                            
                        catch { }
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                        //dlgEditor.MyValue["viTriPhuHop"]
                        
                        //LoadVisibleAndEnableTabPageDanhGia();
                    }
                    else
                    {
                        db.SubmitChanges();
                        LogAction.LogAction.PushLog("Sửa dữ liệu", dg.idUV, "", string.Format("Cập nhật đánh giá ứng viên {0}", dg.idUV), "tblUV_DanhGia");
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                    }
                    //bool isSuccess = true;
                    if (dlgEditor.isChangedFile)
                    {
                        if (dlgEditor.MyValue["dataFile"] != DBNull.Value) // Nếu chọn file khác
                        {
                            if (!frmBase.AddOrUpdateDbFile(Guid.Parse(dlgEditor.MyValue["idFile"].ToString()), 1, dlgEditor.MyValue["dataFile"] as byte[], dlgEditor.MyValue["duoiFile"] as string, dlgEditor.MyValue["tenFile"] as string))
                            {
                                try
                                {
                                    tblEmpFilesLienQuan empFile = new tblEmpFilesLienQuan();
                                    empFile.ghiChu = "PM chuyển từ đánh giá ứng viên";
                                    empFile.EmployeeID = dlgEditor.MyValue["MaNhanVien"].ToString();
                                    empFile.idFile = (Guid)dlgEditor.MyValue["idFile"];
                                    db.tblEmpFilesLienQuans.InsertOnSubmit(empFile);
                                }
                                catch { }
                                //GUIHelper.Notifications("Thêm file không thành công", "Thêm yêu cầu tuyển dụng", GUIHelper.NotifiType.error);
                                //isSuccess = false;
                            }
                        }
                        else // Nếu xóa file
                        {
                            if (dlgEditor.MyValue["idFile"] != DBNull.Value) // Check khi k có dữ liệu mà vẫn bấm xóa
                            {
                                if (frmBase.AddOrUpdateDbFile(Guid.Parse(dlgEditor.MyValue["idFile"].ToString()), 2))
                                {
                                    dg.idFile = null;
                                }
                            }
                        }
                    }
                    db.SubmitChanges();
                    dlgEditor.Close();
                    btnFind_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        private void btnThemNV_Click_Click(object sender, EventArgs e)
        {
            if (grvDanhGiaUV.FocusedRowHandle >= 0)
            {
                if (_isThemDanhGia)
                {
                    DataRow r = grvDanhGiaUV.GetFocusedDataRow();
                    CRow = dtData.NewRow();
                    CRow["idUV"] = r["EmployeeID"];

                    var count = db.tblUV_DanhGias.Where(p => p.ngayKetLuanSoVan.Value.Year == DateTime.Now.Year).Count();
                    CRow["soChungTu"] = string.Format("TD/D.04/{0:00}-{1:0000}", DateTime.Now.Year.ToString().Substring(2,2), count + 1);
                    CRow["idYCTD_UV"] = r["idycuv"];
                    CRow["doTuoi"] = "Đạt yêu cầu";
                    CRow["trinhDoHocVan"] = "Đạt yêu cầu";
                    CRow["kienThucChuyenMon"] = "Đúng yêu cầu";
                    CRow["kinhNghiemCongViec"] = "Vượt yêu cầu";
                    CRow["mucTieuCongViec"] = "Phù hợp";
                    CRow["ngayKetLuanSoVan"] = DateTime.Now;
                    ShowEditor();
                    dlgEditor.CustomFormAction = 0;
                    dlgEditor.MyValue = CRow;
                    LoadVisibleAndEnableTabPageDanhGia();
                }
                else
                {
                    CRow = grvDanhGiaUV.GetFocusedDataRow();
                    ShowEditor();
                    dlgEditor.CustomFormAction = 1;
                    dlgEditor.MyValue = CRow;
                    LoadVisibleAndEnableTabPageDanhGia();
                }


            }
        }
        public void LoadVisibleAndEnableTabPageDanhGia()
        {
            bool isVisibleTab1 = false, isVisibleTab2 = false, isVisibleTab3 = false;
            bool isReadOnlyTab1 = false, isReadOnlyTab2 = false, isReadOnlyTab3 = false;
            if (dlgEditor.MyValue != null)
            {
                if (dlgEditor.MyValue["ketQuaVong1"] != DBNull.Value && Convert.ToInt16(dlgEditor.MyValue["ketQuaVong1"]) == 0)
                {
                    isReadOnlyTab1 = true;
                    if (dlgEditor.MyValue["ketQuaVong2"] != DBNull.Value && Convert.ToInt16(dlgEditor.MyValue["ketQuaVong2"]) == 0)
                    {
                        isReadOnlyTab2 = true;
                        isVisibleTab1 = true;
                        isVisibleTab2 = true;
                        isVisibleTab3 = true;
                    }
                    else
                    {
                        isVisibleTab1 = true;
                        isVisibleTab2 = true;
                    }
                }
                else
                {
                    isVisibleTab1 = true;
                }
            }
            if (isVisibleTab3 && LoginHelper.user.isAcceptBP != null && LoginHelper.user.isAcceptBP.Value)
            {
                isVisibleTab3 = true;
            }
            else
            {
                isVisibleTab3 = false;
            }
            dlgEditor.setVisibleTabPage(isVisibleTab1, isVisibleTab2, isVisibleTab3);
            dlgEditor.setEnableTabPage(isReadOnlyTab1, isReadOnlyTab2);
        }
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (grvDanhGiaUV.FocusedRowHandle != -1)
            {
                if (_isThemDanhGia)
                {
                    return;
                }
                else
                {
                    CRow = grvDanhGiaUV.GetFocusedDataRow();
                    ShowEditor();
                    dlgEditor.CustomFormAction = 1;
                    dlgEditor.MyValue = CRow;
                    LoadVisibleAndEnableTabPageDanhGia();
                }
            }
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            CRow = grvDanhGiaUV.GetFocusedDataRow();
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void txtSearchKey_Leave(object sender, EventArgs e)
        {
            btnFind_Click(sender, e);
        }

        private void grvDanhGiaUV_DataSourceChanged(object sender, EventArgs e)
        {
            grvDanhGiaUV_FocusedRowChanged(null, null);
        }

        private void grvDanhGiaUV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var dr = grvDanhGiaUV.GetFocusedDataRow();
            if (dr != null)
            {
                DataTable Check_tblDanhGia = Provider.ExecuteDataTable("p_tblUV_DanhGia_Check", new System.Data.SqlClient.SqlParameter("id", dr["id"]));
                if (Check_tblDanhGia.Rows.Count > 0)
                {
                    _isThemDanhGia = false;
                    //btnThemNV.Text = "Xem đánh giá";
                    //this.btnThemNV.Image = global::iHRM.Win.Properties.Resources.ico20_edit;
                }
                else
                {
                    _isThemDanhGia = true;
                    //btnThemNV.Text = "Thêm mới đánh giá";
                    //this.btnThemNV.Image = global::iHRM.Win.Properties.Resources.ico20_new;
                }
            }
        }

        private void lookupDotTuyenDung_EditValueChanged_1(object sender, EventArgs e)
        {
            if (lookupDotTuyenDung.EditValue != null)
            {
                lookUpYCTD.Properties.DataSource = Provider.ExecuteDataTable("p_tbYeuCauTuyenDung_GetAllByIdDotTD",
                                                    new System.Data.SqlClient.SqlParameter("idDotTD", lookupDotTuyenDung.EditValue));
            }
            else
            {
                lookUpYCTD.Properties.DataSource = null;
                lookUpYCTD.EditValue = null;
            }
        }

        private void lookUpYCTD_EditValueChanged_1(object sender, EventArgs e)
        {
            //chọn phạm vi đánh giá
            arrSex = new List<PhongVan>();
            arrSex.Add(new PhongVan { PhongVanName = "Đánh giá PV lần 1", PhongVanID = "PV1" });
            arrSex.Add(new PhongVan { PhongVanName = "Đánh giá PV lần 2", PhongVanID = "PV2" });
            arrSex.Add(new PhongVan { PhongVanName = "Phê duyệt trưởng bộ phận", PhongVanID = "TBP" });
            cboPhamViPV.Properties.DataSource = arrSex;
            cboPhamViPV.EditValue = "PV1";
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
