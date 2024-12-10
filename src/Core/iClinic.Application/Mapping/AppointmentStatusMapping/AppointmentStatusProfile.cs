using AutoMapper;

namespace iClinic.Application.Mapping.AppointmentStatusMapping
{
    public partial class AppointmentStatusProfile : Profile
    {

        public AppointmentStatusProfile()
        {
            GetAppointmentStatusListMapping();
            GetSingleAppointmentStatusMapping();
        }
    }
}
