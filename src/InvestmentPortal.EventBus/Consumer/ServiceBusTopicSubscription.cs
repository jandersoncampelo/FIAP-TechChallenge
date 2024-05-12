
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InvestmentPortal.EventBus;

public class ServiceBusTopicSubscription : IServiceBusTopicSubscription
{
    private readonly ILogger _logger;
    private readonly IProcessData _processData;
    private readonly ServiceBusClient _client;
    private readonly ServiceBusAdministrationClient _adminClient;
    private ServiceBusProcessor? _processor = null;

    private const string TOPIC_PATH = "investment-order-topic";
    private const string SUBSCRIPTION_NAME = "investment-order-subscription";

    public ServiceBusTopicSubscription(IProcessData processData, IConfiguration configuration, ILogger<ServiceBusTopicSubscription> logger)
    {
        _processData = processData;
        _logger = logger;

        var connectionString = configuration["ConnectionStrings:AzureServiceBus"];
        _client = new ServiceBusClient(connectionString);
        _adminClient = new ServiceBusAdministrationClient(connectionString);
    }

    public async Task PrepareFiltersAndHandleMessages()
    {
        var options = new ServiceBusProcessorOptions
        {
            AutoCompleteMessages = false,
            MaxConcurrentCalls = 1
        };

        _processor = _client.CreateProcessor(TOPIC_PATH, SUBSCRIPTION_NAME, options);
        _processor.ProcessMessageAsync += ProcessMessagesAsync;
        _processor.ProcessErrorAsync += ProcessErrorAsync;

        await RemoveDefaultFilters().ConfigureAwait(false);
        await AddFilters().ConfigureAwait(false);

        await _processor.StartProcessingAsync();
    }

    private async Task RemoveDefaultFilters()
    {
        try
        {
            var rules = _adminClient.GetRulesAsync(TOPIC_PATH, SUBSCRIPTION_NAME);
            var ruleProperties = new List<RuleProperties>();
            await foreach (var rule in rules)
            {
                ruleProperties.Add(rule);
            }

            foreach (var rule in ruleProperties)
            {
                if (rule.Name == "GoalsGreaterThanSeven")
                {
                    await _adminClient.DeleteRuleAsync(TOPIC_PATH, SUBSCRIPTION_NAME, "GoalsGreaterThanSeven")
                        .ConfigureAwait(false);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("{ex}", ex.ToString());
        }
    }

    private async Task AddFilters()
    {
        try
        {
            var rules = _adminClient.GetRulesAsync(TOPIC_PATH, SUBSCRIPTION_NAME)
                .ConfigureAwait(false);

            var ruleProperties = new List<RuleProperties>();
            await foreach (var rule in rules)
            {
                ruleProperties.Add(rule);
            }

            if (!ruleProperties.Any(r => r.Name == "GoalsGreaterThanSeven"))
            {
                var createRuleOptions = new CreateRuleOptions
                {
                    Name = "GoalsGreaterThanSeven",
                    Filter = new SqlRuleFilter("goals > 7")
                };
                await _adminClient.CreateRuleAsync(TOPIC_PATH, SUBSCRIPTION_NAME, createRuleOptions)
                    .ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning("{ex}", ex.ToString());
        }
    }

    private async Task ProcessMessagesAsync(ProcessMessageEventArgs args)
    {
        var myPayload = args.Message.Body.ToObjectFromJson<InvestmentOrderMessage>();
        await _processData.Process(myPayload).ConfigureAwait(false);
        await args.CompleteMessageAsync(args.Message).ConfigureAwait(false);
    }

    private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
    {
        _logger.LogError(arg.Exception, "Message handler encountered an exception");
        _logger.LogDebug("- ErrorSource: {ErrorSource}", arg.ErrorSource);
        _logger.LogDebug("- Entity Path: {EntityPath}", arg.EntityPath);
        _logger.LogDebug("- FullyQualifiedNamespace: {FullyQualifiedNamespace}", arg.FullyQualifiedNamespace);

        return Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        if (_processor != null)
        {
            await _processor.DisposeAsync().ConfigureAwait(false);
        }

        if (_client != null)
        {
            await _client.DisposeAsync().ConfigureAwait(false);
        }
    }

    public async Task CloseSubscriptionAsync()
    {
        await _processor!.CloseAsync().ConfigureAwait(false);
    }
}
