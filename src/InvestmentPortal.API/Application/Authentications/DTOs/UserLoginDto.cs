using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace InvestmentPortal.API.Application.DTOs
{
    public class UserLoginDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }

        public UserLoginDto(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
