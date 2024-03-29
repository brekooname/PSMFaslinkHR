﻿using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
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

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class frmNhomHuongLuong_TS : frmBase
    {
        dcLuongv3DataContext db;
        List<tbLuong_DinhNghiaThamSo> LstData;

        dlgNhomHuongLuong_TS dlgEditor = new dlgNhomHuongLuong_TS();

        public frmNhomHuongLuong_TS()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            //txtModule.Properties.DataSource = CacheDataTable.GetCacheDataTable("tbDM_nhomNV");
            DataTable dt = Provider.ExecuteDataTable("p_tbDM_nhomNV_idDM_nhomNV_idUser", new System.Data.SqlClient.SqlParameter("idUser", LoginHelper.user.id));
            txtModule.Properties.DataSource = dt;

            LoadGrvLayout(grv);
            TranslateForm();

        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtModule.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn nhóm");
                return;
            }

            btnFind.Enabled = false;
            db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) => 
            {
                LstData = db.tbNhanVien_ThamSoLuongs.Where(i => i.nhomnv_id == txtModule.EditValue as int?).Select(i => i.tbLuong_DinhNghiaThamSo).ToList();
                dw_it.bw.ReportProgress(1, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = new BindingList<tbLuong_DinhNghiaThamSo>(LstData);
                btnFind.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtModule.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn nhóm");
                return;
            }
            var drs = grv.GetSelectedRows().Select(i => grv.GetRow(i) as tbLuong_DinhNghiaThamSo);
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            
            try
            {
                Provider.ExecuteNonQuery_SQL(string.Format("DELETE tbNhanVien_ThamSoLuong where nhomnv_id={0} and thamso_id in ({1})",
                    txtModule.EditValue as int?,
                    string.Join(",", drs.Select(i => i.id))
                ));

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                grv.DeleteSelectedRows();

                var log = Log2.CreateLog(Log2.Log2Action.xoa, "Xóa " + drs.Count() + " bản ghi", "tbNhanVien_ThamSoLuong");
                log.tbLog2_details.AddRange(drs.Select(i => new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "id",
                    target2 = "ten",
                    value1 = i.id.ToString(),
                    value2 = i.ten
                }).ToArray());
                Log2.PushLog(log);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtModule.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn nhóm");
                return;
            }

            dlgEditor.MyValue = LstData;
            if (dlgEditor.ShowDialog() == DialogResult.OK)
            {
                if (dlgEditor.MyValue.Count() == 0)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                    return;
                }

                try
                {
                    var newLst = new List<tbLuong_DinhNghiaThamSo>();
                    foreach (var it in dlgEditor.MyValue)
                    {
                        if (LstData.Count(i => i.id == it.id) == 0)
                            newLst.Add(it);
                    }

                    Provider.ExecuteNonQuery_SQL("INSERT tbNhanVien_ThamSoLuong (id,thamso_id,nhomnv_id) VALUES " +
                        string.Join(",", newLst.Select(i => string.Format("(newid(),{0},{1})", i.id, txtModule.EditValue as int?)))
                    );
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                    LstData.AddRange(newLst);
                    grd.DataSource = new BindingList<tbLuong_DinhNghiaThamSo>(LstData);

                    var log = Log2.CreateLog(Log2.Log2Action.them, "Thêm " + newLst.Count() + " bản ghi", "tbNhanVien_NhomNV");
                    log.tbLog2_details.AddRange(newLst.Select(i => new Core.Business.DbObject.tbLog2_detail()
                    {
                        id = Guid.NewGuid(),
                        log_id = log.id,
                        target1 = "id",
                        target2 = "ten",
                        value1 = i.id.ToString(),
                        value2 = i.ten
                    }).ToArray());
                    Log2.PushLog(log);
                }
                catch (Exception ex)
                {
                    win_globall.ExecCatch(ex);
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
        private void frmNhomHuongLuong_TS_KeyDown(object sender, KeyEventArgs e)
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
