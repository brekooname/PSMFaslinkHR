using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class dlgDinhNghiaBieuMau : dlgCustomBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
        List<tbLuong_DinhNghiaThamSo> LstDataTS;
        
        private tbLuong_XuatBangLuong myValue;
        public tbLuong_XuatBangLuong MyValue
        {
            get { return myValue; }
            set
            {
                myValue = value;
                txtTen.Text = myValue.ten;
                txtFilePath.Text = myValue.duongdan;
                chkStatus.Checked = myValue.status == 1;
                lblHTML.Text = myValue.loai.ToUpper();

                if (myValue.loai == "html")
                {
                    xtraTabPage2.PageEnabled = true;

                    txtNhomNV.EditValue = null;
                    LstDataTS = db.tbLuong_DinhNghiaThamSos.ToList();
                    GetThamSoChecked();
                }
                else
                {
                    xtraTabPage2.PageEnabled = false;
                }
            }
        }

        public dlgDinhNghiaBieuMau()
        {
            InitializeComponent();
            //txtFilePath.LostFocus += (s, e) => { if (!txtFilePath.Text.Trim().ToLower().EndsWith("." + myValue.loai)) txtFilePath.Text += "." + myValue.loai; };
        }
        private void dlgDinhNghiaThamSo_Load(object sender, EventArgs e)
        {
            txtNhomNV.Properties.DataSource = CacheDataTable.GetCacheDataTable("tbDM_nhomNV");
            this.Form_Title = SelectTranslate("dlgDinhNghiaThamSo_Title", LoginHelper.langTrans) ;
            this.Form_Description = SelectTranslate("dlgDinhNghiaThamSo_Des", LoginHelper.langTrans);
            TranslateForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool ok = true;
                if (string.IsNullOrWhiteSpace(txtTen.Text))
                { 
                    errorProvider1.SetError(txtTen, "Bạn chưa nhập ten...");
                    ok = false;
                }
                if (string.IsNullOrWhiteSpace(txtFilePath.Text))
                { 
                    errorProvider1.SetError(txtFilePath, "Bạn chưa nhập đường dẫn tới file mẫu báo cáo...");
                    ok = false;
                }
                if (!File.Exists(Path.Combine(win_globall.apppath, "ExcelTemplate\\Luong", txtFilePath.Text)))
                {
                    errorProvider1.SetError(txtFilePath, "File mẫu báo cáo không tồn tại...");
                    ok = false;
                }

                if (!ok)
                    return;
                
                myValue.ten = txtTen.Text;
                myValue.duongdan = txtFilePath.Text;
                myValue.status = chkStatus.Checked ? 1 : 0;

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
        
        private void txtNhom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Biểu mẫu|*." + (myValue.loai == "excel" ? "xls;*.xlsx" : "html");
            od.InitialDirectory = Path.Combine(win_globall.apppath, "ExcelTemplate\\Luong");
            if (od.ShowDialog() == DialogResult.OK)
                txtFilePath.Text = Path.GetFileName(od.FileName);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                GUIHelper.MessageBox("Bạn chưa nhập đường dẫn tới file mẫu báo cáo...");
                return;
            }

            try
            {
                var groups = LstDataTS.Where(i => i.hienTrenBangLuong ?? false).Select(i => i.nhom).Distinct();
                string data = string.Join("", groups.Select(i => string.Format("<h4 class='tt'>{0}</h4><table class='bt sect5' cellpadding='0' cellspacing='0'>{1}{2}</table>",
                    i,
                    string.Join("", LstDataTS.Where(j => j.hienTrenBangLuong == true && j.nhom == i).Select(j => string.Format("<tr><td class='tit1'>{0}</td><td class='m haicham'>{1}</td></tr>",
                        j.ten,
                        "{{ct_" + j.tsIdx + "_value}}"
                    ))),
                    chkShowTotalGroup.Checked ? ("<tr><td class='tit1'>Tổng</td><td class='m haicham'><span style='font-weight:bold; color:red;'>{{ct_sum_group_" + i + "}}</span></td></tr>") : ""
                )));
                string temp = File.ReadAllText(Path.Combine(win_globall.apppath, "ExcelTemplate\\Luong\\PhieuLuong_base.html"));
                var fPath = Path.Combine(win_globall.apppath, "ExcelTemplate\\Luong", txtFilePath.Text);
                File.WriteAllText(fPath, temp.Replace("{{#data}}", data), Encoding.Unicode);

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

        private void txtNhomNV_EditValueChanged(object sender, EventArgs e)
        {
            LstDataTS = db.tbNhanVien_ThamSoLuongs.Where(i => i.nhomnv_id == txtNhomNV.EditValue as int?).Select(i => i.tbLuong_DinhNghiaThamSo).ToList();
            GetThamSoChecked();
        }

        private void GetThamSoChecked()
        {
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                foreach (var it in LstDataTS)
                    it.hienTrenBangLuong = false;
                chkShowTotalGroup.Checked = false;
            }
            else
            {
                string temp = File.ReadAllText(Path.Combine(win_globall.apppath, "ExcelTemplate\\Luong", txtFilePath.Text));
                foreach (var it in LstDataTS)
                    it.hienTrenBangLuong = temp.IndexOf("{{ct_" + it.tsIdx + "_value}}") > 0;
                chkShowTotalGroup.Checked = temp.IndexOf("{{ct_sum_group_") > 0;
            }
            grd.DataSource = LstDataTS;
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
        private void dlgDinhNghiaBieuMau_KeyDown(object sender, KeyEventArgs e)
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
