using iClinic.Application.Base;

namespace iClinic.Application.Features.Authorizations.Commands.Handlers.DeleteRole
{
    public record DeleteRoleCommand : ICommand<BaseResponse<string>>
    {
        public int Id { get; set; }
    }
}
