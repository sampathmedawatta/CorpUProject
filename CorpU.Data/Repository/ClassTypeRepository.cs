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
    internal class ClassTypeRepository : IClassTypeRepository<ClassTypeDto>
    {
        private readonly DataContext context;
        private readonly DbSet<ClassTypeEntity> table;
        private readonly IMapper _mapper;
        public ClassTypeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<ClassTypeEntity>();
            _mapper = mapper;
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClassTypeDto>> GetAllAsync()
        {
            try
            {
                var classTypeList = await table
                   .ToListAsync();

                return _mapper.Map<IEnumerable<ClassTypeDto>>(classTypeList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ClassTypeDto> GetByIdAsync(int id)
        {
            try
            {
                var classType = await table
                    .Where(e => e.class_type_id == id)
                    .FirstOrDefaultAsync();

                return _mapper.Map<ClassTypeEntity, ClassTypeDto>(classType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<int> Insert(ClassTypeDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ClassTypeDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
