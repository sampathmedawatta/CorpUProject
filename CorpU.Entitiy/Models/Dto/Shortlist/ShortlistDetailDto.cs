using CorpU.Entitiy.Models.Dto.Shortlist;
using CorpU.Entitiy.Models.Dto.Application;
using CorpU.Entitiy.Models.Dto.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Shortlist
{
    public class ShortlistDetailDto
    {
        [JsonPropertyName("shortlist_id")]
        public int shortlist_id { get; set; }

        [JsonPropertyName("Application_id")]
        public int Application_id { get; set; }

        [JsonPropertyName("employee_id")]
        public int emp_id { get; set; }

        [JsonPropertyName("interview_date")]
        public DateTime interview_date { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("comments")]
        public string comments { get; set; }

        [JsonPropertyName("Application")]
        public ApplicationDto application { get; set; }

        [JsonPropertyName("Employee")]
        public EmployeeRegisterDto employee { get; set; }
    }
}
