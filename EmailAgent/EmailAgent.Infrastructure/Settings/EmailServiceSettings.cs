namespace MusicStore.EmailAgent.Infrastructure.Settings
{
    public class EmailServiceSettings
    {
        public string SmtpServerAdress { get; set; }
        public int SmtpServerPort { get; set; }
        public EmailSenderSettings Sender { get; set; }
        public bool IsNeedToUseSsl { get; set; }
    }
}
