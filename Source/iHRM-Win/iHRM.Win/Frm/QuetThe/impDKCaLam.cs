using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.Base;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class impDKCaLam : i_Import.FixImporter
    {
        public impDKCaLam()
        {
            InitializeComponent();
        }
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
            //dtDataExcelImported = e
        }

        private void impEmployee_OnImportRow(DataRow dr)
        {
            try
            {
                ExecuteResult ret;
                Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
                string WeekHoliday = "," + iHRM.Core.Business.Logic.AllLogic.SysPa_Get("WeekHoliday") + ",";
                string empID = dr[0].ToString();
                DateTime d = Convert.ToDateTime(dr[1]);
                string strCaLam = dr[2].ToString().Trim().ToUpper();
                var calam = db.tbCaLamViecs.Where(p => p.ten.Trim().ToUpper().Equals(strCaLam)).FirstOrDefault();
                if (calam == null)
                {
                    OutLog_DuringImport(string.Format("Đăng ký ca làm nhân viên {0} bị lỗi: Ca làm bị sai.", empID
                   ));
                }
                else
                {
                    Guid idCaLam = calam.id;

                    if (!AllLogic.checkEmployeeIDInDep(empID, LoginHelper.user.idKhoiPB))
                    {
                        OutLog_DuringImport(string.Format("Mã nhân viên: {0} không nằm trong phòng ban của bạn.\n", empID));
                        return;
                    }

                    //if (IsLock.IsLock.Check_IsLock("tbDangKyCaLam", d))
                    //{
                    //    OutLog_DuringImport(string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} khổng thể thao tác!", d));
                    //    return;
                    //}

                    if (IsLock.IsLock.Check_IsLock_Type("tbDangKyCaLam", d,1))
                    {
                        OutLog_DuringImport(string.Format("Dữ liệu đã chốt công ngày {0:dd/MM/yyyy} khổng thể thao tác!", d));
                        return;
                    }

                    if (IsLock.IsLock.Check_IsLock_Type("tbDangKyCaLam", d,2))
                    {
                        OutLog_DuringImport(string.Format("Dữ liệu đã chốt đăng ký mới ngày {0:dd/MM/yyyy} khổng thể thao tác!", d));
                        return;
                    }
                    if (IsLock.IsLock.Check_DangKyCaLam(empID, d))
                    {
                        OutLog_DuringImport(string.Format("Dữ liệu đã chốt ca làm/ làm thêm ngày {0:dd/MM/yyyy} khổng thể thao tác!", d));
                        return;
                    }

                    if (IsLock.IsLock.p_Check_IsdklamThem(empID, d))
                    {
                        OutLog_DuringImport( string.Format("NV {1} ngày {0:dd/MM/yyyy} đã đăng ký bên làm thêm!\n Vui lòng xóa làm thêm để đăng ký ca làm.\n", d, empID));
                        return;
                    }
                    

                    ret = logic.DangKyCaLam(empID, d, idCaLam, null, 100, LoginHelper.user.id);
                    if (ret.NumberOfRowAffected == 1)
                    {
                        OutLog_DuringImport(string.Format("Đăng ký ca làm nhân viên {0} thành công", empID));

                        LogAction.LogAction.PushLog("Đăng ký", empID, "", string.Format("Đăng ký ca làm bằng excel thành công NV {0} ngày {1:dd/MM/yyyy}", empID, d), "tbDangKyCaLam");
                    }
                    else
                    {
                        OutLog_DuringImport(string.Format("Đăng ký ca làm nhân viên {0} bị lỗi: {1}", empID,
                            ret.Message
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                //GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.ExceptionThrow);
                OutLog_DuringImport(ex.Message);
            }
        }

        private void ImpEmployee_OnDownLoadFileTemplate(string saveFileTo)
        {
            ExcelExtend ex = new ExcelExtend();
            ex.OpenFile(Path.Combine(win_globall.apppath, "ExcelTemplate/Cong/impDKCaLam.xlsx"));
            ex.ActiveSheet = "data";

            var dt = Provider.ExecuteDataTableReader("p_getCaLamByDepID_Name_SW", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));
            //var dt = Provider.ExecuteDataTableReader_SQL("select ten from tbCaLamViec");
            ex.WriteDataTable_NoInsert(dt, "A2");

            ex.Save(saveFileTo);
        }

        int? GetID_ds(string value, DataTable dt)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var r = dt.Select("ten='" + value + "'").SingleOrDefault();
                if (r != null)
                    return r["id"] as int?;
            }
            return null;
        }

        private void wizardControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
