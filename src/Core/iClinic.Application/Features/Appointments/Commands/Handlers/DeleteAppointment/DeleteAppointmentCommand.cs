using iClinic.Application.Base;

namespace iClinic.Application.Features.Appointments.Commands.Handlers.DeleteAppointment
{
    public class DeleteAppointmentCommand : ICommand<BaseResponse<string>>
    {
        public int Id   { get; set; }
    }
}
