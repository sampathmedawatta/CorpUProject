﻿using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;

namespace CorpU.Business
{
    public class ApplicantManager : IApplicantManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        public ApplicantManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
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
    }
}
