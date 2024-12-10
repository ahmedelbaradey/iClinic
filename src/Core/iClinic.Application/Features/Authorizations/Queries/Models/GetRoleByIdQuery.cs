using iClinic.Application.Base;
using iClinic.Application.Features.Authorizations.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Authorizations.Queries.Models
{
    public class GetRoleByIdQuery : IRequest<BaseResponse<GetRoleByIdResponse>>
    {
        public int Id { get; set; }

        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
