using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Schedules.Commands.Models
{
    public class AddScheduleCommand : IRequest<BaseResponse<string>>
    {

        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int EmployeeSchedulesId { get; set; }
    }
}
