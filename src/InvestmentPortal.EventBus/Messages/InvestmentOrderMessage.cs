using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.EventBus
{
    public class InvestmentOrderMessage : CustomMessage
    {
        public string Symbol { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public OrderType Type { get; set; }
    }
}
