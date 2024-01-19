using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Separar em arquivos de configuração
            //modelBuilder.ApplyConfigurationFromAssembly(typeof(SqlServerContext).Assembly);

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("TB_USER");

                u.HasKey(x => x.Id);
                u.Property(x => x.Id)
                    .ValueGeneratedNever()
                    .UseIdentityColumn();

                u.Property(x => x.Name)
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .IsRequired();
                u.Property(x => x.Email)
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .IsRequired();
                u.Property(x => x.PasswordHash)
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .IsRequired();
                u.Property(x => x.FirstName)
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .IsRequired();
                u.Property(x => x.LastName)
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .IsRequired();

                u.HasMany(x => x.Portfolios)
                 .WithOne(y => y.User)
                 .HasForeignKey(y => y.UserId);

                u.HasMany(x => x.InvestmentOrders)
                 .WithOne(y => y.User)
                 .HasForeignKey(y => y.UserId);
            });

            modelBuilder.Entity<Asset>(a =>
            {
                a.ToTable("TB_ASSET");
                a.HasKey(x => x.Id);
                a.Property(x => x.Id)
                    .ValueGeneratedNever()
                    .UseIdentityColumn();

                a.Property(x => x.Symbol)
                    .IsUnicode(false)
                    .HasMaxLength(10)
                    .IsRequired();
                a.Property(x => x.Type)
                    .IsRequired();
                a.Property(x => x.Name)
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .IsRequired();
                a.Property(x => x.Description)
                    .IsUnicode(false)
                    .HasMaxLength(500)
                    .IsRequired();

                a.HasMany(x => x.Portfolios)
                    .WithOne(y => y.Asset)
                    .HasForeignKey(y => y.AssetId);

                a.HasMany(x => x.InvestmentOrders)
                    .WithOne(y => y.Asset)
                    .HasForeignKey(y => y.AssetId);
            });

            modelBuilder.Entity<Portfolio>(p =>
            {
                p.ToTable("TB_PORTFOLIO");

                p.HasKey(x => x.Id);
                p.Property(x => x.Id)
                    .ValueGeneratedNever()
                    .UseIdentityColumn();

                p.Property(x => x.UserId)
                    .IsRequired();
                p.Property(x => x.AssetId)
                    .IsRequired();
                p.Property(x => x.Quantity)
                    .HasPrecision(18, 2)
                    .IsRequired();

                p.Property(x => x.PurchaseDate)
                    .IsRequired();

                p.HasOne(x => x.User)
                    .WithMany(y => y.Portfolios)
                    .HasForeignKey(x => x.UserId);

                p.HasOne(x => x.Asset)
                    .WithMany(y => y.Portfolios)
                    .HasForeignKey(x => x.AssetId);
            });

            modelBuilder.Entity<InvestmentOrder>(i =>
            {
                i.ToTable("TB_INVESTMENT_ORDER");

                i.HasKey(x => x.Id);
                i.Property(x => x.Id)
                    .ValueGeneratedNever()
                    .UseIdentityColumn();

                i.Property(x => x.UserId)
                    .IsRequired();
                i.Property(x => x.AssetId)
                    .IsRequired();
                i.Property(x => x.Quantity)
                    .HasPrecision(18, 2)
                    .IsRequired();
                i.Property(x => x.OrderDate)
                    .IsRequired();
                i.Property(x => x.Type)
                    .IsRequired();
                i.Property(x => x.Price)
                    .HasPrecision(18, 2)
                    .IsRequired();
                i.Property(x => x.Status)
                    .IsRequired();

                i.HasOne(x => x.User)
                    .WithMany(x => x.InvestmentOrders)
                    .HasForeignKey(x => x.UserId);

                i.HasOne(x => x.Asset)
                    .WithMany(y => y.InvestmentOrders)
                    .HasForeignKey(x => x.AssetId);
            });
        }
    }
}
