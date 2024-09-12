namespace InvestmentPortal.API.Application.DTOs
{
    public record UserCreateDto(string UserName, string Password, string Email, string FirstName, string LastName);
}
