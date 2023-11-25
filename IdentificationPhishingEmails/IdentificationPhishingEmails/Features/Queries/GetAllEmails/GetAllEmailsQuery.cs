using IdentificationPhishingEmails.Models;
using MediatR;

namespace IdentificationPhishingEmails.Features.Queries.GetAllEmails
{
    public class GetAllEmailsQuery : IRequest<IEnumerable<Email>>
    {
    }
}
