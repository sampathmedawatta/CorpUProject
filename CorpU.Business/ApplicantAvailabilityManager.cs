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
    public class ApplicantAvailabilityManager : IApplicantAvailabilityManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;

        public ApplicantAvailabilityManager(IUnitOfWork unitOfWork, IEmailManager emailManager, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
        }

        public async Task<ApplicantAvailabilityDto> GetByIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.ApplicantAvailability.GetByIdAsync(Id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<ApplicantAvailabilityDto>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.ApplicantAvailability.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<ApplicantAvailabilityDto> CreateApplicantAvailabilityAsync(ApplicantAvailabilityRegisterDto entity)
        {
            ApplicantAvailabilityDto applicantavailabilityDto = new ApplicantAvailabilityDto();
            applicantavailabilityDto.applicant_id=entity.applicant_id;
            applicantavailabilityDto.start_date=entity.start_date;
            applicantavailabilityDto.end_date=entity.end_date;

            var applicantReuslt = await _unitOfWork.ApplicantAvailability.Insert(applicantavailabilityDto);

            var applicantAvailability = await GetByIdAsync(applicantavailabilityDto.applicant_id);
            return applicantAvailability;
        }
        public async Task<OperationResult> UpdateApplicantAvailabilityAsync(ApplicantAvailabilityUpdateDto entity)
        {
            try
            {
                ApplicantAvailabilityDto applicantAvailabilityDto = new ApplicantAvailabilityDto();
                applicantAvailabilityDto.app_availability_id = entity.app_availability_id;
                applicantAvailabilityDto.applicant_id = entity.applicant_id;
                applicantAvailabilityDto.start_date = entity.start_date;
                applicantAvailabilityDto.end_date = entity.end_date;
                var applicantReuslt = await _unitOfWork.ApplicantAvailability.Update(applicantAvailabilityDto);

                var applicant = await GetByIdAsync(applicantAvailabilityDto.applicant_id);

                _or = new OperationResult
                {
                    Message = "Availability successfully updated.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicant
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Availability update faild!",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
            return _or;
        }
    }
}
