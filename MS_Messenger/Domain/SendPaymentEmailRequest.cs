using System;

namespace MS_Messenger.Domain
{
    public class SendPaymentEmailRequest
    {
        public Guid UserId { get; set; }
        public string CardNumber { get; set; }
        public Guid OrderId { get; set; }
    }
}
