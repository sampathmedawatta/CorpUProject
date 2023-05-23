using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Repository.Interfaces
{
    public interface IEmployeeRoleRepository<T> : IRepository<T> where T : class
    {

    }
}
