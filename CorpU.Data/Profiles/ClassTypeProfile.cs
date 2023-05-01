﻿using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Referance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class ClassTypeProfile : Profile
    {
        public ClassTypeProfile()
        {
            //Get
            CreateMap<ClassTypeEntity, ClassTypeDto>();
            
            //Set
            CreateMap<ClassTypeDto, ClassTypeEntity>();
           
        }
    }
}