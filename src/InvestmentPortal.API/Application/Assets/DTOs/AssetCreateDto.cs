using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.API.Application.DTOs;

public record AssetCreateDto(
        string Symbol,
        AssetType Type,
        string? Name,
        string? Description)
{
    public AssetCreateDto(string symbol, AssetType type) : this(symbol, type, null, null)
    {
    }
}
