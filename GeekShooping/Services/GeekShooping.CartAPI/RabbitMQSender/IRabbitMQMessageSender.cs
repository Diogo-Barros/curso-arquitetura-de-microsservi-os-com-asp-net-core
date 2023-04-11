using GeekShooping.MessageBus;

namespace GeekShooping.CartAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage message, string queueName);
    }
}
