using CorpU.Entitiy.Models.Dto.Application;
using CorpU.Entitiy.Models.Dto.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Application
{
    public class ApplicationRegisterDto
    {
        [JsonPropertyName("applicant_id")]
        public int applicant_id { get; set; }

        [JsonPropertyName("resumeUrl")]
        public string resume_url { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }
    }
}
