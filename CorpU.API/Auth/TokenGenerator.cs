using CorpU.API.Auth.Interfaces;
using CorpU.Entitiy.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CorpU.API.Auth
{
    public class TokenGenerator : ITokenGenerator
    {
        public AuthanticationResponse GenerateToken(string key, string username, double expTime)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username.ToString())
                    }),
                Expires = DateTime.UtcNow.AddMinutes(expTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return new AuthanticationResponse
            {
                JwtToken = token
            };
        }
    }
}
