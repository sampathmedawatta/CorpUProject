using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Applicant
{
    public class ApplicantRegisterDto
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("email")]
        public string email { get; set; }
        [JsonPropertyName("userId")]
        public int user_id { get; set; }

        [JsonPropertyName("resumeUrl")]
        public string resume_url { get; set; }
    }
}
