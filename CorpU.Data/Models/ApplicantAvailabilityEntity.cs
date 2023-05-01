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
        public int app_availability_id { get; set; }

        [ForeignKey("aplicant_id")]
        public int aplicant_id { get; set; }
        public AplicantEntity Aplicant { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }
    }
}
