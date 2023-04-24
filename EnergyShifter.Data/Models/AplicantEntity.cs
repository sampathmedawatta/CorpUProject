using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyShifter.Data.Models
{
    public class AplicantEntity
    {
        [Key]
        [MaxLength(10)]
        public int aplicant_id { get; set; }
        [MaxLength(50)]
        public string eame { get; set; }
        [MaxLength(250)]
        public string email { get; set; }
        [MaxLength(256)]
        public string password { get; set; }
        [MaxLength(50)]
        public string resume_url { get; set; }
        public bool status { get; set; }
    }
}
