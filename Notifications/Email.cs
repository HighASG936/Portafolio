using System.Net.Mail;
using System.Net;

namespace Portafolio.Notifications
{
    public class Email : IEmail
    {
        public required string Destiny { get; set; }
        public required string Message { get; set; }
        public required string Subject { get; set; }
        
        public bool IsSent { get; set; } = false;

        public void Send()
        {
            try
            {
                string sender = "lz.g.rock@gmail.com";
                var password = Environment.GetEnvironmentVariable("GMAIL_PASSWORD");

                var clienteSmtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(sender, password),
                    EnableSsl = true
                };

                MailMessage correo = new MailMessage(sender, Destiny, Subject, Message);
                clienteSmtp.Send(correo);
                IsSent = true;
                Console.WriteLine("Correo enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
