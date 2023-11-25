using IdentificationPhishingEmails.Features.Dtos;
using IdentificationPhishingEmails.Models;
using MediatR;

namespace IdentificationPhishingEmails.Features.Commands.AddEmail
{
    public class AddEmailCommand : IRequest<Email>
    {
        public AddEmailDto NewEmail { get; set; }
    }
}
