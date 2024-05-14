using InvestmentPortal.Core.Data.EntityFrameworkCore;
using InvestmentPortal.Core.Domain.Interfaces;
using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.Core.Data.Repositories;

public class UserRepository(FiapDbContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User> GetUserByLogin(string userName, string password)
    {
        // Convert password to hash SHA256
        var passwordHash = password.ToSHA256();
        var result = await _context.Set<User>().FirstOrDefaultAsync(u => u.UserName == userName && u.PasswordHash == passwordHash);

        return result ?? throw new Exception("User not found");
    }
}
