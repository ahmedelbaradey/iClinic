using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Commands.Models
{
    public class EditRoleCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string roleName { get; set; } = null!;
    }
}
