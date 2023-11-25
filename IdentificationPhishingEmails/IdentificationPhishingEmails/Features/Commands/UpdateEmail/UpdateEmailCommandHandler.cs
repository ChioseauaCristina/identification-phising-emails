using IdentificationPhishingEmails.Data;
using IdentificationPhishingEmails.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentificationPhishingEmails.Features.Commands.UpdateEmail
{
    public class UpdateEmailCommandHandler : IRequestHandler<UpdateEmailCommand>
    {
        private readonly DataContext _dataContext;
        public UpdateEmailCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
        {
            var isEmailInDb = await _dataContext.Emails.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            if (isEmailInDb is null)
            {
                throw new Exception($"Email with id: {request.Id}  does not exists!");
            }

            isEmailInDb.Content = request.Email.Content; 

            _dataContext.Emails.Update(isEmailInDb);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
