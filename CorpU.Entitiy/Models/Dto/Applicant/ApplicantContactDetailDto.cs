using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Applicant
{
    public class ApplicantContactDetailDto
    {
        [JsonPropertyName("appContactId")]
        public int app_contact_id { get; set; }
        [JsonPropertyName("applicantId")]
        public int applicant_id { get; set;}

        [JsonPropertyName("phone")]
        public int phone { get; set; }
        [JsonPropertyName("addressLine1")]
        public string address_line1 { get; set; }
        [JsonPropertyName("addressLine2")]
        public string address_line2 { get; set; }
        [JsonPropertyName("state")]
        public string state { get; set; }
        [JsonPropertyName("postcode")]
        public int postcode { get; set; }
        [JsonPropertyName("applicant")]
        public ApplicantDto applicant { get; set; }
    }
}
