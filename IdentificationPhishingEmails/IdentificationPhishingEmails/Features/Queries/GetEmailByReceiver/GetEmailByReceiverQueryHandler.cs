using IdentificationPhishingEmails.Data;
using IdentificationPhishingEmails.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentificationPhishingEmails.Features.Queries.GetEmailByReceiver
{
    public class GetEmailByReceiverQueryHandler : IRequestHandler<GetEmailByReceiverQuery, Email>
    {
        private readonly DataContext _dataContext;
        public GetEmailByReceiverQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Email> Handle(GetEmailByReceiverQuery request, CancellationToken cancellationToken)
        {
            var email = await _dataContext.Emails
                .Where(e => e.Receiver == request.Receiver)
                .FirstOrDefaultAsync(cancellationToken);
            if (email == null)
            {
                throw new Exception($"Email with receiver: {request.Receiver} does not exists!");
            }

            return email;
        }
    }
}
