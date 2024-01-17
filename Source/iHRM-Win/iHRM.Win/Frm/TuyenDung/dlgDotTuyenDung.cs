using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class dlgDotTuyenDung : dlgBase
    {
        dcDatabaseDataContext db;
        /// <summary>
        /// Hành động đang thêm (0) hay sửa (1)
        /// </summary>
        public int CustomFormAction = -1;

        public int _idDotTD = 0;

        public int _flagUpdate = 0;

        public dlgDotTuyenDung()
        {
            InitializeComponent();

            dlgData.IdColumnName = "id";

            dlgData.CaptionColumnName = "tenDotTD";

            dlgData.FormCaption = "Thông tin đợt tuyển dụng";
        }

        private void dlgTuyenDung_Load(object sender, EventArgs e)
        {
            TranslateForm();

            db = new dcDatabaseDataContext(Provider.ConnectionString);

            loadPredata();

            AddBinddingControl();
        }
        private void AddBinddingControl()
        {
            dlgData.CB.Add(new ControlBinding("soChungTu", txtSoChungTu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("tenDotTD", txtTenDotTD, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BeginDate", dateNgayBD, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("EndDate", dateNgayKT, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("soLuongDuKien", txtSoLuongDuKien, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding("chiPhiDuKien", txtChiPhiDuKien, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding("trangThaiThucHien", lookupTrangThai, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ghiChu", memoYeuCauTuyenDung, ControlBinding_DataType.String));
        }
        private void loadPredata()
        {
            lookupTrangThai.Properties.DataSource = Enums.elTrangThaiTD;
        }

        private void dateNgayBD_EditValueChanged(object sender, EventArgs e)
        {
            if(_flagUpdate == 1)
            {
                return;
            }
            else
            {
                var a = db.tbDotTuyenDungs.Where(p => p.BeginDate.Year == dateNgayBD.DateTime.Year && p.BeginDate.Month == dateNgayBD.DateTime.Month).Count();

                txtSoChungTu.Text = string.Format("TD/A.01/{0}/{1:00}/{2:00000}", dateNgayBD.DateTime.Year, dateNgayBD.DateTime.Month, a + 1);

                txtTenDotTD.Text = string.Format("Đợt TD tháng {0} năm {1} lần {2}", dateNgayBD.DateTime.Month, dateNgayBD.DateTime.Year, a + 1);
            }
        }

        private void dlgDotTuyenDung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
