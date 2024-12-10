using iClinic.Application.Base;
using iClinic.Application.Features.Appointments.Queries.Responses;
 
namespace iClinic.Application.Features.Appointments.Queries.Handlers.GetAppointmentById
{
    public class GetAppointmentByIdQuery : IQuery<BaseResponse<GetSingleAppointmentResponse>>
    {
        public int Id { get; set; }
    }
}
