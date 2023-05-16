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
    public class ApplicantQualificationManager : IApplicantQualificationManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public ApplicantQualificationManager(IUnitOfWork unitOfWork, IEmailManager emailManager, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
        }
        public async Task<ApplicantQualificationDto> GetByIdAsync(int Id)
        {
            try
            {
                return await _unitOfWork.ApplicantQualification.GetByIdAsync(Id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<ApplicantQualificationDto> CreateApplicantQualificationAsync(ApplicantQualificationRegisterDto entity)
        {
            ApplicantQualificationDto applicantQualificationDto = new ApplicantQualificationDto();
            applicantQualificationDto.applicant_id = entity.applicant_id;
            applicantQualificationDto.qualification_type_id=entity.qualification_type_id;
            applicantQualificationDto.description = entity.description;
            applicantQualificationDto.institute=entity.institute;
            applicantQualificationDto.awarded_date= entity.awarded_date;

            var applicantQualificationReuslt = await _unitOfWork.ApplicantQualification.Insert(applicantQualificationDto);

            var applicantContact = await GetByIdAsync(applicantQualificationDto.applicant_id);
            return applicantContact;
        }
        public async Task<OperationResult> UpdateApplicantQualificationAsync(ApplicantQualificationUpdateDto entity)
        {
            try
            {
                ApplicantQualificationDto applicantQualificationDto = new ApplicantQualificationDto();
                applicantQualificationDto.app_qualification_id = entity.app_qualification_id;
                applicantQualificationDto.applicant_id=entity.applicant_id;
                applicantQualificationDto.qualification_type_id = entity.qualification_type_id;
                applicantQualificationDto.description=entity.description;
                applicantQualificationDto.institute = entity.institute;
                applicantQualificationDto.awarded_date= entity.awarded_date;
                var applicantReuslt = await _unitOfWork.ApplicantQualification.Update(applicantQualificationDto);

                var applicantQualification = await GetByIdAsync(applicantQualificationDto.applicant_id);

                _or = new OperationResult
                {
                    Message = "Applicant Qualification successfully updated.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = applicantQualification
                };
            }
            catch (Exception ex)
            {
                _or = new OperationResult
                {
                    Message = "Error: Applicant Qualification update faild!",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Data = null
                };
            }
            return _or;
        }
    }
}
