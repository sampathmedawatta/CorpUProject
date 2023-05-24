using CorpU.Data.Models;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Shortlist;
using CorpU.Entitiy.Models.Dto.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IOfferManager : IBaseManager
    {
        Task<OfferDetailDto> GetOfferByApplicationId(int id);
        Task<IEnumerable<OfferDetailDto>> GetAllOfferAsync();
        Task<OfferDetailDto> CreateOfferAsync(OfferRegisterDto entity);
        //Task<OperationResult> UpdateShortlistAsync(ShortlistUpdateDto entity);
    }
}