using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationGateway.Application.Models;
using NotificationGateway.Application.Queries;

namespace NotificationGateway.Web.Controllers;

public class NotificationController(IMediator mediator) : ControllerBase
{
    [HttpGet("getById/{id}")]
    public async Task<ActionResult<NotificationInfo>> GetById(long id)
    {
        var result = await mediator.Send(new GetNotification.Query { Id = id });
        return result.IsSuccess
            ? Ok(result)
            : BadRequest(result.Message);
    }
}