using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Shared.Models;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public InventoryController()
    {
        var factory = new ConnectionFactory() { HostName = "rabbitmq" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "inventory_updates", durable: true, exclusive: false, autoDelete: false);
    }

    [HttpPost("update")]
    public IActionResult UpdateInventory([FromBody] InventoryUpdateMessage message)
    {
        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;

        _channel.BasicPublish(exchange: "", routingKey: "inventory_updates", basicProperties: properties, body: body);

        return Accepted(new { TransactionId = message.TransactionId, Status = "Queued" });
    }
}
