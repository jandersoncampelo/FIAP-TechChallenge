using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/user/{userId}/portfolio")]
    public class PortfolioController
    {
        private readonly ILogger<PortfolioController> _logger;
        private IRepository<Portfolio> _repository;

        public PortfolioController(ILogger<PortfolioController> logger, IRepository<Portfolio> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetPortfolio")]
        public IEnumerable<Portfolio> Get()
        {
            return _repository.GetAll<Portfolio>();
        }
    }
}
