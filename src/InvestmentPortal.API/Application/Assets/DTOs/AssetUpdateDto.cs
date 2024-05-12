using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.API.Application.DTOs
{
    public record AssetUpdateDto(
        string? Name,
        string? Description);
}
