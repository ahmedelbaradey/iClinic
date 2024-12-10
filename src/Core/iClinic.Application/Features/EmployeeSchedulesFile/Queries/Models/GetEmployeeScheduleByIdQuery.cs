using iClinic.Application.Base;
using iClinic.Application.Features.EmployeeSchedulesFile.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.EmployeeSchedulesFile.Queries.Models
{
    public class GetEmployeeScheduleByIdQuery : IRequest<BaseResponse<GetSingleEmployeeScheduleResponse>>
    {
        public int Id { get; set; }
        public GetEmployeeScheduleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
