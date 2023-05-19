﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class ShortlistedApplicantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shortlist_id { get; set; }
        [Required]
        public int Application_id { get; set; }
        [ForeignKey("Application_id")]
        public ApplicationEntity application { get; set; }
        [Required]
        public int emp_id { get; set; }
        [ForeignKey("emp_id")]
        public EmployeeEntity employee { get; set; }
        [Required]
        public DateTime interview_date { get;set; }
        [Required]
        public string status { get; set; }
        public string comments { get; set; }

    }
}