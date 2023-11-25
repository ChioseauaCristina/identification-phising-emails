using IdentificationPhishingEmails.Features.Dtos;
using IdentificationPhishingEmails.Models;
using MediatR;

namespace IdentificationPhishingEmails.Features.Commands.UpdateEmail
{
    public class UpdateEmailCommand : IRequest
    {
        public int Id { get; set; }
        public UpdateEmailDto Email { get; set; }
    }
}
