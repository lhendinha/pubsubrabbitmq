using PubSubRabbitmq.Customers.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PubSubRabbitmq.Customers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Exchange = "customers-service";

        public CustomersController()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "rabbitmq",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };

            _connection = connectionFactory.CreateConnection("customers-service-publisher");

            _channel = _connection.CreateModel();
        }

        [HttpPost]
        public IActionResult Post(CustomerInputModel model)
        {
            var customerCreated = new CustomerCreatedEvent(model.FullName, model.Email);

            var payload = JsonConvert.SerializeObject(customerCreated);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            Console.WriteLine("CustomerCreatedEvent Published");

            _channel.BasicPublish(Exchange, "customer-created", null, byteArray);

            return NoContent();
        }
    }
}

