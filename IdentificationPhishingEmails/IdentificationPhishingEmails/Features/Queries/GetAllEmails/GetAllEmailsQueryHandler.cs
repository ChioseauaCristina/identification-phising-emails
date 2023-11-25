using IdentificationPhishingEmails.Data;
using IdentificationPhishingEmails.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentificationPhishingEmails.Features.Queries.GetAllEmails
{
    public class GetAllEmailsQueryHandler : IRequestHandler<GetAllEmailsQuery, IEnumerable<Email>>
    {
        private readonly DataContext _dataContext;
        public GetAllEmailsQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Email>> Handle(GetAllEmailsQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.Emails.ToListAsync(cancellationToken);
        }
    }
}
