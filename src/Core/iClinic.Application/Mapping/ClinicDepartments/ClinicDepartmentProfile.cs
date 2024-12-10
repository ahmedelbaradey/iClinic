using AutoMapper;

namespace iClinic.Application.Mapping.ClinicDepartments
{
    public partial class ClinicDepartmentProfile : Profile
    {
        public ClinicDepartmentProfile()
        {
            AddClinicDepartmentMapping();
            EditClinicDepartmentMapping();
            GetClinicDepartmentListMapping();
            GetClinicDepartmentByIdMapping();
        }
    }
}
