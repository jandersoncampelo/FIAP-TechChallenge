using InvestmentPortal.API.Application.DTOs;
using InvestmentPortal.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> _logger;
        private readonly IAssetAppService _appService;

        public AssetController(ILogger<AssetController> logger, IAssetAppService assetAppService)
        {
            _logger = logger;
            _appService = assetAppService;
        }

        [HttpGet(Name = "GetAssets")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _appService.GetAllAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
