using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Common.Code;
using System.Data.SqlClient;

namespace iHRM.Win.UC
{
    public partial class ChonPhongBan : UserControl
    {
        public event EventHandler OnSelected;
        public string SelectedValue
        {
            get { return treeDept.EditValue as string; }
            set { treeDept.EditValue = value; }
        }

        public tblRef_Department SelectedRow
        {
            get
            {
                return treeDept.GetSelectedDataRow() as tblRef_Department;
            }
        }

        public ChonPhongBan()
        {
            InitializeComponent();

            if (!globall.indesign)
            {
                dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
                var idKhoiPB = LoginHelper.user.idKhoiPB;
                if (idKhoiPB != null && !LoginHelper.user.isAdmin)
                {
                    var d = db.tblRef_Departments.Where(p => p.DepID == idKhoiPB.Value.ToString()).FirstOrDefault();
                    if (d != null)
                    {
                        treeDept.Properties.DataSource = db.tblRef_Departments.Where(p => p.Path.Contains(string.Format("/{0}/", d.DepID)));
                    }
                }
                else
                {
                    treeDept.Properties.DataSource = db.tblRef_Departments;
                }
                if (idKhoiPB != null)
                {
                    treeDept.EditValue = idKhoiPB.ToString();
                }
                TranslateForm();
            }
        }
        public string getPBDisplay()
        {
            return treeDept.Text;
        }

        private void treeDept_Resize(object sender, EventArgs e)
        {
            // this.Height = treeDept.Height;
        }

        private void treeDept_EditValueChanged(object sender, EventArgs e)
        {
            if (OnSelected != null)
                OnSelected(treeDept, null);
        }

        private void ChonPhongBan_Load(object sender, EventArgs e)
        {

        }

        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new SqlParameter("CtrName", nameCrt),

                           new SqlParameter("FormName", ""));
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
            string langTrans = "";
            if (Config.appConfig.language.Trim().ToUpper() == "ENGLISH")
                langTrans = "EN";
            else
                if (Config.appConfig.language.Trim().ToUpper() == "KOREAN")
                    langTrans = "KR";
                else
                    langTrans = "VN";


            treeDept.Properties.NullText = SelectTranslate(treeDept.Name, langTrans);
            treeListColumn3.Caption = SelectTranslate("treeDeptID", langTrans);
            treeListColumn5.Caption = SelectTranslate("treeDeptName", langTrans);
        }

    }
}
