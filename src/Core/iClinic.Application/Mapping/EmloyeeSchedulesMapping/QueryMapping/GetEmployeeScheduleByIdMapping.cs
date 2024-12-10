using iClinic.Application.Features.EmployeeSchedulesFile.Queries.Responses;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.EmloyeeSchedulesMapping
{
    public partial class EmployeeScheduleProfile
    {
        public void GetEmployeeScheduleByIdMapping()
        {
            CreateMap<EmployeeSchedules, GetSingleEmployeeScheduleResponse>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmployeeSchedulesId))
                            .ForMember(dest => dest.doctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
                            .ForMember(dest => dest.departmentName, opt => opt.MapFrom(src => src.ClinicDepartment.DepartmentName));

        }
    }
}
