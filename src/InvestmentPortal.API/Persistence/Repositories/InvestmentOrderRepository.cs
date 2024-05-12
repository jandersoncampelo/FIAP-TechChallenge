using InvestmentPortal.API.Persistence;
using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.API.Persistence.Repositories;
using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.API;

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
