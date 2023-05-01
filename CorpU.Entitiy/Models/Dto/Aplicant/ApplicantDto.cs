using CorpU.Entitiy.Models.Dto.Referance;
using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Aplicant
{
    public class ApplicantDto
    {
        [JsonPropertyName("applicantId")]
        public int applicant_id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("name")]
        public string email { get; set; }

        [JsonPropertyName("user")]
        public UserDto user { get; set; }

    }
}
