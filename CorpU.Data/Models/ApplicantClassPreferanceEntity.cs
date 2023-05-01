using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class ApplicantClassPreferanceEntity
    {
        [Key]
        public int class_preferance_id { get; set; }

        [ForeignKey("aplicant_id")]
        public int aplicant_id { get; set; }
        public AplicantEntity Aplicant { get; set; }

        [ForeignKey("class_type_id")]
        public int class_type_id { get; set; }
        public ClassTypeEntity ClassType { get; set; }

    }
}
