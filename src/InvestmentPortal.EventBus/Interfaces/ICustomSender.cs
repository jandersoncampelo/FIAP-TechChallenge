namespace InvestmentPortal.EventBus;

public interface ICustomSender
{
    Task SendMessageAsync(InvestmentOrderMessage customMessage);
}
