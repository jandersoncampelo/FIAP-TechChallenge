using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IRepository<User> _repository;

        public UserController(ILogger<UserController> logger, IRepository<User> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost(Name = "Register")]
        public IEnumerable<User> UserRegister()
        {
            return _repository.GetAll<User>();
        }
    }
}
