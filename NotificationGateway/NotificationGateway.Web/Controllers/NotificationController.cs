using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationGateway.Application.Commands;
using NotificationGateway.Application.Models;
using NotificationGateway.Core;
using NotificationGateway.Core.Models;
using NotificationGateway.Web.Extensions;

namespace NotificationGateway.Web.Controllers;

[Route("api/[controller]")]
public class NotificationController(IMediator mediator) : ControllerBase
{
    [HttpPost("addMessage")]
    public async Task<ActionResult<Message>> AddMessage([FromBody] MessageFront message)
    {
        var result = await mediator.Send(new AddMessageRequest.Command { MessageFront = message });
        return result.ToActionResult();
    }
    
    [HttpPost("addEmail")]
    public async Task<ActionResult<Email>> AddEmail([FromBody] EmailFront message)
    {
        var result = await mediator.Send(new AddEmailRequest.Command { EmailFront = message });
        return result.ToActionResult();
    }
}