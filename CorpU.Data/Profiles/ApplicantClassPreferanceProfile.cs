﻿using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class ApplicantClassPreferanceProfile : Profile
    {
        public ApplicantClassPreferanceProfile()
        {
            //Get
            CreateMap<ApplicantClassPreferanceEntity, ApplicantClassPreferanceDto>();
            CreateMap<ApplicantClassPreferanceEntity, ApplicantClassPreferanceDto>()
            .ForPath(dest =>
           dest.applicant.applicant_id,
           opt => opt.MapFrom(src => src.Applicant.applicant_id));

            //Set
            CreateMap<ApplicantClassPreferanceDto, ApplicantClassPreferanceEntity>();
            
        }
    }
}
