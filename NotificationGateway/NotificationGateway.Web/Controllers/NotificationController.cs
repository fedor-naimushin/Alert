using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationGateway.Application.Commands;
using NotificationGateway.Application.Models;
using NotificationGateway.Application.Models.Front;
using NotificationGateway.Web.Extensions;

namespace NotificationGateway.Web.Controllers;

[Route("api/[controller]")]
public class NotificationController(IMediator mediator) : ControllerBase
{
    [HttpPost("addRequest")]
    public async Task<ActionResult<int>> AddRequest([FromBody] IReadOnlyList<NotificationFront> notification)
    {
        var result = await mediator.Send(new AddNotificationRequests.Command { NotificationFronts = notification });
        return result.ToActionResult();
    }
}