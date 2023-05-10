using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Common.Communication
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string TemplateName { get; set; }
        public dynamic Data { get; set; }

        public Message(string subject, string templateName, dynamic data)
        {
            //To = new List<MailboxAddress>();

            //To.AddRange(to.Select(x => new MailboxAddress("",x)));
            Subject = subject;
            TemplateName = templateName;
            Data = data;
        }
    }
}
