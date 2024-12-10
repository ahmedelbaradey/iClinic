using iClinic.Application.Features.ClinicDepartments.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.ClinicDepartments
{
    public partial class ClinicDepartmentProfile
    {
        public void AddClinicDepartmentMapping()
        {
            CreateMap<AddClinicDepartmentCommand, ClinicDepartment>();
        }
    }
}
