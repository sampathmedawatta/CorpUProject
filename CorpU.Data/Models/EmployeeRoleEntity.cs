using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class EmployeeRoleEntity
    {
        [Key]
        public int emp_role_id { get; set; }

        [MaxLength(250)]
        public string role_name { get; set; }

        public bool status { get; set; }
    }
}
