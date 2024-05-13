using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace InvestmentPortal.EventBus;

public class ServiceBusMessageSender : ICustomSender
{
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;
    private const string QUEUE_NAME = "investment-order-created";

    public ServiceBusMessageSender(IConfiguration configuration)
    {
        _client = new ServiceBusClient(configuration["ConnectionStrings:AzureServiceBus"]);
        _sender = _client.CreateSender(QUEUE_NAME);
    }

    public async Task SendMessageAsync(InvestmentOrderMessage customMessage)
    {
        ServiceBusMessage message = new(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(customMessage)));
        await _sender.SendMessageAsync(message);
    }
}
