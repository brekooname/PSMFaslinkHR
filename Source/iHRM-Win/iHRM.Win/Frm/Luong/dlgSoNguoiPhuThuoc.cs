using System.Collections.Generic;
using System.Windows.Forms;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Reflection;
using iHRM.Win.Frm.LogAction;

namespace iHRM.Win.Frm.Luong
{
    public partial class dlgSoNguoiPhuThuoc : dlgCustomBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        public int _flag = 0;

        public DataRow _CRow;

        public dlgSoNguoiPhuThuoc()
        {
            InitializeComponent();
        }
        private void dlgSoNguoiPhuThuoc_Load(object sender, EventArgs e)
        {
            TranslateForm();

            lkQuanHe.Properties.DataSource = db.tblRef_Relations;

            this.Form_Title = SelectTranslate("dlgSoNguoiPhuThuoc", LoginHelper.langTrans);

            this.Form_Description = SelectTranslate("dlgSoNguoiPhuThuoc_des", LoginHelper.langTrans);

            InitLookUp();

            if(_flag<= 0)
            {
                lkChonNV.Enabled = true;

                dateNgayHL.EditValue = DateTime.Today;
            }
            else
            {
                InitUpdate();

                lkChonNV.Enabled = false;
            }
        }

        public void InitLookUp()
        {
            var dt = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));

            // Thông Liêu add phan quyen 2019-10-22
            lkChonNV.Properties.DataSource = dt;
        }

        public void InitUpdate()
        {
            var _EmployeeID = DbHelper.DrGet(_CRow, "EmployeeID") != null ? DbHelper.DrGet(_CRow, "EmployeeID") : null;

            var _DateHieuLuc = DbHelper.DrGet(_CRow, "DateHieuLuc") != null ? DbHelper.DrGet(_CRow, "DateHieuLuc") : null;

            var _PhuThuocName = DbHelper.DrGet(_CRow, "PhuThuocName") != null ? DbHelper.DrGet(_CRow, "PhuThuocName") : "";

            var _PhuThuocNgaySinh = DbHelper.DrGet(_CRow, "PhuThuocNgaySinh") != null ? DbHelper.DrGet(_CRow, "PhuThuocNgaySinh") : null;

            var _MSTNguoiThuThuoc = DbHelper.DrGet(_CRow, "MSTNguoiThuThuoc") != null ? DbHelper.DrGet(_CRow, "MSTNguoiThuThuoc") : "";

            var _CMNDNguoiThuThuoc = DbHelper.DrGet(_CRow, "CMNDNguoiThuThuoc") != null ? DbHelper.DrGet(_CRow, "CMNDNguoiThuThuoc") : "";

            var _QuanHeNguoiNopThue = DbHelper.DrGet(_CRow, "QuanHeNguoiNopThue") != null ? DbHelper.DrGet(_CRow, "QuanHeNguoiNopThue") : null;

            var _DateHetHan = DbHelper.DrGet(_CRow, "DateHetHan") != null ? DbHelper.DrGet(_CRow, "DateHetHan") : null;

            var _Ghichu = DbHelper.DrGet(_CRow, "Ghichu") != null ? DbHelper.DrGet(_CRow, "Ghichu") : "";

            lkChonNV.EditValue = _EmployeeID;

            txtNPT.Text = _PhuThuocName as String;

            txtMST.Text = _MSTNguoiThuThuoc as String;

            txtCMND.Text = _CMNDNguoiThuThuoc as String;

            lkQuanHe.EditValue = _QuanHeNguoiNopThue;

            txtGhiChu.Text = _Ghichu as String;

            if (_DateHieuLuc != null) dateNgayHL.EditValue = DateTime.Parse(_DateHieuLuc.ToString());

            if (_PhuThuocNgaySinh != null) dateNgaySinh.EditValue = DateTime.Parse(_PhuThuocNgaySinh.ToString());

            if (_DateHetHan != null) dateNgayHetHan.EditValue = DateTime.Parse(_DateHetHan.ToString());
        }

        public bool CheckNull(DevExpress.XtraEditors.BaseEdit _control)
        {
            if (_control.EditValue == null || String.IsNullOrEmpty(_control.ToString())) return true;

            return false;
        }

        private bool Check()
        {
            if (CheckNull(lkChonNV))
            {
                GUIHelper.Notifications("Vui lòng chọn nhân viên!", "Lỗi dữ liệu", GUIHelper.NotifiType.error);

                return true;
            }

            if (txtNPT.Text.ToString().Trim() == "")
            {
                GUIHelper.Notifications("Vui lòng nhập tên người phụ thuộc!", "Lỗi dữ liệu", GUIHelper.NotifiType.error);

                return true;
            }

            if (CheckNull(dateNgayHL))
            {
                GUIHelper.Notifications("Vui lòng chọn ngày hiệu lực!", "Lỗi dữ liệu", GUIHelper.NotifiType.error);

                return true;
            }

            if (CheckNull(dateNgaySinh))
            {
                GUIHelper.Notifications("Vui lòng chọn ngày sinh của người phụ thuộc!", "Lỗi dữ liệu", GUIHelper.NotifiType.error);

                return true;
            }

            //if (txtMST.Text.ToString().Trim() == "")
            //{
            //    GUIHelper.Notifications("Vui lòng nhập mã số thuế người phụ thuộc!", "Lỗi dữ liệu", GUIHelper.NotifiType.error);

            //    return true;
            //}

            if (txtCMND.Text.ToString().Trim() == "")
            {
                GUIHelper.Notifications("Vui lòng nhập CMND người phụ thuộc!", "Lỗi dữ liệu", GUIHelper.NotifiType.error);

                return true;
            }

            if (CheckNull(lkQuanHe))
            {
                GUIHelper.Notifications("Vui lòng chọn mối quan hệ!", "Lỗi dữ liệu", GUIHelper.NotifiType.error);

                return true;
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check()) return;

            long _userInsert = LoginHelper.user.id;

            DateTime _dateInsert = DateTime.Now;

            tblEmpPIT_Family _tbl = new tblEmpPIT_Family();

            if (DbHelper.DrGet(_CRow, "id") != null && _flag == 1)
            {
                _tbl = db.tblEmpPIT_Families.Where(p => p.id == DbHelper.DrGet(_CRow, "id") as Guid?).SingleOrDefault();
            }

            _tbl.EmployeeID = lkChonNV.EditValue as String;

            _tbl.DateHieuLuc = dateNgayHL.EditValue as DateTime?;

            _tbl.PhuThuocName = txtNPT.Text;

            _tbl.PhuThuocNgaySinh = dateNgaySinh.EditValue as DateTime?;

            _tbl.MSTNguoiThuThuoc = txtMST.Text;

            _tbl.CMNDNguoiThuThuoc = txtCMND.Text;

            _tbl.QuanHeNguoiNopThue = lkQuanHe.EditValue as String;

            _tbl.DateHetHan = dateNgayHetHan.EditValue as DateTime?;

            _tbl.Ghichu = txtGhiChu.Text;

            if(_flag <= 0)
            {
                _tbl.UserInsert = LoginHelper.user.id;

                _tbl.NgayInsert = DateTime.Now;

                _tbl.id = Guid.NewGuid();

                try
                {
                    LogAction.LogAction.PushLog("Cập nhật người phụ thuộc"
                                        , lkChonNV.EditValue.ToString()
                                        , ""
                                        , String.Format(@"Thêm người phụ thuộc , Tên NPT: {0} 
                                                            , Ngày sinh: {1}
                                                            , CMND: {2}
                                                            , MST: {3}
                                                            , Quan hệ: {4}
                                                            , Ngày thêm: {5}
                                                            , Ngày hết hạn: {6}"
                                                            , txtNPT.Text
                                                            , dateNgaySinh.EditValue
                                                            , txtCMND.Text
                                                            , txtMST.Text
                                                            , lkQuanHe.Text
                                                            , DateTime.Now
                                                            , dateNgayHetHan.EditValue
                                        )
                                        , "tblEmpPIT_Family");

                    db.tblEmpPIT_Families.InsertOnSubmit(_tbl);

                    db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
            else
            {
                try
                {
                    LogAction.LogAction.PushLog("Cập nhật người phụ thuộc"
                                                , lkChonNV.EditValue.ToString()
                                                , ""
                                                , String.Format(@"Cập nhật người phụ thuộc , Tên NPT: {0} 
                                                                    , Ngày sinh: {1}
                                                                    , CMND: {2}
                                                                    , MST: {3}
                                                                    , Quan hệ: {4}
                                                                    , Ngày cập nhật: {5}
                                                                    , Ngày hết hạn: {6}"
                                                                    , txtNPT.Text
                                                                    , dateNgaySinh.EditValue
                                                                    , txtCMND.Text
                                                                    , txtMST.Text
                                                                    , lkQuanHe.Text
                                                                    , DateTime.Now
                                                                    , dateNgayHetHan.EditValue
                                        )
                                        , "tblEmpPIT_Family");

                    db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }

            

            btnSave.Enabled = true;
        }

        private void lkChonNV_EditValueChanged(object sender, EventArgs e)
        {
            tblEmployee _emp = new tblEmployee();

            if (lkChonNV.EditValue != null || lkChonNV.EditValue.ToString() == "")
            {
                _emp = db.tblEmployees.Where(x => x.EmployeeID == lkChonNV.EditValue.ToString()).SingleOrDefault();
            }

            if (_emp != null)
            {
                txtPhongBan.Text = _emp.DepName_Final as String;
            }
        }

        private void dlgSoNguoiPhuThuoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;

            this.Hide();
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
            //string formText = SelectTranslate(this.Name, langTrans);
            //if (formText != "")
            //{
            //    this.Text = formText;
            //}
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

        private void dlgSoNguoiPhuThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgSoNguoiPhuThuoc_Load(null, null);
            }
        }



    }
}
