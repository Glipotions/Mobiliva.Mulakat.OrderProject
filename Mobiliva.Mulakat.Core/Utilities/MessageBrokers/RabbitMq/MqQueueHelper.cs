using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Mobiliva.Mulakat.Core.Utilities.MessageBrokers.RabbitMq
{
    public class MqQueueHelper : IMailSenderBackgroundService
    {
        public IConfiguration Configuration;
        private readonly MailSenderBackgroundService _brokerOptions;
        public MqQueueHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _brokerOptions = Configuration.GetSection("MessageBrokerOptions").Get<MailSenderBackgroundService>();
        }

        public void QueueMessage(Customer messageText)
        {
            var factory = new ConnectionFactory
            {
                HostName = _brokerOptions.HostName,
                UserName = _brokerOptions.UserName,
                Password = _brokerOptions.Password
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                        queue: "DArchQueue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                var message = JsonConvert.SerializeObject(messageText);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "DArchQueue", basicProperties: null, body: body);
            }
        }
    }
}
