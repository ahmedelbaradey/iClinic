using iClinic.Application.Features.Schedules.Queries.Responses;
using iClinic.Application.Wappers;
using MediatR;

namespace iClinic.Application.Features.Schedules.Queries.Models
{
    public class GetSchedulePaginatedQuery : IRequest<PaginatedResult<GetSchedulePaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public DateTime? Date { get; set; }
    }
}
