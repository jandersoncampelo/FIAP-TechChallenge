using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController
    {
        private readonly ILogger<OrdersController> _logger;

        private readonly List<InvestmentOrder> orders = new List<InvestmentOrder>
        {
            new InvestmentOrder
            {
                Id = 1,
                UserId = 1,
                AssetId = 1,
                Quantity = 10,
                OrderDate = DateTime.Now,
                Type = OrderType.Buy,
                Price = 100,
                Status = OrderStatus.Executed
            },
            new InvestmentOrder
            {
                Id = 2,
                UserId = 1,
                AssetId = 2,
                Quantity = 10,
                OrderDate = DateTime.Now,
                Type = OrderType.Buy,
                Price = 100,
                Status = OrderStatus.Pending
            }
        };

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOrders")]
        public IEnumerable<InvestmentOrder> Get()
        {
            return orders;
        }
    };
}
