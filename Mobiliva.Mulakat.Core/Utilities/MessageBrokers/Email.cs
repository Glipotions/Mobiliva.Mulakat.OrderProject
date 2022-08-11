using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Mulakat.Entities.Dtos
{
    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Cc { get; set; }
        public string Message { get; set; }
    }
}
