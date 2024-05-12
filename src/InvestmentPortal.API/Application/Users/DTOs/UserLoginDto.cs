using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace InvestmentPortal.API.Application.DTOs
{
    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
