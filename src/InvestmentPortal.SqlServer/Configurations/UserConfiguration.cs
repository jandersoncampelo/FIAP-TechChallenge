using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortal.Core.SqlServer;

public partial class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("TB_USER");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.UserName)
            .IsUnicode(false)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.Email)
            .IsUnicode(false)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.PasswordHash)
            .IsUnicode(false)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.FirstName)
            .IsUnicode(false)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.LastName)
            .IsUnicode(false)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(x => x.Portfolios)
         .WithOne(y => y.User)
         .HasForeignKey(y => y.UserId);

        builder.HasMany(x => x.InvestmentOrders)
         .WithOne(y => y.User)
         .HasForeignKey(y => y.UserId);
    }
}
