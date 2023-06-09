﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class ApplicantQualificationEntiry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int app_qualification_id { get; set; }
        [Required]
        public int applicant_id { get; set; }
        [ForeignKey("applicant_id")]
        public ApplicantEntity Applicant { get; set; }
        [Required]
        public int qualification_type_id { get; set; }
        [Required]
        [MaxLength(250)]
        public string description { get; set; }
        [ForeignKey("qualification_type_id")]
        public QualificationTypeEntity QualificationType { get; set; }
        [Required]
        public int awarded_year { get; set; }
        [Required]
        [MaxLength(150)]
        public string institute { get; set; }
    }
}
