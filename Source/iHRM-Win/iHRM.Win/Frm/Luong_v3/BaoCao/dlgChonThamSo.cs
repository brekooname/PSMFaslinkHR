﻿using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3.BaoCao
{
    public partial class dlgChonThamSo : frmBase
    {
        dcLuongv3DataContext db;
        public List<tbLuong_DinhNghiaThamSo> LstData = new List<tbLuong_DinhNghiaThamSo>();

        dlgDinhNghiaThamSo dlgEditor = new dlgDinhNghiaThamSo();
        private class KieuDuLieu
        {
            public string Ten { get; set; }
            public int kieuDuLieu { get; set; }
        }
        public dlgChonThamSo()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            List<KieuDuLieu> arrKDL = new List<KieuDuLieu>();
            arrKDL.Add(new KieuDuLieu { Ten = "Nhập tay", kieuDuLieu = 1 });
            arrKDL.Add(new KieuDuLieu { Ten = "Tự động từ module khác", kieuDuLieu = 2 });
            arrKDL.Add(new KieuDuLieu { Ten = "Được tính toán", kieuDuLieu = 3 });
            repositoryItemLookUpEdit1.DataSource = arrKDL;
            repositoryItemLookUpEdit1.DisplayMember = "Ten";
            repositoryItemLookUpEdit1.ValueMember = "kieuDuLieu";

            btnFind_Click(null, null);
            LoadGrvLayout(grv);
            TranslateForm();
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu tham số tính lương...";
            dw_it.OnDoing = (s,ev) => 
            {
                if (string.IsNullOrWhiteSpace(txtSearchKey.Text))
                    LstData = db.tbLuong_DinhNghiaThamSos.ToList();
                else
                    LstData = db.tbLuong_DinhNghiaThamSos.Where(i => i.ten.IndexOf(txtSearchKey.Text.Trim()) >= 0).ToList();
                dw_it.bw.ReportProgress(1, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = new BindingList<tbLuong_DinhNghiaThamSo>(LstData);
                btnFind.Enabled = true;
                dlgEditor.LstThamSo = LstData;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dlgChonThamSo_FormClosing(object sender, FormClosingEventArgs e)
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
        private void dlgChonThamSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frm_Load(null, null);
            }
        }
    }
}