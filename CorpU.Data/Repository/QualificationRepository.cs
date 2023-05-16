using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Referance;
using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpU.Entitiy.Models.Dto.Applicant;

namespace CorpU.Data.Repository
{
    internal class QualificationRepository : IQualificationRepository<QualificationTypeDto>
    {
        private readonly DataContext context;
        private readonly DbSet<QualificationTypeEntity> table;
        private readonly IMapper _mapper;
        public QualificationRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<QualificationTypeEntity>();
            _mapper = mapper;
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QualificationTypeDto>> GetAllAsync()
        {
            try
            {
                var qualificationList = await table
                   .ToListAsync();

                return _mapper.Map<IEnumerable<QualificationTypeDto>>(qualificationList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<QualificationTypeDto> GetByIdAsync(int id)
        {
            try
            {
                var qualification = await table
                    .Where(e => e.qualification_type_id == id)
                    .FirstOrDefaultAsync();

                return _mapper.Map<QualificationTypeEntity, QualificationTypeDto>(qualification);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<int> Insert(QualificationTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(QualificationTypeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
