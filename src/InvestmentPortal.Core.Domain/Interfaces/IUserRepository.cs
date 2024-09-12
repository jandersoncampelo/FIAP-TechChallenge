using InvestmentPortal.Domain.Entities;

namespace InvestmentPortal.Core.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByLogin(string userName, string password);
    Task<User> CreateUser(User user);
}
