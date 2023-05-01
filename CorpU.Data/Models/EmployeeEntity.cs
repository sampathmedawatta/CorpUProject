using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class EmployeeEntity
    {
        
        public int emp_id { get; set; }
       
        [ForeignKey("emp_role_id")]
        public int emp_role_id { get; set; }
        public EmployeeRoleEntity EmployeeRole { get; set; }

        [MaxLength(100)]
        public string emp_name { get; set; }
        [MaxLength(250)]
        public string email { get; set; }
        public string phone { get; set; }

        [ForeignKey("faculty_id")]
        public int faculty_id { get; set; }
        public FacultyEntity Faculty { get; set; }

        public bool status { get; set; }
    }
}
