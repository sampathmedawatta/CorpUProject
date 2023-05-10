using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Common.Communication;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Communication;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
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
        private IEmailSender _emailSender;
        private IUnitOfWork _unitOfWork;
        OperationResult _or;

        public EmailManager(IEmailSender emailSender, IUnitOfWork unitOfWork)
        {
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> SendAccountSuccessfulEmail(EmployeeDto employeeDto, UserDto userDto)
        {
            var emailDto = new EmailDto
            {
                ToEmail = employeeDto.email,
                Name = employeeDto.emp_name,
                UserDto = userDto,
                EmployeeDto = employeeDto
            };

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
