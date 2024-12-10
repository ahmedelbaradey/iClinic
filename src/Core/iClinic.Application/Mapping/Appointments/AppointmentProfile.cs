using AutoMapper;

namespace iClinic.Application.Mapping.Appointments
{
    public partial class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            AddAppointmentMapping();
            EditAppointmentMapping();
            GetAppointmentListMapping();
            GetAppointmentByIdMapping();
        }
    }
}
