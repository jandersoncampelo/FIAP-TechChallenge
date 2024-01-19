using InvestmentPortal.API.Persistence.Interfaces;
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
        private IRepository<InvestmentOrder> _repository;

        public OrdersController(ILogger<OrdersController> logger, IRepository<InvestmentOrder> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetOrders")]
        public IEnumerable<InvestmentOrder> Get()
        {
            return _repository.GetAll<InvestmentOrder>();
        }
    };
}
