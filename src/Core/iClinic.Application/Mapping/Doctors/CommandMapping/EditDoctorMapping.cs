
using iClinic.Application.Features.Doctors.Commands.Handlers.EditDoctor;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void EditDoctorMapping()
        {
            CreateMap<EditDoctorCommand, Doctor>().ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
