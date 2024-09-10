using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortal.Infra.SqlServer.Configurations;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.ToTable("AppAssets");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Symbol).IsRequired();
        builder.Property(e => e.Type).IsRequired();

        builder.HasMany(e => e.Portfolios)
            .WithOne(e => e.Asset)
            .HasForeignKey(e => e.AssetId);

        builder.HasMany(e => e.InvestmentOrders)
            .WithOne(e => e.Asset)
            .HasForeignKey(e => e.AssetId);
    }
}
