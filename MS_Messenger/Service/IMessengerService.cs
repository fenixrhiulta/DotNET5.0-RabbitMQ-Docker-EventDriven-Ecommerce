using MS_Messenger.Domain;

namespace MS_Messenger.Service
{
    public interface IMessengerService
    {
        SendPaymentEmailResponse PostSendPaymentEmailService(SendPaymentEmailRequest paymentRequest);
    }
}