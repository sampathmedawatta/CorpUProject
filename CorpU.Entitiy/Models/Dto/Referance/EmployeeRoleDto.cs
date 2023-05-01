using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Referance
{
    public class EmployeeRoleDto
    {
        [JsonPropertyName("emp_role_id")]
        public int emp_role_id { get; set; }

        [JsonPropertyName("role_name")]
        public string role_name { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }


    }
}
