using iClinic.Application.Base;
using iClinic.Domain.Helpers;
using MediatR;

namespace iClinic.Application.Features.Authentications.Commands.Handlers.SignIn
{
    public record SignInCommand : ICommand<BaseResponse<JwtAuthResponse>>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
