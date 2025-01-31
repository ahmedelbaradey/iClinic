using iClinic.Application.Base;
using iClinic.Application.Features.Appointments.Commands.Base;
 

namespace iClinic.Application.Features.Appointments.Commands.Handlers.EditAppointment
{
    public record EditAppointmentCommand : BaseAppointmentCommand, ICommand<BaseResponse<string>>
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientCaseId { get; set; }
        public int AppointmentStatusId { get; set; }
    }
}
