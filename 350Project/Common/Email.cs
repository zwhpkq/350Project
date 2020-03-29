using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace _350Project.Common
{
    public class Email
    {
        public static void SendEmail( string mailbody, string email) {
            MailMessage mailMessage = new MailMessage("lightweightworkout@hotmail.com",email);
            mailMessage.Subject = "Thank You For Registation";
            mailMessage.Body = mailbody;
            SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "lightweightworkout@hotmail.com",
                Password = "Lnr95116"
            };
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
        }
    }
}