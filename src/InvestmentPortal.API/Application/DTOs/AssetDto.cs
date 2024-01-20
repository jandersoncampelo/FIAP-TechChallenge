using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.API.Application.DTOs
{
    public record AssetDto(
        int Id,
        string? Symbol,
        AssetType Type,
        string TypeDescription,
        string? Name,
        string? Description);
}
