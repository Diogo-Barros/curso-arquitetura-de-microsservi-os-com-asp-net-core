using GeekShopping.PaymentAPI.Messages;
using GeekShopping.PaymentAPI.RabbitMQSender;
using GeekShopping.PaymentProcessor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.PaymentAPI.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IRabbitMQMessageSender _messageSender;
        private readonly IProcessPayment _processPayment;

        private const string HOST_NAME = "localhost";
        private const string USERNAME = "guest";
        private const string PASSWORD = "guest";
        private const string QUEUE_PROCESS = "orderpaymentprocessqueue";

        public RabbitMQPaymentConsumer(IRabbitMQMessageSender messageSender, IProcessPayment processPayment)
        {
            _messageSender = messageSender;
            _processPayment = processPayment;
            var factory = new ConnectionFactory
            {
                HostName = HOST_NAME,
                UserName = USERNAME,
                Password = PASSWORD
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: QUEUE_PROCESS, false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                PaymentMessage message = JsonSerializer.Deserialize<PaymentMessage>(content);
                ProcessPayment(message).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };

            _channel.BasicConsume(QUEUE_PROCESS, false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentMessage message)
        {
            var result = _processPayment.PaymentProcessor();
            UpdatePaymentResultMessage paymentResult = new UpdatePaymentResultMessage
            {
                Status = result,
                OrderId = message.OrderId,
                Email = message.Email,
            };

            try
            {
                _messageSender.SendMessage(paymentResult);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
