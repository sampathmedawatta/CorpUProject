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

        [JsonPropertyName("applicantId")]
        public int applicant_id { get; set; }

        [JsonPropertyName("monday")]
        public string monday { get; set; }
        [JsonPropertyName("tuesday")]
        public string tuesday { get; set; }
        [JsonPropertyName("wednesday")]
        public string wednesday { get; set; }
        [JsonPropertyName("thursday")]
        public string thursday { get; set; }
        [JsonPropertyName("friday")]
        public string friday { get; set; }

    }
}
