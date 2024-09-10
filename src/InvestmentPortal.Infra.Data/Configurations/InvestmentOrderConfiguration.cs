using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortal.Infra.SqlServer.Configurations;

public class InvestmentOrderConfiguration : IEntityTypeConfiguration<InvestmentOrder>
{
    public void Configure(EntityTypeBuilder<InvestmentOrder> builder)
    {
        builder.ToTable("AppInvestmentOrders");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Quantity)
            .IsRequired();

        builder.Property(e => e.Price)
            .IsRequired();

        builder.Property(e => e.Status)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(e => e.InvestmentOrders)
            .HasForeignKey(e => e.UserId);

        builder.HasOne(e => e.Asset)
            .WithMany(e => e.InvestmentOrders)
            .HasForeignKey(e => e.AssetId);
    }
}
