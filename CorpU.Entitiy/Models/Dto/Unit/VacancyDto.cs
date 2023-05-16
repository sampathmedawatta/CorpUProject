using CorpU.Entitiy.Models.Dto.Employee;
using CorpU.Entitiy.Models.Dto.Referance;
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
        [JsonPropertyName("vacancyId")]
        public int vacancy_id { get; set; }

        [JsonPropertyName("vacancyTypeId")]
        public int vacancy_type_id { get; set; }

        [JsonPropertyName("classTypeId")]
        public int class_type_id { get; set; }

        [JsonPropertyName("empId")]
        public int emp_id { get; set; }

        [JsonPropertyName("unitId")]
        public int unit_id { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("publishDate")]
        public DateTime publish_date { get; set; }

        [JsonPropertyName("closingDate")]
        public DateTime closing_date { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }

        [JsonPropertyName("vacancyType")]
        public VacancyTypeDto vacancyType { get; set; }

        [JsonPropertyName("classType")]
        public ClassTypeDto classType { get; set; }

        [JsonPropertyName("employee")]
        public EmployeeDto employee { get; set; }

        [JsonPropertyName("unit")]
        public UnitDto unit { get; set; }        
    }
}
