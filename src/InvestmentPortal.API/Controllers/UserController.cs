using InvestmentPortal.API.Application.DTOs;
using InvestmentPortal.Core.Domain.Interfaces;
using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserRepository _repository;

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost(Name = "register")]
        public async Task<UserDto> UserRegister([FromBody] UserCreateDto user)
        {
            var newUser = new User
            {
                UserName = user.UserName,
                PasswordHash = user.Password,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Type = UserType.User
            };

            var result = await _repository.CreateUser(newUser);
            return new UserDto
            {
                UserName = result.UserName,
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName
            };
        }

        
    }
}
