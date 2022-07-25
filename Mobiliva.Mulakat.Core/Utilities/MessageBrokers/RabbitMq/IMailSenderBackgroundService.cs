namespace Mobiliva.Mulakat.Core.Utilities.MessageBrokers.RabbitMq
{
    public interface IMailSenderBackgroundService
    {
        //void QueueMessage(string messageText);
        void QueueMessage(Customer messageText);
    }
}
