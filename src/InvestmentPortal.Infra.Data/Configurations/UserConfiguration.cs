using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortal.Infra.SqlServer.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("AppUsers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.PasswordHash).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();

        builder.HasMany(x => x.Portfolios).WithOne().HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.InvestmentOrders).WithOne().HasForeignKey(x => x.UserId);
    }
}
