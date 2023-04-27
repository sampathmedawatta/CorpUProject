using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class QualificationTypeEntity
    {
        [Key]
        public int qualification_type_id { get; set; }

        [MaxLength(50)]
        public string description { get; set; }

        public bool status { get; set; }
    }
}
