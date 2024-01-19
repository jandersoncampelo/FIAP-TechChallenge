using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.Domain.Entities
{
    public class Asset
    {
        public int Id { get; set; }
        public string? Symbol { get; set; }
        public AssetType Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<Portfolio> Portfolios { get; set; } = [];
        public List<InvestmentOrder> InvestmentOrders { get; set; } = [];
    }
}
