using InvestmentPortal.Core.Data.EntityFrameworkCore;
using InvestmentPortal.Core.Data.Repositories;
using InvestmentPortal.Core.Domain.Interfaces;
using InvestmentPortal.EventBus;
using InvestmentPortal.Order.API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FiapDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IAssetRepository, AssetRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IInvestmentOrderRepository, InvestmentOrderRepository>();

//builder.Services.AddSingleton<IServiceBusConsumer, ServiceBusConsumer>();
builder.Services.AddSingleton<IServiceBusTopicSubscription, ServiceBusTopicSubscription>();
builder.Services.AddSingleton<IProcessData, ProcessOrder>();

builder.Services.AddHostedService<WorkerServiceBus>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
