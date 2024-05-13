using InvestmentPortal.Core.Domain.Data;
using InvestmentPortal.Core.Domain.Interfaces;
using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.Core.SqlServer.Repositories;

public class AssetRepository(MainContext context) : Repository<Asset>(context), IAssetRepository
{
    public async Task<Asset> GetBySymbolAsync(string symbol)
    {
        var result = await _context.Set<Asset>().FirstOrDefaultAsync(a => a.Symbol == symbol);

        return result ?? throw new Exception("Asset not found");
    }
}
