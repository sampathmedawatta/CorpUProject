using CorpU.Entitiy.Models.Dto.Aplicant;
using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAplicantRepository<ApplicantDto> Aplicants { get; }
        IUserRepository<UserDto> Users { get; }
        int Complete();

    }
}
