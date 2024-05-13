using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InvestmentPortal.EventBus;

public class ServiceBusTopicSender : ICustomSender
{
    private const string TOPIC_PATH = "investment-order-topic";
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;
    private readonly ILogger<ServiceBusTopicSender> _logger;

    public ServiceBusTopicSender(IConfiguration configuration, ILogger<ServiceBusTopicSender> logger)
    {
        _client = new ServiceBusClient(configuration["ConnectionStrings:AzureServiceBus"]);
        _sender = _client.CreateSender(TOPIC_PATH);
        _logger = logger;
    }

    public async Task SendMessageAsync(InvestmentOrderMessage customMessage)
    {
        ServiceBusMessage message = new(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(customMessage)));
        await _sender.SendMessageAsync(message);

        _logger.LogInformation($"Sent message to topic: {TOPIC_PATH}");
    }
}
