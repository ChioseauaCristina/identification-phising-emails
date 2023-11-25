using IdentificationPhishingEmails.Models;

namespace IdentificationPhishingEmails.Features.Dtos
{
    public class AddEmailDto
    {
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public static explicit operator Email(AddEmailDto emailDto)
        {
            return new()
            {
                Receiver = emailDto.Receiver,
                Sender = emailDto.Sender,
                Title = emailDto.Title,
                Content = emailDto.Content
            };
        }
    }
}
