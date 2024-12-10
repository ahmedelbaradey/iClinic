using AutoMapper;

namespace iClinic.Application.Mapping.Schedules
{
    public partial class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            AddScheduleMapping();
            EditScheduleMapping();
            GetScheduleListMapping();
            GetScheduleByIdMapping();
        }
    }
}
