using IdentificationPhishingEmails.Features.Commands.AddEmail;
using IdentificationPhishingEmails.Features.Commands.DeleteEmail;
using IdentificationPhishingEmails.Features.Commands.UpdateEmail;
using IdentificationPhishingEmails.Features.Dtos;
using IdentificationPhishingEmails.Features.Queries.GetAllEmails;
using IdentificationPhishingEmails.Features.Queries.GetEmailByReceiver;
using IdentificationPhishingEmails.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IdentificationPhishingEmails.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/allEmails")]
        [ProducesResponseType(typeof(IEnumerable<Email>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAllEmails()
        {
            var response = await _mediator.Send(new GetAllEmailsQuery());
            return Ok(response);
        }

        [HttpGet("{receiver}")]
        [ProducesResponseType(typeof(Email), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetEmailByReceiver(string receiver)
        {
            var response = await _mediator.Send(new GetEmailByReceiverQuery() { Receiver = receiver });
            return Ok(response);
        }

        [HttpPost("/addEmailsSimplified")]
        [ProducesResponseType(typeof(List<Email>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddEmailsSimplified([FromBody] List<AddEmailDto> newEmails)
        {
            var response = await _mediator.Send(new AddEmailsSimplifiedCommand() { NewEmails = newEmails });
            return Ok(response);
        }

        [HttpPost("/addEmails")]
        [ProducesResponseType(typeof(List<Email>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddEmails([FromBody] List<AddEmailDto> newEmails)
        {
            var response = await _mediator.Send(new AddEmailsCommand() { NewEmails = newEmails });
            return Ok(response);
        }

        [HttpPut("/modifyEmail/{emailId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> ModifyEmail(int emailId, [FromBody] UpdateEmailDto updateEmail)
        {
            await _mediator.Send(new UpdateEmailCommand() { Id = emailId, Email = updateEmail });
            return Ok();
        }

        [HttpDelete("/deleteEmail/{emailId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteEmail(int emailId)
        {
            await _mediator.Send(new DeleteEmailCommand() { Id = emailId });
            return Ok();
        }
    }
}
