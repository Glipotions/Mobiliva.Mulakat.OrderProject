using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisSubscriber: BackgroundService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisSubscriber(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriber = _connectionMultiplexer.GetSubscriber();
            return subscriber.SubscribeAsync("messages", ((channel, value) =>
            {
                Console.WriteLine($"This essage content was : {value}");
            }));
        }
    }
}
