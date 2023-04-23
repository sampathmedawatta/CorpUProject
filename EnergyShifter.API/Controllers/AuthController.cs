using EnergyShifter.API.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnergyShifter.API.Controllers
{
    [ApiKeyAuthentication]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpGet("HealthCheck")]
        public ActionResult HealthCheck()
        {

            return Ok();

        }
    }
}
