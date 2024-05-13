using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortal.Core.SqlServer;

public partial class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.ToTable("TB_PORTFOLIO");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.UserId)
            .IsRequired();
        builder.Property(x => x.AssetId)
            .IsRequired();
        builder.Property(x => x.Quantity)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.PurchaseDate)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(y => y.Portfolios)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Asset)
            .WithMany(y => y.Portfolios)
            .HasForeignKey(x => x.AssetId);
    }
}

