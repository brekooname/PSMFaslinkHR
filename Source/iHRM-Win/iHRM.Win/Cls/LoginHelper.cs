using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace iHRM.Win
{
    public class LoginHelper
    {
        public static dcDatabaseDataContext db;
        public static Interface_Company Context;
        private static w5sysUser u = null;
     

        private static tbConnectionInfo _cnInfor = null;
        public static tbConnectionInfo ConnectionInfo
        {
            get
            {
                if (_cnInfor != null)
                    return _cnInfor;

                _cnInfor = new tbConnectionInfo();
                _cnInfor.id = Guid.NewGuid();
                _cnInfor.IPAdress = GetLocalIPAddress();
                _cnInfor.DomainName = Environment.UserDomainName;
                _cnInfor.MachineName = Environment.MachineName;
                _cnInfor.OperationSystem = Environment.Is64BitOperatingSystem ? "Window 64bit" : "Window 32bit";
                _cnInfor.OSVersion = Environment.OSVersion.VersionString;
                _cnInfor.sHRM_version = win_globall.updater_ver;

                var db1 = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);
                db1.tbConnectionInfos.InsertOnSubmit(_cnInfor);
                db1.SubmitChanges();

                return _cnInfor;
            }
        }
        public static tblRef_Company Company { get; set; }
        public static w5sysUser user
        {
            get
            {
                if (u != null)
                    return u;

                var uu = new w5sysUser();
                uu.caption = "TK Khách";
                return uu;
            }
            set
            {
                u = value;
            }
        }
        public static DataRow Dept { get; set; }

        public static string Database { get; set; }

        public static string langTrans { get; set; }
        public static bool isLogin
        {
            get { return u != null; }
        }

        public static w5sysRule getRightAccess(long function)
        {
            w5sysRule r = null;
            try { r = user.w5sysRole.w5sysRules.SingleOrDefault(i => i.functionID == function); } catch { }
            if (r == null)
                r = new w5sysRule();
            return r;
        }

        public static bool loginin(string id, string pw)
        {
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            u = db.w5sysUsers.SingleOrDefault(i => i.loginID == id && i.loginPW == pw);
            Company = db.tblRef_Companies.FirstOrDefault();
            if (u == null)
            {
                GUIHelper.MessageError("Tài khoản hoặc mật khẩu không đúng! Xin vui lòng kiểm tra lại.", "Đăng nhập");
            }
            try
            {
                if (u.w5sysRole != null)
                {
                    int ii = u.w5sysRole.w5sysRules.Count;
                    ii = u.w5sysRole.w5sysRules.Count;
                    ii = u.w5sysRole.w5sysRules.Select(i => i.w5sysFunction.parentId).Count();
                    if (Config.appConfig.language.Trim().ToUpper() == "ENGLISH")
                        langTrans = "EN";
                    else
                        if (Config.appConfig.language.Trim().ToUpper() == "KOREAN")
                            langTrans = "KR";
                        else
                            langTrans = "VN";
                }
                Context = new Interface_Company();
            }
            catch { }

            return true;
        }

        public static void logout()
        {
            u = null;
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "";
        }
    }
}
