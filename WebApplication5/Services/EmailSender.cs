using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplication5.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //freemedicalcare@​yahoo.com
            /*FMC123@*/
            var fromMail = "freemedicalcare@​yahoo.com";
            var fromPassword = "FMC123@";
            var message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(email);
            message.Body = $"<html><body>{htmlMessage}</body></html>";
            message.IsBodyHtml = true;
            var SmtpClient = new SmtpClient("smtp.mail.gmail.com")
            {
                Port = 465,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl=true

            };

            SmtpClient.Send(message);

                }
    }
}
