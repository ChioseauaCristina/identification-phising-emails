using IdentificationPhishingEmails.Features.Dtos;
using IdentificationPhishingEmails.Models;
using MediatR;
using System.Collections.Generic;

namespace IdentificationPhishingEmails.Features.Commands.AddEmail
{
    public class AddEmailsSimplifiedCommand : IRequest<List<EmailSimplified>>
    {
        public List<AddEmailDto> NewEmails { get; set; }
    }
}
