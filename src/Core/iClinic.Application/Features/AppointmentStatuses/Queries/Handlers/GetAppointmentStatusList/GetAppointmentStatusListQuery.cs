using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Queries.Handlers.GetAppointmentStatusList
{
    public class GetAppointmentStatusListQuery : IQuery<BaseResponse<List<GetAppointmentStatusListResponse>>>
    {

    }
}
