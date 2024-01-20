using InvestmentPortal.API.Persistence.Repositories;
using InvestmentPortal.Domain.Entities;

namespace InvestmentPortal.API.Persistence.Interfaces
{
    public interface IAssetRepository : IRepository<Asset>
    {
        Task<Asset> GetBySymbolAsync(string symbol);
    }
}
