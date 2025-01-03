using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationGateway.Application.Commands;
using NotificationGateway.Application.Models.Front;
using NotificationGateway.Core;
using NotificationGateway.Web.Extensions;

namespace NotificationGateway.Web.Controllers;

[Route("api/[controller]")]
public class NotificationController(IMediator mediator) : ControllerBase
{
    [HttpPost("addRequest")]
    public async Task<ActionResult<Notification>> AddRequest([FromBody] NotificationFront notification)
    {
        var result = await mediator.Send(new AddNotificationRequest.Command { NotificationFronts = notification });
        return result.ToActionResult();
    }
}