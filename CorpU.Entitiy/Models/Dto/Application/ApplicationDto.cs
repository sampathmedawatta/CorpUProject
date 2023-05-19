using CorpU.Entitiy.Models.Dto.Application;
using CorpU.Entitiy.Models.Dto.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CorpU.Entitiy.Models.Dto.Unit;

namespace CorpU.Entitiy.Models.Dto.Application
{
    public class ApplicationDto
    {

        [JsonPropertyName("ApplicationId")]
        public int Application_id { get; set; }

        [JsonPropertyName("applicant_id")]
        public int applicant_id { get; set; }

        [JsonPropertyName("resumeUrl")]
        public string resume_url { get; set; }

        [JsonPropertyName("vacancyId")]
        public int vacancy_id { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("Applicant")]
        public ApplicantDto applicant { get; set; }


    }
}
