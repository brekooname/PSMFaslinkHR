using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    public partial class dlgCaLam : dlgBase
    {
        DataTable dtSoTiengTinhCa = null;

        public dlgCaLam()
        {
            InitializeComponent();

            dlgData.IdColumnName = TableConst.tbCaLamViec.id;
            dlgData.CaptionColumnName = TableConst.tbCaLamViec.ten;
            dlgData.FormCaption = "Ca làm";

            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.ten, txtTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("kqNgayCong", txtKetQuaNgayCong, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tuGio, txtTuGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.denGio, txtDenGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tgQuetTruoc_Vao, txtTgQuetTruocVao, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tgQuetTruoc_Ra, txtTgQuetTruocRa, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tgQuetSau_Vao, txtTgQuetSauVao, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.tgQuetSau_Ra, txtTgQuetSauRa, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.soTiengTinhCa, txtSoTiengTinhCa, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.soTiengTangCaTrachNhiem, txtTangCaTrachNhiem, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.soTiengTinhTangCa, txtSoTiengTinhTC, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.caSang_tuGio, txtCaSangTuGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.caSang_denGio, txtCaSangDenGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.caChieu_tuGio, txtCaChieuTuGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.caChieu_denGio, txtCaChieuDenGio, ControlBinding_DataType.TimeSpan));
            dlgData.CB.Add(new ControlBinding(TableConst.tbCaLamViec.caDem, chkisCaDem, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("T7LamSang", chkT7LamSang, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("isKhongCanQuetThe", chkBatBuocQuetThe, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("Alias", txtAlias, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("idKhoiPB", treeDept, ControlBinding_DataType.Int));

            dlgData.CB.Add(new ControlBinding("isCaLamAudit", chkisCaLamAudit, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("idCaLamAudit", txtidCaLamAudi, ControlBinding_DataType.Guid));
            dlgData.CB.Add(new ControlBinding("caLamAuditKhongTangCa", chkcaLamAuditKhongTangCa, ControlBinding_DataType.Bool));

            dlgData.CB.Add(new ControlBinding("isTruTangCa", chkisTruTangCa, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("soTiengTangCa", txtsoTiengTangCa, ControlBinding_DataType.Float));
            dlgData.CB.Add(new ControlBinding("soTiengTruTangCa", txtsoTiengTruTangCa, ControlBinding_DataType.Float));

            treeDept.Properties.DataSource = Cls.CacheDataTable.GetCacheDataTable("tblRef_Department");
            txtidCaLamAudi.Properties.DataSource = Cls.CacheDataTable.GetCacheDataTable("tbCaLamViec");
        }

        protected override void FormSetData()
        {
            base.FormSetData();

            if (myID != null)
            {
                xtraTabPage2.PageVisible = true;
                dtSoTiengTinhCa = Provider.ExecuteDataTableReader_SQL("SELECT * FROM tbCaLam_TinhTangCa WHERE idCaLamViec='" + myID + "'");
                grd.DataSource = dtSoTiengTinhCa;
            }
            else
            {
                xtraTabPage2.PageVisible = false;
            }
        }

        protected override void FormGetData()
        {
            base.FormGetData();

            if (myValue["soTiengTinhTangCa"] == DBNull.Value)
            myValue["soTiengTinhTangCa"] = 0;

            Provider.UpdateData(dtSoTiengTinhCa, "tbCaLam_TinhTangCa");
            //if (myID != null)
            //{ 
            //   txtSoTiengTinhTC.Text = Provider.ExecuteScalar("p_tbcalam_recalc_soTiengTinhTangCa", new System.Data.SqlClient.SqlParameter("id", myID)).ToString();
            //    myValue["soTiengTinhTangCa"] = txtSoTiengTinhTC.Text;
            //}
        }

        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dr = grv.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr[TableConst.tbCaLam_TinhTangCa.id] = Guid.NewGuid();
                dr[TableConst.tbCaLam_TinhTangCa.idCaLamViec] = myID;
            }
        }
        
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var it = grv.GetFocusedDataRow() as DataRow;
            if (it != null)
                it.Delete();
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

        private void dlgCaLam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgCaLam_Load(null, null);
            }
        }

        private void dlgCaLam_Load(object sender, EventArgs e)
        {
            TranslateForm();
        }


    }
}
