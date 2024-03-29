﻿using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Frm.XtraReportTemplate;
using DevExpress.XtraGrid;
using System.Reflection;

namespace iHRM.Win.Frm.TuyenDung
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class frmYeuCauTuyenDung_v1 : frmBase
    {
        //Khai báo biến//
        LogicBase _logic = new LogicBase();

        DataTable _dt = new DataTable();

        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        //String _FilesChoised = "";

        DataRow _CRow;

        DataTable _dtData = new DataTable();
        //---//

        public frmYeuCauTuyenDung_v1()
        {
            InitializeComponent();
        }

        private void frmYeuCauTuyenDung_v1_Load_1(object sender, EventArgs e)
        {
            TranslateForm();
            ///
            var _dttd = _db.tblRef_Educations;

            repItemTrinhDo.DataSource = _dttd;

            ///
            var _dtvttd = _db.tblRef_Positions;

            repItemVTriTD.DataSource = _dtvttd;

            ///
            var _dtdtd = _db.tbDotTuyenDungs;

            repItemidDotTD.DataSource = _dtdtd;

            ///
            repItemQLDuyet.DataSource = _db.w5sysUsers;

            _listActionClass.Clear();

            if (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin)
            {
                toolStripAccept.Visible = true;
                toolStripNotAccept.Visible = true;
                toolStripAcceptAll.Visible = true;
                toolStripGoDuyet.Visible = true;
                rdAccept.Visible = false;
            }
            else
            {
                toolStripAccept.Visible = false;
                toolStripNotAccept.Visible = false;
                toolStripAcceptAll.Visible = false;
                toolStripGoDuyet.Visible = false;
                rdAccept.Visible = true;
            }

            if (LoginHelper.user.isAcceptBP == true || LoginHelper.user.isAdmin)
            {
                rdAccept.Visible = false;
            }
            else
            {
                rdAccept.Visible = true;
            }

            btnSearch_Click(null, null);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dlgYeuCauTuyenDung_v1 _dlg = new dlgYeuCauTuyenDung_v1();

            _dlg._flag = 0;

            _dlg.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dlgYeuCauTuyenDung_v1 _dlg = new dlgYeuCauTuyenDung_v1();

            if (grv.GetFocusedDataRow() != null) //Kiểm tra Focused có dữ liệu
            {
                int[] rc = grv.GetSelectedRows(); //Lấy dữ liệu trong lưới

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {
                        if (r["isAccept"] != DBNull.Value) return; //Không sửa đơn đã duyệt hoặc chốt

                        if (grv.FocusedRowHandle != -1)
                        {

                            if (_dlg != null)
                            {
                                _CRow = grv.GetFocusedDataRow();

                                _dlg._flag = 1;

                                _dlg._CRow = _CRow;

                                _dlg.ShowDialog();
                            }
                            else
                            {
                                _dlg = new dlgYeuCauTuyenDung_v1();

                                _CRow = grv.GetFocusedDataRow();

                                _dlg._flag = 1;

                                _dlg._CRow = _CRow;

                                _dlg.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item _dw_it = new mainBase.Dowork_Item();

            String _table_name = "p_GetYeuCauTuyenDung_byStrDep_v1";

            _dw_it.Caption = "Đang tải dữ liệu nhân viên...";

            _dw_it.OnDoing = (s, ev) =>
            {
                _logic.VirtualPaging.PageSize = pageNavigator1.PageSize;

                _logic.VirtualPaging.Page = pageNavigator1.CurrentPage;

                bool? isAccept = null;

                if (rdAccept.SelectedIndex == 1)
                {
                    isAccept = true;
                }

                if (rdAccept.SelectedIndex == 2)
                {
                    isAccept = false;
                }

                SqlParameter[] _par = {
                                new SqlParameter("@tuNgay", chonKyLuong1.TuNgay),

                                new SqlParameter("@denNgay", chonKyLuong1.DenNgay_End),

                                Provider.CreateParameter_StringList("@dtEmpID", ucChonDoiTuong_DS.GetValue()),

                                new SqlParameter("@isAccept", isAccept)
                                };

                _dt = _logic.GetAllDep(_table_name, _par);

                _dw_it.bw.ReportProgress(1, _dt);

                _dw_it.bw.ReportProgress(2, _logic.VirtualPaging.RecordCount);
            };
            _dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState; btnSearch.Enabled = true;
                }
                else if (data.ProgressPercentage == 2)
                {
                    pageNavigator1.RecordCount = (int)data.UserState;
                }
            };

            main.Instance.DoworkItem_Reg(_dw_it);
        }

        private void grv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //GridView view = sender as GridView;

            //if (view == null) return;

            //if (e.Column == colisAccept && e.CellValue != null)
            //{
            //    if (e.CellValue.ToString() == "Đã duyệt")
            //    {
            //        e.Appearance.BackColor = Color.MediumSpringGreen;
            //    }
            //    else if (e.CellValue.ToString() == "Không duyệt")
            //    {
            //        e.Appearance.BackColor = Color.NavajoWhite;
            //    }
            //}
        }

        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "isAccept") != null
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

        private void toolStripAcceptAll_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các yêu cầu tuyển dụng?", "Duyệt yêu cầu tuyển dụng", MessageBoxButtons.OKCancel);
            
            if (dg == DialogResult.OK)
            {
                for (int i = 0; i < grv.DataRowCount; i++)
                {
                    var r = grv.GetDataRow(i);

                    if (r != null)
                    {
                        if (r["isAccept"] == DBNull.Value)
                        {
                            if (r["userAccept"] != DBNull.Value)
                            {
                                if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                                {
                                    continue;
                                }
                            }

                            r["isAccept"] = true;
                            
                            r["userAccept"] = LoginHelper.user.id;

                            _listActionClass.Add(new ActionClass("Duyệt tất cả " + r["soYeuCau"].ToString()
                                                            , r["nguoiYeuCau"].ToString()
                                                            , ""
                                                            , "Duyệt tất cả yêu cầu tuyển dụng ngày duyệt: " + DateTime.Now.Date
                                                            , "tbYeuCauTuyenDung_v1"));
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
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);

                    if (r != null)
                    {
                        if (r["userAccept"] != DBNull.Value)
                        {
                            if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                            {
                                continue;
                            }
                        }

                        r["isAccept"] = true;

                        r["userAccept"] = LoginHelper.user.id;

                        _listActionClass.Add(new ActionClass("Duyệt " + r["soYeuCau"].ToString()
                                                            , r["nguoiYeuCau"].ToString()
                                                            , ""
                                                            , "Duyệt yêu cầu tuyển dụng ngày duyệt: " + DateTime.Now.Date
                                                            , "tbYeuCauTuyenDung_v1"));
                    }
                }
            }
        }

        private void toolStripNotAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các yêu cầu tuyển dụng đang chọn?", "Không duyệt yêu cầu tuyển dụng", MessageBoxButtons.OKCancel);
            
            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);

                    if (r != null)
                    {
                        if (r["userAccept"] != DBNull.Value)
                        {
                            if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                            {
                                continue;
                            }
                        }

                        r["isAccept"] = false;

                        r["userAccept"] = LoginHelper.user.id;

                        _listActionClass.Add(new ActionClass("Không duyệt " + r["soYeuCau"].ToString()
                                                            , r["nguoiYeuCau"].ToString()
                                                            , ""
                                                            , "Không duyệt yêu cầu tuyển dụng ngày duyệt: " + DateTime.Now.Date
                                                            , "tbYeuCauTuyenDung_v1"));
                    }
                }
            }
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            if (_dt.GetChanges() == null || (_dt.GetChanges() != null && _dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }

            var count = _dt.GetChanges().Rows.Count;

            try
            {
                Provider.UpdateData(_dt, "tbYeuCauTuyenDung_v1");

                LogAction.LogAction.PushLog("Sửa dữ liệu"
                                            , ""
                                            , ""
                                            , string.Format("Cập nhật kế hoạch tuyển dụng") + LoginHelper.user.id
                                            , "tbYeuCauTuyenDung_v1");

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));
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
                    
                    try
                    {
                        foreach (var item in drs)
                        {
                            var a = _db.tbYeuCauTuyenDung_v1s.Where(i => i.id.ToString() == item["id"].ToString()).FirstOrDefault();

                            if (a == null)
                            {
                                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                                return;
                            }

                            if (item["isAccept"] != DBNull.Value)
                            {
                                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                                return;
                            }

                            LogAction.LogAction.PushLog("Xóa dữ liệu " + item["soYeuCau"].ToString()
                                                    , item["nguoiYeuCau"].ToString()
                                                    , ""
                                                    , string.Format("Xóa kế hoạch tuyển dụng ") + LoginHelper.user.id
                                                    , "tbYeuCauTuyenDung_v1");

                            _db.tbYeuCauTuyenDung_v1s.DeleteOnSubmit(a);

                            _db.SubmitChanges();
                        }

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void grv_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column == colXemFile && grv.GetFocusedDataRow() != null)
            {
                FileStorageHelper _fh = new FileStorageHelper();

                var _a = grv.GetFocusedRowCellValue(coldataFile);

                var _duoiFile = grv.GetFocusedRowCellValue(colduoiFile).ToString();

                if (_a != null && _a.ToString() != "")
                {
                    Binary dataFile = new Binary(_a as byte[]);

                    _fh.DownLoadAndShowFILE(_a as byte[], _duoiFile);
                }
                else
                {
                    GUIHelper.Notifications("Không tìm thấy file.", "Xem file", GUIHelper.NotifiType.error);
                }
            }
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            _CRow = grv.GetFocusedDataRow();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));

            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }
            else
            {
                foreach (var item in drs)
                {
                    var a = Provider.ExecuteDataTableReader("p_export_tbYeuCauTuyenDung_byID_v1"
                                                            , new System.Data.SqlClient.SqlParameter("idYCTD", item["id"].ToString()));

                    var rp = new rep_phieu_YCTD();

                    rp.DataBindings(a);

                    ReportViewer rv = new ReportViewer();

                    rv.ViewReport(rp);
                }
            }
            
        }

        private void toolStripGoDuyet_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ duyệt đăng ký đang chọn?"
                                    , "Gỡ duyệt đăng ký"
                                    , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
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

                        _listActionClass.Add(new ActionClass("Gỡ duyệt"
                                                            , r["nguoiYeuCau"].ToString()
                                                            , ""
                                                            , "Gỡ duyệt yêu cầu tuyển dụng ngày gỡ " + DateTime.Now.Date
                                                            , "tbYeuCauTuyenDung_v1"));
                    }
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

        private void frmYeuCauTuyenDung_v1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmYeuCauTuyenDung_v1_Load_1(null, null);
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