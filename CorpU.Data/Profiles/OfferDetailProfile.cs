using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Shortlist;
using CorpU.Entitiy.Models.Dto.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class OfferDetailProfile:Profile
    {
        public OfferDetailProfile() 
        {
            CreateMap<OfferDetailEntity, OfferDetailDto>();
            CreateMap<OfferDetailEntity, OfferDetailDto>()
            .ForPath(dest =>
           dest.application.Application_id,
           opt => opt.MapFrom(src => src.Application_id));
            CreateMap<OfferDetailDto, OfferDetailEntity>();
        }
    }
}
