using iClinic.Application.Base;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace iClinic.Application.Features.Authentications.Queries.Handlers.ValidateAccessToken
{
    public record AccessTokenQuery : IQuery<BaseResponse<string>>
    {

        public string Accesstoken { get; set; } = null!;
    }
}
