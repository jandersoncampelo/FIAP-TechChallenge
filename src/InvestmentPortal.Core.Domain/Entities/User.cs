using InvestmentPortal.Domain.Core;
using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.Domain.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserType Type { get; set; } = UserType.User;

        public List<Portfolio> Portfolios { get; set; } = [];
        public List<InvestmentOrder> InvestmentOrders { get; set; } = [];
    }
}
