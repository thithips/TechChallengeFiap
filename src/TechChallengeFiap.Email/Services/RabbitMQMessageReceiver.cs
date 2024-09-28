using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using TechChallengeFiap.Core;

namespace TechChallengeFiap.Email.Services
{
    public class RabbitMQMessageReceiverService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQMessageReceiverService(IEmailService emailService, IConfiguration configuration)
        {
            _emailService = emailService;

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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _channel.QueueDeclare(queue: _configuration["RabbitMQSettings:Queue"], false, false, false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var emailModel = JsonSerializer.Deserialize<EmailModel>(message);

                if (emailModel != null)
                {
                    await _emailService.SendEmailAsync(emailModel);
                }
            };

            _channel.BasicConsume(queue: _configuration["RabbitMQSettings:Queue"], autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
