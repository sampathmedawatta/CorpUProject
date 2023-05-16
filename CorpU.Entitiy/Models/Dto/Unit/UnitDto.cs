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
        [JsonPropertyName("unitId")]
        public int unit_id { get; set; }

        [JsonPropertyName("unitName")]
        public string unit_name { get; set; }

        [JsonPropertyName("unitCode")]
        public string unit_code { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }
    }
}
