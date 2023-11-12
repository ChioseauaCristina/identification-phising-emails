using IdentificationPhishingEmails.Models;
using MediatR;

namespace IdentificationPhishingEmails.Features.Commands.AddEmail
{
    public class AddEmailCommand : IRequest<Email>
    {
        public Email Email { get; set; }
    }
}
