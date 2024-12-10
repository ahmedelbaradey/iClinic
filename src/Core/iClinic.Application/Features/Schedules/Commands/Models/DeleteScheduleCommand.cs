using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Schedules.Commands.Models
{
    public class DeleteScheduleCommand : IRequest<BaseResponse<string>>
    {

        public int Id { get; set; }
        public DeleteScheduleCommand(int ID)
        {
            Id = ID;
        }
    }
}
