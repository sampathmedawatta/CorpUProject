using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Aplicant
{
    public class AplicantDto
    {
        [JsonPropertyName("aplicantId")]
        public string applicant_id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("name")]
        public string email { get; set; }
        [JsonPropertyName("password")]
        public string password { get; set; }
    }
}
