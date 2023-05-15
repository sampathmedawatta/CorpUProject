﻿using CorpU.Data.Models;
using CorpU.Entitiy.Models.Dto.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Business.Interfaces
{
    public interface IApplicantQualificationManager : IBaseManager
    {
        Task<ApplicantQualificationDto> GetByIdAsync(int id);
    }
}