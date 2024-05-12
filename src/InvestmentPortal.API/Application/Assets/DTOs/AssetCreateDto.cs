using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.API.Application.DTOs
{
    public record AssetCreateDto(
        string Symbol,
        AssetType Type,
        string? Name,
        string? Description)
    { };
}
