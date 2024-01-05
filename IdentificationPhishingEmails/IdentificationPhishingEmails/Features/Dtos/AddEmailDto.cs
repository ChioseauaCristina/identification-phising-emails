using IdentificationPhishingEmails.Models;

namespace IdentificationPhishingEmails.Features.Dtos
{
    public class AddEmailDto
    {
        public string Sender { get; set; }
        public string Content { get; set; }

        public static explicit operator Email(AddEmailDto emailDto)
        {
            return new()
            {
                Sender = emailDto.Sender,
                Content = emailDto.Content,
            };
        }
    }
}
