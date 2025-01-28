using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.UpdateAppointmentStatuses
{
    public class UpdateAppointmentStatusCommand : ICommand<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string statusName { get; set; } = null!;
    }
}
