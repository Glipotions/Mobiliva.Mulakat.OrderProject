using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Mobiliva.Mulakat.Core.Utilities.MessageBrokers.RabbitMq
{
    public class MqQueueHelper : IMailSenderBackgroundService
    {
        private readonly MailSenderBackgroundService _brokerOptions;
        public IConfiguration Configuration;
        private readonly IModel _channel;


        public MqQueueHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _brokerOptions = Configuration.GetSection("RabbitMq").Get<MailSenderBackgroundService>();

            var factory = new ConnectionFactory()
            {
                HostName = _brokerOptions.HostName,
                UserName = _brokerOptions.UserName,
                Password = _brokerOptions.Password
            };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "email-box", type: ExchangeType.Direct);
            _channel.QueueDeclare(
                    queue: "email-send",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
            _channel.QueueBind(queue: "email-send", exchange: "email-box", routingKey: "email-add");
        }

        public void SendMail(string messageText)
        {
            var message = JsonConvert.SerializeObject(messageText);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "email-box", routingKey: "email-add", basicProperties: null, body: body);
        }


        //public IConfiguration Configuration;
        //private readonly MailSenderBackgroundService _brokerOptions;
        //public MqQueueHelper(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    _brokerOptions = Configuration.GetSection("RabbitMq").Get<MailSenderBackgroundService>();
        //}

        //public void SendMail(string messageText)
        //{
        //    var factory = new ConnectionFactory
        //    {
        //        HostName = _brokerOptions.HostName,
        //        UserName = _brokerOptions.UserName,
        //        Password = _brokerOptions.Password
        //    };
        //    using (var connection = factory.CreateConnection())
        //    using (var channel = connection.CreateModel())
        //    {
        //        channel.ExchangeDeclare(exchange:"email-box", type:ExchangeType.Direct);
        //        channel.QueueDeclare(
        //                queue: "email-send",
        //                durable: false,
        //                exclusive: false,
        //                autoDelete: false,
        //                arguments: null);
        //        channel.QueueBind(queue: "email-send", exchange: "email-box", routingKey: "email-add");


        //        var message = JsonConvert.SerializeObject(messageText);
        //        var body = Encoding.UTF8.GetBytes(message);

        //        channel.BasicPublish(exchange: "email-box", routingKey: "email-add", basicProperties: null, body: body);
        //    }
        //}
    }
}
