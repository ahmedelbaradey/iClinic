using iClinic.Application.Base;

namespace iClinic.Application.Features.Authorizations.Commands.Handlers.AddRole
{
    public record AddRoleCommand : ICommand<BaseResponse<string>>
    {
        public string roleName { get; set; } = null!;
    }
}
