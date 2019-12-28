using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Ecommerce.Servicies.Interface;
using Ecommerce.ViewModels;
using Microsoft.Extensions.Options;

namespace Ecommerce.Servicies.Manager
{
    public class EmailSender : IEmailSender
    {
        private SmtpOptions _smtpOptions { get; }

        /// <summary>
        /// Email Sender Information
        /// </summary>
        /// <param name="smtpOptions">smtp Options</param>
        public EmailSender(
            IOptions<SmtpOptions> smtpOptions)
        {
           
            _smtpOptions = smtpOptions.Value;
        }
        /// <summary>
        /// This will send email for required operations.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public  async Task SendEmailAsync(string email, string subject, string message)
        {
            var body = message;
            var bodymessage = new MailMessage();
            bodymessage.To.Add(new MailAddress(email, email));
            bodymessage.From = new MailAddress(_smtpOptions.FromEmail, _smtpOptions.FromFullName);
            bodymessage.Subject = subject;
            bodymessage.Body = body;
            bodymessage.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _smtpOptions.SmtpUserName,
                    Password = _smtpOptions.SmtpPassword
                };
                smtp.Credentials = credential;
                smtp.Host = _smtpOptions.SmtpHost;
                smtp.Port = _smtpOptions.SmtpPort;
                smtp.EnableSsl = _smtpOptions.SmtpSSL;
                await smtp.SendMailAsync(bodymessage);

            }
        }
    }
}
