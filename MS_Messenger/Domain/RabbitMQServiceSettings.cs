namespace MS_Messenger.Domain
{
    public class RabbitMQServiceSettings
    {
        public string Hostname { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Exchange { get; set; }
    }
}
