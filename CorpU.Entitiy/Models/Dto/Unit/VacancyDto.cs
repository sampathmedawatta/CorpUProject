using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Unit
{
    public class VacancyDto
    {
        [JsonPropertyName("vacancy_id")]
        public int vacancy_id { get; set; }

        [JsonPropertyName("vacancy_type_id")]
        public int vacancy_type_id { get; set; }

        [JsonPropertyName("class_type_id")]
        public int class_type_id { get; set; }

        [JsonPropertyName("emp_id")]
        public int emp_id { get; set; }

        [JsonPropertyName("unit_id")]
        public int unit_id { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("publish_date")]
        public DateTime publish_date { get; set; }
        [JsonPropertyName("closing_date")]
        public DateTime closing_date { get; set; }
        [JsonPropertyName("status")]
        public bool status { get; set; }
    }
}
