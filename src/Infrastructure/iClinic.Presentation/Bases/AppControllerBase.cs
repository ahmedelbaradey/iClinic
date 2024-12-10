﻿using iClinic.Application.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace  iClinic.Presentation.Bases
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public ObjectResult NewResult<T>(BaseResponse<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult();
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Conflict:
                    return new ConflictObjectResult(response);
                case HttpStatusCode.InternalServerError:
                    return new ObjectResult(response) { StatusCode = StatusCodes.Status500InternalServerError };
                default:
                    return new ObjectResult(response) { StatusCode = (int)response.StatusCode };
            }
        }

    }
}
