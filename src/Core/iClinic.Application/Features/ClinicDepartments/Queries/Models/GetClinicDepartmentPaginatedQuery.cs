using iClinic.Application.Features.ClinicDepartments.Queries.Responses;
using iClinic.Application.Wappers;
using MediatR;

namespace iClinic.Application.Features.ClinicDepartments.Queries.Models
{
    public class GetClinicDepartmentPaginatedQuery : IRequest<PaginatedResult<GetClinicDepartmentPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
