using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using TechChallengeFiap.Core;
using TechChallengeFiap.Domain.Interfaces.Service;

namespace TechChallengeFiap.Services
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private IConnection _connection;
        private IModel _channel;
        private IConfiguration _configuration;

        public RabbitMQMessageSender(IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQSettings:Host"],
                Port = int.Parse(configuration["RabbitMQSettings:Port"]),
                Password = configuration["RabbitMQSettings:Password"],
                UserName = configuration["RabbitMQSettings:User"],
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _configuration = configuration;
        }

        public void SendMessage(BaseMessage baseMessage)
        {
            _channel.QueueDeclare(queue: _configuration["RabbitMQSettings:Queue"], false, false, false, arguments: null);
            byte[] body = GetMessageAsByteArray(baseMessage);
            _channel.BasicPublish(exchange: "", routingKey: _configuration["RabbitMQSettings:Queue"], basicProperties: null, body: body);
        }

        private byte[] GetMessageAsByteArray(BaseMessage baseMessage)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize<EmailModel>((EmailModel)baseMessage, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }
    }

}
