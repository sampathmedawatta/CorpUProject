using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Aplicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class ApplicantAvailabilityProfile : Profile
    {
        public ApplicantAvailabilityProfile()
        {
            //Get
            CreateMap<ApplicantAvailabilityEntity, ApplicantAvailabilityDto>();
            
            CreateMap<ApplicantAvailabilityEntity, ApplicantAvailabilityDto>()
            .ForPath(dest =>
            dest.applicant.applicant_id,
            opt => opt.MapFrom(src => src.Applicant.applicant_id));

            //Set
            CreateMap<ApplicantAvailabilityDto, ApplicantAvailabilityEntity>();
            CreateMap<ApplicantAvailabilityDto, ApplicantAvailabilityEntity>()
            .ForPath(dest =>
            dest.Applicant.applicant_id,
            opt => opt.MapFrom(src => src.applicant.applicant_id));
        }
    }
}
