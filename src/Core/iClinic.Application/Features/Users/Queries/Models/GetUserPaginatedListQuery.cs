using iClinic.Application.Features.Users.Queries.Responses;
using iClinic.Application.Wappers;
using MediatR;

namespace iClinic.Application.Features.Users.Queries.Models
{
    public class GetUserPaginatedListQuery : IRequest<PaginatedResult<GetUserPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
