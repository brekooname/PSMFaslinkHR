using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Frm;

namespace iHRM.Win.UC
{
    public partial class ucChonDoiTuong_DS : UserControl
    {
        public ucChonDoiTuong_DS()
        {
            InitializeComponent();
        }
        public List<string> GetValue()
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            List<string> _lStr = new List<string>();
            bool isOK = false;

            try
            {
                if (LoginHelper.user.isAdmin || LoginHelper.user.idKhoiPB == null)
                {
                    isOK = true;
                }
                if (rdLoaiDK.SelectedIndex == 0)
                {
                    string str = mmMaNV.Text.ToUpper().Trim();
                    foreach (string item in str.Split(','))
                    {
                        string maNV = item.Trim();
                        if (maNV != "")
                        {
                            _lStr.Add(maNV);
                        }
                    }
                }
                else if (rdLoaiDK.SelectedIndex == 1)
                {
                    if (checkEdit1.Checked)
                    {
                        if (txtMaNV.Text.Trim() != "")
                        {
                            _lStr.Add(txtMaNV.Text);
                        }
                    }
                    else if (checkEdit2.Checked)
                    {
                        string str = chonPhongBan1.SelectedValue;
                        var a1 = db.tblRef_Departments.Where(p => p.DepID == str).FirstOrDefault();
                        string PathOfStr = "";
                        if (a1 == null) // Nếu chưa chọn phòng ban -> Return.
                        {
                            return _lStr;
                        }
                        PathOfStr = a1.Path;
                        _lStr = (from e in db.tblEmployees
                                 join p in db.tblRef_Departments on e.DepID_Final equals p.DepID
                                 select new
                                 {
                                     e.EmployeeID,
                                     p.Path
                                 }).ToList().Where(p => p.Path.Contains(PathOfStr)).Select(p => p.EmployeeID).ToList<string>();
                        isOK = true;
                    }
                    else if (checkEdit3.Checked)
                    {
                        _lStr = db.tblEmployees.Where(p => p.InGroup1 != null && p.InGroup1.Value == (int)cboSearchNhom.EditValue).Select(p => p.EmployeeID).ToList<string>();
                    }
                }
                if (!isOK)
                {
                    List<string> _lTemp = _lStr;
                    _lStr = (from e in _lTemp
                             join e1 in db.tblEmployees on e equals e1.EmployeeID
                             join d in db.tblRef_Departments on e1.DepID_Final equals d.DepID
                             where d.Path.Contains(string.Format("/{0}/", LoginHelper.user.idKhoiPB))
                             select e1.EmployeeID).ToList();
                }
                return _lStr;
            }
            catch (Exception)
            {
                List<string> _lStrerr = new List<string>();
                return _lStrerr;
            }

            
        }

        public void SetValue_TextBox(String _String)
        {
            mmMaNV.Text = _String;
        }


        public int radioSelected
        {
            get
            {
                return rdLoaiDK.SelectedIndex;
            }
            set
            {
                rdLoaiDK.SelectedIndex = value;
            }
        }
        private void ucChonDoiTuong_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                checkEdit1.Checked = true;
                cboSearchNhom.Properties.DataSource = Cls.CacheDataTable.GetCacheDataTable(TableConst.tblEmp_Group1.TableName);
                var dt = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));
                cboSearchTen.Properties.DataSource = dt;
                cboSearchTen.Properties.DisplayMember = "EmployeeName";
                cboSearchTen.Properties.ValueMember = "EmployeeCode";

                //// Dùng để tự chọn phòng ban khi load Jun add 03/09/2020
                //if (LoginHelper.user.idKhoiPB >= 1)
                //{
                //    rdLoaiDK.SelectedIndex = 1;
                //    checkEdit2.Checked = true;
                //    chonPhongBan1.SelectedValue = LoginHelper.user.idKhoiPB.ToString();
                //}

                TranslateForm();
            }
        }

        public void txtMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
                var dr = logic.checkNV(txtMaNV.Text);
                if (dr == null)
                {
                    txtMaNV.Text = "";
                }
                else
                {
                    txtMaNV.Text = DbHelper.DrGetString(dr, "EmployeeID");
                    string s = string.Format("{0}", DbHelper.DrGet(dr, "EmployeeID"));
                    cboSearchTen.EditValue = s;

                    checkEdit1.Checked = true;
                }
            }
        }

        private void chonPhongBan1_OnSelected(object sender, EventArgs e)
        {
            checkEdit2.Checked = true;
        }
        public string getKhoiPBDisPlay()
        {
            if (rdLoaiDK.SelectedIndex == 0)
            {
                return "";
            }
            else if (rdLoaiDK.SelectedIndex == 1)
            {
                if (checkEdit1.Checked)
                {
                    return "";
                }
                else if (checkEdit2.Checked)
                {
                    return chonPhongBan1.getPBDisplay();
                }
                else if (checkEdit3.Checked)
                {
                    return "";
                }
            }
            return "";
        }

        public string getKhoiPBvalue()
        {
            if (rdLoaiDK.SelectedIndex == 0)
            {
                return "";
            }
            else if (rdLoaiDK.SelectedIndex == 1)
            {
                if (checkEdit1.Checked)
                {
                    return "";
                }
                else if (checkEdit2.Checked)
                {
                    return chonPhongBan1.SelectedRow.DepID;
                }
                else if (checkEdit3.Checked)
                {
                    return "";
                }
            }
            return "";
        }

        private void btnDSNV_Click(object sender, EventArgs e)
        {
            dlgChonNV dlgEditor = new dlgChonNV();

            if (dlgEditor.ShowDialog() == DialogResult.OK)
            {
                if (dlgEditor.MyValue.Count() == 0)
                {
                    return;
                }
                var newLst = new List<tblEmployee>();
                foreach (var it in dlgEditor.MyValue)
                {
                        newLst.Add(it);
                }

                mmMaNV.Text = string.Join(",", newLst.Select(i => i.EmployeeID));

            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            checkEdit3.Checked = true;
        }

        private void rdLoaiDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdLoaiDK.SelectedIndex == 1)
            {
                panelDanhSach.Visible = false;
                panelCheck.Visible = true;
            }
            else
            {
                panelDanhSach.Visible = true;
                panelCheck.Visible = false;
            }
        }

        private void cboSearchTen_EditValueChanged(object sender, EventArgs e)
        {
            txtMaNV.Text = (string)cboSearchTen.EditValue;
            checkEdit1.Checked = true;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                chonPhongBan1.SelectedValue = null;
                chonPhongBan1.Enabled = false;

                cboSearchNhom.EditValue = null;
                cboSearchNhom.Enabled = false;
                
                txtMaNV.Enabled = cboSearchTen.Enabled = true;
            }
            if (checkEdit2.Checked)
            {

                chonPhongBan1.Enabled = true;

                cboSearchNhom.EditValue = null;
                cboSearchNhom.Enabled = false;

                txtMaNV.Enabled = cboSearchTen.Enabled = false;
                txtMaNV.Text = string.Empty;
                cboSearchTen.EditValue = null;
            }

            if (checkEdit3.Checked)
            {
                cboSearchNhom.Enabled = true;

                chonPhongBan1.SelectedValue = null;
                chonPhongBan1.Enabled = false;

                txtMaNV.Enabled = cboSearchTen.Enabled = false;
                txtMaNV.Text = string.Empty;
                cboSearchTen.EditValue = null;
            }

        }

        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet dsTrans = Provider.ExecuteDataSetReader("p_Translate",

                           new System.Data.SqlClient.SqlParameter("CtrName", nameCrt),

                           new System.Data.SqlClient.SqlParameter("FormName", ""));
            if (dsTrans.Tables[0].Rows.Count > 0)
            {
                //có dữ liệu cho dùng chung
                if (dsTrans.Tables[1].Rows.Count == 0)
                {
                    //không dùng riêng
                    return dsTrans.Tables[0].Rows[0][lang].ToString().Trim();

                }
                else
                {
                    // có dùng riêng 
                    return dsTrans.Tables[1].Rows[0][lang].ToString().Trim();
                }
            }
            else
            {
                return "";
            }

        }

        public void TranslateForm()
        {
            string langTrans = "";
            if (Config.appConfig.language.Trim().ToUpper() == "ENGLISH")
                langTrans = "EN";
            else
                if (Config.appConfig.language.Trim().ToUpper() == "KOREAN")
                    langTrans = "KR";
                else
                    langTrans = "VN";

            rdLoaiDK.Properties.Items[0].Description = SelectTranslate("rdLoaiDK1", langTrans);
            rdLoaiDK.Properties.Items[1].Description = SelectTranslate("rdLoaiDK2", langTrans);
            checkEdit1.Text = SelectTranslate("checkEditNV", langTrans);
            checkEdit2.Text = SelectTranslate("checkEditPB", langTrans);
            checkEdit3.Text = SelectTranslate("checkEditNhomNV", langTrans);
            groupDSNV.Text = SelectTranslate(groupDSNV.Name, langTrans);
            cboSearchNhom.Properties.NullText = SelectTranslate(cboSearchNhom.Name, langTrans);
            cboSearchTen.Properties.NullText = SelectTranslate(cboSearchTen.Name, langTrans);
            EmployeeCode.Caption = SelectTranslate(EmployeeCode.Name, langTrans);
            EmployeeName.Caption = SelectTranslate(EmployeeName.Name, langTrans);
            DepName_Final.Caption = SelectTranslate(DepName_Final.Name, langTrans);
            cboSearchNhom.Properties.Columns[0].Caption = SelectTranslate("cboSearchNhom0", langTrans);
        }




    }
}
