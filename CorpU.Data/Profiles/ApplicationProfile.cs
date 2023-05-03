﻿using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //Get
            CreateMap<ApplicationEntity, ApplicationDto>();
            CreateMap<ApplicationEntity, ApplicationDto>()
            .ForPath(dest =>
           dest.applicant.applicant_id,
           opt => opt.MapFrom(src => src.Applicant.applicant_id));

            //Set
            CreateMap<ApplicationDto, ApplicationEntity>();
            CreateMap<ApplicationDto, ApplicationEntity>()
            .ForPath(dest =>
           dest.Applicant.applicant_id,
           opt => opt.MapFrom(src => src.applicant.applicant_id));
        }
    }
}
