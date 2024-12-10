using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Commands.Models
{
    public class AddRoleCommand : IRequest<BaseResponse<string>>
    {
        public string roleName { get; set; } = null!;
    }
}
