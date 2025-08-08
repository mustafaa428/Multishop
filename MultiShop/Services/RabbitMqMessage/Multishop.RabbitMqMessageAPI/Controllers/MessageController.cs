using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace Multishop.RabbitMqMessageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            await using var connection = await connectionFactory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            // Kuyruğu oluştur
            await channel.QueueDeclareAsync(
                queue: "Kuyruk1",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var messageContent = "Merhaba bu bir rabbitmq kuyruk mesajı eğitim denemesidir.";
            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            // 7.x sürümünde BasicPublishAsync generic oldu, mandatory parametresi eklendi
            await channel.BasicPublishAsync(
                    exchange: "",
                    routingKey: "Kuyruk1",
                    mandatory: false,
                    basicProperties: new BasicProperties(),
                    body: new ReadOnlyMemory<byte>(byteMessageContent),
                    cancellationToken: default
                );

            return Ok("Mesajınız kuyruğa alınmıştır.");
        }

        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            var result = await channel.BasicGetAsync("Kuyruk1", autoAck: true);

            if (result == null)
            {
                return Ok("Kuyruk boş");
            }

            var message = Encoding.UTF8.GetString(result.Body.ToArray());
            return Ok(message);
        }

    }
}
