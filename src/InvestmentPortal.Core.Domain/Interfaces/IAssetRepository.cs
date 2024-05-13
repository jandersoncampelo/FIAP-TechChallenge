using InvestmentPortal.Domain.Entities;

namespace InvestmentPortal.Core.Domain.Interfaces;

public interface IAssetRepository : IRepository<Asset>
{
    Task<Asset> GetBySymbolAsync(string symbol);
}
