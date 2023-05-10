using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Common.Communication;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Communication;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business
{
    public class EmailManager : IEmailManager
    {
        private IOptions<EmailSettings> _emailSettings;
        private IEmailSender _emailSender;
        private IUnitOfWork _unitOfWork;
        OperationResult _or;

        public EmailManager(IOptions<EmailSettings> emailSettings, IEmailSender emailSender, IUnitOfWork unitOfWork)
        {
            _emailSettings = emailSettings;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> SendPaymentSuccessfulEmail()
        {
            var emailDto = new EmailDto();
            emailDto.ToEmail = "test@gmail.com";
            emailDto.SenderName = "Test corpU";


            await SendEmail(emailDto);

            _or = new OperationResult
            {
                Message = "Email sent successfully",
                StatusCode = (int)HttpStatusCode.OK,
                Data = null
            };

            return _or;
        }

        private async Task SendEmail(EmailDto emailDto)
        {
            var message = new Message(subject: "Account Activation", templateName: "ActivateAccount.html", data: emailDto);
            await _emailSender.SendEmailAsync(message);
        }
    }
}
