using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class XuLyDuLieu : dlgCustomBase
    {
        Common.dlgChonDoiTuong chonDT = new Common.dlgChonDoiTuong();
        public XuLyDuLieu()
        {
            InitializeComponent();
        }
        private void XuLyDuLieu_Load(object sender, EventArgs e)
        {
            this.Form_Title = SelectTranslate("XuLyDuLieu_Title", LoginHelper.langTrans);
            this.Text = SelectTranslate("XuLyDuLieu_Title", LoginHelper.langTrans);
            this.Form_Description = SelectTranslate("XuLyDuLieu_Des", LoginHelper.langTrans);
            chonKyLuong1.TuNgay = chonKyLuong1.DenNgay = DateTime.Today;
            //simpleButton1.Enabled = simpleButton2.Enabled = LoginHelper.user.isAdmin;
            //simpleButton1.Visible = simpleButton2.Visible = LoginHelper.user.isAdmin;
            btnDoImport.Left = this.Width - btnDoImport.Width - 18;
            TranslateForm();
        }

        private void bgw_import_DoWork(object sender, DoWorkEventArgs e)
        {
          
            iHRM.Win.ExtClass.QuetThe.XuLyDuLieu controller = new iHRM.Win.ExtClass.QuetThe.XuLyDuLieu(LoginHelper.user);
            controller.lp.OnOutMessage += (msg) => { bgw_import.ReportProgress(1, msg); };
            controller.lp.OnSetMaxValue += () => { bgw_import.ReportProgress(2, controller.lp.MaxValue); };
            controller.lp.OnSetValue += () => { bgw_import.ReportProgress(3, controller.lp.CurrentValue); };
            controller.lp.OnSetTitle += (title) => { bgw_import.ReportProgress(4, title); };
            DateTime tuNgay = chonKyLuong1.TuNgay;
            DateTime denNgay = chonKyLuong1.DenNgay;
            #region Check ngày đã lock
            bool isContinue = true;
            for (DateTime i = tuNgay.AddDays(-1); i <= denNgay;)
            {
                i = i.AddDays(1);
                if (IsLock.IsLock.Check_IsLock("tbKetQuaQuetThe", i))
                {
                    bgw_import.ReportProgress(1, string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} khổng thể thao tác!", i));
                    isContinue = false;
                    continue;
                }
            }
            #endregion
            if (isContinue)
            {
                controller.doAnalyza(tuNgay,
                    denNgay,
                    ucChonDoiTuong_DS1.GetValue(),
                    checkEdit1.Checked,
                    LoginHelper.user
                );

                LogAction.LogAction.PushLog("Analyze", ucChonDoiTuong_DS1.GetValue(), "", string.Format("Xử lý dữ liệu công từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", tuNgay, denNgay), "tbBangCongThang");
            }
        }
        private void bgw_import_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    outLog(e.UserState.ToString());
                    break;
                case 2:
                    prg.Properties.Maximum = (int)e.UserState;
                    break;
                case 3:
                    prg.EditValue = e.UserState;
                    break;
                case 4:
                    break;
            }
        }
        private void bgw_import_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDoImport.Enabled = true;
            btnDoImport.Image = Properties.Resources.play;
            prg.EditValue = prg.Properties.Maximum;
        }

        private void btnDoImport_Click(object sender, EventArgs e)
        {
            btnDoImport.Enabled = false;
            btnDoImport.Image = Properties.Resources.loading;
            if (!bgw_import.IsBusy)
                bgw_import.RunWorkerAsync();
        }
        void outLog(string log)
        {
            try
            {
                richTextBox1.AppendText(string.Format("\n{0:HH:mm:ss}: {1}", DateTime.Now, log));
            }
            catch(Exception ex)
            {
                win_globall.ExecCatch(ex);
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

        private void XuLyDuLieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                XuLyDuLieu_Load(null, null);
            }
        }
    }
}
