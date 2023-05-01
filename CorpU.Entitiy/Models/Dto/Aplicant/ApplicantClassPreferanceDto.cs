using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Aplicant
{
    public class ApplicantClassPreferanceDto
    {
        [JsonPropertyName("class_preferance_id")]
        public int class_preferance_id { get; set; }

        [JsonPropertyName("aplicantId")]
        public int aplicant_id { get; set; }

        [JsonPropertyName("class_type_id")]
        public int class_type_id { get; set; }

    }
}
