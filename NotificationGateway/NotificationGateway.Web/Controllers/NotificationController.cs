using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationGateway.Application.Commands;
using NotificationGateway.Application.Models;
using NotificationGateway.Application.Models.Front;
using NotificationGateway.Web.Extensions;

namespace NotificationGateway.Web.Controllers;

public class NotificationController(IMediator mediator) : ControllerBase
{
    [HttpPost("addRequest")]
    public async Task<ActionResult<NotificationInfo>> AddRequest([FromBody] NotificationFront notification)
    {
        var result = await mediator.Send(new AddNotificationRequest.Command { NotificationFront = notification });
        return result.ToActionResult();
    }
}