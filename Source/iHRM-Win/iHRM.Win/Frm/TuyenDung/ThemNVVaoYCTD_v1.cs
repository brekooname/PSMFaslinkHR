using iHRM.Core.Business;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using iHRM.Common.Code;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Reflection;

namespace iHRM.Win.Frm.TuyenDung
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class ThemNVVaoYCTD_v1 : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        public ThemNVVaoYCTD_v1()
        {
            InitializeComponent();
        }

        private void ThemNVVaoYCTD_v1_Load(object sender, EventArgs e)
        {
            TranslateForm();

            btnThemUV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);

            btnXoaUV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);

            grcDotTuyenDung.DataSource = db.tbDotTuyenDungs.OrderByDescending(p => p.BeginDate);
        }

        //Grid View: Đợt tuyển dụng
        private void grvDotTuyenDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var a = grvDotTuyenDung.GetFocusedRow() as tbDotTuyenDung;

            if (a != null)
            {
                grcYCTD.DataSource = Provider.ExecuteDataTableReader("p_tbYeuCauTuyenDung_GetAllByIdDotTD",

                                                    new System.Data.SqlClient.SqlParameter("idDotTD", a.id));
            }
            else
            {
                grcYCTD.DataSource = null;
            }
        }

        //Grid View: Yêu cầu tuyển dụng
        private void grvYCTD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = grvYCTD.GetFocusedDataRow();

            if (r != null)
            {
                grcNhanVien.DataSource = Provider.ExecuteDataTableReader("p_tblYeuCauTD_UngVien_GetByIdYCTD_v1",

                                                    new System.Data.SqlClient.SqlParameter("idYCTD", r["id"]));
            }
            else
            {
                grcNhanVien.DataSource = null;
            }
        }

        private void grvYCTD_DataSourceChanged(object sender, EventArgs e)
        {
            grvYCTD_FocusedRowChanged(null, null);
        }

        private void btnThemUV_Click(object sender, EventArgs e)
        {
            DataRow r = grvYCTD.GetFocusedDataRow();

            if (r != null)
            {
                dlgThemNVVaoYCTD_v1 _dlg = new dlgThemNVVaoYCTD_v1();

                if (_dlg.ShowDialog() == DialogResult.OK)
                {
                    if (_dlg.MyValue.Count() == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                        return;
                    }

                    try
                    {
                        var a = _dlg.MyValue.ToList();

                        grvDotTuyenDung_FocusedRowChanged(null, null);

                        if (r["isAccept"] != DBNull.Value)
                        {
                            if (!(bool)r["isAccept"])
                            {
                                GUIHelper.MessageError("Yêu cầu tuyển dụng này chưa được phê duyệt.", "Thêm nhân viên vào yêu cầu tuyển dụng");

                                return;
                            }

                            Provider.ExecuteNonQuery_SQL("INSERT tblYeuCauTD_NhanVien (idNV,idYCTD) VALUES " +
                                string.Join(",", _dlg.MyValue.Select(i => string.Format("('{0}','{1}')", i["EmployeeID"], r["id"])))
                            );

                            LogAction.LogAction.PushLog("Thêm dữ liệu"
                                                , string.Join(",", _dlg.MyValue.Select(i => string.Format("({0})", i["EmployeeID"])))
                                                , ""
                                                , string.Format("Thêm nhân viên vào yêu cầu tuyển dụng")
                                                , "tblYeuCauTD_NhanVien");

                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                            grvDotTuyenDung_FocusedRowChanged(null, null);
                        }
                        else
                        {
                            GUIHelper.MessageError("Yêu cầu tuyển dụng này chưa được phê duyệt.", "Thêm nhân viên vào yêu cầu tuyển dụng");
                        }
                    }
                    catch (Exception ex)
                    {
                        win_globall.ExecCatch(ex);
                    }
                }
            }
            else
            {
                GUIHelper.MessageError("Bạn chưa chọn yêu cầu tuyển dụng.", "Thêm ứng viên vào yêu cầu tuyển dụng");

                return;
            }
        }

        private void btnXoaUV_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả danh sách ứng viên trong yêu cầu tuyển dụng này?"
                                    , "Xóa danh sách ứng viên", MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                DataRow r = grvYCTD.GetFocusedDataRow();

                string idxoa = string.Empty;

                if (r != null && r["id"] != DBNull.Value)
                {
                    var a = grvNhanVien.GetSelectedRows();

                    if (a.Count() != 0)
                    {
                        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

                        foreach (var item in a)
                        {
                            var r2 = grvNhanVien.GetDataRow(item);

                            if (r2 != null && r2["EmployeeID"] != DBNull.Value)
                            {
                                var nv = db.tblYeuCauTD_NhanViens.FirstOrDefault(p => p.idNV == r2["EmployeeID"].ToString() && p.idYCTD.ToString() == r["id"].ToString());

                                if (nv != null)
                                {
                                    idxoa += r2["EmployeeID"].ToString() + ",";

                                    db.tblYeuCauTD_NhanViens.DeleteOnSubmit(nv);
                                }
                            }
                        }
                        try
                        {
                            db.SubmitChanges();

                            LogAction.LogAction.PushLog("Xóa dữ liệu"
                                                        , idxoa
                                                        , ""
                                                        , string.Format("Xóa ứng viên khỏi yêu cầu tuyển dụng")
                                                        , "tblYeuCauTD_NhanVien");

                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);

                            grvYCTD_FocusedRowChanged(null, null);
                        }
                        catch (Exception ex)
                        {
                            win_globall.ExecCatch(ex);
                        }
                    }
                    else
                    {
                        GUIHelper.MessageError("Bạn chưa chọn ứng viên.", "Xóa ứng viên khỏi yêu cầu tuyển dụng");

                        return;
                    }
                }
                else
                {
                    GUIHelper.MessageError("Bạn chưa chọn yêu cầu tuyển dụng.", "Thêm ứng viên vào yêu cầu tuyển dụng");

                    return;
                }
            }
        }

        private void grvNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcNhanVien.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void grvYCTD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcYCTD.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void grvDotTuyenDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcDotTuyenDung.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void ThemNVVaoYCTD_v1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                ThemNVVaoYCTD_v1_Load(null, null);
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
