using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mail;
using System.Windows.Forms;
using System.Xml;
using iHRM.Win.ExtClass;
using iHRM.Common.Code;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Win.Frm.XtraReportTemplate;
using System.Data.SqlClient;
using System.Drawing;
using iHRM.Win.Frm;


namespace iHRM.Win.DungChung
{
    public static class Ham
    {
        public static int DemNgayCong(DateTime startDate, DateTime endDate)
        {

            int c = 0;
            while (startDate < endDate)
            {
                if (startDate.DayOfWeek != DayOfWeek.Sunday)
                    c += 1;

                startDate = startDate.AddDays(1);
            }
            return c;
        }

        public static List<string> getYear()
        {
            List<string> lst = new List<string>();
            for(int i=0;i <= DateTime.Now.Year;i++)
            {
                lst.Add(string.Format("{0:0000}", i));
            }
            return lst;
        }

        public static List<string> getYear(int _nam)
        {
            List<string> lst = new List<string>();
            for (int i = 0; i <= DateTime.Now.Year + 10; i++)
            {
                if(i >= _nam)
                    lst.Add(string.Format("{0:0000}", i));
            }
            return lst;
        }

        public static void SendMail( string Subject,string body,string loginid)
        {
            try
            {
                var db = new dcDatabaseDataContext(Provider.ConnectionString); // mở kết nối SQL
                var user = db.w5sysUsers.First(p => p.loginID == loginid); // lấy ra User để lấy địa chỉ Email
                var From_tam = db.tblRef_Emails.OrderByDescending(p => p.LoaiMail == "2").FirstOrDefault(); // lấy ra email để gửi đi
                string From = From_tam.Email;
                string Pass = From_tam.Pass;

                MailMessage msg = new MailMessage();
                msg.Body = body;
                string smtpServer = "mail.thuanhai.com.vn";// khai báo server web mail
                string userName = From; // user login web mail
                string password = Pass; // pass login web mail
                int cdoBasic = 1; // mở smtpauthenticate = 1
                int cdoSendUsingPort = 2; // mở SendUsingPort = 2
                if (userName.Length > 0)
                {
                    // mở kết nối với server web mail
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpServer);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", cdoSendUsingPort);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", cdoBasic);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", userName);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
                }
                msg.From = userName; // tên email gửi đi
                msg.To = user.Email; // email nhận mail
                msg.Cc = From;
                msg.Subject = Subject; // tiêu đề
                msg.BodyEncoding = System.Text.Encoding.UTF8; // fortmat lại nội dung email tránh lỗi font
                msg.BodyFormat = MailFormat.Text;
                SmtpMail.SmtpServer = smtpServer; // gán server web mail
                SmtpMail.Send(msg); // gửi mail
            }
            catch
            {
            }
        }

        public static void SendMailTD(string Subject, string body, string to, string cc ,ListBox  ls)
        {
            try
            {
                var db = new dcDatabaseDataContext(Provider.ConnectionString);
                var From_tam = db.tblRef_Emails.OrderByDescending(p => p.LoaiMail == "1").FirstOrDefault();
                string From = From_tam.Email;
                string Pass = From_tam.Pass;

                MailMessage msg = new MailMessage();
                msg.BodyFormat = MailFormat.Html;
                msg.Body = body;
                string smtpServer = "smtp.gmail.com";
                string userName = From;
                string password = Pass;
                int cdoBasic = 1;
                int cdoSendUsingPort = 2;
                if (userName.Length > 0)
                {
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpServer);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", cdoSendUsingPort);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", cdoBasic);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", userName);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
                }
                if (ls.Items.Count > 0)
                {
                    foreach (var filename in ls.Items)
                    {
                        //Kiểm tra file có tồn tại trong ổ đĩa không
                        if (File.Exists(filename.ToString()))
                        {
                            //Thêm file đính kèm vào tin nhắn
                            msg.Attachments.Add(new MailAttachment(filename.ToString()));
                        }
                    }
                }
                msg.From = userName;
                msg.To = to;
                msg.Cc = cc;
                msg.Subject = Subject;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                SmtpMail.SmtpServer = smtpServer;
                SmtpMail.Send(msg);

            }
            catch
            {
            }
        }

        public static bool SendMail_Luong(string to, string Subject, string body, string[] attFiles = null)
        {
            if (string.IsNullOrWhiteSpace(to) || !Common.Code.SendMailHelper.IsValidEmail(to))
                return false;

            try
            {
                MailMessage msg = new MailMessage();
                msg.BodyFormat = MailFormat.Html;
                msg.Body = body;
                string smtpServer = "smtp.gmail.com";
                string userName = iHRM.Core.Business.Logic.AllLogic.SysPa_Get("mail_u");
                string password = iHRM.Core.Business.Logic.AllLogic.SysPa_Get("mail_p");
                int cdoBasic = 1;
                int cdoSendUsingPort = 587;
                if (userName.Length > 0)
                {
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpServer);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 587);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", cdoSendUsingPort);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", cdoBasic);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", userName);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
                }
                if (attFiles != null && attFiles.Length > 0)
                {
                    foreach (var filename in attFiles)
                    {
                        //Kiểm tra file có tồn tại trong ổ đĩa không
                        if (File.Exists(filename))
                        {
                            //Thêm file đính kèm vào tin nhắn
                            msg.Attachments.Add(new MailAttachment(filename.ToString()));
                        }
                    }
                }
                msg.From = userName;
                msg.To = to;
                msg.Cc = userName;
                msg.Subject = Subject;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                SmtpMail.SmtpServer = smtpServer;
                SmtpMail.Send(msg);

                

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static string getHTML(DataTable dt)
        {
            StringBuilder myBuilder = new StringBuilder();

            myBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            myBuilder.Append("style='border: solid 1px Silver; font-size: x-small;'>");

            myBuilder.Append("<tr align='left' valign='top'>");
            for (int i = 1; i < dt.Columns.Count;i++ )
            {
                myBuilder.Append("<td align='left' valign='top'>");
                myBuilder.Append(dt.Columns[i].ColumnName);
                myBuilder.Append("</td>");
            }
            myBuilder.Append("</tr>");

            foreach (DataRow myRow in dt.Rows)
            {
                myBuilder.Append("<tr align='left' valign='top'>");
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    myBuilder.Append("<td align='left' valign='top'>");
                    myBuilder.Append(myRow[dt.Columns[i].ColumnName].ToString());
                    myBuilder.Append("</td>");
                }
                myBuilder.Append("</tr>");
            }
            myBuilder.Append("</table>");

            return myBuilder.ToString();
        }

        public static void report_ChamCongThang_ChiTiet(DateTime tuNgay, DateTime denNgay, List<String> emp) //Thong Lieu: '19-12-2018'
        {
            dsXuLyQuetThe ds = new dsXuLyQuetThe();

            Provider.LoadData(ds, ds.tbCaLamViec.TableName);

            Provider.LoadData(ds, ds.tbLoaiNgayLamThem.TableName);

            Provider.LoadData(ds, ds.tbNgayNghiPhepNam.TableName);

            Provider.LoadData(ds, ds.tblRef_LeaveType.TableName);

            Provider.LoadDataByProc(ds
                                    , ds.tblEmployee.TableName
                                    , "p_getAlltblEmployee_ByList"
                                    , new SqlParameter("tuNgay", tuNgay)
                                    , new SqlParameter("denNgay", denNgay)
                                    , Provider.CreateParameter_StringList("dtEmpID", emp));

            Provider.LoadDataByProc(ds
                                    , ds.tblEmpDayOff.TableName
                                    , "p_getAllDangKyVangMat_ByList"
                                    , Provider.CreateParameter_StringList("dtEmpID", emp));

            Provider.LoadDataByProc(ds
                                    , ds.tblEmp7hours.TableName
                                    , "p_GetAllEmp7hours_ByList"
                                    , Provider.CreateParameter_StringList("dtEmpID", emp));

            Provider.LoadDataByProc(ds
                                    , ds.tbKetQuaQuetThe.TableName
                                    , "p_duLieuQuetThe_GetAllKetQuaQuetThe_TinhCong_ByList"
                                    , new SqlParameter("tuNgay", tuNgay)
                                    , new SqlParameter("denNgay", denNgay)
                                    , Provider.CreateParameter_StringList("dtEmpID", emp));

            var rs = ds.tbKetQuaQuetThe;

            List<KQQT> _lKQQT = new List<KQQT>();

            List<Emp_KQ> _lEmp_KQ = new List<Emp_KQ>();

            foreach (var i_Emp in ds.tblEmployee)
            {
                Emp_KQ newEmpKQ = new Emp_KQ();

                newEmpKQ.EmployeeID = i_Emp.EmployeeID;

                newEmpKQ.EmployeeName = i_Emp.EmployeeName;

                newEmpKQ.DepName_Final = i_Emp.DepName_Final;

                double SoGio = 0, Cong = 0, TangCa = 0, SoLanTre = 0, SoLanSom = 0, VangKP = 0, SoPhutTre = 0, SoPhutSom = 0, TangCaNgayLe = 0, VangCP = 0, NT = 0, NT2 = 0;

                _lKQQT = new List<KQQT>();

                for (DateTime i = tuNgay; i <= denNgay; i = i.AddDays(1)) // Để hiện thị cả ngày chủ nhật nếu không đăng ký ca làm.
                {
                    KQQT new_KQQT = new KQQT();

                    new_KQQT.ngay = i;

                    _lKQQT.Add(new_KQQT);

                }
                foreach (var i_kqqt in _lKQQT)
                {
                    var _lDr = ds.tbKetQuaQuetThe.Where(p => p.EmployeeID == i_Emp.EmployeeID && p.ngay == i_kqqt.ngay);

                    if (_lDr.Count() == 0)
                    {
                        continue;
                    }

                    var dr = _lDr.FirstOrDefault();

                    i_kqqt.caLam = ds.tbCaLamViec.Where(p => p.id == DbHelper.DrGetGuid(dr, "idCaLam")).FirstOrDefault().ten;

                    SoGio += DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");

                    if (dr["dkLamThem"] == DBNull.Value) // không làm thêm
                    {
                        Cong += DbHelper.DrGetDouble(dr, "kqNgayCong");

                        SoPhutTre += DbHelper.DrGetDouble(dr, "tgDiMuon") > 0 ? DbHelper.DrGetDouble(dr, "tgDiMuon") : 0;

                        if (DbHelper.DrGetDouble(dr, "tgDiMuon") > 0)
                        {
                            SoLanTre++;
                        }

                        SoPhutSom += DbHelper.DrGetDouble(dr, "tgVeSom") > 0 ? DbHelper.DrGetDouble(dr, "tgVeSom") : 0;

                        if (DbHelper.DrGetDouble(dr, "tgVeSom") > 0)
                        {
                            SoLanSom++;
                        }

                        TangCa += DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                    }
                    else // làm thêm
                    {
                        TangCa += DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                    }


                    if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") == "KP")
                    {
                        VangKP++;
                    }

                    string leaveID = DbHelper.DrGetString(dr, "LeaveID");

                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == leaveID).FirstOrDefault();

                    if (leaveType != null && !leaveType.isTinhCong)
                    {
                        if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") != "" && DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") != "KP")
                        {
                            int PerTimeID = DbHelper.DrGetInt(dr, "PerTimeID");

                            if (PerTimeID != 0)
                            {
                                VangCP += PerTimeID == 3 ? 1 : 0.5;
                            }
                        }
                    }

                    if (dr["dkLamThem"] != DBNull.Value)
                    {
                        try
                        {
                            int dkLT = Convert.ToInt16(dr["dkLamThem"]);

                            string tenLoaiLT = ds.tbLoaiNgayLamThem.Where(p => p.id == dkLT).FirstOrDefault().tenLoai;

                            i_kqqt.caLam = i_kqqt.caLam + " - " + tenLoaiLT;
                        }
                        catch (Exception)
                        {
                        }
                        if (DbHelper.DrGetBoolean(dr, "tt_leTet") == true && DbHelper.DrGetDouble(dr, "kqNgayCong") > 0) // A trọng sửa từ dklamthem = 3 sang tt_leTet = true 26/02/2018
                        {
                            TangCaNgayLe += DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                        }
                    }

                    i_kqqt.ngay = DbHelper.DrGetDateTime(dr, "ngay");

                    i_kqqt.tgQuetDen = DbHelper.DrGetTimeSpan(dr, "tgQuetDen");

                    i_kqqt.tgDiMuon = DbHelper.DrGetDouble(dr, "tgDiMuon") > 0 ? DbHelper.DrGetDouble(dr, "tgDiMuon") : 0;

                    i_kqqt.tgQuetVe = DbHelper.DrGetTimeSpan(dr, "tgQuetVe");

                    i_kqqt.tgVeSom = DbHelper.DrGetDouble(dr, "tgVeSom") > 0 ? DbHelper.DrGetDouble(dr, "tgVeSom") : 0;

                    if (dr["dkLamThem"] == DBNull.Value) // không làm thêm
                    {
                        i_kqqt.OT = DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                    }
                    else // làm thêm
                    {
                        i_kqqt.OT = DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                    }
                    if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") != "")
                    {
                        if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") == "KP")
                        {
                            i_kqqt.lyDoNghi = "Không quẹt thẻ";
                        }
                        else
                        {
                            i_kqqt.lyDoNghi = ds.tblRef_LeaveType.Where(p => p.LeaveID == DbHelper.DrGetString(dr, "tt_nghiPhep_Alias")).FirstOrDefault().LeaveType;
                        }
                    }

                    if ((DbHelper.DrGetDouble(dr, "NormalOISDay") + DbHelper.DrGetDouble(dr, "NightOISDay")) > 0 && i_kqqt.lyDoNghi == null)
                    {
                        i_kqqt.lyDoNghi = "Ra vào giữa ca";
                    }

                    i_kqqt.NT = DbHelper.DrGetDouble(dr, "NT");

                    i_kqqt.NT2 = DbHelper.DrGetDouble(dr, "NT2");

                    i_kqqt.TG = DbHelper.DrGetDouble(dr, "WorkingHours") - (DbHelper.DrGetDouble(dr, "NormalOISDay") + DbHelper.DrGetDouble(dr, "NightOISDay"));
                }

                newEmpKQ._lKQQT = _lKQQT;

                newEmpKQ.SoGio = SoGio;

                newEmpKQ.Cong = Cong;

                newEmpKQ.TangCa = TangCa;

                newEmpKQ.SoLanTre = SoLanTre;

                newEmpKQ.SoLanSom = SoLanSom;

                newEmpKQ.VangKP = VangKP;

                newEmpKQ.SoPhutTre = SoPhutTre;

                newEmpKQ.SoPhutSom = SoPhutSom;

                newEmpKQ.TangCaNgayLe = TangCaNgayLe;

                newEmpKQ.VangCP = VangCP;

                _lEmp_KQ.Add(newEmpKQ);

            }

            var rp = new rep_BangCongChiTiet();

            rp.paramTieuDe.Value = string.Format("BẢNG CHI TIẾT CHẤM CÔNG THÁNG {0}", denNgay.Month);

            rp.paramTuNgay.Value = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", tuNgay, denNgay);

            rp.BindData(_lEmp_KQ);

            ReportViewer rv = new ReportViewer();

            rv.ViewReport(rp);
        }

        public static void report_ChamCongThang_ChiTiet_Fake(DateTime tuNgay, DateTime denNgay, List<String> emp) //Thong Lieu: '19-12-2018'
        {
            dsXuLyQuetThe ds = new dsXuLyQuetThe();

            Provider.LoadData(ds, ds.tbCaLamViec.TableName);

            Provider.LoadData(ds, ds.tbLoaiNgayLamThem.TableName);

            Provider.LoadData(ds, ds.tbNgayNghiPhepNam.TableName);

            Provider.LoadData(ds, ds.tblRef_LeaveType.TableName);

            Provider.LoadDataByProc(ds
                                    , ds.tblEmployee.TableName
                                    , "p_getAlltblEmployee_ByList"
                                    , new SqlParameter("tuNgay", tuNgay)
                                    , new SqlParameter("denNgay", denNgay)
                                    , Provider.CreateParameter_StringList("dtEmpID", emp));

            Provider.LoadDataByProc(ds
                                    , ds.tblEmpDayOff.TableName
                                    , "p_getAllDangKyVangMat_ByList"
                                    , Provider.CreateParameter_StringList("dtEmpID", emp));

            Provider.LoadDataByProc(ds
                                    , ds.tblEmp7hours.TableName
                                    , "p_GetAllEmp7hours_ByList"
                                    , Provider.CreateParameter_StringList("dtEmpID", emp));

            Provider.LoadDataByProc(ds
                                    , ds.tbKetQuaQuetThe.TableName
                                    , "p_duLieuQuetThe_GetAllKetQuaQuetThe_Fake_TinhCong_ByList"
                                    , new SqlParameter("tuNgay", tuNgay)
                                    , new SqlParameter("denNgay", denNgay)
                                    , Provider.CreateParameter_StringList("dtEmpID", emp));

            var rs = ds.tbKetQuaQuetThe;

            List<KQQT> _lKQQT = new List<KQQT>();

            List<Emp_KQ> _lEmp_KQ = new List<Emp_KQ>();

            foreach (var i_Emp in ds.tblEmployee)
            {
                Emp_KQ newEmpKQ = new Emp_KQ();

                newEmpKQ.EmployeeID = i_Emp.EmployeeID;

                newEmpKQ.EmployeeName = i_Emp.EmployeeName;

                newEmpKQ.DepName_Final = i_Emp.DepName_Final;

                double SoGio = 0, Cong = 0, TangCa = 0, SoLanTre = 0, SoLanSom = 0, VangKP = 0, SoPhutTre = 0, SoPhutSom = 0, TangCaNgayLe = 0, VangCP = 0, NT = 0, NT2 = 0;

                _lKQQT = new List<KQQT>();

                for (DateTime i = tuNgay; i <= denNgay; i = i.AddDays(1)) // Để hiện thị cả ngày chủ nhật nếu không đăng ký ca làm.
                {
                    KQQT new_KQQT = new KQQT();

                    new_KQQT.ngay = i;

                    _lKQQT.Add(new_KQQT);

                }
                foreach (var i_kqqt in _lKQQT)
                {
                    var _lDr = ds.tbKetQuaQuetThe.Where(p => p.EmployeeID == i_Emp.EmployeeID && p.ngay == i_kqqt.ngay);

                    if (_lDr.Count() == 0)
                    {
                        continue;
                    }

                    var dr = _lDr.FirstOrDefault();

                    i_kqqt.caLam = ds.tbCaLamViec.Where(p => p.id == DbHelper.DrGetGuid(dr, "idCaLam")).FirstOrDefault().ten;

                    SoGio += DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");

                    if (dr["dkLamThem"] == DBNull.Value) // không làm thêm
                    {
                        Cong += DbHelper.DrGetDouble(dr, "kqNgayCong");

                        SoPhutTre += DbHelper.DrGetDouble(dr, "tgDiMuon") > 0 ? DbHelper.DrGetDouble(dr, "tgDiMuon") : 0;

                        if (DbHelper.DrGetDouble(dr, "tgDiMuon") > 0)
                        {
                            SoLanTre++;
                        }

                        SoPhutSom += DbHelper.DrGetDouble(dr, "tgVeSom") > 0 ? DbHelper.DrGetDouble(dr, "tgVeSom") : 0;

                        if (DbHelper.DrGetDouble(dr, "tgVeSom") > 0)
                        {
                            SoLanSom++;
                        }

                        TangCa += DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                    }
                    else // làm thêm
                    {
                        TangCa += DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                    }


                    if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") == "KP")
                    {
                        VangKP++;
                    }

                    string leaveID = DbHelper.DrGetString(dr, "LeaveID");

                    var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == leaveID).FirstOrDefault();

                    if (leaveType != null && !leaveType.isTinhCong)
                    {
                        if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") != "" && DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") != "KP")
                        {
                            int PerTimeID = DbHelper.DrGetInt(dr, "PerTimeID");

                            if (PerTimeID != 0)
                            {
                                VangCP += PerTimeID == 3 ? 1 : 0.5;
                            }
                        }
                    }

                    if (dr["dkLamThem"] != DBNull.Value)
                    {
                        try
                        {
                            int dkLT = Convert.ToInt16(dr["dkLamThem"]);

                            string tenLoaiLT = ds.tbLoaiNgayLamThem.Where(p => p.id == dkLT).FirstOrDefault().tenLoai;

                            i_kqqt.caLam = i_kqqt.caLam + " - " + tenLoaiLT;
                        }
                        catch (Exception)
                        {
                        }
                        if (DbHelper.DrGetBoolean(dr, "tt_leTet") == true && DbHelper.DrGetDouble(dr, "kqNgayCong") > 0) 
                        {
                            TangCaNgayLe += DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                        }
                    }

                    i_kqqt.ngay = DbHelper.DrGetDateTime(dr, "ngay");

                    i_kqqt.tgQuetDen = DbHelper.DrGetTimeSpan(dr, "tgQuetDen");

                    i_kqqt.tgDiMuon = DbHelper.DrGetDouble(dr, "tgDiMuon") > 0 ? DbHelper.DrGetDouble(dr, "tgDiMuon") : 0;

                    i_kqqt.tgQuetVe = DbHelper.DrGetTimeSpan(dr, "tgQuetVe");

                    i_kqqt.tgVeSom = DbHelper.DrGetDouble(dr, "tgVeSom") > 0 ? DbHelper.DrGetDouble(dr, "tgVeSom") : 0;

                    if (dr["dkLamThem"] == DBNull.Value) // không làm thêm
                    {
                        i_kqqt.OT = DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                    }
                    else // làm thêm
                    {
                        i_kqqt.OT = DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");
                    }
                    if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") != "")
                    {
                        if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") == "KP")
                        {
                            i_kqqt.lyDoNghi = "Không quẹt thẻ";
                        }
                        else
                        {
                            i_kqqt.lyDoNghi = ds.tblRef_LeaveType.Where(p => p.LeaveID == DbHelper.DrGetString(dr, "tt_nghiPhep_Alias")).FirstOrDefault().LeaveType;
                        }
                    }

                    if ((DbHelper.DrGetDouble(dr, "NormalOISDay") + DbHelper.DrGetDouble(dr, "NightOISDay")) > 0 && i_kqqt.lyDoNghi == null)
                    {
                        i_kqqt.lyDoNghi = "Ra vào giữa ca";
                    }

                    i_kqqt.NT = DbHelper.DrGetDouble(dr, "NT");

                    i_kqqt.NT2 = DbHelper.DrGetDouble(dr, "NT2");

                    i_kqqt.TG = DbHelper.DrGetDouble(dr, "WorkingHours") - (DbHelper.DrGetDouble(dr, "NormalOISDay") + DbHelper.DrGetDouble(dr, "NightOISDay"));
                }

                newEmpKQ._lKQQT = _lKQQT;

                newEmpKQ.SoGio = SoGio;

                newEmpKQ.Cong = Cong;

                newEmpKQ.TangCa = TangCa;

                newEmpKQ.SoLanTre = SoLanTre;

                newEmpKQ.SoLanSom = SoLanSom;

                newEmpKQ.VangKP = VangKP;

                newEmpKQ.SoPhutTre = SoPhutTre;

                newEmpKQ.SoPhutSom = SoPhutSom;

                newEmpKQ.TangCaNgayLe = TangCaNgayLe;

                newEmpKQ.VangCP = VangCP;

                _lEmp_KQ.Add(newEmpKQ);

            }

            var rp = new rep_BangCongChiTiet();

            rp.paramTieuDe.Value = string.Format("BẢNG CHI TIẾT CHẤM CÔNG THÁNG {0}", denNgay.Month);

            rp.paramTuNgay.Value = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", tuNgay, denNgay);

            rp.BindData(_lEmp_KQ);

            ReportViewer rv = new ReportViewer();

            rv.ViewReport(rp);
        }

    }
}
