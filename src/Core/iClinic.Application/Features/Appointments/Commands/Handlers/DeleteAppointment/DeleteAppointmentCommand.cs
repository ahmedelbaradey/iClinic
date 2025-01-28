using iClinic.Application.Base;

namespace iClinic.Application.Features.Appointments.Commands.Handlers.DeleteAppointment
{
    public record DeleteAppointmentCommand : ICommand<BaseResponse<string>>
    {
        public int Id   { get; set; }
    }
}
