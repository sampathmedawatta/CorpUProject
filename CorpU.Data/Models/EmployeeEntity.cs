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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int emp_id { get; set; }
        [Required]
        [ForeignKey("emp_role_id")]
        public EmployeeRoleEntity EmployeeRole { get; set; }
        [Required]
        [ForeignKey("user_id")]
        public UserEntity User { get; set; }
        [Required]
        [MaxLength(100)]
        public string emp_name { get; set; }
        [Required]
        [MaxLength(250)]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        [ForeignKey("faculty_id")]
        public FacultyEntity Faculty { get; set; }
        [Required]
        public bool status { get; set; }
    }
}
