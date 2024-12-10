using iClinic.Application.Features.ClinicDepartments.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.ClinicDepartments
{
    public partial class ClinicDepartmentProfile
    {
        public void EditClinicDepartmentMapping()
        {
            CreateMap<EditClinicDepartmentCommand, ClinicDepartment>()
               .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
