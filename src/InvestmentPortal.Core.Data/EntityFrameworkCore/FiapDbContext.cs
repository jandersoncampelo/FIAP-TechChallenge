﻿using InvestmentPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortal.Core.Data.EntityFrameworkCore;

public class FiapDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Asset> Assets { get; set; }
    public DbSet<InvestmentOrder> InvestmentOrders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
}
