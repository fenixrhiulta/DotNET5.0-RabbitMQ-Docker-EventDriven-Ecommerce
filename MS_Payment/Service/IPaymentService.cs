using MS_Payment.Domain;

namespace MS_Payment.Service
{
    public interface IPaymentService
    {
        PaymentResponse PostPaymentService(PaymentRequest paymentRequest);
    }
}