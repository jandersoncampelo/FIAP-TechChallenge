using InvestmentPortal.Core.Domain.Data;
using InvestmentPortal.Core.Domain.Interfaces;
using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.Core.SqlServer.Repositories;

public class InvestmentOrderRepository(MainContext context) : Repository<InvestmentOrder>(context), IInvestmentOrderRepository
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
