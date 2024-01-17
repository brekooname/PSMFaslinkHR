using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using iHRM.Core.Business.DbObject;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace iHRM.Win.Frm.MayChamCong
{
    public partial class ThongTinNhanVien : DevExpress.XtraEditors.XtraForm
    {
        dcDatabaseMCCDataContext db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);

        public ThongTinNhanVien()
        {
            InitializeComponent();
        }

        private void KhaibaoMCC_Load(object sender, EventArgs e)
        {
            grvTTNV.OptionsBehavior.Editable = false;

            grvTTNV.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            menuRefresh_LuongCB_Click(null, null);
            TranslateForm();
        }

        private void grvKhaiBaoMCC_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == colSTT)

                    e.Value = e.ListSourceRowIndex + 1;
            }
        }

        private void grvKhaibaoMCC_InitNewRow_1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var nv = db.tbNhanViens.OrderByDescending(p => p.maChamCong).FirstOrDefault();

            long lastMaCC = 0;

            if (nv != null)
            {
                lastMaCC = nv.maChamCong;
            }

            var dr = grvTTNV.GetRow(e.RowHandle) as tbNhanVien;

            if (dr != null)
            {
                dr.maChamCong = lastMaCC + 1;
            }
        }

        private void menuRefresh_LuongCB_Click(object sender, EventArgs e)
        {
            grvTTNV.OptionsBehavior.Editable = false;

            grvTTNV.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);

            //dbnv = new dcDatabaseDataContext(Provider.ConnectionString);

            //var td = db.tbNhanViens.ToList();
            //var tdnv =dbnv.tblEmployees.ToList();

            //var dtt = ( from u in td
            //          join v in tdnv on u.maNV equals v.EmployeeCode into m
            //          from z in m.DefaultIfEmpty()
            //          select new
            //          {
            //              tenChamCong = u.tenChamCong,
            //              maThe = u.maThe,
            //              maNV = u.maNV,
            //              maChamCong = u.maChamCong,
            //              loaiNhanVien = u.loaiNhanVien,
            //              DepName_Final = (z == null ? string.Empty : z.DepName_Final)
            //          }).OrderBy(p => p.maChamCong);

            //grcTTNV.DataSource = dtt;

            grcTTNV.DataSource = db.tbNhanViens.OrderBy(p => p.maChamCong);
        }

        private void menuDelete_LuongCB_Click(object sender, EventArgs e)
        {
            if (GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa nhân viên: " + grvTTNV.GetFocusedRowCellValue("tenChamCong").ToString()))
            {
                try
                {
                    if (grvTTNV.FocusedRowHandle >= 0)
                    {
                        grvTTNV.DeleteRow(grvTTNV.FocusedRowHandle);
                    }

                    db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                }
                catch (Exception)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelFalse);
                }
            }
        }

        private void menuSave_LuongCB_Click(object sender, EventArgs e)
        {
            try
            {
                db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);

                grvTTNV.OptionsBehavior.Editable = false;

                grvTTNV.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            }
            catch (Exception)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveFalse);
            }
        }

        private void grvTTNV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colSoTheQuet)
            {
                if (db.tbNhanViens.Where(p => p.maThe == e.Value.ToString()).Count() >= 1)
                {
                    GUIHelper.MessageError("Mã thẻ quẹt " + e.Value + " đã có người sử dụng!");
                }
            }
            if (e.Column == colMaThesHRM)
            {
                if (db.tbNhanViens.Where(p => p.maThesHRM == e.Value.ToString()).Count() >= 1)
                {
                    GUIHelper.MessageError("Mã thẻ sHRM " + e.Value + " đã có người sử dụng!");
                }
            }
        }

        private void menuEdit_LuongCB_Click(object sender, EventArgs e)
        {
            grvTTNV.OptionsBehavior.Editable = true;

            grvTTNV.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

            GUIHelper.Notifications("Bạn đã có thể sửa trực tiếp trên lưới danh sách.", "Sửa dữ liệu", GUIHelper.NotifiType.info);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "Excel (2003)|*.xls|Excel (2007)|*.xlsx |RichText File|*.rtf |Pdf File|*.pdf |Html File|*.html";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveDialog.FileName;

                string fileExtenstion = (new System.IO.FileInfo(exportFilePath)).Extension;

                switch (fileExtenstion)
                {
                    case ".xls":

                        XlsExportOptions options = new XlsExportOptions();

                        options.TextExportMode = TextExportMode.Value;

                        grcTTNV.ExportToXls(exportFilePath, options);

                        break;

                    case ".xlsx":

                        grcTTNV.ExportToXlsx(exportFilePath);

                        break;

                    case ".rtf":

                        grcTTNV.ExportToRtf(exportFilePath);

                        break;

                    case ".pdf":

                        grcTTNV.ExportToPdf(exportFilePath);

                        break;

                    case ".html":

                        grcTTNV.ExportToHtml(exportFilePath);

                        break;

                    case ".mht":

                        grcTTNV.ExportToMht(exportFilePath);

                        break;
                }

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = exportFilePath,
                    UseShellExecute = true
                });
            }
        }

        private void grvTTNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcTTNV.FocusedView as GridView;
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
        private IEnumerable<DevExpress.XtraEditors.GroupControl> EnumerateGroupControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.GroupControl).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.GroupControl)field.GetValue(this)
                   where component != null
                   select component;
        }
        //DevExpress.XtraGrid.Views.BandedGrid.GridBand
        private IEnumerable<DevExpress.XtraGrid.Views.BandedGrid.GridBand> EnumerateGridBand()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraGrid.Views.BandedGrid.GridBand).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraGrid.Views.BandedGrid.GridBand)field.GetValue(this)
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
            var _GridBand = EnumerateGridBand();
            var _GroupControl = EnumerateGroupControl();
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
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand s in _GridBand)
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
            foreach (DevExpress.XtraEditors.GroupControl s in _GroupControl)
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
        private void ThongTinNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                KhaibaoMCC_Load(null, null);
            }
        }
    }
}