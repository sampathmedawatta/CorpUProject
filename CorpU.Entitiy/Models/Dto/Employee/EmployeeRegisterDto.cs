using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Employee
{
    public class EmployeeRegisterDto
    {
        [JsonPropertyName("empName")]
        public string emp_name { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("phone")]
        public string phone { get; set; }

        [JsonPropertyName("facultyId")]
        public int faculty_id { get; set; }

        [JsonPropertyName("empRoleId")]
        public int emp_role_id { get; set; }

    }
}
