using iClinic.Application.Features.Patients.Queries.Responses;
using iClinic.Application.Wappers;
using MediatR;

namespace iClinic.Application.Features.Patients.Queries.Models
{
    public class GetPatientsPaginatedListQuery : IRequest<PaginatedResult<GetPatientsPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Serach { get; set; }
    }
}
