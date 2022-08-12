using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Mulakat.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        //public string Password { get; set; }
        public long Db { get; set; }
    }
}
