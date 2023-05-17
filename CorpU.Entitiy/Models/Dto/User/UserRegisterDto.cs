using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Dto.User
{
    public class UserRegisterDto
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("password")]
        public string password { get; set; }

        [JsonPropertyName("userRoleId")]
        public int user_role_id { get; set; }
    }
}
