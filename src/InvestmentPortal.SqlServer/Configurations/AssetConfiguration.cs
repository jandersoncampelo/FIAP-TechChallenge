using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortal.Core.SqlServer;

public partial class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.ToTable("TB_ASSET");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Symbol)
            .IsUnicode(false)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(x => x.Type)
            .IsRequired();
        builder.Property(x => x.Name)
            .IsUnicode(false)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.Description)
            .IsUnicode(false)
            .HasMaxLength(500)
            .IsRequired();

        builder.HasMany(x => x.Portfolios)
            .WithOne(y => y.Asset)
            .HasForeignKey(y => y.AssetId);

        builder.HasMany(x => x.InvestmentOrders)
            .WithOne(y => y.Asset)
            .HasForeignKey(y => y.AssetId);
    }
}
