using iClinic.Application.Features.StatusHistories.Querires.Responses;
using iClinic.Application.Wappers;
using MediatR;

namespace iClinic.Application.Features.StatusHistories.Querires.Models
{
    public class GetStatusHistoryPaginatedQuery : IRequest<PaginatedResult<GetStatusHistoryPaginatedResponse>>
    {
        public int PageNumer { get; set; }
        public int PageSize { get; set; }
        public string? statusName { get; set; }
    }
}
