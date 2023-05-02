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

        [ForeignKey("applicant_id")]
        public ApplicantEntity Applicant { get; set; }
        public int phone { get; set; }
        [MaxLength(250)]
        public string address_line1 { get; set; }
        [MaxLength(250)]
        public string address_line2 { get; set; }
        [MaxLength(10)]
        public string state { get; set; }
        public int postcode { get; set; }
    }
}
