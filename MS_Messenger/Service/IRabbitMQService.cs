namespace MS_Messenger.Service
{
    public interface IRabbitMQService
    {
        bool SendMessage(object request, string exchange, string routingKey);
    }
}