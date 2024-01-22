using InvestmentPortal.API.Application.DTOs;
using InvestmentPortal.Domain.Entities;

namespace InvestmentPortal.API.Application.Interfaces
{
    public interface IAuthenticationAppService
    {
        string GenerateToken(User user);
        Task<User> LoginAsync(UserLoginDto login);
    }
}
