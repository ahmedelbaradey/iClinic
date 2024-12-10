using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Models
{
    public class AddAppointmentStatusCommand : IRequest<BaseResponse<string>>
    {
        public string StatusName { get; set; } = null!;
    }
}
