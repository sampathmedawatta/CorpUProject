using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class QualificationTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int qualification_type_id { get; set; }
        [Required]
        [MaxLength(50)]
        public string description { get; set; }
        [Required]
        public bool status { get; set; }
    }
}
