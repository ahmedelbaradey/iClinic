using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Commands.Models
{
    public class DeleteRoleCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }

        public DeleteRoleCommand(int id)
        {
            Id = id;
        }
    }
}
