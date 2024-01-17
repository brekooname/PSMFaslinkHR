using DevExpress.XtraEditors;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iHRM.Win.Frm.LogAction;
using System.Collections.Generic;
using iHRM.Core.Business.Logic;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Reflection;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class frmDangKyCa7h : frmBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        dlgDangKyCa7h dlgDKCaLam7h;

        DataRow _CRow;

        public frmDangKyCa7h()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            TranslateForm();
            var dt = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name"
                                                    , new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));

            repNhanvien.DataSource = dt;

            repNhanvien.DisplayMember = "EmployeeName";

            repNhanvien.ValueMember = "EmployeeCode";

            repQLDuyet.DataSource = db.w5sysUsers;

            LoadGrvLayout(grvDK7h);

            btnFind_Click(null,null);
        }

        private void toolStripAddNew_Click(object sender, EventArgs e)
        {
            dlgDKCaLam7h = new dlgDangKyCa7h();

            dlgDKCaLam7h._flag = 0;

            dlgDKCaLam7h.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            dw_it.Caption = "Đang tải dữ liệu đăng ký ca làm 7 hours";

            dw_it.OnDoing = (s, ev) =>
            {
                var data = logic.GetDataDangKy7Hours(ucChonDoiTuong_DS1.GetValue()
                                                    , chonKyLuong1.TuNgay
                                                    , chonKyLuong1.DenNgay);

                dw_it.bw.ReportProgress(1, data);

            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grcDK7h.DataSource = data.UserState;

                    (grcDK7h.DataSource as DataTable).AcceptChanges();
                }
            };
            dw_it.OnCompleting = (s, a) =>
            {
                btnFind.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grvDK7h);
        }

        private void toolstripSave_Click(object sender, EventArgs e)
        {
            try
            {
                Provider.UpdateData((grcDK7h.DataSource as DataTable), "tblEmp7hours");

                (grcDK7h.DataSource as DataTable).AcceptChanges();

                LogAction.LogAction.PushLog("Sửa dữ liệu"
                                            , ""
                                            , ""
                                            , "Cập nhật bảng dữ liệu nhân viên làm 7h"
                                            , "tblEmp7hours");
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);

                frmDangKyCaLam_Load(null, null);
            }
            catch (Exception)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditFalse);
            }
        }

        private void toolStripUpdate_Click(object sender, EventArgs e)
        {
            if (grvDK7h.GetFocusedDataRow() != null) //Kiểm tra Focused có dữ liệu
            {
                int[] rc = grvDK7h.GetSelectedRows(); //Lấy dữ liệu trong lưới

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grvDK7h.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        if (grvDK7h.FocusedRowHandle != -1)
                        {

                            if (dlgDKCaLam7h != null)
                            {
                                _CRow = grvDK7h.GetFocusedDataRow();

                                dlgDKCaLam7h._flag = 1;

                                dlgDKCaLam7h._CRow = _CRow;

                                dlgDKCaLam7h.ShowDialog();
                            }
                            else
                            {
                                dlgDKCaLam7h = new dlgDangKyCa7h();

                                _CRow = grvDK7h.GetFocusedDataRow();

                                dlgDKCaLam7h._flag = 1;

                                dlgDKCaLam7h._CRow = _CRow;

                                dlgDKCaLam7h.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            var drs = grvDK7h.GetSelectedRows().Select(i => grvDK7h.GetDataRow(i));

            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }

            var db = new dcDatabaseDataContext(Provider.ConnectionString);

            var lst = db.tblEmp7hours.Where(p => drs.Select(j => j["EmployeeID"]).Contains(p.EmployeeID) && drs.Select(j => j["BeginDate"]).Contains(p.BeginDate)).ToList();

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
                    _listActionClass.Clear();

                    bool isHaveLockedRecord = false;

                    List<tblEmp7hour> listDKCaLam_NoLock = new List<tblEmp7hour>();

                    foreach (tblEmp7hour item in lst)
                    {
                        if (IsLock.IsLock.Check_IsLock("tblEmp7hours", item.RegistedDate.Value))
                        {
                            isHaveLockedRecord = true;
                        }
                        else
                        {
                            int count = db.tbKetQuaQuetThes.Where(p => p.EmployeeID == item.EmployeeID
                                                                    && p.is7Hours == true
                                                                    && p.ngay <= item.EndDate).Count();

                            if(count > 0)
                            {
                                isHaveLockedRecord = true;
                            }
                            else
                            {
                                listDKCaLam_NoLock.Add(item);
                            }
                        }
                    }

                    foreach (tblEmp7hour item in listDKCaLam_NoLock)
                    {
                        _listActionClass.Add(new ActionClass("Xóa dữ liệu"
                                                        , item.EmployeeID
                                                        , ""
                                                        , string.Format("Xóa đăng ký ca làm 7 giờ ngày {0:dd/MM/yyyy}, Mã nv = {1}", item.RegistedDate, item.EmployeeID)
                                                        , "tblEmp7hours"));
                    }
                    try
                    {
                        db.tblEmp7hours.DeleteAllOnSubmit(listDKCaLam_NoLock);

                        db.SubmitChanges();

                        if (isHaveLockedRecord)
                        {
                            GUIHelper.Notifications(string.Format("Có {0} bản ghi không được xóa vì đã có dữ liệu công.", lst.Count - listDKCaLam_NoLock.Count)
                                                    , "Xóa dữ liệu"
                                                    , GUIHelper.NotifiType.info);
                        }
                        else
                        {
                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);

                            LogAction.LogAction.PushLog(_listActionClass);

                            grvDK7h.DeleteSelectedRows();
                        }
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

        private void grvDK7h_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grvDK7h.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["RegistedDate"] = DateTime.Now;

                dr["isLate"] = false;
            }
        }

        private void grvDK7h_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colChon)
            {
                if (grvDK7h.GetRowCellValue(e.RowHandle, colChon) != null)
                {
                    string empID = grvDK7h.GetRowCellValue(e.RowHandle, colChon).ToString();

                    dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

                    var emp = db.tblEmployees.Where(p => p.EmployeeID == empID).FirstOrDefault();

                    if (emp != null)
                    {
                        grvDK7h.SetRowCellValue(e.RowHandle, colEmployeeName, emp.EmployeeName);
                    }
                }

            }

            if(e.Column == colNgaySinhCon)
            {
                if(grvDK7h.GetRowCellValue(e.RowHandle, colNgaySinhCon) != null)
                {
                    try
                    {
                        DateTime _ngayKT = DateTime.Parse(grvDK7h.GetRowCellValue(e.RowHandle, colNgaySinhCon).ToString());

                        this.grvDK7h.SetFocusedRowCellValue(colNgayKetThuc
                                                        , _ngayKT.AddYears(1).AddDays(-1));
                    }
                    catch(Exception)
                    {}
                    
                }

            }
        }

        private void grvDK7h_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column == colXoa)
            {
                int[] rc = grvDK7h.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grvDK7h.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        if ((r["isAccept"] != DBNull.Value))
                        {
                            GUIHelper.MessageBox("Đăng ký đã được duyệt không thể xóa.");

                            continue;
                        }

                        grvDK7h.DeleteSelectedRows();
                    }
                }
                
            }
        }

        private void grvDK7h_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void grvDK7h_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = grvDK7h.GetDataRow(e.RowHandle);
            if (r != null && r.RowState != DataRowState.Unchanged)
            {
                if (r["RegistedDate"] == DBNull.Value || r["RegistedDate"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập ngày đăng ký.\n");
                    e.Valid = false;
                    return;
                }
                if (r["BeginDate"] == DBNull.Value || r["BeginDate"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập ngày bắt đầu.\n");
                    e.Valid = false;
                    return;
                }
                if (r["EndDate"] == DBNull.Value || r["EndDate"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập ngày kết thúc.\n");
                    e.Valid = false;
                    return;
                }

                DateTime _BeginDate = DateTime.Parse(r["BeginDate"].ToString());

                DateTime _EndDate = DateTime.Parse(r["EndDate"].ToString());

                if (DateTime.Compare(_BeginDate.Date, _EndDate.Date) > 0)
                {
                    e.ErrorText = ("Ngày kết thúc không nhỏ hơn ngày bắt đầu.\n");
                    e.Valid = false;
                    return;
                }
                if (IsLock.IsLock.Check_IsLock("tblEmp7hours", Convert.ToDateTime(r["BeginDate"].ToString())))
                {
                    e.ErrorText = ("Dữ liệu đã chốt công khổng thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
            }
        }

        private void repNhanvien_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;

            this.grvDK7h.SetFocusedRowCellValue(colChon, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeCode"));

            this.grvDK7h.SetFocusedRowCellValue(colEmployeeName, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeName"));

            this.grvDK7h.SetFocusedRowCellValue(colPosName, searchEdit.Properties.View.GetFocusedRowCellValue("EmpTypeName"));

            this.grvDK7h.SetFocusedRowCellValue(colDepName_Final, searchEdit.Properties.View.GetFocusedRowCellValue("DepName_Final"));
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {

        }

        private void toolStripAcceptAll_Click(object sender, EventArgs e)
        {

        }

        private void toolStripGoDuyet_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ bỏ đăng ký đang chọn?"
                                    , "Khóa đăng ký"
                                    , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                int[] rc = grvDK7h.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grvDK7h.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        if (LoginHelper.user.idKhoiPB != null &&
                            !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }

                        if ((r["isAccept"] == DBNull.Value))
                        {
                            continue;
                        }

                        if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                        {
                            continue;
                        }

                        r["isAccept"] = DBNull.Value;

                        r["userAccept"] = DBNull.Value;

                        r["ngayAccept"] = DBNull.Value;

                        _listActionClass.Add(new ActionClass("Gỡ duyệt"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Gỡ duyệt đăng ký ca làm 7 giờ nhân viên"
                                                            , "tblEmp7hours"));
                    }
                }
            }
        }

        private void grvDK7h_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && grvDK7h.GetRowCellValue(e.RowHandle, "isAccept") != null
                && !string.IsNullOrEmpty(grvDK7h.GetRowCellValue(e.RowHandle, "isAccept").ToString()))
            {

                if (grvDK7h.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "True")
                {
                    e.Appearance.ForeColor = Color.Green;
                }

                else if (grvDK7h.GetRowCellValue(e.RowHandle, "isAccept").ToString() == "False")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void grcDK7h_DataSourceChanged(object sender, EventArgs e)
        {
            _CRow = grvDK7h.GetFocusedDataRow();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grcDK7h);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void grvDK7h_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcDK7h.FocusedView as GridView;
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
            //cmbLoaiLamThem.Properties.Columns[0].Caption = SelectTranslate("dlgDangKyLamThem_CalamID", langTrans);
            //cmbLoaiLamThem.Properties.Columns[1].Caption = SelectTranslate("dlgDangKyLamThem_CalamTen", langTrans);

            #endregion
        }

        #endregion

        private void frmDangKyCa7h_KeyDown(object sender, KeyEventArgs e)
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
