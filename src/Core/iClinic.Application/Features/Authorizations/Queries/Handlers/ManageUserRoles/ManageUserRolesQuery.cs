using iClinic.Application.Base;
using iClinic.Domain.Helpers;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Queries.Handlers.ManageUserRoles
{
    public class ManageUserRolesQuery : IQuery<BaseResponse<ManageUserRolesResponse>>
    {
        public int Id { get; set; }
    }
}
