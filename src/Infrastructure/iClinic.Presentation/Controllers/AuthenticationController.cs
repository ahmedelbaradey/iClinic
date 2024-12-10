using iClinic.Presentation.Bases;
using Microsoft.AspNetCore.Mvc;
using iClinic.Application.Features.Authentications.Commands.Handlers.RefreshToken;
using iClinic.Application.Features.Authentications.Commands.Handlers.SignIn;
using iClinic.Application.Features.Authentications.Queries.Handlers.ValidateAccessToken;

namespace iClinic.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {

        [HttpPost("Sign-In")]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost("Refresh-Token")]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet("Is-Valid_Token")]
        public async Task<IActionResult> IsValidToken([FromQuery] AccessTokenQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

    }
}
