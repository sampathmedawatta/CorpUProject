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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int class_preferance_id { get; set; }

        [ForeignKey("applicant_id")]
        public ApplicantEntity Applicant { get; set; }

        [ForeignKey("class_type_id")]
        public ClassTypeEntity ClassType { get; set; }

    }
}
