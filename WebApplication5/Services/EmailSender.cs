using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplication5.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        public MailJetOptions _mailJetOptions;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _mailJetOptions = _config.GetSection("MailJet").Get<MailJetOptions>();

            MailjetClient client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey)
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
               .Property(Send.Messages, new JArray {
                new JObject {
                 {"From", new JObject {
                  {"Email", "youssefsaidhassan@protonmail.com"},
                  {"Name", "Medical Checker"}
                  }},
                 {"To", new JArray {
                  new JObject {
                   {"Email", "passenger1@mailjet.com"},
                   {"Name", "passenger 1"}
                   }
                  }},
                 {"Subject", subject},
                 
                 {"HTMLPart", htmlMessage}
                 }
                   });
            MailjetResponse response = await client.PostAsync(request);
            //if (response.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
            //    Console.WriteLine(response.GetData());
            //}
            //else
            //{
            //    Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
            //    Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
            //    Console.WriteLine(response.GetData());
            //    Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            //}
        }
    }
}
    
