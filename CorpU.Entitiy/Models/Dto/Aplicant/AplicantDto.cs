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
    public class AplicantDto
    {
        [JsonPropertyName("aplicantId")]
        public int aplicant_id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("name")]
        public string email { get; set; }

        [JsonPropertyName("userId")]
        public int user_id { get; set; }

        [JsonPropertyName("user")]
        public UserDto User { get; set; }

    }
}
