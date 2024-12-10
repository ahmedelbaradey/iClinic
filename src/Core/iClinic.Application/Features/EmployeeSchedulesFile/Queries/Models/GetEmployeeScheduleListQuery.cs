using iClinic.Application.Base;
using iClinic.Application.Features.EmployeeSchedulesFile.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.EmployeeSchedulesFile.Queries.Models
{
    public class GetEmployeeScheduleListQuery : IRequest<BaseResponse<List<GetEmployeeScheduleListResponse>>>
    {

    }
}
