using InvestmentPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController
    {
        private readonly ILogger<PortfolioController> _logger;

        private readonly List<Portfolio> portfolios = new List<Portfolio>
        {
            new Portfolio
            {
                Id = 1,
                UserId = 1,
                AssetId = 1,
                Quantity = 10
            },
            new Portfolio
            {
                Id = 2,
                UserId = 1,
                AssetId = 2,
                Quantity = 10
            }
        };
        public PortfolioController(ILogger<PortfolioController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPortfolio")]
        public IEnumerable<Portfolio> Get()
        {
            return portfolios;
        }
    }
}
