namespace Mobiliva.Mulakat.Core.Utilities.MessageBrokers.RabbitMq
{
    public class MailSenderBackgroundService
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }

    }
    //public class Customer
    //{
    //    public string Email { get; set; }
    //    public string Message { get; set; }
    //}
}
