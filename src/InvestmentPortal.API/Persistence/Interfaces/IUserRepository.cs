using InvestmentPortal.Domain.Entities;

namespace InvestmentPortal.API.Persistence.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByLogin(string userName, string password);
    }
}
