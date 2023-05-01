using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class ClassTypeEntity
    {
        [Key]
        public int class_type_id { get; set; }

        [MaxLength(250)]
        public string class_description { get; set; }

        public bool status { get; set; }
    }
}
