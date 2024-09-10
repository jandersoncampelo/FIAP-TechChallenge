using InvestmentPortal.Core.Domain.Interfaces;
using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.Infra.SqlServer.Repositories;

public class InvestmentOrderRepository(FiapDbContext context) : Repository<InvestmentOrder>(context), IInvestmentOrderRepository
{
    public async Task<bool> VerifyOpenOrderAsync(int userId, int assetId, DateTime orderDate)
    {
        var result = await _context.Set<InvestmentOrder>()
                                   .FirstOrDefaultAsync(o => o.UserId == userId &&
                                                        o.AssetId == assetId &&
                                                        o.OrderDate == orderDate);

        return result != null;
    }
}
