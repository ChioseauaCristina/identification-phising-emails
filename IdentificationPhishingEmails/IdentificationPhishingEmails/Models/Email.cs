namespace IdentificationPhishingEmails.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string Receiver { get; set; }
        public  string Sender { get; set ; }
        public string Title { get; set; }
        public  string Content { get; set; }
    }
}
