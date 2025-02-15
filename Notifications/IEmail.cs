namespace Portafolio.Notifications
{
    public interface IEmail
    {
        string Destiny { get; set; }
        string Message { get; set; }
        string Subject { get; set; }
        bool IsSent { get; set; }

        void Send();
    }
}
