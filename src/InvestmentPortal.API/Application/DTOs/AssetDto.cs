using InvestmentPortal.Domain.Entities;
using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.API.Application.DTOs
{
    public record AssetDto(
        int Id,
        string? Symbol,
        AssetType Type,
        string TypeDescription,
        string? Name,
        string? Description)
    {
        internal static AssetDto FromAsset(Asset entity)
        {
            return new AssetDto(entity.Id, entity.Symbol, entity.Type, entity.Type.ToString(), entity.Name, entity.Description);
        }
    }
}
