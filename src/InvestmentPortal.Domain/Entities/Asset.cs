using InvestmentPortal.Domain.Core;
using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.Domain.Entities
{
    public class Asset : Entity
    {
        public Asset(string? symbol, AssetType type, string? name, string? description)
        {
            Symbol = symbol;
            Type = type;
            Name = name;
            Description = description;
        }

        public string? Symbol { get; set; }
        public AssetType Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<Portfolio> Portfolios { get; set; } = [];
        public List<InvestmentOrder> InvestmentOrders { get; set; } = [];
    }
}
