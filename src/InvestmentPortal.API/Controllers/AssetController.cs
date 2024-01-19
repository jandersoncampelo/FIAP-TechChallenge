using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> _logger;
        private readonly IRepository<Asset> _repository;

        public AssetController(ILogger<AssetController> logger, IRepository<Asset> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetAssets")]
        public IEnumerable<Asset> Get()
        {
            return _repository.GetAll<Asset>();
        }
    }
}
