﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class FacultyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int faculty_id { get; set; }
        [Required]
        [MaxLength(250)]
        public string faculty_name { get; set; }
        [Required]
        public bool status { get; set; }
    }
}
