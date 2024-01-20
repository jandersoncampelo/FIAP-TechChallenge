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

        [HttpGet("{id}", Name = "GetAsset")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _appService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost(Name = "CreateAsset")]
        public async Task<IActionResult> PostAsync([FromBody] AssetCreateDto asset)
        {
            var result = await _appService.CreateAsync(asset);
            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetAsset", new { id = result.Id }, result);
        }

        [HttpPut("{id}", Name = "UpdateAsset")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AssetUpdateDto asset)
        {
            var result = await _appService.UpdateAsync(id, asset);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
