namespace InvestmentPortal.EventBus;

public interface ICustomSender
{
    Task SendMessageAsync(CustomMessage customMessage);
}
