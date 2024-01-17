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
using System.Reflection;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgRequestOutInShift : dlgCustomBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        string FilesChoised = "";

        public dlgRequestOutInShift()
        {
            InitializeComponent();
        }

        private void dlgRequestOutInShift_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;

            this.Hide();
        }

        private void dlgRequestOutInShift_Load(object sender, EventArgs e)
        {

            TranslateForm();
           
            dateNgay.EditValue = DateTime.Now.Date;

            cbbLoaiRaVao.Properties.DataSource = db.tblRef_OutInShiftTypes;

            this.Form_Title = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "dlgRequestOutInShift_Title")).Tables[0].Rows[0][LoginHelper.langTrans].ToString();

            this.Form_Description = Provider.ExecuteDataSetReader("p_Translate", new System.Data.SqlClient.SqlParameter("CtrName", "dlgRequestOutInShift_Description")).Tables[0].Rows[0][LoginHelper.langTrans].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isChoiseFile = FilesChoised == "" ? false : true;

            byte[] datafileChoised = null;

            string mnv = string.Empty;

            string duoiFile = "";

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

            if (dateNgay.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn ngày đăng ký!", "Đăng ký ra vào"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);

                return;
            }

            if (String.IsNullOrWhiteSpace(txtTuGio.Text) || String.IsNullOrWhiteSpace(txtDenGio.Text))
            {
                MessageBox.Show("Vui lòng nhập giờ đăng ký!", "Đăng ký ra vào"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);

                return;
            }


            if (cbbLoaiRaVao.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn loại đăng ký", "Đăng ký ra vào"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);

                return;
            }

            List<string> _lEmp = new List<string>();

            _lEmp = ucChonDoiTuong_DS1.GetValue();

            if (_lEmp.Count <= 0)
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

                int rowAffect = 0;

                dw_it.bw.ReportProgress(1, "Đang đăng ký..");

                dw_it.bw.ReportProgress(0, _lEmp.Count);

                DateTime _day = dateNgay.DateTime.Date;

                DateTime _dayNow = DateTime.Now;

                int count = 0;

                int _i = 0;

                foreach (string empID in _lEmp)
                {
                    count++;

                    dw_it.bw.ReportProgress(3, count); //report progress

                    Core.Business.Base.ExecuteResult ii = null;

                    if (!AllLogic.checkEmployeeIDInDep(empID, LoginHelper.user.idKhoiPB))
                    {
                        dw_it.bw.ReportProgress(2, string.Format("Mã nhân viên: {0} không nằm trong phòng ban của bạn.\n", empID));

                        continue;
                    }

                    if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", _day, 1))
                    {
                        dw_it.bw.ReportProgress(2, string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} khổng thể thao tác!\r\n", _day));
                        continue;
                    }
                    if (IsLock.IsLock.Check_IsLock_Type("tbRequestOutInShift", _day, 2))
                    {
                        dw_it.bw.ReportProgress(2, string.Format("Dữ liệu đã chốt đăng ký mới ngày {0:dd/MM/yyyy} khổng thể thao tác!\r\n", _day));
                        continue;
                    }

                    //if (IsLock.IsLock.Check_DangKyTangCa(empID, _day))
                    //{
                    //    dw_it.bw.ReportProgress(2, string.Format("Dữ liệu đã chốt đăng ký {0:dd/MM/yyyy} khổng thể thao tác!\r\n", _day));

                    //    continue;
                    //}

                    ii = logic.DangKyRaVao(empID
                        , _day
                        , _dayNow
                        , TimeSpan.Parse(txtTuGio.Text.ToString())
                        , TimeSpan.Parse(txtDenGio.Text.ToString())
                        , LoginHelper.user.id
                        , cbbLoaiRaVao.EditValue as String
                        , txtGhiChu.Text
                        , datafileChoised
                        , duoiFile);

                    if(ii != null)
                    {
                        LogAction.LogAction.PushLog("Đăng ký ra vào "
                            , empID
                            , ""
                            , string.Format("Đăng ký ra vào từ giờ: {0} - đến giờ: {1} - ngày: {2:dd/MM/yyyy}"
                                            , txtTuGio.Text.ToString()
                                            , txtDenGio.Text.ToString()
                                            , _day)
                            , "tbRequestOutInShift");


                        rowAffect += ii.NumberOfRowAffected < 0 ? 0 : (int)((float)ii.NumberOfRowAffected / 2 + 0.5);

                        _i++;

                        dw_it.bw.ReportProgress(2, "Đăng ký thành công nhân viên " + empID + "\r\n");
                    }
                    
                }

                dw_it.bw.ReportProgress(1, string.Format("Đăng ký thành công {0} record!", _i)); //report progress  
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


        private void dlgRequestOutInShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch 
                
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgRequestOutInShift_Load(null, null);

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