using CorpU.Entitiy.Models.Dto.Referance;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace CorpU.Business.Interfaces

{

    public interface IEmployeeRoleManager : IBaseManager

    {

        Task<EmployeeRoleDto> GetByIdAsync(int id);

        //Task<IEnumerable<EmployeeRoleDto>> GetAllAsync();

    }

}





