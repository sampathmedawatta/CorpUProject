using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;
using System.Net;

namespace CorpU.Business
{
    public class ApplicantManager : IApplicantManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public ApplicantManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
        }
        public async Task<ApplicantDto> GetByIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.Applicants.GetByIdAsync(Id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<ApplicantDto>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Applicants.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<ApplicantDto>> SearchApplicantAsync(string name)
        {
            try
            {
                return await _unitOfWork.Applicants.SearchApplicantAsync(name);
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<ApplicantDto> CreateApplicantAsync(ApplicantRegisterDto entity)
        {
            ApplicantDto applicantDto = new ApplicantDto();
            applicantDto.user_id = entity.user_id;
            applicantDto.name = entity.name;
            applicantDto.email = entity.email;
            applicantDto.resume_url = entity.resume_url;
            applicantDto.status = false;

            var applicantReuslt = await _unitOfWork.Applicants.Insert(applicantDto);

            var applicant = await GetByIdAsync(applicantDto.applicant_id);
            return applicant;
        }
        public async Task<OperationResult> UpdateEmployeeAsync(ApplicantUpdateDto entity)
        {
            try
            {
                ApplicantDto applicantDto = new ApplicantDto();

                applicantDto.applicant_id=entity.applicant_id;
                applicantDto.name = entity.name;
                applicantDto.email = entity.email;
                applicantDto.status = entity.status;
                applicantDto.resume_url = entity.resume_url;

                var applicantReuslt = await _unitOfWork.Applicants.Update(applicantDto);

                var applicant = await GetByIdAsync(applicantDto.applicant_id);

                _or = new OperationResult
                {
                    Message = "Employee successfully updated.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicant
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Employee update faild!",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
            return _or;
        }
    }
}
