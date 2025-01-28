using iClinic.Application.Base;

namespace iClinic.Application.Features.Appointments.Commands.Handlers.AddAppointment
{
    public record AddAppointmentCommand : ICommand<BaseResponse<string>>
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientCaseId { get; set; }
        public int AppointmentStatusId { get; set; }
    }
}
