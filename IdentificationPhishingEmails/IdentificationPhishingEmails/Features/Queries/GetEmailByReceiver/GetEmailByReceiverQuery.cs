using IdentificationPhishingEmails.Models;
using MediatR;

namespace IdentificationPhishingEmails.Features.Queries.GetEmailByReceiver
{
    public class GetEmailByReceiverQuery : IRequest<Email>
    {
        public string Receiver { get; set; }
    }
}
