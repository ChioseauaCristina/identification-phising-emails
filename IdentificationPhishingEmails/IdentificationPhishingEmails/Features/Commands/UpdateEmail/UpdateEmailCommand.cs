using IdentificationPhishingEmails.Features.Dtos;
using MediatR;

namespace IdentificationPhishingEmails.Features.Commands.UpdateEmail
{
    public class UpdateEmailCommand : IRequest
    {
        public string Receiver { get; set; } 
        public UpdateEmailDto Email { get; set; }
    }
}
