using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Queries.Handlers.GetAppointmentStatusLById
{
    public class GetAppointmentStatusLByIdQuery : IQuery<BaseResponse<GetSingleAppointmentStatusResponse>>
    {
        public int Id { get; set; }
      
    }
}
