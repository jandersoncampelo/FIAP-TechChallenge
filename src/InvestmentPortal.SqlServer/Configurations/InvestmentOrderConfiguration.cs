using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortal.Core.SqlServer;

public partial class InvestmentOrderConfiguration : IEntityTypeConfiguration<InvestmentOrder>
{
    public void Configure(EntityTypeBuilder<InvestmentOrder> builder)
    {
        builder.ToTable("TB_INVESTMENT_ORDER");

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
        builder.Property(x => x.OrderDate)
            .IsRequired();
        builder.Property(x => x.Type)
            .IsRequired();
        builder.Property(x => x.Price)
            .HasPrecision(18, 2)
            .IsRequired();
        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.InvestmentOrders)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Asset)
            .WithMany(y => y.InvestmentOrders)
            .HasForeignKey(x => x.AssetId);
    }
}
