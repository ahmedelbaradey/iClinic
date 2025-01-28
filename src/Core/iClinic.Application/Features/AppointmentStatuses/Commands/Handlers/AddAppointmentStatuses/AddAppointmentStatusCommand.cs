using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.AddAppointmentStatuses
{
    public class AddAppointmentStatusCommand : ICommand<BaseResponse<string>>
    {
        public string StatusName { get; set; } = null!;
    }
}
