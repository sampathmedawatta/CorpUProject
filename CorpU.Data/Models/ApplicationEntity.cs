using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class ApplicationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Application_id { get; set; }
        [Required]
        public int applicant_id { get; set; }

        [ForeignKey("applicant_id")]
        public ApplicantEntity Applicant { get; set; }

        [Required]
        [MaxLength(250)]
        public string resume_url { get; set; }

        [Required]
        [ForeignKey("vacancy_id")]
        public int vacancy_id { get; set; }


        [Required]
        [MaxLength(250)]
        public string status { get; set; }


    }
}
