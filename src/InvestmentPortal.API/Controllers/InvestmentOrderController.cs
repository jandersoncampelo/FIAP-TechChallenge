using InvestmentPortal.API.Persistence.Interfaces;
using InvestmentPortal.Application.InvestmentOrders;
using InvestmentPortal.Domain.Entities;
using InvestmentPortal.EventBus;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortal.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController
{
    private readonly ILogger<OrdersController> _logger;
    private IRepository<InvestmentOrder> _repository;
    private readonly ICustomSender _sender;

    public OrdersController(ILogger<OrdersController> logger, IRepository<InvestmentOrder> repository, ICustomSender sender)
    {
        _logger = logger;
        _repository = repository;
        _sender = sender;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task Post([FromBody] InvestmentOrderCreateDto order)
    {
        //new InvestmentOrderCreateDtoValidator().ValidateAndThrow(order);

        var message = new InvestmentOrderMessage
        {
            Symbol = order.Symbol,
            Amount = order.Amount,
            OrderDate = order.OrderDate,
            UserId = order.UserId,
            Type = order.Type
        };

        await _sender.SendMessageAsync(message);
    }
};
