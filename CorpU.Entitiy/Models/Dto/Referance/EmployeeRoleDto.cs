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
        [JsonPropertyName("empRoleId")]
        public int emp_role_id { get; set; }

        [JsonPropertyName("roleName")]
        public string role_name { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }


    }
}
