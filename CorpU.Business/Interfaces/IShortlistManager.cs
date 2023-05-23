using CorpU.Data.Models;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Shortlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IShortlistManager: IBaseManager
    {
        Task<ShortlistDetailDto> GetShortlistByApplicationId(int id);
        Task<IEnumerable<ShortlistDetailDto>> GetAllShortlistAsync();
        Task<ShortlistDetailDto> CreateShortlistAsync(ShortlistRegisterDto entity);
        Task<OperationResult> UpdateShortlistAsync(ShortlistUpdateDto entity);
    }
}
