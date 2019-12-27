using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Service
{
    public interface IEmailSender
    {
        AuthMessageSenderOptions Options { get; }

        void Execute(string apiKey, string subject, string message, string email, string fromEmail, string fromName, string EmailAdministrador, string SenhaEmailAdministrador);
        void SendEmailAsync(string email, string subject, string message, string fromEmail, string fromName, string EmailAdministrador, string SenhaEmailAdministrador);
    }

    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //PEGA DO APPSETTINGS MESMO E QUE SE DANE :p

        public void SendEmailAsync(string email, string subject, string message, string fromEmail, string fromName, string EmailAdministrador, string SenhaEmailAdministrador)
        {
            Execute(Options.SendGridKey, subject, message, email, fromEmail, fromName, EmailAdministrador, SenhaEmailAdministrador);
        }

        public void Execute(string apiKey, string subject, string message, string email, string fromEmail, string fromName, string EmailAdministrador, string SenhaEmailAdministrador)
        {

            //contato.mensagem = contato.mensagem.Replace("\n", "<br>");

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,

                Credentials = new System.Net.NetworkCredential(EmailAdministrador, SenhaEmailAdministrador)
            };

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage
            {
                Subject = subject,

                From = new MailAddress(fromEmail, fromName),
                Body = message,
                IsBodyHtml = true
            };

            mail.To.Add(new MailAddress(email));
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            smtpClient.Send(mail);
        }

    }
}
