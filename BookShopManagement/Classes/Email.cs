using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BookShopManagement.Classes
{
    class Email
    {
        private string email = "StudentDataSchool@gmail.com";
        private string password = "KeLaNiYa";



        public void send(string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("StudentDataSchool@gmail.com");
            mail.To.Add("albertlinconnr@gmail.com");
            mail.Subject = "Test Mail - 1";
            mail.Body = body;

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment("C:/Users/HP/Desktop/ticket.jpg");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
        public void emailPromotions(string promotion)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("StudentDataSchool@gmail.com");
            mail.To.Add("albertlinconnr@gmail.com");
            mail.Subject = "Test Mail - 1";
            mail.Body = promotion;

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment("C:/Users/HP/Desktop");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}
