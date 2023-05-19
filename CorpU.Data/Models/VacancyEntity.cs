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
        public int vacancy_type_id { get; set; }

        [ForeignKey("vacancy_type_id")]
        public VacancyTypeEntity vacancyType { get; set; }
        [Required]
        public int class_type_id { get; set; }

        [ForeignKey("class_type_id")]
        public ClassTypeEntity classType { get; set; }
        [Required]
        public int emp_id { get; set; }

        [ForeignKey("emp_id")]
        public EmployeeEntity employee { get; set; }

        [Required]
        public int unit_id { get; set; }

        [ForeignKey("unit_id")]
        public UnitEntity unit { get; set; }

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
