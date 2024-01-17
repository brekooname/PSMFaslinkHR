using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm.ThuongPhat
{
    public partial class frmThuongPhat : Form
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        DataTable dt = new DataTable();
        Boolean checkedit =false;
        public frmThuongPhat()
        {
            InitializeComponent();
        }

        private void frmThuongPhat_Load(object sender, EventArgs e)
        {
            TranslateForm();
            var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name_01",

            new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));
            repositoryItemSearchLookUpEditNV.DataSource = dtnv;
            repositoryItemSearchLookUpEditNV.DisplayMember = "EmployeeName";
            repositoryItemSearchLookUpEditNV.ValueMember = "EmployeeCode";

            repSearchLookUpEditTenQL.DataSource = db.w5sysUsers;
            repSearchLookUpEditTenQL.DisplayMember = "caption";
            repSearchLookUpEditTenQL.ValueMember = "id";

            edit();

            toolStripButton1_Click(null, null);

        }
        void timkiem() 
        {
            toolStripFind.Enabled = false;

            dt = Provider.ExecuteDataTable("p_getThuongPhat_byStrEmp",
                new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                new SqlParameter("denNgay", chonKyLuong1.DenNgay_End),
                Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue()));
            dt.Columns.Add("idFileDelete");
            dt = new DataTable();
            grd.DataSource = dt;

            toolStripFind.Enabled = true;
        }
        void edit() {
            if (checkedit ==false)
            {
                colEmployeeID.OptionsColumn.AllowEdit = false;
               
                colGhiChu.OptionsColumn.AllowEdit = false;
                colHinhThucShow.OptionsColumn.AllowEdit = false;
                colSoQD.OptionsColumn.AllowEdit = false;
                colSoTien.OptionsColumn.AllowEdit = false;
                colDateRequest.OptionsColumn.AllowEdit = false;
                colNgayHieuLuc.OptionsColumn.AllowEdit = false;
                colNgayQD.OptionsColumn.AllowEdit = false;
            }
            else
            {
                colEmployeeID.OptionsColumn.AllowEdit = true;
                
                colGhiChu.OptionsColumn.AllowEdit = true;
                colHinhThucShow.OptionsColumn.AllowEdit = true;
                colSoQD.OptionsColumn.AllowEdit = true;
                colSoTien.OptionsColumn.AllowEdit = true;
                colDateRequest.OptionsColumn.AllowEdit = true;
                colNgayHieuLuc.OptionsColumn.AllowEdit = true;
                colNgayQD.OptionsColumn.AllowEdit = true;
            }
        }
        private void repComboBoxThuongPhat_SelectedValueChanged(object sender, EventArgs e)
        {
            // colHinhThuc
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//tim kiem
        {
            toolStripFind.Enabled = false;
            dt = new DataTable();
            dt = Provider.ExecuteDataTable("p_getThuongPhat_byStrEmp",
                new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                new SqlParameter("denNgay", chonKyLuong1.DenNgay_End),
                Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue()));

            grd.DataSource = dt;
            dt.Columns.Add("idFileDelete");
            toolStripFind.Enabled = true;
        }

        private void repositoryItemSearchLookUpEditNV_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
           
            this.grv.SetFocusedRowCellValue(colMaNhanVien, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeCode"));
            this.grv.SetFocusedRowCellValue(colDepName, searchEdit.Properties.View.GetFocusedRowCellValue("DepName_Final"));
        }

        private void repComboBoxThuongPhat_EditValueChanged(object sender, EventArgs e)
        {
           
           /* int a = kiemtra();
            if (a != 2)
            {
                this.gridView1.SetFocusedRowCellValue(colHinhThuc, a);
            }
            else
            {*/
                ComboBoxEdit edit = (ComboBoxEdit)sender;
                object editValue = edit.EditValue;
                if (editValue.ToString() == "Phạt")
                {
                    this.grv.SetFocusedRowCellValue(colHinhThuc, 1);
                }
                else
                {
                    this.grv.SetFocusedRowCellValue(colHinhThuc, 0);
                }


           // }
        }
        int kiemtra()
        {
            string a = grv.GetFocusedRowCellValue(colHinhThucShow).ToString();
            if (a == "Thưởng")
            {
                return 1;
            }
            else if(a == "Phạt")
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }

        private void repItemButtonEditFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dr = grv.GetFocusedDataRow();
            if (e.Button.Index == 0)//xem
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
            if (e.Button.Index == 1)//chon
            {

                if (checkedit == true)
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
                                var x = Guid.NewGuid();
                                dr["idFile"] = Guid.NewGuid();
                            }
                        }
                    }
                    else
                    {
                        GUIHelper.Notifications("Không có dữ liệu để chọn", "Mở file", GUIHelper.NotifiType.error);
                    }
                }
            }
            if (e.Button.Index == 2)//xoa
            {
                if (checkedit == true)
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
        }

        private void toolStripSave_Click(object sender, EventArgs e)//luu
        {
            checkedit = false;
            edit();
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }
            dcDatabaseFilesDataContext dbFile = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);
            var count = dt.GetChanges().Rows.Count;
            
           
            
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
                    }
                        dbFile.SubmitChanges();
                    }
                    Provider.UpdateData(dt, "tbThuong_Phat");
                    GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
                    
                  
                }
            catch (Exception ex)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các yêu cầu đang chọn?", "Xóa tất cả các yêu cầu đang chọn", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        grv.DeleteRow(rc[i - 1]);
                    }

                }
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.grv.SetFocusedRowCellValue(colID, Guid.NewGuid());
            this.grv.SetFocusedRowCellValue(colDateRequest, DateTime.Now);
            this.grv.SetFocusedRowCellValue(colidUser,LoginHelper.user.id);
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = grv.GetDataRow(e.RowHandle);
            if (r != null && r.RowState != DataRowState.Unchanged)
            {
                if (r["EmployeeID"] == DBNull.Value )
                {
                    e.ErrorText = ("Bạn cần phải chọn nhân viên.\n");
                    e.Valid = false;
                    return;
                }
                if (r["NgayHieuLuc"] == DBNull.Value || r["NgayHieuLuc"].ToString() == "")
                {

                    e.ErrorText = ("Bạn cần phải nhập ngày hiệu lực \n");
                    e.Valid = false;
                    return;
                }
                if (r["NgayQD"] == DBNull.Value || r["NgayQD"].ToString() == "")
                {

                    e.ErrorText = ("Bạn cần phải nhập ngày quyết định \n");
                    e.Valid = false;
                    return;
                }
                if (r["SoQD"] == DBNull.Value || r["SoQD"].ToString() == "")
                {

                    e.ErrorText = ("Bạn cần phải nhập số quyết định \n");
                    e.Valid = false;
                    return;
                }
                if (r["HinhThuc"] == DBNull.Value || r["HinhThuc"].ToString() == "")
                {

                    e.ErrorText = ("Bạn cần phải chọn hình thức \n");
                    e.Valid = false;
                    return;
                }
                if (r["SoTien"] == DBNull.Value || r["SoTien"].ToString() == "")
                {

                    e.ErrorText = ("Bạn cần phải nhập số tiền \n");
                    e.Valid = false;
                    return;
                }
            }
        }

        private void toolStripExcel_Click(object sender, EventArgs e)
        {
        a:
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
                        grd.ExportToXls(exportFilePath, options);
                        break;
                    case ".xlsx":
                        grd.ExportToXlsx(exportFilePath);
                        break;
                    case ".rtf":
                        grd.ExportToRtf(exportFilePath);
                        break;
                    case ".pdf":
                        grd.ExportToPdf(exportFilePath);
                        break;
                    case ".html":
                        grd.ExportToHtml(exportFilePath);
                        break;
                    case ".mht":
                        grd.ExportToMht(exportFilePath);
                        break;
                    default:
                        // lỗi tên file
                        MessageBox.Show("Lỗi tên file", "Export excel");
                        goto a;
                }

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = exportFilePath,
                    UseShellExecute = true
                });
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            checkedit = true;
            edit();
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

        private void frmThuongPhat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmThuongPhat_Load(null, null);
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
            // dịch radiogrop duyệt 
            //rdAccept.Properties.Items[0].Description = SelectTranslate("rdAcceptTatca", langTrans);
            //rdAccept.Properties.Items[1].Description = SelectTranslate("rdAcceptDaDuyet", langTrans);
            //rdAccept.Properties.Items[2].Description = SelectTranslate("rdAcceptKhongDuyet", langTrans);

            #endregion
        }

        #endregion
    }
}
