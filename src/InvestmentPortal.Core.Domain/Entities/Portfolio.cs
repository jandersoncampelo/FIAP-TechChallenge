using InvestmentPortal.Domain.Core;

namespace InvestmentPortal.Domain.Entities
{
    public class Portfolio : Entity
    {
        public required int UserId { get; set; }
        public required int AssetId { get; set; }
        public required decimal Quantity { get; set; }
        public required DateTime PurchaseDate { get; set; }

        public User? User { get; set; }
        public Asset? Asset { get; set; }
    }
}
