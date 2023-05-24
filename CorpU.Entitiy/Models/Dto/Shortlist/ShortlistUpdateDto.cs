using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Shortlist
{
    public class ShortlistUpdateDto
    {
        [JsonPropertyName("shortlistId")]
        public int shortlist_id { get; set; }

        [JsonPropertyName("applicationId")]
        public int Application_id { get; set; }

        [JsonPropertyName("empId")]
        public int emp_id { get; set; }

        [JsonPropertyName("location")]
        public string location { get; set; }

        [JsonPropertyName("timeslot")]
        public string timeslot { get; set; }

        [JsonPropertyName("interviewDate")]
        public string interview_date { get; set; }

        [JsonPropertyName("interviewTime")]
        public string interview_time { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("comments")]
        public string comments { get; set; }
    }
}
