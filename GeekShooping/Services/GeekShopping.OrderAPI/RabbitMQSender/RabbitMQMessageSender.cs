using GeekShooping.MessageBus;
using GeekShopping.OrderAPI.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GeekShopping.OrderAPI.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private const string _hostName = "localhost";
        private const string _password = "guest";
        private const string _userName = "guest";
        private IConnection connection;

        public RabbitMQMessageSender() { }

        public void SendMessage(BaseMessage message, string queueName)
        {
            if (ConnectionExists())
            {
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);

                byte[] body = GetMessageAsByteArray(message);
                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            }
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize<PaymentVO>((PaymentVO)message, options);

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
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
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
