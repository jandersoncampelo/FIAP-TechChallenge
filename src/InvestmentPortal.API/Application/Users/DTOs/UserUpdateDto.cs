namespace InvestmentPortal.API.Application.DTOs
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
    }
}
