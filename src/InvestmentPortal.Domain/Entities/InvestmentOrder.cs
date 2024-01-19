using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.Domain.Entities
{
    public class InvestmentOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderType Type { get; set; }
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }

        public User? User { get; set; }
        public Asset? Asset { get; set; }
    }
}
