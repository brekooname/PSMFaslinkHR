using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Reflection;

namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    public partial class CaLam :  frmBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
        DataTable Data;
        DataRow CRow;

        dlgCaLam _dlgEditor = null;
        dlgCaLam dlgEditor
        {
            get
            {
                if (_dlgEditor == null)
                {
                    _dlgEditor = new dlgCaLam();
                    dlgEditor.Owner = this;
                    dlgEditor.OnSave += dlgEditor_OnSave;
                }
                return _dlgEditor;
            }
            set
            {
                _dlgEditor = value;
            }
        }

        public CaLam()
        {
            InitializeComponent();
        }

        private void CaLam_Load(object sender, EventArgs e)
        {
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            rep_Dept.DataSource = db.tblRef_Departments;
            buttonPanel1_OnFind(null, null);
            TranslateForm();
        }

        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CRow = grv.GetFocusedDataRow();
        }

        private void buttonPanel1_OnFind(object sender, EventArgs e)
        {
            Data = logic.GetAll();
            grd.DataSource = Data;
        }
        private void buttonPanel1_OnNew(object sender, EventArgs e)
        {
            DataRow r = Data.NewRow();
            r["caDem"] = false;
            r["kqNgayCong"] = 1;
            dlgEditor.MyValue = r;
            dlgEditor.Show();
        }
        private void buttonPanel1_OnEdit(object sender, EventArgs e)
        {
            dlgEditor.MyValue = CRow;
            dlgEditor.Show();
        }
        private void buttonPanel1_OnDelete(object sender, EventArgs e)
        {
            if (CRow == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            var it = db.tbCaLamViecs.SingleOrDefault(i => i.id == DbHelper.DrGetGuid(CRow, TableConst.tbCaLamViec.id));

            if (it != null)
            {
                try
                {
                    if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa ?"))
                        return;

                    var _check = db.tbKetQuaQuetThes.Where(i => i.idCaLam == DbHelper.DrGetGuid(CRow, TableConst.tbCaLamViec.id)).ToList();

                    if(_check.Count != 0)
                    {
                        GUIHelper.MessageBox("Ca làm đã được xử lý quẹt thẻ. Không thể xóa!");

                        return;
                    }

                    if (it.isSystem)
                    {
                        GUIHelper.MessageBox("Ca làm của hệ thống. Không thể xóa!");

                        return;
                    }

                    LogAction.LogAction.PushLog("Xóa", "", "", string.Format("Xóa thông tin ca làm: {0}, Kết quả ngày công: {1}, Từ giờ: {2}, Đến giờ: {3}, Quẹt trước vào: {4}, Quẹt trước ra: {5},"
                     + " Quẹt sau vào: {6}, Quẹt sau ra: {7}, Số tiếng tính ca: {9}, Số tiếng tăng ca trách nhiệm: {10}, Ca sáng từ giờ: {11}, Ca sáng đến giờ: {12}, "
                     + " Ca chiều từ giờ: {13}, Ca chiều đến giờ: {14}, Là ca đêm: {15}, T7 làm sáng: {16}, Không cần quét thẻ: {17}, Alias: {18}, Khối PB: {19}",
                       it.ten.ToString(), //0
                       it.kqNgayCong.ToString(),//1
                       it.tuGio.ToString(),//2
                       it.denGio.ToString(),//3
                       it.tgQuetTruoc_Vao.ToString(),//4
                       it.tgQuetTruoc_Ra.ToString(),//5
                       it.tgQuetSau_Vao.ToString(),//6
                       it.tgQuetSau_Ra.ToString(),//7
                       it.soTiengTinhCa.ToString(),//8
                       it.soTiengTangCaTrachNhiem.ToString(),//9
                       it.soTiengTinhTangCa.ToString(),//10
                       it.caSang_tuGio.ToString(),//11
                       it.caSang_denGio.ToString(),//12
                       it.caChieu_tuGio.ToString(),//13
                       it.caChieu_denGio.ToString(),//14
                       it.caDem.ToString(),//15
                       it.T7LamSang.ToString(),//16
                       it.isKhongCanQuetThe.ToString(),//17
                       it.Alias != null ? it.Alias.ToString() : "",//18
                       it.idKhoiPB.ToString()//19
                       ), "tbCaLamViec");

                    db.tbCaLam_TinhTangCas.DeleteAllOnSubmit(it.tbCaLam_TinhTangCas);
                    db.tbCaLamViecs.DeleteOnSubmit(it);
                    db.SubmitChanges();

                    Data.Rows.Remove(CRow);
                    grv_FocusedRowChanged(null, null);
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                }
                catch(Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
            else
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
            }
        }

        private void dlgEditor_OnSave(object sender, EventArgs e) //sự kiện khi ấn nút lưu ở dlg
        {
            try
            {
                dlgEditor.MyValue[TableConst.tbCaLamViec.id] = logic.InsertOrUpdate(dlgEditor.MyValue);

                if (dlgEditor.myID == null)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    Data.Rows.Add(dlgEditor.MyValue);


                    LogAction.LogAction.PushLog("Thêm", "", "", string.Format("Thêm thông tin ca làm: {0}, Kết quả ngày công: {1}, Từ giờ: {2}, Đến giờ: {3}, Quẹt trước vào: {4}, Quẹt trước ra: {5},"
                        + " Quẹt sau vào: {6}, Quẹt sau ra: {7}, Số tiếng tính ca: {9}, Số tiếng tăng ca trách nhiệm: {10}, Ca sáng từ giờ: {11}, Ca sáng đến giờ: {12}, "
                        + " Ca chiều từ giờ: {13}, Ca chiều đến giờ: {14}, Là ca đêm: {15}, T7 làm sáng: {16}, Không cần quét thẻ: {17}, Alias: {18}, Khối PB: {19}",
                          dlgEditor.MyValue[TableConst.tbCaLamViec.ten].ToString(), //0
                          dlgEditor.MyValue["kqNgayCong"].ToString(),//1
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tuGio].ToString(),//2
                          dlgEditor.MyValue[TableConst.tbCaLamViec.denGio].ToString(),//3
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tgQuetTruoc_Vao].ToString(),//4
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tgQuetTruoc_Ra].ToString(),//5
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tgQuetSau_Vao].ToString(),//6
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tgQuetSau_Ra].ToString(),//7
                          dlgEditor.MyValue[TableConst.tbCaLamViec.soTiengTinhCa].ToString(),//8
                          dlgEditor.MyValue[TableConst.tbCaLamViec.soTiengTangCaTrachNhiem].ToString(),//9
                          dlgEditor.MyValue[TableConst.tbCaLamViec.soTiengTinhTangCa].ToString(),//10
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caSang_tuGio].ToString(),//11
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caSang_denGio].ToString(),//12
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caChieu_tuGio].ToString(),//13
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caChieu_denGio].ToString(),//14
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caDem].ToString(),//15
                          dlgEditor.MyValue["T7LamSang"].ToString(),//16
                          dlgEditor.MyValue["isKhongCanQuetThe"].ToString(),//17
                          dlgEditor.MyValue["Alias"].ToString(),//18
                          dlgEditor.MyValue["idKhoiPB"].ToString()//19
                          ), "tbCaLamViec");

                }
                else
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);

                    LogAction.LogAction.PushLog("Cập nhật", "", "", string.Format("Cập nhật thông tin ca làm: {0}, Kết quả ngày công: {1}, Từ giờ: {2}, Đến giờ: {3}, Quẹt trước vào: {4}, Quẹt trước ra: {5},"
                        + " Quẹt sau vào: {6}, Quẹt sau ra: {7}, Số tiếng tính ca: {9}, Số tiếng tăng ca trách nhiệm: {10}, Ca sáng từ giờ: {11}, Ca sáng đến giờ: {12}, "
                        + " Ca chiều từ giờ: {13}, Ca chiều đến giờ: {14}, Là ca đêm: {15}, T7 làm sáng: {16}, Không cần quét thẻ: {17}, Alias: {18}, Khối PB: {19}",
                          dlgEditor.MyValue[TableConst.tbCaLamViec.ten].ToString(), //0
                          dlgEditor.MyValue["kqNgayCong"].ToString(),//1
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tuGio].ToString(),//2
                          dlgEditor.MyValue[TableConst.tbCaLamViec.denGio].ToString(),//3
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tgQuetTruoc_Vao].ToString(),//4
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tgQuetTruoc_Ra].ToString(),//5
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tgQuetSau_Vao].ToString(),//6
                          dlgEditor.MyValue[TableConst.tbCaLamViec.tgQuetSau_Ra].ToString(),//7
                          dlgEditor.MyValue[TableConst.tbCaLamViec.soTiengTinhCa].ToString(),//8
                          dlgEditor.MyValue[TableConst.tbCaLamViec.soTiengTangCaTrachNhiem].ToString(),//9
                          dlgEditor.MyValue[TableConst.tbCaLamViec.soTiengTinhTangCa].ToString(),//10
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caSang_tuGio].ToString(),//11
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caSang_denGio].ToString(),//12
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caChieu_tuGio].ToString(),//13
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caChieu_denGio].ToString(),//14
                          dlgEditor.MyValue[TableConst.tbCaLamViec.caDem].ToString(),//15
                          dlgEditor.MyValue["T7LamSang"].ToString(),//16
                          dlgEditor.MyValue["isKhongCanQuetThe"].ToString(),//17
                          dlgEditor.MyValue["Alias"].ToString(),//18
                          dlgEditor.MyValue["idKhoiPB"].ToString()//19
                          ), "tbCaLamViec");
                }
            }
            catch(Exception ex)
            {
                win_globall.ExecCatch(ex);
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
        private IEnumerable<DevExpress.XtraEditors.CheckEdit> EnumerateCheckEdit()
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
            var _CheckEdit = EnumerateCheckEdit();
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


            #endregion
        }

        #endregion

        private void CaLam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                CaLam_Load(null, null);
            }
        }


    }
}
