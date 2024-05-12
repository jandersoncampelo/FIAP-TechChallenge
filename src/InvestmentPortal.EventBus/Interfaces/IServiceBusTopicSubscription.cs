namespace InvestmentPortal.EventBus;

public interface IServiceBusTopicSubscription
{
    Task PrepareFiltersAndHandleMessages();
    Task CloseSubscriptionAsync();
    ValueTask DisposeAsync();
}
