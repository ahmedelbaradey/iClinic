using iClinic.Application.Features.StatusHistories.Querires.Responses;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.StatusHistories
{
    public partial class StatusHistoryProfile
    {
        public void GetStatusHistoryListMapping()
        {
            CreateMap<StatusHistory, GetStatusHistoryListResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StatusHistoryId))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.AppointmentStatus.StatusName));

        }
    }
}
