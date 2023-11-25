using MediatR;

namespace IdentificationPhishingEmails.Features.Commands.DeleteEmail
{
    public class DeleteEmailCommand : IRequest
    {
        public int Id { get; set; }
    }
}
