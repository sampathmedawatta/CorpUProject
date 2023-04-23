using EnergyShifter.Entitiy.Models.Auth;
using System.Security.Claims;

namespace EnergyShifter.API.Auth.Interfaces
{
    public interface ITokenGenerator
    {
        AuthanticationResponse GenerateToken(string key, string id, double expTime);
    }
}
