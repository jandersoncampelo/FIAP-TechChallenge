
using InvestmentPortal.EventBus;

namespace InvestmentPortal.Order.API;

public class WorkerServiceBus : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<WorkerServiceBus> _logger;
    private readonly IServiceBusConsumer _serviceBusConsumer;
    private readonly IServiceBusTopicSubscription _serviceBusTopicSubscription;

    public WorkerServiceBus(ILogger<WorkerServiceBus> logger, IServiceBusConsumer serviceBusConsumer, IServiceBusTopicSubscription serviceBusTopicSubscription, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceBusConsumer = serviceBusConsumer;
        _serviceBusTopicSubscription = serviceBusTopicSubscription;
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug("Starting the service bus queue consumer and the subscription");
        _logger.LogInformation("WorkerServiceBus running at: {time}", DateTimeOffset.Now);

        await _serviceBusConsumer.RegisterOnMessageHandlerAndReceiveMessages();
        await _serviceBusTopicSubscription.PrepareFiltersAndHandleMessages();

        _logger.LogDebug("Service bus queue consumer and the subscription started");
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogDebug("Stopping the service bus queue consumer and the subscription");
        _logger.LogInformation("WorkerServiceBus is stopping.");

        await _serviceBusConsumer.CloseQueueAsync();
        await _serviceBusTopicSubscription.CloseSubscriptionAsync();

        _logger.LogDebug("Service bus queue consumer and the subscription stopped");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual async void Dispose(bool disposing)
    {
        if (disposing)
        {
            await _serviceBusConsumer.DisposeAsync().ConfigureAwait(false);
            await _serviceBusTopicSubscription.DisposeAsync().ConfigureAwait(false);
        }
    }
}
