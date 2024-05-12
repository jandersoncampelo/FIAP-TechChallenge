using InvestmentPortal.Domain.Enums;

namespace InvestmentPortal.Application.InvestmentOrders;

public record InvestmentOrderCreateDto(string Symbol,
                                       decimal Amount,
                                       DateTime OrderDate,
                                       int UserId,
                                       OrderType Type);
