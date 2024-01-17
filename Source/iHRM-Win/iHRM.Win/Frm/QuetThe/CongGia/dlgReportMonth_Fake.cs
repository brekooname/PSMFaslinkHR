using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass;
using iHRM.Win.Frm.XtraReportTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using iHRM.Win.Frm.LogAction;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using iHRM.Win.DungChung;
using DevExpress.XtraPrinting;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgReportMonth_Fake : dlgCustomBase
    {
        Core.Business.Logic.ChamCong.ReportMonthLogic logic = new Core.Business.Logic.ChamCong.ReportMonthLogic();
        Core.Controller.QuetThe.ReportMonth controller = new Core.Controller.QuetThe.ReportMonth();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        List<ActionClass> _lActionClass = new List<ActionClass>();
        dsXuLyQuetThe ds;
        public string empID { get; set; }
        public string empName { get; set; }
        public DateTime tuNgay { get; set; }
        public DateTime denNgay { get; set; }

        public dlgReportMonth_Fake()
        {
            InitializeComponent();
        }

        private void dlgReportMonth_Load(object sender, EventArgs e)
        {
            frmBase.LoadGrvLayout_custom(grv, "QuetThe.CongGia.dlgReportMonth");
            lookupCaLam.DataSource = db.tbCaLamViecs;
            lookupLamThem.DataSource = db.tbLoaiNgayLamThems;

            this.Form_Title = SelectTranslate("dlgReportMonth_Title", LoginHelper.langTrans);
            this.Text = SelectTranslate("dlgReportMonth_Title", LoginHelper.langTrans);
            this.Form_Description = SelectTranslate("dlgReportMonth_Des", LoginHelper.langTrans);
        }

        public void LoadData()
        {
            ds = new dsXuLyQuetThe();
            List<string> _lNV = new List<string>();

            Provider.LoadData(ds, ds.tbCaLamViec.TableName);
            Provider.LoadData(ds, ds.tbNgayNghiPhepNam.TableName);
            Provider.LoadData(ds, ds.tblRef_LeaveType.TableName);
            Provider.LoadData(ds, ds.tbLoaiNgayLamThem.TableName);

            Provider.LoadDataByProc(ds, ds.tblEmpDayOff.TableName, "p_getAllDangKyVangMat_ByList", Provider.CreateParameter_StringList("dtEmpID", empID));

            Provider.LoadDataByProc(ds, ds.tblEmp7hours.TableName, "p_GetAllEmp7hours_ByList", Provider.CreateParameter_StringList("dtEmpID", empID));
            Provider.LoadDataByProc(ds, ds.tbKetQuaQuetThe_Fake.TableName, "p_duLieuQuetThe_GetAllKetQuaQuetThe_Fake_TinhCong_ByList", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), Provider.CreateParameter_StringList("dtEmpID", empID));

            this.Form_Title = string.Format(SelectTranslate("dlgReportMonth_Title", LoginHelper.langTrans) + " [{0}]-[{1}]", empID, empName);
            ds.tbKetQuaQuetThe_Fake.Columns.Add("TT");
            ds.tbKetQuaQuetThe_Fake.Columns.Add("tgTangCa", typeof(double));
            ds.tbKetQuaQuetThe_Fake.Columns.Add("tgDiMuon_grv", typeof(double));
            ds.tbKetQuaQuetThe_Fake.Columns.Add("tgTangCa_grv", typeof(double));
            ds.tbKetQuaQuetThe_Fake.Columns.Add("tgVeSom_grv", typeof(double));
            ds.tbKetQuaQuetThe_Fake.Columns.Add("caLam", typeof(string));
            dcDatabaseFilesDataContext dbFile = new dcDatabaseFilesDataContext(Provider.ConnectionString);

            Double TongNC = 0;
            Double TongNC_LThem = 0;
            Double TongTC = 0;

            foreach (DataRow dr in ds.tbKetQuaQuetThe_Fake.Rows)
            {
                dr["tgDiMuon_grv"] = dr["tgDiMuon"];
                dr["tgTangCa"] = 0;
                dr["tgTangCa_grv"] = 0;
                dr["tgVeSom_grv"] = dr["tgVeSom"];
                dr["TT"] = Core.Controller.QuetThe.Helper.GetTrangThai(dr, 2);
                if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                    dr["tgDiMuon_grv"] = 0;
                if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                {
                    dr["tgTangCa_grv"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                    dr["tgVeSom_grv"] = 0;
                }
                try
                {
                    Guid dkCL = Guid.Parse(dr["idCaLam"].ToString());
                    string caLam = ds.tbCaLamViec.Where(p => p.id == dkCL).FirstOrDefault().ten;
                    if (dr["dkLamThem"] != DBNull.Value) // Ngày làm thêm
                    {
                        try
                        {
                            int dkLT = Convert.ToInt16(dr["dkLamThem"]);
                            string tenLoaiLT = ds.tbLoaiNgayLamThem.Where(p => p.id == dkLT).FirstOrDefault().tenLoai;
                            caLam = caLam + " - " + tenLoaiLT;

                            TongNC_LThem += Convert.ToDouble(dr["kqNgayCong"]);
                            TongTC += Convert.ToDouble(dr["tgTinhTangCa"]);

                        }
                        catch (Exception)
                        {
                        }
                    }
                    else // Ngày thường
                    {
                        TongNC += Convert.ToDouble(dr["kqNgayCong"]);
                        TongTC += Convert.ToDouble(dr["tgTinhTangCa"]);
                    }

                    dr["caLam"] = caLam;
                }
                catch (Exception)
                {
                }
            }

            grd.DataSource = ds.tbKetQuaQuetThe_Fake;

            if (ds.tbKetQuaQuetThe_Fake != null && ds.tbKetQuaQuetThe_Fake.Rows.Count > 0)
            {
                stt_Ngay.Text = "Tổng: " + ds.tbKetQuaQuetThe_Fake.Rows.Count;
                stt_CongWD.Text = string.Format("Công: {0:0.##} ({1:0.##})", TongNC, TongTC);
                stt_CongCN.Text = string.Format("L.Thêm: {0:0.##}", TongNC_LThem);

                stt_DSVM.Text = string.Format("ĐM: {0:#,0} - VS: {1:#,0} - LT: {2} - VM: {3}",
                    ds.tbKetQuaQuetThe_Fake.Compute("SUM(tgDiMuon)", ""),
                    ds.tbKetQuaQuetThe_Fake.Compute("SUM(tgVeSom)", ""),
                    ds.tbKetQuaQuetThe_Fake.Compute("COUNT(tt_leTet)", ""),
                    ds.tbKetQuaQuetThe_Fake.Compute("SUM(tt_nghiPhep)", "")
                );
            }

            toolStripButton3.Enabled = (ds.tbKetQuaQuetThe != null && ds.tbKetQuaQuetThe_Fake.Rows.Count > 0);
            ds.tbKetQuaQuetThe_Fake.AcceptChanges();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(Provider.ConnectionString);

            var dt = ds.tbKetQuaQuetThe_Fake.GetChanges();

            if (dt == null || dt.Rows.Count == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            string msg = "";
            string str = "";

            dsXuLyQuetThe.tbKetQuaQuetThe_FakeDataTable dtChanged = (dsXuLyQuetThe.tbKetQuaQuetThe_FakeDataTable)dt;
            foreach (var kqChanged in dtChanged)
            {
                bool isNew = false;
                try
                {
                    var emp = db.tblEmployees.Where(p => p.EmployeeID == empID).FirstOrDefault();
                    var islock = db.tblRef_IsLocks.Where(p => p.tableName == "tbKetQuaQuetThe_Fake" && p.ngay == kqChanged.ngay).FirstOrDefault();

                    if (emp != null && emp.EmployedDate != null && emp.EmployedDate > kqChanged.ngay)
                    {
                        if (emp.AppliedDate != null && emp.AppliedDate > kqChanged.ngay)
                        {
                            str = string.Format("Ngày {0:dd/MM/yyyy} nhân viên {1} chưa vào làm", kqChanged.ngay, empID, emp.LeftDate.Value);
                        }
                        if (emp.LeftDate != null && kqChanged.ngay >= emp.LeftDate.Value.Date)
                        {
                            str = string.Format("Ngày {0:dd/MM/yyyy} nhân viên {1} đã nghỉ làm từ ngày {2:dd/MM/yyyy}", kqChanged.ngay, empID, emp.LeftDate.Value);
                        }
                        if (str != "")
                        {
                            GUIHelper.Notifications(str, "Lưu dữ liệu", GUIHelper.NotifiType.tick);
                        }
                        return;
                    }

                    if (islock != null)
                    {
                        str = string.Format("Ngày {0:dd/MM/yyyy} đã chốt dữ liệu công", kqChanged.ngay);
                        GUIHelper.Notifications(str, "Lưu dữ liệu", GUIHelper.NotifiType.tick);
                        return;
                    }

                    var kq = ds.tbKetQuaQuetThe_Fake.Where(p => p.id == kqChanged.id).FirstOrDefault();
                    if (kq == null)
                    {
                        isNew = true;
                        kq = ds.tbKetQuaQuetThe_Fake.NewtbKetQuaQuetThe_FakeRow();
                    }
                    kq.modifyDate = DateTime.Now;
                    kq.modifyBy = LoginHelper.user.id;

                    iHRM.Win.ExtClass.QuetThe_Fake.QuetThe.AnalyzeDataQuetThe_dlgXL(kq, emp.IsNotOT, tuNgay, false, db, false, kq.EmployeeID, 0, 1);
                    if (isNew)
                    {
                        ds.tbKetQuaQuetThe_Fake.AddtbKetQuaQuetThe_FakeRow(kq);
                    }
                    _lActionClass.Add(new ActionClass("Analyze", kq.EmployeeID, "", "Xử lý dữ liệu công báo cáo do thay đổi giờ vào: " + kq.tgQuetDen.ToString() + ", giờ ra: " + kq.tgQuetVe.ToString() + string.Format(", ngày: {0: dd/MM/yyyy}", Convert.ToDateTime(kq.ngay.ToString())), "tbKetQuaQuetThe_Fake"));
                }
                catch (Exception ex)
                {
                    msg += ex + "\n";
                }
            }

            if (!string.IsNullOrWhiteSpace(msg))
            {
                GUIHelper.MessageBox(msg, "Lỗi");
            }
            else
            {
                var rowChanged = ds.tbKetQuaQuetThe_Fake.GetChanges().Rows.Count;
                Provider.UpdateData(ds, ds.tbKetQuaQuetThe_Fake.TableName);
                GUIHelper.Notifications("Cập nhật thành công " + rowChanged + " records", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
                ds.tbKetQuaQuetThe_Fake.AcceptChanges();
                if (_lActionClass.Count > 0)
                {
                    LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();
                }
                LoadData();
            }
        }

        private void dlgReportMonth_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBase.SaveGrvLayout_custom(grv, "QuetThe.dlgReportMonth");
        }

        private void dlgReportMonth_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void grv_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var r = e.Row as DataRowView;
                if (r == null)
                    return;

                if (e.Column == colL)
                {
                    if ((r["isLocked"] as bool?) == true)
                        e.Value = Properties.Resources.ico20_lock;
                    else
                        e.Value = null;
                }
                else if (e.Column == colCaNghi) // Cột nghỉ cả ngày
                {
                    if (r["PerTimeID"] != DBNull.Value)
                    {
                        string PerTimeID = r["PerTimeID"].ToString();
                        if (PerTimeID == "1")
                        {
                            e.Value = "Nghỉ sáng";
                        }
                        else if (PerTimeID == "2")
                        {
                            e.Value = "Nghỉ chiều";
                        }
                        else if (PerTimeID == "3")
                        {
                            e.Value = "Nghỉ cả ngày";
                        }
                    }
                }
                else if (e.Column == colLyDoNghi) // Cột lý do nghỉ
                {
                    if (r["LeaveID"] != DBNull.Value)
                    {
                        e.Value = r["LeaveID"].ToString();
                    }
                }
            }
        }

        private void grv_ShowingEditor(object sender, CancelEventArgs e)
        {
            var r = grv.GetFocusedDataRow();
            if (r == null)
                return;

            e.Cancel = ((r["isLocked"] as bool?) == true);
        }

        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            int count = grv.GetSelectedRows().Count();
            if (e.KeyCode == Keys.Delete && count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                if (MessageBox.Show("Xác nhận xóa dữ liệu và không cần bấm nút lưu?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                int[] rc = grv.GetSelectedRows();
                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        if (IsLock.IsLock.Check_IsLock("tbKetQuaQuetThe_Fake", Convert.ToDateTime(r["ngay"].ToString())))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        grv.DeleteRow(rc[i - 1]);
                    }
                }

                Provider.UpdateData(ds, ds.tbKetQuaQuetThe_Fake.TableName);
                GUIHelper.Notifications("Xóa thành công " + count + " records", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
                ds.tbKetQuaQuetThe_Fake.AcceptChanges();
                if (_lActionClass.Count > 0)
                {
                    LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();
                }
                LoadData();
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grd.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }

        private void grv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "ngay").ToString()))
            {
                try
                {
                    DateTime d = Convert.ToDateTime(grv.GetRowCellValue(e.RowHandle, "ngay"));
                    if (d.DayOfWeek == DayOfWeek.Sunday)
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void grv_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == colXemFile)
            {
                FileStorageHelper fh = new FileStorageHelper();
                var a = grv.GetFocusedRowCellValue(colFile);
                var duoiFile = grv.GetFocusedRowCellValue(colDuoiFile);
                if (a != null && a.ToString() != "")
                {
                    Binary dataFile = new Binary(a as byte[]);
                    fh.DownLoadAndShowFILE(a as byte[], duoiFile.ToString());
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            List<String> _emp = new List<String>();

            _emp.Add(empID);

            Ham.report_ChamCongThang_ChiTiet_Fake(tuNgay, denNgay, _emp);
        }

        private void grv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = grv.GetDataRow(e.RowHandle);
            if (r != null && r.RowState != DataRowState.Unchanged)
            {
                if (IsLock.IsLock.Check_IsLock("tbKetQuaQuetThe_Fake", Convert.ToDateTime(r["ngay"].ToString())))
                {
                    e.ErrorText = ("Dữ liệu đã chốt công không thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
            }
            if (r != null && r.RowState == DataRowState.Unchanged)
            {
                if (IsLock.IsLock.Check_IsLock("tbKetQuaQuetThe_Fake", Convert.ToDateTime(r["ngay"].ToString())))
                {
                    e.ErrorText = ("Dữ liệu đã chốt công không thể thao tác!\n");
                    e.Valid = false;
                    return;
                }
            }
        }

        public static void ExportGrid(DevExpress.XtraGrid.GridControl grd)
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
                }

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = exportFilePath,
                    UseShellExecute = true
                });
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

        private void dlgReportMonth_Fake_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgReportMonth_Load(null, null);
            }
        }

    }
}
