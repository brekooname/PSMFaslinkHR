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

namespace iHRM.Win.Frm.Employee
{
    public partial class impEmployee_YCSC : i_Import.FixImporter
    {
        /// <summary>
        /// biến lưu danh mục dùng chung
        /// </summary>
        DataSet dsDM = null;

        public impEmployee_YCSC()
        {
            InitializeComponent();
        }

        private void impEmployee_YCSC_Load(object sender, EventArgs e)
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
                dsDM = Provider.ExecuteDataSetReader("p_Emp_getAllDM");

            //thêm cột
            //this.dtDataExcelImported.Columns.Add(new DataColumn("EmpTypeID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("LeftTypeID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("ContractTypeID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("DepID_Final"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("hdld1_loaihdID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("hdld2_loaihdID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("hdld3_loaihdID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("hdld1_PosID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("hdld2_PosID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("hdld3_PosID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("NationalityID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("EducationID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("MaritalStatusID"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("idCaLamMacDinh"));

            //this.dtDataExcelImported.Columns.Add(new DataColumn("BankID"));

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
                //dr["EmpTypeID"] = GetID_ds(dsDM.Tables[0], "EmpTypeName", dr["EmpTypeName"] as string, "EmpTypeID");

                //dr["LeftTypeID"] = GetID_ds(dsDM.Tables[1], "LeftTypeName", dr["LeftTypeName"] as string, "LeftTypeID");

                //dr["ContractTypeID"] = GetID_ds(dsDM.Tables[2], "ContractTypeName", dr["ContractTypeName"] as string, "ContractTypeID");

                //dr["DepID_Final"] = GetID_ds(dsDM.Tables[3], "DepName", dr["DepName_Final"] as string, "DepID");

                //dr["NationalityID"] = GetID_ds(dsDM.Tables[4], "NationalityName", dr["NationalityName"] as string, "NationalityID");

                //dr["EducationID"] = GetID_ds(dsDM.Tables[5], "EducationType", dr["EducationType"] as string, "EducationID");

                //dr["MaritalStatusID"] = GetID_ds(dsDM.Tables[6], "MaritalStatusName", dr["MaritalStatusName"] as string, "MaritalStatusID");

                //dr["idCaLamMacDinh"] = GetID_ds(dsDM.Tables[7], "Alias", dr["ten_calammd"] as string, "id");

                //dr["hdld1_loaihdID"] = GetID_ds(dsDM.Tables[2], "ContractTypeName", dr["hdld1_loaihd"] as string, "ContractTypeID");

                //dr["hdld2_loaihdID"] = GetID_ds(dsDM.Tables[2], "ContractTypeName", dr["hdld2_loaihd"] as string, "ContractTypeID");

                //dr["hdld3_loaihdID"] = GetID_ds(dsDM.Tables[2], "ContractTypeName", dr["hdld3_loaihd"] as string, "ContractTypeID");

                //// Chưa điền bảng
                //dr["hdld1_PosID"] = GetID_ds(dsDM.Tables[8], "PosName", dr["hdld1_PosName"] as string, "PosID");

                //dr["hdld2_PosID"] = GetID_ds(dsDM.Tables[8], "PosName", dr["hdld2_PosName"] as string, "PosID");

                //dr["hdld3_PosID"] = GetID_ds(dsDM.Tables[8], "PosName", dr["hdld3_PosName"] as string, "PosID");

                //dr["BankID"] = GetID_ds(dsDM.Tables[9], "BankName", dr["BankName"] as string, "BankID");

                foreach (DataColumn dc in dtDataExcelImported.Columns)
                {
                    if (dr[dc] == DBNull.Value || string.IsNullOrWhiteSpace(dr[dc].ToString()))

                        dr[dc] = DBNull.Value;
                }

                var ret = Provider.ExecuteNonQuery("p_Emp_ExcelImport_YCSC", dr);

                //LogAction.LogAction.PushLog("Import nhân viên"
                //                            , dr["EmployeeCode"].ToString()
                //                            , ""
                //                            , "Import nhân viên thành công"
                //                            , "tblEmployee");

                OutLog_DuringImport(string.Format("Emp: {0}: Done", dr["EmployeeCode"]));
            }
            catch (Exception ex)
            {
                //GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.ExceptionThrow);
                OutLog_DuringImport( string.Format( "Emp: {0}: " + ex.Message, dr["EmployeeCode"]));
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

            ex.OpenFile(Path.Combine(win_globall.apppath, "ExcelTemplate/Employee/impNS_New.xlsx"));

            ex.ActiveSheet = "data";

            //chuẩn bị dữ liệu đẩy ra file excel

            dsDM = Provider.ExecuteDataSetReader("p_Emp_getAllDM");

            ex.WriteDataTable_NoInsert(dsDM.Tables[0], "A2");

            ex.WriteDataTable_NoInsert(dsDM.Tables[1], "C2");

            ex.WriteDataTable_NoInsert(dsDM.Tables[2], "E2");

            ex.WriteDataTable_NoInsert(dsDM.Tables[3], "G2");

            ex.WriteDataTable_NoInsert(dsDM.Tables[4], "I2");

            ex.WriteDataTable_NoInsert(dsDM.Tables[5], "K2");

            ex.WriteDataTable_NoInsert(dsDM.Tables[6], "M2");

            ex.WriteDataTable_NoInsert(dsDM.Tables[7], "O2");

            ex.WriteDataTable_NoInsert(dsDM.Tables[8], "Q2");

            ex.WriteDataTable_NoInsert(dsDM.Tables[9], "S2");

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
