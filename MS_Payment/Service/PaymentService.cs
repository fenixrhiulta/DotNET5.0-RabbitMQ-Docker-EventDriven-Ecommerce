using MS_Payment.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace MS_Payment.Service
{
    public class PaymentService : IPaymentService
    {
        public PaymentResponse PostPaymentService(PaymentRequest request)
        {
            try
            {
                // Processar o pagamento
                // API Cartão de credito
                // Caso sucesso no processamento

                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    //channel.QueueDeclare(queue: "hello",
                    //                     durable: false,
                    //                     exclusive: false,
                    //                     autoDelete: false,
                    //                     arguments: null);

                    string message = JsonConvert.SerializeObject(request);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "ms.payment",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine(" [x] Sent {0}", message);
                }

                // enviar mensagem para a fila
                return new PaymentResponse { Protocol = Guid.NewGuid().ToString() };
            }
            catch (Exception e)
            {
            }

            return null;
        }
    }
}