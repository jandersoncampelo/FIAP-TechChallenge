using InvestmentPortal.API.Application.DTOs;
using InvestmentPortal.API.Application.Interfaces;
using InvestmentPortal.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers
{
    [ApiController]
    [Route("api/assets")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = Permissoes.Admin)]
        public async Task<IActionResult> PostAsync([FromBody] AssetCreateDto asset)
        {
            var result = await _appService.CreateAsync(asset);
            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetAsset", new { id = result.Id }, result);
        }

        [Authorize(Roles = Permissoes.Admin)]
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

        [Authorize(Roles = Permissoes.Admin)]
        [HttpDelete("{id}", Name = "DeleteAsset")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = Permissoes.Admin)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _appService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            await _appService.RemoveAsync(id);

            return Ok();
        }
    }
}
