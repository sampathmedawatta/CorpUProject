using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class VacancyTypeEntity
    {
        [Key]
        public int vacancy_type_id { get; set; }

        [MaxLength(250)]
        public string vacancy_name { get; set; }

        public bool status { get; set; }
    }
}
