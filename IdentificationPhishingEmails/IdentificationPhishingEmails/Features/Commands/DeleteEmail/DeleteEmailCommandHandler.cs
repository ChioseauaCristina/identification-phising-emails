using IdentificationPhishingEmails.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentificationPhishingEmails.Features.Commands.DeleteEmail
{
    public class DeleteEmailCommandHandler : IRequestHandler<DeleteEmailCommand>
    {
        private readonly DataContext _dataContext;
        public DeleteEmailCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Handle(DeleteEmailCommand request, CancellationToken cancellationToken)
        {
            var isEmailInDb = await _dataContext.Emails.FirstOrDefaultAsync(e => e.Id == request.Id);
            if (isEmailInDb is null)
            {
                throw new Exception($"Email with id: {request.Id} does not exists!");
            }

            _dataContext.Emails.Remove(isEmailInDb);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
