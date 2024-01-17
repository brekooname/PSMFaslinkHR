using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Controller.Import;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class impUngVienSoBo : i_Import.FixImporter
    {
        /// <summary>
        /// biến lưu danh mục dùng chung
        /// </summary>
        DataSet dsDM = null;

        public impUngVienSoBo()
        {
            InitializeComponent();
        }

        private void impEmployee_Load(object sender, EventArgs e)
        {
            this.InitializeComponent();
            
            //gán sự kiện
            this.OnPreData += impEmployee_OnPreData; //khi chuẩn bị dữ liệu trước khi import
            this.OnImportRow += impEmployee_OnImportRow; //khi import từng dòng vào db
            this.OnDownLoadFileTemplate += ImpEmployee_OnDownLoadFileTemplate; //khi click nút download template (nếu ko có sự kiện này thì phải gán FileTemplate)
        }

        /// <summary>
        /// chuẩn bị dữ liệu trước khi import
        /// </summary>
        private void impEmployee_OnPreData()
        {
            if (dsDM == null)
                dsDM = Provider.ExecuteDataSetReader("p_Emp_getAllDM_UVSB");

            //thêm cột
            this.dtDataExcelImported.Columns.Add(new DataColumn("EmpTypeID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("QualificationID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("LangID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("EducationID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("NationalityID"));
        

            //xóa dòng đầu
            if (this.dtDataExcelImported.Rows.Count > 0)
                this.dtDataExcelImported.Rows.RemoveAt(0);
        }

        /// <summary>
        /// import từng dòng vào db
        /// </summary>
        /// <param name="dr">Dòng sẽ đc import</param>
        private void impEmployee_OnImportRow(DataRow dr)
        {
            try
            {
                dr["EmpTypeID"] = GetID_ds(dsDM.Tables[0], "EmpTypeName", dr["ViTriUngTuyenName"] as string, "EmpTypeID");
                dr["QualificationID"] = GetID_ds(dsDM.Tables[1], "QualificationName", dr["TrinhDoChuyenMonName"] as string, "QualificationID");
                dr["LangID"] = GetID_ds(dsDM.Tables[2], "LangName", dr["NgoaiNguName"] as string, "LangID");
                dr["EducationID"] = GetID_ds(dsDM.Tables[3], "EducationType", dr["TrinhDoVanHoaName"] as string, "EducationID");
                dr["NationalityID"] = GetID_ds(dsDM.Tables[4], "NationalityName", dr["Quoctich"] as string, "NationalityID");

                
                foreach (DataColumn dc in dtDataExcelImported.Columns)
                {
                    if (dr[dc] == DBNull.Value || string.IsNullOrWhiteSpace(dr[dc].ToString()))
                        dr[dc] = DBNull.Value;
                }

                var ret = Provider.ExecuteNonQuery("p_EmpUVSB_ExcelImport", dr);

                LogAction.LogAction.PushLog("Import", dr["MaUVSB"].ToString(), "", string.Format("Import ứng viên sơ bộ {0}", dr["MaUVSB"]), "tblUngVienSoBo");
                OutLog_DuringImport(string.Format("Emp: {0}: Done", dr["MaUVSB"]));
            }
            catch (Exception ex)
            {
                //GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.ExceptionThrow);
                OutLog_DuringImport(string.Format("Emp: {0}: " + ex.Message, dr["MaUVSB"]));
            }
        }

        /// <summary>
        /// click nút download template 
        /// </summary>
        /// <param name="saveFileTo"></param>
        private void ImpEmployee_OnDownLoadFileTemplate(string saveFileTo)
        {
            //lấy file mẫu
            ExcelExtend ex = new ExcelExtend();
            ex.OpenFile(Path.Combine(win_globall.apppath, "ExcelTemplate/TuyenDung/impUVSB.xlsx"));

            ex.ActiveSheet = "data";
            //chuẩn bị dữ liệu đẩy ra file excel
            dsDM = Provider.ExecuteDataSetReader("p_Emp_getAllDM_UVSB");
            ex.WriteDataTable_NoInsert(dsDM.Tables[0], "A2");
            ex.WriteDataTable_NoInsert(dsDM.Tables[1], "C2");
            ex.WriteDataTable_NoInsert(dsDM.Tables[2], "E2");
            ex.WriteDataTable_NoInsert(dsDM.Tables[3], "G2");
            ex.WriteDataTable_NoInsert(dsDM.Tables[4], "I2");
            //lưu file vào vị trí download
            ex.Save(saveFileTo);
        }

        /// <summary>
        /// lấy id từ tên
        /// </summary>
        /// <param name="value">giá trị gì</param>
        /// <param name="dt">bảng nào</param>
        /// <returns></returns>
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
