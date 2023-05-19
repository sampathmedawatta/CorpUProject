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

        [JsonPropertyName("applicationId")]
        public int Application_id { get; set; }

        [JsonPropertyName("applicantId")]
        public int applicant_id { get; set; }

        [JsonPropertyName("resumeUrl")]
        public string resume_url { get; set; }

        [JsonPropertyName("vacancyId")]
        public int vacancy_id { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("applicant")]
        public ApplicantDto applicant { get; set; }

        [JsonPropertyName("vacancy")]
        public VacancyDto vacancy { get; set; }

    }
}
