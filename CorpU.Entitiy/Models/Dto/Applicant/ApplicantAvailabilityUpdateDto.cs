using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Applicant
{
    public class ApplicantAvailabilityUpdateDto
    {
        [JsonPropertyName("appAvailabilityId")]
        public int app_availability_id { get; set; }

        [JsonPropertyName("applicant_id")]
        public int applicant_id { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime start_date { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime end_date { get; set; }

    }
}
