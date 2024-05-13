using InvestmentPortal.Domain.Entities;

namespace InvestmentPortal.Core.Domain.Interfaces;

public interface IInvestmentOrderRepository : IRepository<InvestmentOrder>
{
    Task<bool> VerifyOpenOrderAsync(int userId, int assetId, DateTime orderDate);
}
