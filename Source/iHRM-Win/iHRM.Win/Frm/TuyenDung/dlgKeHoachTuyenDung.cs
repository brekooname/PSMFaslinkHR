using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using iHRM.Win.DungChung;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class dlgKeHoachTuyenDung : dlgBase
    {
        dcDatabaseDataContext db;
        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
        public int CustomFormAction = -1;
        public int _idDotTD = 0;
        public dlgKeHoachTuyenDung()
        {
            InitializeComponent();
            dlgData.IdColumnName = "id";
            dlgData.CaptionColumnName = "tenDotTD";
            dlgData.FormCaption = "Thông tin kế hoạch tuyển dụng";
        }



        private void dlgTuyenDung_Load(object sender, EventArgs e)
        {
            TranslateForm();
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            loadPredata();
            AddBinddingControl();
        }
        protected override void FormGetData()
        {
            base.FormGetData();
            if (cboPhongBan.SelectedValue != null)
            {
                this.MyValue["DonVi"] = cboPhongBan.SelectedValue;
            }
            this.MyValue["Ngay"] = cboNam.EditValue;
            //this.MyValue["SLT1"] = int.Parse(txtThang1.Text.Trim().Replace("",""));
            //this.MyValue["SLT2"] = int.Parse(txtThang2.Text.Trim().Replace("", ""));
            //this.MyValue["SLT3"] = int.Parse(txtThang3.Text.Trim().Replace("", ""));
            //this.MyValue["SLT4"] = int.Parse(txtThang4.Text.Trim().Replace("", ""));
            //this.MyValue["SLT5"] = int.Parse(txtThang5.Text.Trim().Replace("", ""));
            //this.MyValue["SLT6"] = int.Parse(txtThang6.Text.Trim().Replace("", ""));

            //this.MyValue["SLT7"] = int.Parse(txtThang7.Text.Trim().Replace("", ""));
            //this.MyValue["SLT8"] = int.Parse(txtThang8.Text.Trim().Replace("", ""));
            //this.MyValue["SLT9"] = int.Parse(txtThang9.Text.Trim().Replace("", ""));
            //this.MyValue["SLT10"] = int.Parse(txtThang10.Text.Trim().Replace("", ""));
            //this.MyValue["SLT11"] = int.Parse(txtThang11.Text.Trim().Replace("", ""));
            //this.MyValue["SLT12"] = int.Parse(txtThang12.Text.Trim().Replace("", ""));
        }
        protected override void FormSetData()
        {
            base.FormSetData();

            if (this.MyValue == null) return;

            else
            {

                if (this.MyValue["DonVi"] != DBNull.Value)
                {
                    cboPhongBan.SelectedValue = this.MyValue["DonVi"].ToString();
                }
                else
                    cboPhongBan.SelectedValue = null;
            }

            cboNam.EditValue = this.MyValue["Ngay"].ToString();
        }
        private void AddBinddingControl()
        {
            //dlgData.CB.Add(new ControlBinding("soChungTu", txtSoChungTu, ControlBinding_DataType.String));
            //dlgData.CB.Add(new ControlBinding("id", txtSoChungTu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("soChungTu", txtSoChungTu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("Ngay", cboNam, ControlBinding_DataType.String));
            //dlgData.CB.Add(new ControlBinding("DonVi", cboPhongBan, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("ViTri", cboDonViYeuCau, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("SLT1", txtThang1, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT2", txtThang2, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT3", txtThang3, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT4", txtThang4, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT5", txtThang5, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT6", txtThang6, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT7", txtThang7, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT8", txtThang8, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT9", txtThang9, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT10", txtThang10, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT11", txtThang11, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SLT12", txtThang12, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("GhiChu", memoGhiChu, ControlBinding_DataType.String));
        }
        private void loadPredata()
        {
            cboNam.Properties.Items.AddRange(Ham.getYear(DateTime.Now.Year));
            cboNam.SelectedText = DateTime.Now.Year.ToString();
            cboDonViYeuCau.Properties.DataSource = CacheDataTable.GetCacheDataTable("tblRef_Position");
            //lookupTrangThai.Properties.DataSource = Enums.elTrangThaiTD;
        }

        private void dateNgayBD_EditValueChanged(object sender, EventArgs e)
        {
            //var a = db.tbDotTuyenDungs.Where(p => p.BeginDate.Year == dateNamThucHien.DateTime.Year && p.BeginDate.Month == dateNamThucHien.DateTime.Month).Count();
            //txtSoChungTu.Text = string.Format("NS/TD/A.01/{0}/{1:00}/{2:00000}", dateNamThucHien.DateTime.Year, dateNamThucHien.DateTime.Month,a + 1);
        }

        private void groupControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void dlgKeHoachTuyenDung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgTuyenDung_Load(null, null);
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
