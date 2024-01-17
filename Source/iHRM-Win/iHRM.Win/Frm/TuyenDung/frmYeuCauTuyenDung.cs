using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using iHRM.Common.Code;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmYeuCauTuyenDung : frmBase
    {
        global::iHRM.Core.Business.Logic.TuyenDung.YeuCauTuyenDung logic = new global::iHRM.Core.Business.Logic.TuyenDung.YeuCauTuyenDung();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        DataTable dt = new DataTable();
        DataRow CRow;
        dlgYeuCauTuyenDung dlgEditor;
        private int isTaoVongPV = 1;
        public string _isTaoVongPV { get { return isTaoVongPV.ToString(); } set { isTaoVongPV = int.Parse(value); } }
        public frmYeuCauTuyenDung()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            lookupDonViTD.DataSource = db.tblRef_Positions;
            lookupTrangThaiTD.DataSource = Enums.elTrangThaiTD;
            searchLookUpDotTD.Properties.DataSource = db.tbDotTuyenDungs;

            btnThemNV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            toolStripXoa.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);
            toolStripButton2.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            toolStripLuu.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Save);
            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);


            if (LoginHelper.user.isAcceptBP == true || LoginHelper.user.isAdmin || LoginHelper.user.isAcceptable == true)
            {
                toolStripLuu.Visible = true;
                toolStripAcceptAll.Visible = true;
                toolStripAccept.Visible = true;
                toolStripNotAccept.Visible = true;
            }
            else
            {
                toolStripLuu.Visible = false;
                toolStripAcceptAll.Visible = false;
                toolStripAccept.Visible = false;
                toolStripNotAccept.Visible = false;
            }

            if (btnFind.Enabled)
            {
                btnFind_Click(null, null);
            }

            if (_isTaoVongPV == "1")
            {
                this.Text = "Tạo vòng phỏng vấn";
                btnThemNV.Visible = false;
                toolStripXoa.Visible = false;
                toolStripLuu.Visible = false;
                toolStripAcceptAll.Visible = false;
                toolStripAccept.Visible = false;
                toolStripNotAccept.Visible = false;
            }
            else
            {
                this.Text = "Danh sách các yêu cầu tuyển dụng";
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu nhân viên...";
            dw_it.OnDoing = (s, ev) =>
            {
                logic.VirtualPaging.PageSize = pageNavigator1.PageSize;
                logic.VirtualPaging.Page = pageNavigator1.CurrentPage;
                if (_isTaoVongPV == "1") // Tạo vòng PV
                {
                    dt = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearch.Text),
                                      new System.Data.SqlClient.SqlParameter("idDotID", searchLookUpDotTD.EditValue),
                                      new System.Data.SqlClient.SqlParameter("isTaoVongPV", true));
                }
                else
                {
                    dt = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearch.Text), new System.Data.SqlClient.SqlParameter("idDotID", searchLookUpDotTD.EditValue));
                }
                dw_it.bw.ReportProgress(1, dt);
                dw_it.bw.ReportProgress(2, logic.VirtualPaging.RecordCount);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grcYeuCauTD.DataSource = data.UserState; btnFind.Enabled = true;
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
            ExportGrid(grcYeuCauTD);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var drs = grvYeuCauTD.GetSelectedRows().Select(i => grvYeuCauTD.GetDataRow(i));
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            else
            {
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa yêu cầu tuyển dụng đã chọn"))
                {
                    if (drs.Count() == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }
                    foreach (var item in drs)
                    {
                        var a = db.tbYeuCauTuyenDungs.Where(i => i.id.ToString() == item["id"].ToString()).FirstOrDefault();
                        if (a == null)
                        {
                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                            return;
                        }
                        db.tbYeuCauTuyenDungs.DeleteOnSubmit(a);
                    }
                    try
                    {
                        db.SubmitChanges();
                        LogAction.LogAction.PushLog("Xóa dữ liệu", "", "", string.Format("Xóa kế hoạch tuyển dụng"), "tbYeuCauTuyenDung");
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                        grvYeuCauTD.DeleteSelectedRows();
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
                dlgEditor = new dlgYeuCauTuyenDung();
                dlgEditor.Owner = this;
                dlgEditor.OnSave += dlgEditor_OnSave;
            }
            dlgEditor.setDisplayForForm(_isTaoVongPV);
            dlgEditor.setSelectedTab();
            dlgEditor.Show();
        }

        void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                #region  Check nhập thông tin
                if (dlgEditor.MyValue["idDotTD"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Bạn chưa chọn đợt tuyển dụng", "Không thể lưu");
                    return;
                }
                if (dlgEditor.MyValue["PosID"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Bạn chưa chọn vị trí tuyển dụng", "Không thể lưu");
                    return;
                }
                if (dlgEditor.MyValue["doTuoi"] != DBNull.Value)
                {
                    var a = dlgEditor.MyValue["doTuoi"].ToString().Split('-');
                    if (a[0] != "" && a[1] != "")
                    {
                        if (Convert.ToInt16(a[0]) > Convert.ToInt16(a[1]))
                        {
                            GUIHelper.MessageError("Độ tuổi bắt đầu không thể lớn hơn tuổi đến", "Không thể lưu");
                            return;
                        }
                    }
                }
                if (dlgEditor.MyValue["kinhNghiem"] != DBNull.Value)
                {
                    var a = dlgEditor.MyValue["kinhNghiem"].ToString().Split('-');
                    if (a[0] != "" && a[1] != "")
                    {
                        if (Convert.ToInt16(a[0]) > Convert.ToInt16(a[1]))
                        {
                            GUIHelper.MessageError("Kinh nghiệm bắt đầu không thể lớn hơn kinh nghiệm đến", "Không thể lưu");
                            return;
                        }
                    }
                }

                if (dlgEditor.MyValue["soLuong"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Số lượng của yêu cẩu không được rổng", "Không thể lưu");
                    return;
                }

                if (dlgEditor.MyValue["DistrictID"] != DBNull.Value)
                {
                    var a = db.tblRef_Districts.FirstOrDefault(p => p.DistrictID == dlgEditor.MyValue["DistrictID"].ToString());
                    if (a != null)
                    {
                        dlgEditor.MyValue["DistrictName"] = a.DistrictName;
                    }
                }
                if (dlgEditor.MyValue["CityID"] != DBNull.Value)
                {
                    var a = db.tblRef_Cities.FirstOrDefault(p => p.CityID == dlgEditor.MyValue["CityID"].ToString());
                    if (a != null)
                    {
                        dlgEditor.MyValue["CityName"] = a.CityName;
                    }
                }

                var xx = db.tbYeuCauTuyenDungs.Where(p => p.ngayYeuCau.Value.Year == DateTime.Now.Year).OrderByDescending(p => p.soChungTu).FirstOrDefault();
                if (xx != null)
                {
                    dlgEditor.MyValue["soChungTu"] = string.Format("TD/D.01/{0:00}-{1:00000}", DateTime.Now.Year.ToString().Substring(2, 2), int.Parse(xx.soChungTu.Substring(11, 5).ToString().Trim()) + 1);
                }
                else
                {

                    dlgEditor.MyValue["soChungTu"] = string.Format("TD/D.01/{0:00}-{1:00000}", DateTime.Now.Year.ToString().Substring(2, 2), 1);
                }

                #endregion

                db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
                tbYeuCauTuyenDung kh;
                if (dlgEditor.CustomFormAction == 0)//Thêm mới
                {
                    kh = new tbYeuCauTuyenDung();
                }
                else
                {
                    kh = db.tbYeuCauTuyenDungs.FirstOrDefault(p => p.id == Convert.ToInt32(dlgEditor.MyValue["id"]));
                }

                SetDataContextFromDataRow(kh, dlgEditor.MyValue);
                if (dlgEditor.CustomFormAction == 0)//Thêm mới
                {
                    kh.idUser = LoginHelper.user.id;
                    db.tbYeuCauTuyenDungs.InsertOnSubmit(kh);
                    var dtd = db.tbDotTuyenDungs.Where(p => p.id == kh.id).FirstOrDefault();
                    if (dtd != null)
                    {
                        dtd.trangThaiThucHien = 1;
                    }
                }
                bool isSuccess = true;
                if (dlgEditor.isChangedFile)
                {
                    if (dlgEditor.MyValue["dataFile"] != DBNull.Value) // Nếu chọn file khác
                    {
                        if (!frmBase.AddOrUpdateDbFile(Guid.Parse(dlgEditor.MyValue["idFile"].ToString()), 1, dlgEditor.MyValue["dataFile"] as byte[], dlgEditor.MyValue["duoiFile"] as string, dlgEditor.MyValue["tenFile"] as string))
                        {
                            GUIHelper.MessageError("Thêm file không thành công", "Thêm yêu cầu tuyển dụng");
                            isSuccess = false;
                        }
                    }
                    else // Nếu xóa file
                    {
                        if (dlgEditor.MyValue["idFile"] != DBNull.Value) // Check khi k có dữ liệu mà vẫn bấm xóa
                        {
                            if (!frmBase.AddOrUpdateDbFile(Guid.Parse(dlgEditor.MyValue["idFile"].ToString()), 2))
                            {
                                GUIHelper.MessageError("Xóa file không thành công", "Thêm yêu cầu tuyển dụng");
                                isSuccess = false;
                            }
                            else
                            {
                                kh.idFile = null;
                            }
                        }
                    }
                }
                if (isSuccess)
                {
                    db.SubmitChanges();
                    if (dlgEditor.CustomFormAction == 0)
                    {
                        LogAction.LogAction.PushLog("Thêm dữ liệu", "", "", string.Format("Thêm mới yêu cầu tuyển dụng"), "tbYeuCauTuyenDung");
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    }
                    else
                    {
                        LogAction.LogAction.PushLog("Sửa dữ liệu", "", "", string.Format("Cập nhật yêu cầu tuyển dụng"), "tbYeuCauTuyenDung");
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                    }
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
            ShowEditor();
            var r = dt.NewRow();
            db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
            var a = db.tbYeuCauTuyenDungs.Where(p => p.ngayYeuCau.Value.Year == DateTime.Now.Year).OrderByDescending(p=>p.soChungTu).FirstOrDefault();
            if(a!=null)
            {
                r["soChungTu"] = string.Format("TD/D.01/{0:00}-{1:00000}", DateTime.Now.Year.ToString().Substring(2, 2), int.Parse(a.soChungTu.Substring(11,5).ToString().Trim())+1);
            }
            else
            {

                r["soChungTu"] = string.Format("TD/D.01/{0:00}-{1:00000}", DateTime.Now.Year.ToString().Substring(2, 2), 1);
            }
          
            dlgEditor.CustomFormAction = 0;
            dlgEditor._idYCTD = DbHelper.DrGetInt(r, "id");
            dlgEditor.MyValue = r;
        }
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (grvYeuCauTD.FocusedRowHandle != -1)
            {
                CRow = grvYeuCauTD.GetFocusedDataRow();
                ShowEditor();
                dlgEditor.CustomFormAction = 1;
                dlgEditor._idYCTD = DbHelper.DrGetInt(CRow, "id");
                dlgEditor.MyValue = CRow;
            }
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            CRow = grvYeuCauTD.GetFocusedDataRow();
        }

        private void grv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (_isTaoVongPV != "1")
            {
                if (e.RowHandle >= 0 && grvYeuCauTD.GetRowCellValue(e.RowHandle, "isAccept") != null && !string.IsNullOrEmpty(grvYeuCauTD.GetRowCellValue(e.RowHandle, "isAccept").ToString()))
                {
                    if (grvYeuCauTD.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "True")
                    {
                        e.Appearance.ForeColor = Color.Green;
                    }
                    else if (grvYeuCauTD.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "False")
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
             frmDangKyCaLam_Load(null, null);
        }

        private void toolStripAcceptAll_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu tuyển dụng?", "Duyệt yêu cầu tuyển dụng", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                for (int i = 0; i < grvYeuCauTD.DataRowCount; i++)
                {
                    var r = grvYeuCauTD.GetDataRow(i);
                    if (r != null)
                    {
                        if (r["isAccept"] == DBNull.Value)
                        {
                            r["isAccept"] = true;
                            r["userAccept"] = LoginHelper.user.id;
                            r["ngayPhanHoiPNS"] = DateTime.Now;
                        }
                    }
                }
            }
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu tuyển dụng đang chọn?", "Duyệt yêu cầu tuyển dụng", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grvYeuCauTD.GetSelectedRows())
                {
                    var r = grvYeuCauTD.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        r["isAccept"] = true;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayPhanHoiPNS"] = DateTime.Now;
                    }
                }
            }
        }

        private void toolStripNotAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu tuyển dụng đang chọn?", "Không duyệt yêu cầu tuyển dụng", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grvYeuCauTD.GetSelectedRows())
                {
                    var r = grvYeuCauTD.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        r["isAccept"] = false;
                    }
                }
            }
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }
            var count = dt.GetChanges().Rows.Count;
            try
            {
                Provider.UpdateData(dt, "tbYeuCauTuyenDung");

                LogAction.LogAction.PushLog("Sửa dữ liệu", "", "", string.Format("Cập nhật kế hoạch tuyển dụng"), "tbYeuCauTuyenDung");
                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }
    }
}
