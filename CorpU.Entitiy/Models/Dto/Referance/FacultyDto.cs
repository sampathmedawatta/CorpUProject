using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Referance
{
    public class FacultyDto
    {
        [JsonPropertyName("facultyId")]
        public int faculty_id { get; set; }

        [JsonPropertyName("facultyName")]
        public string faculty_name { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }
    }
}
