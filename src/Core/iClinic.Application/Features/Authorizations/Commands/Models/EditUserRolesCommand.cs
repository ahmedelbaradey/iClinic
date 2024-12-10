using iClinic.Application.Base;
using iClinic.Domain.Helpers;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Commands.Models
{
    public class EditUserRolesCommand : EditUserRolesRequest,
        IRequest<BaseResponse<string>>
    {

    }
}
