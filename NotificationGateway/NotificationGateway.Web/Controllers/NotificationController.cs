using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationGateway.Application.Commands;
using NotificationGateway.Application.Models;
using NotificationGateway.Application.Queries;
using NotificationGateway.Web.Extensions;

namespace NotificationGateway.Web.Controllers;

public class NotificationController(IMediator mediator) : ControllerBase
{
    [HttpGet("getById/{id}")]
    public async Task<ActionResult<NotificationInfo>> GetById(long id)
    {
        var result = await mediator.Send(new GetNotification.Query { Id = id });
        return result.ToActionResult();
    }

    [HttpPost("add")]
    public async Task<ActionResult<NotificationInfo>> Add([FromBody] NotificationInfo notification)
    {
        var result = await mediator.Send(new AddNotification.Command { NotificationInfo = notification });
        return result.ToActionResult();
    }
}