using iClinic.Application.Base;
using iClinic.Application.Features.Authorizations.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Queries.Models
{
    public class GetRoleListQuery : IRequest<BaseResponse<List<GetRoleListResponse>>>
    {

    }
}
