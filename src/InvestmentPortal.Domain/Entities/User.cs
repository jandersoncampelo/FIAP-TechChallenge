namespace InvestmentPortal.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Portfolio> Portfolios { get; set; } = [];
        public List<InvestmentOrder> InvestmentOrders { get; set; } = [];
    }
}
