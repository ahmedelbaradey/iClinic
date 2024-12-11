using iClinic.Application.Base;
using iClinic.Application.Features.Authorizations.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Queries.Handlers.GetRoleList
{
    public class GetRoleListQuery : IQuery<BaseResponse<List<GetRoleListResponse>>>
    {

    }
}
