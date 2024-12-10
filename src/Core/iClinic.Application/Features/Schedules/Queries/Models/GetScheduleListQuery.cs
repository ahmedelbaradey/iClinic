using iClinic.Application.Base;
using iClinic.Application.Features.Schedules.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Schedules.Queries.Models
{
    public class GetScheduleListQuery : IRequest<BaseResponse<List<GetScheduleListResponse>>>
    {

    }
}
