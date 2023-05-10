using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Common.Communication
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private IHostingEnvironment _env;

        public EmailSender(EmailSettings emailConfig, IHostingEnvironment env)
        {
            _emailSettings = emailConfig;
            _env = env;
        }
        public async Task SendEmailAsync(Message message)
        {

        }

    }
}
