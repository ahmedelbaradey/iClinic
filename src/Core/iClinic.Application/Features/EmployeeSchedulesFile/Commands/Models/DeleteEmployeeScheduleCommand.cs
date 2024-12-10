using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.EmployeeSchedulesFile.Commands.Models
{
    public class DeleteEmployeeScheduleCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public DeleteEmployeeScheduleCommand(int id)
        {
            Id = id;
        }
    }
}
