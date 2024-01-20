using Infrastructure.Persistence;
using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.API.Persistence.Repositories
{
    public class AssetRepository(MainContext context) : Repository<Asset>(context), IAssetRepository
    {
        public async Task<Asset> GetBySymbolAsync(string symbol)
        {
            return await _context.Set<Asset>().FirstOrDefaultAsync(a => a.Symbol == symbol);
        }
    }
}
