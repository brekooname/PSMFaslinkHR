using iHRM.Common.Code;
using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm.impForms
{
    public partial class impTamUng : i_Import.FixImporter
    {
        public impTamUng()
        {
            InitializeComponent();
            this.OnPreData += TU_OnPreData; 
            this.OnImportRow += TU_OnImportRow; 
            this.OnDownLoadFileTemplate += TU_OnDownLoadFileTemplate;
        }
        DataSet dsDM = null;
        private void TU_OnDownLoadFileTemplate(string saveFileTo)
        {
            ExcelExtend ex = new ExcelExtend();
            ex.OpenFile(Path.Combine(win_globall.apppath,"ExcelTemplate/Luong/impTamUng.xlsx"));
            ex.Save(saveFileTo);
        }

        private void TU_OnImportRow(DataRow dr)
        {
            try
            {

                //get Imformation Candidate

                dr["idUserRequest"] = LoginHelper.user.id;
                dr["ngayRequest"] = DateTime.Now;
                foreach (DataColumn dc in dtDataExcelImported.Columns)
                {
                    if (dr[dc] == DBNull.Value || string.IsNullOrWhiteSpace(dr[dc].ToString()))
                        dr[dc] = DBNull.Value;
                }
                var ret = Provider.ExecuteNonQuery("p_Luong_TamUng_ExcelImport", dr);
                OutLog_DuringImport(string.Format("Emp: {0}: Done", dr["EmployeeID"]));
            }
            catch (Exception ex)
            {
                
                OutLog_DuringImport(string.Format("Emp: {0}: " + ex.Message, dr["EmployeeID"]));
            }
        }

        private void TU_OnPreData()
        {
            this.dtDataExcelImported.Columns.Add(new DataColumn("idUserRequest"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("ngayRequest"));
            if (this.dtDataExcelImported.Rows.Count > 0)
                this.dtDataExcelImported.Rows.RemoveAt(0);

        }
        object GetID_ds(DataTable dt, string textColName, string textValue, string idColName)
        {
            if (!string.IsNullOrWhiteSpace(textValue))
            {
                var r = dt.Select("[" + textColName + "]='" + textValue.Trim() + "'").FirstOrDefault();
                if (r != null)
                    return r[idColName];
            }
            return DBNull.Value;
        }
    }
}
