using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class ApplicantAvailabilityEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int app_availability_id { get; set; }
        [Required]
        public int applicant_id { get; set; }

        [ForeignKey("applicant_id")]
        public ApplicantEntity applicant { get; set; }
        [MaxLength(10)]
        public string monday { get; set; }
        [MaxLength(10)]
        public string tuesday { get; set; }
        [MaxLength(10)]
        public string wednesday { get; set; }
        [MaxLength(10)]
        public string thursday { get; set; }
        [MaxLength(10)]
        public string friday { get; set; }
        
    }
}
