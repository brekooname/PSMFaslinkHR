using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Reflection;
using System.Collections.Generic;

namespace iHRM.Win.Frm.Luong_v3.Module
{
    public partial class frmLuongDinhKemFile : frmBase
    {
        DataTable dt = new DataTable();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        Boolean Editfile = false;
        public frmLuongDinhKemFile()
        {
            InitializeComponent();
        }
        private void resItemButtonFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dr = grv.GetFocusedDataRow();
            if (e.Button.Index == 0)// Xem file
            {
                if (dr != null && dr["dataFile"] != DBNull.Value)
                {
                    FileStorageHelper fh = new FileStorageHelper();

                    var duoiFile = grv.GetFocusedRowCellValue(colDuoiFile).ToString();
                    Binary dataFile = new Binary(dr["dataFile"] as byte[]);
                    fh.DownLoadAndShowFILE(dataFile, dr["duoiFile"].ToString());
                }
                else
                {
                    GUIHelper.Notifications("Không có dữ liệu để xem", "Mở file", GUIHelper.NotifiType.error);
                }
            }
            else if (e.Button.Index == 1) // Chọn file mới
            {
                if (Editfile == true)
                {
                    if (dr != null)
                    {
                        OpenFileDialog od = new OpenFileDialog();
                        string filterFile = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                        filterFile += "|Word files (*.doc, *.docx)|*.doc; *.docx; ";
                        filterFile += "|Pdf files (*.pdf)|*.pdf; ";
                        filterFile += "|All files (*.*)|*.*;";
                        od.Filter = filterFile;
                        od.Multiselect = false;
                        if (od.ShowDialog() == DialogResult.OK)
                        {
                            byte[] bytes = System.IO.File.ReadAllBytes(od.FileNames[0]);
                            dr["dataFile"] = bytes;
                            dr["duoiFile"] = Path.GetExtension(od.FileNames[0]);
                            if (dr["idFile"] == DBNull.Value)
                            {
                                dr["idFile"] = Guid.NewGuid();
                            }
                        }
                    }
                    else
                    {
                        GUIHelper.Notifications("Không có dữ liệu để chọn, xin hãy điền dữ liệu trước ", "Mở file", GUIHelper.NotifiType.error);
                    }
                }
            }
            else if (e.Button.Index == 2) // Xóa file
            {
                if (dr != null)
                {
                    
                    dr["idFileDelete"] = dr["idFile"];
                    dr["dataFile"] = DBNull.Value;
                    dr["idFile"] = DBNull.Value;
                    dr["duoiFile"] = DBNull.Value;
                    GUIHelper.Notifications("Đã xóa file đính kèm. Bấm lưu lại để hoàn thành.", "Xóa file đính kèm", GUIHelper.NotifiType.info);
                }
                else
                {
                    GUIHelper.Notifications("Không có dữ liệu để xóa", "Xóa file", GUIHelper.NotifiType.error);
                }
            }
        }
        private void toolStripSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        void search()
        {
            toolStripSearch.Enabled = false;
            dt = new DataTable();

            dt = Provider.ExecuteDataTable("p_getluong_DinhKem",
                new SqlParameter("Ngay", Convert.ToDateTime(deKiLuong.EditValue))
            );
            dt.Columns.Add("idFileDelete");
            grd.DataSource = dt;
            toolStripSearch.Enabled = true;
        }
        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            Editfile = false;
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }
            dcDatabaseFilesDataContext dbFile = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);
            var count = dt.GetChanges().Rows.Count;
            string mnv = string.Empty;
            long idUserRequests = 0;
            DateTime ngay = DateTime.Now;
            DateTime ngayYeuCau = DateTime.Now;
            try
            {
                foreach (DataRow dr in dt.GetChanges().Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if (dr["idFile"] == DBNull.Value)
                        {
                            if (dr["idFileDelete"] != DBNull.Value)
                            {
                                var a = dbFile.tbFiles.Where(p => p.id == Guid.Parse(dr["idFileDelete"].ToString())).FirstOrDefault();
                                if (a != null)
                                {
                                    dbFile.tbFiles.DeleteOnSubmit(a);
                                }
                            }
                        }
                        else
                        {
                            var a = dbFile.tbFiles.Where(p => p.id == Guid.Parse(dr["idFile"].ToString())).FirstOrDefault();
                            if (a == null)
                            {
                                a = new tbFile();
                                a.id = Guid.Parse(dr["idFile"].ToString());
                                dbFile.tbFiles.InsertOnSubmit(a);
                            }
                            if (dr["duoiFile"] == DBNull.Value)
                            {
                                a.duoiFile = null;
                            }
                            else
                                a.duoiFile = dr["duoiFile"].ToString();
                            if (dr["dataFile"] == DBNull.Value)
                            {
                                a.dataFile = null;
                            }
                            else
                                a.dataFile = dr["dataFile"] as byte[];
                        }
                        dbFile.SubmitChanges();
                        idUserRequests = long.Parse(dr["idUser"].ToString());
                        ngay = Convert.ToDateTime(dr["Date"]);
                        ngayYeuCau = Convert.ToDateTime(dr["DateRequest"]);
                    }

                    Provider.UpdateData(dt, "tbluong_DinhKem");
                } 
                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
               
                colTen.OptionsColumn.AllowEdit = false;
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }
        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
       {        

            var dr = grv.GetDataRow(e.RowHandle);
            if (dr != null )
            {
                dr["DateRequest"] = DateTime.Now;
                dr["idUser"] = LoginHelper.user.id;
                dr["id"]= Guid.NewGuid();
                dr["Date"] =Convert.ToDateTime(deKiLuong.EditValue);
            }
        }
        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các yêu cầu đang chọn?", "Xóa tất cả các yêu cầu đang chọn", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();
                
                for(int i= rc.Count(); i > 0 ;i--)
                {
                    var r = grv.GetDataRow(rc[i-1]);
                    if (r != null)
                    {
                            grv.DeleteRow(rc[i-1]); 
                    }
                }
            }
        }
        private void grv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = grv.GetDataRow(e.RowHandle);
            if (r != null && r.RowState != DataRowState.Unchanged)
            {
                if (r["Ten"] == DBNull.Value || r["Ten"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập Tên.\n");
                    e.Valid = false;
                    return;
                }
                if (r["dataFile"] == DBNull.Value || r["dataFile"].ToString() == ""|| r["idFile"] == DBNull.Value || r["idFile"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải chọn File đính kèm.\n");
                    e.Valid = false;
                    return;
                }
            }
        }  
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmLuongDinhKemFile_Load(null,null);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            grv.OptionsPrint.UsePrintStyles = false;
            
            ExportGrid(grd);
        }
        private void grv_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            //var r = grv.GetDataRow(e.RowHandle);
            if (e.RowHandle > -1) e.Info.DisplayText = (e.RowHandle + 1).ToString();
            //if (e.RowHandle > -1)  r.SetField(0, (e.RowHandle + 1).ToString());
        }
        private void frmLuongDinhKemFile_Load(object sender, EventArgs e)
        {
            deKiLuong.EditValue = DateTime.Now;
            colTen.OptionsColumn.AllowEdit = false;
            Editfile = false;
            toolStripSearch_Click(null,null);
            TranslateForm();
            
        }
        private void deKiLuong_EditValueChanged(object sender, EventArgs e)
        {
            //search();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(Editfile == false)
            {
                Editfile = true;
                colTen.OptionsColumn.AllowEdit = true;
            }
            else
            {
               // Editfile = false;
               // colTen.OptionsColumn.AllowEdit = false;
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
        private void frmLuongDinhKemFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmLuongDinhKemFile_Load(null, null);
            }
        }
    }
}
