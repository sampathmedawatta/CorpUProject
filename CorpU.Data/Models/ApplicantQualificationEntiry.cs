using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class ApplicantQualificationEntiry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int app_qualification_id { get; set; }
        [Required]
        [ForeignKey("applicant_id")]
        public ApplicantEntity Applicant { get; set; }
        [Required]
        [ForeignKey("qualification_type_id")]
        public QualificationTypeEntity QualificationType { get; set; }
        [Required]
        [MaxLength(250)]
        public string description { get; set; }
        [Required]
        public DateTime awarded_date { get; set; }
        [Required]
        [MaxLength(150)]
        public string institute { get; set; }
    }
}
