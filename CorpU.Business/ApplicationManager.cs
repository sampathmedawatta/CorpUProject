using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Application;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;
using System.Net;

namespace CorpU.Business
{
    public class ApplicationManager : IApplicationManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public ApplicationManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
        }
        public async Task<ApplicationDto> GetByApplicantIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.Application.GetByApplicantIdAsync(Id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<ApplicationDto> GetByApplicationIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.Application.GetByApplicationIdAsync(Id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<ApplicationDto>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Application.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
    }
}
