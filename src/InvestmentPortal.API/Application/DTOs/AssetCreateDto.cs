using InvestmentPortal.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace InvestmentPortal.API.Application.DTOs
{
    public record AssetCreateDto(
        string Symbol,
        AssetType Type,
        string? Name,
        string? Description);
}
