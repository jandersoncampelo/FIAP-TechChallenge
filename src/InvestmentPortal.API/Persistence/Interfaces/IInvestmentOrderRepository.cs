using InvestmentPortal.Domain.Entities;

namespace InvestmentPortal.API.Persistence.Interfaces;

public interface IInvestmentOrderRepository : IRepository<InvestmentOrder>
{
    Task<bool> VerifyOpenOrderAsync(int userId, int assetId, DateTime orderDate);
}
