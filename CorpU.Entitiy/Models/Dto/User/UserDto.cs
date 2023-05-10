using CorpU.Entitiy.Models.Dto.Referance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.User
{
    public class UserDto
    {
        [JsonPropertyName("userId")]
        public int user_id { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonIgnore]
        [JsonPropertyName("password")]
        public string password { get; set; }

        [JsonIgnore]
        [JsonPropertyName("salt")]
        public string salt { get; set; }

        [JsonPropertyName("userRoleId")]
        public int user_role_id { get; set; }

        [JsonPropertyName("userRole")]
        public UserRoleDto UserRole { get; set; }
    }
}
