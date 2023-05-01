using CorpU.Entitiy.Models.Dto.Referance;
using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.Employee
{
    public class EmployeeDto
    {
        [JsonPropertyName("emp_id")]
        public int emp_id { get; set; }

        [JsonPropertyName("empRoleId")]
        public int emp_role_id { get; set; }

        [JsonPropertyName("employeeRole")]
        public EmployeeRoleDto EmployeeRole { get; set; }

        [JsonPropertyName("userId")]
        public int user_id { get; set; }

        [JsonPropertyName("user")]
        public UserDto User { get; set; }

        [JsonPropertyName("emp_name")]
        public string emp_name { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("phone")]
        public string phone { get; set; }

        [JsonPropertyName("faculty_id")]
        public string faculty_id { get; set; }

        [JsonPropertyName("faculty")]
        public FacultyDto Faculty { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }
    }
}
