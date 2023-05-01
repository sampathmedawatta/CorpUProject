using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Referance
{
    public class QualificationTypeDto
    {
        [JsonPropertyName("qualification_type_id")]
        public int qualification_type_id { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }
    }
}
