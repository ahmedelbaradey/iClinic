using iClinic.Application.Features.PatientCases.Queries.Responses;
using iClinic.Application.Wappers;
using MediatR;

namespace iClinic.Application.Features.PatientCases.Queries.Models
{
    public class GetPatientCasePaginatedQuery : IRequest<PaginatedResult<GetPatientCasePaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? search { get; set; }

    }
}
