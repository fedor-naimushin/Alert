using Microsoft.AspNetCore.Mvc;
using NotificationGateway.Core.Enums;
using NotificationGateway.Core.Infrastructure;

namespace NotificationGateway.Web.Extensions;

public static class ResultExtensions
{
    public static ActionResult<TResult> ToActionResult<TResult>(this Result<TResult> result)
    {
        return result.Code switch
        {
            ResultCode.Ok => new OkObjectResult(result.Value),
            ResultCode.Fail => new BadRequestObjectResult(result.ErrorMessage),
            ResultCode.NotFound => new NotFoundObjectResult(result.ErrorMessage),
            ResultCode.Forbidden => new ForbidResult(result.ErrorMessage!),
            ResultCode.AlreadyExist => new ObjectResult(result.ErrorMessage){ StatusCode = 409 },
            _ => new BadRequestObjectResult(result.ErrorMessage)
        };
    } 
}