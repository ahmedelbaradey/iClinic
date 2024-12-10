using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Queries.Models
{
    public class GetAppointmentStatusLByIdQuery : IRequest<BaseResponse<GetSingleAppointmentStatusResponse>>
    {
        public int Id { get; set; }
        public GetAppointmentStatusLByIdQuery(int id)
        {
            Id = id;
        }
    }
}
