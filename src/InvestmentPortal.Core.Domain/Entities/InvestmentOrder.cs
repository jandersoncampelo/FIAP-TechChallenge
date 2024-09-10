using InvestmentPortal.Domain.Core;
using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.Domain.Entities
{
    public class InvestmentOrder : Entity
    {
        public required int UserId { get; set; }
        public required int AssetId { get; set; }
        public required decimal Quantity { get; set; }
        public required DateTime OrderDate { get; set; }
        public required OrderType Type { get; set; }
        public required decimal Price { get; set; }
        public required OrderStatus Status { get; set; }

        public User? User { get; set; }
        public Asset? Asset { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
