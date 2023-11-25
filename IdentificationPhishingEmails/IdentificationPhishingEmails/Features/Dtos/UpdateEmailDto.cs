using IdentificationPhishingEmails.Models;

namespace IdentificationPhishingEmails.Features.Dtos
{
    public class UpdateEmailDto
    {
        public string Content { get; set; }

        public static explicit operator Email(UpdateEmailDto dto)
        {
            return new()
            {
                Content = dto.Content
            };
        }
    }
}
