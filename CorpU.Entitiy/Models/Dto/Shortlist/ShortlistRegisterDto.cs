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
    public class ShortlistRegisterDto
    {
        [JsonPropertyName("applicationId")]
        public int Application_id { get; set; }

        [JsonPropertyName("empId")]
        public int emp_id { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("comments")]
        public string comments { get; set; }
    }
}
