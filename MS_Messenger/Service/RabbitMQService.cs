using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MS_Messenger.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace MS_Messenger.Service
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConnection _conn;
        private readonly IModel _channel;
        private readonly AppSettings _appSettings;
        private Guid _id;

        public RabbitMQService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;

            try
            {
                var rabbitMQSettings = _appSettings.RabbitMQServiceSettings;

                var factory = new ConnectionFactory()
                {
                    HostName = rabbitMQSettings.Hostname,
                    Port = Convert.ToInt32(rabbitMQSettings.Port),
                    UserName = rabbitMQSettings.Username,
                    Password = rabbitMQSettings.Password
                };
                _conn = factory.CreateConnection();
                _channel = _conn.CreateModel();

                if (_conn.IsOpen)
                {
                    _channel.ExchangeDeclare(rabbitMQSettings.Exchange, "topic");

                    // Queue Send Email Payment
                    _channel.QueueDeclare(queue: "send-payment-email",
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    _channel.QueueBind(queue: "send-payment-email", exchange: rabbitMQSettings.Exchange, routingKey: "send-payment-email-rk");

                    // Queue Send Email Newsletter
                    _channel.QueueDeclare(queue: "send-newsletter-email",
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    _channel.QueueBind(queue: "send-newsletter-email", exchange: rabbitMQSettings.Exchange, routingKey: "send-newsletter-email-rk");
                }

                Console.WriteLine("Exchange e Queues criadas com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, "Fatal error");
            }
        }

        public bool SendMessage(object request, string exchange, string routingKey)
        {
            try
            {
                var objectJson = JsonConvert.SerializeObject(request);
                var body = Encoding.UTF8.GetBytes(objectJson);

                _channel.BasicPublish(exchange: exchange,
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
    }
}