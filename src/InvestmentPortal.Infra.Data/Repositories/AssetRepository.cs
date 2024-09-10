using InvestmentPortal.Core.Domain.Interfaces;
using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.Infra.SqlServer.Repositories;

public class AssetRepository(FiapDbContext context) : Repository<Asset>(context), IAssetRepository
{
    public async Task<Asset> GetBySymbolAsync(string symbol)
        => await _context.Set<Asset>().FirstOrDefaultAsync(a => a.Symbol == symbol);
}
