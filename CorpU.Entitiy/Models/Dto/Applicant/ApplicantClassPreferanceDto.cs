using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Applicant
{
    public class ApplicantClassPreferanceDto
    {
        [JsonPropertyName("classPreferanceId")]
        public int class_preferance_id { get; set; }

        [JsonPropertyName("applicant")]
        public ApplicantDto applicant { get; set; }

        [JsonPropertyName("classTypeId")]
        public int class_type_id { get; set; }

    }
}
