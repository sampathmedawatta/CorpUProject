using AutoMapper;
using CorpU.Common;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models.Dto.Aplicant;
using CorpU.Entitiy.Models.Dto.User;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string ConnectionString;
        private DataContext Context
        {
            get
            {
                return new DataContext(ConnectionString);
            }
        }

        public IAplicantRepository<AplicantDto> Aplicants { get; private set; }
        public IUserRepository<UserDto> Users { get; private set; }
        public UnitOfWork(IOptions<AppSettings> appSetting, IMapper mapper)
        {

            ConnectionString = appSetting.Value.DBConnection;
            Aplicants = new AplicantRepository(Context, mapper);
            Users = new UserRepository(Context, mapper);
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
