using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Mulakat.Core.Utilities.MessageBrokers.RabbitMq
{
    public class RabbitMQClient
    {
        //private readonly IConnection connection;
        private readonly MailSenderBackgroundService _brokerOptions;
        public IConfiguration Configuration;
        private readonly IModel _channel;


        public RabbitMQClient(MailSenderBackgroundService brokerOptions, IConfiguration configuration)
        {
            _brokerOptions = Configuration.GetSection("RabbitMq").Get<MailSenderBackgroundService>();
            Configuration = configuration;

            var factory = new ConnectionFactory()
            {
                HostName = _brokerOptions.HostName,
                UserName = _brokerOptions.UserName,
                Password = _brokerOptions.Password
            };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }
    }
}
