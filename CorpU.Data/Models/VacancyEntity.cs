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

        [ForeignKey("vacancy_type_id")]
        public VacancyTypeEntity VacancyType { get; set; }

        
        [ForeignKey("class_type_id")]
        public ClassTypeEntity ClassType { get; set; }

        
        [ForeignKey("emp_id")]
        public EmployeeEntity Employee { get; set; }

        
        [ForeignKey("unit_id")]
        public UnitEntity Unit { get; set; }


        [MaxLength(250)]
        public string title { get; set; }
        [MaxLength(100)]
        public string description { get; set; }
        public DateTime publish_date { get; set; }
        public DateTime closing_date { get; set; }
        public bool status { get; set; }
    }
}
