using iClinic.Application.Base;
using iClinic.Application.Features.Users.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<BaseResponse<GetUserByIdResponse>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
