using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository
{
    internal class ApplicantQualificationRepository : IApplicantQualificationRepository<ApplicantQualificationDto>
    {
        private readonly DataContext context;
        private readonly DbSet<ApplicantQualificationEntiry> table;
        private readonly IMapper _mapper;
        public ApplicantQualificationRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<ApplicantQualificationEntiry>();
            _mapper = mapper;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicantQualificationDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicantQualificationDto> GetByIdAsync(int id)
        {
            try
            {
                var applicantQualification = await table
                    .Where(e => e.Applicant.applicant_id == id)
                    .Include(u => u.Applicant)
                    .Include (c => c.QualificationType)
                    .FirstOrDefaultAsync();

                return _mapper.Map<ApplicantQualificationEntiry, ApplicantQualificationDto>(applicantQualification);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Insert(ApplicantQualificationDto entity)
        {
            try
            {
                ApplicantQualificationEntiry applicantQualificationEntity;
                applicantQualificationEntity = _mapper.Map<ApplicantQualificationDto, ApplicantQualificationEntiry>(entity);

                this.context.Set<ApplicantQualificationEntiry>().Add(applicantQualificationEntity);
                int excecutedRows = await this.context.SaveChangesAsync();

                entity.app_qualification_id = applicantQualificationEntity.app_qualification_id;
                return excecutedRows;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> Update(ApplicantQualificationDto entity)
        {
            try
            {
                ApplicantQualificationEntiry? ApplicantQualification = await table
                    .Where(c => c.app_qualification_id == entity.app_qualification_id)
                    .Where(d => d.applicant_id == entity.applicant_id)
                    .FirstOrDefaultAsync();

                if (ApplicantQualification != null)
                {
                    //ApplicantContact.app_contact_id=entity.app_contact_id;
                    //ApplicantContact.applicant_id=entity.applicant_id;
                    ApplicantQualification.qualification_type_id = entity.qualification_type_id;
                    ApplicantQualification.description = entity.description;
                    ApplicantQualification.awarded_date = entity.awarded_date;
                    ApplicantQualification.institute=entity.institute;
                    int excecutedRows = await this.context.SaveChangesAsync();

                    return excecutedRows;
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
