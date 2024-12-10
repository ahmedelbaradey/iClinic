using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Schedules.Commands.Models
{
    public class EditScheduleCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int EmployeeSchedulesId { get; set; }
    }
}
