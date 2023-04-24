using AutoMapper;
using CorpU.Data.Models;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Aplicant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository
{
    internal class AplicantRepository : IAplicantRepository<AplicantDto>
    {
        private readonly DataContext context;
        private readonly DbSet<AplicantEntity> table;
        private readonly IMapper _mapper;

        public AplicantRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            table = context.Set<AplicantEntity>();
            _mapper = mapper;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AplicantDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AplicantDto>> GetAllByEmailAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AplicantDto>> GetAllByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AplicantDto>> GetAllByStatusAsync(int Status)
        {
            throw new NotImplementedException();
        }

        public Task<AplicantDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(AplicantDto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(AplicantDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
