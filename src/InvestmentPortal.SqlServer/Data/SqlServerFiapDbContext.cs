using InvestmentPortal.Core.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.Core.SqlServer.Data;

public partial class SqlServerFiapDbContext : MainContext
{
    public SqlServerFiapDbContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerFiapDbContext).Assembly);
    }
}
