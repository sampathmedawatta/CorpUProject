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
        public int Application_id { get; set; }

        [ForeignKey("aplicant_id")]
        public int aplicant_id { get; set; }
        public AplicantEntity Aplicant { get; set; }

        [MaxLength(250)]
        public string resume_url { get; set; }
        
        [MaxLength(250)]
        public string status { get; set; }
        

    }
}
