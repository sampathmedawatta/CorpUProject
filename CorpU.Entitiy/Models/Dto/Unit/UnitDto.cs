using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Unit
{
    public class UnitDto
    {
        [JsonPropertyName("unit_id")]
        public int unit_id { get; set; }

        [JsonPropertyName("unit_name")]
        public string unit_name { get; set; }

        [JsonPropertyName("unit_code")]
        public string unit_code { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }
    }
}
