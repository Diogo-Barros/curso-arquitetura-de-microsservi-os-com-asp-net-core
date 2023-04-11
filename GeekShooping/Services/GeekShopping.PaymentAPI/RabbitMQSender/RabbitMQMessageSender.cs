using GeekShooping.MessageBus;
using GeekShopping.PaymentAPI.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GeekShopping.PaymentAPI.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private const string HOST_NAME = "localhost";
        private const string USERNAME = "guest";
        private const string PASSWORD = "guest";
        private const string EXCHANGE_NAME = "DirectPaymentUpdateExchange";
        private const string PAYMENT_EMAIL_UPDATE_QUEUE_NAME = "PaymentEmailUpdateQueueName";
        private const string PAYMENT_ORDER_UPDATE_QUEUE_NAME = "PaymentOrderUpdateQueueName";

        private IConnection connection;

        public RabbitMQMessageSender() { }

        public void SendMessage(BaseMessage message)
        {
            if (ConnectionExists())
            {
                using var channel = connection.CreateModel();
                channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Direct, durable: false);

                channel.QueueDeclare(PAYMENT_EMAIL_UPDATE_QUEUE_NAME, false, false, false, null);
                channel.QueueDeclare(PAYMENT_ORDER_UPDATE_QUEUE_NAME, false, false, false, null);

                channel.QueueBind(PAYMENT_EMAIL_UPDATE_QUEUE_NAME, EXCHANGE_NAME, "PaymentEmail");
                channel.QueueBind(PAYMENT_ORDER_UPDATE_QUEUE_NAME, EXCHANGE_NAME, "PaymentOrder");

                byte[] body = GetMessaggeAsByteArray(message);

                channel.BasicPublish(exchange: EXCHANGE_NAME, "PaymentEmail", null, body: body);
                channel.BasicPublish(exchange: EXCHANGE_NAME, "PaymentOrder", null, body: body);
            }
        }

        private byte[] GetMessaggeAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize<UpdatePaymentResultMessage>((UpdatePaymentResultMessage)message, options);
            return Encoding.UTF8.GetBytes(json);
        }

        private bool ConnectionExists()
        {
            if (connection != null)
            {
                return true;
            }

            CreateConnection();
            return connection != null;
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = HOST_NAME,
                    UserName = USERNAME, 
                    Password = PASSWORD
                };

                connection = factory.CreateConnection();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
