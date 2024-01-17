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
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Frm.QuetThe;
using DevExpress.Skins;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Win.ExtClass;
using System.Reflection;

namespace iHRM.Win.Frm.Employee
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class frmGiayPhepLaoDong_v1 : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        DataTable dtData = new DataTable();

        List<ActionClass> _listActionClass = new List<ActionClass>();

        DataRow CRow;

        public frmGiayPhepLaoDong_v1()
        {
            InitializeComponent();
        }

        private void frmGiayPhepLaoDong_v1_Load(object sender, EventArgs e)
        {
            TranslateForm();
            btnFind_Click(null, null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            dw_it.Caption = "Đang tải dữ liệu...";

            dw_it.OnDoing = (s, ev) =>
            {
                dtData = Provider.ExecuteDataTable("p_tblGiayPhepLaoDong_GetAll"
                                                    , new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text)
                                                    , new System.Data.SqlClient.SqlParameter("tuNgay", chonKyLuong1.TuNgay)
                                                    , new System.Data.SqlClient.SqlParameter("denNgay", chonKyLuong1.DenNgay));

                dw_it.bw.ReportProgress(1, dtData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState;

                    btnFind.Enabled = true;
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
                if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa giấy phép lao động đã chọn"))
                {
                    if (drs.Count() == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                        return;
                    }

                    foreach (var item in drs)
                    {
                        tblGiayPhepLaoDong a = db.tblGiayPhepLaoDongs.Where(x => x.id.ToString() == item["id"].ToString()).FirstOrDefault();

                        if (a == null)
                        {
                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                            return;
                        }


                        db.tblGiayPhepLaoDongs.DeleteOnSubmit(a);
                        LogAction.LogAction.PushLog("Xóa dữ liệu phép lao động số " + item["soGiayPhep"].ToString()
                                                    , item["EmployeeID"].ToString()
                                                    , ""
                                                    , string.Format("Xóa giấy phép lao động số ") + item["soGiayPhep"].ToString()
                                                    , "tblGiayPhepLaoDong");
                    }

                    try
                    {
                        db.SubmitChanges();

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

        private void btnThemNV_Click_Click(object sender, EventArgs e)
        {
            dlgGiayPhepLaoDong_v1 _dlg = new dlgGiayPhepLaoDong_v1();

            _dlg._flag = 0;

            _dlg.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            dlgGiayPhepLaoDong_v1 _dlg = new dlgGiayPhepLaoDong_v1();

            if (grv.GetFocusedDataRow() != null) //Kiểm tra Focused có dữ liệu
            {
                int[] rc = grv.GetSelectedRows(); //Lấy dữ liệu trong lưới

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        if (grv.FocusedRowHandle != -1)
                        {
                            CRow = grv.GetFocusedDataRow();

                            _dlg._flag = 1;

                            _dlg._CRow = CRow;

                            _dlg.ShowDialog();
                        }
                    }
                }
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

        private void frmGiayPhepLaoDong_v1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmGiayPhepLaoDong_v1_Load(null, null);
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
    }
}
