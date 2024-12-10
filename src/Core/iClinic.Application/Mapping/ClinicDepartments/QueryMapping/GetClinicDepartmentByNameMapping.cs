using iClinic.Application.Features.ClinicDepartments.Queries.Responses;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.ClinicDepartments
{
    public partial class ClinicDepartmentProfile
    {
        public void GetClinicDepartmentByNameMapping()
        {
            CreateMap<ClinicDepartment, GetClinicDepartmentResponse>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DepartmentId))
              .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Clinic.Name));
        }
    }
}
