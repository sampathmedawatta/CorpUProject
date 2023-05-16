using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Referance
{
    public class VacancyTypeDto
    {
        [JsonPropertyName("vacancyTypeId")]
        public int vacancy_type_id { get; set; }

        [JsonPropertyName("vacancyName")]
        public string vacancy_name { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }
    }
}
