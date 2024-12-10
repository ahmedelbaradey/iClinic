using AutoMapper;

namespace iClinic.Application.Mapping.EmloyeeSchedulesMapping
{
    public partial class EmployeeScheduleProfile : Profile
    {
        public EmployeeScheduleProfile()
        {
            AddEmployeeScheduleMapping();
            EditEmployeeScheduleMapping();
            GetEmployeeScheduleListMapping();
            GetEmployeeScheduleByIdMapping();
        }
    }
}
