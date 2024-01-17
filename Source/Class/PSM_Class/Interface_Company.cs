using iHRM.Core.Business;
using iHRM.Core.Business.Logic.Luong;
using iHRM.Core.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.ChamCong;

namespace iHRM.Win.ExtClass
{
    public class Interface_Company
    {
        Core.Business.DbObject.dcDatabaseDataContext db;
        public static string strLuuDataQuetThe = "D:\\Data Quet The";
        public static bool RegistableALWhenSmaller0 = false;
        public static bool AnyUserEditLeftDate = true;
        public static bool useFinger = false;
        public static int ngayBatDauChuKy = 1;
        public Interface_Company()
        {
            db = new Core.Business.DbObject.dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        }

        public static DateTime DateServer()
        {
            DataTable dt = new DataTable();
            DateTime dtTemp = new DateTime();
            try
            {
                string sql = " SELECT CAST( CONVERT(date, GETDATE(), 110) as nvarchar ) + ' ' + left( CAST( CONVERT(time, GETDATE()) as nvarchar),8) AS DATE ";
                dt = Provider.ExecuteDataTableReader_SQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    dtTemp = Convert.ToDateTime( dr["DATE"].ToString());
                }
            }
            catch { }
            return dtTemp;
        }
        public string getEmployeeID()
        {
            var empIDLast = db.tblEmployees.Where(x => x.EmployeeID.Substring(0, 2) == "FL").OrderByDescending(p => p.EmployeeID).FirstOrDefault();

            int empID_Last = 0;

            if (empIDLast != null)
            {
                empID_Last = int.Parse(empIDLast.EmployeeID.Substring(2, 4));
            }

            int empID = empID_Last + 1;

            if (empID.ToString().Length <= 4)
            {
                return string.Format("FL{0:0000}", empID);
            }

            return string.Format("FL{0:0000}", empID);
        }

        public string getEmployeeID(DateTime _ngay)
        {

            var empIDLast = db.tblEmployees.Where(x => x.EmployeeID.Substring(0, 2) == "FL").OrderByDescending(p => p.EmployeeID).FirstOrDefault();

            int empID_Last = 0;

            if (empIDLast != null)
            {
                empID_Last = int.Parse(empIDLast.EmployeeID.Substring(2, 4));
            }

            int empID = empID_Last + 1;

            if (empID.ToString().Length <= 4)
            {
                return string.Format("FL{0:0000}", empID);
            }

            return string.Format("FL{0:0000}", empID);
        }

        public string getEmployeeID(String _EmpTypeCode)
        {
            DataTable dt = new DataTable();
            string EmpTypeCode = "";
            int length = 0;
            int str_Len = _EmpTypeCode.Length;
            int empID_Last = 0;
            int empID = 0;

            try
            {
                string sql = " SELECT MAX(RIGHT(EmployeeID,(LEN(EmployeeID) - " + str_Len + "))) AS EmpTypeCode FROM dbo.tblEmployee WHERE LEFT(EmployeeID," + str_Len + ") = '" + _EmpTypeCode.Substring(0, 4) + "' ";
                dt = Provider.ExecuteDataTableReader_SQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    EmpTypeCode = Convert.ToString(dr["EmpTypeCode"].ToString());
                }
                length = EmpTypeCode.Length;
            }
            catch { }

            if (EmpTypeCode != "")
            {
                empID_Last = int.Parse(EmpTypeCode);
            }

           
            empID = empID_Last + 1;

            return string.Format("{0}{1:0000}", _EmpTypeCode, empID);
        }

        public string getUngVienID()
        {
            var empIDLast = db.tblUngViens.OrderByDescending(p => p.EmployeeID).FirstOrDefault();
            int empID_Last = 0;
            if (empIDLast != null)
            {
                empID_Last = Convert.ToInt16(empIDLast.EmployeeID.Substring(2,5));
            }
            int empID = empID_Last + 1;

            return string.Format("{0:UV00000}", empID);
        }
        public string getSoCT_TuyenDung()
        {
            var empIDLast = db.tbYeuCauTuyenDungs.OrderByDescending(p => p.soChungTu).FirstOrDefault();
            int empID_Last = 0;
            if (empIDLast != null)
            {
                empID_Last = Convert.ToInt16(empIDLast.soChungTu.Substring(11, 5));
            }
            int empID = empID_Last + 1;
            string ma = string.Format("{0:00000}", empID);
            return "TD/D.01/"+DateTime.Now.Year.ToString().Substring(2,2)+"."+ma+"";
        }
        public double getAnnualLeave(DateTime AppliedDate, int totalAL)
        {
            double AnnualLeave = 0;
            AnnualLeave += (new DateTime(DateTime.Now.Year, 12, 31) - (AppliedDate.Year < DateTime.Now.Year ? new DateTime(DateTime.Now.Year, 1, 1) : AppliedDate)).TotalDays / 365 * totalAL;
            AnnualLeave = (int)AnnualLeave + ((AnnualLeave - (int)AnnualLeave) > 0.5 ? 0.5 : 0);
            return AnnualLeave;
        }
        public string getKeHoachTuyenDungID()
        {
            var empIDLast = db.tblKeHoachTuyenDungs.OrderByDescending(p => p.MaKHTD).FirstOrDefault();
            int empID_Last = 0;
            if (empIDLast != null)
            {
                empID_Last = Convert.ToInt16(empIDLast.MaKHTD.Substring(4, 5));
            }
            int empID = empID_Last + 1;

            return string.Format("{0:KHTD00000}", empID);
        }
        public string getKeHoachTuyenDungSCT()
        {
            var Count = db.tblKeHoachTuyenDungs.Where(p => p.Ngay == DateTime.Now.Year.ToString()).Count();
            return string.Format("TD/B.01/{0:00}-{1:0000}", DateTime.Now.Year.ToString().Substring(2,2),Count+1);
        }
        public string getUngVienSCT()
        {
            var Count = db.tblUngViens.Where(p => p.CreatedDate.Value.Year == DateTime.Now.Year).Count();
            return string.Format("TD/B.03/{0:00}-{1:0000}", DateTime.Now.Year.ToString().Substring(2, 2), Count + 1);
        }
        public string getUngVienSoBoID()
        {
            var empIDLast = db.tblUngVienSoBos.OrderByDescending(p => p.MaUVSB).FirstOrDefault();
            int empID_Last = 0;
            if (empIDLast != null)
            {
                empID_Last = Convert.ToInt16(empIDLast.MaUVSB.Substring(4, 6));
            }
            int empID = empID_Last + 1;

            return string.Format("{0:UVSB00000}", empID);
        }
        public int getNumberEmpID(string EmpID)
        {
            return Convert.ToInt32(EmpID.Substring(7, 4));
        }
        public string getKhoi(string DepID)
        {
            string Khoi = string.Empty;
            var Dept = db.tblRef_Departments.OrderByDescending(p => p.Notes).Where(p=>p.DepID == DepID).FirstOrDefault();
            if (Dept != null)
            {
                Khoi = Dept.Notes;
            }
            else
            {
                Khoi = string.Empty;
            }
            return Khoi;
        }
    }

    public class Emp_KQ
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string DepName_Final { get; set; }
        public double SoGio { get; set; }
        public double Cong { get; set; }
        public double TangCa { get; set; }
        public double SoLanTre { get; set; }
        public double SoLanSom { get; set; }
        public double VangKP { get; set; }
        public double SoPhutTre { get; set; }
        public double SoPhutSom { get; set; }
        public double TangCaNgayLe { get; set; }
        public double VangCP { get; set; }
        public List<KQQT> _lKQQT { get; set; }
    }
    public class KQQT
    {
        public DateTime? ngay { get; set; }
        public string caLam { get; set; }
        public TimeSpan? tgQuetDen { get; set; }
        public TimeSpan? tgQuetVe { get; set; }
        public double tgDiMuon { get; set; }
        public double tgVeSom { get; set; }
        public double kqNgayCong { get; set; }
        public double OT { get; set; }
        public string lyDoNghi { get; set; }
        public double NT { get; set; } 
        public double NT2 { get; set; } 
        public double TG { get; set; } 
    }
}
