using CorpU.Entitiy.Models.Auth;
using System.Security.Claims;

namespace CorpU.API.Auth.Interfaces
{
    public interface ITokenGenerator
    {
        AuthanticationResponse GenerateToken(string key, string id, double expTime);
    }
}
