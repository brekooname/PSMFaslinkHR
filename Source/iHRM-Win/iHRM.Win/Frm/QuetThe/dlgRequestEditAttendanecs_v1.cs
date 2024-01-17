using System.Windows.Forms;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using iHRM.Core.FileDB;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;

namespace iHRM.Win.Frm.QuetThe
{
    /// <summary>
    /// Thông Liêu: '19-12-2018'
    /// </summary>
    /// <returns></returns>
    public partial class dlgRequestEditAttendanecs_v1 : dlgCustomBase
    {
        //Khởi tạo//
        dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        dcDatabaseFilesDataContext _dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

        List<ActionClass> _listActionClass = new List<ActionClass>();

        DataTable _dt;

        public int _flag = 0;

        public DataRow _CRow;
        //---//

        public dlgRequestEditAttendanecs_v1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;

            _dt = new DataTable();

            _dt = Provider.ExecuteDataTable("p_getRequestEditAttendane_ByDep",
                                            new SqlParameter("@ngay", dateNgayYC.EditValue),
                                            Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue())
            );

            _dt.Columns.Add("idFileDelete");

            grd.DataSource = _dt;

            btnSearch.Enabled = true;

            _listActionClass.Clear();
        }

        private void dlgRequestEditAttendanecs_v1_Load(object sender, EventArgs e)
        {


            this.Form_Title = SelectTranslate("dlgRequestEditAttendanecs_v1_title", LoginHelper.langTrans);
            this.Form_Description = SelectTranslate("dlgRequestEditAttendanecs_v1_Description", LoginHelper.langTrans);
            layoutControlItem4.Text = SelectTranslate("dlgRequestEditAttendanecs_v1_Date", LoginHelper.langTrans);
            TranlateForm();

            dateNgayYC.DateTime = DateTime.Now.Date;

            btnSearch_Click(null, null);
        }

        private void grv_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value != null)
            {
                grv.SelectRow(e.RowHandle);
            }
            else
            {
                grv.UnselectRow(e.RowHandle);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<DataRow> _list_dr = grv.GetSelectedRows().Select(x => grv.GetDataRow(x) as DataRow).ToList();

            if (_list_dr.Count == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                return;
            }

            dcDatabaseFilesDataContext dbFile = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

            var count = _list_dr.Count;

            DateTime ngay = DateTime.Now;

            try
            {
                foreach (DataRow dr in _list_dr)
                {
                    int _check = 0;

                    if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(dr["ngayYC"]), 1))
                    {
                        GUIHelper.MessageError(string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} khổng thể thao tác!\r\n", Convert.ToDateTime(dr["ngayYC"])));
                        return;
                    }
                    if (IsLock.IsLock.Check_IsLock_Type("tbRequestEditAttendane", Convert.ToDateTime(dr["ngayYC"]), 2))
                    {
                        GUIHelper.MessageError(string.Format("Dữ liệu đã chốt đăng ký mới ngày {0:dd/MM/yyyy} khổng thể thao tác!\r\n", Convert.ToDateTime(dr["ngayYC"])));
                        return;
                    }
                    //if (IsLock.IsLock.Check_DangKySuaCong(dr["EmployeeName"].ToString(), Convert.ToDateTime(dr["ngayYC"])))		
                    //{		
                    //    GUIHelper.MessageError(string.Format("Dữ liệu đã chốt ca làm/ làm thêm ngày {0:dd/MM/yyyy} khổng thể thao tác!\r\n", Convert.ToDateTime(dr["ngayYC"])));		
                    //    return;		
                    //}

                    if (dr["gioVao_Request"] == DBNull.Value || dr["gioVao_Request"].ToString() == "")
                    {
                        GUIHelper.MessageError("Bạn cần phải nhập giờ vào yêu cầu nhân viên '" + dr["EmployeeName"] + "'.\n");

                        return;
                    }

                    if (dr["gioRa_Request"] == DBNull.Value || dr["gioRa_Request"].ToString() == "")
                    {
                        GUIHelper.MessageError("Bạn cần phải nhập ra yêu cầu nhân viên '" + dr["EmployeeName"] + "'.\n");

                        return;
                    }

                    if (dr["isAcceptBP"] != DBNull.Value)
                    {
                        GUIHelper.MessageError("Yêu sửa công của nhân viên '" + dr["EmployeeName"] + "' đã được duyệt không thể thao tác.\n");

                        return;
                    }

                    if (dr["isAccept"] != DBNull.Value)
                    {
                        GUIHelper.MessageError("Yêu sửa công của nhân viên '" + dr["EmployeeName"] + "' đã được chốt không thể thao tác.\n");

                        return;
                    }

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

                    if (dr["isCaDemTrongNgay"].ToString() != "")
                    {
                        if (bool.Parse(dr["isCaDemTrongNgay"].ToString()) == true)

                            _check = 1;
                    }
                    else
                        _check = 0;

                    if (AllLogic.checkDkSuaCong(dr["EmployeeID"].ToString(), Convert.ToDateTime(dr["ngayYC"]), 1))
                    {
                        tbRequestEditAttendane _tb = new tbRequestEditAttendane();

                        _tb = _db.tbRequestEditAttendanes.Where(x => x.EmployeeID == dr["EmployeeID"].ToString()
                                                                    && (DateTime.Compare(x.ngay.Date, DateTime.Parse(dr["ngayYC"].ToString()).Date) == 0)
                                                                    ).SingleOrDefault();

                        _tb.gioVao_Request = TimeSpan.Parse(dr["gioVao_Request"].ToString());

                        _tb.gioRa_Request = TimeSpan.Parse(dr["gioRa_Request"].ToString());

                        _tb.ghiChu = dr["ghiChu"] as String;

                        _tb.idFile = dr["idFile"] != null ? dr["idFile"] as Guid? : null;

                        _tb.ngay = DateTime.Parse(dr["ngayYC"].ToString()).Date;

                        _tb.isCaDemTrongNgay = _check == 1 ? true : false;

                        _db.SubmitChanges();

                        _listActionClass.Add(new ActionClass("Cập nhật dữ liệu"
                                                , dr["EmployeeID"].ToString()
                                                , ""
                                                , "Cập nhật dữ liệu yêu cầu sửa công từ "
                                                        + dr["gioVao_Request"].ToString()
                                                        + " - "
                                                        + dr["gioRa_Request"].ToString()
                                                        + String.Format(" Ngày {0:dd/MM/yyyy}", dr["ngayYC"])
                                                , "tbRequestEditAttendane"));

                    }
                    else
                    {
                        bool a = AllLogic.insert_YeuCauSuaCong(dr["EmployeeID"].ToString()
                                                                , DateTime.Parse(dr["ngayYC"].ToString()).Date
                                                                , DateTime.Now
                                                                , TimeSpan.Parse(dr["gioVao_Request"].ToString())
                                                                , TimeSpan.Parse(dr["gioRa_Request"].ToString())
                                                                , _check == 1 ? true : false
                                                                , dr["ghiChu"].ToString()
                                                                , dr["idFile"].ToString()
                                                                , LoginHelper.user.id);

                        _listActionClass.Add(new ActionClass("Thêm dữ liệu"
                                                , dr["EmployeeID"].ToString()
                                                , ""
                                                , "Thêm dữ liệu yêu cầu sửa công từ "
                                                        + dr["gioVao_Request"].ToString()
                                                        + " - "
                                                        + dr["gioRa_Request"].ToString()
                                                        + String.Format(" Ngày {0:dd/MM/yyyy}", dr["ngayYC"])
                                                , "tbRequestEditAttendane"));

                    }

                    dbFile.SubmitChanges();
                }

                LogAction.LogAction.PushLog(_listActionClass); _listActionClass.Clear();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
            }
            catch (Exception)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddFalse);
            }

            #region: Hàm 'insert_YeuCauSuaCong'
            // public static bool insert_YeuCauSuaCong(String empID, DateTime ngay, DateTime ngayYC, TimeSpan gioVao_Request, TimeSpan gioRa_Request, String ghiChu, String idFile, long? userID)
            //{
            //    if(idFile.ToString() == "" || idFile == null)
            //    {
            //        var b = Provider.ExecuteScalar("p_chamcong_tbRequestEditAttendane_v1",
            //                                    new SqlParameter("@employeeID", empID),
            //                                    new SqlParameter("@ngay", ngay),
            //                                    new SqlParameter("@ngayYeuCau", ngayYC),
            //                                    new SqlParameter("@gioVao_Request", gioVao_Request),
            //                                    new SqlParameter("@gioRa_Request", gioRa_Request),
            //                                    new SqlParameter("@ghiChu", ghiChu),
            //                                    new SqlParameter("@idFile", DBNull.Value),
            //                                    new SqlParameter("@idUserRequest", userID)
            //                                    );
            //        return b != null;
            //    }
            //    else
            //    {
            //        var b = Provider.ExecuteScalar("p_chamcong_tbRequestEditAttendane_v1",
            //                                    new SqlParameter("@employeeID", empID),
            //                                    new SqlParameter("@ngay", ngay),
            //                                    new SqlParameter("@ngayYeuCau", ngayYC),
            //                                    new SqlParameter("@gioVao_Request", gioVao_Request),
            //                                    new SqlParameter("@gioRa_Request", gioRa_Request),
            //                                    new SqlParameter("@ghiChu", ghiChu),
            //                                    new SqlParameter("@idFile", Guid.Parse(idFile)),
            //                                    new SqlParameter("@idUserRequest", userID)
            //                                    );
            //        return b != null;
            //    }
            //}
            #endregion
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
                if (dr != null)
                {
                    if (dr["isAcceptBP"] != DBNull.Value)
                    {
                        return;
                    }
                    if (dr["isHetHan"] != DBNull.Value)
                    {
                        return;
                    }

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

                        _listActionClass.Add(new ActionClass("Cập nhật"
                                                            , dr["EmployeeID"].ToString()
                                                            , ""
                                                            , "Chọn file mới"
                                                            , "tbRequestEditAttendane")); // Chưa đổi tên
                    }
                }
                else
                {
                    GUIHelper.Notifications("Không có dữ liệu để chọn", "Mở file", GUIHelper.NotifiType.error);
                }


            }
            else if (e.Button.Index == 2) // Xóa file
            {
                if (dr != null)
                {
                    if (dr["isAcceptBP"] != DBNull.Value)
                    {
                        GUIHelper.Notifications("Không thể xóa được file đã duyệt.", "Xóa file đính kèm", GUIHelper.NotifiType.error);

                        return;
                    }

                    if (dr["isHetHan"] != DBNull.Value)
                    {
                        return;
                    }

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

        private List<String> getEmpID()
        {
            List<String> _lEmpID = new List<String>();

            List<DataRow> _list_dr = grv.GetSelectedRows().Select(x => grv.GetDataRow(x) as DataRow).ToList();

            foreach (DataRow _dr in _list_dr)
            {
                _lEmpID.Add(_dr["EmployeeID"].ToString());
            }

            return _lEmpID;
        }

        private void grv_DoubleClick(object sender, EventArgs e)
        {
            dlgDuLieuQuetThe _dlg = new dlgDuLieuQuetThe();

            _dlg._maNV = grv.GetFocusedRowCellValue(colMaNV).ToString();

            _dlg._ngay = dateNgayYC.DateTime.Date;

            _dlg.ShowDialog();

            //if (getEmpID().Count == 1) //Kiểm tra Focused có dữ liệu
            //{
            //    dlgDuLieuQuetThe _dlg = new dlgDuLieuQuetThe();

            //    _dlg._listEmp = getEmpID();

            //    _dlg._ngay = dateNgayYC.DateTime.Date;

            //    _dlg.ShowDialog();
            //}
            //else
            //{
            //    GUIHelper.MessageBox("Chỉ cho phép chọn một Nhân Viên");
            //}
            
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

            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            

                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgRequestEditAttendanecs_v1_Load(null, null);


            }
        }
        #region  Dịch form
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
        private IEnumerable<SimpleButton> EnumerateSimpleButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(SimpleButton).IsAssignableFrom(field.FieldType)
                   let component = (SimpleButton)field.GetValue(this)
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

        private IEnumerable<Control> EnumerateLabelControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(LabelControl).IsAssignableFrom(field.FieldType)
                   let component = (LabelControl)field.GetValue(this)
                   where component != null
                   select component;
        }

        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new SqlParameter("CtrName", nameCrt),

                           new SqlParameter("FormName", this.Name.ToString()));
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
        public void TranlateForm()
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
            foreach (SimpleButton s in _SimpleButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (LabelControl s in _LableControl)
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