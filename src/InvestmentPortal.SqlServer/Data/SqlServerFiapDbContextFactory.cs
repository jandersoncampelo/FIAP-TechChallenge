using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentPortal.Core.SqlServer.Data;

public class SqlServerFiapDbContextFactory(IServiceProvider serviceProvider) : IDbContextFactory<SqlServerFiapDbContext>
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public SqlServerFiapDbContext CreateDbContext()
        => ActivatorUtilities.CreateInstance<SqlServerFiapDbContext>(_serviceProvider, Type.EmptyTypes);

    public Task<SqlServerFiapDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(CreateDbContext());
}