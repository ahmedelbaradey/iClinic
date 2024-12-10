using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Queries.Models
{
    public class GetAppointmentStatusListQuery : IRequest<BaseResponse<List<GetAppointmentStatusListResponse>>>
    {

    }
}
