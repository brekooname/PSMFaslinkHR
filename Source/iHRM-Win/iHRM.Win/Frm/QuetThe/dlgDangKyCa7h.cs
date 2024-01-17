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

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgDangKyCa7h : dlgCustomBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        public int _flag = 0;

        public DataRow _CRow;

        private String _EmpID = "";

        public dlgDangKyCa7h()
        {
            InitializeComponent();
        }
        private void dlgDangKyCa7h_Load(object sender, EventArgs e)
        {
            TranslateForm();
            dateBegin.EditValue = dateEnd.EditValue = DateTime.Today;

            //this.Form_Title = SelectTranslate("dlgDangKyCaLam", LoginHelper.langTrans);

            //this.Form_Description = SelectTranslate("dlgDangKyCaLam_des", LoginHelper.langTrans);

            if (_flag == 0) //Load Dialog thêm//
            {
                dateBegin.Enabled = true;

                ucChonDoiTuong_DS1.Enabled = true;
            }
            else //Load Dialog cập nhật//
            {
                dateBegin.Enabled = false;

                ucChonDoiTuong_DS1.Enabled = false;

                InitUpdate();
                //---//

            }

        }

        public bool CheckNull(DevExpress.XtraEditors.BaseEdit _control)
        {
            if (_control.EditValue == null || String.IsNullOrEmpty(_control.ToString())) return true;
            if (_control.EditValue == null || _control.EditValue == "") return true;

            return false;
        }

        public void InitUpdate()
        {
            //Đổ dữ liệu vào Edit Control//

            var _dateBegin = DbHelper.DrGet(_CRow, "BeginDate") != null ? DbHelper.DrGet(_CRow, "BeginDate") : "";

            var _dateEnd = DbHelper.DrGet(_CRow, "EndDate") != null ? DbHelper.DrGet(_CRow, "EndDate") : "";

            var _dateChild = DbHelper.DrGet(_CRow, "ChildDate") != null ? DbHelper.DrGet(_CRow, "ChildDate") : "";

            var _chkisLate = DbHelper.DrGet(_CRow, "isLate") != null ? DbHelper.DrGet(_CRow, "isLate") : "";

            _EmpID = DbHelper.DrGet(_CRow, "EmployeeID") != null ? DbHelper.DrGet(_CRow, "EmployeeID").ToString() : "";

            ucChonDoiTuong_DS1.SetValue_TextBox(_EmpID);

            dateBegin.EditValue = _dateBegin;

            dateEnd.EditValue = _dateEnd;

            dateChild.EditValue = _dateChild;

            chkisLate.EditValue = _chkisLate;

            //---//
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> _lEmp = new List<string>();

            _lEmp = ucChonDoiTuong_DS1.GetValue();

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            if (CheckNull(dateBegin))
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày bắt đầu!");

                return;
            }

            if (CheckNull(dateEnd))
            {
                GUIHelper.MessageBox("Vui lòng chọn ngày kết thúc!");

                return;
            }

            DateTime tuNgay = dateBegin.DateTime;

            DateTime denNgay = dateEnd.DateTime;

            int isLate = 0;

            var count_day = (denNgay - tuNgay).TotalDays;

            if (count_day <= 0)
            {
                GUIHelper.MessageBox("Ngày bắt đầu không nhỏ hơn ngày kết thúc!\r\n");

                return;
            }

            dw_it.OnDoing = (s, ev) =>
            {
                if(chkisLate.Checked)
                {
                    isLate = 1;
                }
                else
                {
                    isLate = 0;
                }

                int rowAffect = 0;

                dw_it.bw.ReportProgress(1, "Đang đăng ký..");

                dw_it.bw.ReportProgress(0, _lEmp.Count);

                int count = 0;

                foreach (string empID in _lEmp)
                {
                    count++;

                    dw_it.bw.ReportProgress(3, count); //report progress

                    dw_it.bw.ReportProgress(1, "Đang đăng ký nhân viên " + empID);

                    btnSave.Enabled = false;

                    Core.Business.Base.ExecuteResult ii = null;

                    if (!AllLogic.checkEmployeeIDInDep(empID, LoginHelper.user.idKhoiPB))
                    {
                        dw_it.bw.ReportProgress(1, string.Format("Mã nhân viên: {0} không nằm trong phòng ban của bạn.\r\n", empID));

                        continue;
                    }

                    if (IsLock.IsLock.Check_IsLock("tblEmp7hours", tuNgay))
                    {
                        dw_it.bw.ReportProgress(1, string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} khổng thể thao tác!", tuNgay));
                        continue;
                    }

                    if(CheckNull(dateChild))
                    {
                        ii = logic.DangKyCaLam7Hours(empID
                                                , DateTime.Now
                                                , tuNgay
                                                , denNgay
                                                , isLate);
                    }
                    else
                    {
                        ii = logic.DangKyCaLam7Hours(empID
                                                , DateTime.Now
                                                , tuNgay
                                                , denNgay
                                                , isLate
                                                , dateChild.DateTime);
                    }

                    if (ii != null)
                    {
                        LogAction.LogAction.PushLog("Đăng ký ca làm 7h"
                                                    , empID
                                                    , ""
                                                    , string.Format("Đăng ký ca làm 7h từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}, ngày đăng ký {2}"
                                                                    , dateBegin.DateTime
                                                                    , dateEnd.DateTime
                                                                    , DateTime.Now.Date)
                                                    , "tblEmp7hours");


                        rowAffect += ii.NumberOfRowAffected < 0 ? 0 : (int)((float)ii.NumberOfRowAffected / 2 + 0.5);

                        dw_it.bw.ReportProgress(2, "Đăng ký ca làm 7 giờ thành công nhân viên " + empID + "\r\n");
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
            dateEnd.DateTime = dateBegin.DateTime;
        }
        private void btnDangKyExcel_Click(object sender, EventArgs e)
        {
            impDKCaLam frm = new impDKCaLam();

            frm.ShowDialog();
        }
        private void dlgDangKyCa7h_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;

            this.Hide();
        }

        private void btnDangKyDA_Click(object sender, EventArgs e)
        {
            impDKCaLam_New frm = new impDKCaLam_New();

            frm.ShowDialog();
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
            //string formText = SelectTranslate(this.Name, langTrans);
            //if (formText != "")
            //{
            //    this.Text = formText;
            //}
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
            myData.Add(this.Name, this.Text);
            listCtr.Add(this.Name);


            #endregion
        }

        #endregion

        private void dlgDangKyCa7h_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                dlgDangKyCa7h_Load(null, null);
            }
        }

    }
}
