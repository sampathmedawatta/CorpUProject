using CorpU.Entitiy.Models.Dto.Referance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Applicant
{
    public class ApplicantQualificationRegisterDto
    {
        [JsonPropertyName("applicant_id")]
        public int applicant_id { get; set; }

        [JsonPropertyName("qualificationType")]
        public int qualification_type_id { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("institute")]
        public string institute { get; set; }

        [JsonPropertyName("awarded_date")]
        public DateTime awarded_date { get; set; }
    }
}
