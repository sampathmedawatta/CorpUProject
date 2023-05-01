using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class AplicantEntity
    {
        [Key]
        public int aplicant_id { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        [MaxLength(250)]
        public string email { get; set; }

        [ForeignKey("user_id")]
        public int user_id { get; set; }
        public UserEntity User { get; set; }

        [MaxLength(50)]
        public string resume_url { get; set; }
        public bool status { get; set; }
    }
}
