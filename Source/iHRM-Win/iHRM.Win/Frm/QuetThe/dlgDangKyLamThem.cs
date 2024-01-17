
using System.Collections.Generic;
using System.Windows.Forms;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;
using DevExpress.XtraEditors;
using System.Reflection;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgDangKyLamThem : dlgCustomBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        string FilesChoised = "";

        public dlgDangKyLamThem()
        {
            InitializeComponent();
        }
        public void dlgDangKyCaLam_Load(object sender, EventArgs e)
        {
            TranslateForm();
            txtTuNgay.EditValue = txtDenNgay.EditValue = DateTime.Today;

            txtCaLam.Properties.DataSource = Provider.ExecuteDataTableReader("p_getCaLamByDepID"
                                                                            , new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));

            cmbLoaiLamThem.Properties.DataSource = db.tbLoaiNgayLamThems;

            panel2.Enabled = false;

            this.Form_Title = SelectTranslate("dlgDangKyLamThem_Title", LoginHelper.langTrans);

            this.Form_Description = SelectTranslate("dlgDangKyLamThem_Des", LoginHelper.langTrans);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isChoiseFile = FilesChoised == "" ? false : true;

            byte[] datafileChoised = null;

            string mnv = string.Empty;

            string duoiFile = "";

            TimeSpan CaSang_TuGio = txtCaSangTuGio.TimeSpan;

            TimeSpan CaSang_DenGio = txtCaSangDenGio.TimeSpan;

            TimeSpan CaChieu_TuGio = txtCaChieuTuGio.TimeSpan;

            TimeSpan CaChieu_DenGio = txtCaChieuDenGio.TimeSpan;

            bool isCaDem = chkisCaDem.Checked;

            bool isDkTuGioDenGio = chkDangKyCaTuDong.Checked;

            if (isDkTuGioDenGio 
                && (CaSang_TuGio.TotalMinutes == 0 
                    || CaSang_DenGio.TotalMinutes == 0 
                    || CaChieu_TuGio.TotalMinutes == 0 
                    || CaChieu_DenGio.TotalMinutes == 0))
            {
                if (!GUIHelper.ConfirmBox("Thời gian tự động có 00:00. Bạn có chắc chắn muốn đăng ký"))
                {
                    return;
                }
            }

            if (cmbLoaiLamThem.EditValue == null)
            {
                GUIHelper.MessageError("Bạn chưa chọn loại ngày làm thêm.");

                return;
            }
            if (txtLyDo.Text == "" 
                && cmbLoaiLamThem.EditValue.ToString() != "1" 
                && cmbLoaiLamThem.EditValue.ToString() != "0")
            {
                if (txtLyDo.Enabled)
                {
                    MessageBox.Show("Bạn chưa nhập số QĐ để đăng ký", "Đăng ký làm thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            if (isChoiseFile)
            {
                try
                {
                    datafileChoised = System.IO.File.ReadAllBytes(FilesChoised);

                    duoiFile = Path.GetExtension(FilesChoised);
                }
                catch (Exception)
                {
                    GUIHelper.MessageError("File đính kèm không hợp lệ.");

                    return;
                }
            }
            else
            {
                if (cmbLoaiLamThem.EditValue.ToString() != "1" && cmbLoaiLamThem.EditValue.ToString() != "0")
                {
                    MessageBox.Show("Bạn chưa chọn file đính kèm"
                                    , "Đăng ký làm thêm"
                                    , MessageBoxButtons.OK
                                    , MessageBoxIcon.Error);

                    return;
                }
            }

            List<string> _lEmp = new List<string>();

            _lEmp = ucChonDoiTuong_DS1.GetValue();

            if ( _lEmp.Count <= 0 )
            {
                MessageBox.Show("Bạn chưa chọn hoặc đối tượng đăng ký sai"
                                , "Đăng ký làm thêm"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);
                return;
            }

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            btnSave.Enabled = false;

            dw_it.OnDoing = (s, ev) =>
            {
                var dbFiles = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

                DateTime tuNgay = txtTuNgay.DateTime;

                DateTime denNgay = txtDenNgay.DateTime;

                Guid idCaLam = (Guid)txtCaLam.EditValue;

                int hsLuong = Convert.ToInt16(cmbHeSoLuong.Text);

                var count_day = (denNgay - tuNgay).TotalDays;

                if (count_day < 0)
                {
                    dw_it.bw.ReportProgress(1, "Từ ngày nhỏ hơn đến ngày!\n");

                    return;
                }

                //string WeekHoliday = "," + iHRM.Core.Business.Logic.AllLogic.SysPa_Get("WeekHoliday") + ",";

                int rowAffect = 0;

                //string msg = "";

                dw_it.bw.ReportProgress(1, "Đang đăng ký..");

                dw_it.bw.ReportProgress(0, _lEmp.Count);

                DateTime d;

                int count = 0;

                foreach (string empID in _lEmp)
                {
                    count++;

                    dw_it.bw.ReportProgress(3, count); //report progress

                    if (!AllLogic.checkEmployeeIDInDep(empID, LoginHelper.user.idKhoiPB))
                    {
                        dw_it.bw.ReportProgress(2, string.Format("Mã nhân viên: {0} không nằm trong phòng ban của bạn.\n", empID));

                        continue;
                    }

                    for (int i = 0; i <= count_day; i++)
                    {
                        dw_it.bw.ReportProgress(1, "Đang đăng ký nhân viên " + empID);

                        d = tuNgay.AddDays(i);

                        Core.Business.Base.ExecuteResult ii = null;

                        //if (IsLock.IsLock.Check_IsLock("tbDangKyCaLam1", d))
                        //{
                        //    dw_it.bw.ReportProgress(1, string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} không thể thao tác!\n", d));
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tbDangKyCaLam1", d,1))
                        {
                            dw_it.bw.ReportProgress(2, string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} không thể thao tác!\r\n", d));

                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tbDangKyCaLam1", d, 2))
                        {
                            dw_it.bw.ReportProgress(2, string.Format("Dữ liệu đã chốt đăng ký mới ngày {0:dd/MM/yyyy} không thể thao tác!\r\n", d));
                            
                            continue;
                        }

                        if (AllLogic.checkDkLamThem_KhoaDK(empID, d))
                        {
                            dw_it.bw.ReportProgress(2, string.Format("Dữ liệu đã chốt công bên đăng ký ca làm ngày {0:dd/MM/yyyy} không thể thao tác!\r\n", d));
                            
                            continue;
                        }
                        if (IsLock.IsLock.Check_DangKyCaLam(empID, d))
                        {
                            dw_it.bw.ReportProgress(2, string.Format("Dữ liệu đã chốt ca làm/ làm thêm ngày {0:dd/MM/yyyy} khổng thể thao tác!\r\n", d));
                           
                            continue;
                        }

                        if (IsLock.IsLock.Check_IsdkCaLam(empID, d))
                        {
                            dw_it.bw.ReportProgress(2, string.Format("NV {1} ngày {0:dd/MM/yyyy} đã đăng ký bên ca làm!\n Vui lòng xóa ca làm để đăng ký làm thêm.\r\n", d, empID));
                            
                            continue;
                        }

                        if (isDkTuGioDenGio)
                        {
                            ii = logic.DangKyCaLam(empID
                                                    , d
                                                    , idCaLam
                                                    , Convert.ToInt32(cmbLoaiLamThem.EditValue)
                                                    , hsLuong
                                                    , LoginHelper.user.id
                                                    , txtLyDo.Text
                                                    , datafileChoised
                                                    , duoiFile
                                                    , isDkTuGioDenGio
                                                    , isCaDem
                                                    , CaSang_TuGio
                                                    , CaSang_DenGio
                                                    , CaChieu_TuGio
                                                    , CaChieu_DenGio
                                                    , (double)numericSoTiengTinhCa.Value);

                            LogAction.LogAction.PushLog("Đăng ký"
                                , empID
                                , ""
                                , string.Format("Đăng ký làm thêm từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}, Loại làm thêm: {2}, idCaLam: {3}, SQĐ: {4}"
                                                , txtTuNgay.DateTime
                                                , txtDenNgay.DateTime
                                                , cmbLoaiLamThem.EditValue
                                                , idCaLam
                                                , txtLyDo.Text)
                                , "tbDangKyCaLam");
                        }
                        else
                        {
                            ii = logic.DangKyCaLam(empID
                                                    , d
                                                    , idCaLam
                                                    , Convert.ToInt32(cmbLoaiLamThem.EditValue)
                                                    , hsLuong
                                                    , LoginHelper.user.id
                                                    , txtLyDo.Text
                                                    , datafileChoised
                                                    , duoiFile);

                            LogAction.LogAction.PushLog("Đăng ký"
                                , empID
                                , ""
                                , string.Format("Đăng ký làm thêm từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}, Loại làm thêm: {2}, idCaLam: {3}, SQĐ: {4}"
                                                , txtTuNgay.DateTime
                                                , txtDenNgay.DateTime
                                                , cmbLoaiLamThem.EditValue
                                                , idCaLam
                                                , txtLyDo.Text)
                                , "tbDangKyCaLam");
                        }
                        if (ii != null)
                        {
                            rowAffect += ii.NumberOfRowAffected < 0 ? 0 : (int)((float)ii.NumberOfRowAffected / 2 + 0.5);
                        }

                        dw_it.bw.ReportProgress(2, "Đăng ký thành công nhân viên " + empID + "\r\n");
                    }
                }

                dw_it.bw.ReportProgress(1, string.Format("Đăng ký thành công {0} record!", rowAffect)); //report progress  
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 0)
                {
                    ucProgress1.start(0, (int)data.UserState);
                }
                else if (data.ProgressPercentage == 1)
                {
                    ucProgress1.Status = data.UserState.ToString();
                }
                else if (data.ProgressPercentage == 2)
                {
                    ucProgress1.Message = ucProgress1.Message + "\r\n" + data.UserState;
                }
                else if (data.ProgressPercentage == 3)
                {
                    ucProgress1.CurrentValue = (int)data.UserState;
                }
            };
            dw_it.OnCompleting = (ps, obj) =>
            {
                btnSave.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it); //reg and run progress
        }
        private void txtTuNgay_Leave(object sender, EventArgs e)
        {
            txtDenNgay.DateTime = txtTuNgay.DateTime;
        }
        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }
        private void btnFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) //Chọn file
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
                    FilesChoised = od.FileNames[0];

                    btnFile.Text = string.Format(FilesChoised);
                }
            }
            else //Hủy file
            {
                btnFile.Text = "";

                FilesChoised = "";
            }
        }

        private void txtCaLam_EditValueChanged(object sender, EventArgs e)
        {
            setEnablePanel();
        }
        private void setEnablePanel()
        {
            if (txtCaLam.EditValue.ToString().ToUpper() == "BE478C1D-7450-44AB-9EA3-F537122A913C")
            {
                panel2.Enabled = true;

                chkDangKyCaTuDong.Checked = true;
            }
            else
            {
                panel2.Enabled = false;

                chkDangKyCaTuDong.Checked = false;

                txtCaSangTuGio.EditValue = "00:00:00";

                txtCaSangDenGio.EditValue = "00:00:00";

                txtCaChieuTuGio.EditValue = "00:00:00";

                txtCaChieuDenGio.EditValue = "00:00:00";
            }
        }
        private void chkDangKyCaTuDong_CheckedChanged(object sender, EventArgs e)
        {
            setEnablePanel();
        }

        private void txtCaSangTuGio_EditValueChanged(object sender, EventArgs e)
        {
            setTgTinhCa();
        }

        private void txtCaChieuDenGio_EditValueChanged(object sender, EventArgs e)
        {
            setTgTinhCa();
        }
        private void txtCaSangDenGio_EditValueChanged(object sender, EventArgs e)
        {
            setTgTinhCa();
        }

        private void txtCaChieuTuGio_EditValueChanged(object sender, EventArgs e)
        {
            setTgTinhCa();
        }
        private void setTgTinhCa()
        {
            TimeSpan caSang_TuGio = txtCaSangTuGio.TimeSpan;

            TimeSpan caSang_DenGio = txtCaSangDenGio.TimeSpan;

            TimeSpan caChieu_TuGio = txtCaChieuTuGio.TimeSpan;

            TimeSpan caChieu_DenGio = txtCaChieuDenGio.TimeSpan;

            if (caSang_TuGio > caSang_DenGio)
            {
                caSang_DenGio = caSang_DenGio.Add(new TimeSpan(24, 0, 0));
            }
            if (caChieu_TuGio > caChieu_DenGio)
            {
                caChieu_DenGio = caChieu_DenGio.Add(new TimeSpan(24, 0, 0));
            }

            double a = Math.Round(((caSang_DenGio - caSang_TuGio).TotalMinutes + (caChieu_DenGio - caChieu_TuGio).TotalMinutes) / (double)60, 3);

            numericSoTiengTinhCa.Value = (decimal)a;
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
            cmbLoaiLamThem.Properties.Columns[0].Caption = SelectTranslate("dlgDangKyLamThem_CalamID", langTrans);
            cmbLoaiLamThem.Properties.Columns[1].Caption = SelectTranslate("dlgDangKyLamThem_CalamTen", langTrans);

            #endregion
        }

        #endregion

        private void dlgDangKyLamThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgDangKyCaLam_Load(null, null);
            }
        }


    }
}
