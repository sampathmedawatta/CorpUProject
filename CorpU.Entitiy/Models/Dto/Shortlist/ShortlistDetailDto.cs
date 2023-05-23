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
        [JsonPropertyName("shortlistId")]
        public int shortlist_id { get; set; }

        [JsonPropertyName("applicationId")]
        public int Application_id { get; set; }

        [JsonPropertyName("empId")]
        public int emp_id { get; set; }

        [JsonPropertyName("interviewDate")]
        public DateTime interview_date { get; set; }

        [JsonPropertyName("interviewTime")]
        public TimeSpan interview_time { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("comments")]
        public string comments { get; set; }

        [JsonPropertyName("application")]
        public ApplicationDto application { get; set; }

        [JsonPropertyName("employee")]
        public EmployeeDto employee { get; set; }
    }
}
