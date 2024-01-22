using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.API.Persistence.Repositories
{
    public class UserRepository(MainContext context) : Repository<User>(context), IUserRepository
    {
        public async Task<User> GetUserByLogin(string userName, string password)
        {
            // Convert password to hash SHA256
            var passwordHash = password.ToSHA256();
            var result = await _context.Set<User>().FirstOrDefaultAsync(u => u.UserName == userName && u.PasswordHash == passwordHash);

            return result;
        }
    }
}
