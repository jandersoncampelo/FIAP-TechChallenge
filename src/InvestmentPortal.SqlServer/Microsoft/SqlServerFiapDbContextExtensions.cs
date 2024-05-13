using InvestmentPortal.Core.Domain.Data;
using InvestmentPortal.Core.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class SqlServerFiapDbContextExtensions
{
    public static IServiceCollection AddSqlServerFiapDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
            => services
            .AddScoped<MainContext, SqlServerFiapDbContext>()
            .AddDbContextFactory<SqlServerFiapDbContext, SqlServerFiapDbContextFactory>(optionsAction);
}
