using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Translate
{
    public partial class frmTranslate : frmBase
    {
        public frmTranslate()
        {
            InitializeComponent();
        }
      
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //LST_String
        public  Dictionary<string, string> myDataControl ;
        public List<string> listCtrontrol;
        public string formName;
        public DataTable dtDC = new DataTable();
        public DataTable dtDR = new DataTable();

     

        private void frmTranslate_Load(object sender, EventArgs e)
        {

            try
            {
                //add form name vao
           

                //listCtrontrol.Add(formName.ToString().Trim());

                DataSet ds = Provider.ExecuteDataSetReader("p_Translate_All",

                    Provider.CreateParameter_StringList("DSControl", listCtrontrol),

                     new SqlParameter("FormName", formName));

               
                if(ds.Tables[0].Rows.Count>0)
                {
                    dtDC = ds.Tables[0];
                }
                else
                {
                    dtDC = ds.Tables[0].Copy();
                }
               
                if (ds.Tables[1].Rows.Count > 0)
                {
                    dtDR = ds.Tables[1];
                }
                else
                {
                    dtDR = ds.Tables[1].Copy();
                }
                //lấy list dữ liệu trên form
                var listringMyData = myDataControl.Keys.ToArray();
              
                List<string> temp = new List<string>();
                temp = dtDC.AsEnumerable()
                          .Select(r => r.Field<string>("CtrName"))
                          .ToList();
                //cũ là listControl
                var result = (from o in listringMyData
                              join p in temp on o equals p into t
                              from od in t.DefaultIfEmpty()
                              where od == null
                              select o).ToList<string>();
               
               
                for (int i = 0; i < result.Count; i++)
                {
                    DataRow dataRow = dtDC.NewRow();
                    dataRow["CtrName"] = result[i].ToString();
                   // dataRow["VN"] = myDataControl.Any(p => p.Key.Contains(result[i].ToString().Trim()));
                    dataRow["VN"] = myDataControl[result[i].ToString().Trim()];
                    dtDC.Rows.Add(dataRow);
                }
                
                grdDC.DataSource = dtDC;
                grdDR.DataSource = dtDR;


            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.ToString());
            }

        }
        private void toolStripSave_Click(object sender, EventArgs e)
        {
            //lưu vào database
            try
            {
                //get 2 table của 2 bảng
               foreach(DataRow dr in dtDC.Rows)
               {
                   if (dr["VN"].ToString().Trim() != "")
                   {
                       // insert vào database Master
                       Provider.ExecNoneQuery("p_Translate_EXEC_Master",
                       new SqlParameter("id", Convert.ToInt32(dr["id"].ToString().Trim())),
                       new SqlParameter("CtrName", dr["CtrName"].ToString()),
                       new SqlParameter("VN", dr["VN"].ToString().Trim()),
                       new SqlParameter("EN", dr["EN"].ToString().Trim()),
                       new SqlParameter("KR", dr["KR"].ToString().Trim()),
                       new SqlParameter("Typer", 0));
                   }
               }

                foreach(DataRow dr in dtDR.Rows)
                {
                    if (dr["VN"].ToString().Trim() != "")
                    {
                        // insert vào database Master
                        Provider.ExecNoneQuery("p_Translate_EXEC_Detail",
                        new SqlParameter("id", Convert.ToInt32(dr["id"].ToString().Trim())),
                        new SqlParameter("CtrName", dr["CtrName"].ToString()),
                        new SqlParameter("FormName", dr["FormName"].ToString()),
                        new SqlParameter("VN", dr["VN"].ToString().Trim()),
                        new SqlParameter("EN", dr["EN"].ToString().Trim()),
                        new SqlParameter("KR", dr["KR"].ToString().Trim()),
                        new SqlParameter("Typer", 0));
                    }

                }
                GUIHelper.MessageBox("Cập nhập dữ liệu thành công!");

            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.ToString());
            }

        }

        private void grvDC_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
            {              
                //add new row to list dùng riêng    
                try
                {
                    DataRow dr = grvDC.GetDataRow(grvDC.FocusedRowHandle);

                    DataRow[] result = dtDR.Select("CtrName = '" + dr["CtrName"].ToString() + "'");
                    if (result.Count() == 0)
                    {
                        DataRow dataRow = dtDR.NewRow();
                        dataRow["CtrName"] = dr["CtrName"].ToString();
                        dataRow["CtrTyper"] = dr["CtrTyper"].ToString();
                        dataRow["VN"] = dr["VN"].ToString();
                        dataRow["EN"] = dr["EN"].ToString();
                        dataRow["KR"] = dr["KR"].ToString();
                        dataRow["FormName"] = formName.ToString();
                        dtDR.Rows.Add(dataRow);
                        grdDR.DataSource = dtDR;
                    }
                }
                catch(Exception ex)
                {
                    GUIHelper.MessageError(ex.ToString());
                }  
            }
            else
            {
                if (e.Action == CollectionChangeAction.Remove)
                {
                    //ngược lại bỏ check
                    try
                    {
                        DataRow dr = grvDC.GetDataRow(grvDC.FocusedRowHandle);
                        List<DataRow> RowsToDelete = new List<DataRow>();
                        foreach (DataRow drs in dtDR.Rows)
                        {
                            //duyệt datatable
                            if (drs["CtrName"].ToString().Equals(dr["CtrName"].ToString().Trim()))
                            {
                                RowsToDelete.Add(drs);
                            }
                        }
                        foreach (var drDelete in RowsToDelete)
                        {
                            dtDR.Rows.Remove(drDelete);
                        }                         
                        grdDR.DataSource = dtDR;
                    }
                    catch (Exception ex)
                    {
                        GUIHelper.MessageError(ex.ToString());
                    }

                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmTranslate_Load(sender, e);
        }
    }
}
