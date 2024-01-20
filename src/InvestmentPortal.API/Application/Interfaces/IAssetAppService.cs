﻿using InvestmentPortal.API.Application.DTOs;

namespace InvestmentPortal.API.Application.Interfaces
{
    public interface IAssetAppService
    {
        Task<IList<AssetDto>> GetAllAsync();
        Task<AssetDto> GetByIdAsync(int id);
        Task CreateAsync(AssetCreateDto createDTO);
        Task UpdateAsync(int id, AssetUpdateDto updateDTO);
        Task RemoveAsync(int id);
    }
}
