using CorpU.Entitiy.Models.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorpU.Entitiy.Models.Auth
{
    public class AuthanticationResponse
    {
        [JsonPropertyName("jwtToken")]
        public string JwtToken { get; set; }

        [JsonPropertyName("user")]
        public UserDto User { get; set; }
    }
}
