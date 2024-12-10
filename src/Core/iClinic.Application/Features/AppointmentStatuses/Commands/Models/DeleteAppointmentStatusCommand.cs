using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Models
{
    public class DeleteAppointmentStatusCommand : IRequest<BaseResponse<string>>
    {
        public int ID { get; set; }
        public DeleteAppointmentStatusCommand(int Id)
        {
            ID = Id;
        }
    }
}
