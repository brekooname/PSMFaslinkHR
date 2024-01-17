using System.Windows.Forms;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Reflection;

namespace iHRM.Win.Frm.Employee
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class dlgGiayPhepLaoDong_v1 : dlgCustomBase
    {
        //Khởi tạo//
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        public int _flag = 0;

        public DataRow _CRow;
        //---//
        public dlgGiayPhepLaoDong_v1()
        {
            InitializeComponent();
        }

        private void dlgGiayPhepLaoDong_v1_Load(object sender, EventArgs e)
        {
            TranslateForm();

            dateNgayBD.DateTime = dateNgayKy.DateTime = DateTime.Now.Date;

            InitLookUp();

            if (_flag == 0)
            {
                btnSave.Visible = true;

                btnUpdate.Visible = false;

                lkNV.Enabled = true;
            }
            else
            {
                InitUpdate();

                btnSave.Visible = false;

                btnUpdate.Visible = true;

                lkNV.Enabled = false;
            }
        }

        public void InitLookUp()
        {
            var _table_Nv = _db.tblEmployees;

            lkNV.Properties.DataSource = _table_Nv;
        }

        public void InitUpdate()
        {
            var _EmployeeID = DbHelper.DrGet(_CRow, "EmployeeID") != null ? DbHelper.DrGet(_CRow, "EmployeeID") : null;

            var _soGiayPhep = DbHelper.DrGet(_CRow, "soGiayPhep") != null ? DbHelper.DrGet(_CRow, "soGiayPhep") : "";

            var _soHoChieu = DbHelper.DrGet(_CRow, "soHoChieu") != null ? DbHelper.DrGet(_CRow, "soHoChieu") : "";

            var _toChucLamViec = DbHelper.DrGet(_CRow, "toChucLamViec") != null ? DbHelper.DrGet(_CRow, "toChucLamViec") : "";

            var _noiLamViec = DbHelper.DrGet(_CRow, "noiLamViec") != null ? DbHelper.DrGet(_CRow, "noiLamViec") : "";

            var _viTriCongViec = DbHelper.DrGet(_CRow, "viTriCongViec") != null ? DbHelper.DrGet(_CRow, "viTriCongViec") : "";

            var _BeginDate = DbHelper.DrGet(_CRow, "BeginDate") != null ? DbHelper.DrGet(_CRow, "BeginDate") : null;

            var _EndDate = DbHelper.DrGet(_CRow, "EndDate") != null ? DbHelper.DrGet(_CRow, "EndDate") : null;

            var _ngayKy = DbHelper.DrGet(_CRow, "ngayKy") != null ? DbHelper.DrGet(_CRow, "ngayKy") : null;

            var _noiKy = DbHelper.DrGet(_CRow, "soGiayPhep") != null ? DbHelper.DrGet(_CRow, "noiKy") : "";

            var _ngaySinh = DbHelper.DrGet(_CRow, "ngaySinh") != null ? DbHelper.DrGet(_CRow, "ngaySinh") : "";

            lkNV.EditValue = _EmployeeID;

            txtSoGiayPhep.Text = _soGiayPhep as String;

            txtSoHoChieu.Text = _soHoChieu as String;

            txtToChuc.Text = _toChucLamViec as String;

            txtNoiLamViec.Text = _noiLamViec as String;

            txtViTri.Text = _viTriCongViec as String;

            if (_BeginDate != null) dateNgayBD.DateTime = DateTime.Parse(_BeginDate.ToString());

            if (_EndDate != null) dateNgayKT.DateTime = DateTime.Parse(_EndDate.ToString());

            if (_ngayKy != null) dateNgayKy.DateTime = DateTime.Parse(_ngayKy.ToString());

            txtNoiKy.Text = _noiKy as String;

            dateNgaySinh.EditValue = _ngaySinh;
        }

        private bool Check()
        {
            if (lkNV.EditValue == null || String.IsNullOrEmpty(lkNV.EditValue.ToString()))
            {
                GUIHelper.MessageBox("Vui lòng chọn nhân viên!");

                return true;
            }

            if (dateNgayBD.EditValue == null || String.IsNullOrEmpty(dateNgayBD.DateTime.ToString()))
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày bắt đầu!");

                return true;
            }

            if (dateNgayKy.EditValue == null || String.IsNullOrEmpty(dateNgayBD.DateTime.ToString()))
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày ký!");

                return true;
            }

            if (dateNgayKT.EditValue != null)
            {
                if (DateTime.Compare(dateNgayKT.DateTime.Date, dateNgayBD.DateTime.Date) < 0)
                {
                    GUIHelper.MessageBox("Vui lòng chọn ngày kết thúc lớn hơn ngày bắt đầu!");

                    return true;
                }
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _listActionClass.Clear();

            if (Check()) return;

            _db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

            tblGiayPhepLaoDong gp = new tblGiayPhepLaoDong();

            // Thông tin chung:
            gp.hoTen = txtHoTen.Text as String;

            gp.soGiayPhep = txtSoGiayPhep.Text as String;

            gp.EmployeeID = lkNV.EditValue as String;

            gp.soHoChieu = txtSoHoChieu.Text as String;

            gp.toChucLamViec = txtToChuc.Text as String;

            gp.noiLamViec = txtNoiLamViec.Text as String;

            gp.viTriCongViec = txtViTri.Text as String;

            gp.trinhDoChuyenMon = txtTrinhDo.Text as String;

            gp.gioiTinh = txtGioiTinh.Text as String;

            gp.BeginDate = dateNgayBD.DateTime as DateTime?;

            gp.EndDate = dateNgayKT.EditValue != null ? dateNgayKT.DateTime as DateTime? : null;

            gp.ngayKy = dateNgayKy.DateTime as DateTime?;

            gp.noiKy = txtNoiKy.Text as String;

            gp.ngaySinh = dateNgaySinh.EditValue == "" ? null : dateNgaySinh.DateTime as DateTime? ;

            try
            {
                var _check = _db.tblGiayPhepLaoDongs.Where(x => x.EmployeeID == lkNV.EditValue).SingleOrDefault();

                if (_check != null)
                {
                    if (_check.BeginDate != null)

                        if (DateTime.Compare(DateTime.Parse(_check.BeginDate.ToString()), dateNgayBD.DateTime) == 0)
                        {
                            GUIHelper.MessageBox("Giấy phép lao động đã tồn tại.");

                            return;
                        }
                    
                }

                LogAction.LogAction.PushLog("Thêm giấy phép lao động số " + gp.soGiayPhep
                                                    , gp.EmployeeID
                                                    , ""
                                                    , String.Format("Thêm giấy phép lao động số {0} ", gp.soGiayPhep) 
                                                    , "tblGiayPhepLaoDong");

                _db.tblGiayPhepLaoDongs.InsertOnSubmit(gp);

                _db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _listActionClass.Clear();

            if (Check()) return;

            _db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

            int _id = DbHelper.DrGet(_CRow, "id") != null ? int.Parse(DbHelper.DrGet(_CRow, "id").ToString()) : 0;

            tblGiayPhepLaoDong gp = new tblGiayPhepLaoDong();

            gp = _db.tblGiayPhepLaoDongs.Where(x => x.id == _id).SingleOrDefault();

            // Thông tin chung:
            gp.hoTen = txtHoTen.Text as String;

            gp.soGiayPhep = txtSoGiayPhep.Text as String;

            gp.EmployeeID = lkNV.EditValue as String;

            gp.soHoChieu = txtSoHoChieu.Text as String;

            gp.toChucLamViec = txtToChuc.Text as String;

            gp.noiLamViec = txtNoiLamViec.Text as String;

            gp.viTriCongViec = txtViTri.Text as String;

            gp.trinhDoChuyenMon = txtTrinhDo.Text as String;

            gp.gioiTinh = txtGioiTinh.Text as String;

            gp.BeginDate = dateNgayBD.DateTime as DateTime?;

            gp.EndDate = dateNgayKT.EditValue != null ? dateNgayKT.DateTime as DateTime? : null;

            gp.ngayKy = dateNgayKy.DateTime as DateTime?;

            gp.noiKy = txtNoiKy.Text as String;

            gp.ngaySinh = dateNgaySinh.EditValue == "" ? null : dateNgaySinh.DateTime as DateTime?;

            try
            {
                LogAction.LogAction.PushLog("Sửa giấy phép lao động số " + gp.soGiayPhep
                                                    , gp.EmployeeID
                                                    , ""
                                                    , String.Format("Sửa giấy phép lao động số {0} ", gp.soGiayPhep)
                                                    , "tblGiayPhepLaoDong");

                _db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void lkNV_EditValueChanged(object sender, EventArgs e)
        {
            tblEmployee _emp = new tblEmployee();

            if (lkNV.EditValue != null || lkNV.EditValue.ToString() == "")
            {
                _emp = _db.tblEmployees.Where(x => x.EmployeeID == lkNV.EditValue.ToString()).SingleOrDefault();
            }

            if (_emp != null)
            {
                txtGioiTinh.Text = _emp.SexID as String;

                txtHoTen.Text = _emp.EmployeeName as String;

                txtTrinhDo.Text = _emp.EducationType;

                if (_emp.Birthday != null)

                    dateNgaySinh.DateTime = DateTime.Parse(_emp.Birthday.ToString());

                else

                    dateNgaySinh.EditValue = "";
            }
        }

        private void dateNgayKT_EditValueChanged(object sender, EventArgs e)
        {
            if (dateNgayKT.Text == "")
            {
                dateNgayKT.EditValue = null;
            }
        }

        private void dlgGiayPhepLaoDong_v1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgGiayPhepLaoDong_v1_Load(null, null);
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
        private IEnumerable<DevExpress.XtraLayout.LayoutItem> EnumerateLayoutItem()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraLayout.LayoutItem).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraLayout.LayoutItem)field.GetValue(this)
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
            var _LayoutItem = EnumerateLayoutItem();
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
            foreach (DevExpress.XtraLayout.LayoutItem s in _LayoutItem)
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