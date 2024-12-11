using iClinic.Application.Base;
using iClinic.Domain.Helpers;

namespace iClinic.Application.Features.Authorizations.Commands.Handlers.EditUserRoles
{
    public class EditUserRolesCommand : EditUserRolesRequest, ICommand<BaseResponse<string>>
    {

    }
}
