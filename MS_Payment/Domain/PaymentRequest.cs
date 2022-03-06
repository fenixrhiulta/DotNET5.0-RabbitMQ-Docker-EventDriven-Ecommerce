using System;

namespace MS_Payment.Domain
{
    public class PaymentRequest
    {
        public Guid UserId { get; set; }
        public string CardNumber { get; set; }
        public Guid OrderId { get; set; }
    }
}
