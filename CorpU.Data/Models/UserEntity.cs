using System;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        [Required]
        [MaxLength(250)]
        public string email { get; set; }
        [Required]
        [MaxLength(256)]
        public string password { get; set; }
        [Required]
        [ForeignKey("user_role_id")]
        public UserRoleEntity UserRole { get; set; }
    }
}
