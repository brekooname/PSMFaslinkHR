using DevExpress.XtraEditors;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong
{
    public partial class frmSoNguoiPhuThuoc_v1 : frmBase
    {
        Core.Business.Logic.Luong.TinhLuong logic = new Core.Business.Logic.Luong.TinhLuong();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        DataTable dt = new DataTable();

        dlgSoNguoiPhuThuoc _dlgSoNguoiPhuThuoc;

        DataRow _CRow;

        public frmSoNguoiPhuThuoc_v1()
        {
            InitializeComponent();
        }

        private void frmSoNguoiPhuThuoc_v1_Load(object sender, EventArgs e)
        {
            #region phân quyền
            toolstripSDelete.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);

            toolStripExcel.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);

            toolStripThem.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);

            toolStripCapNhat.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Edit);

            toolstripSave.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Save);
            #endregion

            TranslateForm();
            grv.OptionsBehavior.Editable = false;

            grv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            LoadGrvLayout(grv);

            //thông tin quan hệ 
            repositoryItemSearchLookUpEditQH.DataSource = db.tblRef_Relations;

            repositoryItemSearchLookUpEditQH.DisplayMember = "RelationName";

            repositoryItemSearchLookUpEditQH.ValueMember = "RelationID";

            btnFind_Click(null, null);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            dw_it.Caption = "Đang tải dữ liệu đăng ký số người phụ thuộc";

            dw_it.OnDoing = (s, ev) =>
            {
                dt = logic.getSoNguoiPhuThuoc(ucChonDoiTuong_DS1.GetValue(), chonKyLuong1.TuNgay, chonKyLuong1.DenNgay);

                dw_it.bw.ReportProgress(1, dt);
            };

            dw_it.OnProcessing = (ps, dt) =>
            {
                if (dt.ProgressPercentage == 1)
                {
                    grd.DataSource = dt.UserState;
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
            SaveGrvLayout(grv);
        }
        private void toolStripThem_Click(object sender, EventArgs e)
        {
            _dlgSoNguoiPhuThuoc = new dlgSoNguoiPhuThuoc();

            _dlgSoNguoiPhuThuoc._flag = 0;

            _dlgSoNguoiPhuThuoc.ShowDialog();
        }

        private void toolStripCapNhat_Click(object sender, EventArgs e)
        {
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
                            if (_dlgSoNguoiPhuThuoc != null)
                            {
                                _CRow = grv.GetFocusedDataRow();

                                _dlgSoNguoiPhuThuoc._flag = 1;

                                _dlgSoNguoiPhuThuoc._CRow = _CRow;

                                _dlgSoNguoiPhuThuoc.ShowDialog();
                            }
                            else
                            {
                                _dlgSoNguoiPhuThuoc = new dlgSoNguoiPhuThuoc();

                                _CRow = grv.GetFocusedDataRow();

                                _dlgSoNguoiPhuThuoc._flag = 1;

                                _dlgSoNguoiPhuThuoc._CRow = _CRow;

                                _dlgSoNguoiPhuThuoc.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void toolstripSave_Click(object sender, EventArgs e)
        {
            grv.OptionsBehavior.Editable = false;

            grv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            var db = new dcDatabaseDataContext(Provider.ConnectionString);

            //MessageBox.Show(coHuongLuong.ToString());

            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }

            var count = dt.GetChanges().Rows.Count;

            try
            {
                foreach (DataRow dr in dt.GetChanges().Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                    {
                        LogAction.LogAction.PushLog("Xóa người phụ thuộc"
                                            , (string)dr["EmployeeID", DataRowVersion.Original]
                                            , ""
                                            , String.Format(@"Xóa người phụ thuộc , Tên NPT: {0} 
                                                            , Ngày sinh: {1}
                                                            , CMND: {2}
                                                            , MST: {3}
                                                            , Quan hệ: {4}
                                                            , Ngày xóa: {5}"
                                                                , (string)dr["PhuThuocName", DataRowVersion.Original]
                                                                , ""
                                                                , (string)dr["CMNDNguoiThuThuoc", DataRowVersion.Original]
                                                                , (string)dr["MSTNguoiThuThuoc", DataRowVersion.Original]
                                                                , (string)dr["QuanHeNguoiNopThue", DataRowVersion.Original]
                                                                , DateTime.Now
                                            )
                                            , "tblEmpPIT_Family");
                    }
                }
                Provider.UpdateData(dt, "tblEmpPIT_Family");

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
                
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
            

        }
        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dr = grv.GetDataRow(e.RowHandle);

            if (dr != null)
            {
                dr["UserInsert"] = LoginHelper.user.id;

                dr["NgayInsert"] = DateTime.Now;
            } 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các yêu cầu đang chọn?", "Xóa tất cả các yêu cầu đang chọn", MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);

                    if (r != null)
                    {
                        var isOK = true;

                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            isOK = false;
                        }

                        if (!isOK)
                        {
                            GUIHelper.Notifications("Không thể xóa vì bản ghi này không thuộc phòng ban của bạn.", "Xóa tất cả các yêu cầu đang chọn", GUIHelper.NotifiType.error);
                        }
                        else
                        {
                            grv.DeleteRow(rowhandler);
                        }
                    }
                }
            }
        }

        private void repositoryItemSearchLookUpEditNhanVien_EditValueChanged_1(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;

            this.grv.SetFocusedRowCellValue(colNgaySinh, searchEdit.Properties.View.GetFocusedRowCellValue("Birthday"));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            grv.OptionsBehavior.Editable = true;

            grv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

            GUIHelper.Notifications("Bạn đã có thể sửa trực tiếp trên lưới danh sách.", "Sửa dữ liệu", GUIHelper.NotifiType.info);
        }

        private void repositoryItemSearchLookUpEditMaNV_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;

            this.grv.SetFocusedRowCellValue(colMaNV, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeID"));

            this.grv.SetFocusedRowCellValue(colChucVu, searchEdit.Properties.View.GetFocusedRowCellValue("EmpTypeName"));

            this.grv.SetFocusedRowCellValue(colPhongBan, searchEdit.Properties.View.GetFocusedRowCellValue("DepName_Final"));
        }

        private void grv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = grv.GetDataRow(e.RowHandle);

            if (r != null && r.RowState != DataRowState.Unchanged)
            {
                if (r["EmployeeID"] == DBNull.Value || r["EmployeeID"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập mã nhân viên.\n");

                    e.Valid = false;

                    grv.FocusedColumn = grv.Columns[0];

                    return;
                }
                else
                {
                    if (!AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB))
                    {
                        e.ErrorText = ("Mã nhân viên bạn nhập không nằm trong phòng ban của bạn.\n");

                        e.Valid = false;

                        grv.FocusedColumn = grv.Columns[0];

                        return;

                    }
                }

                if (r["PhuThuocName"] == DBNull.Value || r["PhuThuocName"].ToString() == "")
                {
                    e.ErrorText = ("Chưa nhập người phụ thuộc.\n");

                    e.Valid = false;

                    grv.FocusedColumn = grv.Columns[4];

                    return;
                }

                if (r["DateHieuLuc"] == DBNull.Value || r["DateHieuLuc"].ToString() == "")
                {
                    e.ErrorText = ("Chưa chọn ngày hiệu lực.\n");

                    e.Valid = false;

                    grv.FocusedColumn = grv.Columns[6];

                    return;
                }

                if (r["PhuThuocNgaySinh"] == DBNull.Value || r["PhuThuocNgaySinh"].ToString() == "")
                {
                    e.ErrorText = ("Chưa chọn ngày sinh của ngày phụ thuộc.\n");

                    e.Valid = false;

                    grv.FocusedColumn = grv.Columns[5];

                    return;
                }

                if (r["MSTNguoiThuThuoc"] == DBNull.Value || r["MSTNguoiThuThuoc"].ToString() == "")
                {
                    e.ErrorText = ("Chưa nhập mã số thuế.\n");

                    e.Valid = false;

                    grv.FocusedColumn = grv.Columns[7];

                    return;
                }

                if (r["CMNDNguoiThuThuoc"] == DBNull.Value || r["CMNDNguoiThuThuoc"].ToString() == "")
                {
                    e.ErrorText = ("Chưa nhập số CMND.\n");

                    e.Valid = false;

                    grv.FocusedColumn = grv.Columns[8];

                    return;
                }

                if (r["QuanHeNguoiNopThue"] == DBNull.Value || r["QuanHeNguoiNopThue"].ToString() == "")
                {
                    e.ErrorText = ("Chưa chọn quan hệ với người nộp thuế.\n");

                    e.Valid = false;

                    grv.FocusedColumn = grv.Columns[9];

                    return;
                }
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
        private void frmSoNguoiPhuThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmSoNguoiPhuThuoc_v1_Load(null, null);
            }
        }

    }
}
