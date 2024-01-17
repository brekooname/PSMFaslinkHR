using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class dlgDinhNghiaThamSo : dlgCustomBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
        public List<tbLuong_DinhNghiaThamSo> LstThamSo
        {
            set
            {
                frmCongThucTinh.lstPara.Clear();
                if (value != null)
                {
                    frmCongThucTinh.lstPara.AddRange(value.Select(i => new frmCongThucTinh.lstItem()
                    {
                        Name = i.ma,
                        Description = i.ten,
                        nhom = i.nhom
                    }));
                }
                dlgCalcEditor.RefeshLstPara();
            }

        
        }

        private tbLuong_DinhNghiaThamSo myValue;
        public tbLuong_DinhNghiaThamSo MyValue
        {
            get { return myValue; }
            set
            {
                myValue = value;
                txtMa.Text = myValue.ma;
                txtIdx.Text = myValue.tsIdx;
                txtTen.Text = myValue.ten;
                txtNhom.Text = myValue.nhom;
                txtKieuDL.SelectedIndex = (myValue.kieuDuLieu ?? 0) - 1;
                txtKieuNhap.SelectedIndex = (myValue.kieuNhap ?? 0) - 1;
                txtKieuChuyenDL.SelectedIndex = (myValue.kieuMapping ?? 0) - 1;
                txtGiaTriMD.Text = string.Format("{0}", myValue.giatri_macdinh);
                txtLvTinh.EditValue = myValue.lvTinhToan;
                chkHienTrenBC.Checked = myValue.hienTrenBangLuong ?? false;
                chkHienTrenPL.Checked = myValue.hienTrenPhieuLuong ?? false;
                checkLayThangTruoc.Checked = myValue.macdinh_theothangtruoc ?? false;
                txtStt.EditValue = myValue.stt;
            }
        }

        public string AttackMode { get; set; }
        frmCongThucTinh dlgCalcEditor = new frmCongThucTinh();

        public dlgDinhNghiaThamSo()
        {
            InitializeComponent();
        }
        private void dlgDinhNghiaThamSo_Load(object sender, EventArgs e)
        {
            txtKieuDL.ReadOnly = AttackMode != "add";
            this.Form_Title = SelectTranslate("dlgDinhNghiaThamSo_Title", LoginHelper.langTrans);
            this.Form_Description = SelectTranslate("dlgDinhNghiaThamSo_Des", LoginHelper.langTrans);
            TranslateForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool ok = true;
                if (string.IsNullOrWhiteSpace(txtMa.Text))
                {
                    errorProvider1.SetError(txtMa, "Bạn chưa nhập mã...");
                    ok = false;
                }
                if (string.IsNullOrWhiteSpace(txtTen.Text))
                { 
                    errorProvider1.SetError(txtTen, "Bạn chưa nhập tên...");
                    ok = false;
                }
                if (string.IsNullOrWhiteSpace(txtKieuDL.Text))
                {
                    errorProvider1.SetError(txtKieuDL, "Bạn chưa chọn kiểu dữ liệu...");
                    ok = false;
                }

                if (!ok)
                    return;

                myValue.ma = txtMa.Text;
                myValue.tsIdx = txtIdx.Text;
                myValue.ten = txtTen.Text;
                myValue.nhom = txtNhom.Text;
                myValue.kieuDuLieu = txtKieuDL.SelectedIndex + 1;
                myValue.kieuNhap = txtKieuNhap.SelectedIndex + 1;
                myValue.kieuMapping = txtKieuChuyenDL.SelectedIndex + 1;
                if (!string.IsNullOrWhiteSpace(txtGiaTriMD.Text))
                    myValue.giatri_macdinh = Convert.ToDouble(txtGiaTriMD.EditValue);
                if (!string.IsNullOrWhiteSpace(txtLvTinh.Text))
                    myValue.lvTinhToan = Convert.ToInt32(txtLvTinh.EditValue);
                myValue.hienTrenBangLuong = chkHienTrenBC.Checked;
                myValue.hienTrenPhieuLuong = chkHienTrenPL.Checked;
                myValue.macdinh_theothangtruoc = checkLayThangTruoc.Checked;
                myValue.stt = (int)txtStt.Value;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
            
        }

        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void txtKieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCauHinh.Visible = (txtKieuNhap.SelectedIndex > 0);
            switch (txtKieuNhap.SelectedIndex)
            {
                case 0:
                    myValue.moduleDef_id = null;
                    //myValue.congthuc_id = null;
                    break;
                case 1:
                    btnCauHinh.Text = " Cấu hình module";
                    break;
                case 2:
                    btnCauHinh.Text = " Cấu hình công thức";
                    break;
            }
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            if (AttackMode == "add")
            {
                GUIHelper.MessageBox("Cần lưu trước đã");
                return;
            }

            switch (txtKieuNhap.SelectedIndex)
            {
                case 1: // " Cấu hình module";
                    var frm2 = new frmDinhNghiaThamSo_ModuleSelect();
                    frm2.MyId = myValue.moduleDef_id;
                    if (frm2.ShowDialog() == DialogResult.OK)
                        myValue.moduleDef_id = frm2.MyId;
                    break;
                case 2: // " Cấu hình công thức";
                    if (myValue.congthuc_id == null)
                        myValue.congthuc_id = frmCongThucTinh.newCT();

                    dlgCalcEditor.MyId = myValue.congthuc_id;
                    dlgCalcEditor.ShowDialog();
                    break;
            }
        }

        private void txtKieuChuyenDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCauHinh2.Visible = txtKieuChuyenDL.SelectedIndex == 1;
        }

        private void btnCauHinh2_Click(object sender, EventArgs e)
        {
            if (AttackMode == "add")
            {
                GUIHelper.MessageBox("Cần lưu trước đã");
                return;
            }

            var frm = new frmDinhNghiaThamSo_TruthDef();
            frm.MyId = myValue.id;
            frm.ShowDialog();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaTriMD.Enabled = !checkLayThangTruoc.Checked;
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

        private void dlgDinhNghiaThamSo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgDinhNghiaThamSo_Load(null, null);
            }
        }
    }
}
