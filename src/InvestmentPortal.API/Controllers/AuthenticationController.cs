using InvestmentPortal.API.Application.DTOs;
using InvestmentPortal.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationAppService _appService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationAppService authenticationService)
        {
            _logger = logger;
            _appService = authenticationService;
        }

        [HttpPost("login", Name = "Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto login)
        {
            var result = await _appService.LoginAsync(login);
            if (result == null)
            {
                return BadRequest(new { message = "Usuário ou senha inválidos!" });
            }

            var token = _appService.GenerateToken(result);

            return Ok(new { Usuario = result, Token = token });
        }
    }

}
