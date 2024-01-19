using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly List<Asset> assets = new List<Asset>
        {
            new Asset
            {
                Id = 1,
                Name = "Asset 1",
                Description = "Asset 1 Description",
                Type = AssetType.Stock
            },
            new Asset
            {
                Id = 2,
                Name = "Asset 2",
                Description = "Asset 2 Description",
                Type = AssetType.Crypto
            },
            new Asset
            {
                Id = 3,
                Name = "Asset 3",
                Description = "Asset 3 Description",
                Type = AssetType.Commodity
            }
        };

        private readonly ILogger<AssetController> _logger;

        public AssetController(ILogger<AssetController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAssets")]
        public IEnumerable<Asset> Get()
        {
            return assets;
        }
    }
}
