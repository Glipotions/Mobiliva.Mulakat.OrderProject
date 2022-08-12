using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;

namespace Mobiliva.Mulakat.Core.Utilities.MessageBrokers.RabbitMq
{
    public class MqConsumerHelper : IMessageConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly MailSenderBackgroundService _brokerOptions;
        public MqConsumerHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _brokerOptions = _configuration.GetSection("MessageBrokerOptions").Get<MailSenderBackgroundService>();
        }
        public void GetQueue(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _brokerOptions.HostName,
                UserName = _brokerOptions.UserName,
                Password = _brokerOptions.Password
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "email-send",
                                                         durable: false,
                                                         exclusive: false,
                                                         autoDelete: false,
                                                         arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, mq) =>
                {
                    var body = mq.Body.ToArray();
                    var json = Encoding.UTF8.GetString(body.ToArray());
                    //var email = Encoding.UTF8.GetString(body);
                    var email = JsonSerializer.Deserialize<Email>(json);

                    Console.WriteLine($"Message: {email.Message}");
                };

                channel.BasicConsume(queue: "email-send",
                                                      autoAck: true,
                                                      consumer: consumer);
                Console.ReadKey();

            }

        }
    }
}
