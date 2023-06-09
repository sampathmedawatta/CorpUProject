﻿using AutoMapper;
using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Get
            CreateMap<UserEntity, UserDto>();
            
            CreateMap<UserEntity, UserDto>()
               .ForPath(dest =>
              dest.user_role_id,
              opt => opt.MapFrom(src => src.user_role_id));

            //Set
            CreateMap<UserDto, UserEntity>();
            
           
        }
    }
}
