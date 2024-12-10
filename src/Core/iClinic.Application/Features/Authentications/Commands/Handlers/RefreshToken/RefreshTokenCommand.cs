using iClinic.Application.Base;
using iClinic.Domain.Helpers;
using MediatR;

namespace iClinic.Application.Features.Authentications.Commands.Handlers.RefreshToken
{
    public record RefreshTokenCommand : ICommand<BaseResponse<JwtAuthResponse>>
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
