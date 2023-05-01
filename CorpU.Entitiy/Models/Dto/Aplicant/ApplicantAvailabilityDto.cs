using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Aplicant
{
    public class ApplicantAvailabilityDto
    {
        [JsonPropertyName("app_availability_id")]
        public int app_availability_id { get; set; }

        [JsonPropertyName("applicant")]
        public ApplicantDto applicant { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime start_date { get; set; }
        
        [JsonPropertyName("end_date")]
        public DateTime end_date { get; set; }

    }
}
