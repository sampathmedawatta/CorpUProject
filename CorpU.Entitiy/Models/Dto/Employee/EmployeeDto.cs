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
        [JsonPropertyName("empId")]
        public int emp_id { get; set; }

        [JsonPropertyName("empName")]
        public string emp_name { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("phone")]
        public string phone { get; set; }

        [JsonPropertyName("empRoleId")]
        public int emp_role_id { get; set; }

        [JsonPropertyName("employeeRole")]
        public EmployeeRoleDto employeeRole { get; set; }

        [JsonPropertyName("userId")]
        public int user_id { get; set; }

        [JsonPropertyName("user")]
        public UserDto user { get; set; }

        [JsonPropertyName("facultyId")]
        public int faculty_id { get; set; }

        [JsonPropertyName("faculty")]
        public FacultyDto faculty { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }
    }
}
