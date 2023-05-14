using CorpU.Entitiy.Models.Dto.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Application
{
    public class ApplicationDto
    {

        [JsonPropertyName("Application_id")]
        public int Application_id { get; set; }

        [JsonPropertyName("applicant")]
        public ApplicantDto applicant { get; set; }

        [JsonPropertyName("resume_url")]
        public string resume_url { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

    }
}
