﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpU.Data.Models
{
    public class UserEntity
    {

        [Key]
        public int user_id { get; set; }

        [MaxLength(250)]
        public string email { get; set; }
        [MaxLength(256)]
        public string password { get; set; }

        [Required]
        [Column("user_role_id")]
        public int user_role_id { get; set; }
        [ForeignKey("user_role_id")]
        public UserRoleEntiry UserRole { get; set; }
    }
}