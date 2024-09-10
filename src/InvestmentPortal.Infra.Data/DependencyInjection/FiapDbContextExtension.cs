using InvestmentPortal.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentPortal.Infra.SqlServer.DependencyInjection;

public static class FiapDbContextExtension
{
    public static IServiceCollection AddFiapDbContext(this IServiceCollection services, string connectionString)
        => services.AddDbContext<FiapDbContext>(options =>
        {
            options.UseSqlServer(connectionString, providerOptions => providerOptions.EnableRetryOnFailure());
        });
}
