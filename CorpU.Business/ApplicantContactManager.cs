using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;

namespace CorpU.Business
{
    public class ApplicantContactManager : IApplicantContactManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        public ApplicantContactManager(IUnitOfWork unitOfWork, IEmailManager emailManager, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
        }
        public async Task<ApplicantContactDetailDto> GetByIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.ApplicantContact.GetByIdAsync(Id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
    }
}
