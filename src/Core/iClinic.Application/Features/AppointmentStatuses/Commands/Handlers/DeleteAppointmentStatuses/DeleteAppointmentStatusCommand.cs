using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.DeleteAppointmentStatuses
{
    public class DeleteAppointmentStatusCommand : ICommand<BaseResponse<string>>
    {
        public int Id { get; set; } 
    }
}
