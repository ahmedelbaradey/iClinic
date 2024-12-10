using iClinic.Application.Base;
using iClinic.Domain.Helpers;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Queries.Models
{
    public class ManagerUserRolesQuery : IRequest<BaseResponse<ManagerUserRolesResponse>>
    {
        public ManagerUserRolesQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
