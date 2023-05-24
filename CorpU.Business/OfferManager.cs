using CorpU.Business.Interfaces;
using CorpU.Common;
using CorpU.Data.Repository.Interfaces;
using CorpU.Entitiy.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using CorpU.Entitiy.Models.Dto.Shortlist;
using CorpU.Entitiy.Models.Dto.Unit;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business
{
    public class OfferManager : IOfferManager
    {
        private IUnitOfWork _unitOfWork;
        readonly AuthenticationOptions _AuthenticationOptions;
        OperationResult _or;
        public OfferManager(IUnitOfWork unitOfWork, IOptions<PasswordSettings> passwordSettings)
        {
            _unitOfWork = unitOfWork;
            _AuthenticationOptions = new AuthenticationOptions(passwordSettings.Value);
            this._or = new OperationResult();
        }
        public async Task<OfferDetailDto> GetOfferByApplicationId(int id)
        {
            try
            {
                return await _unitOfWork.Offer.GetByIdAsync(id);

            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<IEnumerable<OfferDetailDto>> GetAllOfferAsync()
        {
            try
            {
                return await _unitOfWork.Offer.GetAllAsync();
            }
            catch (Exception ex)
            {
                //TODO log error and haddle the error
            }
            return null;
        }
        public async Task<OfferDetailDto> CreateOfferAsync(OfferRegisterDto entity)
        {
            OfferDetailDto offerDto = new OfferDetailDto();
            offerDto.Application_id = entity.Application_id;
            offerDto.offer_date= entity.offer_date;
            offerDto.notes = entity.notes;
            offerDto.status = entity.status;

            var offerReuslt = await _unitOfWork.Offer.Insert(offerDto);

            var offer = await GetOfferByApplicationId(offerDto.Application_id);
            return offerDto;
        }
    }
}
