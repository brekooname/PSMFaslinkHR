using System;
using System.Collections.Generic;
using System.Web;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Linq;
using System.Net;

namespace iHRM.Common.Code
{
    /// <summary>
    /// Summary description for sendMail
    /// </summary>
    public class SendMailHelper
    {
        static string _mailServer = "smtp.gmail.com"; //"smtp.gmail.com";
        static int _mailPort = 587; //587; // Work well, 465 Timeout
        
        string _user, _pass;

        public SendMailHelper(string user, string password)
        {
            _user = user; _pass = password;
        }

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="to">tới, cách nhau bởi [;]</param>
        /// <param name="subject">tiêu đề</param>
        /// <param name="body">nội dung</param>
        /// <returns></returns>
        public bool sendMailTo(string to, string subject, string body)
        {
            return sendMailTo(_user, to, "", "", subject, body, "");
        }

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="from">từ</param>
        /// <param name="to">tới, cách nhau bởi [;]</param>
        /// <param name="cc">cc="", cách nhau bởi [;]</param>
        /// <param name="bcc">bcc="", cách nhau bởi [;]</param>
        /// <param name="subject">tiêu đề</param>
        /// <param name="body">nội dung</param>
        /// <param name="attachment">đính kèm file="", cách nhau bởi [;]</param>
        /// <returns></returns>
        public bool sendMailTo(string from, string to, string cc, string bcc, string subject, string body, string attachment)
        {
            if (!IsValidEmail(from))
            {
                throw new Exception("email from not in-vaild");
            }

            MailMessage mailMessage = new MailMessage();
            SmtpClient mailClient = new SmtpClient(_mailServer, _mailPort);
            mailClient.Timeout = 15000;
            mailClient.UseDefaultCredentials = false; // no work
            mailClient.Credentials = new NetworkCredential(_user, _pass);
            mailClient.EnableSsl = true;
            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress(from);
            mailMessage.Subject = subject;
            addMailAddress(mailMessage.To, to);
            addMailAddress(mailMessage.CC, cc);
            addMailAddress(mailMessage.Bcc, bcc);
            mailMessage.Body = body;
            addMailAttachment(mailMessage.Attachments, attachment);

            try
            {
                mailClient.Send(mailMessage);
                return true;
            }
            catch
            {
                if (globall.indebug)
                    throw;
                return false;
            }
        }

        private static void addMailAddress(MailAddressCollection m, string add)
        {
            if (string.IsNullOrEmpty(add)) return;

            if (add.IndexOf(';') > 0)
            {
                string[] tos = add.Split(';');
                foreach (string too in tos)
                    m.Add(too);
            }
            else
            {
                m.Add(add);
            }
        }
        private static void addMailAttachment(AttachmentCollection m, string att)
        {
            if (string.IsNullOrEmpty(att)) return;

            if (att.IndexOf(';') > 0)
            {
                string[] a = att.Split(';');
                foreach (string i in a)
                    m.Add(new Attachment(i));
            }
            else
            {
                m.Add(new Attachment(att));
            }
        }

        public static bool IsValidEmail(string email)
        {
            //regular expression pattern for valid email
            //addresses, allows for the following domains:
            //com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
            //string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
            string pattern = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            //Regular expression object
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            //boolean variable to return to calling method
            bool valid = false;

            //make sure an email address was provided
            if (string.IsNullOrEmpty(email))
            {
                valid = false;
            }
            else
            {
                //use IsMatch to validate the address
                valid = check.IsMatch(email);
            }
            //return the value to the calling method
            return valid;
        }
        public static bool IsValidDate(string date)
        { //regular expression pattern for valid email
            //addresses, allows for the following domains:
            //com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
            //string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
            string pattern = @"(((0[1-9]|[12][0-9]|3[01])([-./])(0[13578]|10|12)([-./])(\d{4}))|(([0][1-9]|[12][0-9]|30)([-./])(0[469]|11)([-./])(\d{4}))|((0[1-9]|1[0-9]|2[0-8])([-./])(02)([-./])(\d{4}))|((29)(\.|-|\/)(02)([-./])([02468][048]00))|((29)([-./])(02)([-./])([13579][26]00))|((29)([-./])(02)([-./])([0-9][0-9][0][48]))|((29)([-./])(02)([-./])([0-9][0-9][2468][048]))|((29)([-./])(02)([-./])([0-9][0-9][13579][26])))";
            //Regular expression object
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            //boolean variable to return to calling method
            bool valid = false;

            //make sure an email address was provided
            if (string.IsNullOrEmpty(date))
            {
                valid = false;
            }
            else
            {
                //use IsMatch to validate the address
                valid = check.IsMatch(date);
            }
            //return the value to the calling method
            return valid;
        }
    }
}