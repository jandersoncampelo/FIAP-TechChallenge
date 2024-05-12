namespace InvestmentPortal.EventBus;

public interface IServiceBusConsumer
{
    Task RegisterOnMessageHandlerAndReceiveMessages();
    Task CloseQueueAsync();
    ValueTask DisposeAsync();
}
