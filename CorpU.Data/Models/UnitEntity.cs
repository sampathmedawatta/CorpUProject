using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class UnitEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int unit_id { get; set; }

        [MaxLength(25)]
        public string unit_name { get; set; }

        [MaxLength(10)]
        public string unit_code { get; set; }
        public bool status { get; set; }
        
    }
}
