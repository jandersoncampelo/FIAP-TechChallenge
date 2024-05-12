using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.API.Persistence.Repositories;
using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Domain.Enums;
using InvestmentPortal.EventBus;

namespace InvestmentPortal.Order.API;

public class ProcessOrder : IProcessData
{
    private readonly ILogger<ProcessOrder> _logger;

    private readonly IServiceProvider _serviceProvider;

    public ProcessOrder(ILogger<ProcessOrder> logger, IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public async Task Process(InvestmentOrderMessage message)
    {
        _logger.LogInformation("Processing order for user {UserId} with symbol {Symbol}", message.UserId, message.Symbol);

        var user = await ValidateUser(message);
        var asset = await ValidateAsset(message);
        
        if (!await CanInsertOrder(message, user, asset))
        {

            return;
        }

        var order = new InvestmentOrder
        {
            UserId = user.Id,
            AssetId = asset.Id,
            Quantity = message.Amount,
            OrderDate = message.OrderDate,
            Type = message.Type,
            Price = 0.0m,
            Status = OrderStatus.Pending
        };

        using (var scope = _serviceProvider.CreateScope())
        {
            var orderRepository = scope.ServiceProvider.GetRequiredService<IInvestmentOrderRepository>();
            await orderRepository.AddAsync(order);
        }
    }

    private async Task<bool> CanInsertOrder(InvestmentOrderMessage message, User user, Asset asset)
    {
        if (user.Id == 0 || asset.Id == 0)
        {
            _logger.LogWarning("User or asset not found, cannot insert order");
            return false;
        }

        using (var scope = _serviceProvider.CreateScope())
        {
            var orderRepository = scope.ServiceProvider.GetRequiredService<IInvestmentOrderRepository>();
            var orderExists = await orderRepository.VerifyOpenOrderAsync(user.Id, asset.Id, message.OrderDate);
            if (orderExists)
            {
                _logger.LogWarning("Order for user {UserId} with symbol {Symbol} and date {OrderDate} already exists", user.Id, asset.Symbol, message.OrderDate);
                return false;
            }
        }

        return true;
    }

    private async Task<Asset> ValidateAsset(InvestmentOrderMessage message)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var assetRepository = scope.ServiceProvider.GetRequiredService<IAssetRepository>();
            var asset = await assetRepository.GetBySymbolAsync(message.Symbol);

            if (asset == null)
            {
                _logger.LogWarning("Asset with symbol {Symbol} not found", message.Symbol);
            }

            return asset ?? new Asset();
        }
    }

    private async Task<User> ValidateUser(InvestmentOrderMessage message)
    {
        using var scope = _serviceProvider.CreateScope();
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
        var user = await userRepository.GetByIdAsync<User>(message.UserId);
        if (user == null)
        {
            _logger.LogWarning("User with id {UserId} not found", message.UserId);
        }

        return user ?? new User();
    }
}
