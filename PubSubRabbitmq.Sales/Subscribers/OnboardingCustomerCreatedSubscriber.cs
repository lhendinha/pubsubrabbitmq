using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using PubSubRabbitmq.Sales.Models;
using Newtonsoft.Json;
using System.Text;

namespace PubSubRabbitmq.Sales.Subscribers
{
    public class OnboardingCustomerCreatedSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "sales-service/customer-created";

        public OnboardingCustomerCreatedSubscriber()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "rabbitmq",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };

            _connection = connectionFactory.CreateConnection("sales-service-customer-created-consumer");

            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonConvert.DeserializeObject<CustomerCreatedEvent>(contentString);

                Console.WriteLine($"Message CustomerCreatedEvent received with Email {message.Email}");

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }
    }
}

