using iHRM.Common.Code;
using iHRM.Core.Business;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class impUngVien : i_Import.FixImporter
    {
        /// <summary>
        /// biến lưu danh mục dùng chung
        /// </summary>
        DataSet dsDM = null;

        public impUngVien()
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
                dsDM = Provider.ExecuteDataSetReader("p_Emp_getAllDMUV");

            //thêm cột
            this.dtDataExcelImported.Columns.Add(new DataColumn("EmpTypeID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("MaritalStatusID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("RelationID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("LangID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("ID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("TDGD_ID"));
            this.dtDataExcelImported.Columns.Add(new DataColumn("soChungTu"));

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
                //get Imformation Candidate
                dr["EmpTypeID"] = GetID_ds(dsDM.Tables[0], "EmpTypeName", dr["IdViTriDuTuyen1"] as string, "EmpTypeID");
                dr["MaritalStatusID"] = GetID_ds(dsDM.Tables[1], "MaritalStatusName", dr["MaritalStatusName"] as string, "MaritalStatusID");
                dr["LangID"] = GetID_ds(dsDM.Tables[3], "LangName", dr["LangName"] as string, "LangID");
                dr["soChungTu"] = LoginHelper.Context.getUngVienSCT();
                foreach (DataColumn dc in dtDataExcelImported.Columns)
                {
                    if (dr[dc] == DBNull.Value || string.IsNullOrWhiteSpace(dr[dc].ToString()))
                        dr[dc] = DBNull.Value;
                }
                var ret = Provider.ExecuteNonQuery("p_EmpUV_ExcelImport", dr);

                LogAction.LogAction.PushLog("Import", dr["EmployeeID"].ToString(), "", string.Format("Import ứng viên {0}", dr["EmployeeID"]), "tblUngVien");
                OutLog_DuringImport(string.Format("Emp: {0}: Done", dr["EmployeeID"]));
            }
            catch (Exception ex)
            {
                //GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.ExceptionThrow);
                OutLog_DuringImport(string.Format("Emp: {0}: " + ex.Message, dr["EmployeeID"]));
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
            ex.OpenFile(Path.Combine(win_globall.apppath, "ExcelTemplate/TuyenDung/ThongTinUngVien_new.xlsx"));
            //TẠO MỘT DATATABLE TRÌNH ĐỘ GIÁO DỤC
            DataTable dt = new DataTable();
            //Adding columns to datatable
            
            dt.Columns.Add("TDGD_NAME", typeof(string));
            dt.Columns.Add("TDGD_ID", typeof(string));
            DataRow row1;
            row1 = dt.NewRow();
            row1["TDGD_ID"] = "GDPT";
            row1["TDGD_NAME"] = "Giáo Dục Phổ Thông";
            dt.Rows.Add(row1);
            DataRow row2;
            row2 = dt.NewRow();
            
            row2["TDGD_NAME"] = "Giáo Dục Đại Học";
            row2["TDGD_ID"] = "GDĐH";
            dt.Rows.Add(row2);
            DataRow row3;
            row3 = dt.NewRow();
            row3["TDGD_ID"] = "GDTX";
            row3["TDGD_NAME"] = "Giáo Dục Thường Xuyên";
            dt.Rows.Add(row3);
            
            ex.ActiveSheet = "data";
            //chuẩn bị dữ liệu đẩy ra file excel
            dsDM = Provider.ExecuteDataSetReader("p_Emp_getAllDMUV");
            dsDM.Tables.Add(dt);
            ex.WriteDataTable_NoInsert(dsDM.Tables[0], "A2");
            ex.WriteDataTable_NoInsert(dsDM.Tables[1], "C2");
            ex.WriteDataTable_NoInsert(dsDM.Tables[5], "G2");
            ex.WriteDataTable_NoInsert(dsDM.Tables[2], "E2");
            ex.WriteDataTable_NoInsert(dsDM.Tables[3], "I2");
            ex.WriteDataTable_NoInsert(dsDM.Tables[4], "K2");
           
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

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {

        }

    }
}
