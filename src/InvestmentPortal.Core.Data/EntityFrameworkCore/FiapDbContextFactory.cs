using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InvestmentPortal.Core.Data.EntityFrameworkCore;

public class FiapDbContextFactory : IDesignTimeDbContextFactory<FiapDbContext>
{
    public FiapDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<FiapDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));    

        return new FiapDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../InvestmentPortal.API/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
