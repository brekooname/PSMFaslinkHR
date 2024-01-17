using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Common.Code;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Reflection;
using System.Collections.Generic;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class frmDotTuyenDung : frmBase
    {
        global::iHRM.Core.Business.Logic.TuyenDung.DotTuyenDung logic = new global::iHRM.Core.Business.Logic.TuyenDung.DotTuyenDung();
       
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        DataTable dtData = new DataTable();
        
        DataRow CRow;
       
        dlgDotTuyenDung dlgEditor;

        public frmDotTuyenDung()
        {
            InitializeComponent();

        }

        private void frmDotTuyenDung_Load(object sender, EventArgs e)
        {
            TranslateForm();

            btnThemNV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            
            toolXoa.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);
            
            toolExcel.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            
            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);

            lookupDonViCongTac.DataSource = db.tblRef_Positions;
            
            lookupTrangThaiTD.DataSource = Enums.elTrangThaiTD;

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

                dtData = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearch.Text),

                    new System.Data.SqlClient.SqlParameter("tuNgay", chonKyLuong1.TuNgay),

                    new System.Data.SqlClient.SqlParameter("denNgay", chonKyLuong1.DenNgay)

                    );

                dw_it.bw.ReportProgress(1, dtData);

                dw_it.bw.ReportProgress(2, logic.VirtualPaging.RecordCount);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grcDotTD.DataSource = data.UserState; btnFind.Enabled = true;
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
            ExportGrid(grcDotTD);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var drs = grvDotTD.GetSelectedRows().Select(i => grvDotTD.GetDataRow(i));

            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }
            else
            {
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa kế hoạch tuyển dụng đã chọn"))
                {
                    db = new dcDatabaseDataContext(Provider.ConnectionString);

                    foreach (var item in drs)
                    {
                        var a = db.tbDotTuyenDungs.Where(i => i.id.ToString() == item["id"].ToString()).FirstOrDefault();
                        
                        if (a == null)
                        {
                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                            
                            return;
                        }

                        db.tbDotTuyenDungs.DeleteOnSubmit(a);
                    }
                    try
                    {
                        db.SubmitChanges();

                        LogAction.LogAction.PushLog("Xóa dữ liệu", "", "", string.Format("Xóa đợt tuyển dụng "), "tbDotTuyenDung");
                        
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                        
                        grvDotTD.DeleteSelectedRows();
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
                dlgEditor = new dlgDotTuyenDung();

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
                if (dlgEditor.MyValue["tenDotTD"] == null || dlgEditor.MyValue["tenDotTD"].ToString() == "")
                {
                    GUIHelper.MessageError("Bạn chưa nhập tên đợt tuyển dụng.", "Không thể lưu");
                    return;
                }

                if (dlgEditor.MyValue["BeginDate"] == null || dlgEditor.MyValue["BeginDate"].ToString() == "")
                {
                    GUIHelper.MessageError("Bạn chưa nhập ngày bắt đầu.", "Không thể lưu");
                    return;
                }

                if (dlgEditor.MyValue["EndDate"] == null || dlgEditor.MyValue["EndDate"].ToString() == "")
                {
                    GUIHelper.MessageError("Bạn chưa nhập ngày kết thúc.", "Không thể lưu");
                    return;
                }

                if (Convert.ToDateTime(dlgEditor.MyValue["EndDate"]) < Convert.ToDateTime(dlgEditor.MyValue["BeginDate"]))
                {
                    GUIHelper.MessageError("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.", "Không thể lưu");
                    return;
                }

                if (dlgEditor.MyValue["trangThaiThucHien"] == null || dlgEditor.MyValue["trangThaiThucHien"].ToString() == "")
                {
                    GUIHelper.MessageError("Bạn chưa chọn trạng thái thực hiện.", "Không thể lưu");
                    return;
                }

                #endregion

                db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

                tbDotTuyenDung kh;

                if (dlgEditor.CustomFormAction == 0)//Thêm mới
                {
                    kh = new tbDotTuyenDung();
                    //var count = db.tbDotTuyenDungs.Count().
                }
                else
                {
                    kh = db.tbDotTuyenDungs.FirstOrDefault(p => p.id == Convert.ToInt32(dlgEditor.MyValue["id"]));
                }

                int _check = 0;

                _check = db.tbDotTuyenDungs.Where(p => p.soChungTu != dlgEditor.MyValue["soChungTu"].ToString()
                                        && p.BeginDate.Year == Convert.ToDateTime(dlgEditor.MyValue["BeginDate"]).Year
                                        && p.BeginDate.Month == Convert.ToDateTime(dlgEditor.MyValue["BeginDate"]).Month
                                        && p.BeginDate.Day == Convert.ToDateTime(dlgEditor.MyValue["BeginDate"]).Day).Count();

                if(_check != 0)
                {
                    GUIHelper.MessageBox("Ngày tạo đợt tuyển dụng đã tồn tại. Vui lòng chọn ngày khác!");

                    return;
                }

                //kh.s = dlgEditor.MyValue["tenDotTD"] as string;

                kh.tenDotTD = dlgEditor.MyValue["tenDotTD"] as string;

                //kh.PosID = dlgEditor.MyValue["PosID"] as string;

                kh.trangThaiThucHien = dlgEditor.MyValue["trangThaiThucHien"] as int?;

                //kh.yeuCauTuyenDung = dlgEditor.MyValue["yeuCauTuyenDung"] as string;

                kh.BeginDate = Convert.ToDateTime(dlgEditor.MyValue["BeginDate"]);

                kh.EndDate = Convert.ToDateTime(dlgEditor.MyValue["EndDate"]);

                kh.donViCongTac = dlgEditor.MyValue["donViCongTac"] as string;

                kh.soChungTu = dlgEditor.MyValue["soChungTu"] as string;

                kh.soLuongDuKien = dlgEditor.MyValue["soLuongDuKien"] as double?;

                kh.chiPhiDuKien = dlgEditor.MyValue["chiPhiDuKien"] as double?;

                kh.ghiChu = dlgEditor.MyValue["ghiChu"] as string;

                if (dlgEditor.CustomFormAction == 0)//Thêm mới
                {
                    db.tbDotTuyenDungs.InsertOnSubmit(kh);

                    db.SubmitChanges();

                    dlgEditor._idDotTD = db.tbDotTuyenDungs.OrderByDescending(p => p.id).First().id;

                    dlgEditor.MyValue["id"] = dlgEditor._idDotTD;

                    LogAction.LogAction.PushLog("Thêm dữ liệu", "", "", "Thêm mới đợt tuyển dụng id=" + dlgEditor._idDotTD, "tbDotTuyenDung");
                    
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                }
                else
                {
                    db.SubmitChanges();

                    LogAction.LogAction.PushLog("Sửa dữ liệu", "", "", "Cập nhật đợt tuyển dụng id=" + dlgEditor._idDotTD, "tbDotTuyenDung");
                    
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }

                btnFind_Click(null, null);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }

            dlgEditor.Close();
        }
        private void btnThemNV_Click_Click(object sender, EventArgs e)
        {
            ShowEditor();

            var r = dtData.NewRow();

            r["trangThaiThucHien"] = 0;

            dlgEditor.CustomFormAction = 0;

            dlgEditor.MyValue = r;
        }
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (grvDotTD.FocusedRowHandle != -1)
            {
                CRow = grvDotTD.GetFocusedDataRow();

                ShowEditor();

                dlgEditor.CustomFormAction = 1;

                dlgEditor.MyValue = CRow;
            }
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            CRow = grvDotTD.GetFocusedDataRow();
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void txtSearchKey_Leave(object sender, EventArgs e)
        {
            btnFind_Click(sender, e);
        }

        private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (grvDotTD.FocusedRowHandle != -1)
            {
                CRow = grvDotTD.GetFocusedDataRow();

                ShowEditor();

                dlgEditor.CustomFormAction = 1;

                dlgEditor._flagUpdate = 1;

                dlgEditor.MyValue = CRow;
            }
        }

        private void grvDotTD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcDotTD.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
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

        private void frmDotTuyenDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmDotTuyenDung_Load(null, null);
            }
        }
    }
}
