using InvestmentPortal.API.Application.Assets.Interfaces;
using InvestmentPortal.API.Application.DTOs;
using InvestmentPortal.Core.Domain.Interfaces;
using InvestmentPortal.Domain.Entities;

namespace InvestmentPortal.API.Application.Services
{
    public class AssetAppService : IAssetAppService
    {
        private readonly IAssetRepository _repository;

        public AssetAppService(IAssetRepository assetRepository)
        {
            _repository = assetRepository;
        }

        public async Task<AssetDto> CreateAsync(AssetCreateDto createDTO)
        {
            if (createDTO == null || string.IsNullOrEmpty(createDTO.Symbol))
            {
                throw new ArgumentNullException(nameof(createDTO));
            }

            if (await _repository.GetBySymbolAsync(createDTO.Symbol) is not null)
                throw new Exception("Asset already exists");

            var result = await _repository.AddAsync(new Asset(createDTO.Symbol, createDTO.Type, createDTO.Name, createDTO.Description));

            return AssetDto.FromAsset(result);
        }

        public async Task<IList<AssetDto>> GetAllAsync()
        {
            var assets = await _repository.GetAllAsync<Asset>();
            return assets.Select(a => new AssetDto(a.Id, a.Symbol, a.Type, "", a.Name, a.Description)).ToList();
        }

        public async Task<AssetDto> GetByIdAsync(int id)
        {
            var asset = await _repository.GetByIdAsync<Asset>(id);
            return new AssetDto(asset.Id, asset.Symbol, asset.Type, "", asset.Name, asset.Description);
        }

        public async Task RemoveAsync(int id)
        {
            var assetToDelete = await _repository.GetByIdAsync<Asset>(id) ?? throw new Exception("Asset not found");

            await _repository.RemoveAsync(assetToDelete);
        }

        public async Task<AssetDto> UpdateAsync(int id, AssetUpdateDto updateDTO)
        {
            var assetToUpdate = await _repository.GetByIdAsync<Asset>(id) ?? throw new Exception("Asset not found");

            assetToUpdate.Name = updateDTO.Name;
            assetToUpdate.Description = updateDTO.Description;

            var result = await _repository.UpdateAsync(assetToUpdate);

            return AssetDto.FromAsset(result);
        }
    }
}
