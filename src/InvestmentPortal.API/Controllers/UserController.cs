using InvestmentPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "User 1",
                Email = "jandersoncampelo@gmail.com"
            }
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<User> Get()
        {
            return users;
        }
    }
}
