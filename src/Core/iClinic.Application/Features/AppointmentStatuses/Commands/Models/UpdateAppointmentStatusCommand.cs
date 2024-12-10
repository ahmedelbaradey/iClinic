using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Models
{
    public class UpdateAppointmentStatusCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string statusName { get; set; } = null!;
    }
}
