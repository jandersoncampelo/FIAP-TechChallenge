using InvestmentPortal.Core.Data.EntityFrameworkCore;
using InvestmentPortal.Core.Domain.Interfaces;
using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.Core.Data.Repositories;

public class AssetRepository(FiapDbContext context) : Repository<Asset>(context), IAssetRepository
{
    public async Task<Asset> GetBySymbolAsync(string symbol) 
        => await _context.Set<Asset>().FirstOrDefaultAsync(a => a.Symbol == symbol);
}
