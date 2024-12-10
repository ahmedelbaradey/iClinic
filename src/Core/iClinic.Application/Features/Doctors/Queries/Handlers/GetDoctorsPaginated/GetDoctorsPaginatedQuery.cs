using iClinic.Application.Base;
using iClinic.Application.Features.Doctors.Queries.Response;
using iClinic.Application.Wappers;
using MediatR;

namespace iClinic.Application.Features.Doctors.Queries.Handlers.GetDoctorsPaginated
{
    public class GetDoctorsPaginatedQuery : IQuery<PaginatedResult<GetDoctorsPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
