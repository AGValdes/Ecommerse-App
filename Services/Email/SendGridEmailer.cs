using Ecommerce_App.Services.Email.Interfaces;
using Ecommerce_App.Services.Email.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Services.Email
{
    public class SendGridEmailer : IEmail
    {
        public IConfiguration Configuration { get; set; }

        public SendGridEmailer(IConfiguration config)
        {
            Configuration = config;
        }
        public async Task<EmailResponse> SendEmailAsync(Message message)
        {
            string apiKey = Configuration["SendGrid:Key"];
            string fromEmail = Configuration["SendGrid:fsDefaultFromAddress"];
            string fromName = Configuration["SendGrid:DefaultFromName"];

            var client = new SendGridClient(apiKey);

            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress(fromEmail, fromName));
            msg.AddTo(message.To);
            msg.SetSubject(message.Subject);
            msg.AddContent(MimeType.Html, message.Body);

            var sendGridResponse = await client.SendEmailAsync(msg);

            EmailResponse response = new EmailResponse()
            {
                WasSent = sendGridResponse.IsSuccessStatusCode
            };
            return response;
        }
    }
}
