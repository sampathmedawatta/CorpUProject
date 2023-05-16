using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Referance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IQualificationManager : IBaseManager
    {
        Task<QualificationTypeDto> GetByIdAsync(int id);
        Task<IEnumerable<QualificationTypeDto>> GetAllAsync();
    }
}
