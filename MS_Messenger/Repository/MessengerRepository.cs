using Microsoft.Extensions.Options;
using MS_Messenger.Domain;
using MS_Messenger.Service;
using System;

namespace MS_Messenger.Repository
{
    public class MessengerRepository : IMessengerRepository
    {
        private readonly IRabbitMQService _rabbitMQService;
        private readonly AppSettings _appSettings;

        public MessengerRepository(IOptions<AppSettings> appSettings, IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
            _appSettings = appSettings.Value;
        }

        public bool SendMessageToPaymentEmailQueue(SendPaymentEmailRequest request)
        {
            try
            {
                _rabbitMQService.SendMessage(request, _appSettings.RabbitMQServiceSettings.Exchange, "send-payment-email-rk");
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
