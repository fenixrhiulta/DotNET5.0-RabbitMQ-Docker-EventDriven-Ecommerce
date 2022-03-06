using MS_Messenger.Domain;

namespace MS_Messenger.Repository
{
    public interface IMessengerRepository
    {
        bool SendMessageToPaymentEmailQueue(SendPaymentEmailRequest request);
    }
}