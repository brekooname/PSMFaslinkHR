using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Linq;
using iHRM.Win.Frm.LogAction;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Transactions;
using iHRM.Core.Business.Logic;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class frmDangKyCaLam : frmBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        //dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        List<ActionClass> _lActionLog = new List<ActionClass>();

        dlgDangKyCaLam dlgDKCaLam;

        public frmDangKyCaLam()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            //if (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin)
            //{
            //    toolStripAccept.Visible = true;

            //    toolStripAcceptAll.Visible = true;

            //    toolStripGoDuyet.Visible = true;
            //}
            //else
            //{
            //    toolStripAccept.Visible = false;

            //    toolStripAcceptAll.Visible = false;

            //    toolStripGoDuyet.Visible = false;
            //}
            TranslateForm();
            LoadGrvLayout(grv);
         
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (chonPhongBan1.SelectedValue == null)
            {
                GUIHelper.MessageBox("Cần chọn phòng ban");

                return;
            }

            btnFind.Enabled = false;

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            dw_it.Caption = "Đang tải dữ liệu đăng ký ca làm...";

            dw_it.OnDoing = (s, ev) =>
            {
                var dt = logic.GetDataDangKyCaLam(
                    txtSearchKey.Text == "" ? null : txtSearchKey.Text,
                    chonKyLuong1.TuNgay,
                    chonKyLuong1.DenNgay,
                    chonPhongBan1.SelectedValue
                );

                dw_it.bw.ReportProgress(1, dt);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = data.UserState; btnFind.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
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

            var db = new dcDatabaseDataContext(Provider.ConnectionString);

            var lst = db.tbDangKyCaLams.Where(i => drs.Select(j => j["id"] as Guid?).Contains(i.id)).ToList();

            if (lst == null || lst.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }

            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả đăng ký ca làm đang chọn?"
                                        , "Xóa tất cả đăng ký vắng mặt đang chọn"
                                        , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                try
                {
                    _lActionLog.Clear();

                    bool isHaveLockedRecord = false;

                    List<tbDangKyCaLam> listDKCaLam_NoLock = new List<tbDangKyCaLam>();

                    foreach (tbDangKyCaLam item in lst)
                    {
                        if (IsLock.IsLock.Check_IsLock("tbDangKyCaLam", item.ngay.Value))
                        {
                            isHaveLockedRecord = true;
                        }
                        else
                        {
                            if (IsLock.IsLock.Check_DangKyCaLam(item.EmployeeID, item.ngay.Value))
                            {
                            }
                            else
                            {
                                listDKCaLam_NoLock.Add(item);
                            }
                        }
                    }
                    foreach (tbDangKyCaLam item in listDKCaLam_NoLock)
                    {
                        _lActionLog.Add(new ActionClass("Xóa dữ liệu"
                                                        , item.EmployeeID
                                                        , ""
                                                        , string.Format("Xóa đăng ký ca làm ngày {0:dd/MM/yyyy}, idCaLam ={1}", item.ngay, item.idCaLam)
                                                        , "tbDangKyCaLam"));
                    }
                    //using (var transaction = new TransactionScope())
                    //{
                        try
                        {
                            db.tbDangKyCaLams.DeleteAllOnSubmit(listDKCaLam_NoLock);

                            foreach (tbDangKyCaLam item in listDKCaLam_NoLock)
                            {
                                var kqqt = db.tbKetQuaQuetThes.Where(p => p.EmployeeID == item.EmployeeID && p.ngay == item.ngay).FirstOrDefault();

                                if (kqqt != null)
                                {
                                    if (!IsLock.IsLock.Check_IsLock("tbKetQuaQuetThe", item.ngay.Value))
                                    {
                                        db.tbKetQuaQuetThes.DeleteOnSubmit(kqqt);

                                        _lActionLog.Add(new ActionClass("Xóa dữ liệu"
                                                                        , item.EmployeeID
                                                                        , ""
                                                                        , string.Format("Xóa dữ liệu kết quả quẹt thẻ ngày {0:dd/MM/yyyy}, EmployeeID ={1} do xóa đăng ký ca làm", item.ngay, item.EmployeeID)
                                                                        , "tbKetQuaQuetThe"));
                                    }
                                }
                            }

                            db.SubmitChanges();

                            if (isHaveLockedRecord)
                            {
                                GUIHelper.Notifications(string.Format("Có {0} bản ghi không được xóa vì đã chốt công.", lst.Count - listDKCaLam_NoLock.Count)
                                                        , "Xóa dữ liệu"
                                                        , GUIHelper.NotifiType.info);
                            }
                            else
                            {
                                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);

                                LogAction.LogAction.PushLog(_lActionLog);

                                grv.DeleteSelectedRows();
                            }
                            

                            //transaction.Complete();
                        }
                        catch (Exception ex)
                        {
                            GUIHelper.MessageBox(ex.Message, "Xóa dữ liệu không thành công.");
                        }
                    //}
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dlgDKCaLam != null)
            {
                dlgDKCaLam.ShowDialog();
            }
            else
            {
                dlgDKCaLam = new dlgDangKyCaLam();

                dlgDKCaLam.ShowDialog();
            }
        }

        private void toolStripAcceptAll_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn chốt tất cả các đăng ký ca làm?"
                                    , "Duyệt đăng ký ca làm"
                                    , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                for (int i = 0; i < grv.DataRowCount; i++)
                {
                    var r = grv.GetDataRow(i);
                        if (r != null)
                        {
                            //if (IsLock.IsLock.Check_IsLock("tbDangKyCaLam", Convert.ToDateTime(r["ngay"].ToString())))
                            //{
                            //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            //    continue;
                            //}
                            if (IsLock.IsLock.Check_IsLock_Type("tbDangKyCaLam", Convert.ToDateTime(r["ngay"].ToString()),1))
                            {
                                GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                                continue;
                            }

                            if (LoginHelper.user.idKhoiPB != null 
                                && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                            {
                                continue;
                            }

                            if ((r["isAccept"] as bool? == true))
                            {
                                continue;
                            }

                            Provider.ExecNoneQuery("p_tbDangKyCaLam_updateIsAccept",
                                new System.Data.SqlClient.SqlParameter("id", r["id"]),
                                new System.Data.SqlClient.SqlParameter("isAccept", true),
                                new System.Data.SqlClient.SqlParameter("ngayAccept", DateTime.Now),
                                new System.Data.SqlClient.SqlParameter("userAccept", LoginHelper.user.id));

                            _lActionLog.Add(new ActionClass("Chốt đăng ký ca làm"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , string.Format("Chốt đăng ký ca làm ngày {0:dd/MM/yyyy}"
                                                            , Convert.ToDateTime(r["ngay"])), "tbDangKyCaLam"));
                        }
                    }

                    LogAction.LogAction.PushLog(_lActionLog);

                }
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {
            _lActionLog.Clear();

            var dg = MessageBox.Show("Bạn có chắc chắn muốn chốt dữ liệu đang chọn?"
                                    , "Chốt đăng ký ca làm"
                                    , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tbDangKyCaLam", Convert.ToDateTime(r["ngay"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}

                        if (IsLock.IsLock.Check_IsLock_Type("tbDangKyCaLam", Convert.ToDateTime(r["ngay"].ToString()), 1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                            continue;
                        }

                        if (LoginHelper.user.idKhoiPB != null 
                            && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }

                        if ((r["isAccept"] as bool? == true))
                        {
                            continue;
                        }

                        Provider.ExecNoneQuery("p_tbDangKyCaLam_updateIsAccept",
                            new System.Data.SqlClient.SqlParameter("id", r["id"]),
                            new System.Data.SqlClient.SqlParameter("isAccept", true),
                            new System.Data.SqlClient.SqlParameter("ngayAccept", DateTime.Now),
                            new System.Data.SqlClient.SqlParameter("userAccept", LoginHelper.user.id));

                        _lActionLog.Add(new ActionClass("Chốt đăng ký ca làm"
                                                        , r["EmployeeID"].ToString()
                                                        , ""
                                                        , string.Format("Chốt đăng ký ca làm ngày {0:dd/MM/yyyy}", Convert.ToDateTime(r["ngay"]))
                                                        , "tbDangKyCaLam"));
                    }
                }

                LogAction.LogAction.PushLog(_lActionLog);

            }
        }

        private void toolStripGoDuyet_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ chốt dữ liệu đang chọn?"
                                    , "Gỡ chốt đăng ký ca làm"
                                    , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                 int[] rc = grv.GetSelectedRows();

                 for (int i = rc.Count(); i > 0; i--)
                 {
                     var r = grv.GetDataRow(rc[i - 1]);
                     if (r != null)
                     {
                         //if (IsLock.IsLock.Check_IsLock("tbDangKyCaLam", Convert.ToDateTime(r["ngay"].ToString())))
                         //{
                         //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                         //    continue;
                         //}
                         if (IsLock.IsLock.Check_IsLock_Type("tbDangKyCaLam", Convert.ToDateTime(r["ngay"].ToString()),1))
                         {
                             GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                             continue;
                         }
                         if (LoginHelper.user.idKhoiPB != null 
                             && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                         {
                             continue;
                         }

                         if ((r["isAccept"] as bool? != true))
                         {
                             continue;
                         }

                         Provider.ExecNoneQuery("p_tbDangKyCaLam_updateIsAccept",
                             new System.Data.SqlClient.SqlParameter("id", r["id"]),
                             new System.Data.SqlClient.SqlParameter("isAccept", null),
                             new System.Data.SqlClient.SqlParameter("ngayAccept", null),
                             new System.Data.SqlClient.SqlParameter("userAccept", null));

                         _lActionLog.Add(new ActionClass("Gỡ chốt đăng ký ca làm"
                                                         , r["EmployeeID"].ToString()
                                                         , ""
                                                         , string.Format("Gỡ chốt đăng ký ca làm ngày {0:dd/MM/yyyy}", Convert.ToDateTime(r["ngay"]))
                                                         , "tbDangKyCaLam"));
                     }
                 }

                 LogAction.LogAction.PushLog(_lActionLog);
            }
        }

        private void grv_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
        }

        private void grv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 
                && grv.GetRowCellValue(e.RowHandle, "isAccept") != null 
                && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAccept").ToString()))
            {
                if (grv.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "True")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else if (grv.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "False")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
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
        
           
            #endregion
        }

        #endregion

        private void frmDangKyCaLam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmDangKyCaLam_Load(null, null);
            }
        }
       

    }
}
