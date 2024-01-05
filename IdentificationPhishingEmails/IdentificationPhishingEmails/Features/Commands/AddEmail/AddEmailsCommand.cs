using IdentificationPhishingEmails.Features.Dtos;
using IdentificationPhishingEmails.Models;
using MediatR;
using System.Collections.Generic;

namespace IdentificationPhishingEmails.Features.Commands.AddEmail
{
    public class AddEmailsCommand : IRequest<List<Email>>
    {
        public List<AddEmailDto> NewEmails { get; set; }
    }
}