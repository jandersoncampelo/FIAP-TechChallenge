namespace InvestmentPortal.Domain.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

        public User? User { get; set; }
        public Asset? Asset { get; set; }
    }
}
