using iClinic.Application.Base;

namespace iClinic.Application.Features.Authorizations.Commands.Handlers.EditRole
{
    public record EditRoleCommand : ICommand<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string roleName { get; set; } = null!;
    }
}
