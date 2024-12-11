using iClinic.Application.Base;
using iClinic.Application.Features.Authorizations.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Queries.Handlers.GetRoleById
{
    public class GetRoleByIdQuery : IQuery<BaseResponse<GetRoleByIdResponse>>
    {
        public int Id { get; set; }
    }
}
