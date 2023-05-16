using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Applicant
{
    public class ApplicantQualificationUpdateDto
    {
        [JsonPropertyName("appQualificationId")]
        public int app_qualification_id { get; set; }

        [JsonPropertyName("applicant_id")]
        public int applicant_id { get; set; }

        [JsonPropertyName("qualificationTypeId")]
        public int qualification_type_id { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("institute")]
        public string institute { get; set; }

        [JsonPropertyName("awarded_date")]
        public DateTime awarded_date { get; set; }
    }
}
