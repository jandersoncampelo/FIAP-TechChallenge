using InvestmentPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.Order.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController
{
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(ILogger<OrdersController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetOrders")]
    public IEnumerable<InvestmentOrder> Get()
    {
        return new List<InvestmentOrder>();
    }
};
