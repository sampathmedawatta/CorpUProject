using CorpU.Entitiy.Models.Communication;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CorpU.Common.Enum;

namespace CorpU.Common.Communication
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private IHostingEnvironment _env;

        //TODO add logger and audit
        public EmailSender(EmailSettings emailConfig, IHostingEnvironment env)
        {
            _emailSettings = emailConfig;
            _env = env;
        }
        public async Task SendEmailAsync(Message message)
        {
            try
            {
                var emailMessage = CreateEmailMessage(message);
                await SendAsync(emailMessage);
            }
            catch (Exception e)
            {

            }
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var adminEmails = _emailSettings.AdminEmails;
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.From));
            emailMessage.To.AddRange(GetToEmail(message));
            emailMessage.Bcc.AddRange(adminEmails.Select(x => new MailboxAddress("Admins", x)));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = BuildMailBody(message) };

            return emailMessage;
        }

        private List<MailboxAddress> GetToEmail(Message message)
        {
            var returnVal = new List<MailboxAddress>();

            if (message.Data.GetType() == typeof(EmailDto))
            {
                var dataObject = (EmailDto)message.Data;
                returnVal.Add(new MailboxAddress(dataObject.SenderName, dataObject.ToEmail));
            }
            else
            {
                throw new Exception("Email field is empty!");
            }

            return returnVal;
        }

        //Todo: Change the body accordingly
        private string BuildMailBody(Message message)
        {
            var messageBody = string.Empty;
            var webRoot = _env.WebRootPath;
            if (string.IsNullOrWhiteSpace(_env.WebRootPath))
            {
                _env.WebRootPath = Directory.GetCurrentDirectory();
            }
            var pathToFile = _env.WebRootPath + Path.DirectorySeparatorChar.ToString() + "EmailTemplates" + Path.DirectorySeparatorChar.ToString() + message.TemplateName;
            var builder = new BodyBuilder();

                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                messageBody = string.Format(builder.HtmlBody," this is the message body");

            return messageBody;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, true);
                    await client.AuthenticateAsync(_emailSettings.UserName, _emailSettings.Password);
                    await client.SendAsync(mailMessage);
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
            }
        }
    }
}
