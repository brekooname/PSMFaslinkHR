using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.Base;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class impDKCaLam_New : i_Import.FixImporter
    {
        public impDKCaLam_New()
        {
            InitializeComponent();
        }
        DataSet dsDM = null;
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        private void impEmployee_Load(object sender, EventArgs e)
        {
            this.InitializeComponent();

            this.OnPreData += impEmployee_OnPreData;
            this.OnImportRow += impEmployee_OnImportRow;
            this.OnDownLoadFileTemplate += ImpEmployee_OnDownLoadFileTemplate;
        }

        private void impEmployee_OnPreData()
        {
            //xóa dòng đầu
            if (this.dtDataExcelImported.Rows.Count > 0)
                this.dtDataExcelImported.Rows.RemoveAt(0);
        }

        private void impEmployee_OnImportRow(DataRow dr)
        {
            int nam = dateThangNam.DateTime.Year;
            if (nam == 1)
            {
                return; 
            }
            Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
            try
            {
                DataTable dt = this.dtDataExcelImported.Copy();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i >= 2)
                    {
                        string ngay = dt.Columns[i].ColumnName.ToString().Trim();
                        int ketqua_ngay = int.Parse(ngay.Replace("N", ""));
                        int thang = dateThangNam.DateTime.Month;
                        int nam_tam = dateThangNam.DateTime.Year;
                        
                        
                        //if (thang == 1)
                        //{
                        //    switch (ketqua_ngay)
                        //    {
                        //        case 26: thang = 12; nam_tam = nam_tam - 1; break;
                        //        case 27: thang = 12; nam_tam = nam_tam - 1; break;
                        //        case 28: thang = 12; nam_tam = nam_tam - 1; break;
                        //        case 29: thang = 12; nam_tam = nam_tam - 1; break;
                        //        case 30: thang = 12; nam_tam = nam_tam - 1; break;
                        //        case 31: thang = 12; nam_tam = nam_tam - 1; break;
                        //    }
                        //}
                        //else
                        //{
                        //    switch (ketqua_ngay)
                        //    {
                        //        case 26: thang = thang - 1; break;
                        //        case 27: thang = thang - 1; break;
                        //        case 28: thang = thang - 1; break;
                        //        case 29: thang = thang - 1; break;
                        //        case 30: thang = thang - 1; break;
                        //        case 31: thang = thang - 1; break;
                        //    }
                        //}

                        try
                        {
                            DateTime d = new DateTime(nam_tam, thang, ketqua_ngay);
                            string manv = dr["EmployeeID"].ToString();
                            var calam = db.tbCaLamViecs.Where(p => p.ten == dr[i].ToString()).FirstOrDefault();
                            if (calam != null)
                            {

                                if (!AllLogic.checkEmployeeIDInDep(manv, LoginHelper.user.idKhoiPB))
                                {
                                    OutLog_DuringImport(string.Format("Mã nhân viên: {0} không nằm trong phòng ban của bạn.\n", manv));
                                    continue;
                                }

                                //if (IsLock.IsLock.Check_IsLock("tbDangKyCaLam", d))
                                //{
                                //    OutLog_DuringImport(string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} khổng thể thao tác!", d));
                                //    continue;
                                //}
                                if (IsLock.IsLock.Check_IsLock_Type("tbDangKyCaLam", d,1))
                                {
                                    OutLog_DuringImport(string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} khổng thể thao tác!", d));
                                    continue;
                                }

                                if (IsLock.IsLock.Check_IsLock_Type("tbDangKyCaLam", d, 2))
                                {
                                    OutLog_DuringImport(string.Format("Dữ liệu đã chốt đăng ký mới ngày {0:dd/MM/yyyy} khổng thể thao tác!", d));
                                    continue;
                                }

                                if (IsLock.IsLock.Check_DangKyCaLam(manv, d))
                                {
                                    OutLog_DuringImport(string.Format("Dữ liệu đã chốt ca làm/ làm thêm ngày {0:dd/MM/yyyy} khổng thể thao tác!", d));
                                    continue;
                                }

                                if (IsLock.IsLock.p_Check_IsdklamThem(manv, d))
                                {
                                    OutLog_DuringImport(string.Format("NV {1} ngày {0:dd/MM/yyyy} đã đăng ký bên làm thêm!\n Vui lòng xóa làm thêm để đăng ký ca làm.\n", d, manv));
                                    continue;
                                }
                               
                                Provider.ExecuteNonQuery("p_chamcong_CaNhan_DangKyCaLam",
                                new SqlParameter("empID", manv),
                                new SqlParameter("ngay", d),
                                new SqlParameter("idCaLam", calam.id),
                                new SqlParameter("dkLamThem", null),
                                new SqlParameter("hsLuong", 100),
                                new SqlParameter("userRequest", LoginHelper.user.id) 
                                 );
                                LogAction.LogAction.PushLog("Đăng ký", manv, "", string.Format("Đăng ký ca làm bằng excel thành công NV {0} ngày {1:dd/MM/yyyy}", manv, d), "tbDangKyCaLam");
                                OutLog_DuringImport(string.Format("Emp: {0}: thành công ca làm ", dr["EmployeeID"]) + " Ngày " + string.Format("{0}/{1}/{2}", ketqua_ngay, thang, nam_tam));
                            }
                        }
                        catch { }
                    }

                }
            }
            catch (Exception ex)
            {
                OutLog_DuringImport(string.Format("Emp: {0}: " + ex.Message, dr["EmployeeID"]));
            }
        }

        private void ImpEmployee_OnDownLoadFileTemplate(string saveFileTo)
        {
            ExcelExtend ex = new ExcelExtend();
            ex.OpenFile(Path.Combine(win_globall.apppath, "ExcelTemplate/Cong/impDKCaLam_NEW.xls"));
            ex.ActiveSheet = "dangkycalam";

            var dt = Provider.ExecuteDataTableReader("p_getThongTinCaLam", new System.Data.SqlClient.SqlParameter("login", LoginHelper.user.loginID));
            ex.WriteDataTable_NoInsert(dt, "A3");


            ex.ActiveSheet = "data";

            var dt_calam = Provider.ExecuteDataTableReader("p_getCaLamByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));
            ex.WriteDataTable_NoInsert(dt_calam, "A2");

            ex.Save(saveFileTo);
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
