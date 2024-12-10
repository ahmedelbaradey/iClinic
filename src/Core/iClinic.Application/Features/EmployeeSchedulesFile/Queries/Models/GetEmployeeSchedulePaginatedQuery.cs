using iClinic.Application.Features.EmployeeSchedulesFile.Queries.Responses;
using iClinic.Application.Wappers;
using MediatR;

namespace iClinic.Application.Features.EmployeeSchedulesFile.Queries.Models
{
    public class GetEmployeeSchedulePaginatedQuery : IRequest<PaginatedResult<GetEmployeeSchedulePaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool IsActive { get; set; }
    }
}
