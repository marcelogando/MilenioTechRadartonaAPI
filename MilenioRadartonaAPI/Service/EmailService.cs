using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Service
{
    public interface IEmailSender
    {
        AuthMessageSenderOptions Options { get; }

        Task Execute(string apiKey, string subject, string message, string email, string fromEmail, string fromName);
        Task SendEmailAsync(string email, string subject, string message, string fromEmail, string fromName);
    }

    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //PEGA DO APPSETTINGS MESMO E QUE SE DANE :p

        public Task SendEmailAsync(string email, string subject, string message, string fromEmail, string fromName)
        {
            return Execute(Options.SendGridKey, subject, message, email, fromEmail, fromName);
        }

        public Task Execute(string apiKey, string subject, string message, string email, string fromEmail, string fromName)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }

    }
}
