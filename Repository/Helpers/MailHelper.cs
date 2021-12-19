using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Entity.Models;

namespace Repository.Helpers
{
    public class MailHelper
    {
        private string Host { get; set; }
        private int Port { get; set; }
        private string Password { get; set; }
        private string BaseMail { get; set; }
        private bool SSL { get; set; }
        public MailHelper( string BaseMail, string Password, bool SSL)
        {
            this.Host = Host;
            this.Port = Port;
            this.Password = Password;
            this.BaseMail = BaseMail;
            this.SSL = SSL;
        }


        public bool Send(string address, string message)
        {
            User user = SessionHelper.DefaultSession;
            var mail = new SmtpClient
            {
                Credentials = new System.Net.NetworkCredential(BaseMail, Password),
                EnableSsl = SSL
            };
            var mailSending = new MailMessage
            {
                IsBodyHtml = true,
                Priority = MailPriority.High,
                From = new MailAddress(BaseMail)
            };

            try
            {
                mailSending.To.Clear();
                mailSending.To.Add(address);
                mailSending.Subject = "Donör-Hasta Uygulaması";
                mailSending.Body = message + "<br><br><br>" + "<b>Gönderen: </b><label>"+user.FirstName+" "+user.LastName+"</label><br><b>Email: </b><label>"+user.Mail+"</label><br><b>Kullanıcı Tipi: </b><label>"+user.UserType+"</label>";
                mail.Send(mailSending);
                return true;
            }
            catch
            {
                return false;
            }


        }

    }
}
