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
using iHRM.Win.DungChung;
using System.Reflection;
namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmKeHoachTuyenDung : frmBase
    {
        global::iHRM.Core.Business.Logic.TuyenDung.KeHoachTuyenDung logic = new global::iHRM.Core.Business.Logic.TuyenDung.KeHoachTuyenDung();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        DataTable dtData = new DataTable();
        DataRow CRow;
        dlgKeHoachTuyenDung dlgEditor;
        public static string strFunction = "";
        public frmKeHoachTuyenDung()
        {
            InitializeComponent();
        }

        private void frmKeHoachTuyenDung_Load(object sender, EventArgs e)
        {
            TranslateForm();
            btnThemNV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            toolXoa.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);
            toolExcel.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            toolCapNhat.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Edit);
            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);

            cboNam.Properties.Items.AddRange(Ham.getYear(DateTime.Now.Year));
            cboNam.SelectedText = DateTime.Now.Year.ToString();

            cboViTriTuyenDung.Properties.DataSource = CacheDataTable.GetCacheDataTable("tblRef_Position");

            if (btnFind.Enabled)
                btnFind_Click(null, null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            //string Key = txtSearchKey.Text;
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s, ev) =>
            {
                logic.VirtualPaging.PageSize = pageNavigator1.PageSize;
                logic.VirtualPaging.Page = pageNavigator1.CurrentPage;
                dtData = logic.GetAll(new System.Data.SqlClient.SqlParameter("Nam", cboNam.SelectedItem.ToString()),
                    new System.Data.SqlClient.SqlParameter("PhongBan", cboPhongBan.SelectedValue),
                    new System.Data.SqlClient.SqlParameter("ViTriTuyenDung", cboViTriTuyenDung.EditValue)
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
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            else
            {
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa kế hoạch tuyển dụng đã chọn!."))
                {
                    db = new dcDatabaseDataContext(Provider.ConnectionString);
                    var lst = db.tblKeHoachTuyenDungs.Where(i => i.id == int.Parse(drs.First()["id"].ToString()));

                    if (lst == null || lst.Count() == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }
                    try
                    {
                        db.tblKeHoachTuyenDungs.DeleteAllOnSubmit(lst);
                        db.SubmitChanges();

                        LogAction.LogAction.PushLog("Xóa dữ liệu", "", "", string.Format("Xóa kế hoạch tuyển dụng"), "tblKeHoachTuyenDung");
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                        grv.DeleteSelectedRows();

                        btnFind_Click(null, null);
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
                dlgEditor = new dlgKeHoachTuyenDung();
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
                if (dlgEditor.MyValue["Ngay"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Chưa chọn năm thực hiện.", "Không thể lưu");
                    return;
                }
                if (dlgEditor.MyValue["DonVi"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Chưa chọn đơn vị nào yêu cầu.", "Không thể lưu");
                    return;
                }
                if (dlgEditor.MyValue["ViTri"] == DBNull.Value)
                {
                    GUIHelper.MessageError("Chưa chọn vị trí cần tuyển.", "Không thể lưu");
                    return;
                }
                #endregion
                db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);


                tblKeHoachTuyenDung khtd;
                if (dlgEditor.CustomFormAction == 0)//Thêm mới
                {
                    khtd = new tblKeHoachTuyenDung();
                }
                else
                {
                    khtd = db.tblKeHoachTuyenDungs.FirstOrDefault(p => p.id == int.Parse(dlgEditor.MyValue["id"].ToString()));
                }
                SetDataContextFromDataRow(khtd, dlgEditor.MyValue);
                if (dlgEditor.CustomFormAction == 0)//Thêm mới
                {
                    db.tblKeHoachTuyenDungs.InsertOnSubmit(khtd);
                    //db.SubmitChanges();
                    //GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    //dlgEditor.visibleTab(true);
                }

                db.SubmitChanges();

                if (dlgEditor.CustomFormAction == 0)
                {
                    LogAction.LogAction.PushLog("Thêm dữ liệu", "", "", "Thêm mới yêu cầu tuyển dụng" + dlgEditor._idDotTD, "tblKeHoachTuyenDung");
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                }
                else
                {
                    LogAction.LogAction.PushLog("Sửa dữ liệu", "", "", "Cập nhật yêu cầu tuyển dụng" + dlgEditor._idDotTD, "tblKeHoachTuyenDung");
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
                dlgKeHoachTuyenDung k = (sender) as dlgKeHoachTuyenDung;
                k.Close();

                btnFind_Click(null, null);

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
            r["MaKHTD"] = LoginHelper.Context.getKeHoachTuyenDungID(); // Thêm dlg khi bấm add.
            r["SoChungTu"] = LoginHelper.Context.getKeHoachTuyenDungSCT();
            //r["trangThai"] = 0; // Set trạng thái = 0. Chưa được phỏng vấn.
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

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //CRow = grv.GetFocusedDataRow();
            //frmSendMail frm = new frmSendMail(CRow);
            //frm.ShowDialog();

            //ShowEditor();
            //dlgEditor.CustomFormAction = 1;
            //dlgEditor.MyValue = CRow;
        }



        private void repositoryItemButtonEditLaUngVien_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //try
            //{
            //     // chuyển ứng viên sơ bộ này thành ứng viên chính thức
            //     CRow = grv.GetFocusedDataRow();
            //     tblUngVien uv = new tblUngVien();
            //     uv.EmployeeID = LoginHelper.Context.getUngVienID();
            //     uv.EmployeeName = CRow["HoVaTen"] as string;
            //     uv.Email = CRow["Email"] as string;
            //     uv.Phone = CRow["DienThoai"] as string;
            //     uv.Birthday = (DateTime)CRow["NamSinh"];
            //     uv.QualificationID = CRow["TrinhDoChuyenMon"] as string ;
            //     uv.EducationID = CRow["TrinhDoVanHoa"] as string;
            //     uv.LangID = CRow["NgoaiNgu"] as string;

            //    //get file liên quan của ứng viên sơ bộ
            //     tblUVSB_FilesLienQuan h = db.tblUVSB_FilesLienQuans.First(f => f.idUVSB == CRow["MaUVSB"].ToString());
            //    //thêm file liên quan
            //     tblUV_FilesLienQuan file_UV = new tblUV_FilesLienQuan();
            //     file_UV.idUV = uv.EmployeeID;
            //     file_UV.idFile = h.idFile;
            //     file_UV.ghiChu = h.ghiChu;
            //     file_UV.CurriculumVitaeCode = h.CurriculumVitaeCode;

            //    //Insert ứng viên
            //     db.tblUngViens.InsertOnSubmit(uv);
            //     db.SubmitChanges();
            //    //insert file liên quan của ứng viên
            //     db.tblUV_FilesLienQuans.InsertOnSubmit(file_UV);
            //     db.SubmitChanges();
            //     btnFind_Click(null, null);
            //     GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            //}
            //catch
            //{
            //    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
            //}
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            if (grv.FocusedRowHandle != -1)
            {
                var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));


                if (drs.Count() == 0)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                    return;
                }

                CRow = grv.GetFocusedDataRow();
                ShowEditor();
                dlgEditor.CustomFormAction = 1;
                dlgEditor.MyValue = CRow;
                btnFind_Click(null, null);
            }
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

        private void frmKeHoachTuyenDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmKeHoachTuyenDung_Load(null, null);
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
