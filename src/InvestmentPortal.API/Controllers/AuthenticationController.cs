using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Authenticate")]
        public IActionResult Authenticate()
        {
            return Ok();
        }

        [HttpPost(Name = "RefreshToken")]
        public IActionResult RefreshToken()
        {
            return Ok();
        }

        [HttpPost(Name = "RevokeToken")]
        public IActionResult RevokeToken()
        {
            return Ok();
        }
    }
}
