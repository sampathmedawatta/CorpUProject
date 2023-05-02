using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class VacancyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vacancy_id { get; set; }
        [Required]
        [ForeignKey("vacancy_type_id")]
        public VacancyTypeEntity VacancyType { get; set; }
        [Required]
        [ForeignKey("class_type_id")]
        public ClassTypeEntity ClassType { get; set; }
        [Required]
        [ForeignKey("emp_id")]
        public EmployeeEntity Employee { get; set; }
        [Required]
        [ForeignKey("unit_id")]
        public UnitEntity Unit { get; set; }
        [Required]
        [MaxLength(250)]
        public string title { get; set; }
        [Required]
        [MaxLength(100)]
        public string description { get; set; }
        [Required]
        public DateTime publish_date { get; set; }
        [Required]
        public DateTime closing_date { get; set; }
        [Required]
        public bool status { get; set; }
    }
}
