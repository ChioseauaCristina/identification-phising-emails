using IdentificationPhishingEmails.Data;
using IdentificationPhishingEmails.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentificationPhishingEmails.Features.Commands.AddEmail
{
    public class AddEmailCommandHandler : IRequestHandler<AddEmailCommand, Email>
    {
        private readonly DataContext _dataContext;
        public AddEmailCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }

        public async Task<Email> Handle(AddEmailCommand request, CancellationToken cancellationToken)
        {
            var isAlreadyInDb = await _dataContext.Emails.FirstOrDefaultAsync(e => e.Content == request.Email.Content, cancellationToken);
            if (isAlreadyInDb is not null)
            {
                throw new Exception($"Email with content: {request.Email.Content} already exists!");
            }
            
            await _dataContext.Emails.AddAsync(request.Email, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return request.Email;
        }
    }
}
