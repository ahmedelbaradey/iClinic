using iClinic.Application.Base;
using iClinic.Application.Features.Schedules.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Schedules.Queries.Models
{
    public class GetScheduleByIdQuery : IRequest<BaseResponse<GetScheduleByIdResponse>>
    {
        public int Id { get; set; }
        public GetScheduleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
