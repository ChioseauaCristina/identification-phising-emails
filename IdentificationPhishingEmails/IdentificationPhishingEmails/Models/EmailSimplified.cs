namespace IdentificationPhishingEmails.Models
{
    public class EmailSimplified
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
        public bool IsSpam { get; set; }
    }
}
