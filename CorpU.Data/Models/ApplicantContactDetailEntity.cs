using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class ApplicantContactDetailEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int app_contact_id { get; set; }
        [Required]
        public int applicant_id { get; set; }

        [ForeignKey("applicant_id")]
        public ApplicantEntity Applicant { get; set; }
        [Required]
        public int phone { get; set; }
        [Required]
        [MaxLength(250)]
        public string address_line1 { get; set; }
        [Required]
        [MaxLength(250)]
        public string address_line2 { get; set; }
        [Required]
        [MaxLength(10)]
        public string state { get; set; }
        [Required]
        public int postcode { get; set; }
    }
}
