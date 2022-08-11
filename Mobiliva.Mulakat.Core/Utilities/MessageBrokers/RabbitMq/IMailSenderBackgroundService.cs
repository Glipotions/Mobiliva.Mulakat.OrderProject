namespace Mobiliva.Mulakat.Core.Utilities.MessageBrokers.RabbitMq
{
    public interface IMailSenderBackgroundService
    {
        void SendMail(string messageText);
        //void QueueMessage(Customer messageText);
    }
}
