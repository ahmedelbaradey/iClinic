using iClinic.Application.Base;
using iClinic.Application.Features.Appointments.Queries.Responses;
using iClinic.Application.Wappers;
 

namespace iClinic.Application.Features.Appointments.Queries.Handlers.GetAppointmentPaginated
{
    public class GetAppointmentPaginatedQuery : IQuery<PaginatedResult<GetAppointmentPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string? DoctorName { get; set; }
        public string? PatientName { get; set; }
        public string? StatusName { get; set; }
    }
}
