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
                    .FirstOrDefaultAsync();

                return _mapper.Map<ApplicantQualificationEntiry, ApplicantQualificationDto>(applicantQualification);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<int> Insert(ApplicantQualificationDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ApplicantQualificationDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
