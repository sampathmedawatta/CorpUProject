﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Common.Communication
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
        Task SendInterviewEmailAsync(Message message);
    }
}
