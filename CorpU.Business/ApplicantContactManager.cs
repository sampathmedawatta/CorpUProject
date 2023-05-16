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
    public class ApplicantContactManager : IApplicantContactManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public ApplicantContactManager(IUnitOfWork unitOfWork, IEmailManager emailManager, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
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
        public async Task<ApplicantContactDetailDto> CreateApplicantContactAsync(ApplicantContactRegisterDto entity)
        {
            ApplicantContactDetailDto applicantContactDto = new ApplicantContactDetailDto();
            applicantContactDto.applicant_id = entity.applicant_id;
            applicantContactDto.phone = entity.phone;
            applicantContactDto.address_line1 = entity.address_line1;
            applicantContactDto.address_line2 = entity.address_line2;
            applicantContactDto.state = entity.state;
            applicantContactDto.postcode = entity.postcode;

            var applicantReuslt = await _unitOfWork.ApplicantContact.Insert(applicantContactDto);

            var applicantContact = await GetByIdAsync(applicantContactDto.applicant_id);
            return applicantContact;
        }
        public async Task<OperationResult> UpdateApplicantContactAsync(ApplicantContactUpdateDto entity)
        {
            try
            {
                ApplicantContactDetailDto applicantContactDto = new ApplicantContactDetailDto();
                applicantContactDto.app_contact_id = entity.app_contact_id;
                applicantContactDto.applicant_id=entity.applicant_id;
                applicantContactDto.phone= entity.phone;
                applicantContactDto.address_line1= entity.address_line1;
                applicantContactDto.address_line2= entity.address_line2;
                applicantContactDto.state= entity.state;
                applicantContactDto.postcode = entity.postcode;
                var applicantReuslt = await _unitOfWork.ApplicantContact.Update(applicantContactDto);

                var applicant = await GetByIdAsync(applicantContactDto.applicant_id);

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
