using iClinic.Application.Features.AppointmentStatuses.Queries.Responses;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.AppointmentStatusMapping
{
    public partial class AppointmentStatusProfile
    {
        public void GetAppointmentStatusListMapping()
        {
            CreateMap<AppointmentStatus, GetAppointmentStatusListResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AppointmentStatusId));
        }
    }
}
