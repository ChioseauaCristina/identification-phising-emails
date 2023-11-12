using IdentificationPhishingEmails.Data;
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

        public Task<Unit> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
