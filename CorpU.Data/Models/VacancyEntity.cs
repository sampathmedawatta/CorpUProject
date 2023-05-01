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
        public int vacancy_id { get; set; }

        [ForeignKey("vacancy_type_id")]
        public int vacancy_type_id { get; set; }
        public VacancyTypeEntity VacancyType { get; set; }

        
        [ForeignKey("class_type_id")]
        public int class_type_id { get; set; }
        public ClassTypeEntity ClassType { get; set; }

        
        [ForeignKey("emp_id")]
        public int emp_id { get; set; }
        public EmployeeEntity Employee { get; set; }

        
        [ForeignKey("unit_id")]
        public int unit_id { get; set; }
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
