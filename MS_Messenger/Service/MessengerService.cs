using MS_Messenger.Domain;
using MS_Messenger.Repository;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace MS_Messenger.Service
{
    public class MessengerService : IMessengerService
    {
        private readonly IMessengerRepository _repository;

        public MessengerService(IMessengerRepository repository)
        {
            _repository = repository;
        }

        public SendPaymentEmailResponse PostSendPaymentEmailService(SendPaymentEmailRequest request)
        {
            try
            {
                // Processar o pagamento
                // API Cartão de credito
                // Caso sucesso no processamento

                // enviar mensagem para a fila

                if (_repository.SendMessageToPaymentEmailQueue(request))
                {
                    Console.WriteLine("Mensagem enviada para a fila!");
                }

                return new SendPaymentEmailResponse { IsEmailSended = true };
            }
            catch (Exception e)
            {
            }

            return null;
        }
    }
}